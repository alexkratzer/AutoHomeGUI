namespace AH_DataLogger
{
    partial class FrmTables
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
            this.comboBox_table = new System.Windows.Forms.ComboBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // comboBox_table
            // 
            this.comboBox_table.FormattingEnabled = true;
            this.comboBox_table.Location = new System.Drawing.Point(12, 12);
            this.comboBox_table.Name = "comboBox_table";
            this.comboBox_table.Size = new System.Drawing.Size(209, 21);
            this.comboBox_table.TabIndex = 13;
            this.comboBox_table.Text = "select table";
            this.comboBox_table.SelectedIndexChanged += new System.EventHandler(this.comboBox_table_SelectedIndexChanged);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(13, 44);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(1103, 677);
            this.dataGridView1.TabIndex = 14;
            // 
            // FrmTables
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1122, 725);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.comboBox_table);
            this.Name = "FrmTables";
            this.Text = "FrmTables";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBox_table;
        private System.Windows.Forms.DataGridView dataGridView1;
    }
}