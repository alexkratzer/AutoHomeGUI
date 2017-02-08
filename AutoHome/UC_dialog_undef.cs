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
    public partial class UC_dialog_undef : UserControl, IdialogUpdate
    {
        aktuator _aktor = null;
        public UC_dialog_undef(object aktor)
        {
            InitializeComponent();
            _aktor = (aktuator)aktor;
            label_index.Text = _aktor.Index.ToString();
            label_name.Text = _aktor.Name;
            label_type.Text = _aktor.AktorType.ToString();
            if (_aktor._plc != null)
                label_plc.Text = _aktor._plc.ToString();
            else
                label_plc.Text = "ERROR: plc = null";
        }

        public void LoadData(object _value)
        {
            Int16[] value = (Int16[])_value;
            
            label_frame.Text = "frame: " + value.ToString();
        }
    }
}
