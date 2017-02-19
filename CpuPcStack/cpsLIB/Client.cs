using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Net.Sockets;

namespace cpsLIB
{
    [Serializable]
    public class Client
    {
        //public Int16 check_trys = 0;
        public string RemoteIp = "";
        public int RemotePort;
        public string RemotePortStr;
        
        public List<Frame> LFrame; //log all frames send over this udp connection
        public Int16 CountSendFrames = 0;
        //private object CallPlc;//plc 

        [NonSerialized]
        Thread _clientThread;

        [NonSerialized]
        public volatile udp_state state = udp_state.disconnected;

        [NonSerialized]
        public int RcvErrorCounter = 0;

        public Client(string ip, string port)
        {
            this.RemoteIp = ip;
            RemotePortStr = port;

            if (int.TryParse(port, out RemotePort))
                RemotePortStr = port;
            else
                RemotePortStr = "ERROR: " + port.ToString();

            state = udp_state.disconnected;
            LFrame = new List<Frame>();
        }

        public override string ToString()
        {
            return RemoteIp + ":" + RemotePortStr;
        }

        public string GetStatus()
        {
            return RemoteIp + ":" + RemotePortStr + " state:" + state.ToString() + " SendFrames: " + LFrame.Count.ToString() + "/" + 
                CountSendFrames.ToString() + " " ;
        }
        public string GetSendFrames()
        {
            string ans = String.Empty;
            foreach (Frame f in LFrame)
                ans += Environment.NewLine + f.ToString();
            return ans;
        }

        /// <summary>
        /// check if RemoteIP and RemotePort is equal
        /// ####################################################
        /// hint: port of send and received frame is NOT equal
        /// ####################################################
        /// </summary>
        /// <param name="cc"></param>
        /// <returns></returns>
        public bool IsEqual(Client cc)
        {
            if ((RemoteIp == cc.RemoteIp) && (RemotePort == cc.RemotePort))
                return true;
            else
                return false;
        }

        #region udp client
        /// <summary>
        /// IBS function -> used only in FrmCps
        /// </summary>
        /// <returns></returns>
        public bool sendSYNC()
        {
            RcvErrorCounter = 0;
            Frame f = new Frame(new Client(RemoteIp, RemotePortStr));
            f.SetHeaderFlag(FrameHeaderFlag.SYNC);
            return send(f);
        }
        
        public bool send(Frame f)
        {
            try
            {
                if ((state == udp_state.connected) || f.GetHeaderFlag(FrameHeaderFlag.SYNC))
                {
                    //der App wird mitgeteilt das dieses frame verschickt wurde
                    //if (SendFramesCallback)
                    //    _FrmMain.interprete_frame(f);

                    CountSendFrames++;
                    LFrame.Add(f);
                    //_clientThread = new Thread(new ThreadStart(send_fkt));
                    _clientThread = new Thread(() => send_fkt(f));
                    _clientThread.IsBackground = true;
                    _clientThread.Start();
                    return true;
                } else;
                     //"Remote udp_state NOT connected - NO Frame is send");
            }
            catch (Exception e)
            {
                state = udp_state.SendError;
            }
            return false;
        }
        

        private void send_fkt(Frame f)
        {
            UdpClient udpClient = new UdpClient();
            udpClient.Send(f.GetByteArray(), f.GetByteArray().Length, RemoteIp, RemotePort);
            udpClient.Close();
        }
        #endregion
    }
}
