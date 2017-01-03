namespace AutoHome
{
    partial class UC_SensorValue
    {
        /// <summary> 
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Komponenten-Designer generierter Code

        /// <summary> 
        /// Erforderliche Methode für die Designerunterstützung. 
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.label_sensorName = new System.Windows.Forms.Label();
            this.label_sensorValue = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label_sensorName
            // 
            this.label_sensorName.AutoSize = true;
            this.label_sensorName.Location = new System.Drawing.Point(3, 0);
            this.label_sensorName.Name = "label_sensorName";
            this.label_sensorName.Size = new System.Drawing.Size(68, 13);
            this.label_sensorName.TabIndex = 0;
            this.label_sensorName.Text = "SensorName";
            // 
            // label_sensorValue
            // 
            this.label_sensorValue.AutoSize = true;
            this.label_sensorValue.Location = new System.Drawing.Point(3, 13);
            this.label_sensorValue.Name = "label_sensorValue";
            this.label_sensorValue.Size = new System.Drawing.Size(33, 13);
            this.label_sensorValue.TabIndex = 1;
            this.label_sensorValue.Text = "value";
            // 
            // UC_SensorValue
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.label_sensorValue);
            this.Controls.Add(this.label_sensorName);
            this.Name = "UC_SensorValue";
            this.Size = new System.Drawing.Size(86, 33);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label_sensorName;
        private System.Windows.Forms.Label label_sensorValue;
    }
}
