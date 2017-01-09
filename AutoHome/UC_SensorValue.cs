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
            label_sensorValue.Visible = false;
        }
        //element wird durch deserialisieren erstellt
        public UC_SensorValue(platform_control platform_control, int pos_x, int pos_y)
        {
            _platform_control = platform_control;
            Location = new Point(pos_x, pos_y);
            init_fill_content();
            //this.BackColor = Color.AliceBlue;
            //this.BorderStyle = BorderStyle.FixedSingle;
            //update_label_text();
        }

        private void init_fill_content() {
            label_sensorName = new Label();
            label_sensorValue = new Label();
            label_sensorName.Location = new Point(2, 2);
            label_sensorValue.Location = new Point(2, 24);
            label_sensorName.BackColor = Color.GreenYellow;//Color.Transparent;
            label_sensorValue.BackColor = Color.GreenYellow; 

            if (_platform_control != null && _platform_control._aktuator != null)
                label_sensorName.Text = _platform_control._aktuator.name();
            else
                label_sensorName.Text = "choose";
            label_sensorValue.Text = "0";

            this.Controls.Add(label_sensorName);
            this.Controls.Add(label_sensorValue);

            Size = new Size(100, 40);
            //this.BackColor = Color.Transparent;
            this.BackColor = Color.AliceBlue;
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

        public void updateValue(float value)
        {
            //no content changed to last request
            if (lastVal==value)
                return;
            if(label_sensorValue!=null)
                label_sensorValue.Text = value.ToString();
            label_sensorValue.Visible = true;
            lastVal = value;
        }

    }
    
}
