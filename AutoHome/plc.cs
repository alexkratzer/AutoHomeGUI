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
        public string IPplc
        {
            get
            {
                if (_ip != null)
                    return _ip;
                else
                    return "no IP set jet";
            }
            set
            {
                System.Net.IPAddress valid_ip;
                if (System.Net.IPAddress.TryParse(value, out valid_ip))
                    _ip = valid_ip.ToString();
            }
        }

        private int _port;
        public string PortPlc
        {
            get
            {
                if (_ip != null)
                    return _port.ToString();
                else
                    return "no port set jet";
                
            }
            set
            {
                int valid_port;
                if (int.TryParse(value, out valid_port))
                    _port = valid_port;
            }
        }
        
        private string _PLC_Name = plc_default_name;
        public string NamePlc
        {
            get
            {
                return _PLC_Name;
            }
            set { _PLC_Name = value; }
        }

        public int new_message_count = 0;
        //private string plc_hash; //wird zum deserialisieren verwendet um objekte eindeutig zu identifizieren

        public List<aktuator> ListAktuator;

        #region tmp vars [NonSerialized]
        [NonSerialized]
        private cpsLIB.CpsNet cpsNet = null;
        [NonSerialized]
        private cpsLIB.Client client_udp = null;

        //wird als temporäre variable in FrmMain benötigt
        [NonSerialized]
        public List<Int16> ListSensorIDs;
        [NonSerialized]
        public DateTime clockPlc;
        [NonSerialized]
        public DateTime clockLocal;
        [NonSerialized]
        public TimeSpan clockPlcJitter;
        [NonSerialized]
        //public Frame DataMngType_GetPlcSensorValues;
        Dictionary<Int16, float> DicSensorVal;
        #endregion


        #region construktor / init / connect
        public plc(string ip, int port, string plc_name = "not named")
        {
            _ip = ip;
            _port = port;
            _PLC_Name = plc_name;
            client_udp = new Client(_ip, port.ToString());
            ListAktuator = new List<aktuator>();
        }
        
        public void connect(CpsNet _cpsNet)
        {
            cpsNet = _cpsNet;
            DicSensorVal = new Dictionary<short, float>();

            if (client_udp != null)
            {
                if (client_udp.RemoteIp != _ip)
                    client_udp.RemoteIp = _ip;
                if (client_udp.RemotePort != _port)
                    client_udp.RemotePort = _port;
            }
            else
                client_udp = cpsNet.newClient(_ip, _port.ToString());

            Frame f = new Frame(client_udp);
            f.SetHeaderFlag(FrameHeaderFlag.SYNC);
            send(f);
        }

        #endregion

        #region functions
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

        public void SetAktuatorData(Frame f) {
            foreach (aktuator a in ListAktuator) {
                if (f.isIOIndex(a.Index)) {
                    if (f.getPayload(1) == (int)DataIOType.GetState)
                        a.ValueFrame = f;
                    else if (f.getPayload(1) == (int)DataIOType.GetParam)
                        a.ConfigAktuatorValuesRunning = f.getPayload();
                    else
                        log.msg(this, "SetAktuatorData(), plc.cs: unknown DataIOType: [" + f.getPayload(2).ToString() + "]");
                }
            }
        }
        #endregion

        #region interprete data

        public void interpreteDataMng(Frame f)
        {
            if (f.getPayload(0) == (Int16)DataMngType.GetPlcTime)
            {
                clockPlc = new DateTime(f.getPayload(1), f.getPayload(2), f.getPayload(3), f.getPayload(4), f.getPayload(5), f.getPayload(6));
                clockLocal = DateTime.Now;
                clockPlcJitter = clockLocal - clockPlc;
                //if (DateTime.Now.Subtract(new TimeSpan(0, 0, var.MngData_AcceptedClockDelay)) > clockPlc)
                //    clockPlcJitter = DateTime.Now - clockPlc;
                //else if (DateTime.Now.Add(new TimeSpan(0, 0, var.MngData_AcceptedClockDelay)) < clockPlc)
                //    clockPlcJitter = clockPlc - DateTime.Now;
            }
            else if (f.getPayload(0) == (Int16)DataMngType.SetPlcTime)
            {
                Int16 retval = f.getPayload(1);
                if (retval > 0)
                    log.msg(this, "++ ERROR ++ interpreteDataMng() DataMngType.SetPlcTime -> see TIA Help [WR_SYS_T: Set time-of-day]: " + retval.ToString());
                //MessageBox.Show("retval: " + f.getPayload(1) + Environment.NewLine + " see TIA Help [WR_SYS_T: Set time-of-day]", "SetPlcTime: ERROR");
            }
            else if (f.getPayload(0) == (Int16)DataMngType.GetPlcSensorValues)
            {
                //TODO    : nicht aus Frame updaten sondern aus plc tmp daten; evtl update_SensorControl() über timer aufrufen und nicht via event
                //komplettes frame durchgehen und auspacken. für jeden sensorwert entsprechendes controll befüllen


                for (int i = 3; i < (f.getPaloadIntLengt()); i = i + 3)
                {
                    float SensorValue;
                    if (f.getPayload(i + 2) != 0)
                        SensorValue = (float)f.getPayload(i + 1) / (float)f.getPayload(i + 2);
                    else
                        SensorValue = f.getPayload(i + 1);

                    if (DicSensorVal.ContainsKey(f.getPayload(i)))
                        DicSensorVal[f.getPayload(i)] = SensorValue;
                    else
                        DicSensorVal.Add(f.getPayload(i), SensorValue);
                }

                //sensor value in entsprechenden aktuator ablegen
                foreach (aktuator a in ListAktuator) 
                    if (DicSensorVal.ContainsKey(a.Index))
                        a.SensorValue = DicSensorVal[a.Index];
                

            }

            //platform p_selected = (platform)comboBox_platform.SelectedItem;
            //if (p_selected != null)
            //    p_selected.update_SensorControl(f);

        }

        #endregion

        #region running startup config

        public string ShowRunningConfig()
        {
            string s= "ShowRunningConfig @" + _PLC_Name + Environment.NewLine;
            //string text = "";
            foreach (aktuator a in ListAktuator)
            {
                s += a.AktorType.ToString() + " / " + a.Name + " [" ;
                if (a.ConfigAktuatorValuesRunning != null)
                    foreach (Int16 i in a.ConfigAktuatorValuesRunning)
                        s += i.ToString() + ", ";
                else
                    s +="XX, ";
                s += "]" + Environment.NewLine;
            }
            //s += text + Environment.NewLine;
            return s;
        }
        /// <summary>
        /// send get request to all aktuators
        /// </summary>
        public void ReadRunningConfig() {
            foreach (aktuator a in ListAktuator) {
                Frame f = new Frame(getClient(), new Int16[] { a.Index, (int)DataIOType.GetParam });
                f.SetHeaderFlag(FrameHeaderFlag.PdataIO);
                send(f);
            } 
        }

        public void copyRunningToStartConfig() {
            foreach (aktuator a in ListAktuator)
                a.copyRunningToStartConfig();
        }
        #endregion
    }

}


