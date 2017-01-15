namespace AutoHome
{
    partial class FrmPlatformConfig
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pictureBox_platform = new System.Windows.Forms.PictureBox();
            this.button_new_platform_name_save = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolStripComboBox_selected_platform = new System.Windows.Forms.ToolStripComboBox();
            this.platformToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.makeNewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.floorPlanToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.controlToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dbghideToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.comboBox_floor_plan = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_platform)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox_platform
            // 
            this.pictureBox_platform.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.pictureBox_platform.Location = new System.Drawing.Point(191, 30);
            this.pictureBox_platform.Name = "pictureBox_platform";
            this.pictureBox_platform.Size = new System.Drawing.Size(925, 720);
            this.pictureBox_platform.TabIndex = 0;
            this.pictureBox_platform.TabStop = false;
            // 
            // button_new_platform_name_save
            // 
            this.button_new_platform_name_save.Location = new System.Drawing.Point(10, 30);
            this.button_new_platform_name_save.Name = "button_new_platform_name_save";
            this.button_new_platform_name_save.Size = new System.Drawing.Size(141, 23);
            this.button_new_platform_name_save.TabIndex = 36;
            this.button_new_platform_name_save.Text = "save new name";
            this.button_new_platform_name_save.UseVisualStyleBackColor = true;
            this.button_new_platform_name_save.Visible = false;
            this.button_new_platform_name_save.Click += new System.EventHandler(this.button_new_platform_name_save_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripComboBox_selected_platform,
            this.platformToolStripMenuItem,
            this.floorPlanToolStripMenuItem,
            this.controlToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1179, 27);
            this.menuStrip1.TabIndex = 35;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // toolStripComboBox_selected_platform
            // 
            this.toolStripComboBox_selected_platform.Name = "toolStripComboBox_selected_platform";
            this.toolStripComboBox_selected_platform.Size = new System.Drawing.Size(121, 23);
            this.toolStripComboBox_selected_platform.SelectedIndexChanged += new System.EventHandler(this.toolStripComboBox_selected_platform_SelectedIndexChanged);
            this.toolStripComboBox_selected_platform.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.toolStripComboBox_selected_platform_KeyPress);
            // 
            // platformToolStripMenuItem
            // 
            this.platformToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.makeNewToolStripMenuItem,
            this.deleteToolStripMenuItem});
            this.platformToolStripMenuItem.Name = "platformToolStripMenuItem";
            this.platformToolStripMenuItem.Size = new System.Drawing.Size(65, 23);
            this.platformToolStripMenuItem.Text = "platform";
            // 
            // makeNewToolStripMenuItem
            // 
            this.makeNewToolStripMenuItem.Name = "makeNewToolStripMenuItem";
            this.makeNewToolStripMenuItem.Size = new System.Drawing.Size(128, 22);
            this.makeNewToolStripMenuItem.Text = "make new";
            this.makeNewToolStripMenuItem.Click += new System.EventHandler(this.makeNewToolStripMenuItem_Click);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(128, 22);
            this.deleteToolStripMenuItem.Text = "delete";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
            // 
            // floorPlanToolStripMenuItem
            // 
            this.floorPlanToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.importToolStripMenuItem,
            this.exportToolStripMenuItem});
            this.floorPlanToolStripMenuItem.Name = "floorPlanToolStripMenuItem";
            this.floorPlanToolStripMenuItem.Size = new System.Drawing.Size(70, 23);
            this.floorPlanToolStripMenuItem.Text = "floor plan";
            // 
            // importToolStripMenuItem
            // 
            this.importToolStripMenuItem.Name = "importToolStripMenuItem";
            this.importToolStripMenuItem.Size = new System.Drawing.Size(110, 22);
            this.importToolStripMenuItem.Text = "import";
            this.importToolStripMenuItem.Click += new System.EventHandler(this.importToolStripMenuItem_Click);
            // 
            // exportToolStripMenuItem
            // 
            this.exportToolStripMenuItem.Name = "exportToolStripMenuItem";
            this.exportToolStripMenuItem.Size = new System.Drawing.Size(110, 22);
            this.exportToolStripMenuItem.Text = "export";
            this.exportToolStripMenuItem.Click += new System.EventHandler(this.exportToolStripMenuItem_Click);
            // 
            // controlToolStripMenuItem
            // 
            this.controlToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.deleteAllToolStripMenuItem,
            this.dbghideToolStripMenuItem});
            this.controlToolStripMenuItem.Name = "controlToolStripMenuItem";
            this.controlToolStripMenuItem.Size = new System.Drawing.Size(122, 23);
            this.controlToolStripMenuItem.Text = "control - evtl delete";
            // 
            // deleteAllToolStripMenuItem
            // 
            this.deleteAllToolStripMenuItem.Name = "deleteAllToolStripMenuItem";
            this.deleteAllToolStripMenuItem.Size = new System.Drawing.Size(123, 22);
            this.deleteAllToolStripMenuItem.Text = "delete all";
            this.deleteAllToolStripMenuItem.Click += new System.EventHandler(this.deleteAllToolStripMenuItem_Click);
            // 
            // dbghideToolStripMenuItem
            // 
            this.dbghideToolStripMenuItem.Name = "dbghideToolStripMenuItem";
            this.dbghideToolStripMenuItem.Size = new System.Drawing.Size(123, 22);
            this.dbghideToolStripMenuItem.Text = "dbg_hide";
            this.dbghideToolStripMenuItem.Click += new System.EventHandler(this.dbghideToolStripMenuItem_Click);
            // 
            // comboBox_floor_plan
            // 
            this.comboBox_floor_plan.FormattingEnabled = true;
            this.comboBox_floor_plan.Location = new System.Drawing.Point(10, 57);
            this.comboBox_floor_plan.Name = "comboBox_floor_plan";
            this.comboBox_floor_plan.Size = new System.Drawing.Size(141, 21);
            this.comboBox_floor_plan.TabIndex = 37;
            this.comboBox_floor_plan.SelectedIndexChanged += new System.EventHandler(this.comboBox_floor_plan_SelectedIndexChanged);
            this.comboBox_floor_plan.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.comboBox_floor_plan_KeyPress);
            // 
            // FrmPlatformConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1179, 793);
            this.Controls.Add(this.comboBox_floor_plan);
            this.Controls.Add(this.button_new_platform_name_save);
            this.Controls.Add(this.pictureBox_platform);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FrmPlatformConfig";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "FrmConfigPlatform";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmConfigPlatform_FormClosed);
            this.Load += new System.EventHandler(this.FrmConfigPlatform_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_platform)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox_platform;
        private System.Windows.Forms.Button button_new_platform_name_save;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripComboBox toolStripComboBox_selected_platform;
        private System.Windows.Forms.ToolStripMenuItem platformToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem makeNewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem controlToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteAllToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dbghideToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem floorPlanToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem importToolStripMenuItem;
        private System.Windows.Forms.ComboBox comboBox_floor_plan;
        private System.Windows.Forms.ToolStripMenuItem exportToolStripMenuItem;
    }
}