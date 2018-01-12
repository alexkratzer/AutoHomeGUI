using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;

namespace AutoHome
{
    public partial class FrmParam : Form
    {
        /// <summary>
        //TODO: alle benutzereingabe edit felder maskieren/ bzw auf fehlerhafte eingabe checken 
        
        List<plc> _list_plc;
        List<platform> _list_platform;
        FrmMain _FrmMain; //notwendig um beim beenden die Main Form zu aktualisieren
        public FrmParam(FrmMain FrmMain, object list_plc, object list_platform)
        {
            InitializeComponent();
            this.Text = var.tool_text + " : parameter";
            _list_plc = (List<plc>)list_plc;
            _list_platform = (List<platform>)list_platform;
            _FrmMain = FrmMain;
            init_controlls();

            comboBox_aktorType.DataSource = Enum.GetValues(typeof(aktor_type));
            comboBox_aktorType.SelectedIndex = 0;

            //listBox_aktors.DataSource = null;
            //listBox_aktors.Items.Clear();
            //listBox_aktors.DataSource = tmp_list_aktor;

            foreach (plc p in _list_plc)
                comboBox_listPlc.Items.Add(p);

            listBox_aktors_refresh();
            listBox_plc_refresh();

            button_save_changes.Visible = false;
        }

        private void init_controlls() {
            textBox_plcip.Text = var.PLCip;
            textBox_plc_port.Text = var.PLC_PORT.ToString();
            textBox_timer_refresh_interval.Text = var.footer_connection_status.ToString();
            textBox_timer_log_interval.Text = var.timer_GetRequestInterval.ToString();
            textBox_timer_refresh_controls_interval.Text = var.timer_refresh_GUI.ToString();
            checkBox_display_exception.Checked = var.display_exception;
            
            checkBox_connect_at_start.Checked = var.connect_to_plc_at_start;
            checkBox_expert_mode.Checked = var.show_expert_mode;
            panel_expert.Visible = var.show_expert_mode;
            textBox_connect_error_retrys.Text = var.connect_error_retrys.ToString();
            linkLabel_default_project_path.Text = var.default_project_data_path;
            checkBox_start_timers_at_startup.Checked = var.start_timers_at_start;

            comboBox_edit_type.DataSource = Enum.GetValues(typeof(aktor_type));
            comboBox_edit_plc.DataSource = _list_plc;

            textBox_DBServerIP.Text = var.DBServerIP;
            textBox_DBName.Text = var.DBName;
            textBox_DBUid.Text = var.DBUid;
            textBox_DBPwd.Text = var.DBPwd;

            textBox_cpsServerPort.Text = var.CpsServerPort.ToString();
            textBox_MngData_AcceptedClockDelay.Text = var.MngData_AcceptedClockDelay.ToString();
            checkBox_CpsNet_FrmStatusLog.Checked = var.CpsNet_FrmStatusLog;
            textBox_WatchdagTime.Text = var.WatchdagTime_PLCtoPC.ToString();

            checkBoxFooterShowPlcTime.Checked = var.FooterShowPlcTime;
        }

        private void FrmParam_FormClosing(object sender, FormClosingEventArgs e)
        {
            _FrmMain.update_gui();
        }
        #region global
        private void textBox_plc_port_TextChanged(object sender, EventArgs e)
        {
            Int32 port;
            if (Int32.TryParse(textBox_plc_port.Text, out port))
            {
                var.PLCport = port;
                textBox_plc_port_hex.Text = Convert.ToString(port, 16);
                textBox_plc_port.BackColor = Color.White;
            }
            else
                textBox_plc_port.BackColor = Color.Red;
        }

        private void textBox_plcOGip_TextChanged(object sender, EventArgs e)
        {
            IPAddress ip;
            if (IPAddress.TryParse(textBox_plcip.Text, out ip))
            {
                var.PLCip = textBox_plcip.Text;
                textBox_plcip.BackColor = Color.White;
            }
            else
                textBox_plcip.BackColor = Color.Red;
        }

