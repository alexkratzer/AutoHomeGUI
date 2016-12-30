using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace AutoHome
{
    class log
    {
        public static void msg(Object o, String msg)
        {
            String log = DateTime.Now.ToString() + " [" + o.ToString() + "] " + msg + Environment.NewLine;
            File.AppendAllText(var.file_log, log);
        }
        public static void exception(Object o, String msg, Exception ex)
        {
            String log = DateTime.Now.ToString() + " +++ EXCEPTION +++ [" + o.ToString() + "] " + msg + " -> " + ex.ToString() + Environment.NewLine;
            File.AppendAllText(var.file_log, log);
        }
    }
}
