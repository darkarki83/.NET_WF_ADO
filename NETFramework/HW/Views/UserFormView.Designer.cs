﻿
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
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.textBoxAddress = new System.Windows.Forms.TextBox();
            this.buttonConfirm = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.labelCost = new System.Windows.Forms.Label();
            this.labelBonus = new System.Windows.Forms.Label();
            this.labelTotalCost = new System.Windows.Forms.Label();
            this.textBoxCost = new System.Windows.Forms.TextBox();
            this.textBoxBonus = new System.Windows.Forms.TextBox();
            this.textBoxTotalCost = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // listViewOrder
            // 
            this.listViewOrder.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnName,
            this.columnCost,
            this.columnCount,
            this.columnId});
            this.listViewOrder.HideSelection = false;
            this.listViewOrder.Location = new System.Drawing.Point(399, 52);
            this.listViewOrder.Name = "listViewOrder";
            this.listViewOrder.Size = new System.Drawing.Size(389, 219);
            this.listViewOrder.TabIndex = 6;
            this.listViewOrder.UseCompatibleStateImageBehavior = false;
            this.listViewOrder.View = System.Windows.Forms.View.Details;
            // 
            // columnName
            // 
            this.columnName.Text = "Name";
            // 
            // columnCost
            // 
            this.columnCost.Text = "Cost";
            // 
            // columnCount
            // 
            this.columnCount.Text = "Count";
            // 
            // columnId
            // 
            this.columnId.Text = "Id";
            // 
            // labelYourOrder
            // 
            this.labelYourOrder.AutoSize = true;
            this.labelYourOrder.Location = new System.Drawing.Point(399, 13);
            this.labelYourOrder.Name = "labelYourOrder";
            this.labelYourOrder.Size = new System.Drawing.Size(56, 13);
            this.labelYourOrder.TabIndex = 5;
            this.labelYourOrder.Text = "Your order";
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelName.Location = new System.Drawing.Point(32, 42);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(65, 20);
            this.labelName.TabIndex = 0;
            this.labelName.Text = "Name :";
            // 
            // labelAdrress
            // 
            this.labelAdrress.AutoSize = true;
            this.labelAdrress.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelAdrress.Location = new System.Drawing.Point(32, 150);
            this.labelAdrress.Name = "labelAdrress";
            this.labelAdrress.Size = new System.Drawing.Size(85, 20);
            this.labelAdrress.TabIndex = 2;
            this.labelAdrress.Text = "Address :";
            // 
            // textBoxName
            // 
            this.textBoxName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxName.Location = new System.Drawing.Point(36, 83);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(226, 26);
            this.textBoxName.TabIndex = 1;
            this.textBoxName.TextChanged += new System.EventHandler(this.textBoxName_TextChanged);
            // 
            // textBoxAddress
            // 
            this.textBoxAddress.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxAddress.Location = new System.Drawing.Point(36, 189);
            this.textBoxAddress.Name = "textBoxAddress";
            this.textBoxAddress.Size = new System.Drawing.Size(226, 26);
            this.textBoxAddress.TabIndex = 3;
            this.textBoxAddress.TextChanged += new System.EventHandler(this.textBoxName_TextChanged);
            // 
            // buttonConfirm
            // 
            this.buttonConfirm.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonConfirm.Location = new System.Drawing.Point(36, 271);
            this.buttonConfirm.Name = "buttonConfirm";
            this.buttonConfirm.Size = new System.Drawing.Size(109, 59);
            this.buttonConfirm.TabIndex = 4;
            this.buttonConfirm.Text = "Confirm Order";
            this.buttonConfirm.UseVisualStyleBackColor = true;
            this.buttonConfirm.Click += new System.EventHandler(this.buttonConfirm_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonCancel.Location = new System.Drawing.Point(165, 271);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(97, 59);
            this.buttonCancel.TabIndex = 7;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // labelCost
            // 
            this.labelCost.AutoSize = true;
            this.labelCost.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelCost.Location = new System.Drawing.Point(545, 310);
            this.labelCost.Name = "labelCost";
            this.labelCost.Size = new System.Drawing.Size(54, 20);
            this.labelCost.TabIndex = 8;
            this.labelCost.Text = "Cost : ";
            // 
            // labelBonus
            // 
            this.labelBonus.AutoSize = true;
            this.labelBonus.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelBonus.Location = new System.Drawing.Point(545, 355);
            this.labelBonus.Name = "labelBonus";
            this.labelBonus.Size = new System.Drawing.Size(67, 20);
            this.labelBonus.TabIndex = 9;
            this.labelBonus.Text = "Bonus : ";
            // 
            // labelTotalCost
            // 
            this.labelTotalCost.AutoSize = true;
            this.labelTotalCost.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelTotalCost.Location = new System.Drawing.Point(545, 401);
            this.labelTotalCost.Name = "labelTotalCost";
            this.labelTotalCost.Size = new System.Drawing.Size(89, 20);
            this.labelTotalCost.TabIndex = 10;
            this.labelTotalCost.Text = "TotalCost : ";
            // 
            // textBoxCost
            // 
            this.textBoxCost.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxCost.Location = new System.Drawing.Point(658, 310);
            this.textBoxCost.Name = "textBoxCost";
            this.textBoxCost.ReadOnly = true;
            this.textBoxCost.Size = new System.Drawing.Size(130, 26);
            this.textBoxCost.TabIndex = 11;
            // 
            // textBoxBonus
            // 
            this.textBoxBonus.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxBonus.Location = new System.Drawing.Point(658, 355);
            this.textBoxBonus.Name = "textBoxBonus";
            this.textBoxBonus.ReadOnly = true;
            this.textBoxBonus.Size = new System.Drawing.Size(130, 26);
            this.textBoxBonus.TabIndex = 12;
            // 
            // textBoxTotalCost
            // 
            this.textBoxTotalCost.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxTotalCost.Location = new System.Drawing.Point(658, 401);
            this.textBoxTotalCost.Name = "textBoxTotalCost";
            this.textBoxTotalCost.ReadOnly = true;
            this.textBoxTotalCost.Size = new System.Drawing.Size(130, 26);
            this.textBoxTotalCost.TabIndex = 13;
            // 
            // UserFormView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonCancel;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.textBoxTotalCost);
            this.Controls.Add(this.textBoxBonus);
            this.Controls.Add(this.textBoxCost);
            this.Controls.Add(this.labelTotalCost);
            this.Controls.Add(this.labelBonus);
            this.Controls.Add(this.labelCost);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonConfirm);
            this.Controls.Add(this.textBoxAddress);
            this.Controls.Add(this.textBoxName);
            this.Controls.Add(this.labelAdrress);
            this.Controls.Add(this.labelName);
            this.Controls.Add(this.labelYourOrder);
            this.Controls.Add(this.listViewOrder);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.MaximizeBox = false;
            this.Name = "UserFormView";
            this.Text = "UserFormView";
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
        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.TextBox textBoxAddress;
        private System.Windows.Forms.Button buttonConfirm;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Label labelCost;
        private System.Windows.Forms.Label labelBonus;
        private System.Windows.Forms.Label labelTotalCost;
        private System.Windows.Forms.TextBox textBoxCost;
        private System.Windows.Forms.TextBox textBoxBonus;
        private System.Windows.Forms.TextBox textBoxTotalCost;
    }
}