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
        BindingList<aktuator> ListAktuatorTmp;

        public FrmStartupRunningConfig(object _ListPlc)
        {
            InitializeComponent();
            ListPlc = (List<plc>)_ListPlc;
            ListAktuatorTmp = new BindingList<aktuator>();
            InitDataGridView_plcs();
            InitDataGridView_aktuators();
            SendGetParamRequestToPlcs();
        }
        private void SendGetParamRequestToPlcs() {
            foreach (plc p in ListPlc)
                p.ReadRunningConfig();
        }

        private void InitDataGridView_plcs()
        {
            //ListPlc = new List<plc>();
            dataGridView_plcs.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            BindingSource bindingSource = new BindingSource();
            bindingSource.DataSource = ListPlc;
            dataGridView_plcs.AutoGenerateColumns = false;
            dataGridView_plcs.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridView_plcs.DataSource = bindingSource;

            DataGridViewTextBoxColumn DGVtbtimestamp = new DataGridViewTextBoxColumn();
            DGVtbtimestamp.Name = "Name";
            DGVtbtimestamp.DataPropertyName = "NamePlc";
            DGVtbtimestamp.ReadOnly = true;
            dataGridView_plcs.Columns.Add(DGVtbtimestamp);

            DataGridViewTextBoxColumn DGVtbcPrio = new DataGridViewTextBoxColumn();
            DGVtbcPrio.Name = "IP address";
            DGVtbcPrio.DataPropertyName = "IPplc";
            DGVtbcPrio.ReadOnly = true;

            dataGridView_plcs.Columns.Add(DGVtbcPrio);

            DataGridViewTextBoxColumn DGVtbMsg = new DataGridViewTextBoxColumn();
            DGVtbMsg.Name = "port";
            DGVtbMsg.DataPropertyName = "PortPlc";
            //DGVtbMsg.ValueType = typeof(string);
            dataGridView_plcs.Columns.Add(DGVtbMsg);
        }

        private void InitDataGridView_aktuators()
        {
            dataGridView_aktuators.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            BindingSource bindingSource = new BindingSource();
            bindingSource.DataSource = ListAktuatorTmp;
            dataGridView_aktuators.AutoGenerateColumns = false;
            dataGridView_aktuators.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridView_aktuators.DataSource = bindingSource;

            DataGridViewTextBoxColumn DGVtype = new DataGridViewTextBoxColumn();
            DGVtype.Name = "type";
            DGVtype.DataPropertyName = "AktorType";
            DGVtype.ReadOnly = true;
            dataGridView_aktuators.Columns.Add(DGVtype);

            DataGridViewTextBoxColumn DGVtbtimestamp = new DataGridViewTextBoxColumn();
            DGVtbtimestamp.Name = "akt Name";
            DGVtbtimestamp.DataPropertyName = "Name";
            DGVtbtimestamp.DefaultCellStyle.BackColor = Color.Green;
            DGVtbtimestamp.ReadOnly = true;
            dataGridView_aktuators.Columns.Add(DGVtbtimestamp);

            DataGridViewTextBoxColumn DGVtbcPrio = new DataGridViewTextBoxColumn();
            DGVtbcPrio.Name = "Index";
            DGVtbcPrio.DataPropertyName = "Index";
            DGVtbcPrio.ReadOnly = true;
            dataGridView_aktuators.Columns.Add(DGVtbcPrio);

            DataGridViewCheckBoxColumn DGVCB_equalConfig = new DataGridViewCheckBoxColumn();
            DGVCB_equalConfig.DataPropertyName = "ConfigsEqual";
            DGVCB_equalConfig.DefaultCellStyle.BackColor = ((Color)ConfigsEqualColor);
            dataGridView_aktuators.Columns.Add(DGVCB_equalConfig);

            DataGridViewTextBoxColumn DGVtbMsg = new DataGridViewTextBoxColumn();
            DGVtbMsg.Name = "Running Config";
            DGVtbMsg.DataPropertyName = "AktuatorRunningConfig";
            //DGVtbMsg.ValueType = typeof(Int16[]);
            DGVtbMsg.ReadOnly = true;
            dataGridView_aktuators.Columns.Add(DGVtbMsg);

            DataGridViewTextBoxColumn DGVtbSC = new DataGridViewTextBoxColumn();
            DGVtbSC.Name = "Startup Config";
            DGVtbSC.DataPropertyName = "AktuatorStartupConfig";
            DGVtbSC.ReadOnly = true;
            dataGridView_aktuators.Columns.Add(DGVtbSC);


        }

        private void updateDataGridView_aktuators() {
            ListAktuatorTmp.Clear();
            plc plc = dataGridView_plcs.SelectedRows[0].DataBoundItem as plc;

            foreach (aktuator a in plc.ListAktuator)
                ListAktuatorTmp.Add(a);
        }
        
        private void dataGridView_plcs_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            updateDataGridView_aktuators();
        }
        private UserControl ucdialog = null;

        public Color ConfigsEqualColor { get; private set; }

        private void dataGridView_aktuators_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            aktuator _akt = dataGridView_aktuators.SelectedRows[0].DataBoundItem as aktuator;
            //MessageBox.Show(_akt.Name + " " + _akt.AktorType,"add aktuator");
            panel_control.Controls.Clear();

            switch (_akt.AktorType)
            {
                case aktor_type.jalousie:
                    ucdialog = new UC_dialog_jalousie(_akt);
                    ((UC_dialog_jalousie)ucdialog).LoadData(_akt.ConfigAktuatorValuesRunning);
                    panel_control.Controls.Add(ucdialog);
                    break;
                case aktor_type.light:
                    ucdialog = new UC_dialog_light(_akt);
                    ((UC_dialog_light)ucdialog).LoadData(_akt.ConfigAktuatorValuesRunning);
                    panel_control.Controls.Add(ucdialog);
                    break;
                case aktor_type.heater:
                    //((UC_dialog_heater)ucdialog).LoadData(_akt.AktuatorRunningConfig);
                    panel_control.Controls.Add(new UC_dialog_heater(_akt).LoadData(_akt.ConfigAktuatorValuesRunning));
                    break;
                case aktor_type.undef:
                    ucdialog = new UC_dialog_undef(_akt);
                    ((UC_dialog_undef)ucdialog).LoadData(_akt.ConfigAktuatorValuesRunning);
                    panel_control.Controls.Add(ucdialog);
                    break;
                case aktor_type.sensor:
                    Label lsensor = new Label();
                    lsensor.Text = "aktor_type.sensor: " + _akt.Name;
                    panel_control.Controls.Add(lsensor);
                    break;
                default:
                    Label lerror = new Label();
                    lerror.Text = "ERROR unknown aktor_type";
                    panel_control.Controls.Add(lerror);
                    break;
                    
            }
            //EXCEPTION ucdialog==null  ->  this.Size = new Size(ucdialog.Size.Width + 6, ucdialog.Size.Height + 29);
            
        }

        private void dataGridView_aktuators_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {

        }

        private void dataGridView_aktuators_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            aktuator _akt = dataGridView_aktuators.SelectedRows[0].DataBoundItem as aktuator;
            DialogResult dr = MessageBox.Show("Copy Running to Startup Config?", _akt.Name, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
            if (dr == DialogResult.Yes) 
                _akt.copyRunningToStartConfig();
            
            
        }

        private void dataGridView_aktuators_CellStateChanged(object sender, DataGridViewCellStateChangedEventArgs e)
        {
            if (e.Cell is DataGridViewCheckBoxCell)
                e.Cell.Style.BackColor = Color.Red;
            else
                e.Cell.Style.BackColor = Color.Green;
        }

        private void dataGridView_aktuators_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
