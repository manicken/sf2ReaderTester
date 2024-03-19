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

namespace TeensySoundfontReader_Interface
{
    public partial class MainForm : Form
    {
        SerialPort serial;
        string currLine = "";
        Queue<string> rxBuffer;

        public MainForm()
        {
            InitializeComponent();

            serial = new SerialPort();
            serial.DataReceived += Serial_DataReceived;
            serial.ErrorReceived += Serial_ErrorReceived;

            rxBuffer = new Queue<string>();
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
                    decodeJson(currLine);
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
                JObject data = JObject.Parse(json);
                if (data == null) return;
                if (data["log"] != null)
                {
                    string log = (string)data["log"];
                    rtxtLog.AppendLine(log);
                    return;
                }
                JArray files = (JArray)data["files"];
                if (files == null) return;

                List<FileListItem> fileListItems = new List<FileListItem>();
                foreach(JObject file in files)
                {
                    string name = (string)file["name"];
                    int size = (int)file["size"];
                    fileListItems.Add(new FileListItem(name, size));
                   // rtxtLog.AppendLine(name.PadRight(40) + " " + ((size!=-1)?size.ToString():"directory").PadLeft(10));
                }
                this.Invoke(new Action(() => { lstFiles.Items.Clear(); lstFiles.Items.AddRange(fileListItems.ToArray()); }));

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
            cmdBoxPorts.Items.AddRange(SerialPort.GetPortNames());
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
            string json = "{'cmd':'list_files'}\n";
            if (serial.IsOpen == false)
                serial.Open();
            serial.Write(json);
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            refreshPorts();
        }

        private void btnReadFile_Click(object sender, EventArgs e)
        {
            if (serial.IsOpen == false)
                serial.Open();
            FileListItem fileItem = (FileListItem)lstFiles.SelectedItem;
            serial.Write("{'cmd':'read_file','path':'" + fileItem.Name + "'}\n");
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
}
