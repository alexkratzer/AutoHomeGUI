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
    public partial class FrmLogPCS : Form
    {
        public FrmLogPCS()
        {
            InitializeComponent();
        }

        public void AddLog(string msg)
        {
            try
            {
                richTextBox_log.AppendText(DateTime.Now.ToString("mm:ss:ms") + " -- " + msg + Environment.NewLine);
            }
            catch (Exception) { };
        }
    }
}
