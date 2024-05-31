namespace Serial
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
            this.components = new System.ComponentModel.Container();
            this.cboxComport = new System.Windows.Forms.ComboBox();
            this.btnConnect = new System.Windows.Forms.Button();
            this.cboxBaudrate = new System.Windows.Forms.ComboBox();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnSend = new System.Windows.Forms.Button();
            this.tboxData = new System.Windows.Forms.TextBox();
            this.tboxReceive = new System.Windows.Forms.TextBox();
            this.browse = new System.Windows.Forms.Button();
            this.textBoxFilePath = new System.Windows.Forms.TextBox();
            this.btnNumberOfLines = new System.Windows.Forms.Button();
            this.btnSendGcode = new System.Windows.Forms.Button();
            this.timerSendGcode = new System.Windows.Forms.Timer(this.components);
            this.btnStopSending = new System.Windows.Forms.Button();
            this.btnSendAllAtOnce = new System.Windows.Forms.Button();
            this.btnAbout = new System.Windows.Forms.Button();
            this.numericUpDownLines = new System.Windows.Forms.NumericUpDown();
            this.btnAutoSend = new System.Windows.Forms.Button();
            this.btnAutoStop = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownLines)).BeginInit();
            this.SuspendLayout();
            // 
            // cboxComport
            // 
            this.cboxComport.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.cboxComport.FormattingEnabled = true;
            this.cboxComport.Location = new System.Drawing.Point(12, 12);
            this.cboxComport.Name = "cboxComport";
            this.cboxComport.Size = new System.Drawing.Size(121, 21);
            this.cboxComport.TabIndex = 0;
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(295, 12);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(104, 23);
            this.btnConnect.TabIndex = 1;
            this.btnConnect.Text = "Connect";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.BtnConnect_Click);
            // 
            // cboxBaudrate
            // 
            this.cboxBaudrate.FormattingEnabled = true;
            this.cboxBaudrate.Location = new System.Drawing.Point(12, 39);
            this.cboxBaudrate.Name = "cboxBaudrate";
            this.cboxBaudrate.Size = new System.Drawing.Size(121, 21);
            this.cboxBaudrate.TabIndex = 2;
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(163, 12);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(104, 23);
            this.btnRefresh.TabIndex = 3;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.BtnRefresh_Click);
            // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(361, 197);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(75, 23);
            this.btnSend.TabIndex = 4;
            this.btnSend.Text = "SendLine";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.BtnSend_Click);
            // 
            // tboxData
            // 
            this.tboxData.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tboxData.Location = new System.Drawing.Point(12, 95);
            this.tboxData.Multiline = true;
            this.tboxData.Name = "tboxData";
            this.tboxData.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tboxData.Size = new System.Drawing.Size(329, 259);
            this.tboxData.TabIndex = 5;
            // 
            // tboxReceive
            // 
            this.tboxReceive.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tboxReceive.Location = new System.Drawing.Point(463, 93);
            this.tboxReceive.Multiline = true;
            this.tboxReceive.Name = "tboxReceive";
            this.tboxReceive.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tboxReceive.Size = new System.Drawing.Size(310, 259);
            this.tboxReceive.TabIndex = 6;
            // 
            // browse
            // 
            this.browse.Location = new System.Drawing.Point(163, 63);
            this.browse.Name = "browse";
            this.browse.Size = new System.Drawing.Size(104, 23);
            this.browse.TabIndex = 7;
            this.browse.Text = "Browse";
            this.browse.UseVisualStyleBackColor = true;
            this.browse.Click += new System.EventHandler(this.Browse_Click);
            // 
            // textBoxFilePath
            // 
            this.textBoxFilePath.Location = new System.Drawing.Point(12, 66);
            this.textBoxFilePath.Name = "textBoxFilePath";
            this.textBoxFilePath.Size = new System.Drawing.Size(121, 20);
            this.textBoxFilePath.TabIndex = 8;
            // 
            // btnNumberOfLines
            // 
            this.btnNumberOfLines.Location = new System.Drawing.Point(295, 63);
            this.btnNumberOfLines.Name = "btnNumberOfLines";
            this.btnNumberOfLines.Size = new System.Drawing.Size(104, 23);
            this.btnNumberOfLines.TabIndex = 10;
            this.btnNumberOfLines.Text = "NumberOfLines";
            this.btnNumberOfLines.UseVisualStyleBackColor = true;
            this.btnNumberOfLines.Click += new System.EventHandler(this.BtnNumberOfLines_Click);
            // 
            // btnSendGcode
            // 
            this.btnSendGcode.Location = new System.Drawing.Point(361, 132);
            this.btnSendGcode.Name = "btnSendGcode";
            this.btnSendGcode.Size = new System.Drawing.Size(75, 23);
            this.btnSendGcode.TabIndex = 11;
            this.btnSendGcode.Text = "SendAuto";
            this.btnSendGcode.UseVisualStyleBackColor = true;
            this.btnSendGcode.Click += new System.EventHandler(this.BtnSendGcode_Click);
            // 
            // timerSendGcode
            // 
            this.timerSendGcode.Tick += new System.EventHandler(this.TimerSendGcode_Tick);
            // 
            // btnStopSending
            // 
            this.btnStopSending.Location = new System.Drawing.Point(361, 161);
            this.btnStopSending.Name = "btnStopSending";
            this.btnStopSending.Size = new System.Drawing.Size(75, 23);
            this.btnStopSending.TabIndex = 12;
            this.btnStopSending.Text = "StopAuto";
            this.btnStopSending.UseVisualStyleBackColor = true;
            this.btnStopSending.Click += new System.EventHandler(this.BtnStopSending_Click);
            // 
            // btnSendAllAtOnce
            // 
            this.btnSendAllAtOnce.Location = new System.Drawing.Point(361, 256);
            this.btnSendAllAtOnce.Name = "btnSendAllAtOnce";
            this.btnSendAllAtOnce.Size = new System.Drawing.Size(75, 23);
            this.btnSendAllAtOnce.TabIndex = 13;
            this.btnSendAllAtOnce.Text = "SendAll";
            this.btnSendAllAtOnce.UseVisualStyleBackColor = true;
            this.btnSendAllAtOnce.Click += new System.EventHandler(this.BtnSendAllAtOnce_Click);
            // 
            // btnAbout
            // 
            this.btnAbout.Location = new System.Drawing.Point(728, 10);
            this.btnAbout.Name = "btnAbout";
            this.btnAbout.Size = new System.Drawing.Size(75, 23);
            this.btnAbout.TabIndex = 14;
            this.btnAbout.Text = "About us";
            this.btnAbout.UseVisualStyleBackColor = true;
            this.btnAbout.Click += new System.EventHandler(this.BtnAbout_Click);
            // 
            // numericUpDownLines
            // 
            this.numericUpDownLines.Location = new System.Drawing.Point(405, 63);
            this.numericUpDownLines.Name = "numericUpDownLines";
            this.numericUpDownLines.Size = new System.Drawing.Size(120, 20);
            this.numericUpDownLines.TabIndex = 16;
            // 
            // btnAutoSend
            // 
            this.btnAutoSend.Location = new System.Drawing.Point(487, 11);
            this.btnAutoSend.Name = "btnAutoSend";
            this.btnAutoSend.Size = new System.Drawing.Size(75, 23);
            this.btnAutoSend.TabIndex = 17;
            this.btnAutoSend.Text = "AutoSend ";
            this.btnAutoSend.UseVisualStyleBackColor = true;
            this.btnAutoSend.Click += new System.EventHandler(this.btnAutoSend_Click);
            // 
            // btnAutoStop
            // 
            this.btnAutoStop.Location = new System.Drawing.Point(601, 9);
            this.btnAutoStop.Name = "btnAutoStop";
            this.btnAutoStop.Size = new System.Drawing.Size(75, 23);
            this.btnAutoStop.TabIndex = 18;
            this.btnAutoStop.Text = "AutoStop";
            this.btnAutoStop.UseVisualStyleBackColor = true;
            this.btnAutoStop.Click += new System.EventHandler(this.btnAutoStop_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(815, 450);
            this.Controls.Add(this.btnAutoStop);
            this.Controls.Add(this.btnAutoSend);
            this.Controls.Add(this.numericUpDownLines);
            this.Controls.Add(this.btnAbout);
            this.Controls.Add(this.btnSendAllAtOnce);
            this.Controls.Add(this.btnStopSending);
            this.Controls.Add(this.btnSendGcode);
            this.Controls.Add(this.btnNumberOfLines);
            this.Controls.Add(this.textBoxFilePath);
            this.Controls.Add(this.browse);
            this.Controls.Add(this.tboxReceive);
            this.Controls.Add(this.tboxData);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.cboxBaudrate);
            this.Controls.Add(this.btnConnect);
            this.Controls.Add(this.cboxComport);
            this.Name = "MainForm";
            this.Text = "Serial V1.0";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownLines)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cboxComport;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.ComboBox cboxBaudrate;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.TextBox tboxData;
        private System.Windows.Forms.TextBox tboxReceive;
        private System.Windows.Forms.Button browse;
        private System.Windows.Forms.TextBox textBoxFilePath;
        private System.Windows.Forms.Button btnNumberOfLines;
        private System.Windows.Forms.Button btnSendGcode;
        private System.Windows.Forms.Timer timerSendGcode;
        private System.Windows.Forms.Button btnStopSending;
        private System.Windows.Forms.Button btnSendAllAtOnce;
        private System.Windows.Forms.Button btnAbout;
        private System.Windows.Forms.NumericUpDown numericUpDownLines;
        private System.Windows.Forms.Button btnAutoSend;
        private System.Windows.Forms.Button btnAutoStop;
    }
}

