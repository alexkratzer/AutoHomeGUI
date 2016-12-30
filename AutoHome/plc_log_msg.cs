using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace AutoHome
{
    
    [Serializable]
    class plc_log_msg
    {
        msg_type _msg_type = msg_type.undef;
        DateTime _datetime = DateTime.MinValue;
        string _msg = String.Empty;
        int _id = -1;
        string _id_text = ""; //bezeichnung aus aktuatorliste zu ID
        bool msg_crap = false;
        //plc _plc;
        //public plc_log_msg(DateTime datetime, msg_type msg_type, int id, string msg)
        //{
        //    //_plc = plc;
        //    _msg_type = msg_type;
        //    _datetime = datetime;
        //    _id = id;
        //    _msg = msg;
        //}
        public plc_log_msg(string msg)
        {
            _msg = msg;
        }
        public plc_log_msg(string msg, List<aktuator> list_akt)
        {
            if (msg.Contains("{MSG_START}") && (msg.Contains("{MSG_END}")))
            {
                msg = msg.Substring(msg.IndexOf("{MSG_START}") + 11);
                msg = msg.Substring(0, msg.IndexOf("{MSG_END}"));

                string[] data = msg.Split('~');
                if (data.Length != 6)
                {
                    msg_crap = true;
                    _msg = "plc_log_msg crap [" + msg + "]";
                }
                else
                {
                    string[] timestamp = data[1].Replace(((char)32).ToString(), "").Split(':');
                    if (timestamp.Length != 6)
                        _msg = "[plc_log_msg timestamp != length 6] " + msg;
                    else
                    {
                        try
                        {
                            _datetime = new DateTime(Convert.ToInt32(timestamp[0]), Convert.ToInt32(timestamp[1]), Convert.ToInt32(timestamp[2]),
                                  Convert.ToInt32(timestamp[3]), Convert.ToInt32(timestamp[4]), Convert.ToInt32(timestamp[5]), 0);
                        }
                        catch (Exception) { _msg = "[plc_log_msg error convert timestamp] " + msg; }

                        try { _msg_type = (msg_type)Convert.ToInt32(data[2].Trim((char)32)); }
                        catch (Exception) { _msg = "[plc_log_msg error convert msg_type] " + msg; }
                        try { _id = Convert.ToInt32(data[3].Trim((char)32)); }
                        catch (Exception) { _msg = "[plc_log_msg error convert ID] " + msg; }

                        //aus aktuatorliste bezeichnung zu ID suchen
                        if (list_akt.Exists(x => x.Index == _id))
                            foreach (aktuator akt in list_akt)
                                if (akt.Index == _id)
                                    _id_text = akt.Name;

                        _msg = _msg + data[4];
                    }
                }
            }
            else
            {
                msg_crap = true;
                _msg = "plc_log_msg tags missing: [" + msg + "] " + Environment.NewLine;
            }
        }

        public string ToString(bool datetime, bool error, bool warning, bool info, bool undef)
        {
            if (msg_crap)
                return _msg;

            string s = String.Empty;

            if ((this._msg_type.Equals(msg_type.error) && error) || (this._msg_type.Equals(msg_type.warning) && warning) ||
                (this._msg_type.Equals(msg_type.info) && info) || (this._msg_type.Equals(msg_type.undef) && undef))
            {
                if (datetime)
                    s += "(" + _datetime.ToString() + ") ";
                //if (show_id)
                s += "'" + _id_text + "' ";
                s += _msg + Environment.NewLine;
            }
            return s;
        }

        public msg_type get_msg_type()
        {
            return _msg_type;
        }
    }
}
