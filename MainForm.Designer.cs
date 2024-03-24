
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
            this.btnListInstruments = new System.Windows.Forms.Button();
            this.btnReadFile = new System.Windows.Forms.Button();
            this.btnGetFiles = new System.Windows.Forms.Button();
            this.lstFiles = new System.Windows.Forms.ListBox();
            this.lstInstruments = new System.Windows.Forms.ListBox();
            this.btnLoadInstrument = new System.Windows.Forms.Button();
            this.grpBoxSerialCommands.SuspendLayout();
            this.SuspendLayout();
            // 
            // rtxtLog
            // 
            this.rtxtLog.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rtxtLog.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtxtLog.Location = new System.Drawing.Point(13, 60);
            this.rtxtLog.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.rtxtLog.Name = "rtxtLog";
            this.rtxtLog.Size = new System.Drawing.Size(151, 620);
            this.rtxtLog.TabIndex = 0;
            this.rtxtLog.Text = "";
            // 
            // btnConnectDisconnect
            // 
            this.btnConnectDisconnect.Enabled = false;
            this.btnConnectDisconnect.Location = new System.Drawing.Point(354, 15);
            this.btnConnectDisconnect.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnConnectDisconnect.Name = "btnConnectDisconnect";
            this.btnConnectDisconnect.Size = new System.Drawing.Size(112, 35);
            this.btnConnectDisconnect.TabIndex = 1;
            this.btnConnectDisconnect.Text = "Connect";
            this.btnConnectDisconnect.UseVisualStyleBackColor = true;
            this.btnConnectDisconnect.Click += new System.EventHandler(this.btnConnectDisconnect_Click);
            // 
            // cmdBoxPorts
            // 
            this.cmdBoxPorts.FormattingEnabled = true;
            this.cmdBoxPorts.Location = new System.Drawing.Point(18, 18);
            this.cmdBoxPorts.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cmdBoxPorts.Name = "cmdBoxPorts";
            this.cmdBoxPorts.Size = new System.Drawing.Size(157, 28);
            this.cmdBoxPorts.TabIndex = 2;
            this.cmdBoxPorts.SelectedIndexChanged += new System.EventHandler(this.cmdBoxPorts_SelectedIndexChanged);
            // 
            // btnRefreshPorts
            // 
            this.btnRefreshPorts.Location = new System.Drawing.Point(186, 15);
            this.btnRefreshPorts.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnRefreshPorts.Name = "btnRefreshPorts";
            this.btnRefreshPorts.Size = new System.Drawing.Size(146, 35);
            this.btnRefreshPorts.TabIndex = 3;
            this.btnRefreshPorts.Text = "Refresh Ports";
            this.btnRefreshPorts.UseVisualStyleBackColor = true;
            this.btnRefreshPorts.Click += new System.EventHandler(this.btnRefreshPorts_Click);
            // 
            // grpBoxSerialCommands
            // 
            this.grpBoxSerialCommands.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.grpBoxSerialCommands.Controls.Add(this.btnLoadInstrument);
            this.grpBoxSerialCommands.Controls.Add(this.btnListInstruments);
            this.grpBoxSerialCommands.Controls.Add(this.btnReadFile);
            this.grpBoxSerialCommands.Controls.Add(this.btnGetFiles);
            this.grpBoxSerialCommands.Enabled = false;
            this.grpBoxSerialCommands.Location = new System.Drawing.Point(1064, 54);
            this.grpBoxSerialCommands.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.grpBoxSerialCommands.Name = "grpBoxSerialCommands";
            this.grpBoxSerialCommands.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.grpBoxSerialCommands.Size = new System.Drawing.Size(123, 403);
            this.grpBoxSerialCommands.TabIndex = 4;
            this.grpBoxSerialCommands.TabStop = false;
            this.grpBoxSerialCommands.Text = "groupBox1";
            // 
            // btnListInstruments
            // 
            this.btnListInstruments.Location = new System.Drawing.Point(8, 125);
            this.btnListInstruments.Name = "btnListInstruments";
            this.btnListInstruments.Size = new System.Drawing.Size(105, 53);
            this.btnListInstruments.TabIndex = 2;
            this.btnListInstruments.Text = "list instruments";
            this.btnListInstruments.UseVisualStyleBackColor = true;
            this.btnListInstruments.Click += new System.EventHandler(this.btnListInstruments_Click);
            // 
            // btnReadFile
            // 
            this.btnReadFile.Location = new System.Drawing.Point(8, 72);
            this.btnReadFile.Name = "btnReadFile";
            this.btnReadFile.Size = new System.Drawing.Size(105, 37);
            this.btnReadFile.TabIndex = 1;
            this.btnReadFile.Text = "read file";
            this.btnReadFile.UseVisualStyleBackColor = true;
            this.btnReadFile.Click += new System.EventHandler(this.btnReadFile_Click);
            // 
            // btnGetFiles
            // 
            this.btnGetFiles.Location = new System.Drawing.Point(8, 29);
            this.btnGetFiles.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnGetFiles.Name = "btnGetFiles";
            this.btnGetFiles.Size = new System.Drawing.Size(105, 35);
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
            this.lstFiles.Location = new System.Drawing.Point(497, 60);
            this.lstFiles.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.lstFiles.Name = "lstFiles";
            this.lstFiles.Size = new System.Drawing.Size(559, 620);
            this.lstFiles.TabIndex = 5;
            // 
            // lstInstruments
            // 
            this.lstInstruments.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstInstruments.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstInstruments.FormattingEnabled = true;
            this.lstInstruments.ItemHeight = 14;
            this.lstInstruments.Location = new System.Drawing.Point(171, 60);
            this.lstInstruments.Name = "lstInstruments";
            this.lstInstruments.Size = new System.Drawing.Size(319, 620);
            this.lstInstruments.TabIndex = 6;
            // 
            // btnLoadInstrument
            // 
            this.btnLoadInstrument.Location = new System.Drawing.Point(8, 184);
            this.btnLoadInstrument.Name = "btnLoadInstrument";
            this.btnLoadInstrument.Size = new System.Drawing.Size(105, 56);
            this.btnLoadInstrument.TabIndex = 3;
            this.btnLoadInstrument.Text = "Load Instrument";
            this.btnLoadInstrument.UseVisualStyleBackColor = true;
            this.btnLoadInstrument.Click += new System.EventHandler(this.btnLoadInstrument_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1200, 692);
            this.Controls.Add(this.lstInstruments);
            this.Controls.Add(this.rtxtLog);
            this.Controls.Add(this.lstFiles);
            this.Controls.Add(this.grpBoxSerialCommands);
            this.Controls.Add(this.btnRefreshPorts);
            this.Controls.Add(this.cmdBoxPorts);
            this.Controls.Add(this.btnConnectDisconnect);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "MainForm";
            this.Text = "Teensy Soundfont 2 reader - Test GUI";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
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
        private System.Windows.Forms.Button btnListInstruments;
        private System.Windows.Forms.ListBox lstInstruments;
        private System.Windows.Forms.Button btnLoadInstrument;
    }
}

