using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO.Ports;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Management;
using Microsoft.Win32;
using System.Threading;

namespace TeensySoundfontReader_Interface
{
    public partial class MainForm : Form
    {
        System.Windows.Forms.Timer portScanTimer;
        int portScanIndex;

        SerialPort serial;
        string currLine = "";
        Queue<string> rxBuffer;

        string[] currPorts;

        string usbId = "";

        bool wantToDisconnect = false;

        System.IO.FileStream fsFileToSend;
        string fileToSend = "";
        BackgroundWorker bgwFileSend;
        class bgwFileSendEvent { public long size; public long curr;}

        public MainForm()
        {
            InitializeComponent();
            bgwFileSend = new BackgroundWorker();
            bgwFileSend.DoWork += bgwFileSend_DoWork;
            bgwFileSend.ProgressChanged += bgwFileSend_ProgressChanged;
            bgwFileSend.WorkerReportsProgress = true;

            serial = new SerialPort();
            serial.DataReceived += Serial_DataReceived;
            serial.ErrorReceived += Serial_ErrorReceived;
            

            rxBuffer = new Queue<string>();
            portScanTimer = new System.Windows.Forms.Timer();
            portScanTimer.Interval = 500;
            portScanTimer.Tick += PortScanTimer_Tick;

            
        }

        private void bgwFileSend_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            this.Invoke(new Action(() =>
            {
                progressBar1.Value = e.ProgressPercentage;
            }));
        }

        private void bgwFileSend_DoWork(object sender, DoWorkEventArgs e)
        {
            bgwFileSendEvent state = new bgwFileSendEvent();
            
            fsFileToSend = new System.IO.FileStream(fileToSend, System.IO.FileMode.Open);
            state.size = fsFileToSend.Length;
            byte[] buff = new byte[4096];
            int count = 0;
            int procent = 0;
            int procentOld = 0;
            while ((count = fsFileToSend.Read(buff, 0, 4096)) > 0)
            {
                if (serial.IsOpen == false) break;
                serial.Write(buff, 0, count);
                procent = (int)((double)fsFileToSend.Position / (double)fsFileToSend.Length * 100.0f);
                if (procent != procentOld) { procentOld = procent; bgwFileSend.ReportProgress(procent); }
            }
            fsFileToSend.Close();
        }

        private void GetCurrentComportUsbDeviceId(string comname)
        {
            string regPath = @"SYSTEM\ControlSet001\Control\COM Name Arbiter\Devices";
            RegistryKey key = Registry.LocalMachine.OpenSubKey(regPath);
            if (key == null) { rtxtLog.AppendLine("could not open reg subkey to get usb device id!"); return; }
            usbId = (string)key.GetValue(comname);
            if (usbId == null) { key.Close(); rtxtLog.AppendLine("could not read reg value to get usb device id!"); usbId = ""; return; }
            key.Close();
            usbId = usbId.Substring(8, 17).ToUpper();
            rtxtLog.AppendLine($"usb deviceid: {usbId}, for comport: {comname}");
        }

        private void PortScanTimer_Tick(object sender, EventArgs e)
        {
            portScanTimer.Stop();
            PortScanTryNext();
        }
        private void PortScanTryNext()
        {
            if (serial.IsOpen) serial.Close();
            if (portScanIndex == currPorts.Length)
            {
                rtxtLog.AppendLine("cannot find device");
                return;
            }
            serial.PortName = currPorts[portScanIndex++];
            serial.Open();
            if (serial.IsOpen)
            {
                portScanTimer.Start();
                serial.Write("ping\n");
            }
            else
                PortScanTryNext();
        }
        private void StartPortScan()
        {
            portScanIndex = 0;
            PortScanTryNext();
        }
        HashSet<string> connectedDevices = new HashSet<string>();

