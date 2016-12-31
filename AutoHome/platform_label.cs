using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AutoHome
{
    [Serializable]
    class platform_label
    {
        //public int _pos_x;
        //public int _pos_y;
        public aktor_type _type;
        
        //private string aktuator_name = null;

        [NonSerialized]//nicht serialisieren da sonst keine referenz auf das aktuelle objekt vorhanden ist sondern mit alten kopien gearbeitet wird
        public aktuator _aktuator;
        private string mapped_aktuator_hash;

        //notwendig um nach deserialisieren eine referenz auf aktuellen aktor zu erzeugen
        public void serialize_init()
        {
            if (_aktuator != null)
                mapped_aktuator_hash = _aktuator.get_aktor_hash();
        }
        public void deserialize_init(List<aktuator> list_aktor)
        {
            foreach (aktuator _akt_in_list in list_aktor)
            {
                if (mapped_aktuator_hash == _akt_in_list.get_aktor_hash())
                {
                    _aktuator = _akt_in_list;
                    break;
                }
            }

            //wird beim deserialisieren aufgerufen da PictureBox nicht serialisierbar ist
            //sollte erst passieren nachdem der aktuator zugewiesen ist da sonst die label info nicht vorhanden ist
            //_PictureBox = new PBplatformControl(this, _pos_x, _pos_y);
        }

        [NonSerialized]//picture box ist nicht serialisierbar
        public PBplatformControl _PictureBox;

        //anlegen eines neuen controls ohne ausgewähltem aktuator
        public platform_label(aktor_type t)
        {
            _type = t;
            //_PictureBox = new PBplatformControl(t, this);
        }

        public void change_aktuator(aktuator a)
        {
            _aktuator = a;
            _PictureBox.update_label_text();
            //if (a != null)
            //    aktuator_name = _aktuator.ToString();
            //else
            //    aktuator_name = "SELECT AKTUATOR";
        }

        public void update_control(cpsLIB.Frame f)
        {
            if (_PictureBox != null)
                _PictureBox.pic_update(f);
        }




    }
}
