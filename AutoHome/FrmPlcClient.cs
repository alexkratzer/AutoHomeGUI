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
            label_CpsStatus.Text = _plc.getClient().GetStatus();

        }

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
            Frame f3 = new Frame(_plc.getClient(), new Int16[] { 1 });
            f3.SetHeaderFlag(FrameHeaderFlag.MngData);
            _plc.send(f3);
        }

        private void button_getClientStatus_Click(object sender, EventArgs e)
        {
            label_CpsStatus.Text = _plc.getClient().GetStatus();
        }
    }
    
}