        void Handle_ConnectDevice_Event(object sender, EventArrivedEventArgs e)
        {
            //rtxtLog.AppendLine("USB device connected!");

            ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT * FROM Win32_USBHub");

            foreach (ManagementObject usbDevice in searcher.Get())
            {
                string deviceId = usbDevice["DeviceID"].ToString();
                deviceId = deviceId.Split('\\')[1];
                /*if (deviceId == "VID_16C0&PID_048B")
                {
                    rtxtLog.AppendLine("USB Devices:   " + usbDevice["Description"]);
                }*/
                // If the device was not already connected, print its information
                if (!connectedDevices.Contains(deviceId))
                {
                    rtxtLog.AppendLine("USB Device Connected:   " + deviceId);
                    //rtxtLog.AppendLine("Device ID: " + usbDevice["DeviceID"]);
                    //rtxtLog.AppendLine("PNP Device ID: " + usbDevice["PNPDeviceID"]);
                    //rtxtLog.AppendLine("Description: " + usbDevice["Description"]);
               
                    //rtxtLog.AppendLine();

                    // Add the device to the set of connected devices
                    connectedDevices.Add(deviceId);
                    
                }
                if (deviceId == usbId) {
                    try {
                        serial.Open();
                        rtxtLog.ClearTextInvoked();
                        rtxtLog.AppendLine("current com device was reconnected!");
                        //TrySendCmd("Hello World"); // this command is not defined, but will answer with a command not found message
                    }
                    catch(Exception ex) { }
                }
            }
        }
        void Handle_DisConnectDevice_Event(object sender, EventArrivedEventArgs e)
        {
            //rtxtLog.AppendLine("USB device disconnected!");

            HashSet<string> disconnectedDevices = new HashSet<string>(connectedDevices);
            // Refresh the list of connected devices
            connectedDevices.Clear();
            ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT * FROM Win32_USBHub");

            foreach (ManagementObject usbDevice in searcher.Get())
            {
                string deviceId = usbDevice["DeviceID"].ToString();
                deviceId = deviceId.Split('\\')[1];
                // Add the device to the set of connected devices
                connectedDevices.Add(deviceId);
                disconnectedDevices.Remove(deviceId); // remove all current devices, only the last removed devices will remain
            }
            foreach (string deviceId in disconnectedDevices)
            {
                rtxtLog.AppendLine("USB Device Disconnected:" + deviceId);
                if (deviceId == usbId) { rtxtLog.AppendLine("current com device was disconnected!"); serial.Close(); }
                //rtxtLog.AppendLine("Device ID: " + deviceId);
            }
        }
        private void StartListenForDevice()
        {
            ManagementEventWatcher watcher = new ManagementEventWatcher();
            WqlEventQuery query = new WqlEventQuery("SELECT * FROM Win32_DeviceChangeEvent WHERE EventType = 2");

            watcher.EventArrived += Handle_ConnectDevice_Event;

            watcher.Query = query;
            watcher.Start();

            watcher = new ManagementEventWatcher();
            query = new WqlEventQuery("SELECT * FROM Win32_DeviceChangeEvent WHERE EventType = 3");

            watcher.EventArrived += Handle_DisConnectDevice_Event;

            watcher.Query = query;
            watcher.Start();

            //Console.WriteLine("Listening for USB device connections. Press any key to exit.");
            //Console.ReadKey();

        }

        private void Serial_ErrorReceived(object sender, SerialErrorReceivedEventArgs e)
        {
            rtxtLog.AppendLine(e.EventType.ToString());
        }

