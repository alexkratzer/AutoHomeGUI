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
        aktuator _akt;
        UserControl ucdialog= null;
        public FrmMain_controlDialog(object akt)
        {
            InitializeComponent();
            _akt = (aktuator)akt;

            this.Text = _akt.Name;
            
            switch (_akt._type)
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
                default:
                    Label l = new Label();
                    l.Text = "ERROR: unknown aktor_type";
                    this.Controls.Add(l);
                    break;
            }
            this.Size = new Size(ucdialog.Size.Width + 6, ucdialog.Size.Height + 29);      
        }

        
        private void FrmMain_controlDialog_Load(object sender, EventArgs e)
        {
            //dialog an position des mauszeigers setzen
            //Point _point = new System.Drawing.Point(Cursor.Position.X, Cursor.Position.Y);
            //Top = _point.Y;
            //Left = _point.X;
        }
        
        public int get_aktuator_id() {
            return _akt.Index;
        }

         /// <summary>
         /// weiterreichen des frames von der main callback an das user_control
         /// </summary>
         /// <param name="f"></param>
        public void update_with_frame(object f) {
            this.Text = _akt.Name;

            dynamic d = ucdialog;
            d.LoadData(f);
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
