using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.IO;

namespace AutoHome
{
    [Serializable]
    class floor_plan {
        public int _picture_width;
        public int _picture_heigth;

        private byte[] _imageAsByteArray = null;
        public string _pic_name;

        [NonSerialized]
        private Image _img_back_pic = null;
        
        public override string ToString()
        {
            return _pic_name;
        }

        //lade bild aus datei und speichere diese für weitere verwendung
        public bool new_floor_plan(string path_to_pic) {
            if (File.Exists(path_to_pic))
            {
                try
                {
                    _img_back_pic = Image.FromFile(path_to_pic);

                    _picture_heigth = _img_back_pic.Height;
                    _picture_width = _img_back_pic.Width;

                    MemoryStream ms = new MemoryStream();
                    _img_back_pic.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                    _imageAsByteArray = ms.ToArray();

                    _pic_name = Path.GetFileNameWithoutExtension(path_to_pic);

                    return true;
                }
                catch (Exception e)
                {
                    log.exception(this, "floor_plan() [" + path_to_pic + "]", e);
                }
            }
            else
                log.msg(this, "make new floor_plan with none existing path: " + path_to_pic);
            return false;
        }

        public Image get_image() {
            if (_img_back_pic == null)
                if (_imageAsByteArray != null)
                {
                    MemoryStream ms = new MemoryStream(_imageAsByteArray);
                    _img_back_pic = Image.FromStream(ms);
                }
                else
                    log.msg(this, " ERROR get_image() _imageAsByteArray==null");
            return _img_back_pic;
        }

    }
}
