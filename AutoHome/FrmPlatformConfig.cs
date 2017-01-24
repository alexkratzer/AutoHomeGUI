using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using cpsLIB; //frames

namespace AutoHome
{
    public partial class FrmPlatformConfig : Form
    {
        List<platform> _list_platform;
        List<plc> _list_plc; //wird in FrmConfigPlatform_controlDialog benötigt
        platform platform_selected = null; //wird gesetzt wenn in combo box ausgewählt wird
        FrmMain _frmMain; //wird benötigt um beim schließen der FrmConfigPlatform Main zu aktualisieren
        List<floor_plan> _list_floor_plan;

        public FrmPlatformConfig(object list_platform, object list_plc, FrmMain frmMain)
        {
            InitializeComponent();
            _list_platform = (List<platform>)list_platform;
            
            _list_plc = (List<plc>)list_plc;
            _frmMain = frmMain;
            
            list_platform_refresh();
            if(_list_platform.Count>0)
                toolStripComboBox_selected_platform.SelectedIndex = 0;
        }

        private void FrmConfigPlatform_Load(object sender, EventArgs e)
        {
            //für jeden aktor typ wird ein default control zum späteren anklicken dargestellt
            List<Control> default_controls = new List<Control>();
            foreach (aktor_type at in Enum.GetValues(typeof(aktor_type)))
                default_controls.Add(new PBdefaultControl(at));
            //default_controls.Add(new PBdefaultControl(aktor_type.light));
            //default_controls.Add(new PBdefaultControl(aktor_type.jalousie));
            //default_controls.Add(new PBdefaultControl(aktor_type.heater));
            //default_controls.Add(new PBdefaultControl(aktor_type.undef));

            foreach (PBdefaultControl c in default_controls)
            {
                this.Controls.Add(c);
                c.MouseClick += new MouseEventHandler(c_MouseClick_new_platform);
            }

            _list_floor_plan = var.deserialize_floor_plan();
            comboBox_floor_plan.DataSource = _list_floor_plan;
        }

        private void FrmConfigPlatform_FormClosed(object sender, FormClosedEventArgs e)
        {
            paint_platform(true);
            var.serialize_floor_plan(_list_floor_plan);
            _frmMain.update_gui();
        }

        #region menue

        #region menue platform
        
