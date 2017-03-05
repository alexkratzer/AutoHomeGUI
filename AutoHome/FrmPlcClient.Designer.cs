namespace AutoHome
{
    partial class FrmPlcClient
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
            this.label_CpsStatus = new System.Windows.Forms.Label();
            this.button_connect = new System.Windows.Forms.Button();
            this.button_status = new System.Windows.Forms.Button();
            this.button_setTime = new System.Windows.Forms.Button();
            this.button_ReadRunningConfig = new System.Windows.Forms.Button();
            this.button_CopyRunningToStartupConfig = new System.Windows.Forms.Button();
            this.button_CopyStartupToRunningConfig = new System.Windows.Forms.Button();
            this.button_send_ibs = new System.Windows.Forms.Button();
            this.label_plc_time = new System.Windows.Forms.Label();
            this.label_timeJitterDesc = new System.Windows.Forms.Label();
            this.label_time_difference = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBox_headerFlag = new System.Windows.Forms.ComboBox();
            this.panel_sendMsg = new System.Windows.Forms.Panel();
            this.textBox_payload = new System.Windows.Forms.TextBox();
            this.textBox_aktuatorID = new System.Windows.Forms.TextBox();
            this.label_aktuatorID = new System.Windows.Forms.Label();
            this.panel_IOdata = new System.Windows.Forms.Panel();
            this.panel_sendMsg.SuspendLayout();
            this.panel_IOdata.SuspendLayout();
            this.SuspendLayout();
            // 
            // label_CpsStatus
            // 
            this.label_CpsStatus.AutoSize = true;
            this.label_CpsStatus.Location = new System.Drawing.Point(9, 127);
            this.label_CpsStatus.Name = "label_CpsStatus";
            this.label_CpsStatus.Size = new System.Drawing.Size(58, 13);
            this.label_CpsStatus.TabIndex = 0;
            this.label_CpsStatus.Text = "Cps Status";
            // 
            // button_connect
            // 
            this.button_connect.Location = new System.Drawing.Point(12, 43);
            this.button_connect.Name = "button_connect";
            this.button_connect.Size = new System.Drawing.Size(75, 23);
            this.button_connect.TabIndex = 1;
            this.button_connect.Text = "connect";
            this.button_connect.UseVisualStyleBackColor = true;
            this.button_connect.Click += new System.EventHandler(this.button_connect_Click);
            // 
            // button_status
            // 
            this.button_status.Enabled = false;
            this.button_status.Location = new System.Drawing.Point(12, 72);
            this.button_status.Name = "button_status";
            this.button_status.Size = new System.Drawing.Size(75, 23);
            this.button_status.TabIndex = 2;
            this.button_status.Text = "status";
            this.button_status.UseVisualStyleBackColor = true;
            this.button_status.Click += new System.EventHandler(this.button_status_Click);
            // 
            // button_setTime
            // 
            this.button_setTime.Location = new System.Drawing.Point(12, 101);
            this.button_setTime.Name = "button_setTime";
            this.button_setTime.Size = new System.Drawing.Size(75, 23);
            this.button_setTime.TabIndex = 3;
            this.button_setTime.Text = "set PLC time";
            this.button_setTime.UseVisualStyleBackColor = true;
            this.button_setTime.Click += new System.EventHandler(this.button_setTime_Click);
            // 
            // button_ReadRunningConfig
            // 
            this.button_ReadRunningConfig.Location = new System.Drawing.Point(111, 43);
            this.button_ReadRunningConfig.Name = "button_ReadRunningConfig";
            this.button_ReadRunningConfig.Size = new System.Drawing.Size(175, 23);
            this.button_ReadRunningConfig.TabIndex = 4;
            this.button_ReadRunningConfig.Text = "read running config";
            this.button_ReadRunningConfig.UseVisualStyleBackColor = true;
            this.button_ReadRunningConfig.Click += new System.EventHandler(this.button_ReadRunningConfig_Click);
            // 
            // button_CopyRunningToStartupConfig
            // 
            this.button_CopyRunningToStartupConfig.Location = new System.Drawing.Point(111, 72);
            this.button_CopyRunningToStartupConfig.Name = "button_CopyRunningToStartupConfig";
            this.button_CopyRunningToStartupConfig.Size = new System.Drawing.Size(175, 23);
            this.button_CopyRunningToStartupConfig.TabIndex = 5;
            this.button_CopyRunningToStartupConfig.Text = "copy running to startup config";
            this.button_CopyRunningToStartupConfig.UseVisualStyleBackColor = true;
            this.button_CopyRunningToStartupConfig.Click += new System.EventHandler(this.button_CopyRunningToStartupConfig_Click);
            // 
            // button_CopyStartupToRunningConfig
            // 
            this.button_CopyStartupToRunningConfig.Location = new System.Drawing.Point(111, 101);
            this.button_CopyStartupToRunningConfig.Name = "button_CopyStartupToRunningConfig";
            this.button_CopyStartupToRunningConfig.Size = new System.Drawing.Size(175, 23);
            this.button_CopyStartupToRunningConfig.TabIndex = 6;
            this.button_CopyStartupToRunningConfig.Text = "copy startup to running config";
            this.button_CopyStartupToRunningConfig.UseVisualStyleBackColor = true;
            this.button_CopyStartupToRunningConfig.Click += new System.EventHandler(this.button_CopyStartupToRunningConfig_Click);
            // 
            // button_send_ibs
            // 
            this.button_send_ibs.Location = new System.Drawing.Point(7, 11);
            this.button_send_ibs.Name = "button_send_ibs";
            this.button_send_ibs.Size = new System.Drawing.Size(121, 23);
            this.button_send_ibs.TabIndex = 7;
            this.button_send_ibs.Text = "IBS send";
            this.button_send_ibs.UseVisualStyleBackColor = true;
            this.button_send_ibs.Click += new System.EventHandler(this.button_send_ibs_Click);
            // 
            // label_plc_time
            // 
            this.label_plc_time.AutoSize = true;
            this.label_plc_time.Location = new System.Drawing.Point(64, 5);
            this.label_plc_time.Name = "label_plc_time";
            this.label_plc_time.Size = new System.Drawing.Size(43, 13);
            this.label_plc_time.TabIndex = 9;
            this.label_plc_time.Text = "plc time";
            // 
            // label_timeJitterDesc
            // 
            this.label_timeJitterDesc.AutoSize = true;
            this.label_timeJitterDesc.Location = new System.Drawing.Point(9, 27);
            this.label_timeJitterDesc.Name = "label_timeJitterDesc";
            this.label_timeJitterDesc.Size = new System.Drawing.Size(54, 13);
            this.label_timeJitterDesc.TabIndex = 10;
            this.label_timeJitterDesc.Text = "difference";
            // 
            // label_time_difference
            // 
            this.label_time_difference.AutoSize = true;
            this.label_time_difference.Location = new System.Drawing.Point(64, 27);
            this.label_time_difference.Name = "label_time_difference";
            this.label_time_difference.Size = new System.Drawing.Size(43, 13);
            this.label_time_difference.TabIndex = 11;
            this.label_time_difference.Text = "xx:xx:xx";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = "plc time";
            // 
            // comboBox_headerFlag
            // 
            this.comboBox_headerFlag.FormattingEnabled = true;
            this.comboBox_headerFlag.Location = new System.Drawing.Point(7, 40);
            this.comboBox_headerFlag.Name = "comboBox_headerFlag";
            this.comboBox_headerFlag.Size = new System.Drawing.Size(121, 21);
            this.comboBox_headerFlag.TabIndex = 13;
            this.comboBox_headerFlag.SelectedIndexChanged += new System.EventHandler(this.comboBox_headerFlag_SelectedIndexChanged);
            // 
            // panel_sendMsg
            // 
            this.panel_sendMsg.Controls.Add(this.panel_IOdata);
            this.panel_sendMsg.Controls.Add(this.textBox_payload);
            this.panel_sendMsg.Controls.Add(this.comboBox_headerFlag);
            this.panel_sendMsg.Controls.Add(this.button_send_ibs);
            this.panel_sendMsg.Location = new System.Drawing.Point(12, 143);
            this.panel_sendMsg.Name = "panel_sendMsg";
            this.panel_sendMsg.Size = new System.Drawing.Size(274, 107);
            this.panel_sendMsg.TabIndex = 14;
            // 
            // textBox_payload
            // 
            this.textBox_payload.Location = new System.Drawing.Point(7, 67);
            this.textBox_payload.Name = "textBox_payload";
            this.textBox_payload.Size = new System.Drawing.Size(187, 20);
            this.textBox_payload.TabIndex = 14;
            // 
            // textBox_aktuatorID
            // 
            this.textBox_aktuatorID.Location = new System.Drawing.Point(31, 3);
            this.textBox_aktuatorID.Name = "textBox_aktuatorID";
            this.textBox_aktuatorID.Size = new System.Drawing.Size(23, 20);
            this.textBox_aktuatorID.TabIndex = 15;
            this.textBox_aktuatorID.Text = "0";
            // 
            // label_aktuatorID
            // 
            this.label_aktuatorID.AutoSize = true;
            this.label_aktuatorID.Location = new System.Drawing.Point(4, 6);
            this.label_aktuatorID.Name = "label_aktuatorID";
            this.label_aktuatorID.Size = new System.Drawing.Size(21, 13);
            this.label_aktuatorID.TabIndex = 16;
            this.label_aktuatorID.Text = "ID:";
            // 
            // panel_IOdata
            // 
            this.panel_IOdata.Controls.Add(this.textBox_aktuatorID);
            this.panel_IOdata.Controls.Add(this.label_aktuatorID);
            this.panel_IOdata.Location = new System.Drawing.Point(141, 40);
            this.panel_IOdata.Name = "panel_IOdata";
            this.panel_IOdata.Size = new System.Drawing.Size(121, 27);
            this.panel_IOdata.TabIndex = 17;
            this.panel_IOdata.Visible = false;
            // 
            // FrmPlcClient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(311, 267);
            this.Controls.Add(this.panel_sendMsg);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label_time_difference);
            this.Controls.Add(this.label_timeJitterDesc);
            this.Controls.Add(this.label_plc_time);
            this.Controls.Add(this.button_CopyStartupToRunningConfig);
            this.Controls.Add(this.button_CopyRunningToStartupConfig);
            this.Controls.Add(this.button_ReadRunningConfig);
            this.Controls.Add(this.button_setTime);
            this.Controls.Add(this.button_status);
            this.Controls.Add(this.button_connect);
            this.Controls.Add(this.label_CpsStatus);
            this.Name = "FrmPlcClient";
            this.Text = "FrmPlcClient";
            this.panel_sendMsg.ResumeLayout(false);
            this.panel_sendMsg.PerformLayout();
            this.panel_IOdata.ResumeLayout(false);
            this.panel_IOdata.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label_CpsStatus;
        private System.Windows.Forms.Button button_connect;
        private System.Windows.Forms.Button button_status;
        private System.Windows.Forms.Button button_setTime;
        private System.Windows.Forms.Button button_ReadRunningConfig;
        private System.Windows.Forms.Button button_CopyRunningToStartupConfig;
        private System.Windows.Forms.Button button_CopyStartupToRunningConfig;
        private System.Windows.Forms.Button button_send_ibs;
        private System.Windows.Forms.Label label_plc_time;
        private System.Windows.Forms.Label label_timeJitterDesc;
        private System.Windows.Forms.Label label_time_difference;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBox_headerFlag;
        private System.Windows.Forms.Panel panel_sendMsg;
        private System.Windows.Forms.TextBox textBox_payload;
        private System.Windows.Forms.Panel panel_IOdata;
        private System.Windows.Forms.TextBox textBox_aktuatorID;
        private System.Windows.Forms.Label label_aktuatorID;
    }
}