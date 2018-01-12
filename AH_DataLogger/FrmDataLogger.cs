using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Windows.Forms.DataVisualization.Charting;

namespace AH_DataLogger
{
    public partial class FrmDataLogger : Form
    {
        string con_string;
        bool connection_valid = true;

        public FrmDataLogger(string DBServerIp, string DBName, string DBUid, string DBPwd)
        {
            InitializeComponent();
            con_string = "Server=" + DBServerIp + ";Database=" + DBName + ";Uid=" + DBUid + ";Pwd=" + DBPwd;
            monthCalendar_start.SelectionStart = DateTime.Now.AddDays(-7);
            monthCalendar_end.SelectionStart = DateTime.Now;
            //update(); -> update ist bei monthCalender implizit mit dabei
        }
        private void update()
        {
            if (connection_valid)
            {
                if (connect_DB())
                {
                    series_init(); //make new series
                    charttype(); //change charttype to line
                    chart1.Series.Clear(); //remove existing series
                    load(); //read dataset from Database and fill series
                    check_series(); //print series if checkbox is checked
                    con.Close();
                }
            }
            else
                MessageBox.Show("connection_valid == false ", "error update()");
        }

        #region connect
        public MySqlConnection con;
        //private void FrmStatistic_FormClosing(object sender, FormClosingEventArgs e)
        //{
        //    if (con != null)
        //        con.Close();
        //}
        