        private void toolStripComboBox_selected_platform_SelectedIndexChanged(object sender, EventArgs e)
        {
            button_new_platform_name_save.Visible = false;
            platform_selected = (platform)toolStripComboBox_selected_platform.SelectedItem;
             
            paint_platform();

            if (platform_selected._floor_plan != null)
            {
                for (int i = 0; i < comboBox_floor_plan.Items.Count; i++)
                    if (((floor_plan)comboBox_floor_plan.Items[i]).ToString() == platform_selected._floor_plan.ToString())
                        comboBox_floor_plan.SelectedIndex = i;
            }

        }
        private void makeNewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            platform p = new platform("choose name");
            _list_platform.Add(p);
            list_platform_refresh();
            toolStripComboBox_selected_platform.SelectedItem = p;
        }
        private void importPicToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_list_platform.Count > 0)
            {
                delete_all_controlls();
                platform p = (platform)toolStripComboBox_selected_platform.SelectedItem;
                _list_platform.Remove(p);
                p = null;
                platform_selected = (platform)toolStripComboBox_selected_platform.Items[0];
                list_platform_refresh();
            }
            else
                MessageBox.Show("no platform exists", "Error");
        }

        private void button_new_platform_name_save_Click(object sender, EventArgs e)
        {
            save_new_platform_name();
        }

        private void toolStripComboBox_selected_platform_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
                save_new_platform_name();
            else
                button_new_platform_name_save.Visible = true;
        }
        private void save_new_platform_name() {
            button_new_platform_name_save.Visible = false;
            if (platform_selected != null)
                platform_selected._platform_name = toolStripComboBox_selected_platform.Text;
            list_platform_refresh();
            //toolStripComboBox_selected_platform.SelectedIndex = 0;
        }
        #endregion

        #region control
        /// <summary>
        /// alle controls der aktuell dargestellten platform werden gelöscht
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void deleteAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            delete_all_controlls();
        }
        private void dbghideToolStripMenuItem_Click(object sender, EventArgs e)
        {
            platform p = (platform)toolStripComboBox_selected_platform.SelectedItem;

            foreach (platform_control pc in p._list_platform_control)
                pictureBox_platform.Controls.Remove(pc._PictureBox);
        }
        private void delete_all_controlls() {
            platform p = (platform)toolStripComboBox_selected_platform.SelectedItem;
            foreach (platform_control pc in p._list_platform_control)
                pictureBox_platform.Controls.Remove(pc._PictureBox);
            p._list_platform_control.Clear();
        }
        #endregion

        #region floor plan
        private void importToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Image Files(*.BMP;*.GIF;*.JPEG;*.PNG;)|*.BMP;*.GIF;*.JPG;*.JPEG;*.PNG;*.TIFF;*.TIF|All files (*.*)|*.*";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                floor_plan fp = new floor_plan();
                if (fp.new_floor_plan(ofd.FileName))
                {
                    paint_platform();
                    _list_floor_plan.Add(fp);
                    comboBox_floor_plan.DataSource = null;
                    comboBox_floor_plan.DataSource = _list_floor_plan;
                }
                else
                    MessageBox.Show("Error importing picture!", "ERROR");
            }
        }
        private void exportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            if (sfd.ShowDialog() == DialogResult.OK) {
                MessageBox.Show("TODO: " + sfd.FileName);
            }
        }


        #endregion
        #endregion

        #region display platform and controls
        /// <summary>
        /// platform wird neu hinzugefügt, gelöscht, editiert usw
        /// </summary>
        private void list_platform_refresh()
        {
            toolStripComboBox_selected_platform.Items.Clear();
            foreach (platform p in _list_platform)
                toolStripComboBox_selected_platform.Items.Add(p);

            paint_platform();
        }

 
        /// <summary>
        /// alle controls aller platforms werden mit event handler gelöscht. Danach wird für die aktuell 
        /// ausgewählte platform die controlls neu angelegt und die event handler gesetzt.
        /// </summary>
        /// <param name="clear">wenn true werden nur die controls gelöscht und nicht neu hinzugefügt</param>
        private void paint_platform(bool clear = false)
        {
            pictureBox_platform.Image = null;
            pictureBox_platform.Refresh();

            //event handler und bilder löschen
            foreach (platform p in _list_platform)
                foreach (platform_control pc in p._list_platform_control)
                {
                    if (pictureBox_platform.Controls.Contains(pc._PictureBox))
                    {
                        pictureBox_platform.Controls.Remove(pc._PictureBox);
                        pc._PictureBox.MouseDoubleClick -= new MouseEventHandler(_PictureBox_MouseDoubleClick);
                        pc._PictureBox.MouseMove -= new MouseEventHandler(_PictureBox_MouseMove);
                    }
                    else if (pictureBox_platform.Controls.Contains(pc._UCsensorValue))
                    {
                        pictureBox_platform.Controls.Remove(pc._UCsensorValue);
                        pc._UCsensorValue.MouseDoubleClick -= new MouseEventHandler(_PictureBox_MouseDoubleClick);
                        pc._UCsensorValue.MouseMove -= new MouseEventHandler(_PictureBox_MouseMove);

                        foreach (Control c in pc._UCsensorValue.Controls)
                        {
                            c.MouseMove -= new MouseEventHandler(_PictureBox_MouseMove);
                            c.MouseDoubleClick -= new MouseEventHandler(_PictureBox_MouseDoubleClick);
                        }
                    }
                }

            if (!clear)
            {//event handler zuweisen und bild zeichnen
                //platform p_selected = (platform)toolStripComboBox_selected_platform.SelectedItem;
                if (platform_selected != null)
                {
                    //hintergrundbild zeichnen
                    pictureBox_platform.Image = platform_selected.get_background_pic();

                    //controls zeichnen
                    foreach (platform_control pc in platform_selected._list_platform_control)
                    {
                        if (pc._PictureBox != null)
                        {
                            pictureBox_platform.Controls.Add(pc._PictureBox);
                            //pictureBox_platform.Image = platform_selected.get_background_pic();
                            pc._PictureBox.MouseMove += new MouseEventHandler(_PictureBox_MouseMove);
                            pc._PictureBox.MouseDoubleClick += new MouseEventHandler(_PictureBox_MouseDoubleClick);
                        }
                        else if (pc._UCsensorValue != null) {
                            pictureBox_platform.Controls.Add(pc._UCsensorValue);
                            pc._UCsensorValue.MouseMove += new MouseEventHandler(_PictureBox_MouseMove);
                            pc._UCsensorValue.MouseDoubleClick += new MouseEventHandler(_PictureBox_MouseDoubleClick);

                            foreach (Control c in pc._UCsensorValue.Controls)
                            {
                                c.MouseMove += new MouseEventHandler(_PictureBox_MouseMove);
                                c.MouseDoubleClick += new MouseEventHandler(_PictureBox_MouseDoubleClick);
                            }
                        }
                    }
                    this.Text = var.tool_text + " Platform: [" + platform_selected._platform_name + "]";
                }
                else
                    this.Text = var.tool_text + " Platform: [ choose platform ]";
            }
        }

        #endregion

        #region event handler
        //default control wird angeklickt, damit wird ein neues control zum definieren erstellt
        void c_MouseClick_new_platform(object sender, MouseEventArgs e)
        {
            if (_list_platform.Count > 0)
            {
                //typ des neuen controls ermitteln
                PBdefaultControl PBdef = (PBdefaultControl)sender;

                //neues control ohne aktor zum verschieben auf richtige position links oben neu anlegen
                platform_control pc = new platform_control(PBdef._type);
                platform_selected._list_platform_control.Add(pc);

                paint_platform();
            }
            else
                MessageBox.Show("no defined platform jet","Error");
        }

        int selected_plc = 0; //damit beim öffnen des dialogs immer die letzte gewählte cpu ausgewählt ist
        //control wird angeklickt
        void _PictureBox_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (sender is PBplatformControl)
            {
                PBplatformControl pc = (PBplatformControl)sender;
                FrmPlatformConfig_EditControlDialog d = new FrmPlatformConfig_EditControlDialog(pc._platform_control, _list_plc, selected_plc);

                DialogResult dr = d.ShowDialog();
                if (dr == DialogResult.OK)
                { //aktuator zuweisen oder ändern
                    pc._platform_control.change_aktuator((aktuator)d.get_aktuator());
                    selected_plc = d.get_selected_plc();
                }
                else if (dr == DialogResult.Abort) //controll wird komplett gelöscht
                {
                    pictureBox_platform.Controls.Remove(pc._platform_control._PictureBox);
                    platform_selected._list_platform_control.Remove(pc._platform_control);
                }
            }
            else if (sender is UC_SensorValue)
            {
                UC_SensorValue uc = (UC_SensorValue)sender;
                FrmPlatformConfig_EditControlDialog d = new FrmPlatformConfig_EditControlDialog(uc._platform_control, _list_plc, selected_plc);

                DialogResult dr = d.ShowDialog();
                if (dr == DialogResult.OK)
                { //aktuator zuweisen oder ändern
                    uc._platform_control.change_aktuator((aktuator)d.get_aktuator());
                    selected_plc = d.get_selected_plc();
                }
                else if (dr == DialogResult.Abort) //controll wird komplett gelöscht
                {
                    pictureBox_platform.Controls.Remove(uc._platform_control._UCsensorValue);
                    platform_selected._list_platform_control.Remove(uc._platform_control);
                }
            }
            else if (sender is Label) //TODO: die 3 typen ohne verzweigung behandeln
            {
                //MessageBox.Show("sender -> label " + Environment.NewLine + l.Handle.ToString() + Environment.NewLine + l.Tag.ToString()
                //    + Environment.NewLine + ((UC_SensorValue)l.Tag).label_sensorName );

                UC_SensorValue uc = (UC_SensorValue)((Label)sender).Tag;
                FrmPlatformConfig_EditControlDialog d = new FrmPlatformConfig_EditControlDialog(uc._platform_control, _list_plc, selected_plc);

                DialogResult dr = d.ShowDialog();
                if (dr == DialogResult.OK)
                { //aktuator zuweisen oder ändern
                    uc._platform_control.change_aktuator((aktuator)d.get_aktuator());
                    selected_plc = d.get_selected_plc();
                }
                else if (dr == DialogResult.Abort) //controll wird komplett gelöscht
                {
                    pictureBox_platform.Controls.Remove(uc._platform_control._UCsensorValue);
                    platform_selected._list_platform_control.Remove(uc._platform_control);
                }
            }
            else
                log.msg(this, "call control_MouseMove with unknown sender (allowed PBplatformControl/UC_SensorValue): " + sender.GetType());
        }

        //control wird verschoben
        void _PictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                PBplatformControl mc;
                UC_SensorValue uc;
                if (sender is PBplatformControl)
                {
                    mc = (PBplatformControl)sender;
                    mc.BringToFront();
                    mc.Location = new Point(mc.Location.X + e.Location.X - 30, mc.Location.Y + e.Location.Y - 30);

                    //speichern der position für spätere bearbeitung
                    mc._platform_control._pos_x = mc.Location.X;
                    mc._platform_control._pos_y = mc.Location.Y;
                }
                else if (sender is UC_SensorValue)
                {
                    uc = (UC_SensorValue)sender;
                    uc.BringToFront();
                    uc.Location = new Point(uc.Location.X + e.Location.X - 30, uc.Location.Y + e.Location.Y - 30);

                    //speichern der position für spätere bearbeitung
                    uc._platform_control._pos_x = uc.Location.X;
                    uc._platform_control._pos_y = uc.Location.Y;
                }
                else if (sender is Label) {
                    uc = (UC_SensorValue)((Label)sender).Tag;
                    uc.BringToFront();
                    uc.Location = new Point(uc.Location.X + e.Location.X - 30, uc.Location.Y + e.Location.Y - 30);

                    //speichern der position für spätere bearbeitung
                    uc._platform_control._pos_x = uc.Location.X;
                    uc._platform_control._pos_y = uc.Location.Y;
                }
                else
                    log.msg(this, "call control_MouseMove with unknown sender (allowed PBplatformControl/UC_SensorValue): " + sender.GetType());
            }
        }
        #endregion 

        #region floor plan
        floor_plan floor_plan_selected;
        private void comboBox_floor_plan_SelectedIndexChanged(object sender, EventArgs e)
        {
            floor_plan_selected = (floor_plan)comboBox_floor_plan.SelectedItem;

            platform_selected.set_floor_plan(floor_plan_selected);
            pictureBox_platform.Image = platform_selected.get_background_pic();
        }

        private void comboBox_floor_plan_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                floor_plan_selected._pic_name = comboBox_floor_plan.Text;
                comboBox_floor_plan.BackColor = Color.White;

                comboBox_floor_plan.DataSource = null;
                comboBox_floor_plan.DataSource = _list_floor_plan;
            }
            else
                comboBox_floor_plan.BackColor = Color.Orange;
        }
        #endregion



    }

    /// <summary>
    /// Picture Box für default Aktoren
    /// für jeden Aktor Typ wird ein default erstellt
    /// um diesen später in der oberfläche verschieben zu können
    /// </summary>
    class PBdefaultControl : PictureBox
    {
        public aktor_type _type; 
        public PBdefaultControl(aktor_type _type)
        {
            this._type = _type;
            set_pic(_type);
            default_location(_type);
        }

        private void set_pic(aktor_type t)
        {
            Visible = true;
            Size = new Size(60, 60);
            this.BackColor = Color.Transparent;
            this.BringToFront();
            Image = GetPicByType(t);
            this._type = t;
        }
        public static Bitmap GetPicByType(aktor_type t) {
            try
            {
                switch (t)
                {
                    case aktor_type.light:
                        return new Bitmap(AutoHome.Properties.Resources.img_candle_default);
                    case aktor_type.jalousie:
                        return new Bitmap(AutoHome.Properties.Resources.img_jalousie_default);
                    case aktor_type.heater:
                        return new Bitmap(AutoHome.Properties.Resources.img_heater_default);                        
                    case aktor_type.undef:
                        return new Bitmap(AutoHome.Properties.Resources.img_undef_default);
                    case aktor_type.sensor:
                        return new Bitmap(AutoHome.Properties.Resources.img_sensor_default);   
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("FrmConfigPlatform: " + e.Message, "error loading png from file ");
                //log.exception("FrmConfigPlatform", "error loading png from file ", e);
            }
            return null;
        }

        private Point default_location(aktor_type t)
        {
            switch (t)
            {
                case aktor_type.light:
                    Location = new Point(12, 143);
                    break;
                case aktor_type.jalousie:
                    Location = new Point(81, 143);
                    break;
                case aktor_type.heater:
                    Location = new Point(12, 209);
                    break;
                case aktor_type.undef:
                    Location = new Point(81, 209);
                    break;
                case aktor_type.sensor:
                    Location = new Point(12, 275);
                    break;
            }
            return Location;
        }
    }


}
