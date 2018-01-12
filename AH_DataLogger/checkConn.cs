using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;

namespace AH_DataLogger
{
    public class checkConn
    {
        public static bool connection_valid = true;
        public static MySqlConnection con;
        public static string connection_status = null;

        public static bool checkDB(string DBServerIp, string DBName, string DBUid, string DBPwd)
        {
            string conn_string = "Server=" + DBServerIp + ";Database=" + DBName + ";Uid=" + DBUid + ";Pwd=" + DBPwd;
            if (con != null && con.State != System.Data.ConnectionState.Closed)
            {
                connection_valid = false;
                connection_status = "open() ERROR: connection not null OR not closed... " + conn_string;
                return false;
            }
            con = new MySqlConnection(conn_string);
            try
            {
                con.Open();
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                string extext = "OK";
                switch (ex.Number)
                {
                    case 0:
                        extext = "open() MySqlException: ex.Number 0 -> wrong DB name?" + conn_string;
                        break;
                    case 1042:
                        extext = "open() MySqlException: Cannot connect to server (). " + conn_string;
                        break;
                    case 1045:
                        extext = "open() MySqlException: Invalid username/password. " + conn_string;
                        break;
                    default:
                        extext = "open() MySqlException " + conn_string + " -> ex.Number: " + ex.Number.ToString() + Environment.NewLine + ex.Message.ToString();
                        break;
                }
                connection_valid = false;
                connection_status = "open() ERROR; " + extext;
                return false;
            }
            catch (Exception ex)
            {
                connection_status = "unknown MySqlException " + conn_string + Environment.NewLine + ex.Message.ToString();
                connection_valid = false;
                return false;
            }
            connection_valid = true;

            return true;
        }


        /*
        #region connect / disconnect DB
        public static MySqlConnection con; //nur wegen backgroundworker public

        public static string connection_status = null;
        static string con_string_info;
        public static bool IsConnected = false;

        public static String Conn_string
        {
            get
            {
                //TODO Datenbankverbindungen aus Debug rausschmeissen
                con_string_info = Environment.NewLine + "Server: [" + var_local.DB_ip_adress + "]" + Environment.NewLine +
                    "DB Name: [" + var_local.DB_name + "]" + Environment.NewLine + "User: [" + var_local.DB_user + "]" + Environment.NewLine;
                return "server=" + var_local.DB_ip_adress + ";userid=" + var_local.DB_user + ";password=" + var_local.DB_pwd + ";database=" + var_local.DB_name + ";Convert Zero Datetime=True"; //TODO: ;Convert Zero Datetime=True ==> wegen getRequestTaskByID() [task_stop]
            }
        }

        public static bool checkDB()
        {
            if (open())
            {
                log.msg("DB, checkDB()", "try to establish MySqlConnection: " + var_local.DB_ip_adress + " SUCCESS...");
                readToolVersion();
                close();
                DB.IsConnected = true;
                return true;
            }
            else
            {
                log.msg("DB, checkDB() / open() ", "try to establish MySqlConnection: " + var_local.DB_ip_adress + " FAILED...");
                DB.IsConnected = false;
            }
            return false;
        }

        //private static bool open()
        //{
        //    if (con != null && con.State != ConnectionState.Closed)
        //    {
        //        IsConnected = false;
        //        connection_status = "open() ERROR: connection not null OR not closed... " + con_string_info;
        //        log.msg("DB", connection_status);
        //        return false;
        //    }
        //    con = new MySqlConnection(Conn_string);
        //    try
        //    {
        //        con.Open();
        //        connection_status = "MySqlConnection " + con_string_info + "DB: " + con.ServerVersion;
        //    }
        //    catch (MySql.Data.MySqlClient.MySqlException ex)
        //    {
        //        switch (ex.Number)
        //        {
        //            case 0:
        //                connection_status = "open() MySqlException: ex.Number 0 -> wrong DB name?" + con_string_info;
        //                log.exception("DB", connection_status, ex);
        //                break;
        //            case 1042:
        //                connection_status = "open() MySqlException: Cannot connect to server (). " + con_string_info;
        //                log.exception("DB", connection_status, ex);
        //                break;
        //            case 1045:
        //                connection_status = "open() MySqlException: Invalid username/password. " + con_string_info;
        //                log.exception("DB", connection_status, ex);
        //                break;
        //            default:
        //                connection_status = "open() MySqlException " + con_string_info + " -> ex.Number: " + ex.Number.ToString() + Environment.NewLine + ex.Message.ToString();
        //                log.exception("DB", connection_status, ex);
        //                break;
        //        }
        //        IsConnected = false;
        //        return false;
        //    }
        //    catch (Exception ex)
        //    {
        //        connection_status = "unknown MySqlException " + con_string_info + Environment.NewLine + ex.Message.ToString();
        //        log.exception("DB", connection_status, ex);
        //        IsConnected = false;
        //        return false;
        //    }
        //    IsConnected = true;
        //    return true;
        //}

        private static void close()
        {
            if (con != null)
                con.Close();
            else
                log.msg("DB", "close() ERROR closing with con==null");
        } 
         * #endregion
        */
    }
}
        