namespace HW.Views
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
            this.addButton = new System.Windows.Forms.Button();
            this.listViewParts = new System.Windows.Forms.ListView();
            this.id = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.name = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.manufacture = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cost = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.count = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.deleteButton = new System.Windows.Forms.Button();
            this.listViewCart = new System.Windows.Forms.ListView();
            this.namePart = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.costPart = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.countPart = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.idPart = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label = new System.Windows.Forms.Label();
            this.labelTotalCost = new System.Windows.Forms.Label();
            this.labelDol = new System.Windows.Forms.Label();
            this.buttonOrder = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.addToCartToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addToCartToolStripMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteFromCartToolStripMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.toOrderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveOrderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuExit = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cpoyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pasteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.adminPanelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loginToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.registrationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.orderPanelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.logInToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.myOrderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButtonAdd = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonDelete = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonCopy = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonOrder = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonExit = new System.Windows.Forms.ToolStripButton();
            this.menuStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // addButton
            // 
            this.addButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.addButton.Location = new System.Drawing.Point(731, 64);
            this.addButton.Margin = new System.Windows.Forms.Padding(5);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(125, 42);
            this.addButton.TabIndex = 3;
            this.addButton.Text = "Add to cart";
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Click += new System.EventHandler(this.AddButton_Click);
            // 
            // listViewParts
            // 
            this.listViewParts.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.id,
            this.name,
            this.manufacture,
            this.cost,
            this.count});
            this.listViewParts.FullRowSelect = true;
            this.listViewParts.GridLines = true;
            this.listViewParts.HideSelection = false;
            this.listViewParts.Location = new System.Drawing.Point(21, 64);
            this.listViewParts.MultiSelect = false;
            this.listViewParts.Name = "listViewParts";
            this.listViewParts.Size = new System.Drawing.Size(692, 486);
            this.listViewParts.TabIndex = 2;
            this.listViewParts.UseCompatibleStateImageBehavior = false;
            this.listViewParts.View = System.Windows.Forms.View.Details;
            this.listViewParts.SelectedIndexChanged += new System.EventHandler(this.listViewParts_SelectedIndexChanged);
            this.listViewParts.DoubleClick += new System.EventHandler(this.AddButton_Click);
            // 
            // id
            // 
            this.id.Text = "ID";
            this.id.Width = 40;
            // 
            // name
            // 
            this.name.Text = "Name";
            this.name.Width = 326;
            // 
            // manufacture
            // 
            this.manufacture.Text = "Manufacture";
            this.manufacture.Width = 130;
            // 
            // cost
            // 
            this.cost.Text = "Cost";
            this.cost.Width = 110;
            // 
            // count
            // 
            this.count.Text = "Count";
            this.count.Width = 80;
            // 
            // deleteButton
            // 
            this.deleteButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.deleteButton.Location = new System.Drawing.Point(731, 133);
            this.deleteButton.Margin = new System.Windows.Forms.Padding(5);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(125, 42);
            this.deleteButton.TabIndex = 4;
            this.deleteButton.Text = "Delete from cart";
            this.deleteButton.UseVisualStyleBackColor = true;
            this.deleteButton.Click += new System.EventHandler(this.DeleteButton_Click);
            // 
            // listViewCart
            // 
            this.listViewCart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.listViewCart.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.namePart,
            this.costPart,
            this.countPart,
            this.idPart});
            this.listViewCart.FullRowSelect = true;
            this.listViewCart.GridLines = true;
            this.listViewCart.HideSelection = false;
            this.listViewCart.Location = new System.Drawing.Point(875, 64);
            this.listViewCart.Name = "listViewCart";
            this.listViewCart.Size = new System.Drawing.Size(627, 381);
            this.listViewCart.TabIndex = 6;
            this.listViewCart.UseCompatibleStateImageBehavior = false;
            this.listViewCart.View = System.Windows.Forms.View.Details;
            this.listViewCart.SelectedIndexChanged += new System.EventHandler(this.listViewCart_SelectedIndexChanged);
            this.listViewCart.DoubleClick += new System.EventHandler(this.DeleteButton_Click);
            // 
            // namePart
            // 
            this.namePart.Text = "Name";
            this.namePart.Width = 350;
            // 
            // costPart
            // 
            this.costPart.Text = "Cost";
            this.costPart.Width = 100;
            // 
            // countPart
            // 
            this.countPart.Text = "Count";
            // 
            // idPart
            // 
            this.idPart.Text = "ID";
            this.idPart.Width = 110;
            // 
            // label
            // 
            this.label.AutoSize = true;
            this.label.Location = new System.Drawing.Point(1232, 470);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(98, 20);
            this.label.TabIndex = 7;
            this.label.Text = "Total cost :";
            // 
            // labelTotalCost
            // 
            this.labelTotalCost.AutoSize = true;
            this.labelTotalCost.Location = new System.Drawing.Point(1395, 470);
            this.labelTotalCost.Name = "labelTotalCost";
            this.labelTotalCost.Size = new System.Drawing.Size(19, 20);
            this.labelTotalCost.TabIndex = 8;
            this.labelTotalCost.Text = "0";
            // 
            // labelDol
            // 
            this.labelDol.AutoSize = true;
            this.labelDol.Location = new System.Drawing.Point(1483, 470);
            this.labelDol.Name = "labelDol";
            this.labelDol.Size = new System.Drawing.Size(19, 20);
            this.labelDol.TabIndex = 9;
            this.labelDol.Text = "$";
            // 
            // buttonOrder
            // 
            this.buttonOrder.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonOrder.Location = new System.Drawing.Point(1377, 532);
            this.buttonOrder.Margin = new System.Windows.Forms.Padding(5);
            this.buttonOrder.Name = "buttonOrder";
            this.buttonOrder.Size = new System.Drawing.Size(125, 42);
            this.buttonOrder.TabIndex = 5;
            this.buttonOrder.Text = "To order";
            this.buttonOrder.UseVisualStyleBackColor = true;
            this.buttonOrder.Click += new System.EventHandler(this.buttonOrder_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addToCartToolStripMenuItem,
            this.editToolStripMenuItem,
            this.adminPanelToolStripMenuItem,
            this.orderPanelToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1543, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // addToCartToolStripMenuItem
            // 
            this.addToCartToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addToCartToolStripMenu,
            this.deleteFromCartToolStripMenu,
            this.toOrderToolStripMenuItem,
            this.saveOrderToolStripMenuItem,
            this.exitToolStripMenuExit});
            this.addToCartToolStripMenuItem.Name = "addToCartToolStripMenuItem";
            this.addToCartToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.B)));
            this.addToCartToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.addToCartToolStripMenuItem.Text = "&File";
            // 
            // addToCartToolStripMenu
            // 
            this.addToCartToolStripMenu.Name = "addToCartToolStripMenu";
            this.addToCartToolStripMenu.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.A)));
            this.addToCartToolStripMenu.Size = new System.Drawing.Size(201, 22);
            this.addToCartToolStripMenu.Text = "&Add to cart";
            this.addToCartToolStripMenu.Click += new System.EventHandler(this.AddButton_Click);
            // 
            // deleteFromCartToolStripMenu
            // 
            this.deleteFromCartToolStripMenu.Name = "deleteFromCartToolStripMenu";
            this.deleteFromCartToolStripMenu.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D)));
            this.deleteFromCartToolStripMenu.Size = new System.Drawing.Size(201, 22);
            this.deleteFromCartToolStripMenu.Text = "&Delete from cart";
            this.deleteFromCartToolStripMenu.Click += new System.EventHandler(this.DeleteButton_Click);
            // 
            // toOrderToolStripMenuItem
            // 
            this.toOrderToolStripMenuItem.Name = "toOrderToolStripMenuItem";
            this.toOrderToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Alt) 
            | System.Windows.Forms.Keys.A)));
            this.toOrderToolStripMenuItem.Size = new System.Drawing.Size(201, 22);
            this.toOrderToolStripMenuItem.Text = "&To order";
            // 
            // saveOrderToolStripMenuItem
            // 
            this.saveOrderToolStripMenuItem.Name = "saveOrderToolStripMenuItem";
            this.saveOrderToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Alt) 
            | System.Windows.Forms.Keys.D)));
            this.saveOrderToolStripMenuItem.Size = new System.Drawing.Size(201, 22);
            this.saveOrderToolStripMenuItem.Text = "&Save order";
            // 
            // exitToolStripMenuExit
            // 
            this.exitToolStripMenuExit.Name = "exitToolStripMenuExit";
            this.exitToolStripMenuExit.Size = new System.Drawing.Size(201, 22);
            this.exitToolStripMenuExit.Text = "&Exit";
            this.exitToolStripMenuExit.Click += new System.EventHandler(this.Exit);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cpoyToolStripMenuItem,
            this.cutToolStripMenuItem,
            this.pasteToolStripMenuItem});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this.editToolStripMenuItem.Text = "&Edit";
            // 
            // cpoyToolStripMenuItem
            // 
            this.cpoyToolStripMenuItem.Name = "cpoyToolStripMenuItem";
            this.cpoyToolStripMenuItem.Size = new System.Drawing.Size(102, 22);
            this.cpoyToolStripMenuItem.Text = "&Copy";
            // 
            // cutToolStripMenuItem
            // 
            this.cutToolStripMenuItem.Name = "cutToolStripMenuItem";
            this.cutToolStripMenuItem.Size = new System.Drawing.Size(102, 22);
            this.cutToolStripMenuItem.Text = "C&ut";
            // 
            // pasteToolStripMenuItem
            // 
            this.pasteToolStripMenuItem.Name = "pasteToolStripMenuItem";
            this.pasteToolStripMenuItem.Size = new System.Drawing.Size(102, 22);
            this.pasteToolStripMenuItem.Text = "&Paste";
            // 
            // adminPanelToolStripMenuItem
            // 
            this.adminPanelToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loginToolStripMenuItem,
            this.registrationToolStripMenuItem});
            this.adminPanelToolStripMenuItem.Name = "adminPanelToolStripMenuItem";
            this.adminPanelToolStripMenuItem.Size = new System.Drawing.Size(87, 20);
            this.adminPanelToolStripMenuItem.Text = "&Admin panel";
            // 
            // loginToolStripMenuItem
            // 
            this.loginToolStripMenuItem.Name = "loginToolStripMenuItem";
            this.loginToolStripMenuItem.Size = new System.Drawing.Size(137, 22);
            this.loginToolStripMenuItem.Text = "&Log in";
            // 
            // registrationToolStripMenuItem
            // 
            this.registrationToolStripMenuItem.Name = "registrationToolStripMenuItem";
            this.registrationToolStripMenuItem.Size = new System.Drawing.Size(137, 22);
            this.registrationToolStripMenuItem.Text = "&Registration";
            // 
            // orderPanelToolStripMenuItem
            // 
            this.orderPanelToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.logInToolStripMenuItem1,
            this.myOrderToolStripMenuItem});
            this.orderPanelToolStripMenuItem.Name = "orderPanelToolStripMenuItem";
            this.orderPanelToolStripMenuItem.Size = new System.Drawing.Size(81, 20);
            this.orderPanelToolStripMenuItem.Text = "Order panel";
            // 
            // logInToolStripMenuItem1
            // 
            this.logInToolStripMenuItem1.Name = "logInToolStripMenuItem1";
            this.logInToolStripMenuItem1.Size = new System.Drawing.Size(122, 22);
            this.logInToolStripMenuItem1.Text = "&Log in";
            // 
            // myOrderToolStripMenuItem
            // 
            this.myOrderToolStripMenuItem.Name = "myOrderToolStripMenuItem";
            this.myOrderToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
            this.myOrderToolStripMenuItem.Text = "&My order";
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButtonAdd,
            this.toolStripButtonDelete,
            this.toolStripButtonCopy,
            this.toolStripButtonOrder,
            this.toolStripButtonExit});
            this.toolStrip1.Location = new System.Drawing.Point(0, 24);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1543, 25);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButtonAdd
            // 
            this.toolStripButtonAdd.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButtonAdd.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonAdd.Image")));
            this.toolStripButtonAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonAdd.Name = "toolStripButtonAdd";
            this.toolStripButtonAdd.Size = new System.Drawing.Size(70, 22);
            this.toolStripButtonAdd.Text = "Add &to cart";
            this.toolStripButtonAdd.Click += new System.EventHandler(this.AddButton_Click);
            // 
            // toolStripButtonDelete
            // 
            this.toolStripButtonDelete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButtonDelete.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonDelete.Image")));
            this.toolStripButtonDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonDelete.Name = "toolStripButtonDelete";
            this.toolStripButtonDelete.Size = new System.Drawing.Size(96, 22);
            this.toolStripButtonDelete.Text = "&Delete from cart";
            this.toolStripButtonDelete.Click += new System.EventHandler(this.DeleteButton_Click);
            // 
            // toolStripButtonCopy
            // 
            this.toolStripButtonCopy.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButtonCopy.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonCopy.Image")));
            this.toolStripButtonCopy.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonCopy.Name = "toolStripButtonCopy";
            this.toolStripButtonCopy.Size = new System.Drawing.Size(39, 22);
            this.toolStripButtonCopy.Text = "&Copy";
            // 
            // toolStripButtonOrder
            // 
            this.toolStripButtonOrder.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButtonOrder.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonOrder.Image")));
            this.toolStripButtonOrder.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonOrder.Name = "toolStripButtonOrder";
            this.toolStripButtonOrder.Size = new System.Drawing.Size(54, 22);
            this.toolStripButtonOrder.Text = "To &order";
            // 
            // toolStripButtonExit
            // 
            this.toolStripButtonExit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButtonExit.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonExit.Image")));
            this.toolStripButtonExit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonExit.Name = "toolStripButtonExit";
            this.toolStripButtonExit.Size = new System.Drawing.Size(30, 22);
            this.toolStripButtonExit.Text = "&Exit";
            this.toolStripButtonExit.Click += new System.EventHandler(this.Exit);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1543, 588);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.buttonOrder);
            this.Controls.Add(this.labelDol);
            this.Controls.Add(this.labelTotalCost);
            this.Controls.Add(this.label);
            this.Controls.Add(this.listViewCart);
            this.Controls.Add(this.deleteButton);
            this.Controls.Add(this.listViewParts);
            this.Controls.Add(this.addButton);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(5);
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.ListView listViewParts;
        private System.Windows.Forms.ColumnHeader id;
        private System.Windows.Forms.ColumnHeader name;
        private System.Windows.Forms.ColumnHeader manufacture;
        private System.Windows.Forms.ColumnHeader cost;
        private System.Windows.Forms.Button deleteButton;
        private System.Windows.Forms.ListView listViewCart;
        private System.Windows.Forms.ColumnHeader namePart;
        private System.Windows.Forms.ColumnHeader costPart;
        private System.Windows.Forms.ColumnHeader countPart;
        private System.Windows.Forms.Label label;
        private System.Windows.Forms.Label labelTotalCost;
        private System.Windows.Forms.Label labelDol;
        private System.Windows.Forms.ColumnHeader idPart;
        private System.Windows.Forms.Button buttonOrder;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem addToCartToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addToCartToolStripMenu;
        private System.Windows.Forms.ToolStripMenuItem deleteFromCartToolStripMenu;
        private System.Windows.Forms.ToolStripMenuItem toOrderToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveOrderToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuExit;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cpoyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pasteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem adminPanelToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loginToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem registrationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem orderPanelToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem logInToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem myOrderToolStripMenuItem;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButtonAdd;
        private System.Windows.Forms.ToolStripButton toolStripButtonDelete;
        private System.Windows.Forms.ToolStripButton toolStripButtonOrder;
        private System.Windows.Forms.ToolStripButton toolStripButtonCopy;
        private System.Windows.Forms.ToolStripButton toolStripButtonExit;
        private System.Windows.Forms.ColumnHeader count;
    }
}

