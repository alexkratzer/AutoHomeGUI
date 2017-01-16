using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Sockets;
using System.Threading;
using cpsLIB; //frames

namespace AutoHome
{
    //enum plc_state { undefined, initialising, connected, disconnected}
    [Serializable]
    class plc
    {
        private const string plc_default_name = "PLC not named";
        private string _ip;
        private int _port;
        private string _PLC_Name = plc_default_name;
        public List<plc_log_msg> list_log = new List<plc_log_msg>();
        public int new_message_count = 0;
        private string plc_hash; //wird zum deserialisieren verwendet um objekte eindeutig zu identifizieren

        [NonSerialized]
        private cpsLIB.CpsNet cpsNet = null;
        [NonSerialized]
        private cpsLIB.Client client_udp = null;

        [NonSerialized]
        System.Windows.Forms.ToolStripDropDownButton _TSSDDB_Status = null;

        //wird als temporäre variable in FrmMain benötigt
        public List<Int16> ListSensorIDs;
        

        #region construktor / init
        public plc(string ip, int port, string plc_name = "not named")
        {
            _ip = ip;
            _port = port;
            _PLC_Name = plc_name;
            client_udp = new Client(_ip, port.ToString());
        }

        public void init_TSDDB(System.Windows.Forms.ToolStripDropDownButton TSSDDB_Status)
        {
            _TSSDDB_Status = TSSDDB_Status;
        }
        #endregion

        #region vars
        public void set_plc_hash()
        {
            plc_hash = _PLC_Name + ":" + _ip + ":" + _port.ToString();
        }
        public string get_plc_hash()
        {
            return plc_hash;
        }
        public void set_plc_name(string name) {
            _PLC_Name = name;
            set_plc_hash();
        }
        public string get_plc_name()
        {
            return _PLC_Name;
        }
        public void set_plc_ip(string ip) {
            System.Net.IPAddress valid_ip;
            if (System.Net.IPAddress.TryParse(ip, out valid_ip))
            {
                _ip = valid_ip.ToString();
                set_plc_hash();
            }
        }
        public string get_plc_ip() {
            return _ip;
        }
        public void set_plc_port(string port)
        {
            int valid_port;
            if (int.TryParse(port, out valid_port))
            {
                _port = valid_port;
                set_plc_hash();
            }
        }
        public string get_plc_port()
        {
            return _port.ToString();
        }
        #endregion
  
        public void connect(CpsNet _cpsNet, FrmLogPCS frm)
        {
            cpsNet = _cpsNet;
            if (client_udp != null) {
                if (client_udp.RemoteIp != _ip)
                    client_udp.RemoteIp = _ip;
                if (client_udp.RemotePort != _port)
                    client_udp.RemotePort = _port;
            }else
                client_udp = cpsNet.newClient(_ip, _port.ToString());
            
            Frame f = new Frame(client_udp);
            f.SetHeaderFlag(FrameHeaderFlag.SYNC);
            send(f, frm);
        }

        public bool send(Frame f, FrmLogPCS frm) 
        {
            if (client_udp == null){    
                frm.AddLog("send frame with no client! " + f.ToString());
                return false;
            }
            frm.AddLog("send: " + f.ToString());
            return cpsNet.send(f);
        }
        public bool send(Frame f)
        {
            if (client_udp == null)
                return false;
            return cpsNet.send(f);
        }
        public void send(FrameHeaderFlag hf, Int16[] data )
        {
            if (client_udp != null)
            {
                Frame f = new Frame(client_udp, data);
                f.SetHeaderFlag(hf);
                cpsNet.send(f);
            }
        }

        /*
        public void newlog(string msg)
        {
            plc_log_msg m = new plc_log_msg(msg);
            list_log.Add(m);
        }
        public void newlog(string msg, List<aktuator> la)
        {
            plc_log_msg m = new plc_log_msg(msg, la);
            list_log.Add(m);
        }
         * */

        public override string ToString()
        { 
            if ((_PLC_Name == String.Empty) || (_PLC_Name == plc_default_name))
                return "[" + _ip + ":" + _port.ToString() + "]";
            else
                return "[" + _PLC_Name + "]";
        }

        public Client getClient() {
            return client_udp;
        }
    }

    //public class msg_log
    //{
    //    string _plc_name;
    //    string _f;
    //    msg_log_type _type;

    //    public msg_log(string plc_name, string f, msg_log_type type)
    //    {
    //        _plc_name = plc_name;
    //        _f = f;
    //        _type = type;
    //    }

    //    public string msg()
    //    {
    //        return _f;
    //    }
    //    public string plc_name()
    //    {
    //        return _plc_name;
    //    }
    //    public msg_log_type type()
    //    {
    //        return _type;
    //    }
    //}

    
}