        private void checkBox_connect_at_start_CheckedChanged(object sender, EventArgs e)
        {
            var.connect_to_plc_at_start = checkBox_connect_at_start.Checked;
        }
        #endregion

        #region expert mode
        private void safe_changes() {
            Int32 tmp;
            if (Int32.TryParse(textBox_timer_refresh_interval.Text, out tmp))
            {
                textBox_timer_refresh_interval.BackColor = Color.White;
                var.footer_connection_status = Convert.ToInt32(textBox_timer_refresh_interval.Text);
            }
            else
                textBox_timer_refresh_interval.BackColor = Color.Red;

            if (Int32.TryParse(textBox_timer_log_interval.Text, out tmp))
            {
                textBox_timer_log_interval.BackColor = Color.White;
                var.timer_GetRequestInterval = Convert.ToInt32(textBox_timer_log_interval.Text);
            }
            else
                textBox_timer_log_interval.BackColor = Color.Red;

            if (Int32.TryParse(textBox_timer_refresh_controls_interval.Text, out tmp))
            {
                textBox_timer_refresh_controls_interval.BackColor = Color.White;
                var.timer_refresh_GUI = Convert.ToInt32(textBox_timer_refresh_controls_interval.Text);
            }
            else
                textBox_timer_refresh_controls_interval.BackColor = Color.Red;

            if (Int32.TryParse(textBox_connect_error_retrys.Text, out tmp))
            {
                textBox_connect_error_retrys.BackColor = Color.White;
                var.connect_error_retrys = Convert.ToInt32(textBox_connect_error_retrys.Text);
            }
            else
                textBox_connect_error_retrys.BackColor = Color.Red;

            var.display_exception = checkBox_display_exception.Checked;
            var.start_timers_at_start = checkBox_start_timers_at_startup.Checked;

            if (Int32.TryParse(textBox_WatchdagTime.Text, out tmp))
            {
                textBox_WatchdagTime.BackColor = Color.White;
                var.WatchdagTime_PLCtoPC = Convert.ToInt16(textBox_WatchdagTime.Text);
            }
            else
                textBox_WatchdagTime.BackColor = Color.Red;
        }
        private void checkBox_expert_mode_CheckedChanged(object sender, EventArgs e)
        {
            var.show_expert_mode = checkBox_expert_mode.Checked;
            panel_expert.Visible = var.show_expert_mode;
        }
        private void textBox_timer_send_intervall_TextChanged(object sender, EventArgs e)
        {
            button_save_changes.Visible = true;
        }
        private void textBox_timer_log_interval_TextChanged(object sender, EventArgs e)
        {
            button_save_changes.Visible = true;
        }
         
        private void textBox_timer_refresh_controls_interval_TextChanged(object sender, EventArgs e)
        {
            button_save_changes.Visible = true;
        }

        private void textBox_connect_error_retrys_TextChanged(object sender, EventArgs e)
        {
            button_save_changes.Visible = true; 
        }
        private void checkBox_display_exception_CheckedChanged(object sender, EventArgs e)
        {
            button_save_changes.Visible = true;
        }

        private void checkBox_start_timers_at_startup_CheckedChanged(object sender, EventArgs e)
        {
            button_save_changes.Visible = true;
        }

        private void checkBox_plc_mode_hold_connection_CheckedChanged(object sender, EventArgs e)
        {
            MessageBox.Show("TODO");
        }

        private void textBox_WatchdagTime_TextChanged(object sender, EventArgs e)
        {
            button_save_changes.Visible = true;
        }


        private void linkLabel_startup_config_path_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FolderBrowserDialog FBD = new FolderBrowserDialog();
            FBD.SelectedPath = var.default_project_data_path;

            if (FBD.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                var.default_project_data_path = FBD.SelectedPath;

            linkLabel_default_project_path.Text = var.default_project_data_path;
        }

        #endregion
        

        #region aktuators
        //aktuator selected_aktuator = null;

