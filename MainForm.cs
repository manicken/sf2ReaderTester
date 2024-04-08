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

namespace TeensySoundfontReader_Interface
{
    public partial class MainForm : Form
    {
        Timer portScanTimer;
        int portScanIndex;

        SerialPort serial;
        string currLine = "";
        Queue<string> rxBuffer;

        string[] currPorts;

        public MainForm()
        {
            InitializeComponent();

            serial = new SerialPort();
            serial.DataReceived += Serial_DataReceived;
            serial.ErrorReceived += Serial_ErrorReceived;

            rxBuffer = new Queue<string>();
            portScanTimer = new Timer();
            portScanTimer.Interval = 500;
            portScanTimer.Tick += PortScanTimer_Tick;
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


        private void StartListenForDevice()
        {
            ManagementEventWatcher watcher = new ManagementEventWatcher();
            WqlEventQuery query = new WqlEventQuery("SELECT * FROM Win32_DeviceChangeEvent WHERE EventType = 2");
            
            watcher.EventArrived += (sender, e) => {
                rtxtLog.AppendLine("USB device connected");
                
            };

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
            while (serial.BytesToRead > 0)
            {
                int nextChar = serial.ReadChar();
                if (nextChar == '\n')
                {
                    if (currLine.StartsWith("json:"))
                        decodeJson(currLine.Substring("json:".Length));
                    else if (currLine.StartsWith("pong"))
                    {
                        portScanIndex--; // go back one step
                        rtxtLog.AppendLine("device found @ " + currPorts[portScanIndex]);
                        this.Invoke((System.Windows.Forms.MethodInvoker)(delegate ()
                        {
                            cmdBoxPorts.SelectedIndex = portScanIndex;
                            portScanTimer.Stop();
                            btnConnectDisconnect.Text = "Disconnect";
                            grpBoxSerialCommands.Enabled = true;
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
                    this.Invoke(new Action(() => { lstInstruments.Items.Clear(); lstInstruments.Items.AddRange(instrumentListItem.ToArray()); }));
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
                    }
                    else
                        rtxtLog.AppendLine("unknown json cmd:\n" + cmd);
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
                grpBoxSerialCommands.Enabled = false;
                return;
            }
            try
            {
                serial.PortName = (string)cmdBoxPorts.SelectedItem;
                serial.Open();
                btnConnectDisconnect.Text = "Disconnect";
                grpBoxSerialCommands.Enabled = true;
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
            //StartListenForDevice();
            int newHeight = (int)((double)Screen.PrimaryScreen.Bounds.Height * 0.5f);
            int newWidth = (int)((double)Screen.PrimaryScreen.Bounds.Width * 0.7f);
            this.Height = newHeight;
            this.Width = newWidth;
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
                serial.Write(cmd + "\n");
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
