namespace FirstAdo.Views
{
    partial class SalesForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SalesForm));
            this.listViewForm = new System.Windows.Forms.ListView();
            this.columnBuyer = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnSeller = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnAmount = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnDate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // listViewForm
            // 
            this.listViewForm.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.listViewForm.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnBuyer,
            this.columnSeller,
            this.columnAmount,
            this.columnDate});
            this.listViewForm.FullRowSelect = true;
            this.listViewForm.GridLines = true;
            this.listViewForm.HideSelection = false;
            this.listViewForm.Location = new System.Drawing.Point(12, 27);
            this.listViewForm.Name = "listViewForm";
            this.listViewForm.Size = new System.Drawing.Size(535, 385);
            this.listViewForm.TabIndex = 1;
            this.listViewForm.UseCompatibleStateImageBehavior = false;
            this.listViewForm.View = System.Windows.Forms.View.Details;
            // 
            // columnBuyer
            // 
            this.columnBuyer.Text = "Buyer";
            this.columnBuyer.Width = 100;
            // 
            // columnSeller
            // 
            this.columnSeller.Text = "Seller";
            this.columnSeller.Width = 100;
            // 
            // columnAmount
            // 
            this.columnAmount.Text = "Amount";
            this.columnAmount.Width = 150;
            // 
            // columnDate
            // 
            this.columnDate.Text = "Date";
            this.columnDate.Width = 180;
            // 
            // SalesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(572, 424);
            this.Controls.Add(this.listViewForm);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SalesForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sales";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.LibraryForm_FormClosed);
            this.Load += new System.EventHandler(this.LibraryForm_Load);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ListView listViewForm;
        private System.Windows.Forms.ColumnHeader columnBuyer;
        private System.Windows.Forms.ColumnHeader columnSeller;
        private System.Windows.Forms.ColumnHeader columnAmount;
        private System.Windows.Forms.ColumnHeader columnDate;
    }
}

