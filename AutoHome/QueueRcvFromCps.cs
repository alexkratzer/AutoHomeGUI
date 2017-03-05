using cpsLIB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AutoHome
{
    class QueueRcvFromCps : IcpsLIB
    {
        List<plc> ListPlc;
        //CpsNet cpsNet;
        FrmMain FrmMain;
        public QueueRcvFromCps(FrmMain _FrmMain, List<plc> _listPlc) {
            ListPlc = _listPlc;
            //cpsNet = _cpsnet;
            FrmMain = _FrmMain;
        }

        int dbgcount = 0;
        public void interprete_frame(object o)
        {
            if (dbgcount > 10)
                return ;
            foreach (plc p in ListPlc)

                if (p.interpreteFrame((Frame)o))
                    return ;
                dbgcount++;
                //TODO: keine plc hat frame verarbeitet
                logMsg("QueueRcvFromCps: keine plc hat frame verarbeitet");
        }

        public void logMsg(string msg)
        {
            FrmMain.ListLogMsg.Add(msg);
            //throw new NotImplementedException();
        }




    }
}
