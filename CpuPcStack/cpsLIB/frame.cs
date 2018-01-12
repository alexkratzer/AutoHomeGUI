using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;

/// <summary>
/// Telegram Structure:
/// 1 byte StructVersion; 1 byte ByteHeaderFlag; 2 byte reserviert; int16 FrameIndex; byte[x] payload
    
namespace cpsLIB
{
    public enum FrameSender { SEND, RCVE, unknown }
    //public enum FrameState { UNDEF, ERROR, IS_OK}
    //public enum FrameWorkingState { created, inWork, finish, error, warning, received, send}
    
        //public static Int16[] SET_STATE(int index, string position, string angle) { return new Int16[] { Convert.ToInt16(index), 2, Convert.ToInt16(position), Convert.ToInt16(angle), 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }; }
        //public static Int16[] SET_STATE(int index, bool state_switch) { return new Int16[] { Convert.ToInt16(index), 2, Convert.ToInt16(state_switch), 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }; }
    
    //order of the flags must match with the Remote FrameHeaderFlag 
    public enum FrameHeaderFlag { containering = 0, SYNC, LogMessage, ACKN, PdataIO, PdataParam, MngData }
    //public enum HeaderFlagManagementData { GetTime = 1, SetTime = 2,  }
    public enum DataIOType {ignore=0, GetState=1, SetState=2, GetParam=3, SetParam=4,
        SetParamJalousieEvent = 5, GetParamJalousieEvent = 6,
        GET_CPU_TIME =10,
        GET_WEATHER = 11,
        NET_SET_LIGHT_CMD = 12
    }
    public enum DataMngType { GetPlcTime=1, SetPlcTime=2, GetPlcSensorValues=10, EtaCmdStart=100, EtaCmdStop=101} //TODO: GetAllAktorIDs, GetAllSensorIDs usw

    [Serializable]
    public class FrameRawData
    {
        #region vars
        //FrameState frameState = FrameState.UNDEF;
        //constanten
        public const int FrameHeaderByteLength = 6; //Länge des Headers in Byte

        //frame content
        private FrameHeader header;
        private byte[] FramePayloadByte;

        // connection depending to frame
        public Client client;

        // frame meta data
        public DateTime TimeCreated; //Zeitstempel an dem das Frame erzeugt wurde

        public FrameSender frameSender = FrameSender.unknown;
        //private List<frameLog> ListFrameLog;
        //public FrameState frameState = FrameState.UNDEF;
        public int SendTrys; //Wird bei FrameType.SYNC Frames verwendet. Anzahl der wiederholungen bei keiner antwort
        public DateTime LastSendDateTime;
        public TimeSpan TimeRcvAnswer; //wird beim empfangen einer antwort gesetzt
        private Int16 Index_tmp;
        
        // static meta data
        public static bool _RemoteIsBigEndian = true; //PC = Little-Endian, CPU = Big-Endian

        //public static Int16 _allFrameCounterStatic = 0; //frame index -> at > ca 65000 restart @0
        //public static Int64 _allFrameCounterTotal = 0; //all frames in total since tool start
        #endregion

        #region construktor
        public FrameRawData(Client _client, byte[] data, FrameSender FS)
        {
            //TODO: catch ursache beheben(client == null)
            try
            {
                //_allFrameCounterStatic++;
                //_allFrameCounterTotal++;
                
                this.client = _client; //darüber kann ein Frame Objekt sich selbst versenden
                TimeCreated = DateTime.Now;
                LastSendDateTime = DateTime.Now;
                frameSender = FS;

                ///#### "make new frame to send it later on" ####
                if (frameSender.Equals(FrameSender.SEND))
                {
                    // ++ send Frame to Remote ++
                    //data is only payload, no FrameHeader
                    //Index_tmp = _allFrameCounterStatic;
                    Index_tmp = client.CountSendFrames;

                    //header = new FrameHeader(client.CountSendFrames); (***)
                    header = new FrameHeader(Index_tmp);
                    FramePayloadByte = data;

                    if (_RemoteIsBigEndian)
                        FramePayloadByte = changeEndian(FramePayloadByte);
                }

                ///#### "make new frame from rcv UDP Frame" ####
                else if (frameSender.Equals(FrameSender.RCVE))
                {
                    // ++ rcv Frame from Remote ++
                    //data includes FrameHeader
                    header = new FrameHeader(data, out FramePayloadByte);
                }
            }
            catch (Exception) {}
        }
        #endregion

