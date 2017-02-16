namespace cpsLIB
{
    partial class FrmStatusLog
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
            this.dGV_Log = new System.Windows.Forms.DataGridView();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.clearToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.autoScrollToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.freezeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripComboBox1 = new System.Windows.Forms.ToolStripComboBox();
            this.filterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel_filter = new System.Windows.Forms.Panel();
            this.button_hide_filter = new System.Windows.Forms.Button();
            this.cLB_msgType = new System.Windows.Forms.CheckedListBox();
            this.cLB_filter_clients = new System.Windows.Forms.CheckedListBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.footer_TSSL_filtered = new System.Windows.Forms.ToolStripStatusLabel();
            ((System.ComponentModel.ISupportInitialize)(this.dGV_Log)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.panel_filter.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dGV_Log
            // 
            this.dGV_Log.AllowUserToOrderColumns = true;
            this.dGV_Log.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dGV_Log.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dGV_Log.Location = new System.Drawing.Point(0, 27);
            this.dGV_Log.Name = "dGV_Log";
            this.dGV_Log.Size = new System.Drawing.Size(1094, 557);
            this.dGV_Log.TabIndex = 3;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.clearToolStripMenuItem,
            this.showAllToolStripMenuItem,
            this.autoScrollToolStripMenuItem,
            this.freezeToolStripMenuItem,
            this.toolStripComboBox1,
            this.filterToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1094, 27);
            this.menuStrip1.TabIndex = 4;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // clearToolStripMenuItem
            // 
            this.clearToolStripMenuItem.Name = "clearToolStripMenuItem";
            this.clearToolStripMenuItem.Size = new System.Drawing.Size(44, 23);
            this.clearToolStripMenuItem.Text = "clear";
            this.clearToolStripMenuItem.Click += new System.EventHandler(this.clearToolStripMenuItem_Click);
            // 
            // showAllToolStripMenuItem
            // 
            this.showAllToolStripMenuItem.Name = "showAllToolStripMenuItem";
            this.showAllToolStripMenuItem.Size = new System.Drawing.Size(62, 23);
            this.showAllToolStripMenuItem.Text = "show all";
            this.showAllToolStripMenuItem.Click += new System.EventHandler(this.showAllToolStripMenuItem_Click);
            // 
            // autoScrollToolStripMenuItem
            // 
            this.autoScrollToolStripMenuItem.Name = "autoScrollToolStripMenuItem";
            this.autoScrollToolStripMenuItem.Size = new System.Drawing.Size(74, 23);
            this.autoScrollToolStripMenuItem.Text = "auto scroll";
            this.autoScrollToolStripMenuItem.Click += new System.EventHandler(this.autoScrollToolStripMenuItem_Click);
            // 
            // freezeToolStripMenuItem
            // 
            this.freezeToolStripMenuItem.Name = "freezeToolStripMenuItem";
            this.freezeToolStripMenuItem.Size = new System.Drawing.Size(50, 23);
            this.freezeToolStripMenuItem.Text = "freeze";
            this.freezeToolStripMenuItem.Click += new System.EventHandler(this.freezeToolStripMenuItem_Click);
            // 
            // toolStripComboBox1
            // 
            this.toolStripComboBox1.Name = "toolStripComboBox1";
            this.toolStripComboBox1.Size = new System.Drawing.Size(121, 23);
            // 
            // filterToolStripMenuItem
            // 
            this.filterToolStripMenuItem.Name = "filterToolStripMenuItem";
            this.filterToolStripMenuItem.Size = new System.Drawing.Size(43, 23);
            this.filterToolStripMenuItem.Text = "filter";
            this.filterToolStripMenuItem.Click += new System.EventHandler(this.filterToolStripMenuItem_Click);
            // 
            // panel_filter
            // 
            this.panel_filter.BackColor = System.Drawing.Color.Transparent;
            this.panel_filter.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel_filter.Controls.Add(this.button_hide_filter);
            this.panel_filter.Controls.Add(this.cLB_msgType);
            this.panel_filter.Controls.Add(this.cLB_filter_clients);
            this.panel_filter.Location = new System.Drawing.Point(12, 72);
            this.panel_filter.Name = "panel_filter";
            this.panel_filter.Size = new System.Drawing.Size(369, 236);
            this.panel_filter.TabIndex = 5;
            // 
            // button_hide_filter
            // 
            this.button_hide_filter.BackColor = System.Drawing.Color.Tomato;
            this.button_hide_filter.Location = new System.Drawing.Point(341, 3);
            this.button_hide_filter.Name = "button_hide_filter";
            this.button_hide_filter.Size = new System.Drawing.Size(23, 23);
            this.button_hide_filter.TabIndex = 2;
            this.button_hide_filter.Text = "X";
            this.button_hide_filter.UseVisualStyleBackColor = false;
            this.button_hide_filter.Click += new System.EventHandler(this.button_hide_filter_Click);
            // 
            // cLB_msgType
            // 
            this.cLB_msgType.FormattingEnabled = true;
            this.cLB_msgType.Location = new System.Drawing.Point(3, 3);
            this.cLB_msgType.Name = "cLB_msgType";
            this.cLB_msgType.Size = new System.Drawing.Size(137, 109);
            this.cLB_msgType.TabIndex = 1;
            // 
            // cLB_filter_clients
            // 
            this.cLB_filter_clients.FormattingEnabled = true;
            this.cLB_filter_clients.Location = new System.Drawing.Point(146, 3);
            this.cLB_filter_clients.Name = "cLB_filter_clients";
            this.cLB_filter_clients.Size = new System.Drawing.Size(137, 109);
            this.cLB_filter_clients.TabIndex = 0;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.footer_TSSL_filtered});
            this.statusStrip1.Location = new System.Drawing.Point(0, 562);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1094, 22);
            this.statusStrip1.TabIndex = 6;
            this.statusStrip1.Text = "msg filtered: x";
            // 
            // footer_TSSL_filtered
            // 
            this.footer_TSSL_filtered.Name = "footer_TSSL_filtered";
            this.footer_TSSL_filtered.Size = new System.Drawing.Size(81, 17);
            this.footer_TSSL_filtered.Text = "msg filtered: x";
            // 
            // FrmStatusLog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1094, 584);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.panel_filter);
            this.Controls.Add(this.dGV_Log);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FrmStatusLog";
            this.Text = "Status Log";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmStatusLog_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.dGV_Log)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel_filter.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dGV_Log;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem clearToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showAllToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem autoScrollToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem freezeToolStripMenuItem;
        private System.Windows.Forms.ToolStripComboBox toolStripComboBox1;
        private System.Windows.Forms.Panel panel_filter;
        private System.Windows.Forms.CheckedListBox cLB_filter_clients;
        private System.Windows.Forms.CheckedListBox cLB_msgType;
        private System.Windows.Forms.ToolStripMenuItem filterToolStripMenuItem;
        private System.Windows.Forms.Button button_hide_filter;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel footer_TSSL_filtered;
    }
}