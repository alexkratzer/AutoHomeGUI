﻿namespace AutoHome
{
    partial class UC_dialog_heater
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
            this.radioButton_state_on = new System.Windows.Forms.RadioButton();
            this.panel_ctrl_auto = new System.Windows.Forms.Panel();
            this.label_temp_ist = new System.Windows.Forms.Label();
            this.label_remaining_time = new System.Windows.Forms.Label();
            this.label_remaining_dsc = new System.Windows.Forms.Label();
            this.textBox_stop_at_degree = new System.Windows.Forms.TextBox();
            this.label_stop_at_degree = new System.Windows.Forms.Label();
            this.textBox_stop_m = new System.Windows.Forms.TextBox();
            this.textBox_stop_h = new System.Windows.Forms.TextBox();
            this.textBox_start_m = new System.Windows.Forms.TextBox();
            this.textBox_start_h = new System.Windows.Forms.TextBox();
            this.label_minutes_off = new System.Windows.Forms.Label();
            this.textBox_time_off = new System.Windows.Forms.TextBox();
            this.label_time_on = new System.Windows.Forms.Label();
            this.textBox_time_on = new System.Windows.Forms.TextBox();
            this.label_timesem = new System.Windows.Forms.Label();
            this.label_stop = new System.Windows.Forms.Label();
            this.label_start = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.checkBox_ctrl_on = new System.Windows.Forms.CheckBox();
            this.checkBox_ctrl_manuel = new System.Windows.Forms.CheckBox();
            this.button_send = new System.Windows.Forms.Button();
            this.checkBox_EditLock = new System.Windows.Forms.CheckBox();
            this.panel_edit = new System.Windows.Forms.Panel();
            this.panel_ctrl_auto.SuspendLayout();
            this.panel_edit.SuspendLayout();
            this.SuspendLayout();
            // 
            // radioButton_state_on
            // 
            this.radioButton_state_on.AutoSize = true;
            this.radioButton_state_on.Location = new System.Drawing.Point(3, 3);
            this.radioButton_state_on.Name = "radioButton_state_on";
            this.radioButton_state_on.Size = new System.Drawing.Size(41, 17);
            this.radioButton_state_on.TabIndex = 94;
            this.radioButton_state_on.TabStop = true;
            this.radioButton_state_on.Text = "ON";
            this.radioButton_state_on.UseVisualStyleBackColor = true;
            // 
            // panel_ctrl_auto
            // 
            this.panel_ctrl_auto.Controls.Add(this.label_temp_ist);
            this.panel_ctrl_auto.Controls.Add(this.label_remaining_time);
            this.panel_ctrl_auto.Controls.Add(this.label_remaining_dsc);
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
            this.panel_ctrl_auto.Location = new System.Drawing.Point(3, 28);
            this.panel_ctrl_auto.Name = "panel_ctrl_auto";
            this.panel_ctrl_auto.Size = new System.Drawing.Size(163, 109);
            this.panel_ctrl_auto.TabIndex = 93;
            // 
            // label_temp_ist
            // 
            this.label_temp_ist.AutoSize = true;
            this.label_temp_ist.Location = new System.Drawing.Point(90, 78);
            this.label_temp_ist.Name = "label_temp_ist";
            this.label_temp_ist.Size = new System.Drawing.Size(60, 13);
            this.label_temp_ist.TabIndex = 89;
            this.label_temp_ist.Text = "temperatur:";
            // 
            // label_remaining_time
            // 
            this.label_remaining_time.AutoSize = true;
            this.label_remaining_time.Location = new System.Drawing.Point(78, 58);
            this.label_remaining_time.Name = "label_remaining_time";
            this.label_remaining_time.Size = new System.Drawing.Size(22, 13);
            this.label_remaining_time.TabIndex = 88;
            this.label_remaining_time.Text = "xxx";
            // 
            // label_remaining_dsc
            // 
            this.label_remaining_dsc.AutoSize = true;
            this.label_remaining_dsc.Location = new System.Drawing.Point(6, 58);
            this.label_remaining_dsc.Name = "label_remaining_dsc";
            this.label_remaining_dsc.Size = new System.Drawing.Size(66, 13);
            this.label_remaining_dsc.TabIndex = 87;
            this.label_remaining_dsc.Text = "time in state:";
            // 
            // textBox_stop_at_degree
            // 
            this.textBox_stop_at_degree.Location = new System.Drawing.Point(45, 78);
            this.textBox_stop_at_degree.Name = "textBox_stop_at_degree";
            this.textBox_stop_at_degree.Size = new System.Drawing.Size(31, 20);
            this.textBox_stop_at_degree.TabIndex = 84;
            this.textBox_stop_at_degree.Text = "0.0";
            this.textBox_stop_at_degree.TextChanged += new System.EventHandler(this.textBox_stop_at_degree_TextChanged);
            // 
            // label_stop_at_degree
            // 
            this.label_stop_at_degree.AutoSize = true;
            this.label_stop_at_degree.Location = new System.Drawing.Point(1, 81);
            this.label_stop_at_degree.Name = "label_stop_at_degree";
            this.label_stop_at_degree.Size = new System.Drawing.Size(43, 13);
            this.label_stop_at_degree.TabIndex = 83;
            this.label_stop_at_degree.Text = "heat to:";
            // 
            // textBox_stop_m
            // 
            this.textBox_stop_m.Location = new System.Drawing.Point(131, 31);
            this.textBox_stop_m.Name = "textBox_stop_m";
            this.textBox_stop_m.Size = new System.Drawing.Size(19, 20);
            this.textBox_stop_m.TabIndex = 80;
            this.textBox_stop_m.Text = "0";
            this.textBox_stop_m.TextChanged += new System.EventHandler(this.textBox_stop_m_TextChanged);
            // 
            // textBox_stop_h
            // 
            this.textBox_stop_h.Location = new System.Drawing.Point(106, 31);
            this.textBox_stop_h.Name = "textBox_stop_h";
            this.textBox_stop_h.Size = new System.Drawing.Size(19, 20);
            this.textBox_stop_h.TabIndex = 79;
            this.textBox_stop_h.Text = "0";
            this.textBox_stop_h.TextChanged += new System.EventHandler(this.textBox_stop_h_TextChanged);
            // 
            // textBox_start_m
            // 
            this.textBox_start_m.Location = new System.Drawing.Point(56, 31);
            this.textBox_start_m.Name = "textBox_start_m";
            this.textBox_start_m.Size = new System.Drawing.Size(19, 20);
            this.textBox_start_m.TabIndex = 76;
            this.textBox_start_m.Text = "0";
            this.textBox_start_m.TextChanged += new System.EventHandler(this.textBox_start_m_TextChanged);
            // 
            // textBox_start_h
            // 
            this.textBox_start_h.Location = new System.Drawing.Point(31, 31);
            this.textBox_start_h.Name = "textBox_start_h";
            this.textBox_start_h.Size = new System.Drawing.Size(19, 20);
            this.textBox_start_h.TabIndex = 75;
            this.textBox_start_h.Text = "0";
            this.textBox_start_h.TextChanged += new System.EventHandler(this.textBox_start_h_TextChanged);
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
            // label_time_on
            // 
            this.label_time_on.AutoSize = true;
            this.label_time_on.Location = new System.Drawing.Point(1, 7);
            this.label_time_on.Name = "label_time_on";
            this.label_time_on.Size = new System.Drawing.Size(61, 13);
            this.label_time_on.TabIndex = 72;
            this.label_time_on.Text = "minutes on:";
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
            // label_timesem
            // 
            this.label_timesem.AutoSize = true;
            this.label_timesem.Location = new System.Drawing.Point(48, 34);
            this.label_timesem.Name = "label_timesem";
            this.label_timesem.Size = new System.Drawing.Size(10, 13);
            this.label_timesem.TabIndex = 85;
            this.label_timesem.Text = ":";
            // 
            // label_stop
            // 
            this.label_stop.AutoSize = true;
            this.label_stop.Location = new System.Drawing.Point(78, 34);
            this.label_stop.Name = "label_stop";
            this.label_stop.Size = new System.Drawing.Size(30, 13);
            this.label_stop.TabIndex = 82;
            this.label_stop.Text = "stop:";
            // 
            // label_start
            // 
            this.label_start.AutoSize = true;
            this.label_start.Location = new System.Drawing.Point(3, 34);
            this.label_start.Name = "label_start";
            this.label_start.Size = new System.Drawing.Size(30, 13);
            this.label_start.TabIndex = 78;
            this.label_start.Text = "start:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(124, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(10, 13);
            this.label1.TabIndex = 86;
            this.label1.Text = ":";
            // 
            // checkBox_ctrl_on
            // 
            this.checkBox_ctrl_on.AutoSize = true;
            this.checkBox_ctrl_on.Enabled = false;
            this.checkBox_ctrl_on.Location = new System.Drawing.Point(107, 6);
            this.checkBox_ctrl_on.Name = "checkBox_ctrl_on";
            this.checkBox_ctrl_on.Size = new System.Drawing.Size(59, 17);
            this.checkBox_ctrl_on.TabIndex = 92;
            this.checkBox_ctrl_on.Text = "turn on";
            this.checkBox_ctrl_on.UseVisualStyleBackColor = true;
            this.checkBox_ctrl_on.CheckedChanged += new System.EventHandler(this.checkBox_ctrl_on_CheckedChanged);
            // 
            // checkBox_ctrl_manuel
            // 
            this.checkBox_ctrl_manuel.AutoSize = true;
            this.checkBox_ctrl_manuel.Location = new System.Drawing.Point(3, 6);
            this.checkBox_ctrl_manuel.Name = "checkBox_ctrl_manuel";
            this.checkBox_ctrl_manuel.Size = new System.Drawing.Size(61, 17);
            this.checkBox_ctrl_manuel.TabIndex = 91;
            this.checkBox_ctrl_manuel.Text = "ctr man";
            this.checkBox_ctrl_manuel.UseVisualStyleBackColor = true;
            this.checkBox_ctrl_manuel.CheckedChanged += new System.EventHandler(this.checkBox_ctrl_manuel_CheckedChanged);
            // 
            // button_send
            // 
            this.button_send.Location = new System.Drawing.Point(1, 139);
            this.button_send.Name = "button_send";
            this.button_send.Size = new System.Drawing.Size(165, 23);
            this.button_send.TabIndex = 89;
            this.button_send.Text = "send";
            this.button_send.UseVisualStyleBackColor = true;
            this.button_send.Visible = false;
            this.button_send.Click += new System.EventHandler(this.button_send_Click);
            // 
            // checkBox_EditLock
            // 
            this.checkBox_EditLock.AutoSize = true;
            this.checkBox_EditLock.Location = new System.Drawing.Point(127, 3);
            this.checkBox_EditLock.Name = "checkBox_EditLock";
            this.checkBox_EditLock.Size = new System.Drawing.Size(44, 17);
            this.checkBox_EditLock.TabIndex = 95;
            this.checkBox_EditLock.Text = "Edit";
            this.checkBox_EditLock.UseVisualStyleBackColor = true;
            this.checkBox_EditLock.CheckedChanged += new System.EventHandler(this.checkBox_EditLock_CheckedChanged);
            // 
            // panel_edit
            // 
            this.panel_edit.Controls.Add(this.panel_ctrl_auto);
            this.panel_edit.Controls.Add(this.button_send);
            this.panel_edit.Controls.Add(this.checkBox_ctrl_manuel);
            this.panel_edit.Controls.Add(this.checkBox_ctrl_on);
            this.panel_edit.Enabled = false;
            this.panel_edit.Location = new System.Drawing.Point(0, 23);
            this.panel_edit.Name = "panel_edit";
            this.panel_edit.Size = new System.Drawing.Size(171, 168);
            this.panel_edit.TabIndex = 96;
            // 
            // UC_dialog_heater
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel_edit);
            this.Controls.Add(this.checkBox_EditLock);
            this.Controls.Add(this.radioButton_state_on);
            this.Name = "UC_dialog_heater";
            this.Size = new System.Drawing.Size(175, 196);
            this.panel_ctrl_auto.ResumeLayout(false);
            this.panel_ctrl_auto.PerformLayout();
            this.panel_edit.ResumeLayout(false);
            this.panel_edit.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton radioButton_state_on;
        private System.Windows.Forms.Panel panel_ctrl_auto;
        private System.Windows.Forms.TextBox textBox_stop_at_degree;
        private System.Windows.Forms.Label label_stop_at_degree;
        private System.Windows.Forms.TextBox textBox_stop_m;
        private System.Windows.Forms.TextBox textBox_stop_h;
        private System.Windows.Forms.TextBox textBox_start_m;
        private System.Windows.Forms.TextBox textBox_start_h;
        private System.Windows.Forms.Label label_minutes_off;
        private System.Windows.Forms.TextBox textBox_time_off;
        private System.Windows.Forms.Label label_time_on;
        private System.Windows.Forms.TextBox textBox_time_on;
        private System.Windows.Forms.Label label_timesem;
        private System.Windows.Forms.Label label_stop;
        private System.Windows.Forms.Label label_start;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox checkBox_ctrl_on;
        private System.Windows.Forms.CheckBox checkBox_ctrl_manuel;
        private System.Windows.Forms.Button button_send;
        private System.Windows.Forms.Label label_remaining_time;
        private System.Windows.Forms.Label label_remaining_dsc;
        private System.Windows.Forms.Label label_temp_ist;
        private System.Windows.Forms.CheckBox checkBox_EditLock;
        private System.Windows.Forms.Panel panel_edit;
    }
}
