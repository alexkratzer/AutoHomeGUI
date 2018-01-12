namespace AutoHome
{
    partial class FrmParam
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
            this.panel_edit_plc = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.button_save_plc = new System.Windows.Forms.Button();
            this.button_plc_delete = new System.Windows.Forms.Button();
            this.textBox_plc_name = new System.Windows.Forms.TextBox();
            this.label_plc_name = new System.Windows.Forms.Label();
            this.textBox_plc_port_hex = new System.Windows.Forms.TextBox();
            this.textBox_plc_port = new System.Windows.Forms.TextBox();
            this.label_plc_port = new System.Windows.Forms.Label();
            this.textBox_plcip = new System.Windows.Forms.TextBox();
            this.label_s7ip_OG = new System.Windows.Forms.Label();
            this.label_timer_send = new System.Windows.Forms.Label();
            this.textBox_timer_refresh_interval = new System.Windows.Forms.TextBox();
            this.label_timer_send_ms = new System.Windows.Forms.Label();
            this.checkBox_display_exception = new System.Windows.Forms.CheckBox();
            this.checkBox_connect_at_start = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox_timer_log_interval = new System.Windows.Forms.TextBox();
            this.label_timer_log = new System.Windows.Forms.Label();
            this.checkBox_expert_mode = new System.Windows.Forms.CheckBox();
            this.panel_expert = new System.Windows.Forms.Panel();
            this.button_save_changes = new System.Windows.Forms.Button();
            this.label_WatchdagTime = new System.Windows.Forms.Label();
            this.textBox_WatchdagTime = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox_timer_refresh_controls_interval = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.checkBox_start_timers_at_startup = new System.Windows.Forms.CheckBox();
            this.textBox_connect_error_retrys = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.linkLabel_default_project_path = new System.Windows.Forms.LinkLabel();
            this.checkBox_plc_mode_hold_connection = new System.Windows.Forms.CheckBox();
            this.listBox_aktors = new System.Windows.Forms.ListBox();
            this.panel_edit_aktuator = new System.Windows.Forms.Panel();
            this.button_save_actuator = new System.Windows.Forms.Button();
            this.comboBox_edit_plc = new System.Windows.Forms.ComboBox();
            this.button_edit_delete = new System.Windows.Forms.Button();
            this.comboBox_edit_type = new System.Windows.Forms.ComboBox();
            this.textBox_edit_name = new System.Windows.Forms.TextBox();
            this.textBox_akt_id = new System.Windows.Forms.TextBox();
            this.checkBox_add_new_aktuator = new System.Windows.Forms.CheckBox();
            this.groupBox_aktors = new System.Windows.Forms.GroupBox();
            this.checkBox_plc = new System.Windows.Forms.CheckBox();
            this.checkBox_aktorType = new System.Windows.Forms.CheckBox();
            this.comboBox_listPlc = new System.Windows.Forms.ComboBox();
            this.comboBox_aktorType = new System.Windows.Forms.ComboBox();
            this.groupBox_plc = new System.Windows.Forms.GroupBox();
            this.checkBox_add_new_plc = new System.Windows.Forms.CheckBox();
            this.listBox_plc = new System.Windows.Forms.ListBox();
            this.panel_edit = new System.Windows.Forms.Panel();
            this.checkBoxFooterShowPlcTime = new System.Windows.Forms.CheckBox();
            this.groupBox_DB = new System.Windows.Forms.GroupBox();
            this.textBox_DBPwd = new System.Windows.Forms.TextBox();
            this.textBox_DBUid = new System.Windows.Forms.TextBox();
            this.textBox_DBName = new System.Windows.Forms.TextBox();
            this.textBox_DBServerIP = new System.Windows.Forms.TextBox();
            this.label_DBPwd = new System.Windows.Forms.Label();
            this.label_DBUid = new System.Windows.Forms.Label();
            this.label_DBName = new System.Windows.Forms.Label();
            this.label_DBServerIP = new System.Windows.Forms.Label();
            this.groupBox_cps_settings = new System.Windows.Forms.GroupBox();
            this.checkBox_CpsNet_FrmStatusLog = new System.Windows.Forms.CheckBox();
            this.textBox_MngData_AcceptedClockDelay = new System.Windows.Forms.TextBox();
            this.label_MngData_AcceptedClockDelay = new System.Windows.Forms.Label();
            this.label_cps_server_port = new System.Windows.Forms.Label();
            this.textBox_cpsServerPort = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel_edit_plc.SuspendLayout();
            this.panel_expert.SuspendLayout();
            this.panel_edit_aktuator.SuspendLayout();
            this.groupBox_aktors.SuspendLayout();
            this.groupBox_plc.SuspendLayout();
            this.panel_edit.SuspendLayout();
            this.groupBox_DB.SuspendLayout();
            this.groupBox_cps_settings.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel_edit_plc
            // 
            this.panel_edit_plc.Controls.Add(this.label5);
            this.panel_edit_plc.Controls.Add(this.button_save_plc);
            this.panel_edit_plc.Controls.Add(this.button_plc_delete);
            this.panel_edit_plc.Controls.Add(this.textBox_plc_name);
            this.panel_edit_plc.Controls.Add(this.label_plc_name);
            this.panel_edit_plc.Controls.Add(this.textBox_plc_port_hex);
            this.panel_edit_plc.Controls.Add(this.textBox_plc_port);
            this.panel_edit_plc.Controls.Add(this.label_plc_port);
            this.panel_edit_plc.Controls.Add(this.textBox_plcip);
            this.panel_edit_plc.Controls.Add(this.label_s7ip_OG);
            this.panel_edit_plc.Location = new System.Drawing.Point(174, 19);
            this.panel_edit_plc.Name = "panel_edit_plc";
            this.panel_edit_plc.Size = new System.Drawing.Size(174, 114);
            this.panel_edit_plc.TabIndex = 2;
            this.panel_edit_plc.Visible = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(70, 47);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(104, 13);
            this.label5.TabIndex = 32;
            this.label5.Text = "TCP2500/UDP2202";
            // 
            // button_save_plc
            // 
            this.button_save_plc.Location = new System.Drawing.Point(7, 82);
            this.button_save_plc.Name = "button_save_plc";
            this.button_save_plc.Size = new System.Drawing.Size(75, 23);
            this.button_save_plc.TabIndex = 31;
            this.button_save_plc.Text = "save";
            this.button_save_plc.UseVisualStyleBackColor = true;
            this.button_save_plc.Click += new System.EventHandler(this.button_save_plc_Click);
            // 
            // button_plc_delete
            // 
            this.button_plc_delete.Location = new System.Drawing.Point(88, 82);
            this.button_plc_delete.Name = "button_plc_delete";
            this.button_plc_delete.Size = new System.Drawing.Size(75, 23);
            this.button_plc_delete.TabIndex = 18;
            this.button_plc_delete.Text = "delete";
            this.button_plc_delete.UseVisualStyleBackColor = true;
            this.button_plc_delete.Click += new System.EventHandler(this.button_plc_delete_Click);
            // 
            // textBox_plc_name
            // 
            this.textBox_plc_name.Location = new System.Drawing.Point(69, 3);
            this.textBox_plc_name.Name = "textBox_plc_name";
            this.textBox_plc_name.Size = new System.Drawing.Size(88, 20);
            this.textBox_plc_name.TabIndex = 30;
            // 
            // label_plc_name
            // 
            this.label_plc_name.AutoSize = true;
            this.label_plc_name.Location = new System.Drawing.Point(4, 4);
            this.label_plc_name.Name = "label_plc_name";
            this.label_plc_name.Size = new System.Drawing.Size(59, 13);
            this.label_plc_name.TabIndex = 29;
            this.label_plc_name.Text = "PLC name:";
            // 
            // textBox_plc_port_hex
            // 
            this.textBox_plc_port_hex.Enabled = false;
            this.textBox_plc_port_hex.Location = new System.Drawing.Point(114, 56);
            this.textBox_plc_port_hex.Name = "textBox_plc_port_hex";
            this.textBox_plc_port_hex.Size = new System.Drawing.Size(43, 20);
            this.textBox_plc_port_hex.TabIndex = 8;
            // 
            // textBox_plc_port
            // 
            this.textBox_plc_port.Location = new System.Drawing.Point(67, 56);
            this.textBox_plc_port.Name = "textBox_plc_port";
            this.textBox_plc_port.Size = new System.Drawing.Size(43, 20);
            this.textBox_plc_port.TabIndex = 7;
            this.textBox_plc_port.TextChanged += new System.EventHandler(this.textBox_plc_port_TextChanged);
            // 
            // label_plc_port
            // 
            this.label_plc_port.AutoSize = true;
            this.label_plc_port.Location = new System.Drawing.Point(4, 58);
            this.label_plc_port.Name = "label_plc_port";
            this.label_plc_port.Size = new System.Drawing.Size(52, 13);
            this.label_plc_port.TabIndex = 6;
            this.label_plc_port.Text = "PLC Port:";
            // 
            // textBox_plcip
            // 
            this.textBox_plcip.Location = new System.Drawing.Point(69, 30);
            this.textBox_plcip.Name = "textBox_plcip";
            this.textBox_plcip.Size = new System.Drawing.Size(88, 20);
            this.textBox_plcip.TabIndex = 5;
            this.textBox_plcip.TextChanged += new System.EventHandler(this.textBox_plcOGip_TextChanged);
            // 
            // label_s7ip_OG
            // 
            this.label_s7ip_OG.AutoSize = true;
            this.label_s7ip_OG.Location = new System.Drawing.Point(4, 33);
            this.label_s7ip_OG.Name = "label_s7ip_OG";
            this.label_s7ip_OG.Size = new System.Drawing.Size(43, 13);
            this.label_s7ip_OG.TabIndex = 4;
            this.label_s7ip_OG.Text = "PLC IP:";
            // 
            // label_timer_send
            // 
            this.label_timer_send.AutoSize = true;
            this.label_timer_send.Location = new System.Drawing.Point(7, 6);
            this.label_timer_send.Name = "label_timer_send";
            this.label_timer_send.Size = new System.Drawing.Size(161, 13);
            this.label_timer_send.TabIndex = 3;
            this.label_timer_send.Text = "interval footer connection status:";
            // 
            // textBox_timer_refresh_interval
            // 
            this.textBox_timer_refresh_interval.Location = new System.Drawing.Point(187, 3);
            this.textBox_timer_refresh_interval.Name = "textBox_timer_refresh_interval";
            this.textBox_timer_refresh_interval.Size = new System.Drawing.Size(39, 20);
            this.textBox_timer_refresh_interval.TabIndex = 4;
            this.textBox_timer_refresh_interval.TextChanged += new System.EventHandler(this.textBox_timer_send_intervall_TextChanged);
            // 
            // label_timer_send_ms
            // 
            this.label_timer_send_ms.AutoSize = true;
            this.label_timer_send_ms.Location = new System.Drawing.Point(232, 6);
            this.label_timer_send_ms.Name = "label_timer_send_ms";
            this.label_timer_send_ms.Size = new System.Drawing.Size(20, 13);
            this.label_timer_send_ms.TabIndex = 5;
            this.label_timer_send_ms.Text = "ms";
            // 
            // checkBox_display_exception
            // 
            this.checkBox_display_exception.AutoSize = true;
            this.checkBox_display_exception.Location = new System.Drawing.Point(10, 87);
            this.checkBox_display_exception.Name = "checkBox_display_exception";
            this.checkBox_display_exception.Size = new System.Drawing.Size(107, 17);
            this.checkBox_display_exception.TabIndex = 7;
            this.checkBox_display_exception.Text = "display exception";
            this.checkBox_display_exception.UseVisualStyleBackColor = true;
            this.checkBox_display_exception.CheckedChanged += new System.EventHandler(this.checkBox_display_exception_CheckedChanged);
            // 
            // checkBox_connect_at_start
            // 
            this.checkBox_connect_at_start.AutoSize = true;
            this.checkBox_connect_at_start.Location = new System.Drawing.Point(12, 17);
            this.checkBox_connect_at_start.Name = "checkBox_connect_at_start";
            this.checkBox_connect_at_start.Size = new System.Drawing.Size(129, 17);
            this.checkBox_connect_at_start.TabIndex = 10;
            this.checkBox_connect_at_start.Text = "connect to plc at start";
            this.checkBox_connect_at_start.UseVisualStyleBackColor = true;
            this.checkBox_connect_at_start.CheckedChanged += new System.EventHandler(this.checkBox_connect_at_start_CheckedChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(232, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(20, 13);
            this.label2.TabIndex = 13;
            this.label2.Text = "ms";
            // 
            // textBox_timer_log_interval
            // 
            this.textBox_timer_log_interval.Location = new System.Drawing.Point(187, 29);
            this.textBox_timer_log_interval.Name = "textBox_timer_log_interval";
            this.textBox_timer_log_interval.Size = new System.Drawing.Size(39, 20);
            this.textBox_timer_log_interval.TabIndex = 12;
            this.textBox_timer_log_interval.TextChanged += new System.EventHandler(this.textBox_timer_log_interval_TextChanged);
            // 
            // label_timer_log
            // 
            this.label_timer_log.AutoSize = true;
            this.label_timer_log.Location = new System.Drawing.Point(7, 32);
            this.label_timer_log.Name = "label_timer_log";
            this.label_timer_log.Size = new System.Drawing.Size(107, 13);
            this.label_timer_log.TabIndex = 11;
            this.label_timer_log.Text = "interval Get Request:";
            // 
            // checkBox_expert_mode
            // 
            this.checkBox_expert_mode.AutoSize = true;
            this.checkBox_expert_mode.Location = new System.Drawing.Point(12, 40);
            this.checkBox_expert_mode.Name = "checkBox_expert_mode";
            this.checkBox_expert_mode.Size = new System.Drawing.Size(84, 17);
            this.checkBox_expert_mode.TabIndex = 14;
            this.checkBox_expert_mode.Text = "expert mode";
            this.checkBox_expert_mode.UseVisualStyleBackColor = true;
            this.checkBox_expert_mode.CheckedChanged += new System.EventHandler(this.checkBox_expert_mode_CheckedChanged);
            // 
            // panel_expert
            // 
            this.panel_expert.Controls.Add(this.button_save_changes);
            this.panel_expert.Controls.Add(this.label_WatchdagTime);
            this.panel_expert.Controls.Add(this.textBox_WatchdagTime);
            this.panel_expert.Controls.Add(this.label1);
            this.panel_expert.Controls.Add(this.textBox_timer_refresh_controls_interval);
            this.panel_expert.Controls.Add(this.label4);
            this.panel_expert.Controls.Add(this.checkBox_start_timers_at_startup);
            this.panel_expert.Controls.Add(this.textBox_connect_error_retrys);
            this.panel_expert.Controls.Add(this.label3);
            this.panel_expert.Controls.Add(this.linkLabel_default_project_path);
            this.panel_expert.Controls.Add(this.checkBox_plc_mode_hold_connection);
            this.panel_expert.Controls.Add(this.textBox_timer_refresh_interval);
            this.panel_expert.Controls.Add(this.label_timer_send);
            this.panel_expert.Controls.Add(this.label2);
            this.panel_expert.Controls.Add(this.checkBox_display_exception);
            this.panel_expert.Controls.Add(this.label_timer_send_ms);
            this.panel_expert.Controls.Add(this.textBox_timer_log_interval);
            this.panel_expert.Controls.Add(this.label_timer_log);
            this.panel_expert.Location = new System.Drawing.Point(12, 63);
            this.panel_expert.Name = "panel_expert";
            this.panel_expert.Size = new System.Drawing.Size(334, 217);
            this.panel_expert.TabIndex = 15;
            // 
            // button_save_changes
            // 
            this.button_save_changes.Location = new System.Drawing.Point(201, 191);
            this.button_save_changes.Name = "button_save_changes";
            this.button_save_changes.Size = new System.Drawing.Size(126, 23);
            this.button_save_changes.TabIndex = 32;
            this.button_save_changes.Text = "save changes";
            this.button_save_changes.UseVisualStyleBackColor = true;
            this.button_save_changes.Visible = false;
            this.button_save_changes.Click += new System.EventHandler(this.button_save_changes_Click);
            // 
            // label_WatchdagTime
            // 
            this.label_WatchdagTime.AutoSize = true;
            this.label_WatchdagTime.Location = new System.Drawing.Point(166, 156);
            this.label_WatchdagTime.Name = "label_WatchdagTime";
            this.label_WatchdagTime.Size = new System.Drawing.Size(83, 13);
            this.label_WatchdagTime.TabIndex = 31;
            this.label_WatchdagTime.Text = "WatchdagTime:";
            // 
            // textBox_WatchdagTime
            // 
            this.textBox_WatchdagTime.Location = new System.Drawing.Point(255, 153);
            this.textBox_WatchdagTime.Name = "textBox_WatchdagTime";
            this.textBox_WatchdagTime.Size = new System.Drawing.Size(53, 20);
            this.textBox_WatchdagTime.TabIndex = 30;
            this.textBox_WatchdagTime.TextChanged += new System.EventHandler(this.textBox_WatchdagTime_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(232, 57);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(20, 13);
            this.label1.TabIndex = 28;
            this.label1.Text = "ms";
            // 
            // textBox_timer_refresh_controls_interval
            // 
            this.textBox_timer_refresh_controls_interval.Location = new System.Drawing.Point(187, 54);
            this.textBox_timer_refresh_controls_interval.Name = "textBox_timer_refresh_controls_interval";
            this.textBox_timer_refresh_controls_interval.Size = new System.Drawing.Size(39, 20);
            this.textBox_timer_refresh_controls_interval.TabIndex = 27;
            this.textBox_timer_refresh_controls_interval.TextChanged += new System.EventHandler(this.textBox_timer_refresh_controls_interval_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 57);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(101, 13);
            this.label4.TabIndex = 26;
            this.label4.Text = "refresh GUI interval:";
            // 
            // checkBox_start_timers_at_startup
            // 
            this.checkBox_start_timers_at_startup.AutoSize = true;
            this.checkBox_start_timers_at_startup.Location = new System.Drawing.Point(10, 152);
            this.checkBox_start_timers_at_startup.Name = "checkBox_start_timers_at_startup";
            this.checkBox_start_timers_at_startup.Size = new System.Drawing.Size(111, 17);
            this.checkBox_start_timers_at_startup.TabIndex = 25;
            this.checkBox_start_timers_at_startup.Text = "start timers at start";
            this.checkBox_start_timers_at_startup.UseVisualStyleBackColor = true;
            this.checkBox_start_timers_at_startup.CheckedChanged += new System.EventHandler(this.checkBox_start_timers_at_startup_CheckedChanged);
            // 
            // textBox_connect_error_retrys
            // 
            this.textBox_connect_error_retrys.Location = new System.Drawing.Point(110, 127);
            this.textBox_connect_error_retrys.Name = "textBox_connect_error_retrys";
            this.textBox_connect_error_retrys.Size = new System.Drawing.Size(39, 20);
            this.textBox_connect_error_retrys.TabIndex = 24;
            this.textBox_connect_error_retrys.TextChanged += new System.EventHandler(this.textBox_connect_error_retrys_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 130);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(92, 13);
            this.label3.TabIndex = 23;
            this.label3.Text = "error trys connect:";
            // 
            // linkLabel_default_project_path
            // 
            this.linkLabel_default_project_path.AutoSize = true;
            this.linkLabel_default_project_path.Location = new System.Drawing.Point(7, 172);
            this.linkLabel_default_project_path.Name = "linkLabel_default_project_path";
            this.linkLabel_default_project_path.Size = new System.Drawing.Size(98, 13);
            this.linkLabel_default_project_path.TabIndex = 14;
            this.linkLabel_default_project_path.TabStop = true;
            this.linkLabel_default_project_path.Text = "default project path";
            this.linkLabel_default_project_path.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel_startup_config_path_LinkClicked);
            // 
            // checkBox_plc_mode_hold_connection
            // 
            this.checkBox_plc_mode_hold_connection.AutoSize = true;
            this.checkBox_plc_mode_hold_connection.Location = new System.Drawing.Point(10, 110);
            this.checkBox_plc_mode_hold_connection.Name = "checkBox_plc_mode_hold_connection";
            this.checkBox_plc_mode_hold_connection.Size = new System.Drawing.Size(119, 17);
            this.checkBox_plc_mode_hold_connection.TabIndex = 22;
            this.checkBox_plc_mode_hold_connection.Text = "plc hold connection";
            this.checkBox_plc_mode_hold_connection.UseVisualStyleBackColor = true;
            this.checkBox_plc_mode_hold_connection.Visible = false;
            this.checkBox_plc_mode_hold_connection.CheckedChanged += new System.EventHandler(this.checkBox_plc_mode_hold_connection_CheckedChanged);
            // 
            // listBox_aktors
            // 
            this.listBox_aktors.FormattingEnabled = true;
            this.listBox_aktors.Location = new System.Drawing.Point(6, 148);
            this.listBox_aktors.Name = "listBox_aktors";
            this.listBox_aktors.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.listBox_aktors.Size = new System.Drawing.Size(494, 420);
            this.listBox_aktors.TabIndex = 19;
            this.listBox_aktors.MouseClick += new System.Windows.Forms.MouseEventHandler(this.listBox_aktors_MouseClick);
            this.listBox_aktors.SelectedIndexChanged += new System.EventHandler(this.listBox_aktors_SelectedIndexChanged);
            // 
            // panel_edit_aktuator
            // 
            this.panel_edit_aktuator.Controls.Add(this.button_save_actuator);
            this.panel_edit_aktuator.Controls.Add(this.comboBox_edit_plc);
            this.panel_edit_aktuator.Controls.Add(this.button_edit_delete);
            this.panel_edit_aktuator.Controls.Add(this.comboBox_edit_type);
            this.panel_edit_aktuator.Controls.Add(this.textBox_edit_name);
            this.panel_edit_aktuator.Controls.Add(this.textBox_akt_id);
            this.panel_edit_aktuator.Location = new System.Drawing.Point(147, 29);
            this.panel_edit_aktuator.Name = "panel_edit_aktuator";
            this.panel_edit_aktuator.Size = new System.Drawing.Size(356, 56);
            this.panel_edit_aktuator.TabIndex = 20;
            this.panel_edit_aktuator.Visible = false;
            // 
            // button_save_actuator
            // 
            this.button_save_actuator.Location = new System.Drawing.Point(278, 29);
            this.button_save_actuator.Name = "button_save_actuator";
            this.button_save_actuator.Size = new System.Drawing.Size(75, 23);
            this.button_save_actuator.TabIndex = 18;
            this.button_save_actuator.Text = "save";
            this.button_save_actuator.UseVisualStyleBackColor = true;
            this.button_save_actuator.Click += new System.EventHandler(this.button_save_actuator_Click);
            // 
            // comboBox_edit_plc
            // 
            this.comboBox_edit_plc.FormattingEnabled = true;
            this.comboBox_edit_plc.Location = new System.Drawing.Point(225, 3);
            this.comboBox_edit_plc.Name = "comboBox_edit_plc";
            this.comboBox_edit_plc.Size = new System.Drawing.Size(128, 21);
            this.comboBox_edit_plc.TabIndex = 5;
            // 
            // button_edit_delete
            // 
            this.button_edit_delete.Location = new System.Drawing.Point(3, 29);
            this.button_edit_delete.Name = "button_edit_delete";
            this.button_edit_delete.Size = new System.Drawing.Size(75, 23);
            this.button_edit_delete.TabIndex = 3;
            this.button_edit_delete.Text = "delete";
            this.button_edit_delete.UseVisualStyleBackColor = true;
            this.button_edit_delete.Click += new System.EventHandler(this.button_edit_delete_Click);
            // 
            // comboBox_edit_type
            // 
            this.comboBox_edit_type.FormattingEnabled = true;
            this.comboBox_edit_type.Location = new System.Drawing.Point(142, 3);
            this.comboBox_edit_type.Name = "comboBox_edit_type";
            this.comboBox_edit_type.Size = new System.Drawing.Size(77, 21);
            this.comboBox_edit_type.TabIndex = 2;
            // 
            // textBox_edit_name
            // 
            this.textBox_edit_name.Location = new System.Drawing.Point(36, 3);
            this.textBox_edit_name.Name = "textBox_edit_name";
            this.textBox_edit_name.Size = new System.Drawing.Size(100, 20);
            this.textBox_edit_name.TabIndex = 1;
            // 
            // textBox_akt_id
            // 
            this.textBox_akt_id.Location = new System.Drawing.Point(3, 3);
            this.textBox_akt_id.Name = "textBox_akt_id";
            this.textBox_akt_id.Size = new System.Drawing.Size(27, 20);
            this.textBox_akt_id.TabIndex = 0;
            // 
            // checkBox_add_new_aktuator
            // 
            this.checkBox_add_new_aktuator.AutoSize = true;
            this.checkBox_add_new_aktuator.Location = new System.Drawing.Point(147, 10);
            this.checkBox_add_new_aktuator.Name = "checkBox_add_new_aktuator";
            this.checkBox_add_new_aktuator.Size = new System.Drawing.Size(110, 17);
            this.checkBox_add_new_aktuator.TabIndex = 21;
            this.checkBox_add_new_aktuator.Text = "make new device";
            this.checkBox_add_new_aktuator.UseVisualStyleBackColor = true;
            this.checkBox_add_new_aktuator.CheckedChanged += new System.EventHandler(this.checkBox_add_new_aktuator_CheckedChanged);
            // 
            // groupBox_aktors
            // 
            this.groupBox_aktors.Controls.Add(this.checkBox_plc);
            this.groupBox_aktors.Controls.Add(this.checkBox_aktorType);
            this.groupBox_aktors.Controls.Add(this.comboBox_listPlc);
            this.groupBox_aktors.Controls.Add(this.comboBox_aktorType);
            this.groupBox_aktors.Controls.Add(this.listBox_aktors);
            this.groupBox_aktors.Controls.Add(this.checkBox_add_new_aktuator);
            this.groupBox_aktors.Controls.Add(this.panel_edit_aktuator);
            this.groupBox_aktors.Location = new System.Drawing.Point(12, 18);
            this.groupBox_aktors.Name = "groupBox_aktors";
            this.groupBox_aktors.Size = new System.Drawing.Size(510, 583);
            this.groupBox_aktors.TabIndex = 23;
            this.groupBox_aktors.TabStop = false;
            this.groupBox_aktors.Text = "device";
            // 
            // checkBox_plc
            // 
            this.checkBox_plc.AutoSize = true;
            this.checkBox_plc.Location = new System.Drawing.Point(53, 125);
            this.checkBox_plc.Name = "checkBox_plc";
            this.checkBox_plc.Size = new System.Drawing.Size(46, 17);
            this.checkBox_plc.TabIndex = 30;
            this.checkBox_plc.Text = "PLC";
            this.checkBox_plc.UseVisualStyleBackColor = true;
            this.checkBox_plc.CheckedChanged += new System.EventHandler(this.checkBox_plc_CheckedChanged);
            // 
            // checkBox_aktorType
            // 
            this.checkBox_aktorType.AutoSize = true;
            this.checkBox_aktorType.Location = new System.Drawing.Point(53, 99);
            this.checkBox_aktorType.Name = "checkBox_aktorType";
            this.checkBox_aktorType.Size = new System.Drawing.Size(77, 17);
            this.checkBox_aktorType.TabIndex = 29;
            this.checkBox_aktorType.Text = "aktor Type";
            this.checkBox_aktorType.UseVisualStyleBackColor = true;
            this.checkBox_aktorType.CheckedChanged += new System.EventHandler(this.checkBox_aktorType_CheckedChanged);
            // 
            // comboBox_listPlc
            // 
            this.comboBox_listPlc.Enabled = false;
            this.comboBox_listPlc.FormattingEnabled = true;
            this.comboBox_listPlc.Location = new System.Drawing.Point(147, 123);
            this.comboBox_listPlc.Name = "comboBox_listPlc";
            this.comboBox_listPlc.Size = new System.Drawing.Size(121, 21);
            this.comboBox_listPlc.TabIndex = 28;
            this.comboBox_listPlc.SelectedIndexChanged += new System.EventHandler(this.comboBox_listPlc_SelectedIndexChanged);
            // 
            // comboBox_aktorType
            // 
            this.comboBox_aktorType.Enabled = false;
            this.comboBox_aktorType.FormattingEnabled = true;
            this.comboBox_aktorType.Location = new System.Drawing.Point(147, 96);
            this.comboBox_aktorType.Name = "comboBox_aktorType";
            this.comboBox_aktorType.Size = new System.Drawing.Size(121, 21);
            this.comboBox_aktorType.TabIndex = 27;
            this.comboBox_aktorType.SelectedIndexChanged += new System.EventHandler(this.comboBox_aktorType_SelectedIndexChanged);
            // 
            // groupBox_plc
            // 
            this.groupBox_plc.Controls.Add(this.checkBox_add_new_plc);
            this.groupBox_plc.Controls.Add(this.listBox_plc);
            this.groupBox_plc.Controls.Add(this.panel_edit_plc);
            this.groupBox_plc.Location = new System.Drawing.Point(1, 1);
            this.groupBox_plc.Name = "groupBox_plc";
            this.groupBox_plc.Size = new System.Drawing.Size(354, 143);
            this.groupBox_plc.TabIndex = 24;
            this.groupBox_plc.TabStop = false;
            this.groupBox_plc.Text = "plc";
            // 
            // checkBox_add_new_plc
            // 
            this.checkBox_add_new_plc.AutoSize = true;
            this.checkBox_add_new_plc.Location = new System.Drawing.Point(6, 19);
            this.checkBox_add_new_plc.Name = "checkBox_add_new_plc";
            this.checkBox_add_new_plc.Size = new System.Drawing.Size(92, 17);
            this.checkBox_add_new_plc.TabIndex = 21;
            this.checkBox_add_new_plc.Text = "make new plc";
            this.checkBox_add_new_plc.UseVisualStyleBackColor = true;
            this.checkBox_add_new_plc.CheckedChanged += new System.EventHandler(this.checkBox_add_new_plc_CheckedChanged);
            // 
            // listBox_plc
            // 
            this.listBox_plc.FormattingEnabled = true;
            this.listBox_plc.Location = new System.Drawing.Point(6, 38);
            this.listBox_plc.Name = "listBox_plc";
            this.listBox_plc.Size = new System.Drawing.Size(157, 95);
            this.listBox_plc.TabIndex = 20;
            this.listBox_plc.MouseClick += new System.Windows.Forms.MouseEventHandler(this.listBox_plc_MouseClick);
            // 
            // panel_edit
            // 
            this.panel_edit.Controls.Add(this.checkBoxFooterShowPlcTime);
            this.panel_edit.Controls.Add(this.checkBox_connect_at_start);
            this.panel_edit.Controls.Add(this.checkBox_expert_mode);
            this.panel_edit.Controls.Add(this.panel_expert);
            this.panel_edit.Location = new System.Drawing.Point(1, 159);
            this.panel_edit.Name = "panel_edit";
            this.panel_edit.Size = new System.Drawing.Size(354, 292);
            this.panel_edit.TabIndex = 25;
            // 
            // checkBoxFooterShowPlcTime
            // 
            this.checkBoxFooterShowPlcTime.AutoSize = true;
            this.checkBoxFooterShowPlcTime.Location = new System.Drawing.Point(102, 40);
            this.checkBoxFooterShowPlcTime.Name = "checkBoxFooterShowPlcTime";
            this.checkBoxFooterShowPlcTime.Size = new System.Drawing.Size(97, 17);
            this.checkBoxFooterShowPlcTime.TabIndex = 30;
            this.checkBoxFooterShowPlcTime.Text = "Show Plc Time";
            this.checkBoxFooterShowPlcTime.UseVisualStyleBackColor = true;
            this.checkBoxFooterShowPlcTime.CheckedChanged += new System.EventHandler(this.checkBoxFooterShowPlcTime_CheckedChanged);
            // 
            // groupBox_DB
            // 
            this.groupBox_DB.Controls.Add(this.textBox_DBPwd);
            this.groupBox_DB.Controls.Add(this.textBox_DBUid);
            this.groupBox_DB.Controls.Add(this.textBox_DBName);
            this.groupBox_DB.Controls.Add(this.textBox_DBServerIP);
            this.groupBox_DB.Controls.Add(this.label_DBPwd);
            this.groupBox_DB.Controls.Add(this.label_DBUid);
            this.groupBox_DB.Controls.Add(this.label_DBName);
            this.groupBox_DB.Controls.Add(this.label_DBServerIP);
            this.groupBox_DB.Location = new System.Drawing.Point(168, 457);
            this.groupBox_DB.Name = "groupBox_DB";
            this.groupBox_DB.Size = new System.Drawing.Size(193, 118);
            this.groupBox_DB.TabIndex = 17;
            this.groupBox_DB.TabStop = false;
            this.groupBox_DB.Text = "Datenbank";
            // 
            // textBox_DBPwd
            // 
            this.textBox_DBPwd.Location = new System.Drawing.Point(72, 84);
            this.textBox_DBPwd.Name = "textBox_DBPwd";
            this.textBox_DBPwd.Size = new System.Drawing.Size(100, 20);
            this.textBox_DBPwd.TabIndex = 23;
            this.textBox_DBPwd.TextChanged += new System.EventHandler(this.textBox_DBPwd_TextChanged);
            // 
            // textBox_DBUid
            // 
            this.textBox_DBUid.Location = new System.Drawing.Point(72, 63);
            this.textBox_DBUid.Name = "textBox_DBUid";
            this.textBox_DBUid.Size = new System.Drawing.Size(100, 20);
            this.textBox_DBUid.TabIndex = 22;
            this.textBox_DBUid.TextChanged += new System.EventHandler(this.textBox_DBUid_TextChanged);
            // 
            // textBox_DBName
            // 
            this.textBox_DBName.Location = new System.Drawing.Point(72, 42);
            this.textBox_DBName.Name = "textBox_DBName";
            this.textBox_DBName.Size = new System.Drawing.Size(100, 20);
            this.textBox_DBName.TabIndex = 21;
            this.textBox_DBName.TextChanged += new System.EventHandler(this.textBox_DBName_TextChanged);
            // 
            // textBox_DBServerIP
            // 
            this.textBox_DBServerIP.Location = new System.Drawing.Point(72, 21);
            this.textBox_DBServerIP.Name = "textBox_DBServerIP";
            this.textBox_DBServerIP.Size = new System.Drawing.Size(100, 20);
            this.textBox_DBServerIP.TabIndex = 20;
            this.textBox_DBServerIP.TextChanged += new System.EventHandler(this.textBox_DBServerIP_TextChanged);
            // 
            // label_DBPwd
            // 
            this.label_DBPwd.AutoSize = true;
            this.label_DBPwd.Location = new System.Drawing.Point(15, 87);
            this.label_DBPwd.Name = "label_DBPwd";
            this.label_DBPwd.Size = new System.Drawing.Size(31, 13);
            this.label_DBPwd.TabIndex = 19;
            this.label_DBPwd.Text = "Pwd:";
            // 
            // label_DBUid
            // 
            this.label_DBUid.AutoSize = true;
            this.label_DBUid.Location = new System.Drawing.Point(15, 66);
            this.label_DBUid.Name = "label_DBUid";
            this.label_DBUid.Size = new System.Drawing.Size(26, 13);
            this.label_DBUid.TabIndex = 18;
            this.label_DBUid.Text = "Uid:";
            // 
            // label_DBName
            // 
            this.label_DBName.AutoSize = true;
            this.label_DBName.Location = new System.Drawing.Point(15, 45);
            this.label_DBName.Name = "label_DBName";
            this.label_DBName.Size = new System.Drawing.Size(38, 13);
            this.label_DBName.TabIndex = 17;
            this.label_DBName.Text = "Name:";
            // 
            // label_DBServerIP
            // 
            this.label_DBServerIP.AutoSize = true;
            this.label_DBServerIP.Location = new System.Drawing.Point(15, 24);
            this.label_DBServerIP.Name = "label_DBServerIP";
            this.label_DBServerIP.Size = new System.Drawing.Size(51, 13);
            this.label_DBServerIP.TabIndex = 16;
            this.label_DBServerIP.Text = "ServerIP:";
            // 
            // groupBox_cps_settings
            // 
            this.groupBox_cps_settings.Controls.Add(this.checkBox_CpsNet_FrmStatusLog);
            this.groupBox_cps_settings.Controls.Add(this.textBox_MngData_AcceptedClockDelay);
            this.groupBox_cps_settings.Controls.Add(this.label_MngData_AcceptedClockDelay);
            this.groupBox_cps_settings.Controls.Add(this.label_cps_server_port);
            this.groupBox_cps_settings.Controls.Add(this.textBox_cpsServerPort);
            this.groupBox_cps_settings.Location = new System.Drawing.Point(1, 457);
            this.groupBox_cps_settings.Name = "groupBox_cps_settings";
            this.groupBox_cps_settings.Size = new System.Drawing.Size(160, 118);
            this.groupBox_cps_settings.TabIndex = 26;
            this.groupBox_cps_settings.TabStop = false;
            this.groupBox_cps_settings.Text = "cps settings";
            // 
            // checkBox_CpsNet_FrmStatusLog
            // 
            this.checkBox_CpsNet_FrmStatusLog.AutoSize = true;
            this.checkBox_CpsNet_FrmStatusLog.Location = new System.Drawing.Point(9, 87);
            this.checkBox_CpsNet_FrmStatusLog.Name = "checkBox_CpsNet_FrmStatusLog";
            this.checkBox_CpsNet_FrmStatusLog.Size = new System.Drawing.Size(96, 17);
            this.checkBox_CpsNet_FrmStatusLog.TabIndex = 4;
            this.checkBox_CpsNet_FrmStatusLog.Text = "Show Log GUI";
            this.checkBox_CpsNet_FrmStatusLog.UseVisualStyleBackColor = true;
            this.checkBox_CpsNet_FrmStatusLog.CheckedChanged += new System.EventHandler(this.checkBox_CpsNet_FrmStatusLog_CheckedChanged);
            // 
            // textBox_MngData_AcceptedClockDelay
            // 
            this.textBox_MngData_AcceptedClockDelay.Location = new System.Drawing.Point(9, 58);
            this.textBox_MngData_AcceptedClockDelay.Name = "textBox_MngData_AcceptedClockDelay";
            this.textBox_MngData_AcceptedClockDelay.Size = new System.Drawing.Size(31, 20);
            this.textBox_MngData_AcceptedClockDelay.TabIndex = 3;
            this.textBox_MngData_AcceptedClockDelay.TextChanged += new System.EventHandler(this.textBox_MngData_AcceptedClockDelay_TextChanged);
            // 
            // label_MngData_AcceptedClockDelay
            // 
            this.label_MngData_AcceptedClockDelay.AutoSize = true;
            this.label_MngData_AcceptedClockDelay.Location = new System.Drawing.Point(6, 42);
            this.label_MngData_AcceptedClockDelay.Name = "label_MngData_AcceptedClockDelay";
            this.label_MngData_AcceptedClockDelay.Size = new System.Drawing.Size(141, 13);
            this.label_MngData_AcceptedClockDelay.TabIndex = 2;
            this.label_MngData_AcceptedClockDelay.Text = "AcceptedClockDelay in sec:";
            // 
            // label_cps_server_port
            // 
            this.label_cps_server_port.AutoSize = true;
            this.label_cps_server_port.Location = new System.Drawing.Point(6, 21);
            this.label_cps_server_port.Name = "label_cps_server_port";
            this.label_cps_server_port.Size = new System.Drawing.Size(63, 13);
            this.label_cps_server_port.TabIndex = 1;
            this.label_cps_server_port.Text = "Server Port:";
            // 
            // textBox_cpsServerPort
            // 
            this.textBox_cpsServerPort.Location = new System.Drawing.Point(75, 18);
            this.textBox_cpsServerPort.Name = "textBox_cpsServerPort";
            this.textBox_cpsServerPort.Size = new System.Drawing.Size(45, 20);
            this.textBox_cpsServerPort.TabIndex = 0;
            this.textBox_cpsServerPort.Text = "50000";
            this.textBox_cpsServerPort.TextChanged += new System.EventHandler(this.textBox_cpsServerPort_TextChanged);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.groupBox_DB);
            this.panel1.Controls.Add(this.groupBox_cps_settings);
            this.panel1.Controls.Add(this.panel_edit);
            this.panel1.Controls.Add(this.groupBox_plc);
            this.panel1.Location = new System.Drawing.Point(550, 18);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(368, 583);
            this.panel1.TabIndex = 27;
            // 
            // FrmParam
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(923, 611);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.groupBox_aktors);
            this.Name = "FrmParam";
            this.ShowInTaskbar = false;
            this.Text = "FrmParam";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmParam_FormClosing);
            this.panel_edit_plc.ResumeLayout(false);
            this.panel_edit_plc.PerformLayout();
            this.panel_expert.ResumeLayout(false);
            this.panel_expert.PerformLayout();
            this.panel_edit_aktuator.ResumeLayout(false);
            this.panel_edit_aktuator.PerformLayout();
            this.groupBox_aktors.ResumeLayout(false);
            this.groupBox_aktors.PerformLayout();
            this.groupBox_plc.ResumeLayout(false);
            this.groupBox_plc.PerformLayout();
            this.panel_edit.ResumeLayout(false);
            this.panel_edit.PerformLayout();
            this.groupBox_DB.ResumeLayout(false);
            this.groupBox_DB.PerformLayout();
            this.groupBox_cps_settings.ResumeLayout(false);
            this.groupBox_cps_settings.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel_edit_plc;
        private System.Windows.Forms.TextBox textBox_plc_port_hex;
        private System.Windows.Forms.TextBox textBox_plc_port;
        private System.Windows.Forms.Label label_plc_port;
        private System.Windows.Forms.TextBox textBox_plcip;
        private System.Windows.Forms.Label label_s7ip_OG;
        private System.Windows.Forms.Label label_timer_send;
        private System.Windows.Forms.TextBox textBox_timer_refresh_interval;
        private System.Windows.Forms.Label label_timer_send_ms;
        private System.Windows.Forms.CheckBox checkBox_display_exception;
        private System.Windows.Forms.CheckBox checkBox_connect_at_start;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox_timer_log_interval;
        private System.Windows.Forms.Label label_timer_log;
        private System.Windows.Forms.CheckBox checkBox_expert_mode;
        private System.Windows.Forms.Panel panel_expert;
        private System.Windows.Forms.LinkLabel linkLabel_default_project_path;
        private System.Windows.Forms.ListBox listBox_aktors;
        private System.Windows.Forms.Panel panel_edit_aktuator;
        private System.Windows.Forms.ComboBox comboBox_edit_type;
        private System.Windows.Forms.TextBox textBox_edit_name;
        private System.Windows.Forms.TextBox textBox_akt_id;
        private System.Windows.Forms.Button button_edit_delete;
        private System.Windows.Forms.ComboBox comboBox_edit_plc;
        private System.Windows.Forms.CheckBox checkBox_add_new_aktuator;
        private System.Windows.Forms.CheckBox checkBox_plc_mode_hold_connection;
        private System.Windows.Forms.TextBox textBox_connect_error_retrys;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox_aktors;
        private System.Windows.Forms.GroupBox groupBox_plc;
        private System.Windows.Forms.ListBox listBox_plc;
        private System.Windows.Forms.TextBox textBox_plc_name;
        private System.Windows.Forms.Label label_plc_name;
        private System.Windows.Forms.Panel panel_edit;
        private System.Windows.Forms.CheckBox checkBox_add_new_plc;
        private System.Windows.Forms.Button button_plc_delete;
        private System.Windows.Forms.Button button_save_actuator;
        private System.Windows.Forms.Button button_save_plc;
        private System.Windows.Forms.CheckBox checkBox_start_timers_at_startup;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox_timer_refresh_controls_interval;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label_DBServerIP;
        private System.Windows.Forms.GroupBox groupBox_DB;
        private System.Windows.Forms.TextBox textBox_DBPwd;
        private System.Windows.Forms.TextBox textBox_DBUid;
        private System.Windows.Forms.TextBox textBox_DBName;
        private System.Windows.Forms.TextBox textBox_DBServerIP;
        private System.Windows.Forms.Label label_DBPwd;
        private System.Windows.Forms.Label label_DBUid;
        private System.Windows.Forms.Label label_DBName;
        private System.Windows.Forms.GroupBox groupBox_cps_settings;
        private System.Windows.Forms.TextBox textBox_cpsServerPort;
        private System.Windows.Forms.Label label_cps_server_port;
        private System.Windows.Forms.Label label_MngData_AcceptedClockDelay;
        private System.Windows.Forms.TextBox textBox_MngData_AcceptedClockDelay;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox comboBox_aktorType;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.CheckBox checkBoxFooterShowPlcTime;
        private System.Windows.Forms.ComboBox comboBox_listPlc;
        private System.Windows.Forms.CheckBox checkBox_plc;
        private System.Windows.Forms.CheckBox checkBox_aktorType;
        private System.Windows.Forms.CheckBox checkBox_CpsNet_FrmStatusLog;
        private System.Windows.Forms.Label label_WatchdagTime;
        private System.Windows.Forms.TextBox textBox_WatchdagTime;
        private System.Windows.Forms.Button button_save_changes;
    }
}