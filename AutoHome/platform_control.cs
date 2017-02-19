using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AutoHome
{
    [Serializable]
    class platform_control
    {
        public int _pos_x;
        public int _pos_y;
        public aktor_type _type; //zwischenspeichern damit in FrmConfigPlatform_EditControlDialog

        [NonSerialized]//nicht serialisieren da sonst keine referenz auf das aktuelle objekt vorhanden ist sondern mit alten kopien gearbeitet wird
        public aktuator _aktuator;
        private string mapped_aktuator_hash;

        [NonSerialized]//picture box ist nicht serialisierbar
        public PBplatformControl _PictureBox;

        [NonSerialized]//picture box ist nicht serialisierbar
        public UC_SensorValue _UCsensorValue;

        //notwendig um nach deserialisieren eine referenz auf aktuellen aktor zu erzeugen
        public void serialize_init()
        {
            if (_aktuator != null)
                mapped_aktuator_hash = _aktuator.get_aktor_hash();
        }

        public void deserialize_init(List<plc> list_plc)
        {
            foreach (plc p in list_plc)
            {
                foreach (aktuator _akt_in_list in p.ListAktuator)
                {
                    if (mapped_aktuator_hash == _akt_in_list.get_aktor_hash())
                    {
                        _aktuator = _akt_in_list;
                        break;
                    }
                }
            }

            //wird beim deserialisieren aufgerufen da PictureBox nicht serialisierbar ist
            //sollte erst passieren nachdem der aktuator zugewiesen ist da sonst die label info nicht vorhanden ist
            if (_aktuator != null)
            {
                if (_aktuator.AktorType == aktor_type.sensor)
                    _UCsensorValue = new UC_SensorValue(this, _pos_x, _pos_y);
                else
                    _PictureBox = new PBplatformControl(this, _pos_x, _pos_y);
            }
        }

        //anlegen eines neuen controls ohne ausgewähltem aktuator
        public platform_control(aktor_type t)
        {
            _type = t; 
            if (t == aktor_type.sensor)
                _UCsensorValue = new UC_SensorValue(this);
            else
                _PictureBox = new PBplatformControl(t, this);
        }

        /// <summary>
        /// call from FrmPlatformConfig if aktuator of control is changed or set
        /// </summary>
        /// <param name="a"></param>
        public void change_aktuator(aktuator a)
        {
            _aktuator = a;
            if (_aktuator.AktorType == aktor_type.sensor)
                _UCsensorValue.update_label_text();
            else
                _PictureBox.update_label_text();
        }

        public void update_control()
        {
            if (_PictureBox != null && _aktuator.ConfigAktuatorValuesRunning.Length != 0)
                    _PictureBox.pic_update(_aktuator.ConfigAktuatorValuesRunning);
            else if (_type == aktor_type.sensor && _UCsensorValue != null)
                _UCsensorValue.updateValue(_aktuator.SensorValue);
            //else
            //    log.msg(this, "update_control() @invalid state [aktor_type " + ((int)_type).ToString() + "]");

            /*
            if (_type != aktor_type.sensor && _PictureBox != null )
                if( _aktuator.ValueFrame == null)
                    log.msg(this, "update_control() @invalid state [_aktuator.ValueFrame==null]");
                else
                    _PictureBox.pic_update(_aktuator.ValueFrame);
            else if (_type == aktor_type.sensor && _UCsensorValue != null)
                _UCsensorValue.updateValue(_aktuator.SensorValue);
            else
                log.msg(this, "update_control() @invalid state [aktor_type " + ((int)_type).ToString() + "]");
                */
        }

    }
}
