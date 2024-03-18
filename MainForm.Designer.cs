
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
            this.btnGetFiles = new System.Windows.Forms.Button();
            this.lstFiles = new System.Windows.Forms.ListBox();
            this.grpBoxSerialCommands.SuspendLayout();
            this.SuspendLayout();
            // 
            // rtxtLog
            // 
            this.rtxtLog.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtxtLog.Location = new System.Drawing.Point(12, 56);
            this.rtxtLog.Name = "rtxtLog";
            this.rtxtLog.Size = new System.Drawing.Size(209, 382);
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
            this.grpBoxSerialCommands.Controls.Add(this.btnGetFiles);
            this.grpBoxSerialCommands.Enabled = false;
            this.grpBoxSerialCommands.Location = new System.Drawing.Point(685, 56);
            this.grpBoxSerialCommands.Name = "grpBoxSerialCommands";
            this.grpBoxSerialCommands.Size = new System.Drawing.Size(85, 262);
            this.grpBoxSerialCommands.TabIndex = 4;
            this.grpBoxSerialCommands.TabStop = false;
            this.grpBoxSerialCommands.Text = "groupBox1";
            // 
            // btnGetFiles
            // 
            this.btnGetFiles.Location = new System.Drawing.Point(15, 28);
            this.btnGetFiles.Name = "btnGetFiles";
            this.btnGetFiles.Size = new System.Drawing.Size(61, 23);
            this.btnGetFiles.TabIndex = 0;
            this.btnGetFiles.Text = "Get Files";
            this.btnGetFiles.UseVisualStyleBackColor = true;
            this.btnGetFiles.Click += new System.EventHandler(this.btnGetFiles_Click);
            // 
            // lstFiles
            // 
            this.lstFiles.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstFiles.FormattingEnabled = true;
            this.lstFiles.ItemHeight = 14;
            this.lstFiles.Location = new System.Drawing.Point(227, 58);
            this.lstFiles.Name = "lstFiles";
            this.lstFiles.Size = new System.Drawing.Size(452, 368);
            this.lstFiles.TabIndex = 5;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lstFiles);
            this.Controls.Add(this.grpBoxSerialCommands);
            this.Controls.Add(this.btnRefreshPorts);
            this.Controls.Add(this.cmdBoxPorts);
            this.Controls.Add(this.btnConnectDisconnect);
            this.Controls.Add(this.rtxtLog);
            this.Name = "MainForm";
            this.Text = "Form1";
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
    }
}

