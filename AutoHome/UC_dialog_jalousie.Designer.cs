namespace AutoHome
{
    partial class UC_dialog_jalousie
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
            this.label_wind_speed = new System.Windows.Forms.Label();
            this.button_set_wind_goup_speed = new System.Windows.Forms.Button();
            this.textBox_wind_go_up = new System.Windows.Forms.TextBox();
            this.comboBox_new_angle = new System.Windows.Forms.ComboBox();
            this.comboBox_new_position = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.button_jal_drive_to = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox_angle = new System.Windows.Forms.TextBox();
            this.textBox_position = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.panel_event = new System.Windows.Forms.Panel();
            this.checkBox_initJalousie = new System.Windows.Forms.CheckBox();
            this.checkBox_EditLock = new System.Windows.Forms.CheckBox();
            this.panel_params = new System.Windows.Forms.Panel();
            this.button_drive_up = new System.Windows.Forms.Button();
            this.button_drive_down = new System.Windows.Forms.Button();
            this.panel_params.SuspendLayout();
            this.SuspendLayout();
            // 
            // label_wind_speed
            // 
            this.label_wind_speed.AutoSize = true;
            this.label_wind_speed.Location = new System.Drawing.Point(52, 10);
            this.label_wind_speed.Name = "label_wind_speed";
            this.label_wind_speed.Size = new System.Drawing.Size(25, 13);
            this.label_wind_speed.TabIndex = 75;
            this.label_wind_speed.Text = "m/s";
            // 
            // button_set_wind_goup_speed
            // 
            this.button_set_wind_goup_speed.Location = new System.Drawing.Point(87, 3);
            this.button_set_wind_goup_speed.Name = "button_set_wind_goup_speed";
            this.button_set_wind_goup_speed.Size = new System.Drawing.Size(40, 23);
            this.button_set_wind_goup_speed.TabIndex = 74;
            this.button_set_wind_goup_speed.Text = "save";
            this.button_set_wind_goup_speed.UseVisualStyleBackColor = true;
            this.button_set_wind_goup_speed.Visible = false;
            this.button_set_wind_goup_speed.Click += new System.EventHandler(this.button_set_wind_goup_speed_Click);
            // 
            // textBox_wind_go_up
            // 
            this.textBox_wind_go_up.Location = new System.Drawing.Point(3, 6);
            this.textBox_wind_go_up.Name = "textBox_wind_go_up";
            this.textBox_wind_go_up.Size = new System.Drawing.Size(48, 20);
            this.textBox_wind_go_up.TabIndex = 73;
            this.textBox_wind_go_up.TextChanged += new System.EventHandler(this.textBox_wind_go_up_TextChanged);
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
            this.comboBox_new_angle.Location = new System.Drawing.Point(137, 39);
            this.comboBox_new_angle.Name = "comboBox_new_angle";
            this.comboBox_new_angle.Size = new System.Drawing.Size(50, 21);
            this.comboBox_new_angle.TabIndex = 72;
            this.comboBox_new_angle.SelectedIndexChanged += new System.EventHandler(this.comboBox_new_angle_SelectedIndexChanged);
            this.comboBox_new_angle.TextChanged += new System.EventHandler(this.comboBox_new_angle_TextChanged);
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
            this.comboBox_new_position.Location = new System.Drawing.Point(137, 12);
            this.comboBox_new_position.Name = "comboBox_new_position";
            this.comboBox_new_position.Size = new System.Drawing.Size(50, 21);
            this.comboBox_new_position.TabIndex = 71;
            this.comboBox_new_position.SelectedIndexChanged += new System.EventHandler(this.comboBox_new_position_SelectedIndexChanged);
            this.comboBox_new_position.TextChanged += new System.EventHandler(this.comboBox_new_position_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(106, 43);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(25, 13);
            this.label3.TabIndex = 69;
            this.label3.Text = "==>";
            // 
            // button_jal_drive_to
            // 
            this.button_jal_drive_to.Location = new System.Drawing.Point(23, 71);
            this.button_jal_drive_to.Name = "button_jal_drive_to";
            this.button_jal_drive_to.Size = new System.Drawing.Size(164, 23);
            this.button_jal_drive_to.TabIndex = 62;
            this.button_jal_drive_to.Text = "drive";
            this.button_jal_drive_to.UseVisualStyleBackColor = true;
            this.button_jal_drive_to.Visible = false;
            this.button_jal_drive_to.Click += new System.EventHandler(this.button_jal_drive_to_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(106, 16);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(25, 13);
            this.label4.TabIndex = 68;
            this.label4.Text = "==>";
            // 
            // textBox_angle
            // 
            this.textBox_angle.Enabled = false;
            this.textBox_angle.Location = new System.Drawing.Point(69, 39);
            this.textBox_angle.Name = "textBox_angle";
            this.textBox_angle.Size = new System.Drawing.Size(31, 20);
            this.textBox_angle.TabIndex = 67;
            // 
            // textBox_position
            // 
            this.textBox_position.Enabled = false;
            this.textBox_position.Location = new System.Drawing.Point(69, 12);
            this.textBox_position.Name = "textBox_position";
            this.textBox_position.Size = new System.Drawing.Size(31, 20);
            this.textBox_position.TabIndex = 66;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(30, 43);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(36, 13);
            this.label5.TabIndex = 65;
            this.label5.Text = "angle:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(20, 16);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(46, 13);
            this.label6.TabIndex = 64;
            this.label6.Text = "position:";
            // 
            // panel_event
            // 
            this.panel_event.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel_event.Location = new System.Drawing.Point(196, 5);
            this.panel_event.Name = "panel_event";
            this.panel_event.Size = new System.Drawing.Size(494, 603);
            this.panel_event.TabIndex = 77;
            // 
            // checkBox_initJalousie
            // 
            this.checkBox_initJalousie.AutoSize = true;
            this.checkBox_initJalousie.Location = new System.Drawing.Point(6, 32);
            this.checkBox_initJalousie.Name = "checkBox_initJalousie";
            this.checkBox_initJalousie.Size = new System.Drawing.Size(113, 17);
            this.checkBox_initJalousie.TabIndex = 78;
            this.checkBox_initJalousie.Text = "init default position";
            this.checkBox_initJalousie.UseVisualStyleBackColor = true;
            // 
            // checkBox_EditLock
            // 
            this.checkBox_EditLock.AutoSize = true;
            this.checkBox_EditLock.Location = new System.Drawing.Point(23, 155);
            this.checkBox_EditLock.Name = "checkBox_EditLock";
            this.checkBox_EditLock.Size = new System.Drawing.Size(44, 17);
            this.checkBox_EditLock.TabIndex = 79;
            this.checkBox_EditLock.Text = "Edit";
            this.checkBox_EditLock.UseVisualStyleBackColor = true;
            this.checkBox_EditLock.CheckedChanged += new System.EventHandler(this.checkBox_EditLock_CheckedChanged);
            // 
            // panel_params
            // 
            this.panel_params.Controls.Add(this.checkBox_initJalousie);
            this.panel_params.Controls.Add(this.textBox_wind_go_up);
            this.panel_params.Controls.Add(this.button_set_wind_goup_speed);
            this.panel_params.Controls.Add(this.label_wind_speed);
            this.panel_params.Enabled = false;
            this.panel_params.Location = new System.Drawing.Point(23, 178);
            this.panel_params.Name = "panel_params";
            this.panel_params.Size = new System.Drawing.Size(154, 61);
            this.panel_params.TabIndex = 80;
            // 
            // button_drive_up
            // 
            this.button_drive_up.Location = new System.Drawing.Point(23, 100);
            this.button_drive_up.Name = "button_drive_up";
            this.button_drive_up.Size = new System.Drawing.Size(75, 23);
            this.button_drive_up.TabIndex = 81;
            this.button_drive_up.Text = "UP";
            this.button_drive_up.UseVisualStyleBackColor = true;
            this.button_drive_up.Click += new System.EventHandler(this.button_drive_up_Click);
            // 
            // button_drive_down
            // 
            this.button_drive_down.Location = new System.Drawing.Point(112, 100);
            this.button_drive_down.Name = "button_drive_down";
            this.button_drive_down.Size = new System.Drawing.Size(75, 23);
            this.button_drive_down.TabIndex = 82;
            this.button_drive_down.Text = "DOWN";
            this.button_drive_down.UseVisualStyleBackColor = true;
            this.button_drive_down.Click += new System.EventHandler(this.button_drive_down_Click);
            // 
            // UC_dialog_jalousie
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.button_drive_down);
            this.Controls.Add(this.button_drive_up);
            this.Controls.Add(this.panel_params);
            this.Controls.Add(this.checkBox_EditLock);
            this.Controls.Add(this.panel_event);
            this.Controls.Add(this.comboBox_new_angle);
            this.Controls.Add(this.comboBox_new_position);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.button_jal_drive_to);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBox_angle);
            this.Controls.Add(this.textBox_position);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label6);
            this.Name = "UC_dialog_jalousie";
            this.Size = new System.Drawing.Size(698, 646);
            this.panel_params.ResumeLayout(false);
            this.panel_params.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label_wind_speed;
        private System.Windows.Forms.Button button_set_wind_goup_speed;
        private System.Windows.Forms.TextBox textBox_wind_go_up;
        private System.Windows.Forms.ComboBox comboBox_new_angle;
        private System.Windows.Forms.ComboBox comboBox_new_position;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button_jal_drive_to;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox_angle;
        private System.Windows.Forms.TextBox textBox_position;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel panel_event;
        private System.Windows.Forms.CheckBox checkBox_initJalousie;
        private System.Windows.Forms.CheckBox checkBox_EditLock;
        private System.Windows.Forms.Panel panel_params;
        private System.Windows.Forms.Button button_drive_up;
        private System.Windows.Forms.Button button_drive_down;
    }
}
