using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using cpsLIB; //frames

namespace AutoHome
{
    public partial class UC_dialog_jalousie : UserControl, IdialogUpdate
    {
        aktuator _aktor = null;
        private const int EVENT_COUNT = 10;

        public UC_dialog_jalousie(object aktor)
        {
            InitializeComponent();
            _aktor = (aktuator)aktor;
            _aktor.plc_send_IO(DataIOType.GetParam);
            
            init_event();
        }

        public void LoadData(object _value)
        {
            if (!checkBox_EditLock.Checked)
            {
                
                //Frame f = (Frame)frame;
                Int16[] value = (Int16[])_value;
                //label1.Text = "frame: " + f.ToString();
                if (value.Length > 1)
                {
                    textBox_wind_go_up.Text = (Convert.ToDouble(value[2]) / 100).ToString("0.0");
                    if (value.Length > 3) //TODO: sporadisch kurze frames (length[3])
                    {
                        checkBox_initJalousie.Checked = Convert.ToBoolean(value[3]);

                        this.BackColor = Control.DefaultBackColor;
                        textBox_position.Text = value[4].ToString();
                        textBox_angle.Text = value[5].ToString();

                        if (value.Length < 79)
                        {
                            log.msg(this, "UC_dialog_jalousie LoadData() with no event data; Length: " + value.Length.ToString());
                            return;
                        }
                        //log.msg(this, "value length: " + value.Length.ToString());

                        for (int i = 0; i < EVENT_COUNT; i++)
                        {
                            Int16[] extractValue = new Int16[7];
                            for (int x = 0; x < 7; x++)
                            {
                                int index = 7 * i + x + 6;
                                //log.msg(this, "index: " + index.ToString() + " value:" + value[index]);
                                extractValue[x] = value[index];
                            }
                            //string tmp = "";
                            //foreach (Int16 y in extractValue)
                            //    tmp += y.ToString() + ", ";
                            //log.msg(this, "extractValue: " + tmp);
                            list_UC_jalousie[i].print_data(extractValue);
                        }
                    }
                }
                else
                    log.msg(this, "LoadData with empty value @RunningConfig");
            }
            
        }

        #region event
        List<UC_jalousieEvent> list_UC_jalousie = new List<UC_jalousieEvent>();
        private void init_event()
        {
            for (int i = 0; i < EVENT_COUNT; i++)
            {
                list_UC_jalousie.Add(new UC_jalousieEvent(_aktor, Convert.ToInt16(i)));
                list_UC_jalousie[i].Location = new Point(10, i * 60);
                list_UC_jalousie[i].Enabled = false;
                panel_event.Controls.Add(list_UC_jalousie[i]);
            }
        }


        private void checkBox_EditLock_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_EditLock.Checked)
            {
                panel_params.Enabled = true;
                for (int i = 0; i < EVENT_COUNT; i++)
                    list_UC_jalousie[i].Enabled = true;
            }
            else
            {
                panel_params.Enabled = false;
                for (int i = 0; i < EVENT_COUNT; i++)
                    list_UC_jalousie[i].Enabled = false;
                _aktor.plc_send_IO(cpsLIB.DataIOType.GetParam);
            }
        }
        #endregion

        private void button_jal_drive_to_Click(object sender, EventArgs e)
        {
            button_jal_drive_to.Visible = false;
            _aktor.plc_send_IO(DataIOType.SetState, new Int16[]{
                Convert.ToInt16(comboBox_new_position.Text),
                Convert.ToInt16(comboBox_new_angle.Text)
            });
        }

        private void button_drive_up_Click(object sender, EventArgs e)
        {
            _aktor.plc_send_IO(DataIOType.SetState, new Int16[]{0,0});
        }

        private void button_drive_down_Click(object sender, EventArgs e)
        {
            _aktor.plc_send_IO(DataIOType.SetState, new Int16[]{100,100});
        }

        private void button_set_wind_goup_speed_Click(object sender, EventArgs e)
        {
            _aktor.plc_send_IO(DataIOType.SetParam, new Int16[] { Convert.ToInt16(Convert.ToDouble(textBox_wind_go_up.Text) * 100), Convert.ToInt16(checkBox_initJalousie.Checked) });
        }

        private void comboBox_new_position_SelectedIndexChanged(object sender, EventArgs e)
        {
            button_jal_drive_to.Visible = true;

            int val_new;
            int val_cur;
            if (Int32.TryParse(textBox_position.Text, out val_cur) && Int32.TryParse(comboBox_new_position.Text, out val_new))
                if (Convert.ToInt32(textBox_position.Text) > val_new)
                    comboBox_new_angle.Text = "0";
                else
                    comboBox_new_angle.Text = "100";
        }

        private void comboBox_new_angle_SelectedIndexChanged(object sender, EventArgs e)
        {
            button_jal_drive_to.Visible = true;
            if (comboBox_new_position.Text == "")
                comboBox_new_position.Text = textBox_position.Text;
        }

        private void comboBox_new_position_TextChanged(object sender, EventArgs e)
        {
            button_jal_drive_to.Visible = true;
        }

        private void comboBox_new_angle_TextChanged(object sender, EventArgs e)
        {
            button_jal_drive_to.Visible = true;
        }

        private void textBox_wind_go_up_TextChanged(object sender, EventArgs e)
        {
            button_set_wind_goup_speed.Visible = true;
        }

       
    }
}
