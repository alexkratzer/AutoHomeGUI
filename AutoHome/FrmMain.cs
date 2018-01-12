using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.IO;
using System.Threading;
using Ionic.Zip;
using cpsLIB;
using System.Runtime.InteropServices;

//**************************************************************************************
//#################################### TODO ###########################################
//**************************************************************************************

namespace AutoHome
{
    public enum aktor_type { undef, jalousie, light, heater, sensor }
    public enum msg_type { undef, info, warning, error }

    public partial class FrmMain : Form
    {
        public static readonly string tool_version = "V0.0.3";

        List<plc> list_plc = new List<plc>();
        List<platform> list_platform = new List<platform>();
        List<floor_plan> list_floor_plan = new List<floor_plan>();
        List<aktuator_control> list_aktuator_controls = new List<aktuator_control>(); //list to store userControls of aktuator
        public List<string> ListLogMsg = new List<string>();

        QueueRcvFromCps rcvQueue;
        cpsLIB.CpsNet CpsNet;

        #region init / connect / close
        public FrmMain()
        {
            InitializeComponent();
            load_projekt_data();

            init_gui();
            make_status_bar();

            initCps();
            init_timer();

            verifyDB();
        }

        private void load_projekt_data() {
            var.read_ini_file();
            list_plc = var.deserialize_plc();
            list_platform = var.deserialize_platform(list_plc);
            log.msg(this, "### start AutoHome GUI " + tool_version + " ###");
            ListLogMsg.Add("### start AutoHome GUI " + tool_version + " ###");
        }

        private void safe_projekt_data()
        {
            var.write_ini_file();
            var.serialize_platform(list_platform);
            var.serialize_plc(list_plc);
        }
        private void initCps()
        {
            rcvQueue = new QueueRcvFromCps(this, list_plc);
            CpsNet = new cpsLIB.CpsNet(rcvQueue, var.CpsNet_FrmStatusLog);
            CpsNet.serverSTART(var.CpsServerPort); 
             
            if (var.connect_to_plc_at_start)
            {
                //try to connect (send SYNC frame) with all projected plc´s
                foreach (plc p in list_plc)
                    p.connect(CpsNet);
            }
        }

