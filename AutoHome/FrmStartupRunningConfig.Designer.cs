namespace AutoHome
{
    partial class FrmStartupRunningConfig
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
            this.listBox_plcs = new System.Windows.Forms.ListBox();
            this.listBox_aktors = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // listBox_plcs
            // 
            this.listBox_plcs.FormattingEnabled = true;
            this.listBox_plcs.Location = new System.Drawing.Point(12, 32);
            this.listBox_plcs.Name = "listBox_plcs";
            this.listBox_plcs.Size = new System.Drawing.Size(127, 511);
            this.listBox_plcs.TabIndex = 1;
            this.listBox_plcs.SelectedIndexChanged += new System.EventHandler(this.listBox_plcs_SelectedIndexChanged);
            // 
            // listBox_aktors
            // 
            this.listBox_aktors.FormattingEnabled = true;
            this.listBox_aktors.Location = new System.Drawing.Point(178, 32);
            this.listBox_aktors.Name = "listBox_aktors";
            this.listBox_aktors.Size = new System.Drawing.Size(333, 498);
            this.listBox_aktors.TabIndex = 2;
            // 
            // FrmStartupRunningConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(855, 567);
            this.Controls.Add(this.listBox_aktors);
            this.Controls.Add(this.listBox_plcs);
            this.Name = "FrmStartupRunningConfig";
            this.Text = "Startup- Running Config";
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ListBox listBox_plcs;
        private System.Windows.Forms.ListBox listBox_aktors;
    }
}