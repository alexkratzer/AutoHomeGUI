using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Drawing;
using cpsLIB; //frames

namespace AutoHome
{
    [Serializable]
    class platform
    {
        public string _platform_name;

        public floor_plan _floor_plan = null; //das hintergrundbild
        public List<platform_control> _list_platform_control;

        public platform(string name) {
            _platform_name = name;
            _list_platform_control = new List<platform_control>();
        }

        public override string ToString()
        {
            return _platform_name;
        }


        /// <summary>
        /// hole Hintergrundbild der Platform
        /// </summary>
        /// <returns></returns>
        public Image get_background_pic() {
            if (_floor_plan == null)
                return null;
            else
                return _floor_plan.get_image();
        }

        /// <summary>
        /// lade bild aus datei und speichere diese für weitere verwendung
        /// </summary>
        /// <param name="path_to_pic">pfad zur bild datei</param>
        /// <returns></returns>
        //public bool set_background_pic(string path_to_pic)
        //{
        //    if (File.Exists(path_to_pic))
        //    {
        //        try
        //        {
        //            Image tmp_img = Image.FromFile(path_to_pic);

        //            _picture_heigth = tmp_img.Height;
        //            _picture_width = tmp_img.Width;

        //            MemoryStream ms = new MemoryStream();
        //            tmp_img.Save(ms, System.Drawing.Imaging.ImageFormat.Png);                   
        //            _imageAsByteArray = ms.ToArray();
        //            return true;
        //        }
        //        catch (Exception e) {
        //            log.exception(this, "set_background_pic() [" + path_to_pic + "]" , e);
        //        }
        //    }
        //    else
        //        log.msg(this, "call set_background_pic with none existing path");
        //    return false;
        //}

        public void set_floor_plan(floor_plan fp){
            _floor_plan = fp;
        }

        public void update_control() {
            //if (f == null)
            //{
            //    log.msg("Frame == null @update_control(), platform.cs", "++++ error ++++");
            //    return;
            //}
            foreach (platform_control pc in _list_platform_control)
                if (pc._aktuator != null )
                    //if(pc._aktuator.RcvFrame.isIOIndex)
                    //f.isIOIndex(pc._aktuator.Index))
                    pc.update_control();
        }
        //public void update_SensorControl(Dictionary<short, float> dicSensorVal) {
        //    foreach (KeyValuePair<Int16, float> kvp in dicSensorVal) {
        //        foreach (platform_control pc in _list_platform_control)
        //            if (pc._aktuator != null && kvp.Key== pc._aktuator.Index)
        //                pc.update_SensorControl(kvp.Value);
        //    }
        //        //FrmLog.AddLog("SensorVal_dic: " + kvp.ToString());
        //}

        //public void update_SensorControl(Frame f)
        //{
        //    //TODO    : nicht aus Frame updaten sondern aus plc tmp daten; evtl update_SensorControl() über timer aufrufen und nicht via event
        //    //komplettes frame durchgehen und auspacken. für jeden sensorwert entsprechendes controll befüllen
        //    float SensorValue;
        //    for (int i = 3; i < (f.getPaloadIntLengt()); i = i + 3)
        //    {
        //        if (f.getPayload(i + 2) != 0)
        //            SensorValue = (float)f.getPayload(i + 1) / (float)f.getPayload(i + 2);
        //        else
        //            SensorValue = f.getPayload(i + 1);

        //        foreach (platform_control pc in _list_platform_control)
        //            if (pc._aktuator != null && pc._aktuator._plc.getClient().RemoteIp == f.client.RemoteIp )
        //                if (pc._aktuator.Index == f.getPayload(i))
        //                    if (pc._aktuator.AktorType == aktor_type.sensor)
        //                        {
        //                            pc.update_SensorControl(SensorValue);
        //                            break;
        //                        }
        //    }
        //}
    }


}
