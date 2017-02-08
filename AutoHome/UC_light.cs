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
    public partial class UC_light : UserControl 
    {
        aktuator akt;

        public UC_light(object a)
        {
            InitializeComponent();
            akt = (aktuator)a;
            label_name.Text = "[" + akt.Index.ToString() + "] " + akt.Name;
            akt.plc_send_IO(DataIOType.GetParam);
        }

        private void checkBox_light_enable_lux_CheckedChanged(object sender, EventArgs e)
        {
            textBox_light_lux_off.Enabled = checkBox_light_enable_lux.Checked;
        }

        private void checkBox_light_enable_timer_CheckedChanged(object sender, EventArgs e)
        {
            textBox_light_time_h.Enabled = checkBox_light_enable_timer.Checked;
            textBox_light_time_m.Enabled = checkBox_light_enable_timer.Checked;
            textBox_light_time_s.Enabled = checkBox_light_enable_timer.Checked;
        }

        public void set_switch(bool state) {
            checkBox_switch.Checked = state;
        }

        public void interprete(object _f)
        {
            Frame f = (Frame)_f;
            show_state(Convert.ToBoolean(f.getPayload(0)));

            if (f.isJob(DataIOType.GetParam) || f.isJob(DataIOType.SetParam))
            {
                checkBox_switch.Checked = Convert.ToBoolean(f.getPayload(2));
                checkBox_light_enable_lux.Checked = Convert.ToBoolean(f.getPayload(3));
                textBox_light_lux_off.Text = f.getPayload(4).ToString();
                checkBox_light_enable_timer.Checked = Convert.ToBoolean(f.getPayload(5));

                textBox_light_time_h.Text = f.getPayload(6).ToString();
                textBox_light_time_m.Text = f.getPayload(7).ToString();
                textBox_light_time_s.Text = f.getPayload(8).ToString();
            }
            else if (f.isJob(DataIOType.SetState))
            {
                checkBox_switch.Checked = Convert.ToBoolean(f.getPayload(2));
            }
            else if (f.isJob(DataIOType.GetState))
            {
                checkBox_switch.Checked = Convert.ToBoolean(f.getPayload(2));

                label_remaining_on.Text = "remaining: " +
                    f.getPayload(3).ToString("##") + ":" +
                    f.getPayload(4).ToString("##") + ":" +
                    f.getPayload(5).ToString("##");
            }
            else
                throw new Exception("uc_light unknown job at interprete");
        }
        private void show_state(bool state){
            checkBox_switch.Checked = state;
            if (state)
                this.BackColor = Color.Yellow;
            else
                this.BackColor = Control.DefaultBackColor;
        }

        private void checkBox_switch_CheckedChanged(object sender, EventArgs e)
        {
            //akt.plc_send(new Frame(Frame.SET_STATE(akt._index, checkBox_switch.Checked)));
        }

        private void button_set_param_Click(object sender, EventArgs e)
        {
            akt.plc_send_IO(DataIOType.SetParam, new Int16[]{
                -1,
                Convert.ToInt16(checkBox_light_enable_lux.Checked), 
                Convert.ToInt16(textBox_light_lux_off.Text),
                Convert.ToInt16(checkBox_light_enable_timer.Checked),
                Convert.ToInt16(textBox_light_time_h.Text),
                Convert.ToInt16(textBox_light_time_m.Text), 
                Convert.ToInt16(textBox_light_time_s.Text)});
        }

        private void button_switch_light_Click(object sender, EventArgs e)
        {
            akt.plc_send_IO(DataIOType.SetState, new Int16[]{Convert.ToInt16(!checkBox_switch.Checked) });
        }

        private void textBox_light_lux_off_TextChanged(object sender, EventArgs e)
        {

        }

        private void label_light_lux_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox_light_time_s_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox_light_time_m_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox_light_time_h_TextChanged(object sender, EventArgs e)
        {

        }

        private void label_name_Click(object sender, EventArgs e)
        {

        }



    }
}
