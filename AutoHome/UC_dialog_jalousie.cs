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
    public partial class UC_dialog_jalousie : UserControl
    {
        aktuator _aktor = null;

        public UC_dialog_jalousie(object aktor)
        {
            InitializeComponent();
            _aktor = (aktuator)aktor;
            _aktor.plc_send_IO(DataIOType.GetParam);
            
            init_event();
        }

        public void LoadData(object frame)
        {
            Frame f = (Frame)frame;
            label1.Text = "frame: " + f.ToString();

            if (f.isJob(DataIOType.GetState) || f.isJob(DataIOType.SetState))
            {
                this.BackColor = Control.DefaultBackColor;
                textBox_position.Text = f.getPayload(2).ToString();
                textBox_angle.Text = f.getPayload(3).ToString();
            }
            else if (f.isJob(DataIOType.GetParam) || f.isJob(DataIOType.SetParam))
            {
                textBox_wind_go_up.Text = (Convert.ToDouble(f.getPayload(2)) / 100).ToString("0.0");
                checkBox_initJalousie.Checked = Convert.ToBoolean(f.getPayload(3));
            }
            else if (f.isJob(DataIOType.GetParamJalousieEvent) || f.isJob(DataIOType.SetParamJalousieEvent))
                LoadData_event(f);
            else
                MessageBox.Show("rcv frame with unknown job: " + f.getPayload(1) + " " + f.ToString());
        }

        #region event
        List<UC_jalousieEvent> list_UC_jalousie = new List<UC_jalousieEvent>();
        private void init_event()
        {
            for (int i = 0; i < 10; i++)
            {
                list_UC_jalousie.Add(new UC_jalousieEvent(_aktor, Convert.ToInt16(i)));
                list_UC_jalousie[i].Location = new Point(10, i * 60);
                panel_event.Controls.Add(list_UC_jalousie[i]);
            }
        }

        public void LoadData_event(object _f)
        {
            Frame f = (Frame)_f;
            list_UC_jalousie[f.getPayload(2)].print_data(f);
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
