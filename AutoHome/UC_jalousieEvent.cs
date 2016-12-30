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
    public partial class UC_jalousieEvent : UserControl
    {
        Int16 count;
        aktuator akt;
        public UC_jalousieEvent(object _a, Int16 _count)
        {
            InitializeComponent();
            count = _count;
            akt = (aktuator)_a;

            akt.plc_send_IO(DataIOType.GetParamJalousieEvent, new Int16[]{count });
            //akt.plc_send_IO(new Frame(Frame.JALOUSIE_EVENT_GET(akt.Index, count)));
            label_event_id.Text = "Event: " + _count;
            button_set_event.Visible = false;
        }

        public void print_data(object _f) {
            Frame f = (Frame)_f;
            textBox_event_time_hour.Text = f.getPayloadInt(3).ToString();
            textBox_event_time_min.Text = f.getPayloadInt(4).ToString();
            textBox_event_time_sec.Text = f.getPayloadInt(5).ToString();
            comboBox_event_position.Text = f.getPayloadInt(6).ToString();
            comboBox_event_angle.Text = f.getPayloadInt(7).ToString();
            checkBox_event_enable.Checked = Convert.ToBoolean(f.getPayloadInt(8));
            radioButton_event_driving_up.Checked = Convert.ToBoolean(f.getPayloadInt(9));
            radioButton_event_drive_down.Checked = !Convert.ToBoolean(f.getPayloadInt(9));
            button_set_event.Visible = false;
        }

        private void checkBox_event_enable_CheckedChanged(object sender, EventArgs e)
        {
            panel_event_data.Enabled = checkBox_event_enable.Checked;
            if(!checkBox_event_enable.Checked)
                write_new_data();
        }

        private void button_set_event_Click(object sender, EventArgs e)
        {
            write_new_data();
            button_set_event.Visible = false;
        }

        private void write_new_data() {
            akt.plc_send_IO(DataIOType.SetParamJalousieEvent, new Int16[]{count, Convert.ToInt16( textBox_event_time_hour.Text),
            Convert.ToInt16(textBox_event_time_min.Text), Convert.ToInt16(textBox_event_time_sec.Text), 
            Convert.ToInt16(comboBox_event_position.Text), Convert.ToInt16(comboBox_event_angle.Text),
            Convert.ToInt16(checkBox_event_enable.Checked), Convert.ToInt16(radioButton_event_driving_up.Checked)});
        }
        #region save changes
        private void textBox_event_time_hour_TextChanged(object sender, EventArgs e)
        {
            button_set_event.Visible = true;
        }

        private void textBox_event_time_min_TextChanged(object sender, EventArgs e)
        {
            button_set_event.Visible = true;
        }

        private void textBox_event_time_sec_TextChanged(object sender, EventArgs e)
        {
            button_set_event.Visible = true;
        }

        private void textBox_event_position_TextChanged(object sender, EventArgs e)
        {
            button_set_event.Visible = true;
        }

        private void textBox_event_angle_TextChanged(object sender, EventArgs e)
        {
            button_set_event.Visible = true;
        }

        private void radioButton_event_driving_up_CheckedChanged(object sender, EventArgs e)
        {
            button_set_event.Visible = true;
        }

        private void radioButton_event_drive_down_CheckedChanged(object sender, EventArgs e)
        {
            button_set_event.Visible = true;
        }
        #endregion
    }
}
