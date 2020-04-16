namespace Home5._3
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
            this.richText = new System.Windows.Forms.RichTextBox();
            this.quickMenu = new System.Windows.Forms.ToolStrip();
            this.openQuickMenu = new System.Windows.Forms.ToolStripButton();
            this.saveQuickMenu = new System.Windows.Forms.ToolStripButton();
            this.closeQuickMenu = new System.Windows.Forms.ToolStripButton();
            this.copyQuickMenu = new System.Windows.Forms.ToolStripButton();
            this.pasteQuickMenu = new System.Windows.Forms.ToolStripButton();
            this.menu = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.saveMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copyMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cutMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pasteMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cancelMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.colorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fontMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quickMenu.SuspendLayout();
            this.menu.SuspendLayout();
            this.SuspendLayout();
            // 
            // richText
            // 
            this.richText.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.richText.Location = new System.Drawing.Point(14, 65);
            this.richText.Margin = new System.Windows.Forms.Padding(5);
            this.richText.Name = "richText";
            this.richText.Size = new System.Drawing.Size(569, 507);
            this.richText.TabIndex = 2;
            this.richText.Text = "";
            this.richText.TextChanged += new System.EventHandler(this.richText_TextChanged);
            this.richText.MouseDown += new System.Windows.Forms.MouseEventHandler(this.richText_MouseDown);
            // 
            // quickMenu
            // 
            this.quickMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openQuickMenu,
            this.saveQuickMenu,
            this.copyQuickMenu,
            this.pasteQuickMenu,
            this.closeQuickMenu});
            this.quickMenu.Location = new System.Drawing.Point(0, 24);
            this.quickMenu.Name = "quickMenu";
            this.quickMenu.Size = new System.Drawing.Size(597, 25);
            this.quickMenu.TabIndex = 1;
            this.quickMenu.Text = "QuickMenu";
            // 
            // openQuickMenu
            // 
            this.openQuickMenu.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.openQuickMenu.Image = ((System.Drawing.Image)(resources.GetObject("openQuickMenu.Image")));
            this.openQuickMenu.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.openQuickMenu.Name = "openQuickMenu";
            this.openQuickMenu.Size = new System.Drawing.Size(40, 22);
            this.openQuickMenu.Text = "&Open";
            this.openQuickMenu.Click += new System.EventHandler(this.openQuickMenu_Click);
            // 
            // saveQuickMenu
            // 
            this.saveQuickMenu.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.saveQuickMenu.Image = ((System.Drawing.Image)(resources.GetObject("saveQuickMenu.Image")));
            this.saveQuickMenu.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.saveQuickMenu.Name = "saveQuickMenu";
            this.saveQuickMenu.Size = new System.Drawing.Size(35, 22);
            this.saveQuickMenu.Text = "&Save";
            this.saveQuickMenu.Click += new System.EventHandler(this.saveMenuItem_Click);
            // 
            // closeQuickMenu
            // 
            this.closeQuickMenu.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.closeQuickMenu.Image = ((System.Drawing.Image)(resources.GetObject("closeQuickMenu.Image")));
            this.closeQuickMenu.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.closeQuickMenu.Name = "closeQuickMenu";
            this.closeQuickMenu.Size = new System.Drawing.Size(40, 22);
            this.closeQuickMenu.Text = "&Close";
            this.closeQuickMenu.Click += new System.EventHandler(this.closeMenuItem_Click);
            // 
            // copyQuickMenu
            // 
            this.copyQuickMenu.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.copyQuickMenu.Image = ((System.Drawing.Image)(resources.GetObject("copyQuickMenu.Image")));
            this.copyQuickMenu.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.copyQuickMenu.Name = "copyQuickMenu";
            this.copyQuickMenu.Size = new System.Drawing.Size(39, 22);
            this.copyQuickMenu.Text = "Co&py";
            this.copyQuickMenu.Click += new System.EventHandler(this.copyMenuItem_Click);
            // 
            // pasteQuickMenu
            // 
            this.pasteQuickMenu.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.pasteQuickMenu.Image = ((System.Drawing.Image)(resources.GetObject("pasteQuickMenu.Image")));
            this.pasteQuickMenu.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.pasteQuickMenu.Name = "pasteQuickMenu";
            this.pasteQuickMenu.Size = new System.Drawing.Size(39, 22);
            this.pasteQuickMenu.Text = "P&aste";
            this.pasteQuickMenu.Click += new System.EventHandler(this.pasteMenuItem_Click);
            // 
            // menu
            // 
            this.menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem,
            this.optionsMenuItem});
            this.menu.Location = new System.Drawing.Point(0, 0);
            this.menu.Name = "menu";
            this.menu.Padding = new System.Windows.Forms.Padding(11, 2, 0, 2);
            this.menu.Size = new System.Drawing.Size(597, 24);
            this.menu.TabIndex = 0;
            this.menu.Text = "menu";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openMenu,
            this.saveMenuItem,
            this.saveAsMenuItem,
            this.closeMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // openMenu
            // 
            this.openMenu.Name = "openMenu";
            this.openMenu.Size = new System.Drawing.Size(180, 22);
            this.openMenu.Text = "&Open";
            this.openMenu.Click += new System.EventHandler(this.openQuickMenu_Click);
            // 
            // saveMenuItem
            // 
            this.saveMenuItem.Name = "saveMenuItem";
            this.saveMenuItem.Size = new System.Drawing.Size(180, 22);
            this.saveMenuItem.Text = "&Save";
            this.saveMenuItem.Click += new System.EventHandler(this.saveMenuItem_Click);
            // 
            // saveAsMenuItem
            // 
            this.saveAsMenuItem.Name = "saveAsMenuItem";
            this.saveAsMenuItem.Size = new System.Drawing.Size(180, 22);
            this.saveAsMenuItem.Text = "S&ave as";
            this.saveAsMenuItem.Click += new System.EventHandler(this.saveAsMenuItem_Click);
            // 
            // closeMenuItem
            // 
            this.closeMenuItem.Name = "closeMenuItem";
            this.closeMenuItem.Size = new System.Drawing.Size(180, 22);
            this.closeMenuItem.Text = "&Close";
            this.closeMenuItem.Click += new System.EventHandler(this.closeMenuItem_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.copyMenuItem,
            this.cutMenuItem,
            this.pasteMenuItem,
            this.cancelMenuItem});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this.editToolStripMenuItem.Text = "&Edit";
            // 
            // copyMenuItem
            // 
            this.copyMenuItem.Name = "copyMenuItem";
            this.copyMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.C)));
            this.copyMenuItem.Size = new System.Drawing.Size(180, 22);
            this.copyMenuItem.Text = "C&opy";
            this.copyMenuItem.Click += new System.EventHandler(this.copyMenuItem_Click);
            // 
            // cutMenuItem
            // 
            this.cutMenuItem.Name = "cutMenuItem";
            this.cutMenuItem.Size = new System.Drawing.Size(180, 22);
            this.cutMenuItem.Text = "C&ut";
            this.cutMenuItem.Click += new System.EventHandler(this.cutMenuItem_Click);
            // 
            // pasteMenuItem
            // 
            this.pasteMenuItem.Name = "pasteMenuItem";
            this.pasteMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.V)));
            this.pasteMenuItem.Size = new System.Drawing.Size(180, 22);
            this.pasteMenuItem.Text = "&Paste";
            this.pasteMenuItem.Click += new System.EventHandler(this.pasteMenuItem_Click);
            // 
            // cancelMenuItem
            // 
            this.cancelMenuItem.Name = "cancelMenuItem";
            this.cancelMenuItem.Size = new System.Drawing.Size(180, 22);
            this.cancelMenuItem.Text = "Ca&ncel";
            this.cancelMenuItem.Click += new System.EventHandler(this.cancelMenuItem_Click);
            // 
            // optionsMenuItem
            // 
            this.optionsMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.colorToolStripMenuItem,
            this.fontMenuItem});
            this.optionsMenuItem.Name = "optionsMenuItem";
            this.optionsMenuItem.Size = new System.Drawing.Size(61, 20);
            this.optionsMenuItem.Text = "O&ptions";
            // 
            // colorToolStripMenuItem
            // 
            this.colorToolStripMenuItem.Name = "colorToolStripMenuItem";
            this.colorToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.colorToolStripMenuItem.Text = "Co&lor";
            this.colorToolStripMenuItem.Click += new System.EventHandler(this.optionsMenuItem_Click);
            // 
            // fontMenuItem
            // 
            this.fontMenuItem.Name = "fontMenuItem";
            this.fontMenuItem.Size = new System.Drawing.Size(180, 22);
            this.fontMenuItem.Text = "Fo&nt";
            this.fontMenuItem.Click += new System.EventHandler(this.fontMenuItem_Click);
            // 
            // MainForm
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(597, 586);
            this.Controls.Add(this.richText);
            this.Controls.Add(this.quickMenu);
            this.Controls.Add(this.menu);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Rich NoteBook";
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.richText_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.richText_DragEnter);
            this.quickMenu.ResumeLayout(false);
            this.quickMenu.PerformLayout();
            this.menu.ResumeLayout(false);
            this.menu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox richText;
        private System.Windows.Forms.ToolStrip quickMenu;
        private System.Windows.Forms.ToolStripButton openQuickMenu;
        private System.Windows.Forms.ToolStripButton saveQuickMenu;
        private System.Windows.Forms.ToolStripButton closeQuickMenu;
        private System.Windows.Forms.ToolStripButton copyQuickMenu;
        private System.Windows.Forms.ToolStripButton pasteQuickMenu;
        private System.Windows.Forms.MenuStrip menu;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openMenu;
        private System.Windows.Forms.ToolStripMenuItem saveMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAsMenuItem;
        private System.Windows.Forms.ToolStripMenuItem closeMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem copyMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cutMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pasteMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cancelMenuItem;
        private System.Windows.Forms.ToolStripMenuItem optionsMenuItem;
        private System.Windows.Forms.ToolStripMenuItem colorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fontMenuItem;
    }
}