        private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                var.LastPlatformView = comboBox_platform.SelectedIndex;
                //if(FrmStatusLog!=null)
                //var.LastShowFormFrameLog 
                timer_stop();
                TimerUpdateGui.Stop();
                CpsNet.cleanup();
            }
            catch (Exception ex)
            {
                log.exception(this, "closing main gui", ex);
            }
            finally {
                safe_projekt_data();
                list_plc.Clear();
                Thread.Sleep(150);
            }
            log.msg(this, "### close AutoHome GUI ###");
        }
        #endregion

        #region menue

        #region menue file
        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openfd = new OpenFileDialog();

            openfd.InitialDirectory = var.default_project_data_path;
            openfd.Filter = var.tool_text + " (*.zip)|*.zip";
            if (openfd.ShowDialog() == DialogResult.OK)
            {
                if (openfd.CheckFileExists)
                    zip(openfd.FileName, false);
                else
                    MessageBox.Show(openfd.FileName + "error: file doesent exist!");
                MessageBox.Show("reading project data: " + openfd.FileName, "finish");
                load_projekt_data();
                update_gui();
                var.default_project_data_path = openfd.InitialDirectory;
                //log.msg(this, "load project data from: " + openfd.FileName);
            }
        }

        private void saveToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("saveToolStripMenuItem1_Click", "TODO");
            //safe_projekt_data();

            //SaveFileDialog savefd = new SaveFileDialog();
            //savefd.InitialDirectory = var.default_project_data_path;
            //savefd.FileName = var.tool_text + "_" + DateTime.Now.Year.ToString() + "-" + DateTime.Now.Month.ToString() + "-" + DateTime.Now.Day.ToString();
            //savefd.Filter = "Zip-File (*.zip)|*.zip";
            //if (savefd.ShowDialog() == DialogResult.OK)
            //    zip(savefd.FileName, true);
            //var.default_project_data_path = savefd.InitialDirectory;
            ////log.msg(this, "save project data to: " + savefd.FileName);
        }


        private void zip(string path, bool archive_true)
        {
            try
            {
                ZipFile zipf = new ZipFile(path);
                System.IO.DirectoryInfo path_dir = new System.IO.DirectoryInfo(var.workingdir);

                if (archive_true)
                {
                    zipf.CompressionLevel = Ionic.Zlib.CompressionLevel.BestCompression;
                    foreach (System.IO.FileInfo f in path_dir.GetFiles())
                        zipf.AddFile(f.DirectoryName + "\\" + f.Name, ".");
                    zipf.Save();
                }
                else
                {
                    zipf.ExtractAll(var.workingdir, ExtractExistingFileAction.OverwriteSilently);
                }
                zipf.Dispose();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "zip error");
            }
        }
        #endregion

        #region menue edit
        private void editParamsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmParam fp = new FrmParam(this, list_plc, list_platform);
            fp.ShowDialog();
        }

        private void editToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (File.Exists(var.workingdir + "\\" + var.file_startup_config))
                System.Diagnostics.Process.Start("notepad", var.workingdir + "\\" + var.file_startup_config);
            else
                new_startup_config();
        }

        private void new_startup_config()
        {
            File.AppendAllText(var.workingdir + "\\" + var.file_startup_config, "################# " + var.tool_text + " startup config ################" + Environment.NewLine +
        "#write one frame per line containing int values seperatet by ," + Environment.NewLine +
        "#for example: 192.168.1.203,1,2,3,4,5,6,7,8" + Environment.NewLine +
        "#             IP            data" + Environment.NewLine +
        "#lines starting with \"#\" will be ignored" + Environment.NewLine);
            System.Diagnostics.Process.Start("notepad", var.workingdir + "\\" + var.file_startup_config);
        }

        /// <summary>
        /// write startup config from file in plc
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void writeInPlcToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("todo -> not jet implemented in cpsLIB","TODO");
            /*
            if (File.Exists(var.workingdir + "\\" + var.file_startup_config))
            {
                int counter_cmd = 0;
                int counter_all = 0;
                int counter_cmd_error = 0;
                string line;
                string error_lines = string.Empty;
                System.IO.StreamReader file = new System.IO.StreamReader(var.workingdir + "\\" + var.file_startup_config);
                while ((line = file.ReadLine()) != null)
                {
                    counter_all++;
                    if (!(line.StartsWith("#") || line.Equals(string.Empty))) //line is no comment or not empty
                    {
                        bool valid_cmd = false;
                        counter_cmd++;
                        string[] cmd_line = line.Split(',');
                        foreach (plc p in list_plc)
                        {
                            if (cmd_line[0].ToLower() == p.get_plc_name().ToLower() || cmd_line[0] == p.get_plc_ip())//cmd kann einer cpu zugeordnet werden
                            {
                                valid_cmd = true;
                                string[] s = new string[cmd_line.Length - 1];
                                for(int i = 0; i < cmd_line.Length-1; i++)
                                    s[i] = cmd_line[i+1];
                                p.putFrameToStack(new Frame(s));
                            }
                        }

                        //falls cmd nicht zugeordnet werden kann speichern
                        if (!valid_cmd)
                        {
                            counter_cmd_error++;
                            error_lines += "unknown plc at line: " + counter_all + " -> " + line + Environment.NewLine;
                        }
                    }
                }
                file.Close();

                MessageBox.Show("lines with cmd: " + counter_cmd + Environment.NewLine + "lines with error cmd: " + counter_cmd_error + 
                    Environment.NewLine + error_lines ,"done writing startup config (" + counter_all + " lines)");
            }
            else { MessageBox.Show("file_startup_config doesent exist. make new one"); }
             */ 
        }

        private void platformToolStripMenuItem_Click(object sender, EventArgs e)
        {
            paint_platform(true);

            FrmPlatformConfig FCP = new FrmPlatformConfig(list_platform, list_plc, this);
            FCP.ShowDialog();
        }

        private void showMsgBoxToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmStartupRunningConfig FSRC = new FrmStartupRunningConfig(list_plc);
            FSRC.Show();
        }

        private void copyRunnintToStartupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (plc p in list_plc)
                p.copyRunningToStartConfig();
        }



        private void copyStartupToRunningToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (plc p in list_plc) {
                foreach (aktuator a in p.ListAktuator) {
                    if (a.AktorType != aktor_type.sensor && a.ConfigAktuatorValuesStartup!=null) {
                        a.plc_send_IO(DataIOType.SetParam, a.ConfigAktuatorValuesStartup);
                    }
                }
            }
        }


        #endregion

        #region menue expert
        private void openWorkingDirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Directory.Exists(var.workingdir))
                System.Diagnostics.Process.Start("explorer.exe", var.workingdir);
        }

        private void startToolStripMenuItem_Click(object sender, EventArgs e)
        {
            timer_start();
        }

        private void stopToolStripMenuItem_Click(object sender, EventArgs e)
        {
            timer_stop();
        }

        private void managementToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (managementToolStripMenuItem.Text == "Get Requests [on]" || managementToolStripMenuItem.Text == "Get Requests")
            {
                timer_GetRequestInterval.Stop();
                managementToolStripMenuItem.Text = "Get Requests [off]";
            }
            else
            {
                timer_GetRequestInterval.Start();
                managementToolStripMenuItem.Text = "Get Requests [on]";
            }
        }
        private void iODataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (iODataToolStripMenuItem.Text == "Update Gui [on]" || iODataToolStripMenuItem.Text == "Update Gui")
            {
                TimerUpdateGui.Stop();
                iODataToolStripMenuItem.Text = "Update Gui [off]";
            }
            else
            {
                TimerUpdateGui.Start();
                iODataToolStripMenuItem.Text = "Update Gui [on]";
            }
        }
        private void onToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var.Notify = true;
        }

        private void offToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var.Notify = false;
        }

        #region cmd ETA
        /**
         * heizung reset //send_stack.put(new Frame(Frame.SET_STATE(11, "3", "1")), var.PLC_EG_IP)
         * heizung tag //send_stack.put(new Frame(Frame.SET_STATE(11, "3", "4")), var.PLC_EG_IP)
         * heizung nacht //send_stack.put(new Frame(Frame.SET_STATE(11, "3", "8")), var.PLC_EG_IP);
         * kessel ein //send_stack.put(new Frame(Frame.SET_STATE(11, "3", "16")), var.PLC_EG_IP);
         * kessel aus //send_stack.put(new Frame(Frame.SET_STATE(11, "3", "32")), var.PLC_EG_IP);
         */

        private void rcvSTARTToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (plc p in list_plc)
                if (p.getClient().RemoteIp == var.tmp_PLC_EG_IP)
                    p.send(Frame.MngData(p.getClient(), DataMngType.EtaCmdStart));
        }

        private void rcvSTOPToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (plc p in list_plc)
                if (p.getClient().RemoteIp == var.tmp_PLC_EG_IP)
                    p.send(Frame.MngData(p.getClient(), DataMngType.EtaCmdStop));
        }

        private void heizungAutoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("todo -> not jet implemented in cpsLIB", "TODO");
            //foreach (plc p in list_plc)
            //    if (p.get_plc_ip() == var.tmp_PLC_EG_IP)
            //        p.putFrameToStack(new Frame(Frame.SET_STATE(11, "3", "2")));
        }

        private void heizungTagToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("todo -> not jet implemented in cpsLIB", "TODO");
            //foreach (plc p in list_plc)
            //    if (p.get_plc_ip() == var.tmp_PLC_EG_IP)
            //        p.putFrameToStack(new Frame(Frame.SET_STATE(11, "3", "4")));
        }

        private void heizungNachtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("todo -> not jet implemented in cpsLIB", "TODO");
            //foreach (plc p in list_plc)
            //    if (p.get_plc_ip() == var.tmp_PLC_EG_IP)
            //        p.putFrameToStack(new Frame(Frame.SET_STATE(11, "3", "8")));
        }
        #endregion

         private void openToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (File.Exists(var.file_log))
                System.Diagnostics.Process.Start(var.file_log);
            else
                MessageBox.Show("no LOGs available", "Info");
        }

        private void resetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (File.Exists(var.file_log))
                File.Delete(var.file_log);
        }

        #endregion

        #region menue CMD
        private void onToolStripMenuItem_light_eg_Click(object sender, EventArgs e)
        {
            MessageBox.Show("todo -> not jet implemented in cpsLIB", "TODO");
            //foreach (plc p in list_plc)
            //    if (p.get_plc_ip() == var.tmp_PLC_EG_IP)
            //        p.send(new Frame(new Int16[] { cpu_net_management, (Int16)job.NET_SET_LIGHT_CMD, 1 }));
        }

        private void offToolStripMenuItem_light_eg_Click(object sender, EventArgs e)
        {
            MessageBox.Show("todo -> not jet implemented in cpsLIB", "TODO");
            //foreach (plc p in list_plc)
            //    if (p.get_plc_ip() == var.tmp_PLC_EG_IP)
            //        p.putFrameToStack(new Frame(new Int16[] { cpu_net_management, (Int16)job.NET_SET_LIGHT_CMD, 2 }));
        }

        private void onToolStripMenuItem_light_ug_Click(object sender, EventArgs e)
        {
            MessageBox.Show("todo -> not jet implemented in cpsLIB", "TODO");
            //foreach (plc p in list_plc)
            //    if (p.get_plc_ip() == var.tmp_PLC_EG_IP)
            //        p.putFrameToStack(new Frame(new Int16[] { cpu_net_management, (Int16)job.NET_SET_LIGHT_CMD, 3 }));
        }

        private void offToolStripMenuItem_light_ug_Click(object sender, EventArgs e)
        {
            MessageBox.Show("todo -> not jet implemented in cpsLIB", "TODO");
            //foreach (plc p in list_plc)
            //    if (p.get_plc_ip() == var.tmp_PLC_EG_IP)
            //        p.putFrameToStack(new Frame(new Int16[] { cpu_net_management, (Int16)job.NET_SET_LIGHT_CMD, 4 }));
        }

        private void onToolStripMenuItem_light_outside_Click(object sender, EventArgs e)
        {
            MessageBox.Show("todo -> not jet implemented in cpsLIB", "TODO");
            //foreach (plc p in list_plc)
            //    if (p.get_plc_ip() == var.tmp_PLC_EG_IP)
            //        p.putFrameToStack(new Frame(new Int16[] { cpu_net_management, (Int16)job.NET_SET_LIGHT_CMD, 5 }));
        }

        private void offToolStripMenuItem_light_outside_Click(object sender, EventArgs e)
        {
            MessageBox.Show("todo -> not jet implemented in cpsLIB", "TODO");
            //foreach (plc p in list_plc)
            //    if (p.get_plc_ip() == var.tmp_PLC_EG_IP)
            //        p.putFrameToStack(new Frame(new Int16[] { cpu_net_management, (Int16)job.NET_SET_LIGHT_CMD, 6 }));
        }

        #endregion

        #region menue view
        private void platformToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            pictureBox_platform.Visible = true;
            panel_controls.Visible = false;
            comboBox_platform.Visible = true;
        }

        private void controlsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pictureBox_platform.Visible = false;
            panel_controls.Visible = true;
            comboBox_platform.Visible = false;
        }
        #endregion

        #region menue data logger
        private void openToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            AH_DataLogger.FrmDataLogger fm = new AH_DataLogger.FrmDataLogger( var.DBServerIP, var.DBName, var.DBUid, var.DBPwd);
            fm.Show();
        }

        private void tableToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AH_DataLogger.FrmTables ft = new AH_DataLogger.FrmTables(var.DBServerIP, var.DBName, var.DBUid, var.DBPwd);
            ft.Show();
        }

        private void verifyDB()
        {
            try
            {
                //wenn MySqlConnector nicht installiert ist wird exception geworfen und nicht mit DB.checkDB == false geantwortet
                //deswegen muss verifyDB() vor dem ersten DB verwenden aufgerufen werden.
                if (!AH_DataLogger.checkConn.checkDB(var.DBServerIP, var.DBName, var.DBUid, var.DBPwd))
                    MessageBox.Show(var.tool_text + AH_DataLogger.checkConn.connection_status, "Ein Problem beim Verbinden mit der Datenbank ist aufgetreten");
            }
            catch (Exception e)
            {
                AH_DataLogger.checkConn.connection_valid = false;
                log.exception(this, "verifyDB() connection_status: " + AH_DataLogger.checkConn.connection_status, e);
                downloadMySqlConnector();
            }
        } 

        [DllImport("shell32.dll", CharSet = CharSet.Unicode)]
        static extern int SHGetKnownFolderPath([MarshalAs(UnmanagedType.LPStruct)] Guid rfid, uint dwFlags, IntPtr hToken, out string pszPath);

        public void downloadMySqlConnector()
        {
            if (MessageBox.Show("Datenbankanbindung nicht installiert!" + Environment.NewLine +
                "download mysql-connector-net-6.9.8.msi?" + Environment.NewLine +
                "dieser ist Voraussetzung um mit " + var.tool_text + " arbeiten zu können"
                + Environment.NewLine + "(zum download ist eine Internetverbindung notwendig," +
                Environment.NewLine + "zum installieren Administrator Rechte)",
                "Fehler", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                log.msg(this, "user choose to download mysql-connector-net-6.9.8.msi");
                System.Diagnostics.Process.Start("http://dev.mysql.com/get/Downloads/Connector-Net/mysql-connector-net-6.9.8.msi");

                if (MessageBox.Show("Datei \"mysql-connector-net-6.9.8.msi\"" + Environment.NewLine + "nach dem download ausführen" +
                    Environment.NewLine + "und durch den install Dialog klicken." + Environment.NewLine +
                    "Für \"Choose Setup Type\" -> [Typical] auswählen",
                    "installieren?", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    string downloads;
                    SHGetKnownFolderPath(new Guid("374DE290-123F-4565-9164-39C4925E467B"), 0, IntPtr.Zero, out downloads);
                    //System.Diagnostics.Process.Start(downloads + "\\mysql-connector-net-6.9.8.msi");
                    if (Directory.Exists(downloads))
                        System.Diagnostics.Process.Start("explorer.exe", downloads);
                    this.Close();
                }
            }
            else
                log.msg(this, "user choose NOT to download mysql-connector-net-6.9.8.msi");
        }
        #endregion

        private void logMsgToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string s = "";
            foreach (string st in ListLogMsg)
                s += st + Environment.NewLine;
            MessageBox.Show(s, "Log Msg: " + ListLogMsg.Count);
        }
        #endregion

        #region footer - status bar
        #region make_status_bar
        private ToolStripStatusLabel TSSLServer_stop;
        private ToolStripStatusLabel TSSLServer_start;
        private ToolStripStatusLabel TSSLServer_SYNCallClients;
        private ToolStripStatusLabel TSSLServer_FormStatusLog;
        /*
        //List<ToolStripDropDownButton> list_TSDDB_plc = new List<ToolStripDropDownButton>();
        private ToolStripStatusLabel TSSL_diag;
        private ToolStripStatusLabel TSSL_connect;
        private ToolStripStatusLabel TSSL_ibs;
        private ToolStripStatusLabel TSSL_SetTime;
        private ToolStripStatusLabel TSSL_ReadRunningConfig;
        private ToolStripStatusLabel TSSL_CopyRunningToStartupConfig;
        private ToolStripStatusLabel TSSL_CopyStartupToRunningConfig;
        */
        private ToolStripDropDownButton TSDDB_server;
        private void make_status_bar()
        {
            
            //################# client region ######################
            foreach (plc p in list_plc)
            {
                ToolStripDropDownButton TSDDB = new ToolStripDropDownButton("->" + p.NamePlc, null, null, "->" + p.NamePlc);
                TSDDB.Tag = p;
                TSDDB.BackColor = Color.Yellow;
                TSDDB.Click += TSDDB_Click;
                /*
                TSSL_connect = new ToolStripStatusLabel("connect");
                TSSL_connect.Tag = p;
                TSSL_connect.Click += new EventHandler(TSSL_OnClickConnect);
                TSDDB.DropDownItems.Add(TSSL_connect);

                TSSL_diag = new ToolStripStatusLabel("status");
                TSSL_diag.Tag = p;
                TSSL_diag.Click += new EventHandler(TSSL_OnClickStatus);
                TSDDB.DropDownItems.Add(TSSL_diag);

                TSSL_ibs = new ToolStripStatusLabel("ibs send");
                TSSL_ibs.Tag = p;
                TSSL_ibs.Click += new EventHandler(TSSL_OnClickIBS);
                TSDDB.DropDownItems.Add(TSSL_ibs);

                TSSL_SetTime = new ToolStripStatusLabel("set time ");
                TSSL_SetTime.Tag = p;
                TSSL_SetTime.Click += new EventHandler(TSSL_OnClickSetTime);
                TSDDB.DropDownItems.Add(TSSL_SetTime);

                TSSL_ReadRunningConfig = new ToolStripStatusLabel("ReadRunningConfig ");
                TSSL_ReadRunningConfig.Tag = p;
                TSSL_ReadRunningConfig.Click += new EventHandler(TSSL_OnClickReadRunningConfig);
                TSDDB.DropDownItems.Add(TSSL_ReadRunningConfig);

                TSSL_CopyRunningToStartupConfig = new ToolStripStatusLabel("CopyRunningToStartupConfig");
                TSSL_CopyRunningToStartupConfig.Tag = p;
                TSSL_CopyRunningToStartupConfig.Click += new EventHandler(TSSL_OnClickCopyRunningToStartupConfig);
                TSDDB.DropDownItems.Add(TSSL_CopyRunningToStartupConfig);

                TSSL_CopyStartupToRunningConfig = new ToolStripStatusLabel("CopyStartupToRunningConfig");
                TSSL_CopyStartupToRunningConfig.Tag = p;
                TSSL_CopyStartupToRunningConfig.Click += new EventHandler(TSSL_OnClickCopyStartupToRunningConfig);
                TSDDB.DropDownItems.Add(TSSL_CopyStartupToRunningConfig);
                */
                statusStrip_bottom.Items.Add(TSDDB);
            }


            //################# server region ######################

            TSDDB_server = new ToolStripDropDownButton("[server status]");
            //TSDDB_server.BackColor = Color.Yellow;
            //TSDDB_server.Size = new Size(500, 500);

            TSSLServer_stop = new ToolStripStatusLabel("STOP server");
            TSSLServer_stop.Click += new EventHandler(TSSL_OnClickStop);
            TSDDB_server.DropDownItems.Add(TSSLServer_stop);

            TSSLServer_start = new ToolStripStatusLabel("START server");
            TSSLServer_start.Click += new EventHandler(TSSL_OnClickStart);
            TSDDB_server.DropDownItems.Add(TSSLServer_start);

            TSSLServer_SYNCallClients = new ToolStripStatusLabel("connect all clients");
            TSSLServer_SYNCallClients.Click += new EventHandler(TSSL_OnClickSYNCallClients);
            TSDDB_server.DropDownItems.Add(TSSLServer_SYNCallClients);

            TSSLServer_FormStatusLog = new ToolStripStatusLabel("Form Status Log");
            TSSLServer_FormStatusLog.Click += new EventHandler(TSSL_OnClickFormStatusLog);
            TSDDB_server.DropDownItems.Add(TSSLServer_FormStatusLog);

            statusStrip_bottom.Items.Add(TSDDB_server);
        }

        private void TSDDB_Click(object sender, EventArgs e)
        {
            ToolStripDropDownButton o = sender as ToolStripDropDownButton;
            FrmPlcClient Fpc = new FrmPlcClient((plc)o.Tag, CpsNet);
            Fpc.Show();
        }
        #endregion

        #region server
        //############################## region server ##############################################


        //private void startServerToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    if (CpsNet != null)
        //        CpsNet.serverSTART(var.CpsServerPort);
        //    else
        //        MessageBox.Show("CpsNet == null");
        //}
        void TSSL_OnClickStart(object sender, EventArgs e)
        {
            if (CpsNet != null)
                CpsNet.serverSTART(var.CpsServerPort);
            else
                MessageBox.Show("CpsNet == null");
        }
        void TSSL_OnClickStop(object sender, EventArgs e)
        {
            if (CpsNet != null)
                CpsNet.serverSTOP();
            else
                MessageBox.Show("CpsNet == null");
        }
        //private void stopServerToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    if (CpsNet != null)
        //        CpsNet.serverSTOP();
        //    else
        //        MessageBox.Show("CpsNet == null");
        //}

        void TSSL_OnClickSYNCallClients(object sender, EventArgs e)
        {
            //try to connect (send SYNC frame) with all projected plc´s
            foreach (plc p in list_plc)
                p.connect(CpsNet);
        }
        //private void connectAllClientsToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    //try to connect (send SYNC frame) with all projected plc´s
        //    foreach (plc p in list_plc)
        //        p.connect(CpsNet);
        //}

        void TSSL_OnClickFormStatusLog(object sender, EventArgs e)
        {
            CpsNet.FrmLogShow(true);
        }
        private void logHideToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CpsNet.FrmLogShow(true);
            //if (logHideToolStripMenuItem.Text == "Form Status Log [show]")
            //{
            //    CpsNet.FrmLogShow(true);
            //    logHideToolStripMenuItem.Text = "Form Status Log [hide]";
            //}
            //else
            //{
            //    CpsNet.FrmLogShow(false);
            //    logHideToolStripMenuItem.Text = "Form Status Log [show]";
            //}
            
        }

        #endregion
        /*
        #region client
        //############################## region client ##############################################
        void TSSL_OnClickConnect(object sender, EventArgs e)
        {
            ToolStripLabel o = sender as ToolStripLabel;
            if (o != null && o.Tag != null)
                ((plc)o.Tag).connect(CpsNet);
            else
                MessageBox.Show("sender == null", "ERROR TSSL_OnClickConnect");
        }

        void TSSL_OnClickStatus(object sender, EventArgs e)
        {
            ToolStripLabel o = sender as ToolStripLabel;
            if (o != null)
                MessageBox.Show(((plc)o.Tag).getClient().GetSendFrames(), o.Tag.ToString() + ((plc)o.Tag).getClient().GetStatus());
            else
                MessageBox.Show("sender == null", "ERROR TSSL_OnClickStatus");
        }

        void TSSL_OnClickSetTime(object sender, EventArgs e)
        {
            ToolStripLabel o = sender as ToolStripLabel;
            DateTime TimeNow = DateTime.Now;
            Frame f = new Frame(((plc)o.Tag).getClient(), new Int16[] { (Int16)DataMngType.SetPlcTime, 
            (Int16)TimeNow.Year, (Int16)TimeNow.Month, (Int16)TimeNow.Day, (Int16)TimeNow.Hour, (Int16)TimeNow.Minute, (Int16)TimeNow.Second});
            f.SetHeaderFlag(FrameHeaderFlag.MngData);

            if (o != null)
                ((plc)o.Tag).send(f);
            else
                MessageBox.Show("TSSL_OnClickSetTime()", "ToolStripLabel o == null");
        }

        //##################################### IBS Function ############################################
        void TSSL_OnClickIBS(object sender, EventArgs e)
        {
            ToolStripLabel o = sender as ToolStripLabel;

            if (o != null)
            {
                Frame f3 = new Frame(((plc)o.Tag).getClient(), new Int16[] { 1 });
                f3.SetHeaderFlag(FrameHeaderFlag.MngData);
                ((plc)o.Tag).send(f3);
            }
            else
            {
                MessageBox.Show("TSSL_OnClickIBS()", "ToolStripLabel o == null");
                return;
            }

            
            //for (Int16 i = 0; i < Convert.ToInt16(textBox1.Text); i++)
            //{
            //    if (o != null) { 
            //        //Frame f = new Frame(((plc)o.Tag).getClient(), new Int16[] { i, 1, 1, 1, 255, 255, 256, 257, -1, -1, -1 });
            //        //f.SetHeaderFlag(FrameHeaderFlag.ACKN);
            //        //((plc)o.Tag).send(f, FrmLog);

            //        //Frame f2 = new Frame(((plc)o.Tag).getClient(), new Int16[] { 999, 1, i });
            //        //f2.SetHeaderFlag(FrameHeaderFlag.PdataIO);
            //        //((plc)o.Tag).send(f2, FrmLog);

            //        Frame f3 = new Frame(((plc)o.Tag).getClient(), new Int16[] { 1, i });
            //        f3.SetHeaderFlag(FrameHeaderFlag.MngData);
            //        ((plc)o.Tag).send(f3, FrmLog);
            //    }
            //    else
            //    {
            //        MessageBox.Show("TSSL_OnClickIBS()", "ToolStripLabel o == null");
            //        return;
            //    }
                
        
        }

        //##################################### running config ############################################
        void TSSL_OnClickReadRunningConfig(object sender, EventArgs e)
        {
            ToolStripLabel o = sender as ToolStripLabel;
            plc p = (plc)o.Tag;
            p.ReadRunningConfig();
        }

        void TSSL_OnClickCopyRunningToStartupConfig(object sender, EventArgs e)
        {
            plc p = (plc)(sender as ToolStripLabel).Tag;
            p.copyRunningToStartConfig();
        }

        private void TSSL_OnClickCopyStartupToRunningConfig(object sender, EventArgs e)
        {
            plc p = (plc)(sender as ToolStripLabel).Tag;
            foreach (aktuator a in p.ListAktuator)
                if (a.AktorType != aktor_type.sensor && a.ConfigAktuatorValuesStartup != null)
                    a.plc_send_IO(DataIOType.SetParam, a.ConfigAktuatorValuesStartup);
        }
        #endregion
        */
        #endregion

        #region paint gui
        /// <summary>
        /// einmaliger aufruf für statische zuweisungen
        /// </summary>
        public void init_gui() {
            comboBox_aktor_type.DataSource = Enum.GetValues(typeof(aktor_type));
            update_gui();
        }
        public void update_gui()
        {
            expertToolStripMenuItem.Visible = var.show_expert_mode;
            comboBox_aktor_cpu.DataSource = null;
            comboBox_aktor_cpu.DataSource = list_plc;
            comboBox_platform.DataSource = null;
            comboBox_platform.DataSource = list_platform;
            comboBox_platform.SelectedIndex = var.LastPlatformView;
            paint_platform();
            if (CpsNet != null)
            {
                CpsNet.WATCHDOG_WORK = var.WatchdagTime_PLCtoPC;
                label_WatchdogWork.Text = "Watchdog Work: " + CpsNet.WATCHDOG_WORK.ToString();
                label_WatchdogWork.Visible = true;
            }
        }

        #region userControl
        private void comboBox_aktor_type_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(panel_controls.Visible)
                make_uc_list();
        }
        private void comboBox_aktor_cpu_SelectedIndexChanged(object sender, EventArgs e)
        {
            //make_uc_list((plc)comboBox_aktor_cpu.SelectedItem, (type)comboBox_aktor_type.SelectedItem);
        }

        List<UserControl> list_UC = new List<UserControl>();
        //private void make_uc_list(plc p, type t)
        private void make_uc_list()
        {
            int counter = 0;
            list_UC.Clear();
            panel_aktors.Controls.Clear();
            
            foreach (aktuator a in ((plc)comboBox_aktor_cpu.SelectedItem).ListAktuator) {
                if (a.AktorType == (aktor_type)comboBox_aktor_type.SelectedItem)
                {
                    aktuator_control ac = new aktuator_control(a);
                    list_aktuator_controls.Add(ac); 

                    switch (ac._aktor_type)
                    {
                        case aktor_type.jalousie:
                            list_UC.Add((UC_jalousie)ac.user_control);
                            list_UC[counter].Location = new Point(0, counter * 41);
                            panel_aktors.Controls.Add(list_UC[counter]);
                            counter++;
                            ac.aktuator.plc_send_IO(DataIOType.GetState);
                            break;
                        case aktor_type.heater:
                            list_UC.Add((UC_heater)ac.user_control);
                            list_UC[counter].Location = new Point(0, counter * 32);
                            panel_aktors.Controls.Add(list_UC[counter]);
                            counter++;
                            ac.aktuator.plc_send_IO(DataIOType.GetParam);
                            break;
                        case aktor_type.light:
                            list_UC.Add((UC_light)ac.user_control);
                            list_UC[counter].Location = new Point(0, counter * 23);
                            panel_aktors.Controls.Add(list_UC[counter]);
                            counter++;
                            ac.aktuator.plc_send_IO(DataIOType.GetParam);
                            break;
                        case aktor_type.undef:

                            break;
                    }
                }
            }
        }
        #endregion

        #region platform
        private void comboBox_platform_SelectedIndexChanged(object sender, EventArgs e)
        {
            paint_platform();
        }

        /// <summary>
        /// alle controls aller platforms werden mit event handler gelöscht. Danach wird für die aktuell 
        /// ausgewählte platform die controlls neu angelegt und die event handler gesetzt.
        /// </summary>
        /// <param name="clear">wenn true werden nur die controls gelöscht und nicht neu hinzugefügt</param>
        private void paint_platform(bool clear = false)
        {
            //event handler und bilder löschen
            foreach (platform p in list_platform)
                foreach (platform_control pc in p._list_platform_control)
                {
                    if (pc._PictureBox != null) //platform_control mit sensor_value haben keine PictrueBox sondern UC_SensorValue
                    {
                        pc._PictureBox.MouseDown -= new MouseEventHandler(_PictureBox_MouseDown);
                        pictureBox_platform.Controls.Remove(pc._PictureBox);
                    }
                    else if (pc._UCsensorValue != null)
                        pictureBox_platform.Controls.Remove(pc._UCsensorValue);
                }
            pictureBox_platform.Image = null;

            if (!clear)
            {//event handler zuweisen und bild zeichnen
                platform p_selected = (platform)comboBox_platform.SelectedItem;
                if (p_selected != null)
                    foreach (platform_control pc in p_selected._list_platform_control)
                        if (pc._aktuator != null ) //controlls denen kein aktor zugewiesen ist nicht zeichnen
                        {
                            if (pc._PictureBox != null)//platform_control mit sensor_value haben keine PictrueBox sondern UC_SensorValue
                            {
                                pc._PictureBox.MouseDown += new MouseEventHandler(_PictureBox_MouseDown);
                                pictureBox_platform.Controls.Add(pc._PictureBox);
                            }
                            else if(pc._UCsensorValue != null)
                                pictureBox_platform.Controls.Add(pc._UCsensorValue);
                        }
                if (p_selected != null && p_selected._floor_plan != null)
                {
                    pictureBox_platform.Size = new Size(p_selected._floor_plan._picture_width, p_selected._floor_plan._picture_heigth);
                    pictureBox_platform.Image = p_selected.get_background_pic();
                }
            }
        }

        /// <summary>
        /// passe größe der FrmMain an platform größe an
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pictureBox_platform_SizeChanged(object sender, EventArgs e)
        {
            //TODO größe anpassen
            this.Size = new Size(pictureBox_platform.Size.Width + 50, pictureBox_platform.Size.Height + 130) ;
        }
        #endregion

        #region platform event handler
        FrmMain_controlDialog _FrmMain_controlDialog;
        void _PictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            PBplatformControl c = (PBplatformControl)sender;

            aktuator a = c._platform_control._aktuator;
            switch (a.AktorType)
            {
                case aktor_type.light:
                    if (e.Button == MouseButtons.Right)
                    {
                        _FrmMain_controlDialog = new FrmMain_controlDialog(c._platform_control._aktuator);
                        _FrmMain_controlDialog.ShowDialog();
                    }
                    else
                        a.plc_send_IO(DataIOType.SetState, new Int16[]{3}); //3 -> toggle switch state 
                            //new Frame(Frame.SET_STATE(a.Index, !a.Light_switch_state)));
                    break;

                case aktor_type.jalousie:
                    if (e.Button == MouseButtons.Right)
                    {
                        _FrmMain_controlDialog = new FrmMain_controlDialog(c._platform_control._aktuator);
                        _FrmMain_controlDialog.ShowDialog();
                    }
                    break;

                case aktor_type.undef:
                    _FrmMain_controlDialog = new FrmMain_controlDialog(c._platform_control._aktuator);
                    _FrmMain_controlDialog.ShowDialog();
                    break;

                case aktor_type.heater:
                    _FrmMain_controlDialog = new FrmMain_controlDialog(c._platform_control._aktuator);
                    _FrmMain_controlDialog.ShowDialog();
                    break;

                //default:
                //    _FrmMain_controlDialog = new FrmMain_controlDialog(c._platform_control._aktuator);
                //    _FrmMain_controlDialog.ShowDialog();
                //    break;
            }
            _FrmMain_controlDialog = null;
        }



        //void _PictureBox_MouseDoubleClick(object sender, MouseEventArgs e)
        //{
        //    MessageBox.Show("doppelt angeklickt [" + ((PBplatformControl)sender)._platform_control._aktuator._name + "]");
        //}
        #endregion


        #endregion

        #region TIMER send/receive/refresh

        #region init_start
        System.Windows.Forms.Timer timer_GetRequestInterval;
        System.Windows.Forms.Timer TimerUpdateGui;
        System.Windows.Forms.Timer timer_footer_connection_status;

        private void init_timer()
        {
            TimerUpdateGui = new System.Windows.Forms.Timer();
            TimerUpdateGui.Interval = var.timer_refresh_GUI;
            TimerUpdateGui.Tick += new EventHandler(timer_refresh_control_Tick);

            timer_footer_connection_status = new System.Windows.Forms.Timer();
            timer_footer_connection_status.Interval = var.footer_connection_status;
            timer_footer_connection_status.Tick += new EventHandler(footer_connection_status_Tick);

            timer_GetRequestInterval = new System.Windows.Forms.Timer();
            timer_GetRequestInterval.Interval = var.timer_GetRequestInterval;
            timer_GetRequestInterval.Tick += new EventHandler(timer_GetRequestInterval_Tick);

            TimerUpdateGui.Start();
            timer_footer_connection_status.Start();

            if (var.start_timers_at_start)
                timer_start();
        }

        private void timer_start()
        {
            timer_GetRequestInterval.Start();
            
        }
        private void timer_stop()
        {
            timer_GetRequestInterval.Stop();
        }
        #endregion

        //TODO: in eigenen timer auslagern
        int dbg_count = 10;
        /// <summary>
        /// collect all visible controll IDs and send GetRequest @PLC
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void timer_GetRequestInterval_Tick(object sender, EventArgs e)
        {
            //********************************************************************************************************************
            //ReadRunningConfig from all aktuators -> send GetRequest (Get_Param) @PLC
            //********************************************************************************************************************
            dbg_count++;
            if (dbg_count > 10)
            {
                dbg_count = 0;
                if (list_plc.Any())
                    foreach (plc p in list_plc)
                        p.ReadRunningConfig();
            }


            if (list_plc.Any())
            {
                //********************************************************************************************************************
                //collect all visible controll (NOT aktor_type.sensor) IDs and send GetRequest (Get_State) @PLC
                //********************************************************************************************************************
                foreach (plc p in list_plc)
                    p.ListSensorIDs = new List<short>();

                if (pictureBox_platform.Visible)
                    if (list_platform.Any() && comboBox_platform.SelectedItem != null)
                        foreach (platform_control pc in ((platform)comboBox_platform.SelectedItem)._list_platform_control)
                            //controlls denen kein aktor zugewiesen ist nicht beachten
                            if (pc._aktuator != null && pc._aktuator._plc != null)
                                //sensor controlls sammeln und in einzelnen management frame versenden
                                if (pc._aktuator.AktorType == aktor_type.sensor) //nur sensoren beachten
                                    pc._aktuator._plc.ListSensorIDs.Add(pc._aktuator.Index);
                                else
                                    //alle aktoren anfragen werden einzeln ein eigenem frame versendet
                                    pc._aktuator.plc_send_IO(DataIOType.GetState); //send GetRequest @PLC for all visible aktuator controll IDs


                //********************************************************************************************************************
                //send GetRequest @PLC (ONLY aktor_type.sensor)
                //********************************************************************************************************************
                foreach (plc p in list_plc)
                    if (p.getClient() != null && p.getClient().state == udp_state.connected)
                    {
                        //send get Time request @PLC
                        p.send(Frame.MngData(p.getClient(), DataMngType.GetPlcTime));

                        //send sensor value request @plc
                        if (p.ListSensorIDs.Any())
                        {
                            p.ListSensorIDs.Insert(0, (Int16)DataMngType.GetPlcSensorValues);
                            p.send(FrameHeaderFlag.MngData, p.ListSensorIDs.ToArray());
                        }
                    }
            }
            
        }

        /// <summary>
        /// footer server status wird angezeigt
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void footer_connection_status_Tick(object sender, EventArgs e)
        {
            //this.Text = "AutoHome " + CpsNet.GetStatus();
            TSDDB_server.Text = "[server status] " + CpsNet.GetStatus();
            logMsgToolStripMenuItem.Text = "Log Msg [" + ListLogMsg.Count.ToString() + "]";

            foreach (ToolStripDropDownButton p in statusStrip_bottom.Items)
            {
                if (((plc)p.Tag) != null) //TODO Server Button nicht beachten, dann abfrage auf !=null überflüssig
                {
                    udp_state state = ((plc)p.Tag).getClient().state;
                    if (state == udp_state.connected && p.BackColor != Color.LightGreen)
                        p.BackColor = Color.LightGreen;
                    else if (state == udp_state.disconnected && p.BackColor != Color.Yellow)
                        p.BackColor = Color.Yellow;
                    else if (state == udp_state.SendError && p.BackColor != Color.Red)
                        p.BackColor = Color.Red;
                }
            }
        }
        
        /// <summary>
        /// alle controls in gui werden mit ihren aktual werten befüllt
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void timer_refresh_control_Tick(object sender, EventArgs e)
        {
            try
            {
                //********************************************************************************************************************
                //show current aktuator value @GUI
                //********************************************************************************************************************
                //update [view controls]
                if (pictureBox_platform.Visible)
                {
                    //update [view platform] GUI with values
                    if (comboBox_platform.SelectedItem != null)
                        ((platform)comboBox_platform.SelectedItem).update_control();
                }
                else if (panel_controls.Visible)
                {
                    //foreach (aktuator_control ac in list_aktuator_controls)
                    //    ac.interprete
                    
                    //foreach (aktuator_control ac in list_aktuator_controls)
                    //{
                    //    if (f.isIOIndex(ac.aktuatorIndex))
                    //        ac.interprete(f);
                    //}
                }
            }
            catch (Exception ex) {
                log.exception(this, "timer_refresh_control_Tick", ex);
            }
        }
        #endregion

        #region client callback (darstellung der werte in GUI)  ==> obsulete, now handled over plc.cs
        
         /// <summary>
        /// interpretes the received Cps frame and display results @ gui
        /// </summary>
        /// <param name="f">received Cps frame</param>
        //private delegate void interprete_frameCallback(object f);
        //void IcpsLIB.interprete_frame(object o)
        //{
        //    try
        //    {
        //        if (this.InvokeRequired)
        //            this.Invoke(new interprete_frameCallback(this.interprete_frame_fkt), new object[] { o });
        //        else
        //            interprete_frame_fkt(o);
        //    }
        //    catch (Exception e)
        //    {
        //        log.exception(this, "interprete_frame(); writing to GUI failed!", e);
        //    }
        //}

        //private void interprete_frame_fkt(object f)
        //{
        //    try
        //    {
        //        Frame _f = (Frame)f;

        //        if (_f.GetHeaderFlag(FrameHeaderFlag.SYNC))
        //        {
        //            //sync frame empfangen -> statusanzeige "verbunden" in footer durch grün
        //            foreach (ToolStripDropDownButton p in statusStrip_bottom.Items)
        //                //statusStrip_bottom contains CPSstatus Label with no p.Tag
        //                if (p.Tag != null && (_f.client.RemoteIp == ((plc)p.Tag).getClient().RemoteIp))
        //                    p.BackColor = Color.GreenYellow;
        //        }
        //        else if (_f.GetHeaderFlag(FrameHeaderFlag.MngData))
        //            interprete_MngData(_f);
        //        else if (_f.GetHeaderFlag(FrameHeaderFlag.ACKN))
        //            ListLogMsg.Add("RCV: ACKN {" + _f.ToString() + "}");
        //        else if (_f.GetHeaderFlag(FrameHeaderFlag.PdataIO))
        //            interprete_IOData(_f);
        //        else
        //            ListLogMsg.Add("RCV: UNKNOWN {" + _f.ToString() + "}");
        //    }
        //    catch (Exception e)
        //    {
        //        log.exception(this, "interprete_frame_fkt()", e);
        //    }
        //}

        //private void interprete_MngData(Frame f) {
        //    foreach (plc p in list_plc) 
        //        if (f.client.RemoteIp == p.getClient().RemoteIp) 
        //            p.interpreteDataMng(f);
        //    //ListLogMsg.Add("RCV: MngData {" + f.ToString() + "}");

        //    foreach (ToolStripDropDownButton p in statusStrip_bottom.Items)
        //    {
        //        //statusStrip_bottom contains CPSstatus Label with no p.Tag
        //        if (p.Tag != null && (f.client.RemoteIp == ((plc)p.Tag).getClient().RemoteIp)) {

        //            if (f.getPayload(0) == (Int16)DataMngType.GetPlcTime)
        //            {
        //                DateTime clockPlc = new DateTime(f.getPayload(1), f.getPayload(2), f.getPayload(3), f.getPayload(4), f.getPayload(5), f.getPayload(6));

        //                if (var.FooterShowPlcTime)
        //                    p.Text = p.Name + " [" + clockPlc.ToString("HH:mm:ss") + "]";
        //            }
        //                #region archive

        //                //try
        //                //{
        //                //    if (f.getPayload(0) == (Int16)DataMngType.GetPlcTime)
        //                //    {
        //                //        DateTime clockPlc = new DateTime(f.getPayload(1), f.getPayload(2), f.getPayload(3), f.getPayload(4), f.getPayload(5), f.getPayload(6));

        //                //        if(var.FooterShowPlcTime)
        //                //            p.Text = p.Name + " [" + clockPlc.ToString("HH:mm:ss") + "]";
        //                //        //p.BackColor = Color.Transparent;
        //                //        if (DateTime.Now.Subtract(new TimeSpan(0, 0, var.MngData_AcceptedClockDelay)) > clockPlc)
        //                //        {
        //                //            TimeSpan ts = DateTime.Now - clockPlc;
        //                //            p.Text = p.Name + " > " + ts.ToString(TSFormat(ts));
        //                //            p.BackColor = Color.Yellow;
        //                //        }
        //                //        else if (DateTime.Now.Add(new TimeSpan(0, 0, var.MngData_AcceptedClockDelay)) < clockPlc)
        //                //        {
        //                //            TimeSpan dt = clockPlc - DateTime.Now;
        //                //            p.Text = p.Name + " < " + dt.ToString(TSFormat(dt));
        //                //            p.BackColor = Color.Yellow;
        //                //        }
        //                //}
        //                //    else if (f.getPayload(0) == (Int16)DataMngType.SetPlcTime) {
        //                //        Int16 retval = f.getPayload(1);
        //                //        if(retval>0)
        //                //            MessageBox.Show("retval: " + f.getPayload(1) + Environment.NewLine + " see TIA Help [WR_SYS_T: Set time-of-day]", "SetPlcTime: ERROR");
        //                //    }
        //                //    else if (f.getPayload(0) == (Int16)DataMngType.GetPlcSensorValues)
        //                //    {
        //                //        if (pictureBox_platform.Visible)
        //                //        {
        //                //            platform p_selected = (platform)comboBox_platform.SelectedItem;
        //                //            if (p_selected != null)
        //                //            {
        //                //                //FrmLog.AddLog("SensorVal: " + f.ShowPayloadInt());

        //                //                //Dictionary<Int16, float> dicSensorVal = new Dictionary<short, float>();
        //                //                ////dicSensorVal.Clear();
        //                //                ////komplettes frame durchgehen und auspacken. für jeden sensorwert entsprechendes controll befüllen
        //                //                //float SensorValue;
        //                //                //for (int i = 3; i < (f.getPaloadIntLengt()); i = i + 3)
        //                //                //{
        //                //                //    if (f.getPayload(i + 2) != 0)
        //                //                //        SensorValue = (float) f.getPayload(i + 1) / (float)f.getPayload(i + 2);
        //                //                //    else
        //                //                //        SensorValue = f.getPayload(i + 1);

        //                //                //    dicSensorVal.Add(f.getPayload(i), SensorValue);
        //                //                //}

        //                //                p_selected.update_SensorControl(f);


        //                //                //p_selected.update_control(f);
        //                //                //FrmLog.AddLog("SensorVal_dic: " + f.ShowPayloadInt());
        //                //            }
        //                //        }
        //                //    }
        //                //}
        //                //catch (Exception e) {
        //                //    //TODO: globalen error log mit notify in GUI einrichten
        //                //    //MessageBox.Show(e.Message, "exception")
        //                //        FrmLog.AddLog("Exception interprete_MngData: " + e.Message);
        //                //    ;
        //                //}
        //                #endregion
        //                break; //da richtige plc zu ToolStripDropDownButton bearbeitet wurde schleife beenden
        //        }   
        //    }
        //}
        //private string TSFormat(TimeSpan ts) {
        //    string format = "";

        //    if (ts.Days != 0)
        //        format = @"d\T\ hh\:mm";
        //    else if (ts.Hours != 0)
        //        format = @"hh\:mm\:ss";
        //    else if (ts.Minutes != 0)
        //        format = @"mm\:ss";
        //    else if (ts.Seconds != 0)
        //        format = @"ss\.fff";
        //    else
        //        format = @"ss\.fffff";
        //    return format;
        //}

        //private void interprete_IOData(Frame f) {
        //    /// DBG -  display all IOData in Log Form
        //    //FrmLog.AddLog("IOData {" + f.client.RemoteIp + " " + f.ToString() + "} " + f.getPayloadHex() + " / " + f.ShowPayloadInt());

        //    //speichere frame in zugehörigem aktuator
        //    //über time_tick wird wert in gui angezeigt
        //    foreach (plc p in list_plc) 
        //        if (p.IPplc==f.client.RemoteIp) 
        //            p.SetAktuatorData(f);
                
            
        //    ////[view platform] fill aktuator dialog box with values
        //    //if (_FrmMain_controlDialog != null)
        //    //    if (f.isIOIndex(_FrmMain_controlDialog.get_aktuator_id()))
        //    //        _FrmMain_controlDialog.update_with_frame(f);

        //    ////update [view controls]
        //    //if (pictureBox_platform.Visible)
        //    //{
        //    //    //update [view platform] GUI with values
        //    //    platform p_selected = (platform)comboBox_platform.SelectedItem;
        //    //    if (p_selected != null)
        //    //        p_selected.update_control(f);
        //    //}
        //    //else if (panel_controls.Visible)
        //    //{
        //    //    foreach (aktuator_control ac in list_aktuator_controls)
        //    //    {
        //    //        if (f.isIOIndex(ac.aktuatorIndex))
        //    //            ac.interprete(f);
        //    //    }
            
        //}

        /// <summary>
        /// log/error messages from udp server
        /// </summary>
        /// <param name="s"></param>
        //private delegate void srv_msgCallback(string s);
        //void IcpsLIB.logMsg(string msg)
        //{
        //    try
        //    {
        //        this.Invoke(new srv_msgCallback(this.srv_msg_funkt), new object[] { msg });
        //        log.msg(this, "IcpsLIB.logMs " + msg);
        //    }
        //    catch (Exception e)
        //    {
        //        //form closing throws exeption -> TODO catch
        //        log.exception(this, "srv_msgCallback: writing to GUI failed", e);
        //        //MessageBox.Show("srv_msgCallback: " + e.Message, "writing to GUI failed");
        //    }
        //}
        //private void srv_msg_funkt(string s)
        //{
        //    ListLogMsg.Add(DateTime.Now.ToString("mm:ss:ms") + " -- " + s);
        //}


        #endregion

       
    }
}
