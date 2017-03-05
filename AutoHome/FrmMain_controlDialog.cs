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
    public interface IdialogUpdate
    {
        void LoadData(object frame);
    }

    public partial class FrmMain_controlDialog : Form
    {
        
        string ip;
        aktuator _akt;
        private UserControl ucdialog= null;
        public FrmMain_controlDialog(object akt)
        {
            InitializeComponent();
            _akt = (aktuator)akt;
            ip = _akt._plc.IPplc;

            this.Text = _akt.Name;
            
            switch (_akt.AktorType)
            {
                case aktor_type.jalousie:
                    ucdialog = new UC_dialog_jalousie(_akt);
                    this.Controls.Add(ucdialog);
                    break;
                case aktor_type.light:
                    ucdialog = new UC_dialog_light(_akt);
                    this.Controls.Add(ucdialog);
                    break;
                case aktor_type.heater:
                    ucdialog = new UC_dialog_heater(_akt);
                    this.Controls.Add(ucdialog);
                    break;
                case aktor_type.undef:
                    ucdialog = new UC_dialog_undef(_akt);
                    this.Controls.Add(ucdialog);
                    break;
                case aktor_type.sensor:
                    Label lsensor = new Label();
                    lsensor.Text = "ERROR: aktor_type.sensor not implemented";
                    this.Controls.Add(lsensor);
                    break;
                default:
                    Label lerror = new Label();
                    lerror.Text = "ERROR: unknown aktor_type";
                    this.Controls.Add(lerror);
                    break;
            }
            this.Size = new Size(ucdialog.Size.Width + 6, ucdialog.Size.Height + 29);

            
            TimerUpdateGui = new System.Windows.Forms.Timer();
            TimerUpdateGui.Interval = var.timer_refresh_GUI;
            TimerUpdateGui.Tick += new EventHandler(timer_refresh_control_Tick);
            TimerUpdateGui.Start();
        }


        private void FrmMain_controlDialog_FormClosing(object sender, FormClosingEventArgs e)
        {
            TimerUpdateGui.Stop();
        }

        /// <summary>
        /// weiterreichen des frames von der main callback an das user_control
        /// </summary>
        /// <param name="f"></param>
        //public void update_with_frame(object f) {
        //    this.Text = _akt.Name;

        //    dynamic d = ucdialog;
        //    d.LoadData(f);
        //}

        System.Windows.Forms.Timer TimerUpdateGui;
        /// alle controls in gui werden mit ihren aktual werten befüllt
        void timer_refresh_control_Tick(object sender, EventArgs e)
        {
            try
            {
                if (_akt.ConfigAktuatorValuesRunning.Length > 1)
                {
                    dynamic d = ucdialog;
                    d.LoadData(_akt.ConfigAktuatorValuesRunning);
                    this.Text = _akt.Name + " [" + _akt.lastUpdateTimestamp.ToString("HH:mm:ss") + "]";
                }
                else
                    log.msg(this, "timer_refresh_control_Tick() with LoadData < 1");
            }
            catch (Exception ex)
            {
                log.exception(this, "timer_refresh_control_Tick", ex);
            }
        }
        
        private void FrmMain_controlDialog_Leave(object sender, EventArgs e)
        {
            Text = Text + "::-- leave";
        }

        private void FrmMain_controlDialog_MouseLeave(object sender, EventArgs e)
        {
            Text = Text + "::mouse leave";
        }

    }
}
