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

            DataGridViewTextBoxColumn DGVtbtimestamp = new DataGridViewTextBoxColumn();
            DGVtbtimestamp.Name = "akt Name";
            DGVtbtimestamp.DataPropertyName = "Name";
            DGVtbtimestamp.ReadOnly = true;
            dataGridView_aktuators.Columns.Add(DGVtbtimestamp);

            DataGridViewTextBoxColumn DGVtbcPrio = new DataGridViewTextBoxColumn();
            DGVtbcPrio.Name = "Index";
            DGVtbcPrio.DataPropertyName = "Index";
            DGVtbcPrio.ReadOnly = true;
            dataGridView_aktuators.Columns.Add(DGVtbcPrio);

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
    }
}
