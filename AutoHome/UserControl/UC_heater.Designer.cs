namespace AutoHome
{
    partial class UC_heater
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
            this.label_name = new System.Windows.Forms.Label();
            this.button_send = new System.Windows.Forms.Button();
            this.textBox_time_on = new System.Windows.Forms.TextBox();
            this.checkBox_ctrl_manuel = new System.Windows.Forms.CheckBox();
            this.checkBox_ctrl_on = new System.Windows.Forms.CheckBox();
            this.label_time_on = new System.Windows.Forms.Label();
            this.label_minutes_off = new System.Windows.Forms.Label();
            this.textBox_time_off = new System.Windows.Forms.TextBox();
            this.textBox_start_h = new System.Windows.Forms.TextBox();
            this.textBox_start_m = new System.Windows.Forms.TextBox();
            this.label_start = new System.Windows.Forms.Label();
            this.label_stop = new System.Windows.Forms.Label();
            this.textBox_stop_m = new System.Windows.Forms.TextBox();
            this.textBox_stop_h = new System.Windows.Forms.TextBox();
            this.label_stop_at_degree = new System.Windows.Forms.Label();
            this.textBox_stop_at_degree = new System.Windows.Forms.TextBox();
            this.label_timesem = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel_ctrl_auto = new System.Windows.Forms.Panel();
            this.radioButton_state_on = new System.Windows.Forms.RadioButton();
            this.label_remaining_time = new System.Windows.Forms.Label();
            this.panel_ctrl_auto.SuspendLayout();
            this.SuspendLayout();
            // 
            // label_name
            // 
            this.label_name.AutoSize = true;
            this.label_name.Location = new System.Drawing.Point(3, 2);
            this.label_name.Name = "label_name";
            this.label_name.Size = new System.Drawing.Size(68, 13);
            this.label_name.TabIndex = 68;
            this.label_name.Text = "control name";
            // 
            // button_send
            // 
            this.button_send.Location = new System.Drawing.Point(755, 2);
            this.button_send.Name = "button_send";
            this.button_send.Size = new System.Drawing.Size(62, 23);
            this.button_send.TabIndex = 59;
            this.button_send.Text = "send";
            this.button_send.UseVisualStyleBackColor = true;
            this.button_send.Visible = false;
            this.button_send.Click += new System.EventHandler(this.button_send_Click);
            // 
            // textBox_time_on
            // 
            this.textBox_time_on.BackColor = System.Drawing.SystemColors.Window;
            this.textBox_time_on.Location = new System.Drawing.Point(62, 4);
            this.textBox_time_on.Name = "textBox_time_on";
            this.textBox_time_on.Size = new System.Drawing.Size(19, 20);
            this.textBox_time_on.TabIndex = 69;
            this.textBox_time_on.Text = "0";
            this.textBox_time_on.TextChanged += new System.EventHandler(this.textBox_time_on_TextChanged);
            // 
            // checkBox_ctrl_manuel
            // 
            this.checkBox_ctrl_manuel.AutoSize = true;
            this.checkBox_ctrl_manuel.Location = new System.Drawing.Point(154, 7);
            this.checkBox_ctrl_manuel.Name = "checkBox_ctrl_manuel";
            this.checkBox_ctrl_manuel.Size = new System.Drawing.Size(61, 17);
            this.checkBox_ctrl_manuel.TabIndex = 70;
            this.checkBox_ctrl_manuel.Text = "ctr man";
            this.checkBox_ctrl_manuel.UseVisualStyleBackColor = true;
            this.checkBox_ctrl_manuel.CheckedChanged += new System.EventHandler(this.checkBox_ctrl_manuel_CheckedChanged);
            // 
            // checkBox_ctrl_on
            // 
            this.checkBox_ctrl_on.AutoSize = true;
            this.checkBox_ctrl_on.Enabled = false;
            this.checkBox_ctrl_on.Location = new System.Drawing.Point(212, 7);
            this.checkBox_ctrl_on.Name = "checkBox_ctrl_on";
            this.checkBox_ctrl_on.Size = new System.Drawing.Size(59, 17);
            this.checkBox_ctrl_on.TabIndex = 71;
            this.checkBox_ctrl_on.Text = "turn on";
            this.checkBox_ctrl_on.UseVisualStyleBackColor = true;
            this.checkBox_ctrl_on.CheckedChanged += new System.EventHandler(this.checkBox_ctrl_on_CheckedChanged);
            // 
            // label_time_on
            // 
            this.label_time_on.AutoSize = true;
            this.label_time_on.Location = new System.Drawing.Point(1, 7);
            this.label_time_on.Name = "label_time_on";
            this.label_time_on.Size = new System.Drawing.Size(61, 13);
            this.label_time_on.TabIndex = 72;
            this.label_time_on.Text = "minutes on:";
            // 
            // label_minutes_off
            // 
            this.label_minutes_off.AutoSize = true;
            this.label_minutes_off.Location = new System.Drawing.Point(86, 7);
            this.label_minutes_off.Name = "label_minutes_off";
            this.label_minutes_off.Size = new System.Drawing.Size(22, 13);
            this.label_minutes_off.TabIndex = 74;
            this.label_minutes_off.Text = "off:";
            // 
            // textBox_time_off
            // 
            this.textBox_time_off.Location = new System.Drawing.Point(109, 4);
            this.textBox_time_off.Name = "textBox_time_off";
            this.textBox_time_off.Size = new System.Drawing.Size(19, 20);
            this.textBox_time_off.TabIndex = 73;
            this.textBox_time_off.Text = "0";
            this.textBox_time_off.TextChanged += new System.EventHandler(this.textBox_time_off_TextChanged);
            // 
            // textBox_start_h
            // 
            this.textBox_start_h.Location = new System.Drawing.Point(177, 4);
            this.textBox_start_h.Name = "textBox_start_h";
            this.textBox_start_h.Size = new System.Drawing.Size(19, 20);
            this.textBox_start_h.TabIndex = 75;
            this.textBox_start_h.Text = "0";
            this.textBox_start_h.TextChanged += new System.EventHandler(this.textBox_start_h_TextChanged);
            // 
            // textBox_start_m
            // 
            this.textBox_start_m.Location = new System.Drawing.Point(202, 4);
            this.textBox_start_m.Name = "textBox_start_m";
            this.textBox_start_m.Size = new System.Drawing.Size(19, 20);
            this.textBox_start_m.TabIndex = 76;
            this.textBox_start_m.Text = "0";
            this.textBox_start_m.TextChanged += new System.EventHandler(this.textBox_start_m_TextChanged);
            // 
            // label_start
            // 
            this.label_start.AutoSize = true;
            this.label_start.Location = new System.Drawing.Point(149, 7);
            this.label_start.Name = "label_start";
            this.label_start.Size = new System.Drawing.Size(30, 13);
            this.label_start.TabIndex = 78;
            this.label_start.Text = "start:";
            // 
            // label_stop
            // 
            this.label_stop.AutoSize = true;
            this.label_stop.Location = new System.Drawing.Point(234, 7);
            this.label_stop.Name = "label_stop";
            this.label_stop.Size = new System.Drawing.Size(30, 13);
            this.label_stop.TabIndex = 82;
            this.label_stop.Text = "stop:";
            // 
            // textBox_stop_m
            // 
            this.textBox_stop_m.Location = new System.Drawing.Point(290, 4);
            this.textBox_stop_m.Name = "textBox_stop_m";
            this.textBox_stop_m.Size = new System.Drawing.Size(19, 20);
            this.textBox_stop_m.TabIndex = 80;
            this.textBox_stop_m.Text = "0";
            this.textBox_stop_m.TextChanged += new System.EventHandler(this.textBox_stop_m_TextChanged);
            // 
            // textBox_stop_h
            // 
            this.textBox_stop_h.Location = new System.Drawing.Point(263, 4);
            this.textBox_stop_h.Name = "textBox_stop_h";
            this.textBox_stop_h.Size = new System.Drawing.Size(19, 20);
            this.textBox_stop_h.TabIndex = 79;
            this.textBox_stop_h.Text = "0";
            this.textBox_stop_h.TextChanged += new System.EventHandler(this.textBox_stop_h_TextChanged);
            // 
            // label_stop_at_degree
            // 
            this.label_stop_at_degree.AutoSize = true;
            this.label_stop_at_degree.Location = new System.Drawing.Point(333, 7);
            this.label_stop_at_degree.Name = "label_stop_at_degree";
            this.label_stop_at_degree.Size = new System.Drawing.Size(43, 13);
            this.label_stop_at_degree.TabIndex = 83;
            this.label_stop_at_degree.Text = "heat to:";
            // 
            // textBox_stop_at_degree
            // 
            this.textBox_stop_at_degree.Location = new System.Drawing.Point(382, 2);
            this.textBox_stop_at_degree.Name = "textBox_stop_at_degree";
            this.textBox_stop_at_degree.Size = new System.Drawing.Size(31, 20);
            this.textBox_stop_at_degree.TabIndex = 84;
            this.textBox_stop_at_degree.Text = "0.0";
            this.textBox_stop_at_degree.TextChanged += new System.EventHandler(this.textBox_stop_at_degree_TextChanged);
            // 
            // label_timesem
            // 
            this.label_timesem.AutoSize = true;
            this.label_timesem.Location = new System.Drawing.Point(194, 7);
            this.label_timesem.Name = "label_timesem";
            this.label_timesem.Size = new System.Drawing.Size(10, 13);
            this.label_timesem.TabIndex = 85;
            this.label_timesem.Text = ":";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(281, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(10, 13);
            this.label1.TabIndex = 86;
            this.label1.Text = ":";
            // 
            // panel_ctrl_auto
            // 
            this.panel_ctrl_auto.Controls.Add(this.textBox_stop_at_degree);
            this.panel_ctrl_auto.Controls.Add(this.label_stop_at_degree);
            this.panel_ctrl_auto.Controls.Add(this.textBox_stop_m);
            this.panel_ctrl_auto.Controls.Add(this.textBox_stop_h);
            this.panel_ctrl_auto.Controls.Add(this.textBox_start_m);
            this.panel_ctrl_auto.Controls.Add(this.textBox_start_h);
            this.panel_ctrl_auto.Controls.Add(this.label_minutes_off);
            this.panel_ctrl_auto.Controls.Add(this.textBox_time_off);
            this.panel_ctrl_auto.Controls.Add(this.label_time_on);
            this.panel_ctrl_auto.Controls.Add(this.textBox_time_on);
            this.panel_ctrl_auto.Controls.Add(this.label_timesem);
            this.panel_ctrl_auto.Controls.Add(this.label_stop);
            this.panel_ctrl_auto.Controls.Add(this.label_start);
            this.panel_ctrl_auto.Controls.Add(this.label1);
            this.panel_ctrl_auto.Location = new System.Drawing.Point(332, -1);
            this.panel_ctrl_auto.Name = "panel_ctrl_auto";
            this.panel_ctrl_auto.Size = new System.Drawing.Size(422, 28);
            this.panel_ctrl_auto.TabIndex = 87;
            // 
            // radioButton_state_on
            // 
            this.radioButton_state_on.AutoSize = true;
            this.radioButton_state_on.Location = new System.Drawing.Point(111, 6);
            this.radioButton_state_on.Name = "radioButton_state_on";
            this.radioButton_state_on.Size = new System.Drawing.Size(41, 17);
            this.radioButton_state_on.TabIndex = 88;
            this.radioButton_state_on.TabStop = true;
            this.radioButton_state_on.Text = "ON";
            this.radioButton_state_on.UseVisualStyleBackColor = true;
            // 
            // label_remaining_time
            // 
            this.label_remaining_time.AutoSize = true;
            this.label_remaining_time.Location = new System.Drawing.Point(277, 8);
            this.label_remaining_time.Name = "label_remaining_time";
            this.label_remaining_time.Size = new System.Drawing.Size(22, 13);
            this.label_remaining_time.TabIndex = 87;
            this.label_remaining_time.Text = "xxx";
            // 
            // UC_heater
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDark;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.label_remaining_time);
            this.Controls.Add(this.radioButton_state_on);
            this.Controls.Add(this.panel_ctrl_auto);
            this.Controls.Add(this.checkBox_ctrl_on);
            this.Controls.Add(this.checkBox_ctrl_manuel);
            this.Controls.Add(this.label_name);
            this.Controls.Add(this.button_send);
            this.Name = "UC_heater";
            this.Size = new System.Drawing.Size(820, 28);
            this.panel_ctrl_auto.ResumeLayout(false);
            this.panel_ctrl_auto.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label_name;
        private System.Windows.Forms.Button button_send;
        private System.Windows.Forms.TextBox textBox_time_on;
        private System.Windows.Forms.CheckBox checkBox_ctrl_manuel;
        private System.Windows.Forms.CheckBox checkBox_ctrl_on;
        private System.Windows.Forms.Label label_time_on;
        private System.Windows.Forms.Label label_minutes_off;
        private System.Windows.Forms.TextBox textBox_time_off;
        private System.Windows.Forms.TextBox textBox_start_h;
        private System.Windows.Forms.TextBox textBox_start_m;
        private System.Windows.Forms.Label label_start;
        private System.Windows.Forms.Label label_stop;
        private System.Windows.Forms.TextBox textBox_stop_m;
        private System.Windows.Forms.TextBox textBox_stop_h;
        private System.Windows.Forms.Label label_stop_at_degree;
        private System.Windows.Forms.TextBox textBox_stop_at_degree;
        private System.Windows.Forms.Label label_timesem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel_ctrl_auto;
        private System.Windows.Forms.RadioButton radioButton_state_on;
        private System.Windows.Forms.Label label_remaining_time;
    }
}
