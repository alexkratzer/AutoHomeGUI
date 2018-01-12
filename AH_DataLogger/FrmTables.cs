using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace AH_DataLogger
{
    public partial class FrmTables : Form
    {
        string con_string;
        public FrmTables(string DBServerIp, string DBName, string DBUid, string DBPwd)
        {
            InitializeComponent();
            con_string = "Server=" + DBServerIp + ";Database=" + DBName + ";Uid=" + DBUid + ";Pwd=" + DBPwd;
            //comboBox_table.Items.Add("eta_burning_time");
            //comboBox_table.Items.Add("eta_values");
            //comboBox_table.Items.Add("plc_sensorik");
            //comboBox_table.Items.Add("weather_station");

            connect_DB();
            read_tables();
        }

        MySqlConnection con;
        private MySqlDataAdapter da = null;
        private DataSet ds = null;

        private void read_tables() {
            MySqlDataReader rdr = null;
            MySqlCommand cmd = new MySqlCommand("SHOW TABLES", con);
            List<string> tables = new List<string>();

            try
            {
                rdr = cmd.ExecuteReader();
                
                int rows = 0;
                if (rdr.HasRows)
                    while (rdr.Read())
                    {
                        tables.Add(rdr.GetString(0));
                        //r = new request_task(rdr.GetInt32(0), rdr.GetString(1), rdr.GetTimeSpan(2), rdr.GetTimeSpan(3), rdr.GetInt32(4), rdr.GetInt32(5));
                        rows++;
                    }
                if (rdr != null)
                    rdr.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Exception read_tables()");
            }
            foreach (string s in tables) {
                comboBox_table.Items.Add(s);
            }
        }

        private void FrmStatistic_expert_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (con != null)
                con.Close();
        }
        private void connect_DB() {
            try
            {
                con = new MySqlConnection(con_string);
                con.Open();
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                switch (ex.Number)
                {
                    case 0:
                        MessageBox.Show("Cannot connect to server.  Contact administrator");
                        break;
                    case 1045:
                        MessageBox.Show("Invalid username/password, please try again");
                        break;
                    default:
                        MessageBox.Show("MySqlException: " + ex.Number.ToString());
                        break;
                }
            }
            catch (Exception exp)
            {
                MessageBox.Show("SQL ERROR: " + exp.ToString());
            }

            MySqlCommand cmd = new MySqlCommand( "SELECT VERSION()", con);
            this.Text = "Statistic expert SQL-Version: " + Convert.ToString(cmd.ExecuteScalar());
        }


        private void comboBox_table_SelectedIndexChanged(object sender, EventArgs e)
        {
            read_db_data();
        }

        private void button_refresh_Click(object sender, EventArgs e)
        {
            read_db_data();
        }

        private void read_db_data() {
            string stm = "SELECT * FROM " + comboBox_table.Text;
            //string stm = "SELECT * FROM `eta_values` WHERE `cur_time` >= " + 2016-01-01 01:00:00"
            //string date_start = monthCalendar_start_ds.SelectionStart.ToString().Replace('.', '-');
            //string stm = "SELECT * FROM `eta_values` WHERE `cur_time` <= " + date_start;
            //MessageBox.Show(stm);

            try
            {
                ds = new DataSet();
                da = new MySqlDataAdapter(stm, con);
                da.Fill(ds, "srcTable");

                dataGridView1.DataSource = null;
                dataGridView1.DataSource = ds.Tables["srcTable"];
                if (textBox1.Text != String.Empty)
                    (dataGridView1.DataSource as DataTable).DefaultView.RowFilter = string.Format("source_plc = '{0}'", textBox1.Text);

                if (textBox_module.Text != String.Empty)
                    (dataGridView1.DataSource as DataTable).DefaultView.RowFilter = string.Format("module = '{0}'", textBox_module.Text);

                if (textBox2.Text != String.Empty)
                    (dataGridView1.DataSource as DataTable).DefaultView.RowFilter = string.Format("prio = '{0}'", textBox2.Text);



            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.ToString());
            }
        }
    }
}
