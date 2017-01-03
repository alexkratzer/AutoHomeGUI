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

//System.IO.File.AppendAllText(@"\\ATOM\alex\desktop\autohomedbg.txt", "" + Environment.NewLine);


namespace AutoHome
{
    public enum aktor_type { undef, jalousie, light, heater, sensor }
    public enum msg_type { undef, info, warning, error }

    public partial class FrmMain : Form, IcpsLIB
    {
        public static readonly string tool_version = "V0.0.3";

        List<aktuator> list_aktuator = new List<aktuator>();
        List<plc> list_plc = new List<plc>();
        List<platform> list_platform = new List<platform>();
        List<floor_plan> list_floor_plan = new List<floor_plan>();
        List<aktuator_control> list_aktuator_controls = new List<aktuator_control>();

        cpsLIB.CpsNet CpsNet;

        //TODO: extract Form Dbg -> //FrmDbg frmdbg;

        public const Int16 cpu_net_management = 10;
        public const Int16 ID_ETA = 11;
        FrmLogPCS FrmLog; 

        #region init / connect / close
        public FrmMain()
        {
            InitializeComponent();
            load_projekt_data();

            FrmLog = new FrmLogPCS();
            FrmLog.Show();

            init_gui();
            make_status_bar();
            
            initCps();
            init_timer();

            verifyDB();
        }

        private void load_projekt_data() {
            var.read_ini_file();
            list_plc = var.deserialize_plc();
            list_aktuator = var.deserialize_aktor(list_plc);
            list_platform = var.deserialize_platform(list_aktuator);
        }

        private void safe_projekt_data() {
            var.write_ini_file();
            var.serialize_platform(list_platform);
            //var.serialize_aktuator_control(list_aktuator_controls);
            var.serialize_aktor(list_aktuator);
            var.serialize_plc(list_plc);
        }
        private void initCps()
        {
            CpsNet = new cpsLIB.CpsNet(this, true);
            CpsNet.serverSTART(var.CpsServerPort);

            if (var.connect_to_plc_at_start)
            {
                //try to connect (send SYNC frame) with all projected plc´s
                foreach (plc p in list_plc)
                    p.connect(CpsNet,FrmLog);
            }
        }

        private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                //log.msg(this, "######## start closing #######");
                timer_stop();
                CpsNet.cleanup();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR Closing");
            }
            finally {
                safe_projekt_data();
                list_plc.Clear();
                Thread.Sleep(150);
            }
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
            safe_projekt_data();

            SaveFileDialog savefd = new SaveFileDialog();
            savefd.InitialDirectory = var.default_project_data_path;
            savefd.FileName = var.tool_text + "_" + DateTime.Now.Year.ToString() + "-" + DateTime.Now.Month.ToString() + "-" + DateTime.Now.Day.ToString();
            savefd.Filter = "Zip-File (*.zip)|*.zip";
            if (savefd.ShowDialog() == DialogResult.OK)
                zip(savefd.FileName, true);
            var.default_project_data_path = savefd.InitialDirectory;
            //log.msg(this, "save project data to: " + savefd.FileName);
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
            FrmParam fp = new FrmParam(this, list_aktuator, list_plc, list_platform);
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

