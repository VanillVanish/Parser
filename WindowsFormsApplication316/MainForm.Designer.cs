namespace Parser
{
    partial class MainForm
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
      this.msMain = new System.Windows.Forms.MenuStrip();
      this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.miNew = new System.Windows.Forms.ToolStripMenuItem();
      this.miOpen = new System.Windows.Forms.ToolStripMenuItem();
      this.toolStripSeparator = new System.Windows.Forms.ToolStripSeparator();
      this.miSave = new System.Windows.Forms.ToolStripMenuItem();
      this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
      this.miExit = new System.Windows.Forms.ToolStripMenuItem();
      this.statusStrip1 = new System.Windows.Forms.StatusStrip();
      this.dgvMain = new System.Windows.Forms.DataGridView();
      this.msMain.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.dgvMain)).BeginInit();
      this.SuspendLayout();
      // 
      // msMain
      // 
      this.msMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
      this.msMain.Location = new System.Drawing.Point(0, 0);
      this.msMain.Name = "msMain";
      this.msMain.Size = new System.Drawing.Size(650, 24);
      this.msMain.TabIndex = 0;
      this.msMain.Text = "menuStrip1";
      // 
      // fileToolStripMenuItem
      // 
      this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miNew,
            this.miOpen,
            this.toolStripSeparator,
            this.miSave,
            this.toolStripSeparator1,
            this.miExit});
      this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
      this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
      this.fileToolStripMenuItem.Text = "&File";
      // 
      // miNew
      // 
      this.miNew.Image = ((System.Drawing.Image)(resources.GetObject("miNew.Image")));
      this.miNew.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.miNew.Name = "miNew";
      this.miNew.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
      this.miNew.Size = new System.Drawing.Size(146, 22);
      this.miNew.Text = "&New";
      this.miNew.Click += new System.EventHandler(this.miNew_Click);
      // 
      // miOpen
      // 
      this.miOpen.Image = ((System.Drawing.Image)(resources.GetObject("miOpen.Image")));
      this.miOpen.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.miOpen.Name = "miOpen";
      this.miOpen.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
      this.miOpen.Size = new System.Drawing.Size(146, 22);
      this.miOpen.Text = "&Open";
      this.miOpen.Click += new System.EventHandler(this.miOpen_Click);
      // 
      // toolStripSeparator
      // 
      this.toolStripSeparator.Name = "toolStripSeparator";
      this.toolStripSeparator.Size = new System.Drawing.Size(143, 6);
      // 
      // miSave
      // 
      this.miSave.Image = ((System.Drawing.Image)(resources.GetObject("miSave.Image")));
      this.miSave.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.miSave.Name = "miSave";
      this.miSave.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
      this.miSave.Size = new System.Drawing.Size(146, 22);
      this.miSave.Text = "&Save";
      this.miSave.Click += new System.EventHandler(this.miSave_Click);
      // 
      // toolStripSeparator1
      // 
      this.toolStripSeparator1.Name = "toolStripSeparator1";
      this.toolStripSeparator1.Size = new System.Drawing.Size(143, 6);
      // 
      // miExit
      // 
      this.miExit.Name = "miExit";
      this.miExit.Size = new System.Drawing.Size(146, 22);
      this.miExit.Text = "E&xit";
      this.miExit.Click += new System.EventHandler(this.miExit_Click);
      // 
      // statusStrip1
      // 
      this.statusStrip1.Location = new System.Drawing.Point(0, 368);
      this.statusStrip1.Name = "statusStrip1";
      this.statusStrip1.Size = new System.Drawing.Size(650, 22);
      this.statusStrip1.TabIndex = 2;
      this.statusStrip1.Text = "statusStrip1";
      // 
      // dgvMain
      // 
      this.dgvMain.AllowUserToAddRows = false;
      this.dgvMain.AllowUserToDeleteRows = false;
      this.dgvMain.BackgroundColor = System.Drawing.Color.White;
      this.dgvMain.ColumnHeadersHeight = 20;
      this.dgvMain.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
      this.dgvMain.Dock = System.Windows.Forms.DockStyle.Fill;
      this.dgvMain.Location = new System.Drawing.Point(0, 24);
      this.dgvMain.Name = "dgvMain";
      this.dgvMain.RowHeadersWidth = 70;
      this.dgvMain.Size = new System.Drawing.Size(650, 344);
      this.dgvMain.TabIndex = 3;
      this.dgvMain.VirtualMode = true;
      this.dgvMain.CellValueNeeded += new System.Windows.Forms.DataGridViewCellValueEventHandler(this.dgvMain_CellValueNeeded);
      this.dgvMain.CellValuePushed += new System.Windows.Forms.DataGridViewCellValueEventHandler(this.dgvMain_CellValuePushed);
      // 
      // MainForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(650, 390);
      this.Controls.Add(this.dgvMain);
      this.Controls.Add(this.statusStrip1);
      this.Controls.Add(this.msMain);
      this.MainMenuStrip = this.msMain;
      this.Name = "MainForm";
      this.Text = "Calc";
      this.Load += new System.EventHandler(this.MainForm_Load);
      this.msMain.ResumeLayout(false);
      this.msMain.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.dgvMain)).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip msMain;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem miNew;
        private System.Windows.Forms.ToolStripMenuItem miOpen;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator;
        private System.Windows.Forms.ToolStripMenuItem miSave;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem miExit;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.DataGridView dgvMain;
    }
}

