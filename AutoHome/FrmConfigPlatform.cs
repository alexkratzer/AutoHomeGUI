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
    public partial class FrmConfigPlatform : Form
    {
        List<platform> _list_platform;
        List<aktuator> _list_aktor;
        List<plc> _list_plc; //wird in FrmConfigPlatform_controlDialog benötigt
        platform platform_selected = null; //wird gesetzt wenn in combo box ausgewählt wird
        FrmMain _frmMain; //wird benötigt um beim schließen der FrmConfigPlatform Main zu aktualisieren
        List<floor_plan> _list_floor_plan;

        public FrmConfigPlatform(object list_platform, object list_aktor, object list_plc, FrmMain frmMain)
        {
            InitializeComponent();
            _list_platform = (List<platform>)list_platform;
            _list_aktor = (List<aktuator>)list_aktor;
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
            default_controls.Add(new PBdefaultControl(aktor_type.light));
            default_controls.Add(new PBdefaultControl(aktor_type.jalousie));
            default_controls.Add(new PBdefaultControl(aktor_type.heater));
            default_controls.Add(new PBdefaultControl(aktor_type.undef));

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
                    //if (pictureBox_platform.Controls.Contains(pc._PictureBox))
                    pictureBox_platform.Controls.Remove(pc._PictureBox);
                    pc._PictureBox.MouseDoubleClick -= new MouseEventHandler(_PictureBox_MouseDoubleClick);
                    pc._PictureBox.MouseMove -= new MouseEventHandler(_PictureBox_MouseMove);  
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
                        pictureBox_platform.Controls.Add(pc._PictureBox);
                        pictureBox_platform.Image = platform_selected.get_background_pic();
                        pc._PictureBox.MouseMove += new MouseEventHandler(_PictureBox_MouseMove);
                        pc._PictureBox.MouseDoubleClick += new MouseEventHandler(_PictureBox_MouseDoubleClick);
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
            PBplatformControl c = (PBplatformControl)sender;
            FrmConfigPlatform_controlDialog d = new FrmConfigPlatform_controlDialog(_list_aktor, c._platform_control, _list_plc, selected_plc);
            
            DialogResult dr = d.ShowDialog();
            if (dr == DialogResult.OK)
            { //aktuator zuweisen oder ändern
                c._platform_control.change_aktuator((aktuator)d.get_aktuator());
                selected_plc = d.get_selected_plc();
            }
            else if (dr == DialogResult.Abort) //controll wird komplett gelöscht
            {
                pictureBox_platform.Controls.Remove(c._platform_control._PictureBox);
                platform_selected._list_platform_control.Remove(c._platform_control);
            }
        }

        //control wird verschoben
        void _PictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                PBplatformControl mc = (PBplatformControl)sender;
                mc.BringToFront();
                mc.Location = new Point(mc.Location.X + e.Location.X - 30, mc.Location.Y + e.Location.Y - 30);

                //speichern der position für spätere bearbeitung
                mc._platform_control._pos_x = mc.Location.X;
                mc._platform_control._pos_y = mc.Location.Y;
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

            try{
                switch (t)
                {
                    case aktor_type.light:
                        Image = new Bitmap(AutoHome.Properties.Resources.img_candle_default);
                        break;
                    case aktor_type.jalousie:
                        Image = new Bitmap(AutoHome.Properties.Resources.img_jalousie_default);
                        break;
                    case aktor_type.heater:
                        Image = new Bitmap(AutoHome.Properties.Resources.img_heater_default);
                        break;
                    case aktor_type.undef:
                        Image = new Bitmap(AutoHome.Properties.Resources.img_undef_default);
                        break;
                }
            }
            catch (Exception e)
            {
                log.exception(this, "error loading png from file ", e);
            }
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
            }
            return Location;
        }
    }

    /// <summary>
    /// Darstellung der aktoren in GUI (platform picture)
    /// </summary>
    class PBplatformControl : PictureBox
    {
        public platform_control _platform_control;
        Label l;
        private Frame lastFrame = null;

        //neues element wird erstellt
        public PBplatformControl(aktor_type t, platform_control platform_control)
        {
            _platform_control = platform_control;
            pic_set_edit_pic(t);
        }

        //element wird durch deserialisieren erstellt
        public PBplatformControl(platform_control platform_control, int pos_x, int pos_y)
        {
            _platform_control = platform_control;
            Location = new Point(pos_x, pos_y);
            pic_set_edit_pic(_platform_control._type);

            update_label_text();
        }

        public void update_label_text() {
            if (_platform_control._aktuator != null)
            {
                if (l != null)
                    l.Text = _platform_control._aktuator.Name;
                else
                {
                    l = new Label();
                    l.BackColor = Color.Transparent;
                    l.Text = _platform_control._aktuator.Name;
                    this.Controls.Add(l);
                }
            }
            else {
//pikture box sollte gelöscht sein.....
                ;
            }
        }

        //bild für FrmConfigPlatform wird erstellt
        private void pic_set_edit_pic(aktor_type t)
        {
            Visible = true;
            Size = new Size(60, 60);
            this.BackColor = Color.Transparent;
            this.BringToFront();

            try
            {
                switch (t)
                {
                    case aktor_type.light:
                        Image = new Bitmap(AutoHome.Properties.Resources.img_candle_default);
                        //Image = System.Drawing.Bitmap.FromFile(var.img_candle);
                        break;
                    case aktor_type.jalousie:
                        Image = new Bitmap(AutoHome.Properties.Resources.img_jalousie_default);
                        break;
                    case aktor_type.heater:
                        Image = new Bitmap(AutoHome.Properties.Resources.img_heater_default);
                        break;
                    case aktor_type.undef:
                        Image = new Bitmap(AutoHome.Properties.Resources.img_undef_default);
                        break;
                }
            }
            catch (Exception e) {
                log.exception(this, "error loading png from file ", e);
            }
        }

        /// <summary>
        /// aktuell dargestelltes bild wird je nach aktualdaten aus cpu angepasst
        /// </summary>
        public void pic_update(cpsLIB.Frame f)
        {
            //no content changed to last request
            if (lastFrame != null && lastFrame.IsEqualPayload(f))
                return;

            this.BackColor = Color.Transparent;
            this.Controls.Remove(l);
            switch (_platform_control._type)
            {
                case aktor_type.light:
                    if (Convert.ToBoolean(f.getPayloadInt(2)))
                        Image = new Bitmap(AutoHome.Properties.Resources.img_candle_on);
                    //Image = System.Drawing.Bitmap.FromFile(var.img_candle_on);
                    else
                        Image = new Bitmap(Properties.Resources.img_candle_off);
                    break;
                case aktor_type.jalousie:
                    if (f.isJob(DataIOType.GetState))
                    {
                        if (f.getPayloadInt(2) >= 0 && f.getPayloadInt(2) < 33)
                            Image = new Bitmap(Properties.Resources.img_jalousie_up);
                        else if (f.getPayloadInt(2) < 66)
                            Image = new Bitmap(Properties.Resources.img_jalousie_middle);
                        else if (f.getPayloadInt(2) <= 100)
                            Image = new Bitmap(Properties.Resources.img_jalousie_down);
                        //PictureBox pbu = new PictureBox();
                        //pbu.Image = System.Drawing.Bitmap.FromFile(var.workingdir + "\\img_arrow_up.png");
                        //this.Controls.Add(pbu);
                    }
                    break;
                case aktor_type.heater:
                    if (f.isJob(DataIOType.GetState)) {
                        bool state_on = Convert.ToBoolean(f.getPayloadInt(2));
                        bool ctrl_manual = Convert.ToBoolean(f.getPayloadInt(3));

                        if (state_on && !ctrl_manual) //an und automatic
                            Image = new Bitmap(Properties.Resources.img_heater_on);
                        else if (state_on && ctrl_manual) //an und manuell
                            Image = new Bitmap(Properties.Resources.img_heater_on_manual);
                        else if (!state_on && !ctrl_manual) //aus und automatic
                            Image = new Bitmap(Properties.Resources.img_heater_off);
                        else if (!state_on && ctrl_manual) //aus und manuell
                            Image = new Bitmap(Properties.Resources.img_heater_off_manual);
                    }
                    break;

                //case aktor_type.undef:
                //    Image = System.Drawing.Bitmap.FromFile(var.workingdir + "\\img_undef.png");
                //    break;
            }

            lastFrame = f;
        }


    }
}
