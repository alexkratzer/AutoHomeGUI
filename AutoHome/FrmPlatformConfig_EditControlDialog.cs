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
    public partial class FrmPlatformConfig_EditControlDialog : Form
    {
        //List<aktuator> _list_a;
        List<plc> _list_plc;
        platform_control _platform_control = null;

        public FrmPlatformConfig_EditControlDialog(object platform_control, object list_plc, int selected_plc)
        {
            InitializeComponent();
            if (platform_control == null)
                MessageBox.Show("platform_control == null", "Exception");
            if (list_plc == null)
                MessageBox.Show("list_plc == null", "Exception");

            _platform_control = (platform_control)platform_control;
            _list_plc = (List<plc>)list_plc;
            comboBox_plc.DataSource = _list_plc;
            if(selected_plc!=0)
                comboBox_plc.SelectedIndex = selected_plc;
            
            fill_selectable();

            if (_platform_control._aktuator != null)
            {
                fill_content(_platform_control._aktuator);
                comboBox_aktor_name.SelectedItem = _platform_control._aktuator;
            }
            else
                this.WindowTitle = "select aktuator";
        }

        /// <summary>
        /// Legt den Fenstertext fest oder gibt diesen zurück.
        /// </summary>
        public string WindowTitle
        {
            get { return this.Text; }
            set { this.Text = value; }
        }

        private void comboBox_aktor_name_SelectedIndexChanged(object sender, EventArgs e)
        {
            fill_content((aktuator)comboBox_aktor_name.SelectedItem);
        }

        private void bttCancel_Click(object sender, EventArgs e)
        {        }

        private void fill_content(aktuator a) {
            label_id.Text = a.Index.ToString();
            label_type.Text = a.AktorType.ToString(); 
            label_aktuator_name.Text = a.Name;
            this.WindowTitle = "edit: " + a.Name;
            _platform_control._aktuator = a;
        }

        public object get_aktuator() {
            return _platform_control._aktuator;
        }
        public int get_selected_plc() {
            return comboBox_plc.SelectedIndex;
        }

        private void fill_selectable() {
            comboBox_aktor_name.Items.Clear();
            foreach (aktuator akt in ((plc)comboBox_plc.SelectedItem).ListAktuator)
            {
                if (akt.AktorType == _platform_control._type)
                    if (comboBox_plc.SelectedItem != null)
                    {
                        if (comboBox_plc.SelectedItem == akt._plc)
                            comboBox_aktor_name.Items.Add(akt);
                    }
                    else
                        log.msg(this, "fill_selectable() TODO comboBox_aktor_name.Items.Add(akt); ");
            }
        }

        private void FrmConfigPlatform_controlDialog_Load(object sender, EventArgs e)
        {

        }

        private void bttOK_Click(object sender, EventArgs e)
        {

        }

        private void button_delete_Click(object sender, EventArgs e)
        {

        }

        private void comboBox_plc_SelectedIndexChanged(object sender, EventArgs e)
        {
            fill_selectable();
        }
    }
}
