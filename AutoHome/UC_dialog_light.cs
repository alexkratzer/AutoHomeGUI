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
    public partial class UC_dialog_light : UserControl, IdialogUpdate
    {
        aktuator _aktor = null;
        public UC_dialog_light(object aktor)
        {
            InitializeComponent();
            _aktor = (aktuator)aktor;
            _aktor.plc_send_IO(DataIOType.GetParam);
            //_aktor.plc_send(new Frame(Frame.GET_PARAM(_aktor.Index)));
        }
        public void LoadData(object frame)
        {
            Frame f = (Frame)frame;
            label1.Text = "frame: " + f.ToString();
            
            if (f.isJob(DataIOType.GetParam) || f.isJob(DataIOType.SetParam))
            {
                if (Convert.ToBoolean(f.getPayload(2)))
                    label_current_state.Text = "state: ON";
                else
                    label_current_state.Text = "state: OFF";
                checkBox_light_enable_lux.Checked = Convert.ToBoolean(f.getPayload(3));              
                textBox_light_lux_off.Text = f.getPayload(4).ToString();
                checkBox_light_enable_timer.Checked = Convert.ToBoolean(f.getPayload(5));
                
                textBox_light_time_h.Text = f.getPayload(6).ToString();
                textBox_light_time_m.Text = f.getPayload(7).ToString();
                textBox_light_time_s.Text = f.getPayload(8).ToString();
            }
            else if (f.isJob(DataIOType.SetState)) {
                if (Convert.ToBoolean(f.getPayload(2)))
                    label_current_state.Text = "state: ON";
                else
                    label_current_state.Text = "state: OFF";
            }
            else if (f.isJob(DataIOType.GetState))
            {
                if (Convert.ToBoolean(f.getPayload(2)))
                    label_current_state.Text = "state: ON";
                else
                    label_current_state.Text = "state: OFF";

                label_remaining_on.Text =
                    f.getPayload(3).ToString("##") + ":" +
                    f.getPayload(4).ToString("##") + ":" +
                    f.getPayload(5).ToString("##");
            }
            else
                MessageBox.Show("rcv frame with unknown job: " + f.getPayload(1) + " " + f.ToString());      
        }

        private void button_switch_Click(object sender, EventArgs e)
        {
            //TODO: implement Frame SetState
            //_aktor.plc_send(new Frame(Frame.SET_STATE(_aktor.Index, true)));
            _aktor.plc_send_IO(DataIOType.SetState, new Int16[] {1});
        }

        private void button_switch_off_Click(object sender, EventArgs e)
        {
            _aktor.plc_send_IO(DataIOType.SetState, new Int16[] { 0 });
        }

        private void checkBox_light_enable_timer_CheckedChanged(object sender, EventArgs e)
        {
            textBox_light_time_h.Enabled = checkBox_light_enable_timer.Checked;
            textBox_light_time_m.Enabled = checkBox_light_enable_timer.Checked;
            textBox_light_time_s.Enabled = checkBox_light_enable_timer.Checked;
        }

        private void checkBox_light_enable_lux_CheckedChanged(object sender, EventArgs e)
        {
            textBox_light_lux_off.Enabled = checkBox_light_enable_lux.Checked;
        }

        private void button_set_param_Click(object sender, EventArgs e)
        {
            _aktor.plc_send_IO(DataIOType.SetParam, new Int16[] {
                -1,
                Convert.ToInt16(checkBox_light_enable_lux.Checked),
                Convert.ToInt16(textBox_light_lux_off.Text),
                Convert.ToInt16(checkBox_light_enable_timer.Checked),
                Convert.ToInt16(textBox_light_time_h.Text),
                Convert.ToInt16(textBox_light_time_m.Text), 
                Convert.ToInt16(textBox_light_time_s.Text) 
            });
        }
    }
}
