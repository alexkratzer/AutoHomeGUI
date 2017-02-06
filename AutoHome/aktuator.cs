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

        public aktor_type _type;

        private string _name;
        public string Name
        {
            get { return _name; }
            set { _name = value;
                set_aktor_hash();
            }
        }

        private string mapped_plc_hash = "";
        private string aktuator_hash = "";

        public Int16[] ConfigAktuatorValuesRunning; //running config of aktuator
        //public Int16[] ConfigAktuatorValuesRunning
        //{
        //    get { return _ConfigAktuatorValuesRunning; }
        //    set { _ConfigAktuatorValuesRunning = value; }
        //}
        public string ShowConfigAktuatorValuesRunning() {
            string s = "";
            foreach (int i in ConfigAktuatorValuesRunning)
                s += i.ToString() + ", ";
            return s;
        }



        public Int16[] ConfigAktuatorValuesStartup; //startup config of aktuator

        [NonSerialized]//nicht serialisieren da sonst keine referenz auf das aktuelle objekt vorhanden ist sondern mit alten kopien gearbeitet wird
        public plc _plc;
        [NonSerialized]
        public Frame ValueFrame; //nur tämporere werte

        public void copyRunningToStartConfig() {
            ConfigAktuatorValuesStartup = ConfigAktuatorValuesRunning;
        }
        #region serialize
        //notwendig um nach deserialisieren eine referenz auf aktuelle plc zu erzeugen
        //public void serialize_init() {
        //    if(_plc != null)
        //        mapped_plc_hash = _plc.get_plc_hash();
        //}

        //public void deserialize_init(List<plc> list_plc) {
        //    foreach (plc _plc_in_list in list_plc)
        //        if (mapped_plc_hash == _plc_in_list.get_plc_hash())
        //        {
        //            _plc = _plc_in_list;
        //            break;
        //        }
        //}

        public void set_aktor_hash()
        {
            aktuator_hash = _index.ToString() + ":" + _name ;
        }
        public string get_aktor_hash()
        {
            return aktuator_hash;
        }
        #endregion

        //temporäre type spezifische daten -> TODO: in abgeleiteten klassen verwalten
        //private bool light_switch_state; 
        //public bool Light_switch_state
        //{
        //  get { return light_switch_state; }
        //  set { light_switch_state = value; }
        //}
        public aktuator(Int16 index, string name, plc plc, aktor_type type)
        {
            _index = index;
            _name = name;
            _plc = plc;
            _type = type;
        }


        //wurde beim löschen aufgerufen -> jetzt gibt es für jede plc einie eigene aktuator liste -> wird nicht mehr 
        public void change_plc(plc plc_new)
        {
            _plc = plc_new;
        }
        

        public string name()
        {
            return _name;
        }
        public aktor_type GetAktType()
        {
            return _type;
        }
        public bool isType(aktor_type t)
        {
            if (_type == t)
                return true;
            else
                return false;
        }

        public bool isPlc(plc name) {
            if (name == _plc)
                return true;
            else
                return false;
        }
        public void plc_send(Frame f) {
            if (_plc != null) //abfrage später nicht mehr notwendig da jeder aktor eine plc haben sollte
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
            if(var.expert_display_hash)
                if (mapped_plc_hash != null)
                    s += "[" + mapped_plc_hash.ToString() + "]";
                else s += "[ NO PLC ]";

            return s;
        }
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
