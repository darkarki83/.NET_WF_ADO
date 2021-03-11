
namespace HW.Views
{
    partial class UserFormView
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
            this.listViewOrder = new System.Windows.Forms.ListView();
            this.columnName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnCost = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnCount = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnId = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.labelYourOrder = new System.Windows.Forms.Label();
            this.labelName = new System.Windows.Forms.Label();
            this.labelAdrress = new System.Windows.Forms.Label();
            this.textBoxAddress = new System.Windows.Forms.TextBox();
            this.buttonConfirm = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.labelCost = new System.Windows.Forms.Label();
            this.labelBonus = new System.Windows.Forms.Label();
            this.labelTotalCost = new System.Windows.Forms.Label();
            this.textBoxCost = new System.Windows.Forms.TextBox();
            this.textBoxBonus = new System.Windows.Forms.TextBox();
            this.textBoxTotalCost = new System.Windows.Forms.TextBox();
            this.comboBoxClient = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // listViewOrder
            // 
            this.listViewOrder.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnName,
            this.columnCost,
            this.columnCount,
            this.columnId});
            this.listViewOrder.FullRowSelect = true;
            this.listViewOrder.GridLines = true;
            this.listViewOrder.HideSelection = false;
            this.listViewOrder.Location = new System.Drawing.Point(419, 64);
            this.listViewOrder.Margin = new System.Windows.Forms.Padding(4);
            this.listViewOrder.Name = "listViewOrder";
            this.listViewOrder.Size = new System.Drawing.Size(631, 269);
            this.listViewOrder.TabIndex = 7;
            this.listViewOrder.UseCompatibleStateImageBehavior = false;
            this.listViewOrder.View = System.Windows.Forms.View.Details;
            // 
            // columnName
            // 
            this.columnName.Text = "Name";
            this.columnName.Width = 400;
            // 
            // columnCost
            // 
            this.columnCost.Text = "Cost";
            this.columnCost.Width = 130;
            // 
            // columnCount
            // 
            this.columnCount.Text = "Count";
            this.columnCount.Width = 56;
            // 
            // columnId
            // 
            this.columnId.Text = "Id";
            // 
            // labelYourOrder
            // 
            this.labelYourOrder.AutoSize = true;
            this.labelYourOrder.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelYourOrder.Location = new System.Drawing.Point(414, 27);
            this.labelYourOrder.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelYourOrder.Name = "labelYourOrder";
            this.labelYourOrder.Size = new System.Drawing.Size(84, 20);
            this.labelYourOrder.TabIndex = 6;
            this.labelYourOrder.Text = "Your order";
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelName.Location = new System.Drawing.Point(43, 52);
            this.labelName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(65, 20);
            this.labelName.TabIndex = 0;
            this.labelName.Text = "&Name :";
            // 
            // labelAdrress
            // 
            this.labelAdrress.AutoSize = true;
            this.labelAdrress.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelAdrress.Location = new System.Drawing.Point(43, 185);
            this.labelAdrress.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelAdrress.Name = "labelAdrress";
            this.labelAdrress.Size = new System.Drawing.Size(85, 20);
            this.labelAdrress.TabIndex = 2;
            this.labelAdrress.Text = "&Address :";
            // 
            // textBoxAddress
            // 
            this.textBoxAddress.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxAddress.Location = new System.Drawing.Point(48, 233);
            this.textBoxAddress.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxAddress.Name = "textBoxAddress";
            this.textBoxAddress.Size = new System.Drawing.Size(300, 26);
            this.textBoxAddress.TabIndex = 3;
            this.textBoxAddress.TextChanged += new System.EventHandler(this.textBoxDress_TextChanged);
            // 
            // buttonConfirm
            // 
            this.buttonConfirm.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonConfirm.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonConfirm.Location = new System.Drawing.Point(48, 334);
            this.buttonConfirm.Margin = new System.Windows.Forms.Padding(4);
            this.buttonConfirm.Name = "buttonConfirm";
            this.buttonConfirm.Size = new System.Drawing.Size(146, 73);
            this.buttonConfirm.TabIndex = 4;
            this.buttonConfirm.Text = "Confirm &Order";
            this.buttonConfirm.UseVisualStyleBackColor = true;
            this.buttonConfirm.Click += new System.EventHandler(this.buttonConfirm_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonCancel.Location = new System.Drawing.Point(220, 334);
            this.buttonCancel.Margin = new System.Windows.Forms.Padding(4);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(130, 73);
            this.buttonCancel.TabIndex = 5;
            this.buttonCancel.Text = "&Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // labelCost
            // 
            this.labelCost.AutoSize = true;
            this.labelCost.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelCost.Location = new System.Drawing.Point(727, 382);
            this.labelCost.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelCost.Name = "labelCost";
            this.labelCost.Size = new System.Drawing.Size(54, 20);
            this.labelCost.TabIndex = 8;
            this.labelCost.Text = "Cost : ";
            // 
            // labelBonus
            // 
            this.labelBonus.AutoSize = true;
            this.labelBonus.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelBonus.Location = new System.Drawing.Point(727, 437);
            this.labelBonus.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelBonus.Name = "labelBonus";
            this.labelBonus.Size = new System.Drawing.Size(67, 20);
            this.labelBonus.TabIndex = 9;
            this.labelBonus.Text = "Bonus : ";
            // 
            // labelTotalCost
            // 
            this.labelTotalCost.AutoSize = true;
            this.labelTotalCost.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelTotalCost.Location = new System.Drawing.Point(727, 494);
            this.labelTotalCost.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelTotalCost.Name = "labelTotalCost";
            this.labelTotalCost.Size = new System.Drawing.Size(89, 20);
            this.labelTotalCost.TabIndex = 10;
            this.labelTotalCost.Text = "TotalCost : ";
            // 
            // textBoxCost
            // 
            this.textBoxCost.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxCost.Location = new System.Drawing.Point(877, 382);
            this.textBoxCost.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxCost.Name = "textBoxCost";
            this.textBoxCost.ReadOnly = true;
            this.textBoxCost.Size = new System.Drawing.Size(172, 26);
            this.textBoxCost.TabIndex = 11;
            // 
            // textBoxBonus
            // 
            this.textBoxBonus.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxBonus.Location = new System.Drawing.Point(877, 437);
            this.textBoxBonus.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxBonus.Name = "textBoxBonus";
            this.textBoxBonus.ReadOnly = true;
            this.textBoxBonus.Size = new System.Drawing.Size(172, 26);
            this.textBoxBonus.TabIndex = 12;
            // 
            // textBoxTotalCost
            // 
            this.textBoxTotalCost.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxTotalCost.Location = new System.Drawing.Point(877, 494);
            this.textBoxTotalCost.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxTotalCost.Name = "textBoxTotalCost";
            this.textBoxTotalCost.ReadOnly = true;
            this.textBoxTotalCost.Size = new System.Drawing.Size(172, 26);
            this.textBoxTotalCost.TabIndex = 13;
            // 
            // comboBoxClient
            // 
            this.comboBoxClient.FormattingEnabled = true;
            this.comboBoxClient.Location = new System.Drawing.Point(46, 89);
            this.comboBoxClient.Name = "comboBoxClient";
            this.comboBoxClient.Size = new System.Drawing.Size(302, 24);
            this.comboBoxClient.TabIndex = 1;
            this.comboBoxClient.SelectedIndexChanged += new System.EventHandler(this.comboBoxClient_SelectedIndexChanged);
            // 
            // UserFormView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonCancel;
            this.ClientSize = new System.Drawing.Size(1095, 569);
            this.Controls.Add(this.comboBoxClient);
            this.Controls.Add(this.textBoxTotalCost);
            this.Controls.Add(this.textBoxBonus);
            this.Controls.Add(this.textBoxCost);
            this.Controls.Add(this.labelTotalCost);
            this.Controls.Add(this.labelBonus);
            this.Controls.Add(this.labelCost);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonConfirm);
            this.Controls.Add(this.textBoxAddress);
            this.Controls.Add(this.labelAdrress);
            this.Controls.Add(this.labelName);
            this.Controls.Add(this.labelYourOrder);
            this.Controls.Add(this.listViewOrder);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "UserFormView";
            this.Text = "Order";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView listViewOrder;
        private System.Windows.Forms.Label labelYourOrder;
        private System.Windows.Forms.ColumnHeader columnName;
        private System.Windows.Forms.ColumnHeader columnCost;
        private System.Windows.Forms.ColumnHeader columnCount;
        private System.Windows.Forms.ColumnHeader columnId;
        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.Label labelAdrress;
        private System.Windows.Forms.TextBox textBoxAddress;
        private System.Windows.Forms.Button buttonConfirm;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Label labelCost;
        private System.Windows.Forms.Label labelBonus;
        private System.Windows.Forms.Label labelTotalCost;
        private System.Windows.Forms.TextBox textBoxCost;
        private System.Windows.Forms.TextBox textBoxBonus;
        private System.Windows.Forms.TextBox textBoxTotalCost;
        private System.Windows.Forms.ComboBox comboBoxClient;
    }
}