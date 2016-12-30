namespace AutoHome
{
    partial class UC_jalousie
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
            this.button_jal_drive_to = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox_angle = new System.Windows.Forms.TextBox();
            this.textBox_position = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label_name = new System.Windows.Forms.Label();
            this.button_open_event = new System.Windows.Forms.Button();
            this.comboBox_new_angle = new System.Windows.Forms.ComboBox();
            this.comboBox_new_position = new System.Windows.Forms.ComboBox();
            this.textBox_wind_go_up = new System.Windows.Forms.TextBox();
            this.button_set_wind_goup_speed = new System.Windows.Forms.Button();
            this.label_wind_speed = new System.Windows.Forms.Label();
            this.checkBox_init_motor = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // button_jal_drive_to
            // 
            this.button_jal_drive_to.Location = new System.Drawing.Point(512, 3);
            this.button_jal_drive_to.Name = "button_jal_drive_to";
            this.button_jal_drive_to.Size = new System.Drawing.Size(60, 23);
            this.button_jal_drive_to.TabIndex = 20;
            this.button_jal_drive_to.Text = "drive";
            this.button_jal_drive_to.UseVisualStyleBackColor = true;
            this.button_jal_drive_to.Visible = false;
            this.button_jal_drive_to.Click += new System.EventHandler(this.button_jal_drive_to_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(415, 8);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(25, 13);
            this.label3.TabIndex = 27;
            this.label3.Text = "==>";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(206, 8);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(25, 13);
            this.label4.TabIndex = 26;
            this.label4.Text = "==>";
            // 
            // textBox_angle
            // 
            this.textBox_angle.Enabled = false;
            this.textBox_angle.Location = new System.Drawing.Point(378, 4);
            this.textBox_angle.Name = "textBox_angle";
            this.textBox_angle.Size = new System.Drawing.Size(31, 20);
            this.textBox_angle.TabIndex = 25;
            // 
            // textBox_position
            // 
            this.textBox_position.Enabled = false;
            this.textBox_position.Location = new System.Drawing.Point(169, 4);
            this.textBox_position.Name = "textBox_position";
            this.textBox_position.Size = new System.Drawing.Size(31, 20);
            this.textBox_position.TabIndex = 24;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(339, 8);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(36, 13);
            this.label5.TabIndex = 23;
            this.label5.Text = "angle:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(120, 8);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(46, 13);
            this.label6.TabIndex = 22;
            this.label6.Text = "position:";
            // 
            // label_name
            // 
            this.label_name.AutoSize = true;
            this.label_name.Location = new System.Drawing.Point(12, 8);
            this.label_name.Name = "label_name";
            this.label_name.Size = new System.Drawing.Size(68, 13);
            this.label_name.TabIndex = 30;
            this.label_name.Text = "control name";
            // 
            // button_open_event
            // 
            this.button_open_event.Location = new System.Drawing.Point(799, 11);
            this.button_open_event.Name = "button_open_event";
            this.button_open_event.Size = new System.Drawing.Size(43, 23);
            this.button_open_event.TabIndex = 44;
            this.button_open_event.Text = "event";
            this.button_open_event.UseVisualStyleBackColor = true;
            this.button_open_event.Click += new System.EventHandler(this.button_open_event_Click);
            // 
            // comboBox_new_angle
            // 
            this.comboBox_new_angle.FormattingEnabled = true;
            this.comboBox_new_angle.Items.AddRange(new object[] {
            "0",
            "10",
            "30",
            "50",
            "70",
            "100"});
            this.comboBox_new_angle.Location = new System.Drawing.Point(446, 4);
            this.comboBox_new_angle.Name = "comboBox_new_angle";
            this.comboBox_new_angle.Size = new System.Drawing.Size(50, 21);
            this.comboBox_new_angle.TabIndex = 58;
            this.comboBox_new_angle.SelectedIndexChanged += new System.EventHandler(this.comboBox_new_angle_SelectedIndexChanged);
            // 
            // comboBox_new_position
            // 
            this.comboBox_new_position.FormattingEnabled = true;
            this.comboBox_new_position.Items.AddRange(new object[] {
            "0",
            "10",
            "30",
            "50",
            "70",
            "100"});
            this.comboBox_new_position.Location = new System.Drawing.Point(237, 4);
            this.comboBox_new_position.Name = "comboBox_new_position";
            this.comboBox_new_position.Size = new System.Drawing.Size(50, 21);
            this.comboBox_new_position.TabIndex = 57;
            this.comboBox_new_position.SelectedIndexChanged += new System.EventHandler(this.comboBox_new_position_SelectedIndexChanged);
            // 
            // textBox_wind_go_up
            // 
            this.textBox_wind_go_up.Location = new System.Drawing.Point(650, 4);
            this.textBox_wind_go_up.Name = "textBox_wind_go_up";
            this.textBox_wind_go_up.Size = new System.Drawing.Size(48, 20);
            this.textBox_wind_go_up.TabIndex = 59;
            this.textBox_wind_go_up.TextChanged += new System.EventHandler(this.textBox_wind_goup_TextChanged);
            // 
            // button_set_wind_goup_speed
            // 
            this.button_set_wind_goup_speed.Location = new System.Drawing.Point(604, 3);
            this.button_set_wind_goup_speed.Name = "button_set_wind_goup_speed";
            this.button_set_wind_goup_speed.Size = new System.Drawing.Size(40, 23);
            this.button_set_wind_goup_speed.TabIndex = 60;
            this.button_set_wind_goup_speed.Text = "save";
            this.button_set_wind_goup_speed.UseVisualStyleBackColor = true;
            this.button_set_wind_goup_speed.Visible = false;
            this.button_set_wind_goup_speed.Click += new System.EventHandler(this.button_set_wind_goup_speed_Click);
            // 
            // label_wind_speed
            // 
            this.label_wind_speed.AutoSize = true;
            this.label_wind_speed.Location = new System.Drawing.Point(699, 8);
            this.label_wind_speed.Name = "label_wind_speed";
            this.label_wind_speed.Size = new System.Drawing.Size(25, 13);
            this.label_wind_speed.TabIndex = 61;
            this.label_wind_speed.Text = "m/s";
            // 
            // checkBox_init_motor
            // 
            this.checkBox_init_motor.AutoSize = true;
            this.checkBox_init_motor.Location = new System.Drawing.Point(725, 7);
            this.checkBox_init_motor.Name = "checkBox_init_motor";
            this.checkBox_init_motor.Size = new System.Drawing.Size(68, 17);
            this.checkBox_init_motor.TabIndex = 62;
            this.checkBox_init_motor.Text = "init motor";
            this.checkBox_init_motor.UseVisualStyleBackColor = true;
            this.checkBox_init_motor.CheckedChanged += new System.EventHandler(this.checkBox_init_motor_CheckedChanged);
            // 
            // UC_jalousie
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDark;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.checkBox_init_motor);
            this.Controls.Add(this.label_wind_speed);
            this.Controls.Add(this.button_set_wind_goup_speed);
            this.Controls.Add(this.textBox_wind_go_up);
            this.Controls.Add(this.comboBox_new_angle);
            this.Controls.Add(this.comboBox_new_position);
            this.Controls.Add(this.button_open_event);
            this.Controls.Add(this.label_name);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.button_jal_drive_to);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBox_angle);
            this.Controls.Add(this.textBox_position);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label6);
            this.Enabled = false;
            this.Name = "UC_jalousie";
            this.Size = new System.Drawing.Size(841, 37);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button button_jal_drive_to;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox_angle;
        private System.Windows.Forms.TextBox textBox_position;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label_name;
        private System.Windows.Forms.Button button_open_event;
        private System.Windows.Forms.ComboBox comboBox_new_angle;
        private System.Windows.Forms.ComboBox comboBox_new_position;
        private System.Windows.Forms.TextBox textBox_wind_go_up;
        private System.Windows.Forms.Button button_set_wind_goup_speed;
        private System.Windows.Forms.Label label_wind_speed;
        private System.Windows.Forms.CheckBox checkBox_init_motor;
    }
}
