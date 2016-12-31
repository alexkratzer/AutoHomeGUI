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
        
        List<aktuator> _list_aktuator;
        List<plc> _list_plc;
        List<platform> _list_platform;
        FrmMain _FrmMain; //notwendig um beim beenden die Main Form zu aktualisieren
        public FrmParam(FrmMain FrmMain, object list_aktuator, object list_plc, object list_platform)
        {
            InitializeComponent();
                
            this.Text = var.tool_text + " : parameter";
            _list_aktuator = (List<aktuator>)list_aktuator;
            _list_plc = (List<plc>)list_plc;
            _list_platform = (List<platform>)list_platform;
            _FrmMain = FrmMain;
            init_controlls();

            comboBox_aktorType.DataSource = Enum.GetValues(typeof(aktor_type));
            comboBox_aktorType.SelectedIndex = 0;
            //foreach (aktor_type at in Enum.GetValues(typeof(aktor_type)))
            //    checkedListBox1.Items.Add(at);
            foreach (plc p in _list_plc)
            {
                ListBoxCheck_plc.Items.Add(p,true);
            }

            listBox_aktors_refresh();
            listBox_plc_refresh();
        }

        private void init_controlls() {
            textBox_plcip.Text = var.PLCip;
            textBox_plc_port.Text = var.PLC_PORT.ToString();
            textBox_timer_refresh_interval.Text = var.timer_plc_management_interval.ToString();
            textBox_timer_log_interval.Text = var.timer_MngData_interval.ToString();
            textBox_timer_refresh_controls_interval.Text = var.timer_control_interval.ToString();
            checkBox_display_exception.Checked = var.display_exception;
            checkBox_display_hash.Checked = var.expert_display_hash;
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
        private void checkBox_expert_mode_CheckedChanged(object sender, EventArgs e)
        {
            var.show_expert_mode = checkBox_expert_mode.Checked;
            panel_expert.Visible = var.show_expert_mode;
            label_change_expert_mode.Visible = true;
        }
        private void textBox_timer_send_intervall_TextChanged(object sender, EventArgs e)
        {
            Int32 tmp;
            if (Int32.TryParse(textBox_timer_refresh_interval.Text, out tmp))
            {
                textBox_timer_refresh_interval.BackColor = Color.White;
                var.timer_plc_management_interval = Convert.ToInt32(textBox_timer_refresh_interval.Text);
            }
            else
                textBox_timer_refresh_interval.BackColor = Color.Red;
        }
        private void textBox_timer_log_interval_TextChanged(object sender, EventArgs e)
        {
            Int32 tmp;
            if (Int32.TryParse(textBox_timer_log_interval.Text, out tmp))
            {
                textBox_timer_log_interval.BackColor = Color.White;
                var.timer_MngData_interval = Convert.ToInt32(textBox_timer_log_interval.Text);
            }
            else
                textBox_timer_log_interval.BackColor = Color.Red;
        }
         
        private void textBox_timer_refresh_controls_interval_TextChanged(object sender, EventArgs e)
        {
            Int32 tmp;
            if (Int32.TryParse(textBox_timer_refresh_controls_interval.Text, out tmp))
            {
                textBox_timer_refresh_controls_interval.BackColor = Color.White;
                var.timer_control_interval = Convert.ToInt32(textBox_timer_refresh_controls_interval.Text);
            }
            else
                textBox_timer_refresh_controls_interval.BackColor = Color.Red;  
        }

        private void textBox_connect_error_retrys_TextChanged(object sender, EventArgs e)
        {
            Int32 tmp;
            if (Int32.TryParse(textBox_connect_error_retrys.Text, out tmp))
            {
                textBox_connect_error_retrys.BackColor = Color.White;
                var.connect_error_retrys = Convert.ToInt32(textBox_connect_error_retrys.Text);
            }
            else
                textBox_connect_error_retrys.BackColor = Color.Red;
        }
        private void checkBox_display_exception_CheckedChanged(object sender, EventArgs e)
        {
            var.display_exception = checkBox_display_exception.Checked;
        }

        private void checkBox_display_hash_CheckedChanged(object sender, EventArgs e)
        {
            var.expert_display_hash = checkBox_display_hash.Checked;
        }
        
        private void checkBox_start_timers_at_startup_CheckedChanged(object sender, EventArgs e)
        {
            var.start_timers_at_start = checkBox_start_timers_at_startup.Checked;
        }

        private void checkBox_plc_mode_hold_connection_CheckedChanged(object sender, EventArgs e)
        {
            MessageBox.Show("TODO");
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
        aktuator selected_aktuator = null;

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

        private void listBox_aktors_refresh()
        {
            List<aktuator> tmp_list_aktor = new List<aktuator>();
            _list_aktuator.Sort((x, y) => x.Index.CompareTo(y.Index));

            //copy aktuator in display list depending on filter settings
            aktor_type at = (aktor_type)comboBox_aktorType.SelectedItem;
            foreach (aktuator a in _list_aktuator) {
                if (a.GetAktType() == at) {
                    for(int x = 0; x <= ListBoxCheck_plc.CheckedItems.Count -1; x++)
                        if( a.isPlc((plc)ListBoxCheck_plc.CheckedItems[x]))
                            tmp_list_aktor.Add(a);
                }

            }

            listBox_aktors.DataSource = null;
            listBox_aktors.Items.Clear();
            listBox_aktors.DataSource = tmp_list_aktor;
        }

        private void listBox_aktors_MouseClick(object sender, MouseEventArgs e)
        {
            checkBox_add_new_aktuator.Checked = false;
            panel_edit_aktuator.Visible = true;
            selected_aktuator = (aktuator)listBox_aktors.SelectedItem;
            if (selected_aktuator != null)
            {
                textBox_akt_id.Text = selected_aktuator.Index.ToString();
                textBox_edit_name.Text = selected_aktuator.Name;
                comboBox_edit_type.Text = selected_aktuator._type.ToString();
                if(selected_aktuator._plc != null)
                    comboBox_edit_plc.Text = selected_aktuator._plc.get_plc_name();
                else
                    comboBox_edit_plc.Text = "SELECT PLC";
            }
        }
        
        private void button_edit_delete_Click(object sender, EventArgs e)
        {
            ListBox.SelectedObjectCollection collection = new ListBox.SelectedObjectCollection(listBox_aktors);
            foreach (aktuator akt in collection)
                _list_aktuator.Remove(akt);

            listBox_aktors_refresh();
            panel_edit_aktuator.Visible = false;
        }

        private void checkBox_add_new_aktuator_CheckedChanged(object sender, EventArgs e)
        {
            panel_edit_aktuator.Visible = checkBox_add_new_aktuator.Checked;
            button_edit_delete.Visible = !checkBox_add_new_aktuator.Checked;

            textBox_akt_id.Text = "xxx";
            textBox_edit_name.Text = "type name here";
            comboBox_edit_type.SelectedIndex = 0;
            comboBox_edit_plc.SelectedIndex = 0;
        }

        private void button_save_actuator_Click(object sender, EventArgs e)
        {
            //ein item wird editiert
            if (listBox_aktors.SelectedItems.Count == 1)
            {
                textBox_akt_id.BackColor = Color.White;
                Int16 index;
                //id auf zahl verifizieren
                if (Int16.TryParse(textBox_akt_id.Text, out index))
                {
                    plc plc = (plc)comboBox_edit_plc.SelectedItem;
                    aktor_type type = (aktor_type)Enum.Parse(typeof(aktor_type), comboBox_edit_type.Text);

                    //if (!checkBox_add_new_aktuator.Checked)
                    //    _list_aktuator.Remove(selected_aktuator);

                    if(checkBox_add_new_aktuator.Checked)
                        _list_aktuator.Add(new aktuator(index, textBox_edit_name.Text, plc, type));
                    else{
                        int nr = _list_aktuator.IndexOf(selected_aktuator);
                        _list_aktuator[nr].Index = index;
                        _list_aktuator[nr].Name = textBox_edit_name.Text;
                        _list_aktuator[nr]._plc = plc;
                        _list_aktuator[nr]._type = type;
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
                foreach (aktuator akt in collection){
                    if(comboBox_edit_type.SelectedItem != null)
                        akt._type = (aktor_type)Enum.Parse(typeof(aktor_type), comboBox_edit_type.Text);
                    if (comboBox_edit_plc.SelectedItem != null)
                        akt.change_plc((plc)comboBox_edit_plc.SelectedItem);
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

            comboBox_edit_plc.DataSource = null;
            comboBox_edit_plc.Items.Clear();
            comboBox_edit_plc.DataSource = _list_plc;
        }
        

        private void listBox_plc_MouseClick(object sender, MouseEventArgs e)
        {
            checkBox_add_new_plc.Checked = false;
            panel_edit_plc.Visible = true;

            selected_plc = (plc)listBox_plc.SelectedItem;
            if (selected_plc != null)
            {
                textBox_plcip.Text = selected_plc.get_plc_ip();
                textBox_plc_name.Text = selected_plc.get_plc_name();
                textBox_plc_port.Text = selected_plc.get_plc_port();
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
            int count = 0;
                foreach (aktuator a in _list_aktuator) 
                    if (a.isPlc(selected_plc))
                        count++;

                if (count > 0) //abfrage ob plc in aktoren hinterlegt ist
                {
                    DialogResult dialogResult = MessageBox.Show("plc is linked to " + count.ToString() + " actuators!", "do you really want to delete " + selected_plc.ToString() + "?",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
                    if (dialogResult == DialogResult.Yes) //plc löschen
                    {
                        foreach (aktuator a in _list_aktuator)
                            if (a.isPlc(selected_plc))
                                a.change_plc(null);
                        _list_plc.Remove(selected_plc);
                        listBox_plc_refresh();
                        panel_edit_plc.Visible = false;
                    }
                }
                else {
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
            //if(!make_new)
            //    _list_plc.Remove(selected_plc);

            if (make_new || (_list_plc.IndexOf(selected_plc) == -1))
                _list_plc.Add(new plc(textBox_plcip.Text, Convert.ToInt32(textBox_plc_port.Text), textBox_plc_name.Text));
            else
            {
                int nr = _list_plc.IndexOf(selected_plc);
                
                _list_plc[nr].set_plc_ip(textBox_plcip.Text);
                _list_plc[nr].set_plc_port(textBox_plc_port.Text);
                _list_plc[nr].set_plc_name(textBox_plc_name.Text);
            }

            listBox_plc_refresh();
        }
        #endregion

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

        private void ListBoxCheck_plc_SelectedValueChanged(object sender, EventArgs e)
        {
            listBox_aktors_refresh();
        }

        private void comboBox_aktorType_SelectedIndexChanged(object sender, EventArgs e)
        {
            listBox_aktors_refresh();
        }
    }
}