        private void Serial_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            if (serial.IsOpen == false) return;
            try
            {
                while (serial.BytesToRead > 0)
                {
                    int nextChar = serial.ReadChar();
                    if (nextChar == '\r') continue; // skip
                    if (nextChar == '\n')
                    {
                        if (currLine.StartsWith("json:"))
                            decodeJson(currLine.Substring("json:".Length));
                        else if (currLine.StartsWith("ACK_KO"))
                        {
                            wantToDisconnect = true;
                        }
                        else if (currLine.StartsWith("ACK_OK"))
                        {
                            wantToDisconnect = true;
                        }
                        else if (currLine.StartsWith("pong"))
                        {
                            portScanIndex--; // go back one step
                            GetCurrentComportUsbDeviceId(serial.PortName);
                            rtxtLog.AppendLine("device found @ " + serial.PortName);
                            this.Invoke((System.Windows.Forms.MethodInvoker)(delegate ()
                            {
                                cmdBoxPorts.SelectedIndex = portScanIndex;
                                portScanTimer.Stop();
                                btnConnectDisconnect.Text = "Disconnect";
                                SendGetFilesCmd();
                            }));
                        }
                        else
                            rtxtLog.AppendLine(currLine);

                        currLine = "";
                    }
                    else
                        currLine += (char)nextChar;
                }
                if (wantToDisconnect) {
                    this.Invoke(new Action(() => { btnConnectDisconnect.Text = "Connect"; }));  wantToDisconnect = false; serial.Close(); }
            }
            catch (Exception ex) { rtxtLog.AppendLine(ex.ToString()); }//"gudförbannat"}
        }

        private void decodeJson(string json)
        {
            try
            {
                //dynamic data = JsonConvert.DeserializeObject(json);
                //rtxtLog.AppendLine(json);
                JObject data = JObject.Parse(json);
                if (data == null) return;

                if (data["log"] != null)
                {
                    string log = (string)data["log"];
                    rtxtLog.AppendLine(log);
                    return;
                }
                else if (data["files"] != null)
                {
                    JArray files = (JArray)data["files"];
                    if (files == null) return;

                    List<FileListItem> fileListItems = new List<FileListItem>();
                    foreach (JObject file in files)
                    {
                        string name = (string)file["name"];
                        int size = (int)file["size"];
                        fileListItems.Add(new FileListItem(name, size));
                        // rtxtLog.AppendLine(name.PadRight(40) + " " + ((size!=-1)?size.ToString():"directory").PadLeft(10));
                    }
                    this.Invoke(new Action(() => { lstFiles.Items.Clear(); lstFiles.Items.AddRange(fileListItems.ToArray()); }));
                    wantToDisconnect = true;
                }
                else if (data["instruments"] != null)
                {
                    JArray instruments = (JArray)data["instruments"];
                    if (instruments == null) return;

                    List<InstrumentListItem> instrumentListItem = new List<InstrumentListItem>();
                    int index = 0;
                    foreach (JObject inst in instruments)
                    {
                        string name = (string)inst["name"];
                        int ibagNdx = (int)inst["ndx"];
                        instrumentListItem.Add(new InstrumentListItem(name, ibagNdx, index++));
                        // rtxtLog.AppendLine(name.PadRight(40) + " " + ((size!=-1)?size.ToString():"directory").PadLeft(10));
                    }
                    this.Invoke(new Action(() => {
                        lstInstruments.Items.Clear();
                        lstInstruments.Items.AddRange(instrumentListItem.ToArray());
                        if (lstInstruments.Items.Count != 0) lstInstruments.SelectedIndex = 0;
                    }));
                    wantToDisconnect = true;
                }
                else if (data["cmd"] != null)
                {
                    string cmd = (string)data["cmd"];
                    if (cmd == "file_loaded")
                    {
                        sendListInstruments();
                    }
                    else if (cmd == "instrument_loaded")
                    {
                        rtxtLog.AppendLine("instrument loaded OK");
                        wantToDisconnect = true;
                    }
                    else if (cmd == "start_send_file_ack")
                    {
                        rtxtLog.AppendLine("start to send file data");
                        if (serial.IsOpen == false)
                            serial.Open();
                        
                        bgwFileSend.RunWorkerAsync();

                    }
                    else if (cmd == "fileRxOK")
                    {
                        rtxtLog.AppendLine("file rx OK");
                        SendGetFilesCmd();
                        //wantToDisconnect = true;
                    }
                    else if (cmd == "deleted_file")
                    {
                        rtxtLog.AppendLine("file delete OK");
                        SendGetFilesCmd();
                    }
                    else
                    {
                        rtxtLog.AppendLine("unknown json cmd:\n" + cmd);
                        wantToDisconnect = true;
                    }
                }
                else
                {
                    rtxtLog.AppendLine("rx unknown json:\n" + json);
                }

            }
            catch (Exception ex)
            {
                rtxtLog.AppendLine("Error while parsing JSON:\n\n" + ex.ToString() + "\n\n>>>"+ json + "<<<");
            }
        }

        private void btnRefreshPorts_Click(object sender, EventArgs e)
        {
            refreshPorts();
        }
        private void refreshPorts()
        {
            cmdBoxPorts.Items.Clear();
            currPorts = SerialPort.GetPortNames().Sort();
            cmdBoxPorts.Items.AddRange(currPorts);
            if (currPorts.Length == 0) return;
            StartPortScan();
        }

        private void btnConnectDisconnect_Click(object sender, EventArgs e)
        {
            if (serial.IsOpen)
            {
                serial.Close();
                btnConnectDisconnect.Text = "Connect";
                return;
            }
            try
            {
                serial.PortName = (string)cmdBoxPorts.SelectedItem;
                serial.Open();
                btnConnectDisconnect.Text = "Disconnect";
            }
            catch (Exception ex)
            {

            }
        }

        private void cmdBoxPorts_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnConnectDisconnect.Enabled = true;
        }

        private void btnGetFiles_Click(object sender, EventArgs e)
        {
            SendGetFilesCmd();
        }

        private void SendGetFilesCmd()
        {
            TrySendCmd("list_files:");
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            refreshPorts();
            StartListenForDevice();
            int newHeight = (int)((double)Screen.PrimaryScreen.Bounds.Height * 0.5f);
            int newWidth = (int)((double)Screen.PrimaryScreen.Bounds.Width * 0.7f);
            this.Height = newHeight;
            this.Width = newWidth;
            Handle_DisConnectDevice_Event(null, null);
        }

        private void btnReadFile_Click(object sender, EventArgs e)
        {
            if (lstFiles.SelectedItem == null) return;
            rtxtLog.Clear();
            FileListItem fileItem = (FileListItem)lstFiles.SelectedItem;
            //TrySendCmd("json:{'cmd':'read_file','path':'" + fileItem.Name + "'}");
            TrySendCmd($"read_file:{fileItem.Name}");
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (serial.IsOpen) serial.Close();
        }

        private void btnListInstruments_Click(object sender, EventArgs e)
        {
            sendListInstruments();
        }

        void sendListInstruments()
        {
            // rtxtLog.Clear();
            //TrySendCmd("json:{'cmd':'list_instruments'}");
            TrySendCmd("list_instruments");
        }

        private void btnLoadInstrument_Click(object sender, EventArgs e)
        {
            rtxtLog.Clear();
            InstrumentListItem instItem = (InstrumentListItem)lstInstruments.SelectedItem;
            //TrySendCmd($"json:{{'cmd':'load_instrument', 'index':{instItem.Index}}}\n");
            TrySendCmd($"load_instrument:{instItem.Index}");
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void btnExtMemTestExec_Click(object sender, EventArgs e)
        {
            TrySendCmd("exec_ext_mem_test");
        }

        private void TrySendCmd(string cmd)
        {
            if (serial.IsOpen == false)
                serial.Open();
            if (serial.IsOpen)
            {
                this.Invoke(new Action(() =>
                {
                    btnConnectDisconnect.Text = "Disconnect";
                }));
                serial.Write(cmd + "\n");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            TrySendCmd("print_all_errors");
        }

        private void btnPrintInfoChunk_Click(object sender, EventArgs e)
        {
            TrySendCmd("print_info");
        }

        private void btnLoadInstrumentDemo_Click(object sender, EventArgs e)
        {
            if (lstFiles.SelectedItem == null) { rtxtLog.AppendLine("error file not selected"); return; }
            if (lstInstruments.SelectedItem == null) { rtxtLog.AppendLine("error instrument not selected"); return; }
            rtxtLog.Clear();
            FileListItem fileItem = (FileListItem)lstFiles.SelectedItem;
            //TrySendCmd("json:{'cmd':'read_file','path':'" + fileItem.Name + "'}");
            TrySendCmd($"load_instrument_from_file:{lstInstruments.SelectedIndex.ToString().PadLeft(5,'0')}:{fileItem.Name}");
        }

        private void btnSendFileTest_Click(object sender, EventArgs e)
        {
            if (lstFiles.SelectedItem == null) { rtxtLog.AppendLine("error file not selected"); return; }

            FileListItem fileItem = (FileListItem)lstFiles.SelectedItem;
            rtxtLog.Clear();
            rtxtLog.AppendLine($"sending file to teensy:{fileItem.Name}, size(hex):{fileItem.Size.ToString("X2").PadLeft(8, '0')}");
            TrySendCmd($"transfer_file:{fileItem.Size.ToString("X2").PadLeft(8,'0')}:{fileItem.Name}");
        }

        private void btnSendFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() != DialogResult.OK) return;
            fileToSend = ofd.FileName;
            System.IO.FileInfo fi = new System.IO.FileInfo(fileToSend);
            //rtxtLog.AppendLine($"transfer_file:{fi.Length.ToString("X2").PadLeft(8, '0')}:{System.IO.Path.GetFileName(fileToSend)}");
            TrySendCmd($"transfer_file:{fi.Length.ToString("X2").PadLeft(8, '0')}:{System.IO.Path.GetFileName(fileToSend)}");
        }

        private void btnDeleteFile_Click(object sender, EventArgs e)
        {
            if (lstFiles.SelectedItem == null) { rtxtLog.AppendLine("error file not selected"); return; }

            FileListItem fileItem = (FileListItem)lstFiles.SelectedItem;
            rtxtLog.Clear();
            TrySendCmd($"delete_file:{fileItem.Name}");
        }
    }
    public class FileListItem
    {
        string name;
        int size;

        public string Name
        {
            get { return name; }
        }
        public int Size
        {
            get { return size; }
        }
        public FileListItem(string name, int size)
        {
            this.name = name;
            this.size = size;
        }

        public override string ToString()
        {
            return name.PadRight(40) + " " + ((size != -1) ? size.ToString() : "directory").PadLeft(10);
        }

    }

    public class InstrumentListItem
    {
        string name;
        int ibagNdx;
        int index;

        public int Index
        {
            get { return index; }
        }
        public InstrumentListItem(string name, int ibagNdx, int index)
        {
            this.name = name;
            this.ibagNdx = ibagNdx;
            this.index = index;
        }

        public override string ToString()
        {
            return name.PadRight(20) + " : " + ibagNdx.ToString();
        }

    }
    
}

