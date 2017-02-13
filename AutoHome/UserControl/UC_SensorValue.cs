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
        public platform_control _platform_control;
        Label label_sensorName;
        Label label_sensorValue;
        private float lastVal = 0;

        //neues element wird erstellt
        public UC_SensorValue(platform_control platform_control)
        {
            _platform_control = platform_control;
            init_fill_content();
            //label_sensorValue.Visible = false;
        }
        //element wird durch deserialisieren erstellt
        public UC_SensorValue(platform_control platform_control, int pos_x, int pos_y)
        {
            _platform_control = platform_control;
            Location = new Point(pos_x, pos_y);
            init_fill_content();
        }

        private void init_fill_content() {
            label_sensorName = new Label();
            label_sensorValue = new Label();
            label_sensorName.Tag = this; //Label überdeckt UC -> damit in FrmPlatformConfig über event handler des Labels auf UC zugegriffen werden kann
            label_sensorValue.Tag = this; //Label überdeckt UC -> damit in FrmPlatformConfig über event handler des Labels auf UC zugegriffen werden kann
            label_sensorName.AutoSize = true; 
            label_sensorName.Location = new Point(0, 0);
            label_sensorValue.Location = new Point(0, 13);
            //label_sensorName.BackColor = Color.GreenYellow;
            //label_sensorValue.BackColor = Color.GreenYellow; 
            label_sensorValue.Font = new Font(label_sensorName.Font, FontStyle.Bold); //besser lesbar mit hintergrundbild

            if (_platform_control != null && _platform_control._aktuator != null)
                label_sensorName.Text = _platform_control._aktuator.Name;
            else
                label_sensorName.Text = "choose";
            label_sensorValue.Text = "0";

            this.Controls.Add(label_sensorName);
            this.Controls.Add(label_sensorValue);

            Size = new Size(label_sensorName.Size.Width + 5, 28);
            this.BackColor = Color.Transparent;
            //this.BackColor = Color.AliceBlue;
            this.BorderStyle = BorderStyle.FixedSingle;
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

        /// <summary>
        /// call from FrmPlatformConfig if aktuator of control is changed or set
        /// </summary>
        public void update_label_text()
        {
            if (_platform_control._aktuator != null)
                label_sensorName.Text = _platform_control._aktuator.Name;
            else
                log.msg(this, "call update_label_text() with _platform_control._aktuator == null");
            Size = new Size(label_sensorName.Size.Width + 5, 28);
            log.msg(this, "label_sensorName.Width: " + label_sensorName.Width.ToString());
        }

        public void updateValue(float value)
        {
            //no content changed to last request
            if (lastVal==value)
                return;
            if(label_sensorValue!=null)
                label_sensorValue.Text = value.ToString();
            //label_sensorValue.Visible = true;
            lastVal = value;
        }

    }
    
}
