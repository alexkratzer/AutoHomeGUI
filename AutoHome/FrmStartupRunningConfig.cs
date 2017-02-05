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
    public partial class FrmStartupRunningConfig : Form
    {
        List<plc> ListPlc;
        public FrmStartupRunningConfig(object _ListPlc)
        {
            InitializeComponent();
            ListPlc = (List<plc>)_ListPlc;
            UpdateListPlc();
        }

        private void UpdateListPlc() {
            listBox_plcs.Items.Clear();
            
            foreach (plc p in ListPlc)
                listBox_plcs.Items.Add(p);
            //p.ShowRunningConfig()
        }

        private void updateAktuators() {
            listBox_aktors.Items.Clear();
            if (listBox_plcs.SelectedItem != null)
            {
                plc p = (plc)listBox_plcs.SelectedItem;

                foreach (aktuator a in p.ListAktuator)
                    listBox_aktors.Items.Add(a);
            }
            else { MessageBox.Show("listBox_plcs.SelectedItem == null", "ERROR"); }
        }

        private void listBox_plcs_SelectedIndexChanged(object sender, EventArgs e)
        {
            updateAktuators();
        }
    }
}