        #region functions 
        public override string ToString()
        {
            //return "[" + frameSender.ToString() + " / " + client.RemoteIp + " / " + header.ToString() + "] ";
            return Index_tmp.ToString() + " " + frameSender.ToString() + " / " + header.ToString();
        }

        private byte[] changeEndian(byte[] data)
        {
            byte[] newData = new byte[data.Length];
            for (int i = 0; i < newData.Length / 2; i++)
            {
                newData[i * 2] = data[(i * 2) + 1];
                newData[(i * 2) + 1] = data[i * 2];
            }
            return newData;
        }

        public void SetHeaderFlag(FrameHeaderFlag fhf)
        {
            header.SetHeaderFlag(fhf);
        }

        /// <summary>
        /// frame ändert seinen status
        /// änderung wird protokolliert
        /// </summary>
        //public FrameRawData ChangeState(FrameWorkingState ws, string msg)
        //{
        //    //log.msg(this, GetDetailedString());
        //    //wenn error wird globaler ERROR für das Frame gesetzt
        //    //if (ws.Equals(FrameWorkingState.error))
        //    //    frameState = FrameState.ERROR;

        //    ListFrameLog.Add(new frameLog(ws, msg));
        //    return this;
        //}
        #endregion

        #region getter IO Data
        public bool isJob(DataIOType jobType)
        {
            if (getPayload(1) == (Int16)jobType)
                return true;
            else
                return false;
        }
        public bool isIOIndex(int index)
        {
            if (getPayload(0) == index)
                return true;
            else
                return false;
        }

        #endregion

        #region getter
        private byte[] getPayloadByte()
        {
            return FramePayloadByte;
        }
        public Int16[] getPayload()
        {
            List<Int16> listPayload = new List<short>(FramePayloadByte.Length / 2);
            for (int i = 0; i < FramePayloadByte.Length / 2; i++)
                listPayload.Add(getPayload(i));

            return listPayload.ToArray();
        }
        public Int16 getPayload(int i)
        {
            int index = i * 2;
            if (index >= FramePayloadByte.Length)
                return -1; //TODO globales fehlerhandling //TODO sporadisch exception -> bei kurzem 3int Payload aufgetreten
            //byte 0 LB
            //byte 1 HB
            //return (Int16)(256 * FramePayloadByte[index+1] + FramePayloadByte[index]);
            Int16 tmp = (Int16)(256 * FramePayloadByte[index] + FramePayloadByte[index+1]);
            return tmp;
        }
        public int getPaloadIntLengt() {
            return FramePayloadByte.Length / 2;
        }
        public bool IsEqual(Frame f)
        {
            if ((this.FramePayloadByte == f.FramePayloadByte) && (this.header == f.header))
                return true;
            else
                return false;
        }
        public bool IsEqualPayload(Frame f) {
            if (f.getPayloadByte() == getPayloadByte())
                return true;
            else
                return false;    
        }

        private Int16[] GetIntArr(byte[] data)
        {
            Int16[] intData = new Int16[data.Length / 2];
            for (int i = 0; i < data.Length / 2; i++)
                intData[i] = BitConverter.ToInt16(data, i * 2);
            return intData;
        }

        //TODO: für IBS um an der GUI darzustellen. später evtl rausnehmen
        public string getPayloadByteAsString() {
            string s = string.Empty;

            for (int i = 0; i < FramePayloadByte.Length; i++)
                s += FramePayloadByte[i].ToString() + ", ";
            return s;
        }

        public string getPayloadHex()
        {
            return BitConverter.ToString(FramePayloadByte);
        }

        //TODO: für IBS um an der GUI darzustellen. später evtl rausnehmen
        public string getPayloadASCII()
        {
            return new string(Encoding.ASCII.GetString(FramePayloadByte).ToCharArray());
        }

