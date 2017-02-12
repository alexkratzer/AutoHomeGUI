using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Collections;
using cpsLIB; //frames

namespace AutoHome
{

    [Serializable]
    class aktuator
    {
        public aktuator(Int16 index, string name, plc plc, aktor_type type)
        {
            _index = index;
            _name = name;
            _plc = plc;
            _type = type;
        }

        #region vars

        private Int16 _index;
        public Int16 Index
        {
            get { return _index; }
            set
            {
                _index = value;
                set_aktor_hash();
            }
        }

        private aktor_type _type;
        public aktor_type AktorType
        {
            get { return _type; }
            set
            { _type = value; }
        }

        private string _name;
        public string Name
        {
            get { return _name; }
            set { _name = value;
                set_aktor_hash();
            }
        }
        //private string mapped_plc_hash = "";
        private string aktuator_hash = "";

        private Int16[] _ConfigAktuatorValuesStartup; //startup config of aktuator
        public Int16[] ConfigAktuatorValuesStartup
        {
            get
            {
                if (_ConfigAktuatorValuesStartup == null)
                    return new Int16[] { 0 };
                else
                    return _ConfigAktuatorValuesStartup;
            }
            set { _ConfigAktuatorValuesStartup = value; }
        }
        public string AktuatorStartupConfig
        {
            get
            {
                string s = "";
                foreach (int i in ConfigAktuatorValuesStartup)
                    s += i.ToString() + ", ";
                return s;
            }
        }

        [NonSerialized]//aktuelle config in cpu muss immer neu ausgelesen werden
        private Int16[] _ConfigAktuatorValuesRunning; //running config of aktuator
        public Int16[] ConfigAktuatorValuesRunning
        {
            get
            {
                if (_ConfigAktuatorValuesRunning == null)
                    return new Int16[] { 0 };
                else
                    return _ConfigAktuatorValuesRunning;
            }
            set { _ConfigAktuatorValuesRunning = value; }
        }
        public string AktuatorRunningConfig
        {
            get
            {
                string s = "";
                foreach (int i in ConfigAktuatorValuesRunning)
                    s += i.ToString() + ", ";
                return s;
            }
        }

        [NonSerialized]//nicht serialisieren da sonst keine referenz auf das aktuelle objekt vorhanden ist sondern mit alten kopien gearbeitet wird
        public plc _plc;
        [NonSerialized]
        public Frame ValueFrame; //nur tämporere werte
        #endregion

        #region functions
        public void copyRunningToStartConfig() {
            ConfigAktuatorValuesStartup = ConfigAktuatorValuesRunning;
        }
        #region serialize
        public void set_aktor_hash()
        {
            aktuator_hash = _index.ToString() + ":" + _name;
        }
        public string get_aktor_hash()
        {
            return aktuator_hash;
        }
        #endregion
        
        public void plc_send(Frame f) {
            _plc.send(f);
        }
        public void plc_send_IO(DataIOType diot)
        {
            if (_plc != null)
            {
                Frame f = new Frame(_plc.getClient(), new Int16[] { Index, (Int16)diot });
                f.SetHeaderFlag(FrameHeaderFlag.PdataIO);
                _plc.send(f);
            }
        }

        /// <summary>
        /// make and send IO Frame to PLC
        /// </summary>
        /// <param name="diot"></param>
        /// <param name="data"></param>
        public void plc_send_IO(DataIOType diot, Int16[] data)
        {
            if (_plc != null)
            {
                Int16[] start = new Int16[] { Index, (Int16)diot };
                Int16[] complete = new Int16[start.Length + data.Length];
                start.CopyTo(complete, 0);
                data.CopyTo(complete, start.Length);

                Frame f = new Frame(_plc.getClient(), complete);
                f.SetHeaderFlag(FrameHeaderFlag.PdataIO);
                _plc.send(f);
            }
        }
        
        public override string ToString()
        { 
            string s = _index + " : ";
            if (_plc != null)
                s += _plc.ToString() + " : ";
            else
                s += "[NO PLC SELECTED] : ";
            s += _type.ToString() + " : " + _name;
            return s;
        }
        #endregion
    }

    //class light : aktuator {
    //    enum light_status {undef, on, off}
    //    light_status status;
    //    bool enable_lux;
    //    int lux_off_at;
    //    bool enable_off_timer;
    //    //off timer timespan

    //}
}
