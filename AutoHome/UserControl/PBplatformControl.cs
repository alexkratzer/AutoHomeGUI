using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using cpsLIB;

namespace AutoHome
{
    /// <summary>
    /// Darstellung der aktoren in GUI (platform picture)
    /// </summary>
    class PBplatformControl : PictureBox
    {
        public platform_control _platform_control;
        Label l;
        private Int16[] lastValue;

        //neues element wird erstellt
        public PBplatformControl(aktor_type t, platform_control platform_control)
        {
            _platform_control = platform_control;
            pic_set_edit_pic(t);
        }

        //element wird durch deserialisieren erstellt
        public PBplatformControl(platform_control platform_control, int pos_x, int pos_y)
        {
            _platform_control = platform_control;
            Location = new Point(pos_x, pos_y);
            pic_set_edit_pic(_platform_control._aktuator.AktorType);

            update_label_text();
        }

        /// <summary>
        /// call from FrmPlatformConfig if aktuator of control is changed or set
        /// </summary>
        public void update_label_text()
        {
            if (_platform_control._aktuator != null)
            {
                if (l != null)
                    l.Text = _platform_control._aktuator.Name;
                else
                {
                    l = new Label();
                    l.BackColor = Color.Transparent;
                    l.Text = _platform_control._aktuator.Name;
                    this.Controls.Add(l);
                }
            }
            else
                log.msg(this, "call update_label_text() with _platform_control._aktuator == null");
                //picture box sollte gelöscht sein.....
        }

        //bild für FrmConfigPlatform wird erstellt
        private void pic_set_edit_pic(aktor_type t)
        {
            Visible = true;
            Size = new Size(60, 60);
            this.BackColor = Color.Transparent;
            this.BringToFront();
            Image = PBdefaultControl.GetPicByType(t);
        }

        /// <summary>
        /// aktuell dargestelltes bild wird je nach aktualdaten aus cpu angepasst
        /// </summary>
        public void pic_update(Int16[] value)
        {
            //TODO hier bild anpassen
            //no content changed to last request
            if (lastValue != null && value.SequenceEqual(lastValue))
                return;
            
            this.BackColor = Color.Transparent;
            this.Controls.Remove(l);

            //if (!f.isJob(DataIOType.GetState))
            //    log.msg(this, "pic_update() with != DataIOType.GetState");
            
            switch (_platform_control._aktuator.AktorType)
            {
                case aktor_type.light:
                    if (Convert.ToBoolean(value[2]))
                        Image = new Bitmap(AutoHome.Properties.Resources.img_candle_on);
                    //Image = System.Drawing.Bitmap.FromFile(var.img_candle_on);
                    else
                        Image = new Bitmap(Properties.Resources.img_candle_off);
                    break;
                case aktor_type.jalousie:
                    
                        if (value[2] >= 0 && value[2] < 33)
                            Image = new Bitmap(Properties.Resources.img_jalousie_up);
                        else if (value[2] < 66)
                            Image = new Bitmap(Properties.Resources.img_jalousie_middle);
                        else if (value[2] <= 100)
                            Image = new Bitmap(Properties.Resources.img_jalousie_down);
                        //PictureBox pbu = new PictureBox();
                        //pbu.Image = System.Drawing.Bitmap.FromFile(var.workingdir + "\\img_arrow_up.png");
                        //this.Controls.Add(pbu);
                    break;
                case aktor_type.heater:
                        bool state_on = Convert.ToBoolean(value[13]);
                        bool ctrl_manual = Convert.ToBoolean(value[2]);

                    if (state_on && !ctrl_manual) //an und automatic
                        Image = new Bitmap(Properties.Resources.img_heater_on);
                    else if (state_on && ctrl_manual) //an und manuell
                        Image = new Bitmap(Properties.Resources.img_heater_on_manual);
                    else if (!state_on && !ctrl_manual) //aus und automatic
                        Image = new Bitmap(Properties.Resources.img_heater_off);
                    else if (!state_on && ctrl_manual) //aus und manuell
                        Image = new Bitmap(Properties.Resources.img_heater_off_manual);
                    else
                        Image = null;
                    break;
                case aktor_type.sensor:
                    throw new Exception("pic_update() in FrmConfigPlatform for aktor_type.sensor (should be handled at UC_SensorValue)");

                    //case aktor_type.undef:
                    //    Image = System.Drawing.Bitmap.FromFile(var.workingdir + "\\img_undef.png");
                    //    break;
            }

            lastValue = value;
            //lastFrame = f;
        }


    }

}
