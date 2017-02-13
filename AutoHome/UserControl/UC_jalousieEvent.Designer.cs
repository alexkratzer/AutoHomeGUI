namespace AutoHome
{
    partial class UC_jalousieEvent
    {
        /// <summary> 
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Komponenten-Designer generierter Code

        /// <summary> 
        /// Erforderliche Methode für die Designerunterstützung. 
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel_event = new System.Windows.Forms.Panel();
            this.checkBox_event_enable = new System.Windows.Forms.CheckBox();
            this.panel_event_data = new System.Windows.Forms.Panel();
            this.comboBox_event_angle = new System.Windows.Forms.ComboBox();
            this.comboBox_event_position = new System.Windows.Forms.ComboBox();
            this.button_set_event = new System.Windows.Forms.Button();
            this.radioButton_event_driving_up = new System.Windows.Forms.RadioButton();
            this.radioButton_event_drive_down = new System.Windows.Forms.RadioButton();
            this.label_event_time = new System.Windows.Forms.Label();
            this.textBox_event_time_hour = new System.Windows.Forms.TextBox();
            this.textBox_event_time_min = new System.Windows.Forms.TextBox();
            this.textBox_event_time_sec = new System.Windows.Forms.TextBox();
            this.label_p_1 = new System.Windows.Forms.Label();
            this.label_event_angle = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label_event_position = new System.Windows.Forms.Label();
            this.label_event_id = new System.Windows.Forms.Label();
            this.panel_event.SuspendLayout();
            this.panel_event_data.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel_event
            // 
            this.panel_event.Controls.Add(this.checkBox_event_enable);
            this.panel_event.Controls.Add(this.panel_event_data);
            this.panel_event.Controls.Add(this.button_set_event);
            this.panel_event.Controls.Add(this.label_event_id);
            this.panel_event.Location = new System.Drawing.Point(0, 0);
            this.panel_event.Name = "panel_event";
            this.panel_event.Size = new System.Drawing.Size(481, 53);
            this.panel_event.TabIndex = 44;
            // 
            // checkBox_event_enable
            // 
            this.checkBox_event_enable.AutoSize = true;
            this.checkBox_event_enable.Location = new System.Drawing.Point(8, 30);
            this.checkBox_event_enable.Name = "checkBox_event_enable";
            this.checkBox_event_enable.Size = new System.Drawing.Size(88, 17);
            this.checkBox_event_enable.TabIndex = 44;
            this.checkBox_event_enable.Text = "event enable";
            this.checkBox_event_enable.UseVisualStyleBackColor = true;
            this.checkBox_event_enable.CheckedChanged += new System.EventHandler(this.checkBox_event_enable_CheckedChanged);
            // 
            // panel_event_data
            // 
            this.panel_event_data.Controls.Add(this.comboBox_event_angle);
            this.panel_event_data.Controls.Add(this.comboBox_event_position);
            this.panel_event_data.Controls.Add(this.radioButton_event_driving_up);
            this.panel_event_data.Controls.Add(this.radioButton_event_drive_down);
            this.panel_event_data.Controls.Add(this.label_event_time);
            this.panel_event_data.Controls.Add(this.textBox_event_time_hour);
            this.panel_event_data.Controls.Add(this.textBox_event_time_min);
            this.panel_event_data.Controls.Add(this.textBox_event_time_sec);
            this.panel_event_data.Controls.Add(this.label_p_1);
            this.panel_event_data.Controls.Add(this.label_event_angle);
            this.panel_event_data.Controls.Add(this.label2);
            this.panel_event_data.Controls.Add(this.label_event_position);
            this.panel_event_data.Enabled = false;
            this.panel_event_data.Location = new System.Drawing.Point(116, 0);
            this.panel_event_data.Name = "panel_event_data";
            this.panel_event_data.Size = new System.Drawing.Size(281, 51);
            this.panel_event_data.TabIndex = 45;
            // 
            // comboBox_event_angle
            // 
            this.comboBox_event_angle.FormattingEnabled = true;
            this.comboBox_event_angle.Items.AddRange(new object[] {
            "10",
            "30",
            "50",
            "70",
            "100"});
            this.comboBox_event_angle.Location = new System.Drawing.Point(224, 27);
            this.comboBox_event_angle.Name = "comboBox_event_angle";
            this.comboBox_event_angle.Size = new System.Drawing.Size(50, 21);
            this.comboBox_event_angle.TabIndex = 56;
            // 
            // comboBox_event_position
            // 
            this.comboBox_event_position.FormattingEnabled = true;
            this.comboBox_event_position.Items.AddRange(new object[] {
            "10",
            "30",
            "50",
            "70",
            "100"});
            this.comboBox_event_position.Location = new System.Drawing.Point(224, 3);
            this.comboBox_event_position.Name = "comboBox_event_position";
            this.comboBox_event_position.Size = new System.Drawing.Size(50, 21);
            this.comboBox_event_position.TabIndex = 46;
            // 
            // button_set_event
            // 
            this.button_set_event.Location = new System.Drawing.Point(403, 3);
            this.button_set_event.Name = "button_set_event";
            this.button_set_event.Size = new System.Drawing.Size(67, 46);
            this.button_set_event.TabIndex = 55;
            this.button_set_event.Text = "safe";
            this.button_set_event.UseVisualStyleBackColor = true;
            this.button_set_event.Click += new System.EventHandler(this.button_set_event_Click);
            // 
            // radioButton_event_driving_up
            // 
            this.radioButton_event_driving_up.AutoSize = true;
            this.radioButton_event_driving_up.Location = new System.Drawing.Point(12, 28);
            this.radioButton_event_driving_up.Name = "radioButton_event_driving_up";
            this.radioButton_event_driving_up.Size = new System.Drawing.Size(63, 17);
            this.radioButton_event_driving_up.TabIndex = 45;
            this.radioButton_event_driving_up.TabStop = true;
            this.radioButton_event_driving_up.Text = "drive up";
            this.radioButton_event_driving_up.UseVisualStyleBackColor = true;
            // 
            // radioButton_event_drive_down
            // 
            this.radioButton_event_drive_down.AutoSize = true;
            this.radioButton_event_drive_down.Location = new System.Drawing.Point(81, 28);
            this.radioButton_event_drive_down.Name = "radioButton_event_drive_down";
            this.radioButton_event_drive_down.Size = new System.Drawing.Size(77, 17);
            this.radioButton_event_drive_down.TabIndex = 46;
            this.radioButton_event_drive_down.TabStop = true;
            this.radioButton_event_drive_down.Text = "drive down";
            this.radioButton_event_drive_down.UseVisualStyleBackColor = true;
            // 
            // label_event_time
            // 
            this.label_event_time.AutoSize = true;
            this.label_event_time.Location = new System.Drawing.Point(9, 7);
            this.label_event_time.Name = "label_event_time";
            this.label_event_time.Size = new System.Drawing.Size(63, 13);
            this.label_event_time.TabIndex = 46;
            this.label_event_time.Text = "time (h:m:s):";
            // 
            // textBox_event_time_hour
            // 
            this.textBox_event_time_hour.Location = new System.Drawing.Point(75, 4);
            this.textBox_event_time_hour.Name = "textBox_event_time_hour";
            this.textBox_event_time_hour.Size = new System.Drawing.Size(20, 20);
            this.textBox_event_time_hour.TabIndex = 45;
            // 
            // textBox_event_time_min
            // 
            this.textBox_event_time_min.Location = new System.Drawing.Point(107, 4);
            this.textBox_event_time_min.Name = "textBox_event_time_min";
            this.textBox_event_time_min.Size = new System.Drawing.Size(20, 20);
            this.textBox_event_time_min.TabIndex = 47;
            // 
            // textBox_event_time_sec
            // 
            this.textBox_event_time_sec.Location = new System.Drawing.Point(139, 4);
            this.textBox_event_time_sec.Name = "textBox_event_time_sec";
            this.textBox_event_time_sec.Size = new System.Drawing.Size(20, 20);
            this.textBox_event_time_sec.TabIndex = 48;
            // 
            // label_p_1
            // 
            this.label_p_1.AutoSize = true;
            this.label_p_1.Location = new System.Drawing.Point(96, 7);
            this.label_p_1.Name = "label_p_1";
            this.label_p_1.Size = new System.Drawing.Size(10, 13);
            this.label_p_1.TabIndex = 49;
            this.label_p_1.Text = ":";
            // 
            // label_event_angle
            // 
            this.label_event_angle.AutoSize = true;
            this.label_event_angle.Location = new System.Drawing.Point(172, 32);
            this.label_event_angle.Name = "label_event_angle";
            this.label_event_angle.Size = new System.Drawing.Size(36, 13);
            this.label_event_angle.TabIndex = 52;
            this.label_event_angle.Text = "angle:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(128, 7);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(10, 13);
            this.label2.TabIndex = 50;
            this.label2.Text = ":";
            // 
            // label_event_position
            // 
            this.label_event_position.AutoSize = true;
            this.label_event_position.Location = new System.Drawing.Point(172, 9);
            this.label_event_position.Name = "label_event_position";
            this.label_event_position.Size = new System.Drawing.Size(46, 13);
            this.label_event_position.TabIndex = 51;
            this.label_event_position.Text = "position:";
            // 
            // label_event_id
            // 
            this.label_event_id.AutoSize = true;
            this.label_event_id.Location = new System.Drawing.Point(3, 7);
            this.label_event_id.Name = "label_event_id";
            this.label_event_id.Size = new System.Drawing.Size(49, 13);
            this.label_event_id.TabIndex = 44;
            this.label_event_id.Text = "event nr:";
            // 
            // UC_jalousieEvent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel_event);
            this.Name = "UC_jalousieEvent";
            this.Size = new System.Drawing.Size(484, 52);
            this.panel_event.ResumeLayout(false);
            this.panel_event.PerformLayout();
            this.panel_event_data.ResumeLayout(false);
            this.panel_event_data.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel_event;
        private System.Windows.Forms.Button button_set_event;
        private System.Windows.Forms.RadioButton radioButton_event_drive_down;
        private System.Windows.Forms.RadioButton radioButton_event_driving_up;
        private System.Windows.Forms.CheckBox checkBox_event_enable;
        private System.Windows.Forms.Label label_event_angle;
        private System.Windows.Forms.Label label_event_position;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label_p_1;
        private System.Windows.Forms.TextBox textBox_event_time_sec;
        private System.Windows.Forms.TextBox textBox_event_time_min;
        private System.Windows.Forms.TextBox textBox_event_time_hour;
        private System.Windows.Forms.Label label_event_time;
        private System.Windows.Forms.Label label_event_id;
        private System.Windows.Forms.Panel panel_event_data;
        private System.Windows.Forms.ComboBox comboBox_event_angle;
        private System.Windows.Forms.ComboBox comboBox_event_position;
    }
}