        /// <summary>
        /// shows frame content as Byte Array
        /// is used @FrmStatusLog 
        /// </summary>
        /// <returns>string representant</returns>
        public string ShowFrameAsByteArry() {
            //byte[] ba = GetByteArray();
            return BitConverter.ToString(FramePayloadByte);
        }
        /// <summary>
        /// shows frame header content as Byte Array
        /// is used @FrmStatusLog 
        /// </summary>
        /// <returns>string representant</returns>
        public string ShowHeaderAsByteArry()
        {
            return BitConverter.ToString(header.GetSendBytes());
        }
        /// <summary>
        /// shows frame payload interpretet as Int Array
        /// is used @FrmStatusLog 
        /// </summary>
        /// <returns>string representant</returns>
        public string ShowPayloadInt()
        {
            string s = string.Empty;

            for (int i = 0; i < FramePayloadByte.Length / 2; i++)
                s += getPayload(i) + "-";
            s = s.TrimEnd('-', ' ');
            return s;
        }


        /// <summary>
        /// cat of remote IP adress and frame index number
        /// used to find frames in fstack (dictionary)
        /// </summary>
        /// <returns></returns>
        public string GetKey() {
            if (header.FrameIndex >= 0) //TO: Abfrage evtl nicht mehr notwendig
                return client.RemoteIp + ":" + header.FrameIndex.ToString();
            else
                
                return "Index 0";
        }

        /// <summary>
        /// Returns Frame Header + Frame Content to send it over stream
        /// </summary>
        /// <returns>Total Frame as Byte Array</returns>
        public byte[] GetByteArray()
        {
            byte[] RetVal = new byte[header.GetSendBytes().Length + FramePayloadByte.Length];
            System.Buffer.BlockCopy(header.GetSendBytes(), 0, RetVal, 0, header.GetSendBytes().Length);
            System.Buffer.BlockCopy(FramePayloadByte, 0, RetVal, header.GetSendBytes().Length, FramePayloadByte.Length);
            return RetVal;
        }
        
        public Int16 GetIndex() {
            return header.FrameIndex;
        }

        public bool GetHeaderFlag(FrameHeaderFlag fhf) {
            return header.GetHeaderFlag(fhf);
        }

        #endregion

        [Serializable]
        class FrameHeader
        {
            /// Telegram Structure:
            /// 1 byte StructVersion; 1 byte ByteHeaderFlag; 2 byte reserviert; int16 FrameIndex; byte[x] payload
            //public static Int16 SendFramesCount = 0;
            //public static Int16 RcvFramesCount = 0;
            byte StructVersion = 1; //Versionskennung dieser Frame Struktur. Damit wäre es später möglich die Struktur zu verändern      
            byte ByteHeaderFlag = 0x00; //Sammelbyte das den Zustand der folgenden flags entspricht
            /*
            bool containering = false; //Erweiterung für später -> udp frame besteht nicht aus einer sondern x nachrichten. 
            //diese müssen auf der client seite eingepackt und auf der server seite ausgepackt werden

            bool _SYNC = false; //Frame zum Verbindungsaufbau bzw zum Verbindungs Status ermitteln
            public bool SYNC
            {
                set {
                _SYNC = value;
                ByteHeaderFlag = SetBit(ByteHeaderFlag, 2);
            } }

            //LOG Message -> interpretiert payload als ascii
            bool LogMessage = false;

            //Aufforderung an den server ein Empfangsbestätigung des frames zu senden
            bool acknowledge = false;

            //austausch von prozessdaten
            bool ProcessData = false;

            //management frame für cpu
            bool ManagementData = false;
             */

            //reserviert für Erweiterungen
            byte resByteI = 0xff;
            byte resByteII = 0xff;

