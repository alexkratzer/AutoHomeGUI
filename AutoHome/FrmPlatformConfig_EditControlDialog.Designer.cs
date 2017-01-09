namespace AutoHome
{
    partial class FrmPlatformConfig_EditControlDialog
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
            this.comboBox_aktor_name = new System.Windows.Forms.ComboBox();
            this.bttOK = new System.Windows.Forms.Button();
            this.bttCancel = new System.Windows.Forms.Button();
            this.label_aktuator_name = new System.Windows.Forms.Label();
            this.label_id = new System.Windows.Forms.Label();
            this.label_type = new System.Windows.Forms.Label();
            this.button_delete = new System.Windows.Forms.Button();
            this.comboBox_plc = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // comboBox_aktor_name
            // 
            this.comboBox_aktor_name.FormattingEnabled = true;
            this.comboBox_aktor_name.Location = new System.Drawing.Point(12, 35);
            this.comboBox_aktor_name.Name = "comboBox_aktor_name";
            this.comboBox_aktor_name.Size = new System.Drawing.Size(311, 21);
            this.comboBox_aktor_name.TabIndex = 0;
            this.comboBox_aktor_name.SelectedIndexChanged += new System.EventHandler(this.comboBox_aktor_name_SelectedIndexChanged);
            // 
            // bttOK
            // 
            this.bttOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.bttOK.Location = new System.Drawing.Point(248, 62);
            this.bttOK.Name = "bttOK";
            this.bttOK.Size = new System.Drawing.Size(75, 23);
            this.bttOK.TabIndex = 1;
            this.bttOK.Text = "OK";
            this.bttOK.UseVisualStyleBackColor = true;
            this.bttOK.Click += new System.EventHandler(this.bttOK_Click);
            // 
            // bttCancel
            // 
            this.bttCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.bttCancel.Location = new System.Drawing.Point(93, 62);
            this.bttCancel.Name = "bttCancel";
            this.bttCancel.Size = new System.Drawing.Size(75, 23);
            this.bttCancel.TabIndex = 2;
            this.bttCancel.Text = "cancel";
            this.bttCancel.UseVisualStyleBackColor = true;
            this.bttCancel.Click += new System.EventHandler(this.bttCancel_Click);
            // 
            // label_aktuator_name
            // 
            this.label_aktuator_name.AutoSize = true;
            this.label_aktuator_name.Location = new System.Drawing.Point(107, 9);
            this.label_aktuator_name.Name = "label_aktuator_name";
            this.label_aktuator_name.Size = new System.Drawing.Size(33, 13);
            this.label_aktuator_name.TabIndex = 5;
            this.label_aktuator_name.Text = "name";
            // 
            // label_id
            // 
            this.label_id.AutoSize = true;
            this.label_id.Location = new System.Drawing.Point(12, 9);
            this.label_id.Name = "label_id";
            this.label_id.Size = new System.Drawing.Size(15, 13);
            this.label_id.TabIndex = 6;
            this.label_id.Text = "id";
            // 
            // label_type
            // 
            this.label_type.AutoSize = true;
            this.label_type.Location = new System.Drawing.Point(52, 9);
            this.label_type.Name = "label_type";
            this.label_type.Size = new System.Drawing.Size(27, 13);
            this.label_type.TabIndex = 7;
            this.label_type.Text = "type";
            // 
            // button_delete
            // 
            this.button_delete.DialogResult = System.Windows.Forms.DialogResult.Abort;
            this.button_delete.Location = new System.Drawing.Point(12, 62);
            this.button_delete.Name = "button_delete";
            this.button_delete.Size = new System.Drawing.Size(75, 23);
            this.button_delete.TabIndex = 8;
            this.button_delete.Text = "delete";
            this.button_delete.UseVisualStyleBackColor = true;
            this.button_delete.Click += new System.EventHandler(this.button_delete_Click);
            // 
            // comboBox_plc
            // 
            this.comboBox_plc.FormattingEnabled = true;
            this.comboBox_plc.Location = new System.Drawing.Point(228, 5);
            this.comboBox_plc.Name = "comboBox_plc";
            this.comboBox_plc.Size = new System.Drawing.Size(95, 21);
            this.comboBox_plc.TabIndex = 9;
            this.comboBox_plc.SelectedIndexChanged += new System.EventHandler(this.comboBox_plc_SelectedIndexChanged);
            // 
            // FrmConfigPlatform_controlDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(335, 92);
            this.Controls.Add(this.comboBox_plc);
            this.Controls.Add(this.button_delete);
            this.Controls.Add(this.label_type);
            this.Controls.Add(this.label_id);
            this.Controls.Add(this.label_aktuator_name);
            this.Controls.Add(this.bttCancel);
            this.Controls.Add(this.bttOK);
            this.Controls.Add(this.comboBox_aktor_name);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmConfigPlatform_controlDialog";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "FrmConfigPlatform_controlDialog";
            this.Load += new System.EventHandler(this.FrmConfigPlatform_controlDialog_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBox_aktor_name;
        private System.Windows.Forms.Button bttOK;
        private System.Windows.Forms.Button bttCancel;
        private System.Windows.Forms.Label label_aktuator_name;
        private System.Windows.Forms.Label label_id;
        private System.Windows.Forms.Label label_type;
        private System.Windows.Forms.Button button_delete;
        private System.Windows.Forms.ComboBox comboBox_plc;
    }
}