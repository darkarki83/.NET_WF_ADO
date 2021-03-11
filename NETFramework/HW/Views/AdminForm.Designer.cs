
namespace HW.Views
{
    partial class AdminForm
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
            this.groupBoxPart = new System.Windows.Forms.GroupBox();
            this.numericPartCount = new System.Windows.Forms.NumericUpDown();
            this.comboBoxPartMan = new System.Windows.Forms.ComboBox();
            this.labelPartCount = new System.Windows.Forms.Label();
            this.labelPartMan = new System.Windows.Forms.Label();
            this.textBoxPartCost = new System.Windows.Forms.TextBox();
            this.labelPartCost = new System.Windows.Forms.Label();
            this.textBoxPartName = new System.Windows.Forms.TextBox();
            this.labelPartName = new System.Windows.Forms.Label();
            this.groupBoxManufacturer = new System.Windows.Forms.GroupBox();
            this.textBoxManName = new System.Windows.Forms.TextBox();
            this.labelManName = new System.Windows.Forms.Label();
            this.groupBoxClient = new System.Windows.Forms.GroupBox();
            this.numericBonus = new System.Windows.Forms.NumericUpDown();
            this.textBoxClientAddress = new System.Windows.Forms.TextBox();
            this.textBoxClientName = new System.Windows.Forms.TextBox();
            this.labelClientBonus = new System.Windows.Forms.Label();
            this.labelClientAddress = new System.Windows.Forms.Label();
            this.labelClientName = new System.Windows.Forms.Label();
            this.buttonPart = new System.Windows.Forms.Button();
            this.buttonMan = new System.Windows.Forms.Button();
            this.buttonClient = new System.Windows.Forms.Button();
            this.buttonCount = new System.Windows.Forms.Button();
            this.groupBoxCount = new System.Windows.Forms.GroupBox();
            this.comboBoxPartName = new System.Windows.Forms.ComboBox();
            this.numericCount = new System.Windows.Forms.NumericUpDown();
            this.labelCount = new System.Windows.Forms.Label();
            this.labelCountPart = new System.Windows.Forms.Label();
            this.listViewParts = new System.Windows.Forms.ListView();
            this.id = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.name = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.man = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cost = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.count = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.buttonDelete = new System.Windows.Forms.Button();
            this.buttonClose = new System.Windows.Forms.Button();
            this.groupBoxPart.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericPartCount)).BeginInit();
            this.groupBoxManufacturer.SuspendLayout();
            this.groupBoxClient.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericBonus)).BeginInit();
            this.groupBoxCount.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericCount)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBoxPart
            // 
            this.groupBoxPart.Controls.Add(this.numericPartCount);
            this.groupBoxPart.Controls.Add(this.comboBoxPartMan);
            this.groupBoxPart.Controls.Add(this.labelPartCount);
            this.groupBoxPart.Controls.Add(this.labelPartMan);
            this.groupBoxPart.Controls.Add(this.textBoxPartCost);
            this.groupBoxPart.Controls.Add(this.labelPartCost);
            this.groupBoxPart.Controls.Add(this.textBoxPartName);
            this.groupBoxPart.Controls.Add(this.labelPartName);
            this.groupBoxPart.Location = new System.Drawing.Point(34, 28);
            this.groupBoxPart.Name = "groupBoxPart";
            this.groupBoxPart.Size = new System.Drawing.Size(349, 194);
            this.groupBoxPart.TabIndex = 0;
            this.groupBoxPart.TabStop = false;
            this.groupBoxPart.Text = "Add part";
            // 
            // numericPartCount
            // 
            this.numericPartCount.Location = new System.Drawing.Point(139, 144);
            this.numericPartCount.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numericPartCount.Name = "numericPartCount";
            this.numericPartCount.Size = new System.Drawing.Size(120, 20);
            this.numericPartCount.TabIndex = 7;
            this.numericPartCount.Value = new decimal(new int[] {
            34,
            0,
            0,
            0});
            // 
            // comboBoxPartMan
            // 
            this.comboBoxPartMan.FormattingEnabled = true;
            this.comboBoxPartMan.Location = new System.Drawing.Point(139, 107);
            this.comboBoxPartMan.Name = "comboBoxPartMan";
            this.comboBoxPartMan.Size = new System.Drawing.Size(183, 21);
            this.comboBoxPartMan.TabIndex = 5;
            this.comboBoxPartMan.SelectedIndexChanged += new System.EventHandler(this.textBoxPartName_TextChanged);
            // 
            // labelPartCount
            // 
            this.labelPartCount.AutoSize = true;
            this.labelPartCount.Location = new System.Drawing.Point(46, 151);
            this.labelPartCount.Name = "labelPartCount";
            this.labelPartCount.Size = new System.Drawing.Size(47, 13);
            this.labelPartCount.TabIndex = 6;
            this.labelPartCount.Text = "Count :  ";
            // 
            // labelPartMan
            // 
            this.labelPartMan.AutoSize = true;
            this.labelPartMan.Location = new System.Drawing.Point(46, 107);
            this.labelPartMan.Name = "labelPartMan";
            this.labelPartMan.Size = new System.Drawing.Size(79, 13);
            this.labelPartMan.TabIndex = 4;
            this.labelPartMan.Text = "Manufacturer : ";
            // 
            // textBoxPartCost
            // 
            this.textBoxPartCost.Location = new System.Drawing.Point(139, 68);
            this.textBoxPartCost.Name = "textBoxPartCost";
            this.textBoxPartCost.Size = new System.Drawing.Size(183, 20);
            this.textBoxPartCost.TabIndex = 3;
            this.textBoxPartCost.TextChanged += new System.EventHandler(this.textBoxPartName_TextChanged);
            // 
            // labelPartCost
            // 
            this.labelPartCost.AutoSize = true;
            this.labelPartCost.Location = new System.Drawing.Point(46, 68);
            this.labelPartCost.Name = "labelPartCost";
            this.labelPartCost.Size = new System.Drawing.Size(34, 13);
            this.labelPartCost.TabIndex = 2;
            this.labelPartCost.Text = "Cost :";
            // 
            // textBoxPartName
            // 
            this.textBoxPartName.Location = new System.Drawing.Point(139, 29);
            this.textBoxPartName.Name = "textBoxPartName";
            this.textBoxPartName.Size = new System.Drawing.Size(183, 20);
            this.textBoxPartName.TabIndex = 1;
            this.textBoxPartName.TextChanged += new System.EventHandler(this.textBoxPartName_TextChanged);
            // 
            // labelPartName
            // 
            this.labelPartName.AutoSize = true;
            this.labelPartName.Location = new System.Drawing.Point(46, 29);
            this.labelPartName.Name = "labelPartName";
            this.labelPartName.Size = new System.Drawing.Size(44, 13);
            this.labelPartName.TabIndex = 0;
            this.labelPartName.Text = "Name : ";
            // 
            // groupBoxManufacturer
            // 
            this.groupBoxManufacturer.Controls.Add(this.textBoxManName);
            this.groupBoxManufacturer.Controls.Add(this.labelManName);
            this.groupBoxManufacturer.Location = new System.Drawing.Point(34, 239);
            this.groupBoxManufacturer.Name = "groupBoxManufacturer";
            this.groupBoxManufacturer.Size = new System.Drawing.Size(349, 84);
            this.groupBoxManufacturer.TabIndex = 2;
            this.groupBoxManufacturer.TabStop = false;
            this.groupBoxManufacturer.Text = "Add manufacturer";
            // 
            // textBoxManName
            // 
            this.textBoxManName.Location = new System.Drawing.Point(139, 31);
            this.textBoxManName.Name = "textBoxManName";
            this.textBoxManName.Size = new System.Drawing.Size(183, 20);
            this.textBoxManName.TabIndex = 1;
            this.textBoxManName.TextChanged += new System.EventHandler(this.textBoxManName_TextChanged);
            // 
            // labelManName
            // 
            this.labelManName.AutoSize = true;
            this.labelManName.Location = new System.Drawing.Point(46, 31);
            this.labelManName.Name = "labelManName";
            this.labelManName.Size = new System.Drawing.Size(44, 13);
            this.labelManName.TabIndex = 0;
            this.labelManName.Text = "Name : ";
            // 
            // groupBoxClient
            // 
            this.groupBoxClient.Controls.Add(this.numericBonus);
            this.groupBoxClient.Controls.Add(this.textBoxClientAddress);
            this.groupBoxClient.Controls.Add(this.textBoxClientName);
            this.groupBoxClient.Controls.Add(this.labelClientBonus);
            this.groupBoxClient.Controls.Add(this.labelClientAddress);
            this.groupBoxClient.Controls.Add(this.labelClientName);
            this.groupBoxClient.Location = new System.Drawing.Point(34, 351);
            this.groupBoxClient.Name = "groupBoxClient";
            this.groupBoxClient.Size = new System.Drawing.Size(349, 182);
            this.groupBoxClient.TabIndex = 4;
            this.groupBoxClient.TabStop = false;
            this.groupBoxClient.Text = "Add Client";
            // 
            // numericBonus
            // 
            this.numericBonus.Location = new System.Drawing.Point(139, 129);
            this.numericBonus.Name = "numericBonus";
            this.numericBonus.Size = new System.Drawing.Size(120, 20);
            this.numericBonus.TabIndex = 5;
            this.numericBonus.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            // 
            // textBoxClientAddress
            // 
            this.textBoxClientAddress.Location = new System.Drawing.Point(139, 87);
            this.textBoxClientAddress.Name = "textBoxClientAddress";
            this.textBoxClientAddress.Size = new System.Drawing.Size(183, 20);
            this.textBoxClientAddress.TabIndex = 3;
            this.textBoxClientAddress.TextChanged += new System.EventHandler(this.textBoxClientName_TextChanged);
            // 
            // textBoxClientName
            // 
            this.textBoxClientName.Location = new System.Drawing.Point(139, 30);
            this.textBoxClientName.Name = "textBoxClientName";
            this.textBoxClientName.Size = new System.Drawing.Size(183, 20);
            this.textBoxClientName.TabIndex = 1;
            this.textBoxClientName.TextChanged += new System.EventHandler(this.textBoxClientName_TextChanged);
            // 
            // labelClientBonus
            // 
            this.labelClientBonus.AutoSize = true;
            this.labelClientBonus.Location = new System.Drawing.Point(46, 136);
            this.labelClientBonus.Name = "labelClientBonus";
            this.labelClientBonus.Size = new System.Drawing.Size(46, 13);
            this.labelClientBonus.TabIndex = 4;
            this.labelClientBonus.Text = "Bonus : ";
            // 
            // labelClientAddress
            // 
            this.labelClientAddress.AutoSize = true;
            this.labelClientAddress.Location = new System.Drawing.Point(46, 87);
            this.labelClientAddress.Name = "labelClientAddress";
            this.labelClientAddress.Size = new System.Drawing.Size(54, 13);
            this.labelClientAddress.TabIndex = 2;
            this.labelClientAddress.Text = "Address : ";
            // 
            // labelClientName
            // 
            this.labelClientName.AutoSize = true;
            this.labelClientName.Location = new System.Drawing.Point(46, 38);
            this.labelClientName.Name = "labelClientName";
            this.labelClientName.Size = new System.Drawing.Size(44, 13);
            this.labelClientName.TabIndex = 0;
            this.labelClientName.Text = "Name : ";
            // 
            // buttonPart
            // 
            this.buttonPart.Location = new System.Drawing.Point(416, 176);
            this.buttonPart.Name = "buttonPart";
            this.buttonPart.Size = new System.Drawing.Size(75, 23);
            this.buttonPart.TabIndex = 1;
            this.buttonPart.Text = "Add Part";
            this.buttonPart.UseVisualStyleBackColor = true;
            this.buttonPart.Click += new System.EventHandler(this.buttonPart_Click);
            // 
            // buttonMan
            // 
            this.buttonMan.Location = new System.Drawing.Point(416, 266);
            this.buttonMan.Name = "buttonMan";
            this.buttonMan.Size = new System.Drawing.Size(75, 23);
            this.buttonMan.TabIndex = 3;
            this.buttonMan.Text = "Add Man";
            this.buttonMan.UseVisualStyleBackColor = true;
            this.buttonMan.Click += new System.EventHandler(this.buttonMan_Click);
            // 
            // buttonClient
            // 
            this.buttonClient.Location = new System.Drawing.Point(416, 477);
            this.buttonClient.Name = "buttonClient";
            this.buttonClient.Size = new System.Drawing.Size(75, 23);
            this.buttonClient.TabIndex = 5;
            this.buttonClient.Text = "Add Client";
            this.buttonClient.UseVisualStyleBackColor = true;
            this.buttonClient.Click += new System.EventHandler(this.buttonClient_Click);
            // 
            // buttonCount
            // 
            this.buttonCount.Location = new System.Drawing.Point(416, 632);
            this.buttonCount.Name = "buttonCount";
            this.buttonCount.Size = new System.Drawing.Size(75, 23);
            this.buttonCount.TabIndex = 7;
            this.buttonCount.Text = "Change";
            this.buttonCount.UseVisualStyleBackColor = true;
            this.buttonCount.Click += new System.EventHandler(this.buttonCount_Click);
            // 
            // groupBoxCount
            // 
            this.groupBoxCount.Controls.Add(this.comboBoxPartName);
            this.groupBoxCount.Controls.Add(this.numericCount);
            this.groupBoxCount.Controls.Add(this.labelCount);
            this.groupBoxCount.Controls.Add(this.labelCountPart);
            this.groupBoxCount.Location = new System.Drawing.Point(34, 562);
            this.groupBoxCount.Name = "groupBoxCount";
            this.groupBoxCount.Size = new System.Drawing.Size(349, 114);
            this.groupBoxCount.TabIndex = 6;
            this.groupBoxCount.TabStop = false;
            this.groupBoxCount.Text = "Change Count";
            // 
            // comboBoxPartName
            // 
            this.comboBoxPartName.FormattingEnabled = true;
            this.comboBoxPartName.Location = new System.Drawing.Point(139, 30);
            this.comboBoxPartName.Name = "comboBoxPartName";
            this.comboBoxPartName.Size = new System.Drawing.Size(183, 21);
            this.comboBoxPartName.TabIndex = 8;
            this.comboBoxPartName.SelectedIndexChanged += new System.EventHandler(this.comboBoxPartName_SelectedIndexChanged);
            // 
            // numericCount
            // 
            this.numericCount.Location = new System.Drawing.Point(139, 73);
            this.numericCount.Name = "numericCount";
            this.numericCount.Size = new System.Drawing.Size(120, 20);
            this.numericCount.TabIndex = 3;
            this.numericCount.Value = new decimal(new int[] {
            34,
            0,
            0,
            0});
            // 
            // labelCount
            // 
            this.labelCount.AutoSize = true;
            this.labelCount.Location = new System.Drawing.Point(40, 73);
            this.labelCount.Name = "labelCount";
            this.labelCount.Size = new System.Drawing.Size(44, 13);
            this.labelCount.TabIndex = 2;
            this.labelCount.Text = "Count : ";
            // 
            // labelCountPart
            // 
            this.labelCountPart.AutoSize = true;
            this.labelCountPart.Location = new System.Drawing.Point(40, 38);
            this.labelCountPart.Name = "labelCountPart";
            this.labelCountPart.Size = new System.Drawing.Size(66, 13);
            this.labelCountPart.TabIndex = 0;
            this.labelCountPart.Text = "Part Name : ";
            // 
            // listViewParts
            // 
            this.listViewParts.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.id,
            this.name,
            this.man,
            this.cost,
            this.count});
            this.listViewParts.FullRowSelect = true;
            this.listViewParts.GridLines = true;
            this.listViewParts.HideSelection = false;
            this.listViewParts.Location = new System.Drawing.Point(528, 28);
            this.listViewParts.MultiSelect = false;
            this.listViewParts.Name = "listViewParts";
            this.listViewParts.Size = new System.Drawing.Size(556, 585);
            this.listViewParts.TabIndex = 8;
            this.listViewParts.UseCompatibleStateImageBehavior = false;
            this.listViewParts.View = System.Windows.Forms.View.Details;
            this.listViewParts.SelectedIndexChanged += new System.EventHandler(this.listViewParts_SelectedIndexChanged);
            // 
            // id
            // 
            this.id.Text = "ID";
            this.id.Width = 30;
            // 
            // name
            // 
            this.name.Text = "Name";
            this.name.Width = 290;
            // 
            // man
            // 
            this.man.Text = "Manufacturer";
            this.man.Width = 100;
            // 
            // cost
            // 
            this.cost.Text = "Cost";
            // 
            // count
            // 
            this.count.Text = "Count";
            // 
            // buttonDelete
            // 
            this.buttonDelete.Location = new System.Drawing.Point(953, 632);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(130, 23);
            this.buttonDelete.TabIndex = 9;
            this.buttonDelete.Text = "Delete";
            this.buttonDelete.UseVisualStyleBackColor = true;
            this.buttonDelete.Click += new System.EventHandler(this.buttonDelete_Click);
            // 
            // buttonClose
            // 
            this.buttonClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonClose.Location = new System.Drawing.Point(657, 632);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(130, 23);
            this.buttonClose.TabIndex = 10;
            this.buttonClose.Text = "&Close";
            this.buttonClose.UseVisualStyleBackColor = true;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // AdminForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonClose;
            this.ClientSize = new System.Drawing.Size(1106, 688);
            this.Controls.Add(this.buttonClose);
            this.Controls.Add(this.buttonDelete);
            this.Controls.Add(this.listViewParts);
            this.Controls.Add(this.buttonCount);
            this.Controls.Add(this.groupBoxCount);
            this.Controls.Add(this.buttonClient);
            this.Controls.Add(this.buttonMan);
            this.Controls.Add(this.buttonPart);
            this.Controls.Add(this.groupBoxClient);
            this.Controls.Add(this.groupBoxManufacturer);
            this.Controls.Add(this.groupBoxPart);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AdminForm";
            this.Text = "Admin Panel";
            this.Load += new System.EventHandler(this.AdminForm_Load);
            this.groupBoxPart.ResumeLayout(false);
            this.groupBoxPart.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericPartCount)).EndInit();
            this.groupBoxManufacturer.ResumeLayout(false);
            this.groupBoxManufacturer.PerformLayout();
            this.groupBoxClient.ResumeLayout(false);
            this.groupBoxClient.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericBonus)).EndInit();
            this.groupBoxCount.ResumeLayout(false);
            this.groupBoxCount.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericCount)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxPart;
        private System.Windows.Forms.ComboBox comboBoxPartMan;
        private System.Windows.Forms.Label labelPartCount;
        private System.Windows.Forms.Label labelPartMan;
        private System.Windows.Forms.TextBox textBoxPartCost;
        private System.Windows.Forms.Label labelPartCost;
        private System.Windows.Forms.TextBox textBoxPartName;
        private System.Windows.Forms.Label labelPartName;
        private System.Windows.Forms.GroupBox groupBoxManufacturer;
        private System.Windows.Forms.TextBox textBoxManName;
        private System.Windows.Forms.Label labelManName;
        private System.Windows.Forms.GroupBox groupBoxClient;
        private System.Windows.Forms.Button buttonPart;
        private System.Windows.Forms.Label labelClientBonus;
        private System.Windows.Forms.Label labelClientAddress;
        private System.Windows.Forms.Label labelClientName;
        private System.Windows.Forms.Button buttonMan;
        private System.Windows.Forms.TextBox textBoxClientAddress;
        private System.Windows.Forms.TextBox textBoxClientName;
        private System.Windows.Forms.Button buttonClient;
        private System.Windows.Forms.Button buttonCount;
        private System.Windows.Forms.GroupBox groupBoxCount;
        private System.Windows.Forms.NumericUpDown numericCount;
        private System.Windows.Forms.Label labelCount;
        private System.Windows.Forms.Label labelCountPart;
        private System.Windows.Forms.ListView listViewParts;
        private System.Windows.Forms.Button buttonDelete;
        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.NumericUpDown numericPartCount;
        private System.Windows.Forms.NumericUpDown numericBonus;
        private System.Windows.Forms.ColumnHeader id;
        private System.Windows.Forms.ColumnHeader name;
        private System.Windows.Forms.ColumnHeader man;
        private System.Windows.Forms.ColumnHeader cost;
        private System.Windows.Forms.ColumnHeader count;
        private System.Windows.Forms.ComboBox comboBoxPartName;
    }
}