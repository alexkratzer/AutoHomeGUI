using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Reflection;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace AutoHome
{
    class var
    {
        #region vars
        public static readonly string tool_text = "AutoHome";
        public static readonly string inifile = "vars.ah";
        public static readonly string workingdir = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\" + tool_text;
        public static string file_log = workingdir + "\\log.ah";
        
        //path
        public static string default_project_data_path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
        public static string file_aktuator = "data_aktuator.ah";
        public static string file_plc = "data_plc.ah";
        public static string file_platform = "data_platform.ah";
        public static string file_plc_log_msg = "plc.log";
        public static string file_startup_config = "startup_config.ah";
        public static string file_floor_plan = "data_floor_plan.ah";
        public static string file_aktuator_control = "data_control.ah";

        //IBS vars
        public static Int32 PLCport = 23456;
        public static int max_rcv_bytes = 2048;
        public static string PLCip = "192.xxx.xxx.xxx";
        public static string tmp_PLC_EG_IP = "192.xxx.xxx.xxx"; //CPU EG
        public static int PLC_PORT = 12345;
        //public static bool AutoUpdateControlTimer = true;
        
        //settings
        public static bool connect_to_plc_at_start = false;
        public static bool start_timers_at_start = true;
        public static bool display_exception = false;
        public static int footer_connection_status = 1000; //refresh timer der cpu management daten
        public static int timer_GetRequestInterval = 1000; //refresh timer der ManagementDaten aus cpu
        public static int timer_refresh_GUI = 1000; //refresh timer der aktualisierung von control elementen
        public static bool show_expert_mode = false;
        public static int connect_error_retrys = 5; //anzahl der fehler bei verbindungsproblemen bis abbruch
        //public static bool make_connection_OnRcvUnknownFrame = true;

        //CpsLIB Vars
        public static int CpsServerPort = 50000;
        public static int MngData_AcceptedClockDelay = 5;//tollerierte Uhrzeitabweichung in sekunden zwischen pc und plc bis wann die differenz angezeigt wird
        public static bool ClientSendOnlyIfConnected = false;
        public static bool CpsNet_FrmStatusLog = false;
        public static Int16 WatchdagTime_PLCtoPC = 2000; //erlaubte zeitdauer (in ms) bis antwort zu request kommen muss

        //Datenbank Verbindung
        public static string DBServerIP;
        public static string DBName;
        public static string DBUid;
        public static string DBPwd;

        //GUI vars
        public static bool FooterShowPlcTime = false;
        public static int LastPlatformView = 0;
        public static bool Notify = false;
        //public static bool LastShowFormFrameLog = false;

            
        //======================== image files =============================
        //sind jetzt als resourcen direkt im projekt eingebunden
        //public static string img_candle = workingdir + "\\img_candle_default.png";
        //public static string img_heater = workingdir + "\\img_heater_default.png";
        //public static string img_jalousie = workingdir + "\\img_jalousie_default.png";
        //public static string img_undef = workingdir + "\\img_undef_default.png";

        //public static string img_candle_on = workingdir + "\\img_candle_on.png";
        //public static string img_candle_off = workingdir + "\\img_candle_off.png";
        //public static string img_jalousie_down = workingdir + "\\img_jalousie_down.png";
        //public static string img_jalousie_middle = workingdir + "\\img_jalousie_middle.png";
        //public static string img_jalousie_up = workingdir + "\\img_jalousie_up.png";
        //public static string img_heater_on = workingdir + "\\img_heater_on.png";
        //public static string img_heater_off = workingdir + "\\img_heater_off.png";
        //public static string img_heater_on_manual = workingdir + "\\img_heater_on_manual.png";
        //public static string img_heater_off_manual = workingdir + "\\img_heater_off_manual.png";
        #endregion

        #region ini file
        //write / read ini file
        public static void read_ini_file()
        {
            try
            {
                string path = workingdir + "\\" + inifile;

                if (!Directory.Exists(workingdir))
                    Directory.CreateDirectory(workingdir);

                if (File.Exists(path))
                {
                    string[] inidata = File.ReadAllText(path).Split(';');                        
                    Type t = typeof(var);

                    foreach (string s in inidata)
                    {
                        string line = s.Trim(Environment.NewLine.ToCharArray());
                        string[] row = line.Split('=');

                        foreach (FieldInfo field in t.GetFields())
                        {
                            if (field.Name == row[0] && row.Length == 2)
                            {
                                if (field.FieldType.Name.Equals("String"))
                                    field.SetValue(null, row[1]);
                                else if (field.FieldType.Name.Equals("Boolean"))
                                    field.SetValue(null, Convert.ToBoolean(row[1]));
                                else if (field.FieldType.Name.Equals("Int32"))
                                    field.SetValue(null, Convert.ToInt32(row[1]));
                                else if (field.FieldType.Name.Equals("Int16"))
                                    field.SetValue(null, Convert.ToInt16(row[1]));
                                //else
                                //dbg.log("var", "value type not available: " + field.FieldType.Name, true);
                            }
                        }
                    }
                    //log.msg("var", Environment.NewLine + Environment.NewLine + "read_ini_file() DONE");
                }
                else
                    log.msg("var", "read_ini_file() FAILED -> File: \"" + path + "\" not found");
            }
            catch (Exception e) { log.exception("var", "read_ini_file()", e); }

        }

        public static void write_ini_file()
        {
            try
            {
                string filepath = workingdir + "\\" + inifile;

                if (File.Exists(filepath))
                    File.Delete(filepath);
                if (!Directory.Exists(workingdir))
                    Directory.CreateDirectory(workingdir);

                var p = new var();
                Type type = p.GetType();

                BindingFlags flags = BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static | BindingFlags.Instance | BindingFlags.DeclaredOnly;
                FieldInfo[] fields = type.GetFields(flags);

                foreach (FieldInfo field in fields)
                    File.AppendAllText(filepath, field.Name.ToString() + "=" + field.GetValue(p) + ";" + Environment.NewLine);

                //log.msg("var", "write_ini_file() DONE");
            }
            catch (Exception e) { log.exception("var", "write_ini_file()", e); }
        }
        #endregion

        #region serialize
        public static void serialize_plc(List<plc> list)
        {
            //TODO: überprüfen ob hash überhaupt noch verwendet wird
            //evtl nur noch von gui controlls aber nicht mehr zwischen plc und aktuator
            foreach (plc p in list)
                foreach (aktuator a in p.ListAktuator)
                    a.set_aktor_hash(); //eigenen hash erzeugen
            
            try
            {
                IFormatter formatter = new BinaryFormatter();
                Stream stream = new FileStream(var.workingdir + "\\" + var.file_plc,
                                         FileMode.Create,
                                         FileAccess.Write, FileShare.None);

                formatter.Serialize(stream, list);
                stream.Close();
            }
            catch (Exception e)
            {
                log.exception("var", "serialize_plc()", e);
            }  
        }

        //public static void serialize_aktor(List<aktuator> list)
        //{
        //    try
        //    {
        //        foreach (aktuator a in list)
        //        {
        //            a.serialize_init(); //mapped_hash der zugehörigen PLC speichern
        //            a.set_aktor_hash(); //eigenen hash erzeugen
        //        }

        //        IFormatter formatter = new BinaryFormatter();
        //        Stream stream = new FileStream(var.workingdir + "\\" + var.file_aktuator,
        //                                 FileMode.Create,
        //                                 FileAccess.Write, FileShare.None);

        //        formatter.Serialize(stream, list);
        //        stream.Close();
        //        //log.msg("var", "serialize_aktor() DONE");
        //    }
        //    catch (Exception e) {
        //        log.exception("var", "serialize_aktor()", e);
        //    }
        //}

        public static void serialize_platform(List<platform> list)
        {
            try{
                foreach (platform p in list) {
                    //alle controls ohne zugewiesenem aktuator entfernen
                    p._list_platform_control.RemoveAll(x => x._aktuator == null);
                    foreach (platform_control pc in p._list_platform_control)
                    {
                        pc._PictureBox = null; //alle bilder-controlls löschen da nicht serialisierbar
                        pc.serialize_init(); //mapped hash des zugehörigen aktors speichern
                    }
                }
                IFormatter formatter = new BinaryFormatter();
                Stream stream = new FileStream(var.workingdir + "\\" + var.file_platform,
                                         FileMode.Create,
                                         FileAccess.Write, FileShare.None);

                formatter.Serialize(stream, list);
                stream.Close();
                //log.msg("var", "serialize_platform() DONE");
            }
            catch (Exception e)
            {
                log.exception("var", "serialize_platform()", e);
            }
        }

        public static void serialize_floor_plan(List<floor_plan> list)
        {
            try
            {
                IFormatter formatter = new BinaryFormatter();
                Stream stream = new FileStream(var.workingdir + "\\" + var.file_floor_plan,
                                         FileMode.Create,
                                         FileAccess.Write, FileShare.None);

                formatter.Serialize(stream, list);
                stream.Close();
            }
            catch (Exception e)
            {
                log.exception("var", "serialize_floor_plan()", e);
            }
        }

        #endregion

        #region deserialize
        public static List<plc> deserialize_plc()
        {
            List<plc> list = new List<plc>();

            try{
                string path = var.workingdir + "\\" + var.file_plc;
                if (File.Exists(path))
                {
                    IFormatter formatter = new BinaryFormatter();
                    Stream stream = new FileStream(path,
                                              FileMode.Open,
                                              FileAccess.Read,
                                              FileShare.Read);
                    list = (List<plc>)formatter.Deserialize(stream);
                    stream.Close();
                }
                else
                    log.msg("var", "deserialize_plc() FAILED -> File: \"" + path + "\" not found");
            }
            catch (Exception e)
            {
                log.exception("var", "deserialize_plc()", e);
            }


            foreach (plc p in list)
                foreach (aktuator a in p.ListAktuator)
                    a._plc = p;

            return list;
        }

        /// überflüssig da jetzt jede plc ihre eigene aktor liste hat
        //public static List<plc> deserialize_aktor(List<plc> list_plc)
        //{
        //    List<aktuator> list = new List<aktuator>();

        //    foreach (plc p in list_plc)
        //        p.ListAktuator = new List<aktuator>();

        //    try
        //    {
        //        string path = var.workingdir + "\\" + var.file_aktuator;
        //        if (File.Exists(path))
        //        {
        //            IFormatter formatter = new BinaryFormatter();
        //            Stream stream = new FileStream(path,
        //                                      FileMode.Open,
        //                                      FileAccess.Read,
        //                                      FileShare.Read);
        //            list = (List<aktuator>)formatter.Deserialize(stream);
        //            stream.Close();

        //            foreach (aktuator a in list)
        //                a.deserialize_init(list_plc);
        //        }
        //        else
        //            log.msg("var", "deserialize_aktor() FAILED -> File: \"" + path + "\" not found");

        //    }
        //    catch (Exception e)
        //    {
        //        log.exception("var", "deserialize_aktor()", e);
        //    }

        //    ///########################### IBS zeuchs
        //    //foreach (aktuator a in list)
        //    //{
        //    //    foreach (plc p in list_plc)
        //    //    {
        //    //        if (a._plc == p)
        //    //            p.ListAktuator.Add(a);
        //    //    }
        //    //}


        //    return list_plc;
        //}

        public static List<platform> deserialize_platform(List<plc> list_aktuator)
        {
            List<platform> list = new List<platform>();

            try
            {
                string path = var.workingdir + "\\" + var.file_platform;
                if (File.Exists(path))
                {
                    IFormatter formatter = new BinaryFormatter();
                    Stream stream = new FileStream(path,
                                              FileMode.Open,
                                              FileAccess.Read,
                                              FileShare.Read);
                    list = (List<platform>)formatter.Deserialize(stream);
                    stream.Close();

                    foreach (platform p in list)
                        foreach (platform_control pc in p._list_platform_control)
                            pc.deserialize_init(list_aktuator);
                                //log.msg("var", "deserialize_platform() DONE");
                }
                else
                    log.msg("var", "deserialize_platform() FAILED -> File: \"" + path + "\" not found");

                ////allen platform_controls ein pictur zuweisen
                //foreach (platform p in list)
                //    foreach (platform_control pc in p._list_platform_control)
                //        pc.init_picture();
                
            }
            catch (Exception e) {
                log.exception("var", "deserialize_platform()", e);
            }
            return list;
        }

        public static List<floor_plan> deserialize_floor_plan()
        {
            List<floor_plan> list = new List<floor_plan>();
            try
            {
                string path = var.workingdir + "\\" + var.file_floor_plan;
                if (File.Exists(path))
                {
                    IFormatter formatter = new BinaryFormatter();
                    Stream stream = new FileStream(path,
                                              FileMode.Open,
                                              FileAccess.Read,
                                              FileShare.Read);
                    list = (List<floor_plan>)formatter.Deserialize(stream);
                    stream.Close();
                    //log.msg("var", "deserialize_floor_plan() DONE");
                }
                else
                    log.msg("var", "deserialize_floor_plan() FAILED -> File: \"" + path + "\" not found");

            }
            catch (Exception e)
            {
                log.exception("var", "deserialize_floor_plan()", e);
            }
            return list;
        }

        #endregion

        #region archiv
        /*
        public static void serialize_plc_log(List<plc_log_msg> list_plc_log_msg)
        {
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream(var.workingdir + "\\" + var.file_plc_log_msg,
                                     FileMode.Create,
                                     FileAccess.Write, FileShare.None);

            formatter.Serialize(stream, list_plc_log_msg);
            stream.Close();
        }
        public static List<plc_log_msg> deserialize_plc_log()
        {
            List<plc_log_msg> list = new List<plc_log_msg>();

            string path = var.workingdir + "\\" + var.file_plc_log_msg;
            if (File.Exists(path))
            {
                IFormatter formatter = new BinaryFormatter();
                Stream stream = new FileStream(path,
                                          FileMode.Open,
                                          FileAccess.Read,
                                          FileShare.Read);
                list = (List<plc_log_msg>)formatter.Deserialize(stream);
                stream.Close();
            }
            return list;
        }
        */
        /*
        public static void serialize(List<object> list)
        {
            foreach (aktuator a in list)
                a.user_control = null;

            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream(var.workingdir + "\\" + var.aktuator_file,
                                     FileMode.Create,
                                     FileAccess.Write, FileShare.None);

            formatter.Serialize(stream, list);
            stream.Close();
        }

        // READ serialised objects
        public static List<object> deserialize(string file_name)
        {
            //List<aktuator> list = new List<aktuator>();
            List<object> lo = new List<object>();
          
            string path = var.workingdir + "\\" + file_name;
            if (File.Exists(path))
            {
                IFormatter formatter = new BinaryFormatter();
                Stream stream = new FileStream(path,
                                          FileMode.Open,
                                          FileAccess.Read,
                                          FileShare.Read);
                lo = (List<object>)formatter.Deserialize(stream);
                stream.Close();
            }
            return lo;
        }
        */
        //// READ FROM FILE
        //public static List<aktuator> read_aktuator_file()
        //{
        //    List<aktuator> list = new List<aktuator>();
        //    if (File.Exists(var.workingdir + "\\" + var.ini_aktuator))
        //    {
        //        string[] data = File.ReadAllLines(var.workingdir + "\\" + var.ini_aktuator);
        //        foreach (string line in data)
        //            if (!line.StartsWith("#") && !String.IsNullOrEmpty(line))
        //                list.Add(new aktuator(line));
        //    }
        //    else
        //    {
        //        File.AppendAllText(var.workingdir + "\\" + var.ini_aktuator, "################# " + var.tool_text + " aktuator config ################" + Environment.NewLine +
        //            "#write one line for each aktuator with PLC_name, ID, type and Name:" + Environment.NewLine +
        //            "#for example: " + Environment.NewLine +
        //            "#EG:50:jalousie:OFFICE" + Environment.NewLine +
        //            "#OG:51:light:OFFICE_CEILING" + Environment.NewLine +
        //            "#lines starting with \"#\" will be ignored" + Environment.NewLine);
        //        System.Diagnostics.Process.Start("notepad", var.workingdir + "\\" + var.ini_aktuator);
        //    }

        //    return list;
        //}
        #endregion
    }
    
}
