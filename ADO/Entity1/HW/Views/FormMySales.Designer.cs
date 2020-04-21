namespace HW.Views
{
    partial class FormMySales
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
            this.listTable = new System.Windows.Forms.ListView();
            this.comboBox = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // listTable
            // 
            this.listTable.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listTable.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.listTable.HideSelection = false;
            this.listTable.Location = new System.Drawing.Point(12, 89);
            this.listTable.Name = "listTable";
            this.listTable.ShowItemToolTips = true;
            this.listTable.Size = new System.Drawing.Size(545, 340);
            this.listTable.TabIndex = 0;
            this.listTable.UseCompatibleStateImageBehavior = false;
            this.listTable.View = System.Windows.Forms.View.Details;
            // 
            // comboBox
            // 
            this.comboBox.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.comboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox.FormattingEnabled = true;
            this.comboBox.Items.AddRange(new object[] {
            "Buyers",
            "Sellers",
            "Sales"});
            this.comboBox.Location = new System.Drawing.Point(12, 30);
            this.comboBox.Name = "comboBox";
            this.comboBox.Size = new System.Drawing.Size(545, 21);
            this.comboBox.TabIndex = 1;
            this.comboBox.SelectedIndexChanged += new System.EventHandler(this.comboBox_SelectedIndexChanged);
            // 
            // FormMySales
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(569, 441);
            this.Controls.Add(this.comboBox);
            this.Controls.Add(this.listTable);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormMySales";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MySales";
            this.Load += new System.EventHandler(this.FormMySales_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView listTable;
        private System.Windows.Forms.ComboBox comboBox;
    }
}

