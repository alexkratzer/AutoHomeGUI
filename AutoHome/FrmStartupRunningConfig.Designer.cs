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
            this.dataGridView_plcs = new System.Windows.Forms.DataGridView();
            this.dataGridView_aktuators = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_plcs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_aktuators)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView_plcs
            // 
            this.dataGridView_plcs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_plcs.Location = new System.Drawing.Point(0, 12);
            this.dataGridView_plcs.Name = "dataGridView_plcs";
            this.dataGridView_plcs.Size = new System.Drawing.Size(312, 188);
            this.dataGridView_plcs.TabIndex = 3;
            this.dataGridView_plcs.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_plcs_CellClick);
            // 
            // dataGridView_aktuators
            // 
            this.dataGridView_aktuators.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_aktuators.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dataGridView_aktuators.Location = new System.Drawing.Point(0, 206);
            this.dataGridView_aktuators.Name = "dataGridView_aktuators";
            this.dataGridView_aktuators.Size = new System.Drawing.Size(855, 361);
            this.dataGridView_aktuators.TabIndex = 4;
            // 
            // FrmStartupRunningConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(855, 567);
            this.Controls.Add(this.dataGridView_aktuators);
            this.Controls.Add(this.dataGridView_plcs);
            this.Name = "FrmStartupRunningConfig";
            this.Text = "Startup- Running Config";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_plcs)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_aktuators)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DataGridView dataGridView_plcs;
        private System.Windows.Forms.DataGridView dataGridView_aktuators;
    }
}