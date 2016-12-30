namespace AutoHome
{
    partial class UC_dialog_light
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.button_switch_on = new System.Windows.Forms.Button();
            this.button_switch_off = new System.Windows.Forms.Button();
            this.button_set_param = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox_light_time_s = new System.Windows.Forms.TextBox();
            this.textBox_light_time_m = new System.Windows.Forms.TextBox();
            this.textBox_light_time_h = new System.Windows.Forms.TextBox();
            this.checkBox_light_enable_timer = new System.Windows.Forms.CheckBox();
            this.textBox_light_lux_off = new System.Windows.Forms.TextBox();
            this.label_light_lux = new System.Windows.Forms.Label();
            this.checkBox_light_enable_lux = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label_remaining_on_desc = new System.Windows.Forms.Label();
            this.label_remaining_on = new System.Windows.Forms.Label();
            this.label_current_state = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button_switch_on
            // 
            this.button_switch_on.Location = new System.Drawing.Point(6, 16);
            this.button_switch_on.Name = "button_switch_on";
            this.button_switch_on.Size = new System.Drawing.Size(41, 23);
            this.button_switch_on.TabIndex = 0;
            this.button_switch_on.Text = "on";
            this.button_switch_on.UseVisualStyleBackColor = true;
            this.button_switch_on.Click += new System.EventHandler(this.button_switch_Click);
            // 
            // button_switch_off
            // 
            this.button_switch_off.Location = new System.Drawing.Point(53, 16);
            this.button_switch_off.Name = "button_switch_off";
            this.button_switch_off.Size = new System.Drawing.Size(41, 23);
            this.button_switch_off.TabIndex = 1;
            this.button_switch_off.Text = "off";
            this.button_switch_off.UseVisualStyleBackColor = true;
            this.button_switch_off.Click += new System.EventHandler(this.button_switch_off_Click);
            // 
            // button_set_param
            // 
            this.button_set_param.Location = new System.Drawing.Point(3, 102);
            this.button_set_param.Name = "button_set_param";
            this.button_set_param.Size = new System.Drawing.Size(64, 20);
            this.button_set_param.TabIndex = 41;
            this.button_set_param.Text = "set param";
            this.button_set_param.UseVisualStyleBackColor = true;
            this.button_set_param.Click += new System.EventHandler(this.button_set_param_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(163, 77);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(10, 13);
            this.label3.TabIndex = 40;
            this.label3.Text = ":";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(131, 77);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(10, 13);
            this.label4.TabIndex = 39;
            this.label4.Text = ":";
            // 
            // textBox_light_time_s
            // 
            this.textBox_light_time_s.Enabled = false;
            this.textBox_light_time_s.Location = new System.Drawing.Point(174, 74);
            this.textBox_light_time_s.Name = "textBox_light_time_s";
            this.textBox_light_time_s.Size = new System.Drawing.Size(20, 20);
            this.textBox_light_time_s.TabIndex = 38;
            // 
            // textBox_light_time_m
            // 
            this.textBox_light_time_m.Enabled = false;
            this.textBox_light_time_m.Location = new System.Drawing.Point(142, 74);
            this.textBox_light_time_m.Name = "textBox_light_time_m";
            this.textBox_light_time_m.Size = new System.Drawing.Size(20, 20);
            this.textBox_light_time_m.TabIndex = 37;
            // 
            // textBox_light_time_h
            // 
            this.textBox_light_time_h.Enabled = false;
            this.textBox_light_time_h.Location = new System.Drawing.Point(110, 74);
            this.textBox_light_time_h.Name = "textBox_light_time_h";
            this.textBox_light_time_h.Size = new System.Drawing.Size(20, 20);
            this.textBox_light_time_h.TabIndex = 36;
            // 
            // checkBox_light_enable_timer
            // 
            this.checkBox_light_enable_timer.AutoSize = true;
            this.checkBox_light_enable_timer.Location = new System.Drawing.Point(6, 77);
            this.checkBox_light_enable_timer.Name = "checkBox_light_enable_timer";
            this.checkBox_light_enable_timer.Size = new System.Drawing.Size(98, 17);
            this.checkBox_light_enable_timer.TabIndex = 35;
            this.checkBox_light_enable_timer.Text = "enable off timer";
            this.checkBox_light_enable_timer.UseVisualStyleBackColor = true;
            this.checkBox_light_enable_timer.CheckedChanged += new System.EventHandler(this.checkBox_light_enable_timer_CheckedChanged);
            // 
            // textBox_light_lux_off
            // 
            this.textBox_light_lux_off.Enabled = false;
            this.textBox_light_lux_off.Location = new System.Drawing.Point(147, 45);
            this.textBox_light_lux_off.Name = "textBox_light_lux_off";
            this.textBox_light_lux_off.Size = new System.Drawing.Size(26, 20);
            this.textBox_light_lux_off.TabIndex = 34;
            // 
            // label_light_lux
            // 
            this.label_light_lux.AutoSize = true;
            this.label_light_lux.Location = new System.Drawing.Point(91, 48);
            this.label_light_lux.Name = "label_light_lux";
            this.label_light_lux.Size = new System.Drawing.Size(50, 13);
            this.label_light_lux.TabIndex = 33;
            this.label_light_lux.Text = "off at lux:";
            // 
            // checkBox_light_enable_lux
            // 
            this.checkBox_light_enable_lux.AutoSize = true;
            this.checkBox_light_enable_lux.Location = new System.Drawing.Point(6, 45);
            this.checkBox_light_enable_lux.Name = "checkBox_light_enable_lux";
            this.checkBox_light_enable_lux.Size = new System.Drawing.Size(74, 17);
            this.checkBox_light_enable_lux.TabIndex = 32;
            this.checkBox_light_enable_lux.Text = "enable lux";
            this.checkBox_light_enable_lux.UseVisualStyleBackColor = true;
            this.checkBox_light_enable_lux.CheckedChanged += new System.EventHandler(this.checkBox_light_enable_lux_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 125);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 42;
            this.label1.Text = "label1";
            // 
            // label_remaining_on_desc
            // 
            this.label_remaining_on_desc.AutoSize = true;
            this.label_remaining_on_desc.Location = new System.Drawing.Point(75, 106);
            this.label_remaining_on_desc.Name = "label_remaining_on_desc";
            this.label_remaining_on_desc.Size = new System.Drawing.Size(55, 13);
            this.label_remaining_on_desc.TabIndex = 43;
            this.label_remaining_on_desc.Text = "remaining:";
            // 
            // label_remaining_on
            // 
            this.label_remaining_on.AutoSize = true;
            this.label_remaining_on.Location = new System.Drawing.Point(141, 106);
            this.label_remaining_on.Name = "label_remaining_on";
            this.label_remaining_on.Size = new System.Drawing.Size(22, 13);
            this.label_remaining_on.TabIndex = 44;
            this.label_remaining_on.Text = "xxx";
            // 
            // label_current_state
            // 
            this.label_current_state.AutoSize = true;
            this.label_current_state.Location = new System.Drawing.Point(3, 0);
            this.label_current_state.Name = "label_current_state";
            this.label_current_state.Size = new System.Drawing.Size(36, 13);
            this.label_current_state.TabIndex = 45;
            this.label_current_state.Text = "state: ";
            // 
            // UC_dialog_light
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label_current_state);
            this.Controls.Add(this.label_remaining_on);
            this.Controls.Add(this.label_remaining_on_desc);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button_set_param);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBox_light_time_s);
            this.Controls.Add(this.textBox_light_time_m);
            this.Controls.Add(this.textBox_light_time_h);
            this.Controls.Add(this.checkBox_light_enable_timer);
            this.Controls.Add(this.textBox_light_lux_off);
            this.Controls.Add(this.label_light_lux);
            this.Controls.Add(this.checkBox_light_enable_lux);
            this.Controls.Add(this.button_switch_off);
            this.Controls.Add(this.button_switch_on);
            this.Name = "UC_dialog_light";
            this.Size = new System.Drawing.Size(208, 143);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_switch_on;
        private System.Windows.Forms.Button button_switch_off;
        private System.Windows.Forms.Button button_set_param;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox_light_time_s;
        private System.Windows.Forms.TextBox textBox_light_time_m;
        private System.Windows.Forms.TextBox textBox_light_time_h;
        private System.Windows.Forms.CheckBox checkBox_light_enable_timer;
        private System.Windows.Forms.TextBox textBox_light_lux_off;
        private System.Windows.Forms.Label label_light_lux;
        private System.Windows.Forms.CheckBox checkBox_light_enable_lux;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label_remaining_on_desc;
        private System.Windows.Forms.Label label_remaining_on;
        private System.Windows.Forms.Label label_current_state;
    }
}
