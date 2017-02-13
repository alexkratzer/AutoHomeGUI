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
    public partial class UC_jalousie : UserControl
    {
        aktuator akt;
        FrmJalousieEvent frmEvent;

        //CMD to refresh current states
        //client.send(a.plc_ip(), var.PLC_PORT, new Frame(Frame.GET_STATE(a._index)));

        public UC_jalousie(object _a)
        {
            InitializeComponent();
            akt = (aktuator)_a;
            label_name.Text = "[" + akt.Index.ToString() + "] " + akt.Name;
            akt.plc_send_IO(DataIOType.GetParam);
        }

        public void interprete(object _f)
        {
            Frame f = (Frame)_f;
            this.Enabled = true;
            if (f.isJob(DataIOType.GetState) || f.isJob(DataIOType.SetState))
            {
                this.BackColor = Control.DefaultBackColor;
                textBox_position.Text = f.getPayload(2).ToString();
                textBox_angle.Text = f.getPayload(3).ToString();
            }
            else if (f.isJob(DataIOType.GetParam) || f.isJob(DataIOType.SetParam))
            {
                textBox_wind_go_up.Text = (Convert.ToDouble(f.getPayload(2)) / 100).ToString("0.0");
                checkBox_init_motor.Checked = Convert.ToBoolean(f.getPayload(3));
            }
            else if (f.isJob(DataIOType.GetParamJalousieEvent) || f.isJob(DataIOType.SetParamJalousieEvent))
            {
                if(frmEvent!=null)
                    frmEvent.print_data(f);
            }
            else if ( f.isJob(DataIOType.GetParam) || f.isJob(DataIOType.SetParam))
            {
                //MessageBox.Show("doing init jalousie. Wait 1 min please!");
            }
            else
                throw new Exception("uc_jalousie unknown job at interprete! ");
        }

        private void button_jal_drive_to_Click(object sender, EventArgs e)
        {
            button_jal_drive_to.Visible = false;
            akt.plc_send_IO(DataIOType.SetState, new Int16[] { Convert.ToInt16(comboBox_new_position.Text), Convert.ToInt16(comboBox_new_angle.Text) });
        }

        private void button_open_event_Click(object sender, EventArgs e)
        {
            frmEvent = new FrmJalousieEvent(akt);
            frmEvent.Show();
        }

        private void comboBox_new_angle_SelectedIndexChanged(object sender, EventArgs e)
        {
            button_jal_drive_to.Visible = true;
            if(comboBox_new_position.Text == "")
                comboBox_new_position.Text = textBox_position.Text;
        }

        private void comboBox_new_position_SelectedIndexChanged(object sender, EventArgs e)
        {
            button_jal_drive_to.Visible = true;
            int val_cur;
            int val_new;
            if (Int32.TryParse(textBox_position.Text, out val_cur) && Int32.TryParse(comboBox_new_position.Text, out val_new))
                if (val_cur > val_new)
                    comboBox_new_angle.Text = "0";
                else
                    comboBox_new_angle.Text = "100";
        }

        private void textBox_wind_goup_TextChanged(object sender, EventArgs e)
        {
            button_set_wind_goup_speed.Visible = true;
        }

        private void button_set_wind_goup_speed_Click(object sender, EventArgs e)
        {
            button_set_wind_goup_speed.Visible = false;
            akt.plc_send_IO(DataIOType.SetParam, new Int16[] { Convert.ToInt16(Convert.ToDouble(textBox_wind_go_up.Text) * 100), Convert.ToInt16(checkBox_init_motor.Checked) });
        }

        private void checkBox_init_motor_CheckedChanged(object sender, EventArgs e)
        {
            button_set_wind_goup_speed.Visible = true;

        }
    }
}