            //16Bit FrameIndex -> wird vom client für jedes neue frame inkrementiert. server sendet als antwort frame mit dem gleichen index
            private Int16 _FrameIndex;
            /// <summary>
            /// return in changed Endian format
            /// </summary>
            public Int16 FrameIndex
            {
                set
                {
                    byte[] b = BitConverter.GetBytes(value);
                    _FrameIndex = (Int16)(b[0] * 256 + b[1]);
                    _FrameIndex = (Int16)(b[1] + b[0]);
                    //_FrameIndex = value;
                }
                get { return _FrameIndex; }
            }

            #region construktor
            //received Frame from remote
            //the payload from the frame is extractet
            public FrameHeader(byte[] ByteArray, out byte[] extractet_payload)
            {
                //RcvFramesCount++;
                if (ByteArray.Length >= FrameHeaderByteLength)
                {
                    StructVersion = ByteArray[0];
                    ByteHeaderFlag = ByteArray[1];
                    resByteI = ByteArray[2];
                    resByteII = ByteArray[3];
                    FrameIndex = BitConverter.ToInt16(ByteArray, 4);

                    extractet_payload = new byte[ByteArray.Length - FrameHeaderByteLength];
                    System.Buffer.BlockCopy(ByteArray, FrameHeaderByteLength, extractet_payload, 0, extractet_payload.Length);
                }
                else
                    throw new Exception("Exception making FrameHeader: ByteArray.Length < " + FrameHeaderByteLength.ToString());
            }
            //Frame to send at remote
            public FrameHeader(Int16 index)
            {
                FrameIndex = index;
            }
            #endregion

            #region functions


            public void SetHeaderFlag(FrameHeaderFlag fhf)
            {
                ByteHeaderFlag = SetBit(ByteHeaderFlag, (int)fhf);
            }

            private FrameHeaderFlag GetHeaderFlag(){

                int count = ByteHeaderFlag;
                int map = -0;
                switch (count) {
                    case 1: map = 0; break;
                    case 2: map = 1; break;
                    case 4: map = 2; break;
                    case 8: map = 3; break;
                    case 16: map = 4; break;
                    case 32: map = 5; break;
                    case 64: map = 6; break;
                    case 128: map = 7; break;

                    default: map = count; break;
                }

                return (FrameHeaderFlag)map;
            }

            public bool GetHeaderFlag(FrameHeaderFlag fhf)
            {
                return (ByteHeaderFlag & (1 << (int)fhf)) != 0;
            }
            public byte[] GetSendBytes()
            {
                byte[] bytearr = new byte[FrameHeaderByteLength];
                bytearr[0] = StructVersion;
                bytearr[1] = ByteHeaderFlag;
                bytearr[2] = resByteI;
                bytearr[3] = resByteII;                 //TODO LittleBigEndian beachten //Bytes noch drehen -> wird bei set gemacht
                System.Buffer.BlockCopy(BitConverter.GetBytes(_FrameIndex), 0, bytearr, 4, 2); 
                return bytearr;
            }
            
            /// <summary>
            /// Setzt ein bestimmtes Bit in einem Byte.
            /// </summary>
            /// <param name="b">Byte, welches bearbeitet werden soll.</param>
            /// <param name="BitNumber">Das zu setzende Bit (0 bis 7).</param>
            /// <returns>Ergebnis - Byte</returns>
            private static byte SetBit(byte b, int BitNumber)
            {
                if (BitNumber < 8 && BitNumber > -1)
                    return (byte)(b | (byte)(0x01 << BitNumber));
                return 0;
            }

            public override string ToString()
            {/*
            return "{Struct: " + StructVersion.ToString() + " Type: " + Convert.ToString(ByteHeaderFlag, 2) + 
                " res: " + resByteI.ToString() + "," + resByteII.ToString() + " Index: " + _FrameIndex.ToString() + "} ";
          * */
                //return "{flag: " + Convert.ToString(ByteHeaderFlag, 2) + " Idx: " + _FrameIndex.ToString() + "} ";
                return GetHeaderFlag() + " / " + _FrameIndex.ToString();
            }
            #endregion
        }

    }

    [Serializable]
    public class  Frame : FrameRawData{
        //public FrameRawData AnswerFrame = null;

