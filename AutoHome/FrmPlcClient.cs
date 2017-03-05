using cpsLIB;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AutoHome
{
    public partial class FrmPlcClient : Form
    {
        private plc _plc;
        private CpsNet _cpsNet;
        public FrmPlcClient(object plc, object cpsNet)
        {
            InitializeComponent();
            _plc = (plc)plc;
            _cpsNet = (CpsNet)cpsNet;
            this.Text = _plc.NamePlc;
            init_timer();

            comboBox_headerFlag.DataSource = Enum.GetValues(typeof(FrameHeaderFlag));
        }
        #region update gui timer
        System.Windows.Forms.Timer TimerUpdateGui;
        private void init_timer()
        {
            TimerUpdateGui = new System.Windows.Forms.Timer();
            TimerUpdateGui.Interval = var.timer_refresh_GUI;
            TimerUpdateGui.Tick += new EventHandler(UpdateGui_tick);
            TimerUpdateGui.Start();
        }
        private void UpdateGui_tick(object sender, EventArgs e) {
            
            label_CpsStatus.Text = _plc.getClient().GetStatus();
            label_plc_time.Text = _plc.clockPlc.ToString();
            label_time_difference.Text = _plc.clockPlcJitter.ToString(@"d\T\ hh\:mm\:ss\.fff");
        }
        #endregion
        //private string TSFormat(TimeSpan ts) {
        //    string format = "";

        //    if (ts.Days != 0)
        //        format = @"d\T\ hh\:mm";
        //    else if (ts.Hours != 0)
        //        format = @"hh\:mm\:ss";
        //    else if (ts.Minutes != 0)
        //        format = @"mm\:ss";
        //    else if (ts.Seconds != 0)
        //        format = @"ss\.fff";
        //    else
        //        format = @"ss\.fffff";
        //    return format;
        //}

        private void button_connect_Click(object sender, EventArgs e)
        {
            _plc.connect(_cpsNet);
        }

        private void button_status_Click(object sender, EventArgs e)
        {
            MessageBox.Show(_plc.getClient().GetSendFrames(), _plc.ToString() + _plc.getClient().GetStatus());
        }

        private void button_setTime_Click(object sender, EventArgs e)
        {
            DateTime TimeNow = DateTime.Now;
            Frame f = new Frame(_plc.getClient(), new Int16[] { (Int16)DataMngType.SetPlcTime, (Int16)TimeNow.Year,
                (Int16)TimeNow.Month, (Int16)TimeNow.Day, (Int16)TimeNow.Hour, (Int16)TimeNow.Minute, (Int16)TimeNow.Second});
            f.SetHeaderFlag(FrameHeaderFlag.MngData);
            _plc.send(f);
        }

        private void button_ReadRunningConfig_Click(object sender, EventArgs e)
        {
            _plc.ReadRunningConfig();
        }

        private void button_CopyRunningToStartupConfig_Click(object sender, EventArgs e)
        {
            _plc.copyRunningToStartConfig();
        }

        private void button_CopyStartupToRunningConfig_Click(object sender, EventArgs e)
        {
            foreach (aktuator a in _plc.ListAktuator)
                if (a.AktorType != aktor_type.sensor && a.ConfigAktuatorValuesStartup != null)
                    a.plc_send_IO(DataIOType.SetParam, a.ConfigAktuatorValuesStartup);
        }

        private void button_send_ibs_Click(object sender, EventArgs e)
        {
            List<string> strPayload = new List<string>();
            strPayload.AddRange(textBox_payload.Text.Split(new char[] { ',', ' ', ';', '|', '.'}));
            if ((FrameHeaderFlag)comboBox_headerFlag.SelectedItem == FrameHeaderFlag.PdataIO)
                strPayload.Insert(0, textBox_aktuatorID.Text);

            Int16 []IntPayload = new Int16[strPayload.Count];

            for(int i = 0; i < strPayload.Count; i++)
            {
                Int16 IntConv;
                if (Int16.TryParse(strPayload[i], out IntConv))
                    IntPayload[i] = IntConv;
                else
                    log.msg(this, "button_send_ibs: Int16.TryParse ERROR (" + textBox_payload.Text + ")");
            }
            Frame frm = new Frame(_plc.getClient(), IntPayload);
            frm.SetHeaderFlag((FrameHeaderFlag)comboBox_headerFlag.SelectedItem);
            _plc.send(frm);
        }

        private void comboBox_headerFlag_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((FrameHeaderFlag)comboBox_headerFlag.SelectedItem == FrameHeaderFlag.PdataIO)
                panel_IOdata.Visible = true;
            else
                panel_IOdata.Visible = false;
        }
    }
    
}