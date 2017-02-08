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
    public partial class UC_heater : UserControl
    {
        aktuator akt;

        public UC_heater(object _a)
        {
            InitializeComponent();
            akt = (aktuator)_a;
            label_name.Text = "[" + akt.Index.ToString() + "] " + akt.Name;
            akt.plc_send_IO(DataIOType.GetParam);
        }

        private void button_send_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    akt.plc_send_IO(DataIOType.SetParam,new Int16[]{
            //        akt.Index, Convert.ToInt16(checkBox_ctrl_manuel.Checked),
            //        Convert.ToInt16(checkBox_ctrl_on.Checked), 0, Convert.ToInt16(textBox_time_on.Text), 0, Convert.ToInt16(textBox_time_off.Text),
            //        Convert.ToInt16(textBox_start_h.Text), Convert.ToInt16(textBox_start_m.Text), Convert.ToInt16(textBox_stop_h.Text),
            //        Convert.ToInt16(textBox_stop_m.Text), Convert.ToInt16(Convert.ToDouble(textBox_stop_at_degree.Text) * 100)
            //    });
            //    button_send.Visible = false;
            //}
            //catch (Exception ex) {
            //    MessageBox.Show(ex.Message);
            //}

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
                });

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

        public void interprete(object _f)
        {
            Frame f = (Frame)_f;
            this.Enabled = true;

            this.BackColor = Control.DefaultBackColor;
            button_send.Visible = false;


            if (f.isJob(DataIOType.GetState))
            {
                //checkBox_ctrl_manuel.Checked = Convert.ToBoolean(f.getPayload(3)); // -> override GUI input
                //checkBox_ctrl_on.Checked = Convert.ToBoolean(f.getPayload(4)); // -> override GUI input
                radioButton_state_on.Checked = Convert.ToBoolean(f.getPayload(2));
                label_remaining_time.Text = f.getPayload(5).ToString("##") + f.getPayload(6).ToString("##");
            }
            else if (f.isJob(DataIOType.GetParam) || f.isJob(DataIOType.SetParam))
            {
                checkBox_ctrl_manuel.Checked = Convert.ToBoolean(f.getPayload(2));
                checkBox_ctrl_on.Checked = Convert.ToBoolean(f.getPayload(3));
                textBox_time_on.Text = ((f.getPayload(4) * 60) + f.getPayload(5)).ToString();
                textBox_time_off.Text = ((f.getPayload(6) * 60) + f.getPayload(7)).ToString();
                textBox_start_h.Text = f.getPayload(8).ToString();
                textBox_start_m.Text = f.getPayload(9).ToString();
                textBox_stop_h.Text = f.getPayload(10).ToString();
                textBox_stop_m.Text = f.getPayload(11).ToString();
                textBox_stop_at_degree.Text = (Convert.ToDouble(f.getPayload(12)) / 100).ToString();
                radioButton_state_on.Checked = Convert.ToBoolean(f.getPayload(13));
                label_remaining_time.Text = f.getPayload(14).ToString("##") + f.getPayload(15).ToString("##");
                button_send.Visible = false;
            }
            else if (f.isJob(DataIOType.SetState))
                MessageBox.Show("rcv frame with unknown job (DataIOType.SetState): " + f.getPayload(1) + " " + f.ToString());
            else
                MessageBox.Show("rcv frame with unknown job: " + f.getPayload(1) + " " + f.ToString());
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


    }
}