        #region construktor
        /// <summary>
        /// sync frame ohne content das versendet wird
        /// </summary>
        //public Frame(string ip, string port) :
        //    base(ip, port, new byte[] { }, FrameSender.SEND) { }
        public Frame(Client cc) :
            base(cc, new byte[] { }, FrameSender.SEND) { }

        /// <summary>
        /// normale frames die versendet werden
        /// </summary>
        //public Frame(string ip, string port, Int16[] data) :
        //    base(ip, port, getByteArray(data), FrameSender.SEND) { }
        public Frame(Client cc, Int16[] data) :
            base(cc, getByteArray(data), FrameSender.SEND) { }

        //public Frame(string ip, string port, char[] data) :
        //    base(ip, port, getByteArray(data), FrameSender.SEND) { }
        public Frame(Client cc, char[] data) :
            base(cc, getByteArray(data), FrameSender.SEND) { }

        //Frame das Empfangen wurde
        public Frame(Client cc, byte[] data) :
            base(cc, data, FrameSender.RCVE) { }
        #endregion
      
        #region frames_payload (to make frames)
        public static Int16[] payload_0(Int16 value) { return new Int16[] { value }; }
        /*public static Int16[] GET_STATE(Int16 index) { return new Int16[] { index, 1 }; }
        public static Int16[] GET_PARAM(int index) { return new Int16[] { Convert.ToInt16(index), 3 }; }
        public static Int16[] SET_STATE(int index, string position, string angle) { return new Int16[] { Convert.ToInt16(index), 2, Convert.ToInt16(position), Convert.ToInt16(angle), 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }; }
        public static Int16[] SET_STATE(int index, bool state_switch) { return new Int16[] { Convert.ToInt16(index), 2, Convert.ToInt16(state_switch), 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }; }
        
         */


        public static Frame MngData(Client c, DataMngType DMT)
        {
            Frame f = new Frame(c, new Int16[] { (Int16)DMT });
            f.SetHeaderFlag(FrameHeaderFlag.MngData);
            return f;
        }
        #endregion

        #region  funktionen
        private static byte[] getByteArray(char[] data)
        {
            byte[] bdata = new byte[data.Length];
            for (int i = 0; i < data.Length; i++)
                bdata[i] = Convert.ToByte(data[i]);

            return bdata;
        }

        private static byte[] getByteArray(Int16[] data)
        {
            byte[] byte_array = new byte[data.Length * 2];

            for (int i = 0; i < data.Length; i++)
            {
                byte[] tmp_bytes = BitConverter.GetBytes(data[i]);
                byte_array[i * 2] = tmp_bytes[0];
                byte_array[(i * 2) + 1] = tmp_bytes[1];
            }
            return byte_array;
        }

        #endregion
    }
}

#region unused
//public Int16 ChangeEndian(Int16 i)
//{
//    byte[] b = BitConverter.GetBytes(i);
//    //return (Int16)(b[0] * 256 + b[1]);
//    return (Int16)(b[1] + b[0]);
//}

//private Int16[] changeEndian(Int16[] data)
//{
//    Int16[] tmp_data = new Int16[data.Length];
//    for (int i = 0; i < data.Length; i++)
//        tmp_data[i] = IPAddress.NetworkToHostOrder(data[i]);
//    return tmp_data;
//}

/// <summary>
/// returns Frame als ByteArray in BigEndian (PLC Order)
/// </summary>
/// <returns></returns>
/*
public byte[] getNetworkOrderFrame()
{
    try
    {
        byte[] network_byte_array = new byte[_data_HostOrder.Length * 2];

        for (int i = 0; i < _data_HostOrder.Length; i++)
        {
            byte[] tmp_bytes = BitConverter.GetBytes(_data_HostOrder[i]);
            network_byte_array[i * 2] = tmp_bytes[1];
            network_byte_array[(i * 2) + 1] = tmp_bytes[0];
        }

        return network_byte_array;
    }
    catch (Exception e)
    {
        throw new Exception("Exception getNetworkOrderFrame: " + e.Message);
    }


public bool isEmptyString()
{
    foreach (Int16 i in _data_HostOrder)
        if (i != 0x2020)
            return false;
    return true;
}
 * */
#endregion