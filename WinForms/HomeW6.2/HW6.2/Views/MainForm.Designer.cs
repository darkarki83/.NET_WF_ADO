namespace HW6._2
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
            this.menu = new System.Windows.Forms.MenuStrip();
            this.menuItemFile = new System.Windows.Forms.ToolStripMenuItem();
            this.newTool = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsTool = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemFigure = new System.Windows.Forms.ToolStripMenuItem();
            this.pointTool = new System.Windows.Forms.ToolStripMenuItem();
            this.lineTool = new System.Windows.Forms.ToolStripMenuItem();
            this.circleTool = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteTool = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemColor = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemColorRed = new System.Windows.Forms.ToolStripMenuItem();
            this.tool = new System.Windows.Forms.ToolStrip();
            this.toolPoint = new System.Windows.Forms.ToolStripButton();
            this.toolLine = new System.Windows.Forms.ToolStripButton();
            this.toolCircle = new System.Windows.Forms.ToolStripButton();
            this.toolDelete = new System.Windows.Forms.ToolStripButton();
            this.toolDiameter = new System.Windows.Forms.ToolStripButton();
            this.menu.SuspendLayout();
            this.tool.SuspendLayout();
            this.SuspendLayout();
            // 
            // menu
            // 
            this.menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemFile,
            this.menuItemFigure,
            this.menuItemColor});
            this.menu.Location = new System.Drawing.Point(0, 0);
            this.menu.Name = "menu";
            this.menu.Size = new System.Drawing.Size(524, 24);
            this.menu.TabIndex = 0;
            this.menu.Text = "menuStrip1";
            // 
            // menuItemFile
            // 
            this.menuItemFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newTool,
            this.saveAsTool});
            this.menuItemFile.Name = "menuItemFile";
            this.menuItemFile.Size = new System.Drawing.Size(37, 20);
            this.menuItemFile.Text = "&File";
            // 
            // newTool
            // 
            this.newTool.Name = "newTool";
            this.newTool.Size = new System.Drawing.Size(112, 22);
            this.newTool.Text = "&New";
            this.newTool.Click += new System.EventHandler(this.newTool_Click);
            // 
            // saveAsTool
            // 
            this.saveAsTool.Name = "saveAsTool";
            this.saveAsTool.Size = new System.Drawing.Size(180, 22);
            this.saveAsTool.Text = "&Save as";
            this.saveAsTool.Click += new System.EventHandler(this.saveAsTool_Click);
            // 
            // menuItemFigure
            // 
            this.menuItemFigure.CheckOnClick = true;
            this.menuItemFigure.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pointTool,
            this.lineTool,
            this.circleTool,
            this.deleteTool});
            this.menuItemFigure.Name = "menuItemFigure";
            this.menuItemFigure.Size = new System.Drawing.Size(52, 20);
            this.menuItemFigure.Text = "F&igure";
            // 
            // pointTool
            // 
            this.pointTool.Name = "pointTool";
            this.pointTool.Size = new System.Drawing.Size(180, 22);
            this.pointTool.Text = "&Point";
            this.pointTool.Click += new System.EventHandler(this.toolPoint_Click);
            // 
            // lineTool
            // 
            this.lineTool.Name = "lineTool";
            this.lineTool.Size = new System.Drawing.Size(180, 22);
            this.lineTool.Text = "&Line";
            this.lineTool.Click += new System.EventHandler(this.toolLine_Click);
            // 
            // circleTool
            // 
            this.circleTool.Name = "circleTool";
            this.circleTool.Size = new System.Drawing.Size(180, 22);
            this.circleTool.Text = "Ci&rcle";
            this.circleTool.Click += new System.EventHandler(this.toolCircle_Click);
            // 
            // deleteTool
            // 
            this.deleteTool.Name = "deleteTool";
            this.deleteTool.Size = new System.Drawing.Size(180, 22);
            this.deleteTool.Text = "&Delete";
            this.deleteTool.Click += new System.EventHandler(this.toolDelete_Click);
            // 
            // menuItemColor
            // 
            this.menuItemColor.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemColorRed});
            this.menuItemColor.Name = "menuItemColor";
            this.menuItemColor.Size = new System.Drawing.Size(48, 20);
            this.menuItemColor.Text = "&Color";
            // 
            // menuItemColorRed
            // 
            this.menuItemColorRed.Name = "menuItemColorRed";
            this.menuItemColorRed.Size = new System.Drawing.Size(180, 22);
            this.menuItemColorRed.Text = "C&hange Color";
            this.menuItemColorRed.Click += new System.EventHandler(this.menuItemColor_Click);
            // 
            // tool
            // 
            this.tool.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolPoint,
            this.toolLine,
            this.toolCircle,
            this.toolDelete,
            this.toolDiameter});
            this.tool.Location = new System.Drawing.Point(0, 24);
            this.tool.Name = "tool";
            this.tool.Size = new System.Drawing.Size(524, 25);
            this.tool.TabIndex = 1;
            this.tool.Text = "toolStrip1";
            // 
            // toolPoint
            // 
            this.toolPoint.CheckOnClick = true;
            this.toolPoint.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolPoint.Image = ((System.Drawing.Image)(resources.GetObject("toolPoint.Image")));
            this.toolPoint.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolPoint.Name = "toolPoint";
            this.toolPoint.Size = new System.Drawing.Size(39, 22);
            this.toolPoint.Text = "&Point";
            this.toolPoint.ToolTipText = "Point";
            this.toolPoint.Click += new System.EventHandler(this.toolPoint_Click);
            // 
            // toolLine
            // 
            this.toolLine.CheckOnClick = true;
            this.toolLine.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolLine.Image = ((System.Drawing.Image)(resources.GetObject("toolLine.Image")));
            this.toolLine.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolLine.Name = "toolLine";
            this.toolLine.Size = new System.Drawing.Size(33, 22);
            this.toolLine.Text = "&Line";
            this.toolLine.Click += new System.EventHandler(this.toolLine_Click);
            // 
            // toolCircle
            // 
            this.toolCircle.CheckOnClick = true;
            this.toolCircle.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolCircle.Image = ((System.Drawing.Image)(resources.GetObject("toolCircle.Image")));
            this.toolCircle.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolCircle.Name = "toolCircle";
            this.toolCircle.Size = new System.Drawing.Size(41, 22);
            this.toolCircle.Text = "Ci&rcle";
            this.toolCircle.Click += new System.EventHandler(this.toolCircle_Click);
            // 
            // toolDelete
            // 
            this.toolDelete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolDelete.Image = ((System.Drawing.Image)(resources.GetObject("toolDelete.Image")));
            this.toolDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolDelete.Name = "toolDelete";
            this.toolDelete.Size = new System.Drawing.Size(44, 22);
            this.toolDelete.Text = "&Delete";
            this.toolDelete.Click += new System.EventHandler(this.toolDelete_Click);
            // 
            // toolDiameter
            // 
            this.toolDiameter.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolDiameter.Enabled = false;
            this.toolDiameter.Image = ((System.Drawing.Image)(resources.GetObject("toolDiameter.Image")));
            this.toolDiameter.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolDiameter.Name = "toolDiameter";
            this.toolDiameter.Size = new System.Drawing.Size(62, 22);
            this.toolDiameter.Text = "&Deameter";
            this.toolDiameter.Click += new System.EventHandler(this.toolDiameter_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(524, 397);
            this.Controls.Add(this.tool);
            this.Controls.Add(this.menu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MainMenuStrip = this.menu;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Draw";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.MainForm_Paint);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.MainForm_MouseClick);
            this.menu.ResumeLayout(false);
            this.menu.PerformLayout();
            this.tool.ResumeLayout(false);
            this.tool.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menu;
        private System.Windows.Forms.ToolStripMenuItem menuItemFile;
        private System.Windows.Forms.ToolStripMenuItem newTool;
        private System.Windows.Forms.ToolStripMenuItem saveAsTool;
        private System.Windows.Forms.ToolStripMenuItem menuItemFigure;
        private System.Windows.Forms.ToolStripMenuItem pointTool;
        private System.Windows.Forms.ToolStripMenuItem lineTool;
        private System.Windows.Forms.ToolStrip tool;
        private System.Windows.Forms.ToolStripButton toolPoint;
        private System.Windows.Forms.ToolStripButton toolLine;
        private System.Windows.Forms.ToolStripMenuItem menuItemColor;
        private System.Windows.Forms.ToolStripMenuItem menuItemColorRed;
        private System.Windows.Forms.ToolStripMenuItem circleTool;
        private System.Windows.Forms.ToolStripMenuItem deleteTool;
        private System.Windows.Forms.ToolStripButton toolCircle;
        private System.Windows.Forms.ToolStripButton toolDelete;
        private System.Windows.Forms.ToolStripButton toolDiameter;
    }
}

