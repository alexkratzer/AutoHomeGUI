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
            this.SuspendLayout();
            // 
            // label_CpsStatus
            // 
            this.label_CpsStatus.AutoSize = true;
            this.label_CpsStatus.Location = new System.Drawing.Point(9, 207);
            this.label_CpsStatus.Name = "label_CpsStatus";
            this.label_CpsStatus.Size = new System.Drawing.Size(58, 13);
            this.label_CpsStatus.TabIndex = 0;
            this.label_CpsStatus.Text = "Cps Status";
            // 
            // button_connect
            // 
            this.button_connect.Location = new System.Drawing.Point(12, 12);
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
            this.button_status.Location = new System.Drawing.Point(12, 41);
            this.button_status.Name = "button_status";
            this.button_status.Size = new System.Drawing.Size(75, 23);
            this.button_status.TabIndex = 2;
            this.button_status.Text = "status";
            this.button_status.UseVisualStyleBackColor = true;
            this.button_status.Click += new System.EventHandler(this.button_status_Click);
            // 
            // button_setTime
            // 
            this.button_setTime.Location = new System.Drawing.Point(12, 70);
            this.button_setTime.Name = "button_setTime";
            this.button_setTime.Size = new System.Drawing.Size(75, 23);
            this.button_setTime.TabIndex = 3;
            this.button_setTime.Text = "set PLC time";
            this.button_setTime.UseVisualStyleBackColor = true;
            this.button_setTime.Click += new System.EventHandler(this.button_setTime_Click);
            // 
            // button_ReadRunningConfig
            // 
            this.button_ReadRunningConfig.Location = new System.Drawing.Point(160, 12);
            this.button_ReadRunningConfig.Name = "button_ReadRunningConfig";
            this.button_ReadRunningConfig.Size = new System.Drawing.Size(175, 23);
            this.button_ReadRunningConfig.TabIndex = 4;
            this.button_ReadRunningConfig.Text = "read running config";
            this.button_ReadRunningConfig.UseVisualStyleBackColor = true;
            this.button_ReadRunningConfig.Click += new System.EventHandler(this.button_ReadRunningConfig_Click);
            // 
            // button_CopyRunningToStartupConfig
            // 
            this.button_CopyRunningToStartupConfig.Location = new System.Drawing.Point(160, 41);
            this.button_CopyRunningToStartupConfig.Name = "button_CopyRunningToStartupConfig";
            this.button_CopyRunningToStartupConfig.Size = new System.Drawing.Size(175, 23);
            this.button_CopyRunningToStartupConfig.TabIndex = 5;
            this.button_CopyRunningToStartupConfig.Text = "copy running to startup config";
            this.button_CopyRunningToStartupConfig.UseVisualStyleBackColor = true;
            this.button_CopyRunningToStartupConfig.Click += new System.EventHandler(this.button_CopyRunningToStartupConfig_Click);
            // 
            // button_CopyStartupToRunningConfig
            // 
            this.button_CopyStartupToRunningConfig.Location = new System.Drawing.Point(160, 70);
            this.button_CopyStartupToRunningConfig.Name = "button_CopyStartupToRunningConfig";
            this.button_CopyStartupToRunningConfig.Size = new System.Drawing.Size(175, 23);
            this.button_CopyStartupToRunningConfig.TabIndex = 6;
            this.button_CopyStartupToRunningConfig.Text = "copy startup to running config";
            this.button_CopyStartupToRunningConfig.UseVisualStyleBackColor = true;
            this.button_CopyStartupToRunningConfig.Click += new System.EventHandler(this.button_CopyStartupToRunningConfig_Click);
            // 
            // button_send_ibs
            // 
            this.button_send_ibs.Location = new System.Drawing.Point(260, 99);
            this.button_send_ibs.Name = "button_send_ibs";
            this.button_send_ibs.Size = new System.Drawing.Size(75, 23);
            this.button_send_ibs.TabIndex = 7;
            this.button_send_ibs.Text = "IBS send";
            this.button_send_ibs.UseVisualStyleBackColor = true;
            this.button_send_ibs.Click += new System.EventHandler(this.button_send_ibs_Click);
            // 
            // label_plc_time
            // 
            this.label_plc_time.AutoSize = true;
            this.label_plc_time.Location = new System.Drawing.Point(73, 151);
            this.label_plc_time.Name = "label_plc_time";
            this.label_plc_time.Size = new System.Drawing.Size(43, 13);
            this.label_plc_time.TabIndex = 9;
            this.label_plc_time.Text = "plc time";
            // 
            // label_timeJitterDesc
            // 
            this.label_timeJitterDesc.AutoSize = true;
            this.label_timeJitterDesc.Location = new System.Drawing.Point(13, 173);
            this.label_timeJitterDesc.Name = "label_timeJitterDesc";
            this.label_timeJitterDesc.Size = new System.Drawing.Size(54, 13);
            this.label_timeJitterDesc.TabIndex = 10;
            this.label_timeJitterDesc.Text = "difference";
            // 
            // label_time_difference
            // 
            this.label_time_difference.AutoSize = true;
            this.label_time_difference.Location = new System.Drawing.Point(73, 173);
            this.label_time_difference.Name = "label_time_difference";
            this.label_time_difference.Size = new System.Drawing.Size(43, 13);
            this.label_time_difference.TabIndex = 11;
            this.label_time_difference.Text = "xx:xx:xx";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 151);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = "plc time";
            // 
            // FrmPlcClient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(479, 382);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label_time_difference);
            this.Controls.Add(this.label_timeJitterDesc);
            this.Controls.Add(this.label_plc_time);
            this.Controls.Add(this.button_send_ibs);
            this.Controls.Add(this.button_CopyStartupToRunningConfig);
            this.Controls.Add(this.button_CopyRunningToStartupConfig);
            this.Controls.Add(this.button_ReadRunningConfig);
            this.Controls.Add(this.button_setTime);
            this.Controls.Add(this.button_status);
            this.Controls.Add(this.button_connect);
            this.Controls.Add(this.label_CpsStatus);
            this.Name = "FrmPlcClient";
            this.Text = "FrmPlcClient";
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
    }
}