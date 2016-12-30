namespace AH_DataLogger
{
    partial class FrmDataLogger
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.monthCalendar_start = new System.Windows.Forms.MonthCalendar();
            this.groupBox_weather_station = new System.Windows.Forms.GroupBox();
            this.checkBox_rain = new System.Windows.Forms.CheckBox();
            this.checkBox_wind_max = new System.Windows.Forms.CheckBox();
            this.checkBox_wind = new System.Windows.Forms.CheckBox();
            this.checkBox_light = new System.Windows.Forms.CheckBox();
            this.checkBox_sun_east = new System.Windows.Forms.CheckBox();
            this.checkBox_sun_west = new System.Windows.Forms.CheckBox();
            this.checkBox_sun_south = new System.Windows.Forms.CheckBox();
            this.checkBox_temperature = new System.Windows.Forms.CheckBox();
            this.groupBox_plc_sensorik = new System.Windows.Forms.GroupBox();
            this.checkBox_humidity_floor_eg = new System.Windows.Forms.CheckBox();
            this.checkBox_lux_stairs_og = new System.Windows.Forms.CheckBox();
            this.checkBox_temperatur_floor_eg = new System.Windows.Forms.CheckBox();
            this.checkBox_temperatur_stairs_og = new System.Windows.Forms.CheckBox();
            this.groupBox_eta_values = new System.Windows.Forms.GroupBox();
            this.checkBox_vorlauf = new System.Windows.Forms.CheckBox();
            this.checkBox_boiler_solar = new System.Windows.Forms.CheckBox();
            this.checkBox_kollektor = new System.Windows.Forms.CheckBox();
            this.checkBox_puffer_unten = new System.Windows.Forms.CheckBox();
            this.checkBox_puffer_mitte = new System.Windows.Forms.CheckBox();
            this.checkBox_puffer_oben = new System.Windows.Forms.CheckBox();
            this.checkBox_kesselruecklauf = new System.Windows.Forms.CheckBox();
            this.checkBox_abgas = new System.Windows.Forms.CheckBox();
            this.checkBox_kessel = new System.Windows.Forms.CheckBox();
            this.checkBox_aussentemperatur = new System.Windows.Forms.CheckBox();
            this.checkBox_pufferladezustand = new System.Windows.Forms.CheckBox();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.monthCalendar_end = new System.Windows.Forms.MonthCalendar();
            this.groupBox_weather_station.SuspendLayout();
            this.groupBox_plc_sensorik.SuspendLayout();
            this.groupBox_eta_values.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.SuspendLayout();
            // 
            // monthCalendar_start
            // 
            this.monthCalendar_start.Location = new System.Drawing.Point(706, 12);
            this.monthCalendar_start.Name = "monthCalendar_start";
            this.monthCalendar_start.TabIndex = 19;
            this.monthCalendar_start.DateChanged += new System.Windows.Forms.DateRangeEventHandler(this.monthCalendar_start_DateChanged);
            // 
            // groupBox_weather_station
            // 
            this.groupBox_weather_station.Controls.Add(this.checkBox_rain);
            this.groupBox_weather_station.Controls.Add(this.checkBox_wind_max);
            this.groupBox_weather_station.Controls.Add(this.checkBox_wind);
            this.groupBox_weather_station.Controls.Add(this.checkBox_light);
            this.groupBox_weather_station.Controls.Add(this.checkBox_sun_east);
            this.groupBox_weather_station.Controls.Add(this.checkBox_sun_west);
            this.groupBox_weather_station.Controls.Add(this.checkBox_sun_south);
            this.groupBox_weather_station.Controls.Add(this.checkBox_temperature);
            this.groupBox_weather_station.Location = new System.Drawing.Point(492, 12);
            this.groupBox_weather_station.Name = "groupBox_weather_station";
            this.groupBox_weather_station.Size = new System.Drawing.Size(171, 118);
            this.groupBox_weather_station.TabIndex = 18;
            this.groupBox_weather_station.TabStop = false;
            this.groupBox_weather_station.Text = "weather station";
            // 
            // checkBox_rain
            // 
            this.checkBox_rain.AutoSize = true;
            this.checkBox_rain.Location = new System.Drawing.Point(94, 88);
            this.checkBox_rain.Name = "checkBox_rain";
            this.checkBox_rain.Size = new System.Drawing.Size(43, 17);
            this.checkBox_rain.TabIndex = 7;
            this.checkBox_rain.Text = "rain";
            this.checkBox_rain.UseVisualStyleBackColor = true;
            this.checkBox_rain.CheckedChanged += new System.EventHandler(this.checkBox_rain_CheckedChanged);
            // 
            // checkBox_wind_max
            // 
            this.checkBox_wind_max.AutoSize = true;
            this.checkBox_wind_max.Location = new System.Drawing.Point(94, 65);
            this.checkBox_wind_max.Name = "checkBox_wind_max";
            this.checkBox_wind_max.Size = new System.Drawing.Size(73, 17);
            this.checkBox_wind_max.TabIndex = 6;
            this.checkBox_wind_max.Text = "wind_max";
            this.checkBox_wind_max.UseVisualStyleBackColor = true;
            this.checkBox_wind_max.CheckedChanged += new System.EventHandler(this.checkBox_wind_max_CheckedChanged);
            // 
            // checkBox_wind
            // 
            this.checkBox_wind.AutoSize = true;
            this.checkBox_wind.Location = new System.Drawing.Point(94, 42);
            this.checkBox_wind.Name = "checkBox_wind";
            this.checkBox_wind.Size = new System.Drawing.Size(48, 17);
            this.checkBox_wind.TabIndex = 5;
            this.checkBox_wind.Text = "wind";
            this.checkBox_wind.UseVisualStyleBackColor = true;
            this.checkBox_wind.CheckedChanged += new System.EventHandler(this.checkBox_wind_CheckedChanged);
            // 
            // checkBox_light
            // 
            this.checkBox_light.AutoSize = true;
            this.checkBox_light.Location = new System.Drawing.Point(94, 19);
            this.checkBox_light.Name = "checkBox_light";
            this.checkBox_light.Size = new System.Drawing.Size(45, 17);
            this.checkBox_light.TabIndex = 4;
            this.checkBox_light.Text = "light";
            this.checkBox_light.UseVisualStyleBackColor = true;
            this.checkBox_light.CheckedChanged += new System.EventHandler(this.checkBox_light_CheckedChanged);
            // 
            // checkBox_sun_east
            // 
            this.checkBox_sun_east.AutoSize = true;
            this.checkBox_sun_east.Location = new System.Drawing.Point(6, 88);
            this.checkBox_sun_east.Name = "checkBox_sun_east";
            this.checkBox_sun_east.Size = new System.Drawing.Size(69, 17);
            this.checkBox_sun_east.TabIndex = 3;
            this.checkBox_sun_east.Text = "sun_east";
            this.checkBox_sun_east.UseVisualStyleBackColor = true;
            this.checkBox_sun_east.CheckedChanged += new System.EventHandler(this.checkBox_sun_east_CheckedChanged);
            // 
            // checkBox_sun_west
            // 
            this.checkBox_sun_west.AutoSize = true;
            this.checkBox_sun_west.Location = new System.Drawing.Point(6, 65);
            this.checkBox_sun_west.Name = "checkBox_sun_west";
            this.checkBox_sun_west.Size = new System.Drawing.Size(71, 17);
            this.checkBox_sun_west.TabIndex = 2;
            this.checkBox_sun_west.Text = "sun_west";
            this.checkBox_sun_west.UseVisualStyleBackColor = true;
            this.checkBox_sun_west.CheckedChanged += new System.EventHandler(this.checkBox_sun_west_CheckedChanged);
            // 
            // checkBox_sun_south
            // 
            this.checkBox_sun_south.AutoSize = true;
            this.checkBox_sun_south.Location = new System.Drawing.Point(6, 42);
            this.checkBox_sun_south.Name = "checkBox_sun_south";
            this.checkBox_sun_south.Size = new System.Drawing.Size(75, 17);
            this.checkBox_sun_south.TabIndex = 1;
            this.checkBox_sun_south.Text = "sun_south";
            this.checkBox_sun_south.UseVisualStyleBackColor = true;
            this.checkBox_sun_south.CheckedChanged += new System.EventHandler(this.checkBox_sun_south_CheckedChanged);
            // 
            // checkBox_temperature
            // 
            this.checkBox_temperature.AutoSize = true;
            this.checkBox_temperature.Location = new System.Drawing.Point(6, 19);
            this.checkBox_temperature.Name = "checkBox_temperature";
            this.checkBox_temperature.Size = new System.Drawing.Size(82, 17);
            this.checkBox_temperature.TabIndex = 0;
            this.checkBox_temperature.Text = "temperature";
            this.checkBox_temperature.UseVisualStyleBackColor = true;
            this.checkBox_temperature.CheckedChanged += new System.EventHandler(this.checkBox_temperature_CheckedChanged);
            // 
            // groupBox_plc_sensorik
            // 
            this.groupBox_plc_sensorik.Controls.Add(this.checkBox_humidity_floor_eg);
            this.groupBox_plc_sensorik.Controls.Add(this.checkBox_lux_stairs_og);
            this.groupBox_plc_sensorik.Controls.Add(this.checkBox_temperatur_floor_eg);
            this.groupBox_plc_sensorik.Controls.Add(this.checkBox_temperatur_stairs_og);
            this.groupBox_plc_sensorik.Location = new System.Drawing.Point(353, 12);
            this.groupBox_plc_sensorik.Name = "groupBox_plc_sensorik";
            this.groupBox_plc_sensorik.Size = new System.Drawing.Size(133, 118);
            this.groupBox_plc_sensorik.TabIndex = 17;
            this.groupBox_plc_sensorik.TabStop = false;
            this.groupBox_plc_sensorik.Text = "sensorik";
            // 
            // checkBox_humidity_floor_eg
            // 
            this.checkBox_humidity_floor_eg.AutoSize = true;
            this.checkBox_humidity_floor_eg.Location = new System.Drawing.Point(6, 88);
            this.checkBox_humidity_floor_eg.Name = "checkBox_humidity_floor_eg";
            this.checkBox_humidity_floor_eg.Size = new System.Drawing.Size(108, 17);
            this.checkBox_humidity_floor_eg.TabIndex = 3;
            this.checkBox_humidity_floor_eg.Text = "humidity_floor_eg";
            this.checkBox_humidity_floor_eg.UseVisualStyleBackColor = true;
            this.checkBox_humidity_floor_eg.CheckedChanged += new System.EventHandler(this.checkBox_humidity_floor_eg_CheckedChanged);
            // 
            // checkBox_lux_stairs_og
            // 
            this.checkBox_lux_stairs_og.AutoSize = true;
            this.checkBox_lux_stairs_og.Location = new System.Drawing.Point(6, 65);
            this.checkBox_lux_stairs_og.Name = "checkBox_lux_stairs_og";
            this.checkBox_lux_stairs_og.Size = new System.Drawing.Size(87, 17);
            this.checkBox_lux_stairs_og.TabIndex = 2;
            this.checkBox_lux_stairs_og.Text = "lux_stairs_og";
            this.checkBox_lux_stairs_og.UseVisualStyleBackColor = true;
            this.checkBox_lux_stairs_og.CheckedChanged += new System.EventHandler(this.checkBox_lux_stairs_og_CheckedChanged);
            // 
            // checkBox_temperatur_floor_eg
            // 
            this.checkBox_temperatur_floor_eg.AutoSize = true;
            this.checkBox_temperatur_floor_eg.Location = new System.Drawing.Point(6, 42);
            this.checkBox_temperatur_floor_eg.Name = "checkBox_temperatur_floor_eg";
            this.checkBox_temperatur_floor_eg.Size = new System.Drawing.Size(120, 17);
            this.checkBox_temperatur_floor_eg.TabIndex = 1;
            this.checkBox_temperatur_floor_eg.Text = "temperatur_floor_eg";
            this.checkBox_temperatur_floor_eg.UseVisualStyleBackColor = true;
            this.checkBox_temperatur_floor_eg.CheckedChanged += new System.EventHandler(this.checkBox_temperatur_floor_eg_CheckedChanged);
            // 
            // checkBox_temperatur_stairs_og
            // 
            this.checkBox_temperatur_stairs_og.AutoSize = true;
            this.checkBox_temperatur_stairs_og.Location = new System.Drawing.Point(6, 19);
            this.checkBox_temperatur_stairs_og.Name = "checkBox_temperatur_stairs_og";
            this.checkBox_temperatur_stairs_og.Size = new System.Drawing.Size(124, 17);
            this.checkBox_temperatur_stairs_og.TabIndex = 0;
            this.checkBox_temperatur_stairs_og.Text = "temperatur_stairs_og";
            this.checkBox_temperatur_stairs_og.UseVisualStyleBackColor = true;
            this.checkBox_temperatur_stairs_og.CheckedChanged += new System.EventHandler(this.checkBox_temperatur_stairs_og_CheckedChanged);
            // 
            // groupBox_eta_values
            // 
            this.groupBox_eta_values.Controls.Add(this.checkBox_vorlauf);
            this.groupBox_eta_values.Controls.Add(this.checkBox_boiler_solar);
            this.groupBox_eta_values.Controls.Add(this.checkBox_kollektor);
            this.groupBox_eta_values.Controls.Add(this.checkBox_puffer_unten);
            this.groupBox_eta_values.Controls.Add(this.checkBox_puffer_mitte);
            this.groupBox_eta_values.Controls.Add(this.checkBox_puffer_oben);
            this.groupBox_eta_values.Controls.Add(this.checkBox_kesselruecklauf);
            this.groupBox_eta_values.Controls.Add(this.checkBox_abgas);
            this.groupBox_eta_values.Controls.Add(this.checkBox_kessel);
            this.groupBox_eta_values.Controls.Add(this.checkBox_aussentemperatur);
            this.groupBox_eta_values.Controls.Add(this.checkBox_pufferladezustand);
            this.groupBox_eta_values.Location = new System.Drawing.Point(12, 12);
            this.groupBox_eta_values.Name = "groupBox_eta_values";
            this.groupBox_eta_values.Size = new System.Drawing.Size(335, 118);
            this.groupBox_eta_values.TabIndex = 16;
            this.groupBox_eta_values.TabStop = false;
            this.groupBox_eta_values.Text = "eta";
            // 
            // checkBox_vorlauf
            // 
            this.checkBox_vorlauf.AutoSize = true;
            this.checkBox_vorlauf.Location = new System.Drawing.Point(6, 88);
            this.checkBox_vorlauf.Name = "checkBox_vorlauf";
            this.checkBox_vorlauf.Size = new System.Drawing.Size(58, 17);
            this.checkBox_vorlauf.TabIndex = 10;
            this.checkBox_vorlauf.Text = "vorlauf";
            this.checkBox_vorlauf.UseVisualStyleBackColor = true;
            this.checkBox_vorlauf.CheckedChanged += new System.EventHandler(this.checkBox_vorlauf_CheckedChanged);
            // 
            // checkBox_boiler_solar
            // 
            this.checkBox_boiler_solar.AutoSize = true;
            this.checkBox_boiler_solar.Location = new System.Drawing.Point(218, 19);
            this.checkBox_boiler_solar.Name = "checkBox_boiler_solar";
            this.checkBox_boiler_solar.Size = new System.Drawing.Size(79, 17);
            this.checkBox_boiler_solar.TabIndex = 9;
            this.checkBox_boiler_solar.Text = "boiler_solar";
            this.checkBox_boiler_solar.UseVisualStyleBackColor = true;
            this.checkBox_boiler_solar.CheckedChanged += new System.EventHandler(this.checkBox_boiler_solar_CheckedChanged);
            // 
            // checkBox_kollektor
            // 
            this.checkBox_kollektor.AutoSize = true;
            this.checkBox_kollektor.Location = new System.Drawing.Point(218, 42);
            this.checkBox_kollektor.Name = "checkBox_kollektor";
            this.checkBox_kollektor.Size = new System.Drawing.Size(66, 17);
            this.checkBox_kollektor.TabIndex = 8;
            this.checkBox_kollektor.Text = "kollektor";
            this.checkBox_kollektor.UseVisualStyleBackColor = true;
            this.checkBox_kollektor.CheckedChanged += new System.EventHandler(this.checkBox_kollektor_CheckedChanged);
            // 
            // checkBox_puffer_unten
            // 
            this.checkBox_puffer_unten.AutoSize = true;
            this.checkBox_puffer_unten.Location = new System.Drawing.Point(102, 88);
            this.checkBox_puffer_unten.Name = "checkBox_puffer_unten";
            this.checkBox_puffer_unten.Size = new System.Drawing.Size(86, 17);
            this.checkBox_puffer_unten.TabIndex = 7;
            this.checkBox_puffer_unten.Text = "puffer_unten";
            this.checkBox_puffer_unten.UseVisualStyleBackColor = true;
            this.checkBox_puffer_unten.CheckedChanged += new System.EventHandler(this.checkBox_puffer_unten_CheckedChanged);
            // 
            // checkBox_puffer_mitte
            // 
            this.checkBox_puffer_mitte.AutoSize = true;
            this.checkBox_puffer_mitte.Location = new System.Drawing.Point(102, 65);
            this.checkBox_puffer_mitte.Name = "checkBox_puffer_mitte";
            this.checkBox_puffer_mitte.Size = new System.Drawing.Size(81, 17);
            this.checkBox_puffer_mitte.TabIndex = 6;
            this.checkBox_puffer_mitte.Text = "puffer_mitte";
            this.checkBox_puffer_mitte.UseVisualStyleBackColor = true;
            this.checkBox_puffer_mitte.CheckedChanged += new System.EventHandler(this.checkBox_puffer_mitte_CheckedChanged);
            // 
            // checkBox_puffer_oben
            // 
            this.checkBox_puffer_oben.AutoSize = true;
            this.checkBox_puffer_oben.Location = new System.Drawing.Point(102, 42);
            this.checkBox_puffer_oben.Name = "checkBox_puffer_oben";
            this.checkBox_puffer_oben.Size = new System.Drawing.Size(83, 17);
            this.checkBox_puffer_oben.TabIndex = 5;
            this.checkBox_puffer_oben.Text = "puffer_oben";
            this.checkBox_puffer_oben.UseVisualStyleBackColor = true;
            this.checkBox_puffer_oben.CheckedChanged += new System.EventHandler(this.checkBox_puffer_oben_CheckedChanged);
            // 
            // checkBox_kesselruecklauf
            // 
            this.checkBox_kesselruecklauf.AutoSize = true;
            this.checkBox_kesselruecklauf.Location = new System.Drawing.Point(5, 65);
            this.checkBox_kesselruecklauf.Name = "checkBox_kesselruecklauf";
            this.checkBox_kesselruecklauf.Size = new System.Drawing.Size(94, 17);
            this.checkBox_kesselruecklauf.TabIndex = 4;
            this.checkBox_kesselruecklauf.Text = "kesselrücklauf";
            this.checkBox_kesselruecklauf.UseVisualStyleBackColor = true;
            this.checkBox_kesselruecklauf.CheckedChanged += new System.EventHandler(this.checkBox_kesselruecklauf_CheckedChanged);
            // 
            // checkBox_abgas
            // 
            this.checkBox_abgas.AutoSize = true;
            this.checkBox_abgas.Location = new System.Drawing.Point(6, 42);
            this.checkBox_abgas.Name = "checkBox_abgas";
            this.checkBox_abgas.Size = new System.Drawing.Size(55, 17);
            this.checkBox_abgas.TabIndex = 3;
            this.checkBox_abgas.Text = "abgas";
            this.checkBox_abgas.UseVisualStyleBackColor = true;
            this.checkBox_abgas.CheckedChanged += new System.EventHandler(this.checkBox_abgas_CheckedChanged);
            // 
            // checkBox_kessel
            // 
            this.checkBox_kessel.AutoSize = true;
            this.checkBox_kessel.Location = new System.Drawing.Point(5, 19);
            this.checkBox_kessel.Name = "checkBox_kessel";
            this.checkBox_kessel.Size = new System.Drawing.Size(56, 17);
            this.checkBox_kessel.TabIndex = 2;
            this.checkBox_kessel.Text = "kessel";
            this.checkBox_kessel.UseVisualStyleBackColor = true;
            this.checkBox_kessel.CheckedChanged += new System.EventHandler(this.checkBox_kessel_CheckedChanged);
            // 
            // checkBox_aussentemperatur
            // 
            this.checkBox_aussentemperatur.AutoSize = true;
            this.checkBox_aussentemperatur.Location = new System.Drawing.Point(218, 65);
            this.checkBox_aussentemperatur.Name = "checkBox_aussentemperatur";
            this.checkBox_aussentemperatur.Size = new System.Drawing.Size(110, 17);
            this.checkBox_aussentemperatur.TabIndex = 1;
            this.checkBox_aussentemperatur.Text = "aussentemperatur";
            this.checkBox_aussentemperatur.UseVisualStyleBackColor = true;
            this.checkBox_aussentemperatur.CheckedChanged += new System.EventHandler(this.checkBox_aussentemperatur_CheckedChanged);
            // 
            // checkBox_pufferladezustand
            // 
            this.checkBox_pufferladezustand.AutoSize = true;
            this.checkBox_pufferladezustand.Location = new System.Drawing.Point(102, 19);
            this.checkBox_pufferladezustand.Name = "checkBox_pufferladezustand";
            this.checkBox_pufferladezustand.Size = new System.Drawing.Size(110, 17);
            this.checkBox_pufferladezustand.TabIndex = 0;
            this.checkBox_pufferladezustand.Text = "pufferladezustand";
            this.checkBox_pufferladezustand.UseVisualStyleBackColor = true;
            this.checkBox_pufferladezustand.CheckedChanged += new System.EventHandler(this.checkBox_pufferladezustand_CheckedChanged);
            // 
            // chart1
            // 
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(12, 186);
            this.chart1.Name = "chart1";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chart1.Series.Add(series1);
            this.chart1.Size = new System.Drawing.Size(1091, 646);
            this.chart1.TabIndex = 15;
            this.chart1.Text = "chart1";
            // 
            // monthCalendar_end
            // 
            this.monthCalendar_end.Location = new System.Drawing.Point(925, 12);
            this.monthCalendar_end.Name = "monthCalendar_end";
            this.monthCalendar_end.TabIndex = 20;
            this.monthCalendar_end.DateChanged += new System.Windows.Forms.DateRangeEventHandler(this.monthCalendar_end_DateChanged);
            // 
            // FrmDataLogger
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1118, 846);
            this.Controls.Add(this.monthCalendar_end);
            this.Controls.Add(this.monthCalendar_start);
            this.Controls.Add(this.groupBox_weather_station);
            this.Controls.Add(this.groupBox_plc_sensorik);
            this.Controls.Add(this.groupBox_eta_values);
            this.Controls.Add(this.chart1);
            this.Name = "FrmDataLogger";
            this.Text = "FrmMainDataLogger";
            this.groupBox_weather_station.ResumeLayout(false);
            this.groupBox_weather_station.PerformLayout();
            this.groupBox_plc_sensorik.ResumeLayout(false);
            this.groupBox_plc_sensorik.PerformLayout();
            this.groupBox_eta_values.ResumeLayout(false);
            this.groupBox_eta_values.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.MonthCalendar monthCalendar_start;
        private System.Windows.Forms.GroupBox groupBox_weather_station;
        private System.Windows.Forms.CheckBox checkBox_rain;
        private System.Windows.Forms.CheckBox checkBox_wind_max;
        private System.Windows.Forms.CheckBox checkBox_wind;
        private System.Windows.Forms.CheckBox checkBox_light;
        private System.Windows.Forms.CheckBox checkBox_sun_east;
        private System.Windows.Forms.CheckBox checkBox_sun_west;
        private System.Windows.Forms.CheckBox checkBox_sun_south;
        private System.Windows.Forms.CheckBox checkBox_temperature;
        private System.Windows.Forms.GroupBox groupBox_plc_sensorik;
        private System.Windows.Forms.CheckBox checkBox_humidity_floor_eg;
        private System.Windows.Forms.CheckBox checkBox_lux_stairs_og;
        private System.Windows.Forms.CheckBox checkBox_temperatur_floor_eg;
        private System.Windows.Forms.CheckBox checkBox_temperatur_stairs_og;
        private System.Windows.Forms.GroupBox groupBox_eta_values;
        private System.Windows.Forms.CheckBox checkBox_vorlauf;
        private System.Windows.Forms.CheckBox checkBox_boiler_solar;
        private System.Windows.Forms.CheckBox checkBox_kollektor;
        private System.Windows.Forms.CheckBox checkBox_puffer_unten;
        private System.Windows.Forms.CheckBox checkBox_puffer_mitte;
        private System.Windows.Forms.CheckBox checkBox_puffer_oben;
        private System.Windows.Forms.CheckBox checkBox_kesselruecklauf;
        private System.Windows.Forms.CheckBox checkBox_abgas;
        private System.Windows.Forms.CheckBox checkBox_kessel;
        private System.Windows.Forms.CheckBox checkBox_aussentemperatur;
        private System.Windows.Forms.CheckBox checkBox_pufferladezustand;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.MonthCalendar monthCalendar_end;
    }
}