            FrmConfigPlatform FCP = new FrmConfigPlatform(list_platform, list_aktuator, list_plc, this);
            FCP.ShowDialog();
        }

        #endregion

        #region menue expert
        private void openWorkingDirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Directory.Exists(var.workingdir))
                System.Diagnostics.Process.Start("explorer.exe", var.workingdir);
        }
        private void openDebugConsoleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //TODO: extract Form Dbg -> //
            //if (frmdbg != null)
            //    frmdbg.Visible = true;
            //else
            //    MessageBox.Show("restart " + var.tool_text + " in expert mode","error");

            //plc_eg.log_dbg(frmdbg);
            //plc_og.log_dbg(frmdbg);
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
            if (managementToolStripMenuItem.Text == "MngData [on]" || managementToolStripMenuItem.Text == "MngData")
            {
                timer_MngData.Stop();
                managementToolStripMenuItem.Text = "MngData [off]";
            }
            else
            {
                timer_MngData.Start();
                managementToolStripMenuItem.Text = "MngData [on]";
            }
        }
        private void iODataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (iODataToolStripMenuItem.Text == "PdataIO [on]" || iODataToolStripMenuItem.Text == "PdataIO")
            {
                timer_refresh_controls.Stop();
                iODataToolStripMenuItem.Text = "PdataIO [off]";
            }
            else
            {
                timer_refresh_controls.Start();
                iODataToolStripMenuItem.Text = "PdataIO [on]";
            }
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
            MessageBox.Show("todo -> not jet implemented in cpsLIB", "TODO");
            //foreach(plc p in list_plc)
            //    if (p.get_plc_ip() == var.tmp_PLC_EG_IP)
            //        p.putFrameToStack(new Frame(Frame.SET_STATE(11, "2", "0")));
        }

        private void rcvSTOPToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("todo -> not jet implemented in cpsLIB", "TODO");
            //foreach (plc p in list_plc)
            //    if (p.get_plc_ip() == var.tmp_PLC_EG_IP)
            //        p.putFrameToStack(new Frame(Frame.SET_STATE(11, "1", "0")));
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
            //log.msg(this, "delete log file");
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
            //string conn_string = "Server=192.168.1.200;Database=auto_home;Uid=auto_home;Pwd=XuY98zjMce8VuWZP";
            AH_DataLogger.FrmDataLogger fm = new AH_DataLogger.FrmDataLogger( var.DBServerIP, var.DBName, var.DBUid, var.DBPwd);
            fm.Show();
        }

        private void tableToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AH_DataLogger.FrmTables ft = new AH_DataLogger.FrmTables();
            ft.Show();
        }

        private void cPSLIBGUIToolStripMenuItem_Click(object sender, EventArgs e)
        {

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

        #endregion

        #region footer - status bar
        #region server
        private void startServerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (CpsNet != null)
                CpsNet.serverSTART(var.CpsServerPort);
            else
                MessageBox.Show("CpsNet == null");
        }
        private void stopServerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (CpsNet != null)
                CpsNet.serverSTOP();
            else
                MessageBox.Show("CpsNet == null");
        }
        private void connectAllClientsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //try to connect (send SYNC frame) with all projected plc´s
            foreach (plc p in list_plc)
                p.connect(CpsNet, FrmLog);
        }
        private void logHideToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (logHideToolStripMenuItem.Text == "Form Status Log [show]")
            {
                CpsNet.FrmLogShow(true);
                logHideToolStripMenuItem.Text = "Form Status Log [hide]";
            }
            else {
                CpsNet.FrmLogShow(false);
                logHideToolStripMenuItem.Text = "Form Status Log [show]";
            }
        }

        private void dBGFrmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CpuPcStack.FrmCPS fCPS = new CpuPcStack.FrmCPS(CpsNet);
            fCPS.Show();
        }
        /*
        private void footer_connection_status_Click(object sender, EventArgs e)
        {
            CpuPcStack.FrmCPS fCPS = new CpuPcStack.FrmCPS(CpsNet);
            fCPS.Show();
        }
        */
        #endregion

        #region clients
        //List<ToolStripDropDownButton> list_TSDDB_plc = new List<ToolStripDropDownButton>();
        private ToolStripStatusLabel TSSL_diag;
        private ToolStripStatusLabel TSSL_connect;
        private ToolStripStatusLabel TSSL_ibs;
        private ToolStripStatusLabel TSSL_SetTime;
        private void make_status_bar()
        {

            foreach (plc p in list_plc)
            {
                ToolStripDropDownButton TSDDB = new ToolStripDropDownButton("->" + p.get_plc_name(), null, null, "->" + p.get_plc_name());
                TSDDB.Tag = p;

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

                TSSL_SetTime = new ToolStripStatusLabel("set time " + DateTime.Now.ToString());
                TSSL_SetTime.Tag = p;
                TSSL_SetTime.Click += new EventHandler(TSSL_OnClickSetTime);
                TSDDB.DropDownItems.Add(TSSL_SetTime);

                statusStrip_bottom.Items.Add(TSDDB);
                //p.init_TSDDB(TSDDB);
                //list_TSDDB_plc.Add(TSDDB);
            }
        }

        void TSSL_OnClickConnect(object sender, EventArgs e)
        {
            ToolStripLabel o = sender as ToolStripLabel;
            if (o != null && o.Tag != null)
                ((plc)o.Tag).connect(CpsNet, FrmLog);
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
                ((plc)o.Tag).send(f, FrmLog);
            else
                MessageBox.Show("TSSL_OnClickSetTime()", "ToolStripLabel o == null");
        }

        //##################################### IBS Function ############################################
        void TSSL_OnClickIBS(object sender, EventArgs e)
        {
            ToolStripLabel o = sender as ToolStripLabel;

            for (Int16 i = 0; i < Convert.ToInt16(textBox1.Text); i++)
            {
                if (o != null) { 
                    //Frame f = new Frame(((plc)o.Tag).getClient(), new Int16[] { i, 1, 1, 1, 255, 255, 256, 257, -1, -1, -1 });
                    //f.SetHeaderFlag(FrameHeaderFlag.ACKN);
                    //((plc)o.Tag).send(f, FrmLog);

                    //Frame f2 = new Frame(((plc)o.Tag).getClient(), new Int16[] { 999, 1, i });
                    //f2.SetHeaderFlag(FrameHeaderFlag.PdataIO);
                    //((plc)o.Tag).send(f2, FrmLog);

                    Frame f3 = new Frame(((plc)o.Tag).getClient(), new Int16[] { 1, i });
                    f3.SetHeaderFlag(FrameHeaderFlag.MngData);
                    ((plc)o.Tag).send(f3, FrmLog);
                }
                else
                {
                    MessageBox.Show("TSSL_OnClickIBS()", "ToolStripLabel o == null");
                    return;
                }

            }
        }
        #endregion
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
            paint_platform();
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

            foreach (aktuator a in list_aktuator) {
                if (a.GetAktType() == (aktor_type)comboBox_aktor_type.SelectedItem)
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
                        pictureBox_platform.Controls.Remove(pc._PictureBox);
                        pc._PictureBox.MouseDown -= new MouseEventHandler(_PictureBox_MouseDown);
                    }
                }

            if (!clear)
            {//event handler zuweisen und bild zeichnen
                platform p_selected = (platform)comboBox_platform.SelectedItem;
                if (p_selected != null)
                    foreach (platform_control pc in p_selected._list_platform_control)
                        if (pc._aktuator != null ) //controlls denen kein aktor zugewiesen ist nicht zeichnen
                        {
                            if (pc._PictureBox != null)//platform_control mit sensor_value haben keine PictrueBox sondern UC_SensorValue
                            {
                                pictureBox_platform.Controls.Add(pc._PictureBox);
                                pictureBox_platform.Image = p_selected.get_background_pic();
                                pc._PictureBox.MouseDown += new MouseEventHandler(_PictureBox_MouseDown);
                            }
                            else {
                                pictureBox_platform.Controls.Add(pc._UCsensorValue);
                            }
                        }
                if (p_selected != null && p_selected._floor_plan != null)
                    pictureBox_platform.Size = new Size(p_selected._floor_plan._picture_width, p_selected._floor_plan._picture_heigth);
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
            this.Size = new Size(pictureBox_platform.Size.Width + 250, pictureBox_platform.Size.Height + 130) ;
        }
        #endregion

        #region platform event handler
        FrmMain_controlDialog _FrmMain_controlDialog;
        void _PictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            PBplatformControl c = (PBplatformControl)sender;

            aktuator a = c._platform_control._aktuator;
            switch (a._type)
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
        //System.Windows.Forms.Timer timer_refresh_main;
        System.Windows.Forms.Timer timer_MngData;
        System.Windows.Forms.Timer timer_refresh_controls;
        System.Windows.Forms.Timer timer_footer_connection_status;

        private void init_timer()
        {           
            //timer_refresh_main = new System.Windows.Forms.Timer();
            ////timer_refresh_main.Interval = var.timer_plc_management_interval;
            //timer_refresh_main.Interval = 500;
            //timer_refresh_main.Tick +=new EventHandler(timer_refresh_main_Tick);

            timer_refresh_controls = new System.Windows.Forms.Timer();
            timer_refresh_controls.Interval = var.timer_control_interval;
            timer_refresh_controls.Tick += new EventHandler(timer_refresh_control_Tick);

            timer_footer_connection_status = new System.Windows.Forms.Timer();
            timer_footer_connection_status.Interval = 100;
            timer_footer_connection_status.Tick += new EventHandler(footer_connection_status_Tick);

            timer_MngData = new System.Windows.Forms.Timer();
            timer_MngData.Interval = var.timer_MngData_interval;
            timer_MngData.Tick += new EventHandler(timer_MngData_Tick);

            if (var.start_timers_at_start)
                timer_start();
        }

        private void timer_start()
        {
            //timer_refresh_main.Start();
            timer_MngData.Start();
            timer_refresh_controls.Start();
            timer_footer_connection_status.Start();
        }
        private void timer_stop()
        {
            timer_MngData.Stop();
            //timer_refresh_main.Stop();
            timer_refresh_controls.Stop();
            timer_footer_connection_status.Stop();
        }



        void timer_refresh_main_Tick(object sender, EventArgs e)
        {
            //TODO job.GET_CPU_TIME
            /*
            foreach (plc p in list_plc)
                if(p.isConnected())
                    p.putFrameToStack(new Frame(Frame.GETbyJOB(cpu_net_management, job.GET_CPU_TIME)));
                //send_stack.put(new Frame(Frame.GETbyJOB(ID_sense_data, job.GET_CPU_TIME)), var.PLC_OG_IP);

            //TODO: weather / eta als aktor mit projektieren
            foreach (plc p in list_plc)
                if (p.get_plc_ip() == var.tmp_PLC_EG_IP)
                { 
                    p.putFrameToStack(new Frame(Frame.GETbyJOB(cpu_net_management, job.GET_WEATHER)));
                    p.putFrameToStack(new Frame(Frame.GETbyJOB(ID_ETA, job.get_state)));
                }
             * */
        }

        void timer_MngData_Tick(object sender, EventArgs e)
        {
            if (list_plc.Count > 0)
                foreach (plc p in list_plc)
                    if (p.getClient().state == udp_state.connected)
                        p.send(Frame.MngData(p.getClient(), DataMngType.GetPlcTime));
        }

        void footer_connection_status_Tick(object sender, EventArgs e)
        {
            this.Text = "AutoHome " + CpsNet.GetStatus();
        }

        void timer_refresh_control_Tick(object sender, EventArgs e)
        {
            Dictionary<Int16, plc> sensor_dic = new Dictionary<short, plc>(); //enthält alle projektierten aktuatoren vom typ sensor
            //List<Int16, plc> list_sensor = new List<short>();
            //############################### automatisches update der controlls #################################################
            if (pictureBox_platform.Visible)
                //bei kaputem serialise file keine elemente
                if (list_platform.Any())
                    if (comboBox_platform.SelectedItem != null)
                        foreach (platform_control pc in ((platform)comboBox_platform.SelectedItem)._list_platform_control)
                            //controlls denen kein aktor zugewiesen ist nicht beachten
                            if (pc._aktuator != null && pc._aktuator._plc != null) 
                                //sensor controlls sammeln und in einzelnen management frame versenden
                                if (pc._aktuator.GetAktType() == aktor_type.sensor) 
                                    sensor_dic.Add(pc._aktuator.Index, pc._aktuator._plc);
                                else
                                    pc._aktuator.plc_send_IO(DataIOType.GetState);

            //send sensor value request
            foreach (plc p in list_plc) {
                List<Int16> list_sensor = new List<short>();
                foreach (KeyValuePair<Int16, plc> var in sensor_dic)
                    if (p == var.Value)
                        list_sensor.Add(var.Key);

                //if (list_sensor.Any())
                if (list_sensor.Count > 0)
                {
                    //sende frame an plc
                    list_sensor.Insert(0, (Int16)DataMngType.GetPlcSensorValues);
                    p.send(FrameHeaderFlag.MngData, list_sensor.ToArray());
                }
            }
        }
        #endregion

        #region client callback (darstellung der werte in GUI)
        
         /// <summary>
        /// interpretes the received Cps frame and display results @ gui
        /// </summary>
        /// <param name="f">received Cps frame</param>
        private delegate void interprete_frameCallback(object f);
        void IcpsLIB.interprete_frame(object o)
        {
            try
            {
                if (this.InvokeRequired)
                    this.Invoke(new interprete_frameCallback(this.interprete_frame_fkt), new object[] { o });
                else
                    interprete_frame_fkt(o);
            }
            catch (Exception e)
            {
                if (var.display_exception)
                    MessageBox.Show("interprete_frameCallback: " + e.Message, "writing to GUI failed");
            }
        }

        private void interprete_frame_fkt(object f)
        {
            Frame _f = (Frame)f;

            if (_f.GetHeaderFlag(FrameHeaderFlag.SYNC)) { }
            else if (_f.GetHeaderFlag(FrameHeaderFlag.MngData))
                interprete_MngData(_f);
            else if (_f.GetHeaderFlag(FrameHeaderFlag.ACKN))
                FrmLog.AddLog("RCV: ACKN {" + _f.ToString() + "}");
            else if (_f.GetHeaderFlag(FrameHeaderFlag.PdataIO))
                interprete_IOData(_f);
            else
                FrmLog.AddLog("RCV: UNKNOWN {" + _f.ToString() + "}");
        }

        private void interprete_MngData(Frame f) {
            //FrmLog.AddLog("RCV: MngData {" + f.ToString() + "}");

            foreach (ToolStripDropDownButton p in statusStrip_bottom.Items)
            {
                //statusStrip_bottom contains CPSstatus Label with no p.Tag
                if (p.Tag != null && (f.client.RemoteIp == ((plc)p.Tag).getClient().RemoteIp)) {
                    try
                    {
                        if (f.getPayloadInt(0) == (Int16)DataMngType.GetPlcTime)
                        {
                            DateTime clockPlc = new DateTime(f.getPayloadInt(1), f.getPayloadInt(2), f.getPayloadInt(3), f.getPayloadInt(4), f.getPayloadInt(5), f.getPayloadInt(6));

                            p.Text = p.Name + " [" + clockPlc.ToString("HH:mm:ss") + "]";
                            p.BackColor = Color.Transparent;
                            if (DateTime.Now.Subtract(new TimeSpan(0, 0, var.MngData_AcceptedClockDelay)) > clockPlc)
                            {
                                TimeSpan ts = DateTime.Now - clockPlc;
                                //p.Text = p.Text + " > " + ts.ToString(TSFormat(ts));
                                p.Text = p.Text + " > " + ts.ToString(TSFormat(ts));
                                p.BackColor = Color.Yellow;
                            }
                            else if (DateTime.Now.Add(new TimeSpan(0, 0, var.MngData_AcceptedClockDelay)) < clockPlc)
                            {
                                TimeSpan dt = clockPlc - DateTime.Now;
                                //p.Text = p.Text + " < " + dt.ToString(TSFormat(dt));
                                p.Text = p.Text + " < " + dt.ToString(TSFormat(dt));
                                p.BackColor = Color.Yellow;
                            }
                        }
                        else if (f.getPayloadInt(0) == (Int16)DataMngType.SetPlcTime) {
                            Int16 retval = f.getPayloadInt(1);
                            if(retval>0)
                                MessageBox.Show("retval: " + f.getPayloadInt(1) + Environment.NewLine + " see TIA Help [WR_SYS_T: Set time-of-day]", "SetPlcTime: ERROR");
                        }
                        else if (f.getPayloadInt(0) == (Int16)DataMngType.GetPlcSensorValues)
                        {
                            if (pictureBox_platform.Visible)
                            {
                                platform p_selected = (platform)comboBox_platform.SelectedItem;
                                if (p_selected != null)
                                {
                                    FrmLog.AddLog("SensorVal: " + f.ShowPayloadInt());
                                    Dictionary<Int16, float> dicSensorVal = new Dictionary<short, float>();
                                    dicSensorVal.Clear();
                                    //komplettes frame durchgehen und auspacken. für jeden sensorwert entsprechendes controll befüllen
                                    float SensorValue;
                                    for (int i = 3; i < (f.getPaloadIntLengt()); i = i + 3)
                                    {
                                        if (f.getPayloadInt(i + 2) != 0)
                                            SensorValue = (float) f.getPayloadInt(i + 1) / (float)f.getPayloadInt(i + 2);
                                        else
                                            SensorValue = f.getPayloadInt(i + 1);

                                        dicSensorVal.Add(f.getPayloadInt(i), SensorValue);
                                    }

                                    p_selected.update_SensorControl(dicSensorVal);


                                    //p_selected.update_control(f);
                                    //FrmLog.AddLog("SensorVal_dic: " + f.ShowPayloadInt());
                                }
                            }
                        }
                    }
                    catch (Exception e) {
                        //TODO: globalen error log mit notify in GUI einrichten
                        //MessageBox.Show(e.Message, "exception")
                            FrmLog.AddLog("Exception interprete_MngData: " + e.Message);
                        ;
                    }


                }   
            }
        }
        private string TSFormat(TimeSpan ts) {
            string format = "";

            if (ts.Days != 0)
                format = @"d\T\ hh\:mm";
            else if (ts.Hours != 0)
                format = @"hh\:mm\:ss";
            else if (ts.Minutes != 0)
                format = @"mm\:ss";
            else if (ts.Seconds != 0)
                format = @"ss\.fff";
            else
                format = @"ss\.fffff";
            return format;
        }

        private void interprete_IOData(Frame f) {
            /// DBG -  display all IOData in Log Form
            FrmLog.AddLog("IOData {" + f.client.RemoteIp + " " + f.ToString() + "} " + f.getPayloadHex() + " / " + f.ShowPayloadInt());

            //[view platform] fill aktuator dialog box with values
            if (_FrmMain_controlDialog != null)
                if (f.isIOIndex(_FrmMain_controlDialog.get_aktuator_id()))
                    _FrmMain_controlDialog.update_with_frame(f);

            //update [view controls]
            if (pictureBox_platform.Visible)
            {
                //update [view platform] GUI with values
                platform p_selected = (platform)comboBox_platform.SelectedItem;
                if (p_selected != null)
                    p_selected.update_control(f);
            }
            else if (panel_controls.Visible)
            {
                foreach (aktuator_control ac in list_aktuator_controls)
                {
                    if (f.isIOIndex(ac.aktuatorIndex))
                        ac.interprete(f);
                }
            }
            else { } //TODO:globale log funktion einbauen
        }

        /// <summary>
        /// log/error messages from udp server
        /// </summary>
        /// <param name="s"></param>
        private delegate void srv_msgCallback(string s);
        void IcpsLIB.logMsg(string msg)
        {
            try
            {
                this.Invoke(new srv_msgCallback(this.srv_msg_funkt), new object[] { msg });
                log.msg(this, "IcpsLIB.logMs " + msg);
            }
            catch (Exception e)
            {
                //form closing throws exeption -> TODO catch
                log.exception(this, "srv_msgCallback: writing to GUI failed", e);
                //MessageBox.Show("srv_msgCallback: " + e.Message, "writing to GUI failed");
            }
        }
        private void srv_msg_funkt(string s)
        {
            //footer_CpsServerStatus.Text = s;
            FrmLog.AddLog(s);
        }
        #endregion


        #region alt TCP [client callback (darstellung der werte in GUI)]
        /// <summary>
        /// auswertung des frames und manipulieren der oberfläche entsprechend den daten
        /// </summary>
        /// <param name="f"></param>
        /// VERSCHOBEN
        /*
        private void interprete_frame_funkt_platform(Frame f)
        {
            if (_FrmMain_controlDialog != null)
                if (f.isIndex(_FrmMain_controlDialog.get_aktuator_id()))
                    _FrmMain_controlDialog.update_with_frame(f);

            platform p_selected = (platform)comboBox_platform.SelectedItem;
            if (p_selected != null)
                p_selected.update_control(f);
        }

        private void interprete_frame_funkt_plc_management(Frame f) {
            
            //TODO in aktor auslagern
                if (f.isIndex(cpu_net_management)) //sensorikwerte auf gui ausgeben
                {

                    if (f.isJob(DataIOType.GET_CPU_TIME))
                    {
                        
                        plc _plc = list_plc.Find(x => x._ip.Equals(f.getIP()));
                        if (_plc == list_plc[0])
                            clockToolStripMenuItem.Text = "clock [" + f.getPayload(0) + "/" + f.getPayload(1) + "/" + f.getPayload(2) + " " + f.getPayload(3) + ":" + f.getPayload(4) + ":" + f.getPayload(5) + "]";
                        else if (_plc == list_plc[1])
                            clockToolStripMenuItem1.Text = "clock [" + f.getPayload(0) + "/" + f.getPayload(1) + "/" + f.getPayload(2) + " " + f.getPayload(3) + ":" + f.getPayload(4) + ":" + f.getPayload(5) + "]";
                        //else
                        //MessageBox.Show("FrmMain.cs -> interprete_frame_funkt", "unknown PLC: " + _plc._PLC_Name + " / " + _plc._ip);
                      
                    }
                    else if (f.isJob(DataIOType.GET_WEATHER))
                    {
                        label_weather_temperature.Text = (Convert.ToDouble(f.getPayload(0)) / 100).ToString("0.0") + "° C";
                        label_weather_sun_s.Text = f.getPayload(1).ToString() + " klux";
                        label_weather_sun_w.Text = f.getPayload(2).ToString() + " klux";
                        label_weather_sun_e.Text = f.getPayload(3).ToString() + " klux";
                        label_weather_light.Text = f.getPayload(4).ToString() + " lux";
                        double wind_speed = (Convert.ToDouble(f.getPayload(5)) / 100);
                        label_weather_wind.Text = wind_speed.ToString("0.0") + " m/s";

                        if (wind_speed < 0.2) label_desc_wind.Text = "Windstille";
                        else if (wind_speed < 1.4) label_desc_wind.Text = "leiser Zug";
                        else if (wind_speed < 3.4) label_desc_wind.Text = "leichte Brise";
                        else if (wind_speed < 5.4) label_desc_wind.Text = "schwacher Wind";
                        else if (wind_speed < 7.4) label_desc_wind.Text = "mäßiger Wind";
                        else if (wind_speed < 10.4) label_desc_wind.Text = "frischer Wind";
                        else if (wind_speed < 13.4) label_desc_wind.Text = "starker Wind";
                        else if (wind_speed < 17.4) label_desc_wind.Text = "steifer Wind";
                        else if (wind_speed < 20.4) label_desc_wind.Text = "stürmischer Wind";
                        else if (wind_speed < 24.4) label_desc_wind.Text = "Sturm";
                        else if (wind_speed < 28.4) label_desc_wind.Text = "schwerer Sturm";
                        else if (wind_speed < 32.4) label_desc_wind.Text = "orkanartiger Sturm";
                        else label_desc_wind.Text = "Orkan!!";

                        if (f.getPayload(6) == 0) label_weather_rain.Text = "trocken";
                        else label_weather_rain.Text = "es regnet";
                        label_stairs_light.Text = f.getPayload(7).ToString("###") + " lux";
                        label_stairs_temperature.Text = (Convert.ToDouble(f.getPayload(8)) / 100).ToString("0.0") + "° C";
                        label_floor_temperature.Text = (Convert.ToDouble(f.getPayload(9)) / 100).ToString("0.0") + "° C";
                        label_floor_humidity.Text = (Convert.ToDouble(f.getPayload(10)) / 100).ToString("0.0") + " %";
                    }
                    //else
                    //    MessageBox.Show(f.ToString(),"rcv unknown job at ID_SENSOR");

                }
                else if (f.isIndex(ID_ETA))
                {
                    label_eta_kessel.Text = (Convert.ToDouble(f.getPayload(0)) / 10).ToString("0.0") + "° C";
                    label_eta_kesselruecklauf.Text = (Convert.ToDouble(f.getPayload(1)) / 10).ToString("0.0") + "° C";
                    label_eta_puffer_unten.Text = (Convert.ToDouble(f.getPayload(2)) / 10).ToString("0.0") + "° C";
                    label_eta_puffer_mitte.Text = (Convert.ToDouble(f.getPayload(3)) / 10).ToString("0.0") + "° C";
                    label_eta_puffer_oben.Text = (Convert.ToDouble(f.getPayload(4)) / 10).ToString("0.0") + "° C";
                    label_eta_abgas.Text = (Convert.ToDouble(f.getPayload(5)) / 10).ToString("0.0") + "° C";
                    label_eta_kollektor.Text = (Convert.ToDouble(f.getPayload(6)) / 10).ToString("0.0") + "° C";
                    label_eta_solar_unten.Text = (Convert.ToDouble(f.getPayload(7)) / 10).ToString("0.0") + "° C";
                    label_eta_vorlauf.Text = (Convert.ToDouble(f.getPayload(8)) / 10).ToString("0.0") + "° C";
                    label_eta_aussentemperatur.Text = (Convert.ToDouble(f.getPayload(9)) / 10).ToString("0.0") + "° C";
                    label_eta_pufferladezustand.Text = f.getPayload(10).ToString() + " %";
                }
                else if (f.isIndex(-1))
                {TODO frame index -1 in cpu und autohome behandeln
                        plc _plc = list_plc.Find(x => x._ip.Equals(f.getIP()));
                        _plc.newlog("index not found: " + f.getPayload(0), list_aktuator);
                        //##################################################################################################
                        //TODO ########################################### TO - DO ##############################################
                        MessageBox.Show(f.ToString(), "index not found: " + f.getPayload(0));
                        //################################################################################################## 
                        //list_plc_log_msg.Add(lg);
                        //print_log_DS(lg);
                   
                }
                else //logmeldungen als string interpretieren und anzeigen
                {
                    /*
                    if (!f.isEmptyString())
                    {
                        string msg = System.Text.Encoding.ASCII.GetString(f.getNetworkOrderFrame(), 0, f.getNetworkOrderFrame().Length);
                        plc _plc = list_plc.Find(x => x._ip.Equals(f.getIP()));
                        _plc.newlog(msg, list_aktuator);
                        _plc.new_message_count++;

                        //##################################################################################################
                        //TODO ########################################### TO - DO ##############################################
                        //MessageBox.Show("FrmMain.cs -> interprete_frame_funkt", "TO-DO");
                        //darstellung der Anzahl in PLC button
                        if (_plc == list_plc[0])
                            pLCEGToolStripMenuItem.Text = list_plc[0]._PLC_Name + "(" + list_plc[0].new_message_count.ToString() + ")";
                        else if (_plc == list_plc[1])
                            pLCOGToolStripMenuItem.Text = list_plc[1]._PLC_Name + "(" + list_plc[1].new_message_count.ToString() + ")";
                        else
                            MessageBox.Show("FrmMain.cs -> interprete_frame_funkt", "unknown PLC: " + _plc._PLC_Name + " / " + _plc._ip);
                        //################################################################################################## 

                        //nächsten log msg aufruf an plc senden
                       // TODO log
                        send_stack.put(new Frame(Frame.LOG_GET), f.getIP());
                        
                    // }

                }
                //else
                //MessageBox.Show(f.getStringFrame(),"rcv unknown Index: " + f.getIndex().ToString());
            
            #endregion
        }

        */
        #endregion

        
    }
}
