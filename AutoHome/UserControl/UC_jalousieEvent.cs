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

            //akt.plc_send_IO(DataIOType.GetParamJalousieEvent, new Int16[]{count });
            //akt.plc_send_IO(new Frame(Frame.JALOUSIE_EVENT_GET(akt.Index, count)));
            label_event_id.Text = "Event: " + _count;
        }

        public void print_data(object _f) {
            Int16[] value = (Int16[])_f;
            textBox_event_time_hour.Text = value[0].ToString();
            textBox_event_time_min.Text = value[1].ToString();
            textBox_event_time_sec.Text = value[2].ToString();
            comboBox_event_position.Text = value[3].ToString();
            comboBox_event_angle.Text = value[4].ToString();
            checkBox_event_enable.Checked = Convert.ToBoolean(value[5]);
            radioButton_event_driving_up.Checked = Convert.ToBoolean(value[6]);
            radioButton_event_drive_down.Checked = !Convert.ToBoolean(value[6]);
        }

        private void checkBox_event_enable_CheckedChanged(object sender, EventArgs e)
        {
            panel_event_data.Enabled = checkBox_event_enable.Checked;
            //if(!checkBox_event_enable.Checked)
            //    write_new_data();
        }

        private void button_set_event_Click(object sender, EventArgs e)
        {
            write_new_data();
        }

        private void write_new_data() {
            try
            {
                akt.plc_send_IO(DataIOType.SetParamJalousieEvent, new Int16[]{count, Convert.ToInt16( textBox_event_time_hour.Text),
            Convert.ToInt16(textBox_event_time_min.Text), Convert.ToInt16(textBox_event_time_sec.Text),
            Convert.ToInt16(comboBox_event_position.Text), Convert.ToInt16(comboBox_event_angle.Text),
            Convert.ToInt16(checkBox_event_enable.Checked), Convert.ToInt16(radioButton_event_driving_up.Checked)});
            }
            catch (Exception) {
                //TODO: Fehleingaben vorher abfragen bzw defaultwerte setzen
                MessageBox.Show("Fehlerhafte eingabe (evtl nicht alle felder ausgefüllt?)","Fehler");
            }
        }
       
    }
}