        //bei auswahl von mehreren elementen anderst verhalten
        private void listBox_aktors_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox_aktors.SelectedItems.Count > 1)
            {
                textBox_akt_id.Visible = false;
                textBox_edit_name.Visible = false;
                comboBox_edit_type.Text = "set type";
                comboBox_edit_type.SelectedItem = null;
                comboBox_edit_plc.Text = "set PLC";
                comboBox_edit_plc.SelectedItem = null;
            }
            else if (listBox_aktors.SelectedItems.Count == 1)
            {
                textBox_akt_id.Visible = true;
                textBox_edit_name.Visible = true;
            }
        }

        List<aktuator> tmp_list_aktor = new List<aktuator>();
        private void listBox_aktors_refresh()
        {
            //List<aktuator> tmp_list_aktor = new List<aktuator>();
            tmp_list_aktor.Clear();
            //copy aktuator in display list depending on filter settings

            plc selectedPlc = (plc)comboBox_listPlc.SelectedItem;

            foreach (plc p in _list_plc) {
                if (checkBox_plc.Checked)
                {
                    foreach (aktuator a in selectedPlc.ListAktuator)
                        if (checkBox_aktorType.Checked)
                        {
                            if (a.AktorType == (aktor_type)comboBox_aktorType.SelectedItem)
                                tmp_list_aktor.Add(a);
                        }
                        else
                            tmp_list_aktor.Add(a);
                }
                else {//alle aktoren aller plc´s hinzufügen
                    foreach (aktuator a in p.ListAktuator)
                    {
                        if (checkBox_aktorType.Checked)
                        {
                            if (a.AktorType == (aktor_type)comboBox_aktorType.SelectedItem)
                                tmp_list_aktor.Add(a);
                        }else
                            tmp_list_aktor.Add(a);
                    }
                }
            }
            
            tmp_list_aktor.Sort((x, y) => x.Index.CompareTo(y.Index));

            listBox_aktors.DataSource = null;
            listBox_aktors.Items.Clear();
            listBox_aktors.DataSource = tmp_list_aktor;
        }

        private void listBox_aktors_MouseClick(object sender, MouseEventArgs e)
        {
            checkBox_add_new_aktuator.Checked = false;
            panel_edit_aktuator.Visible = true;
            aktuator selected_aktuator = (aktuator)listBox_aktors.SelectedItem;
            if (selected_aktuator != null)
            {
                textBox_akt_id.Text = selected_aktuator.Index.ToString();
                textBox_edit_name.Text = selected_aktuator.Name;
                comboBox_edit_type.Text = selected_aktuator.AktorType.ToString();
                if(selected_aktuator._plc != null)
                    comboBox_edit_plc.Text = selected_aktuator._plc.NamePlc;
                else
                    comboBox_edit_plc.Text = "SELECT PLC";
            }
        }
        
        private void button_edit_delete_Click(object sender, EventArgs e)
        {
            ListBox.SelectedObjectCollection collection = new ListBox.SelectedObjectCollection(listBox_aktors);
            foreach (aktuator akt in collection)
                akt._plc.ListAktuator.Remove(akt);
                //_list_aktuator.Remove(akt);

            listBox_aktors_refresh();
            panel_edit_aktuator.Visible = false;
        }

        private void checkBox_add_new_aktuator_CheckedChanged(object sender, EventArgs e)
        {
            panel_edit_aktuator.Visible = checkBox_add_new_aktuator.Checked;
            button_edit_delete.Visible = !checkBox_add_new_aktuator.Checked;

            textBox_akt_id.Text = listBox_aktors.Items.Count.ToString();
            textBox_edit_name.Text = "type name here";
            comboBox_edit_type.SelectedIndex = 0;
            comboBox_edit_plc.SelectedIndex = 0;
        }

        private void button_save_actuator_Click(object sender, EventArgs e)
        {
            //ein item wird editiert
            if (listBox_aktors.SelectedItems.Count == 1 || checkBox_add_new_aktuator.Checked)
            {
                textBox_akt_id.BackColor = Color.White;
                Int16 index;
                //id auf zahl verifizieren
                if (Int16.TryParse(textBox_akt_id.Text, out index))
                {
                    plc plc = (plc)comboBox_edit_plc.SelectedItem;
                    aktor_type type = (aktor_type)Enum.Parse(typeof(aktor_type), comboBox_edit_type.Text);

                    if (checkBox_add_new_aktuator.Checked)
                    {
                        plc.ListAktuator.Add(new aktuator(index, textBox_edit_name.Text, plc, type));
                        textBox_akt_id.Text = (Convert.ToInt16(textBox_akt_id.Text) + 1).ToString();
                    }
                    else
                    {
                        aktuator a = (aktuator)listBox_aktors.SelectedItem;
                        //plc.ListAktuator.FindIndex(a)
                        if (comboBox_edit_type.SelectedItem != null)
                            a.AktorType = (aktor_type)Enum.Parse(typeof(aktor_type), comboBox_edit_type.Text);
                        if (comboBox_edit_plc.SelectedItem != null)
                        {
                            if (a._plc != (plc)comboBox_edit_plc.SelectedItem) {
                                ((plc)comboBox_edit_plc.SelectedItem).ListAktuator.Add(a);
                                a._plc.ListAktuator.Remove(a);
                            }
                        }
                        if (textBox_akt_id.Text != "")
                            a.Index = Convert.ToInt16( textBox_akt_id.Text);
                        if (textBox_edit_name.Text != "")
                            a.Name = textBox_edit_name.Text;



                        //int nr = plc.ListAktuator.IndexOf(a);
                        //plc.ListAktuator[nr].Index = index;
                        //plc.ListAktuator[nr].Name = textBox_edit_name.Text;
                        //plc.ListAktuator[nr]._plc = plc;
                        //plc.ListAktuator[nr]._type = type;
                    }
                    //################################################# TODO: 
                    //###################### alle bereits projektierten aktoren suchen und ebenfalls updaten

                    //foreach(platform p in _list_platform)
                    //    int fn = p._list_platform_control.
                }
                else
                    textBox_akt_id.BackColor = Color.Red;
            }
            //mehrere items werden gleichzeitig editiert
            else
            {
                ListBox.SelectedObjectCollection collection = new ListBox.SelectedObjectCollection(listBox_aktors);
                foreach (aktuator a in collection){
                    if(comboBox_edit_type.SelectedItem != null)
                        a.AktorType = (aktor_type)Enum.Parse(typeof(aktor_type), comboBox_edit_type.Text);
                    if (comboBox_edit_plc.SelectedItem != null)
                    {
                        if (a._plc != (plc)comboBox_edit_plc.SelectedItem)
                        {
                            ((plc)comboBox_edit_plc.SelectedItem).ListAktuator.Add(a);
                            a._plc.ListAktuator.Remove(a);
                        }
                    }
                }
            }
            
            listBox_aktors_refresh();
        }
        #endregion

        #region plc
        plc selected_plc = null;

        private void listBox_plc_refresh()
        {
            listBox_plc.DataSource = null;
            listBox_plc.Items.Clear();
            listBox_plc.DataSource = _list_plc;

            //comboBox_edit_plc.DataSource = null;
            //comboBox_edit_plc.Items.Clear();
            //comboBox_edit_plc.DataSource = _list_plc;
        }
        

        private void listBox_plc_MouseClick(object sender, MouseEventArgs e)
        {
            checkBox_add_new_plc.Checked = false;
            panel_edit_plc.Visible = true;

            selected_plc = (plc)listBox_plc.SelectedItem;
            if (selected_plc != null)
            {
                textBox_plcip.Text = selected_plc.IPplc;
                textBox_plc_name.Text = selected_plc.NamePlc;
                textBox_plc_port.Text = selected_plc.PortPlc;
            }
        }
        

        private void checkBox_add_new_plc_CheckedChanged(object sender, EventArgs e)
        {
            panel_edit_plc.Visible = checkBox_add_new_plc.Checked;
            button_plc_delete.Visible = !checkBox_add_new_plc.Checked;

            textBox_plcip.Text = "";
            textBox_plc_name.Text = "not named";
            textBox_plc_port.Text = "2500";
        }

        private void button_plc_delete_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("plc is linked to " + selected_plc.ListAktuator.Count + " actuators!", "do you really want to delete " + selected_plc.ToString() + "?",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
            if (dialogResult == DialogResult.Yes) //plc löschen
            {
                //foreach (aktuator a in _list_aktuator)
                //    if (a.isPlc(selected_plc))
                //        a.change_plc(null);
                _list_plc.Remove(selected_plc);
                listBox_plc_refresh();
                panel_edit_plc.Visible = false;
            }
        }

        private void button_save_plc_Click(object sender, EventArgs e)
        {
            change_plc(checkBox_add_new_plc.Checked);
        }

        private void change_plc(bool make_new)
        {
            if (make_new || (_list_plc.IndexOf(selected_plc) == -1))
                _list_plc.Add(new plc(textBox_plcip.Text, Convert.ToInt32(textBox_plc_port.Text), textBox_plc_name.Text));
            else
            {
                int nr = _list_plc.IndexOf(selected_plc);
                
                _list_plc[nr].IPplc = textBox_plcip.Text;
                _list_plc[nr].PortPlc = textBox_plc_port.Text;
                _list_plc[nr].NamePlc = textBox_plc_name.Text;
            }

            listBox_plc_refresh();
        }
        #endregion
        private void checkBoxFooterShowPlcTime_CheckedChanged(object sender, EventArgs e)
        {
            var.FooterShowPlcTime = checkBoxFooterShowPlcTime.Checked;
        }

        private void textBox_DBServerIP_TextChanged(object sender, EventArgs e)
        {
            var.DBServerIP = textBox_DBServerIP.Text;
        }

        private void textBox_DBName_TextChanged(object sender, EventArgs e)
        {
            var.DBName = textBox_DBName.Text;
        }

        private void textBox_DBUid_TextChanged(object sender, EventArgs e)
        {
            var.DBUid = textBox_DBUid.Text;
        }

        private void textBox_DBPwd_TextChanged(object sender, EventArgs e)
        {
            var.DBPwd = textBox_DBPwd.Text;
        }

        private void textBox_cpsServerPort_TextChanged(object sender, EventArgs e)
        {
            var.CpsServerPort = Convert.ToInt32( textBox_cpsServerPort.Text );
        }

        private void textBox_MngData_AcceptedClockDelay_TextChanged(object sender, EventArgs e)
        {
            if(textBox_MngData_AcceptedClockDelay.Text != "")
                var.MngData_AcceptedClockDelay = Convert.ToInt32(textBox_MngData_AcceptedClockDelay.Text);
        }

        #region group box device
        private void comboBox_aktorType_SelectedIndexChanged(object sender, EventArgs e)
        {
            listBox_aktors_refresh();
        }
        private void comboBox_listPlc_SelectedIndexChanged(object sender, EventArgs e)
        {
            listBox_aktors_refresh();
        }

        private void checkBox_aktorType_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_aktorType.Checked)
            {
                comboBox_aktorType.Enabled = true;
                comboBox_aktorType.Text = "choose type to filter";
            }
            else
            {
                comboBox_aktorType.Enabled = false;
                comboBox_aktorType.Text = "no type filter";
                listBox_aktors_refresh();
            }
        }

        private void checkBox_plc_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_plc.Checked)
            {
                comboBox_listPlc.Enabled = true;
                comboBox_listPlc.Text = "choose plc to filter";
            }
            else
            {
                comboBox_listPlc.Enabled = false;
                comboBox_listPlc.Text = "no plc filter";
                listBox_aktors_refresh();
            }
        }

        #endregion

        private void checkBox_CpsNet_FrmStatusLog_CheckedChanged(object sender, EventArgs e)
        {
            var.CpsNet_FrmStatusLog = checkBox_CpsNet_FrmStatusLog.Checked;
        }

        private void button_save_changes_Click(object sender, EventArgs e)
        {
            button_save_changes.Visible = false;
            safe_changes();
        }

      
    }
}