        //ersetzt durch unten
        private bool connect_DB()
        {

            try
            {
                con = new MySqlConnection(con_string);
                con.Open();

                MySqlCommand cmd = new MySqlCommand("SELECT VERSION()", con);
                this.Text = "Statistic SQL-Version: " + Convert.ToString(cmd.ExecuteScalar());
                return true;
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
            connection_valid = false;
            return false;
        }


        #endregion

        #region series
        #region eta
        Series kessel;
        Series abgas;
        Series pufferladezustand;
        Series puffer_oben;
        Series puffer_mitte;
        Series puffer_unten;
        Series kesselruecklauf;
        Series kollektor;
        Series boiler_solar;
        Series aussentemperatur;
        Series vorlauf;
        #endregion
        #region plc_values
        Series temperatur_stairs_og;
        Series temperatur_floor_eg;
        Series lux_stairs_og;
        Series humidity_floor_eg;
        #endregion
        #region weather_station
        Series temperature;
        Series sun_south;
        Series sun_west;
        Series sun_east;
        Series light;
        Series wind;
        Series wind_max;
        Series rain;
        #endregion
        private void series_init() {
            #region eta
            kessel = new Series("kessel");
            abgas = new Series("abgas");
            pufferladezustand = new Series("pufferladezustand");
            puffer_oben = new Series("puffer_oben");
            puffer_mitte = new Series("puffer_mitte");
            puffer_unten = new Series("puffer_unten");
            kesselruecklauf = new Series("kesselruecklauf");
            kollektor = new Series("kollektor");
            boiler_solar = new Series("boiler_solar");
            aussentemperatur = new Series("aussentemperatur");
            vorlauf = new Series("vorlauf");
            #endregion
            #region plc_values
            temperatur_stairs_og = new Series("temperatur_stairs_og");
            temperatur_floor_eg = new Series("temperatur_floor_eg");
            lux_stairs_og = new Series("lux_stairs_og");
            humidity_floor_eg = new Series("humidity_floor_eg");
            #endregion
            #region weather_station
            temperature = new Series("temperature");
            sun_south = new Series("sun_south");
            sun_west = new Series("sun_west");
            sun_east = new Series("sun_east");
            light = new Series("light");
            wind = new Series("wind");
            wind_max = new Series("wind_max");
            rain = new Series("rain");
            #endregion
        }
        private void charttype() {
            kessel.ChartType = SeriesChartType.Line;
            abgas.ChartType = SeriesChartType.Line;
            pufferladezustand.ChartType = SeriesChartType.Line;
            puffer_oben.ChartType = SeriesChartType.Line;
            puffer_mitte.ChartType = SeriesChartType.Line;
            puffer_unten.ChartType = SeriesChartType.Line;
            kesselruecklauf.ChartType = SeriesChartType.Line;
            kollektor.ChartType = SeriesChartType.Line;
            boiler_solar.ChartType = SeriesChartType.Line;
            aussentemperatur.ChartType = SeriesChartType.Line;
            vorlauf.ChartType = SeriesChartType.Line;
            temperatur_stairs_og.ChartType = SeriesChartType.Line;
            temperatur_floor_eg.ChartType = SeriesChartType.Line;
            lux_stairs_og.ChartType = SeriesChartType.Line;
            humidity_floor_eg.ChartType = SeriesChartType.Line;
            temperature.ChartType = SeriesChartType.Line;
            sun_south.ChartType = SeriesChartType.Line;
            sun_west.ChartType = SeriesChartType.Line;
            sun_east.ChartType = SeriesChartType.Line;
            light.ChartType = SeriesChartType.Line;
            wind.ChartType = SeriesChartType.Line;
            wind_max.ChartType = SeriesChartType.Line;
            rain.ChartType = SeriesChartType.Line;
        }
        #endregion

        #region update
        MySqlDataReader rdr = null;
        private void load()
        {
            try
            {
                //MySqlCommand cmd = new MySqlCommand("SELECT * FROM eta_values WHERE cur_time > " + monthCalendar_start.SelectionStart.ToString("yyyy-MM-dd HH:mm:ss"), con);
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM eta_values WHERE cur_time > \"" + 
                    monthCalendar_start.SelectionStart.ToString("yyyy-MM-dd") + "\"" +
                    " AND cur_time < \"" +
                    monthCalendar_end.SelectionStart.ToString("yyyy-MM-dd") + "\"", con);
                
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                string datetime = rdr.GetDateTime("cur_time").ToString();
                kessel.Points.AddXY(datetime, rdr.GetDecimal("kessel").ToString().Replace(',', '.'));
                abgas.Points.AddXY(datetime, rdr.GetDecimal("abgas").ToString().Replace(',', '.'));
                pufferladezustand.Points.AddXY(datetime, rdr.GetInt16("pufferladezustand").ToString());
                puffer_oben.Points.AddXY(datetime, rdr.GetDecimal("puffer_oben").ToString().Replace(',', '.'));
                puffer_mitte.Points.AddXY(datetime, rdr.GetDecimal("puffer_mitte").ToString().Replace(',', '.'));
                puffer_unten.Points.AddXY(datetime, rdr.GetDecimal("puffer_unten").ToString().Replace(',', '.'));
                kesselruecklauf.Points.AddXY(datetime, rdr.GetDecimal("kesselruecklauf").ToString().Replace(',', '.'));
                kollektor.Points.AddXY(datetime, rdr.GetDecimal("kollektor").ToString().Replace(',', '.'));
                boiler_solar.Points.AddXY(datetime, rdr.GetDecimal("boiler_solar").ToString().Replace(',', '.'));
                aussentemperatur.Points.AddXY(datetime, rdr.GetDecimal("aussentemperatur").ToString().Replace(',','.'));
                vorlauf.Points.AddXY(datetime, rdr.GetDecimal("vorlauf").ToString().Replace(',', '.'));
                }
                rdr.Close();

                cmd = new MySqlCommand("SELECT * FROM plc_sensorik WHERE cur_time > \"" + monthCalendar_start.SelectionStart.ToString("yyyy-MM-dd") + "\"", con);
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                string datetime = rdr.GetDateTime("cur_time").ToString();
                temperatur_stairs_og.Points.AddXY(datetime, rdr.GetDecimal("temperatur_stairs_og").ToString().Replace(',', '.'));
                temperatur_floor_eg.Points.AddXY(datetime, rdr.GetDecimal("temperatur_floor_eg").ToString().Replace(',', '.'));
                lux_stairs_og.Points.AddXY(datetime, rdr.GetDecimal("lux_stairs_og").ToString().Replace(',', '.'));
                humidity_floor_eg.Points.AddXY(datetime, rdr.GetDecimal("humidity_floor_eg").ToString().Replace(',', '.'));
                }
                rdr.Close();

