
namespace TeensySoundfontReader_Interface
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.rtxtLog = new System.Windows.Forms.RichTextBox();
            this.btnConnectDisconnect = new System.Windows.Forms.Button();
            this.cmdBoxPorts = new System.Windows.Forms.ComboBox();
            this.btnRefreshPorts = new System.Windows.Forms.Button();
            this.grpBoxSerialCommands = new System.Windows.Forms.GroupBox();
            this.btnExtMemTestExec = new System.Windows.Forms.Button();
            this.btnLoadInstrument = new System.Windows.Forms.Button();
            this.btnReadFile = new System.Windows.Forms.Button();
            this.btnGetFiles = new System.Windows.Forms.Button();
            this.lstFiles = new System.Windows.Forms.ListBox();
            this.lstInstruments = new System.Windows.Forms.ListBox();
            this.button1 = new System.Windows.Forms.Button();
            this.grpBoxSerialCommands.SuspendLayout();
            this.SuspendLayout();
            // 
            // rtxtLog
            // 
            this.rtxtLog.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rtxtLog.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtxtLog.Location = new System.Drawing.Point(9, 39);
            this.rtxtLog.Name = "rtxtLog";
            this.rtxtLog.Size = new System.Drawing.Size(102, 404);
            this.rtxtLog.TabIndex = 0;
            this.rtxtLog.Text = "";
            // 
            // btnConnectDisconnect
            // 
            this.btnConnectDisconnect.Enabled = false;
            this.btnConnectDisconnect.Location = new System.Drawing.Point(236, 10);
            this.btnConnectDisconnect.Name = "btnConnectDisconnect";
            this.btnConnectDisconnect.Size = new System.Drawing.Size(75, 23);
            this.btnConnectDisconnect.TabIndex = 1;
            this.btnConnectDisconnect.Text = "Connect";
            this.btnConnectDisconnect.UseVisualStyleBackColor = true;
            this.btnConnectDisconnect.Click += new System.EventHandler(this.btnConnectDisconnect_Click);
            // 
            // cmdBoxPorts
            // 
            this.cmdBoxPorts.FormattingEnabled = true;
            this.cmdBoxPorts.Location = new System.Drawing.Point(12, 12);
            this.cmdBoxPorts.Name = "cmdBoxPorts";
            this.cmdBoxPorts.Size = new System.Drawing.Size(106, 21);
            this.cmdBoxPorts.TabIndex = 2;
            this.cmdBoxPorts.SelectedIndexChanged += new System.EventHandler(this.cmdBoxPorts_SelectedIndexChanged);
            // 
            // btnRefreshPorts
            // 
            this.btnRefreshPorts.Location = new System.Drawing.Point(124, 10);
            this.btnRefreshPorts.Name = "btnRefreshPorts";
            this.btnRefreshPorts.Size = new System.Drawing.Size(97, 23);
            this.btnRefreshPorts.TabIndex = 3;
            this.btnRefreshPorts.Text = "Refresh Ports";
            this.btnRefreshPorts.UseVisualStyleBackColor = true;
            this.btnRefreshPorts.Click += new System.EventHandler(this.btnRefreshPorts_Click);
            // 
            // grpBoxSerialCommands
            // 
            this.grpBoxSerialCommands.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.grpBoxSerialCommands.Controls.Add(this.button1);
            this.grpBoxSerialCommands.Controls.Add(this.btnExtMemTestExec);
            this.grpBoxSerialCommands.Controls.Add(this.btnLoadInstrument);
            this.grpBoxSerialCommands.Controls.Add(this.btnReadFile);
            this.grpBoxSerialCommands.Controls.Add(this.btnGetFiles);
            this.grpBoxSerialCommands.Enabled = false;
            this.grpBoxSerialCommands.Location = new System.Drawing.Point(709, 35);
            this.grpBoxSerialCommands.Name = "grpBoxSerialCommands";
            this.grpBoxSerialCommands.Size = new System.Drawing.Size(82, 262);
            this.grpBoxSerialCommands.TabIndex = 4;
            this.grpBoxSerialCommands.TabStop = false;
            this.grpBoxSerialCommands.Text = "groupBox1";
            // 
            // btnExtMemTestExec
            // 
            this.btnExtMemTestExec.Location = new System.Drawing.Point(2, 219);
            this.btnExtMemTestExec.Name = "btnExtMemTestExec";
            this.btnExtMemTestExec.Size = new System.Drawing.Size(75, 37);
            this.btnExtMemTestExec.TabIndex = 4;
            this.btnExtMemTestExec.Text = "ExtMemTestExec";
            this.btnExtMemTestExec.UseVisualStyleBackColor = true;
            this.btnExtMemTestExec.Click += new System.EventHandler(this.btnExtMemTestExec_Click);
            // 
            // btnLoadInstrument
            // 
            this.btnLoadInstrument.Location = new System.Drawing.Point(5, 75);
            this.btnLoadInstrument.Margin = new System.Windows.Forms.Padding(2);
            this.btnLoadInstrument.Name = "btnLoadInstrument";
            this.btnLoadInstrument.Size = new System.Drawing.Size(70, 36);
            this.btnLoadInstrument.TabIndex = 3;
            this.btnLoadInstrument.Text = "Load Instrument";
            this.btnLoadInstrument.UseVisualStyleBackColor = true;
            this.btnLoadInstrument.Click += new System.EventHandler(this.btnLoadInstrument_Click);
            // 
            // btnReadFile
            // 
            this.btnReadFile.Location = new System.Drawing.Point(5, 47);
            this.btnReadFile.Margin = new System.Windows.Forms.Padding(2);
            this.btnReadFile.Name = "btnReadFile";
            this.btnReadFile.Size = new System.Drawing.Size(70, 24);
            this.btnReadFile.TabIndex = 1;
            this.btnReadFile.Text = "read file";
            this.btnReadFile.UseVisualStyleBackColor = true;
            this.btnReadFile.Click += new System.EventHandler(this.btnReadFile_Click);
            // 
            // btnGetFiles
            // 
            this.btnGetFiles.Location = new System.Drawing.Point(5, 19);
            this.btnGetFiles.Name = "btnGetFiles";
            this.btnGetFiles.Size = new System.Drawing.Size(70, 23);
            this.btnGetFiles.TabIndex = 0;
            this.btnGetFiles.Text = "Get Files";
            this.btnGetFiles.UseVisualStyleBackColor = true;
            this.btnGetFiles.Click += new System.EventHandler(this.btnGetFiles_Click);
            // 
            // lstFiles
            // 
            this.lstFiles.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstFiles.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstFiles.FormattingEnabled = true;
            this.lstFiles.ItemHeight = 14;
            this.lstFiles.Location = new System.Drawing.Point(331, 39);
            this.lstFiles.Name = "lstFiles";
            this.lstFiles.Size = new System.Drawing.Size(374, 396);
            this.lstFiles.TabIndex = 5;
            // 
            // lstInstruments
            // 
            this.lstInstruments.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstInstruments.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstInstruments.FormattingEnabled = true;
            this.lstInstruments.ItemHeight = 14;
            this.lstInstruments.Location = new System.Drawing.Point(114, 39);
            this.lstInstruments.Margin = new System.Windows.Forms.Padding(2);
            this.lstInstruments.Name = "lstInstruments";
            this.lstInstruments.Size = new System.Drawing.Size(214, 396);
            this.lstInstruments.TabIndex = 6;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(2, 178);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 35);
            this.button1.TabIndex = 7;
            this.button1.Text = "print all errors";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lstInstruments);
            this.Controls.Add(this.rtxtLog);
            this.Controls.Add(this.lstFiles);
            this.Controls.Add(this.grpBoxSerialCommands);
            this.Controls.Add(this.btnRefreshPorts);
            this.Controls.Add(this.cmdBoxPorts);
            this.Controls.Add(this.btnConnectDisconnect);
            this.Name = "MainForm";
            this.Text = "Teensy Soundfont 2 reader - Test GUI";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.Shown += new System.EventHandler(this.Form1_Shown);
            this.grpBoxSerialCommands.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox rtxtLog;
        private System.Windows.Forms.Button btnConnectDisconnect;
        private System.Windows.Forms.ComboBox cmdBoxPorts;
        private System.Windows.Forms.Button btnRefreshPorts;
        private System.Windows.Forms.GroupBox grpBoxSerialCommands;
        private System.Windows.Forms.Button btnGetFiles;
        private System.Windows.Forms.ListBox lstFiles;
        private System.Windows.Forms.Button btnReadFile;
        private System.Windows.Forms.ListBox lstInstruments;
        private System.Windows.Forms.Button btnLoadInstrument;
        private System.Windows.Forms.Button btnExtMemTestExec;
        private System.Windows.Forms.Button button1;
    }
}

