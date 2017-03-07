using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using cpsLIB; //frames

namespace AutoHome
{
    /// <summary>
    /// user control to show aktuators in list
    /// </summary>
    /// 
    class aktuator_control
    {
        public aktuator aktuator;
        public Int16 aktuatorIndex;
        public object user_control;
        public aktor_type _aktor_type;
        
        public aktuator_control(aktuator a) {
            aktuator = a;
            aktuatorIndex = a.Index;
            _aktor_type = a.AktorType;
            set_uc(aktuator);
        }

        public void set_uc(aktuator _aktuator)
        {
            if (_aktuator.AktorType == aktor_type.light)
                user_control = new UC_light(aktuator);
            else if (_aktuator.AktorType == aktor_type.jalousie)
                user_control = new UC_jalousie(aktuator);
            else if (_aktuator.AktorType == aktor_type.heater)
                user_control = new UC_heater(aktuator);
            else
                user_control = null;
        }

        public void interprete(Frame f)
        {
            dynamic d = user_control;
            d.interprete(f);
        }
        
    }
}