                cmd = new MySqlCommand("SELECT * FROM weather_station WHERE cur_time > \"" + monthCalendar_start.SelectionStart.ToString("yyyy-MM-dd") + "\"", con);
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    string datetime = rdr.GetDateTime("cur_time").ToString();
                    temperature.Points.AddXY(datetime, rdr.GetDecimal("temperature").ToString().Replace(',', '.'));
                    sun_south.Points.AddXY(datetime, rdr.GetInt16("sun_south").ToString());
                    sun_west.Points.AddXY(datetime, rdr.GetInt16("sun_west").ToString());
                    sun_east.Points.AddXY(datetime, rdr.GetInt16("sun_east").ToString());
                    light.Points.AddXY(datetime, rdr.GetInt16("light").ToString());
                    wind.Points.AddXY(datetime, rdr.GetDecimal("wind").ToString().Replace(',', '.'));
                    wind_max.Points.AddXY(datetime, rdr.GetDecimal("wind_max").ToString().Replace(',', '.'));
                    rain.Points.AddXY(datetime, rdr.GetBoolean("rain").ToString());
                }
                rdr.Close();
            }
            catch (Exception ex)
            {
            MessageBox.Show("Error: " + ex.ToString());
            }
            
        }

        #endregion

        #region check series
        private void check_series()
        {
            if (checkBox_pufferladezustand.Checked)
                chart1.Series.Add(pufferladezustand);
            else
                chart1.Series.Remove(pufferladezustand);

            if (checkBox_aussentemperatur.Checked)
                chart1.Series.Add(aussentemperatur);
            else
                chart1.Series.Remove(aussentemperatur);

            if (checkBox_kessel.Checked)
                chart1.Series.Add(kessel);
            else
                chart1.Series.Remove(kessel);

            if (checkBox_abgas.Checked)
                chart1.Series.Add(abgas);
            else
                chart1.Series.Remove(abgas);

            if (checkBox_kesselruecklauf.Checked)
                chart1.Series.Add(kesselruecklauf);
            else
                chart1.Series.Remove(kesselruecklauf);

            if (checkBox_vorlauf.Checked)
                chart1.Series.Add(vorlauf);
            else
                chart1.Series.Remove(vorlauf);

            if (checkBox_puffer_oben.Checked)
                chart1.Series.Add(puffer_oben);
            else
                chart1.Series.Remove(puffer_oben);

            if (checkBox_puffer_mitte.Checked)
                chart1.Series.Add(puffer_mitte);
            else
                chart1.Series.Remove(puffer_mitte);

            if (checkBox_puffer_unten.Checked)
                chart1.Series.Add(puffer_unten);
            else
                chart1.Series.Remove(puffer_unten);

            if (checkBox_boiler_solar.Checked)
                chart1.Series.Add(boiler_solar);
            else
                chart1.Series.Remove(boiler_solar);

            if (checkBox_kollektor.Checked)
                chart1.Series.Add(kollektor);
            else
                chart1.Series.Remove(kollektor);

            //checked plc_sensorik
            if (checkBox_temperatur_stairs_og.Checked)
                chart1.Series.Add(temperatur_stairs_og);
            else
                chart1.Series.Remove(temperatur_stairs_og);

            if (checkBox_temperatur_floor_eg.Checked)
                chart1.Series.Add(temperatur_floor_eg);
            else
                chart1.Series.Remove(temperatur_floor_eg);

            if (checkBox_lux_stairs_og.Checked)
                chart1.Series.Add(lux_stairs_og);
            else
                chart1.Series.Remove(lux_stairs_og);

            if (checkBox_humidity_floor_eg.Checked)
                chart1.Series.Add(humidity_floor_eg);
            else
                chart1.Series.Remove(humidity_floor_eg);

            //checked weather_station
            if (checkBox_temperature.Checked)
                chart1.Series.Add(temperature);
            else
                chart1.Series.Remove(temperature);

            if (checkBox_sun_south.Checked)
                chart1.Series.Add(sun_south);
            else
                chart1.Series.Remove(sun_south);

            if (checkBox_sun_west.Checked)
                chart1.Series.Add(sun_west);
            else
                chart1.Series.Remove(sun_west);

            if (checkBox_sun_east.Checked)
                chart1.Series.Add(sun_east);
            else
                chart1.Series.Remove(sun_east);

            if (checkBox_light.Checked)
                chart1.Series.Add(light);
            else
                chart1.Series.Remove(light);

            if (checkBox_wind.Checked)
                chart1.Series.Add(wind);
            else
                chart1.Series.Remove(wind);

            if (checkBox_wind_max.Checked)
                chart1.Series.Add(wind_max);
            else
                chart1.Series.Remove(wind_max);

            if (checkBox_rain.Checked)
                chart1.Series.Add(rain);
            else
                chart1.Series.Remove(rain);
        }

        #region checked eta
        private void checkBox_pufferladezustand_CheckedChanged(object sender, EventArgs e)
        {
            update();
        }

        private void checkBox_aussentemperatur_CheckedChanged(object sender, EventArgs e)
        {
            update();
        }

        private void checkBox_kessel_CheckedChanged(object sender, EventArgs e)
        {
            update();
        }

        private void checkBox_abgas_CheckedChanged(object sender, EventArgs e)
        {
            update();
        }

        private void checkBox_kesselruecklauf_CheckedChanged(object sender, EventArgs e)
        {
            update();
        }

        private void checkBox_vorlauf_CheckedChanged(object sender, EventArgs e)
        {
            update();
        }

        private void checkBox_puffer_oben_CheckedChanged(object sender, EventArgs e)
        {
            update();
        }

        private void checkBox_puffer_mitte_CheckedChanged(object sender, EventArgs e)
        {
            update();
        }

        private void checkBox_puffer_unten_CheckedChanged(object sender, EventArgs e)
        {
            update();
        }

        private void checkBox_boiler_solar_CheckedChanged(object sender, EventArgs e)
        {
            update();
        }

        private void checkBox_kollektor_CheckedChanged(object sender, EventArgs e)
        {
            update();
        }

        #endregion

        #region checked plc_sensorik     
        private void checkBox_temperatur_stairs_og_CheckedChanged(object sender, EventArgs e)
        {
            update();
        }

        private void checkBox_temperatur_floor_eg_CheckedChanged(object sender, EventArgs e)
        {
            update();
        }

        private void checkBox_lux_stairs_og_CheckedChanged(object sender, EventArgs e)
        {
            update();
        }

        private void checkBox_humidity_floor_eg_CheckedChanged(object sender, EventArgs e)
        {
            update();
        }
        #endregion

        #region checked weather_station
        private void checkBox_temperature_CheckedChanged(object sender, EventArgs e)
        {
            update();
        }

        private void checkBox_sun_south_CheckedChanged(object sender, EventArgs e)
        {
            update();
        }

        private void checkBox_sun_west_CheckedChanged(object sender, EventArgs e)
        {
            update();
        }

        private void checkBox_sun_east_CheckedChanged(object sender, EventArgs e)
        {
            update();
        }

        private void checkBox_light_CheckedChanged(object sender, EventArgs e)
        {
            update();
        }

        private void checkBox_wind_CheckedChanged(object sender, EventArgs e)
        {
            update();
        }

        private void checkBox_wind_max_CheckedChanged(object sender, EventArgs e)
        {
            update();
        }

        private void checkBox_rain_CheckedChanged(object sender, EventArgs e)
        {
            update();
        }
        #endregion
        #endregion

        private void monthCalendar_start_DateChanged(object sender, DateRangeEventArgs e)
        {
            //SQL 2015-12-23 01:43:12
            this.Text = "Daten von " + monthCalendar_start.SelectionStart.ToString("yyyy-MM-dd") + " -> " + monthCalendar_end.SelectionStart.ToString("yyyy-MM-dd");
            update();
        }

        private void monthCalendar_end_DateChanged(object sender, DateRangeEventArgs e)
        {
            this.Text = "Daten von " + monthCalendar_start.SelectionStart.ToString("yyyy-MM-dd") + " -> " + monthCalendar_end.SelectionStart.ToString("yyyy-MM-dd");
            update();
        }

   }
}
