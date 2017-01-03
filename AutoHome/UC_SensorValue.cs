using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AutoHome
{
    /// <summary>
    /// Darstellung der SensorWerte in GUI (platform picture als UserControl)
    /// </summary>
    partial class UC_SensorValue : UserControl
    {
        private platform_control _platform_control;
        Label l;
        private float lastVal = 0;

        public UC_SensorValue()
        {
            InitializeComponent();
        }
        
        //neues element wird erstellt
        public UC_SensorValue(platform_control platform_control)
        {
            _platform_control = platform_control;
            //pic_set_edit_pic(t);
        }
        //element wird durch deserialisieren erstellt
        public UC_SensorValue(platform_control platform_control, int pos_x, int pos_y)
        {
            _platform_control = platform_control;
            Location = new Point(pos_x, pos_y);
            //pic_set_edit_pic(_platform_control._aktuator.GetAktType());

            update_label_text();
        }

        //bild für FrmConfigPlatform wird erstellt -> TODO: notwendig?
        //private void pic_set_edit_pic()
        //{
        //    Visible = true;
        //    Size = new Size(60, 60);
        //    this.BackColor = Color.Transparent;
        //    this.BringToFront();
        //    Image = PBdefaultControl.GetPicByType(t);
        //}

        public void updateValue(float value)
        {
            //no content changed to last request
            if (lastVal==value)
                return;

            label_sensorValue.Text = value.ToString();

            lastVal = value;
        }

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
            {
                //pikture box sollte gelöscht sein.....
                ;
            }
        }

    }
    
}
