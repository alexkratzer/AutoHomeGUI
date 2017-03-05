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
    public partial class UC_dialog_heater : UserControl
    {

        aktuator akt = null;
        public UC_dialog_heater(object aktor)
        {
            InitializeComponent();
            akt = (aktuator)aktor;
            akt.plc_send_IO(cpsLIB.DataIOType.GetParam);
        }
        public UC_dialog_heater LoadData(object _value)
        {
            if (!checkBox_EditLock.Checked)
            {
                Int16[] value = (Int16[])_value;
                if (value.Length > 1)
                {
                    checkBox_ctrl_manuel.Checked = Convert.ToBoolean(value[2]);
                    checkBox_ctrl_on.Checked = Convert.ToBoolean(value[3]);
                    textBox_time_on.Text = ((value[4] * 60) + value[5]).ToString();
                    textBox_time_off.Text = ((value[6] * 60) + value[7]).ToString();
                    textBox_start_h.Text = value[8].ToString();
                    textBox_start_m.Text = value[9].ToString();
                    textBox_stop_h.Text = value[10].ToString();
                    textBox_stop_m.Text = value[11].ToString();
                    textBox_stop_at_degree.Text = (Convert.ToDouble(value[12]) / 100).ToString();
                    radioButton_state_on.Checked = Convert.ToBoolean(value[13]);
                    label_remaining_time.Text = value[14].ToString() + value[15].ToString();
                    if(value.Length>16)
                        label_temp_ist.Text = "IST: " + (Convert.ToDouble(value[16]) / 100).ToString() + " °C";
                    button_send.Visible = false;
                }
                else
                    log.msg(this, "LoadData with empty value @RunningConfig");
            }
            return this;
        }

        private void button_send_Click(object sender, EventArgs e)
        {
            try
            {
                Int16 minutes_on = Convert.ToInt16(textBox_time_on.Text);
                Int16 minutes_off = Convert.ToInt16(textBox_time_off.Text);

                akt.plc_send_IO(DataIOType.SetParam, new Int16[]{
                    Convert.ToInt16(checkBox_ctrl_manuel.Checked),
                    Convert.ToInt16(checkBox_ctrl_on.Checked),
                    (Int16)(minutes_on/60), //time on -> hour
                    (Int16)(minutes_on %60 ), //time on -> minutes
                    (Int16)(minutes_off/60), //time off -> hour
                    (Int16)(minutes_off %60 ), //time off -> minutes
                    Convert.ToInt16(textBox_start_h.Text),
                    Convert.ToInt16(textBox_start_m.Text),
                    Convert.ToInt16(textBox_stop_h.Text),
                    Convert.ToInt16(textBox_stop_m.Text),
                    Convert.ToInt16(Convert.ToDouble(textBox_stop_at_degree.Text) * 100)
                } );

                button_send.Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void checkBox_ctrl_manuel_CheckedChanged(object sender, EventArgs e)
        {
            checkBox_ctrl_on.Enabled = checkBox_ctrl_manuel.Checked;
            panel_ctrl_auto.Enabled = !checkBox_ctrl_manuel.Checked;
            button_send.Visible = true;
        }

        private void checkBox_ctrl_on_CheckedChanged(object sender, EventArgs e)
        {
            button_send.Visible = true;
        }

        private void textBox_time_on_TextChanged(object sender, EventArgs e)
        {
            button_send.Visible = true;
        }

        private void textBox_time_off_TextChanged(object sender, EventArgs e)
        {
            button_send.Visible = true;
        }

        private void textBox_start_h_TextChanged(object sender, EventArgs e)
        {
            button_send.Visible = true;
        }

        private void textBox_start_m_TextChanged(object sender, EventArgs e)
        {
            button_send.Visible = true;
        }

        private void textBox_stop_h_TextChanged(object sender, EventArgs e)
        {
            button_send.Visible = true;
        }

        private void textBox_stop_m_TextChanged(object sender, EventArgs e)
        {
            button_send.Visible = true;
        }

        private void textBox_stop_at_degree_TextChanged(object sender, EventArgs e)
        {
            button_send.Visible = true;
        }

        private void checkBox_EditLock_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_EditLock.Checked)
                panel_edit.Enabled = true;
            else
                panel_edit.Enabled = false;
        }
    }
}
