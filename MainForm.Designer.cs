﻿
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
            this.btnListPresets = new System.Windows.Forms.Button();
            this.btnLoadInstrumentDemo = new System.Windows.Forms.Button();
            this.btnPrintInfoChunk = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.btnExtMemTestExec = new System.Windows.Forms.Button();
            this.btnLoadInstrument = new System.Windows.Forms.Button();
            this.btnReadFile = new System.Windows.Forms.Button();
            this.btnGetFiles = new System.Windows.Forms.Button();
            this.btnSendFileTest = new System.Windows.Forms.Button();
            this.lstFiles = new System.Windows.Forms.ListBox();
            this.lstInstruments = new System.Windows.Forms.ListBox();
            this.btnSendFile = new System.Windows.Forms.Button();
            this.btnDeleteFile = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
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
            this.rtxtLog.Size = new System.Drawing.Size(212, 382);
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
            this.grpBoxSerialCommands.Controls.Add(this.btnListPresets);
            this.grpBoxSerialCommands.Controls.Add(this.btnLoadInstrumentDemo);
            this.grpBoxSerialCommands.Controls.Add(this.btnPrintInfoChunk);
            this.grpBoxSerialCommands.Controls.Add(this.button1);
            this.grpBoxSerialCommands.Controls.Add(this.btnExtMemTestExec);
            this.grpBoxSerialCommands.Controls.Add(this.btnLoadInstrument);
            this.grpBoxSerialCommands.Controls.Add(this.btnReadFile);
            this.grpBoxSerialCommands.Controls.Add(this.btnGetFiles);
            this.grpBoxSerialCommands.Location = new System.Drawing.Point(937, 35);
            this.grpBoxSerialCommands.Name = "grpBoxSerialCommands";
            this.grpBoxSerialCommands.Size = new System.Drawing.Size(82, 355);
            this.grpBoxSerialCommands.TabIndex = 4;
            this.grpBoxSerialCommands.TabStop = false;
            this.grpBoxSerialCommands.Text = "groupBox1";
            // 
            // btnListPresets
            // 
            this.btnListPresets.Location = new System.Drawing.Point(7, 291);
            this.btnListPresets.Name = "btnListPresets";
            this.btnListPresets.Size = new System.Drawing.Size(75, 23);
            this.btnListPresets.TabIndex = 10;
            this.btnListPresets.Text = "print presets";
            this.btnListPresets.UseVisualStyleBackColor = true;
            this.btnListPresets.Click += new System.EventHandler(this.btnListPresets_Click);
            // 
            // btnLoadInstrumentDemo
            // 
            this.btnLoadInstrumentDemo.Location = new System.Drawing.Point(5, 233);
            this.btnLoadInstrumentDemo.Name = "btnLoadInstrumentDemo";
            this.btnLoadInstrumentDemo.Size = new System.Drawing.Size(75, 52);
            this.btnLoadInstrumentDemo.TabIndex = 9;
            this.btnLoadInstrumentDemo.Text = "read file and load first instrument";
            this.btnLoadInstrumentDemo.UseVisualStyleBackColor = true;
            this.btnLoadInstrumentDemo.Click += new System.EventHandler(this.btnLoadInstrumentDemo_Click);
            // 
            // btnPrintInfoChunk
            // 
            this.btnPrintInfoChunk.Location = new System.Drawing.Point(5, 116);
            this.btnPrintInfoChunk.Name = "btnPrintInfoChunk";
            this.btnPrintInfoChunk.Size = new System.Drawing.Size(70, 27);
            this.btnPrintInfoChunk.TabIndex = 8;
            this.btnPrintInfoChunk.Text = "Print INFO";
            this.btnPrintInfoChunk.UseVisualStyleBackColor = true;
            this.btnPrintInfoChunk.Click += new System.EventHandler(this.btnPrintInfoChunk_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(0, 149);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 35);
            this.button1.TabIndex = 7;
            this.button1.Text = "print all errors";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnExtMemTestExec
            // 
            this.btnExtMemTestExec.Location = new System.Drawing.Point(1, 190);
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
            // btnSendFileTest
            // 
            this.btnSendFileTest.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSendFileTest.Enabled = false;
            this.btnSendFileTest.Location = new System.Drawing.Point(941, 6);
            this.btnSendFileTest.Name = "btnSendFileTest";
            this.btnSendFileTest.Size = new System.Drawing.Size(75, 23);
            this.btnSendFileTest.TabIndex = 7;
            this.btnSendFileTest.Text = "send file test";
            this.btnSendFileTest.UseVisualStyleBackColor = true;
            this.btnSendFileTest.Click += new System.EventHandler(this.btnSendFileTest_Click);
            // 
            // lstFiles
            // 
            this.lstFiles.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstFiles.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstFiles.FormattingEnabled = true;
            this.lstFiles.ItemHeight = 14;
            this.lstFiles.Location = new System.Drawing.Point(559, 39);
            this.lstFiles.Name = "lstFiles";
            this.lstFiles.Size = new System.Drawing.Size(374, 382);
            this.lstFiles.TabIndex = 5;
            // 
            // lstInstruments
            // 
            this.lstInstruments.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstInstruments.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstInstruments.FormattingEnabled = true;
            this.lstInstruments.ItemHeight = 14;
            this.lstInstruments.Location = new System.Drawing.Point(226, 39);
            this.lstInstruments.Margin = new System.Windows.Forms.Padding(2);
            this.lstInstruments.Name = "lstInstruments";
            this.lstInstruments.Size = new System.Drawing.Size(330, 382);
            this.lstInstruments.TabIndex = 6;
            // 
            // btnSendFile
            // 
            this.btnSendFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSendFile.Location = new System.Drawing.Point(633, 11);
            this.btnSendFile.Name = "btnSendFile";
            this.btnSendFile.Size = new System.Drawing.Size(75, 23);
            this.btnSendFile.TabIndex = 7;
            this.btnSendFile.Text = "send file";
            this.btnSendFile.UseVisualStyleBackColor = true;
            this.btnSendFile.Click += new System.EventHandler(this.btnSendFile_Click);
            // 
            // btnDeleteFile
            // 
            this.btnDeleteFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDeleteFile.Location = new System.Drawing.Point(815, 11);
            this.btnDeleteFile.Name = "btnDeleteFile";
            this.btnDeleteFile.Size = new System.Drawing.Size(75, 23);
            this.btnDeleteFile.TabIndex = 8;
            this.btnDeleteFile.Text = "delete file";
            this.btnDeleteFile.UseVisualStyleBackColor = true;
            this.btnDeleteFile.Click += new System.EventHandler(this.btnDeleteFile_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBar1.Location = new System.Drawing.Point(9, 426);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(1010, 23);
            this.progressBar1.TabIndex = 9;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1028, 450);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.btnDeleteFile);
            this.Controls.Add(this.btnSendFileTest);
            this.Controls.Add(this.btnSendFile);
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
        private System.Windows.Forms.Button btnPrintInfoChunk;
        private System.Windows.Forms.Button btnLoadInstrumentDemo;
        private System.Windows.Forms.Button btnSendFileTest;
        private System.Windows.Forms.Button btnSendFile;
        private System.Windows.Forms.Button btnDeleteFile;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Button btnListPresets;
    }
}

