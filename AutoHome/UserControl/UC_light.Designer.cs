namespace AutoHome
{
    partial class UC_light
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
            this.checkBox_switch = new System.Windows.Forms.CheckBox();
            this.checkBox_light_enable_lux = new System.Windows.Forms.CheckBox();
            this.textBox_light_lux_off = new System.Windows.Forms.TextBox();
            this.checkBox_light_enable_timer = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox_light_time_s = new System.Windows.Forms.TextBox();
            this.textBox_light_time_m = new System.Windows.Forms.TextBox();
            this.textBox_light_time_h = new System.Windows.Forms.TextBox();
            this.button_set_param = new System.Windows.Forms.Button();
            this.button_switch_light = new System.Windows.Forms.Button();
            this.label_remaining_on = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label_name
            // 
            this.label_name.AutoSize = true;
            this.label_name.Location = new System.Drawing.Point(3, 2);
            this.label_name.Name = "label_name";
            this.label_name.Size = new System.Drawing.Size(68, 13);
            this.label_name.TabIndex = 0;
            this.label_name.Text = "control name";
            this.label_name.Click += new System.EventHandler(this.label_name_Click);
            // 
            // checkBox_switch
            // 
            this.checkBox_switch.AutoSize = true;
            this.checkBox_switch.Enabled = false;
            this.checkBox_switch.Location = new System.Drawing.Point(174, 3);
            this.checkBox_switch.Name = "checkBox_switch";
            this.checkBox_switch.Size = new System.Drawing.Size(42, 17);
            this.checkBox_switch.TabIndex = 1;
            this.checkBox_switch.Text = "ON";
            this.checkBox_switch.UseVisualStyleBackColor = true;
            this.checkBox_switch.CheckedChanged += new System.EventHandler(this.checkBox_switch_CheckedChanged);
            // 
            // checkBox_light_enable_lux
            // 
            this.checkBox_light_enable_lux.AutoSize = true;
            this.checkBox_light_enable_lux.Location = new System.Drawing.Point(381, 2);
            this.checkBox_light_enable_lux.Name = "checkBox_light_enable_lux";
            this.checkBox_light_enable_lux.Size = new System.Drawing.Size(62, 17);
            this.checkBox_light_enable_lux.TabIndex = 2;
            this.checkBox_light_enable_lux.Text = "off LUX";
            this.checkBox_light_enable_lux.UseVisualStyleBackColor = true;
            this.checkBox_light_enable_lux.CheckedChanged += new System.EventHandler(this.checkBox_light_enable_lux_CheckedChanged);
            // 
            // textBox_light_lux_off
            // 
            this.textBox_light_lux_off.Enabled = false;
            this.textBox_light_lux_off.Location = new System.Drawing.Point(449, 1);
            this.textBox_light_lux_off.Name = "textBox_light_lux_off";
            this.textBox_light_lux_off.Size = new System.Drawing.Size(34, 20);
            this.textBox_light_lux_off.TabIndex = 5;
            this.textBox_light_lux_off.TextChanged += new System.EventHandler(this.textBox_light_lux_off_TextChanged);
            // 
            // checkBox_light_enable_timer
            // 
            this.checkBox_light_enable_timer.AutoSize = true;
            this.checkBox_light_enable_timer.Location = new System.Drawing.Point(502, 4);
            this.checkBox_light_enable_timer.Name = "checkBox_light_enable_timer";
            this.checkBox_light_enable_timer.Size = new System.Drawing.Size(98, 17);
            this.checkBox_light_enable_timer.TabIndex = 6;
            this.checkBox_light_enable_timer.Text = "enable off timer";
            this.checkBox_light_enable_timer.UseVisualStyleBackColor = true;
            this.checkBox_light_enable_timer.CheckedChanged += new System.EventHandler(this.checkBox_light_enable_timer_CheckedChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(659, 4);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(10, 13);
            this.label3.TabIndex = 27;
            this.label3.Text = ":";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(627, 4);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(10, 13);
            this.label4.TabIndex = 26;
            this.label4.Text = ":";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // textBox_light_time_s
            // 
            this.textBox_light_time_s.Enabled = false;
            this.textBox_light_time_s.Location = new System.Drawing.Point(670, 1);
            this.textBox_light_time_s.Name = "textBox_light_time_s";
            this.textBox_light_time_s.Size = new System.Drawing.Size(20, 20);
            this.textBox_light_time_s.TabIndex = 25;
            this.textBox_light_time_s.TextChanged += new System.EventHandler(this.textBox_light_time_s_TextChanged);
            // 
            // textBox_light_time_m
            // 
            this.textBox_light_time_m.Enabled = false;
            this.textBox_light_time_m.Location = new System.Drawing.Point(638, 1);
            this.textBox_light_time_m.Name = "textBox_light_time_m";
            this.textBox_light_time_m.Size = new System.Drawing.Size(20, 20);
            this.textBox_light_time_m.TabIndex = 24;
            this.textBox_light_time_m.TextChanged += new System.EventHandler(this.textBox_light_time_m_TextChanged);
            // 
            // textBox_light_time_h
            // 
            this.textBox_light_time_h.Enabled = false;
            this.textBox_light_time_h.Location = new System.Drawing.Point(606, 1);
            this.textBox_light_time_h.Name = "textBox_light_time_h";
            this.textBox_light_time_h.Size = new System.Drawing.Size(20, 20);
            this.textBox_light_time_h.TabIndex = 22;
            this.textBox_light_time_h.TextChanged += new System.EventHandler(this.textBox_light_time_h_TextChanged);
            // 
            // button_set_param
            // 
            this.button_set_param.Location = new System.Drawing.Point(727, 1);
            this.button_set_param.Name = "button_set_param";
            this.button_set_param.Size = new System.Drawing.Size(64, 20);
            this.button_set_param.TabIndex = 28;
            this.button_set_param.Text = "set param";
            this.button_set_param.UseVisualStyleBackColor = true;
            this.button_set_param.Click += new System.EventHandler(this.button_set_param_Click);
            // 
            // button_switch_light
            // 
            this.button_switch_light.Location = new System.Drawing.Point(222, 1);
            this.button_switch_light.Name = "button_switch_light";
            this.button_switch_light.Size = new System.Drawing.Size(49, 20);
            this.button_switch_light.TabIndex = 29;
            this.button_switch_light.Text = "switch";
            this.button_switch_light.UseVisualStyleBackColor = true;
            this.button_switch_light.Click += new System.EventHandler(this.button_switch_light_Click);
            // 
            // label_remaining_on
            // 
            this.label_remaining_on.AutoSize = true;
            this.label_remaining_on.Location = new System.Drawing.Point(277, 5);
            this.label_remaining_on.Name = "label_remaining_on";
            this.label_remaining_on.Size = new System.Drawing.Size(81, 13);
            this.label_remaining_on.TabIndex = 30;
            this.label_remaining_on.Text = "remaining: xx:xx";
            // 
            // UC_light
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDark;
            this.Controls.Add(this.label_remaining_on);
            this.Controls.Add(this.button_switch_light);
            this.Controls.Add(this.button_set_param);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBox_light_time_s);
            this.Controls.Add(this.textBox_light_time_m);
            this.Controls.Add(this.textBox_light_time_h);
            this.Controls.Add(this.checkBox_light_enable_timer);
            this.Controls.Add(this.textBox_light_lux_off);
            this.Controls.Add(this.checkBox_light_enable_lux);
            this.Controls.Add(this.checkBox_switch);
            this.Controls.Add(this.label_name);
            this.Name = "UC_light";
            this.Size = new System.Drawing.Size(820, 22);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label_name;
        private System.Windows.Forms.CheckBox checkBox_switch;
        private System.Windows.Forms.CheckBox checkBox_light_enable_lux;
        private System.Windows.Forms.TextBox textBox_light_lux_off;
        private System.Windows.Forms.CheckBox checkBox_light_enable_timer;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox_light_time_s;
        private System.Windows.Forms.TextBox textBox_light_time_m;
        private System.Windows.Forms.TextBox textBox_light_time_h;
        private System.Windows.Forms.Button button_set_param;
        private System.Windows.Forms.Button button_switch_light;
        private System.Windows.Forms.Label label_remaining_on;
    }
}
