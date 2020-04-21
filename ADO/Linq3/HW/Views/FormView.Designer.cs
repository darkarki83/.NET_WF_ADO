namespace HW.Views
{
    partial class FormView
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
            this.listViewForm = new System.Windows.Forms.ListView();
            this.columnFirstName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnLastName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnPhone = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnAdress = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.buttonSortByName = new System.Windows.Forms.Button();
            this.buttonSortByFamily = new System.Windows.Forms.Button();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.buttonEdit = new System.Windows.Forms.Button();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.buttonSortByPhone = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listViewForm
            // 
            this.listViewForm.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnFirstName,
            this.columnLastName,
            this.columnPhone,
            this.columnAdress});
            this.listViewForm.FullRowSelect = true;
            this.listViewForm.GridLines = true;
            this.listViewForm.HideSelection = false;
            this.listViewForm.Location = new System.Drawing.Point(12, 12);
            this.listViewForm.MultiSelect = false;
            this.listViewForm.Name = "listViewForm";
            this.listViewForm.Size = new System.Drawing.Size(524, 426);
            this.listViewForm.TabIndex = 0;
            this.listViewForm.UseCompatibleStateImageBehavior = false;
            this.listViewForm.View = System.Windows.Forms.View.Details;
            this.listViewForm.DoubleClick += new System.EventHandler(this.buttonEdit_Click);
            // 
            // columnFirstName
            // 
            this.columnFirstName.Text = "First Name";
            this.columnFirstName.Width = 120;
            // 
            // columnLastName
            // 
            this.columnLastName.Text = "Last Name";
            this.columnLastName.Width = 120;
            // 
            // columnPhone
            // 
            this.columnPhone.Text = "Phone Number";
            this.columnPhone.Width = 160;
            // 
            // columnAdress
            // 
            this.columnAdress.Text = "Adress";
            this.columnAdress.Width = 120;
            // 
            // buttonSortByName
            // 
            this.buttonSortByName.Location = new System.Drawing.Point(24, 458);
            this.buttonSortByName.Name = "buttonSortByName";
            this.buttonSortByName.Size = new System.Drawing.Size(101, 23);
            this.buttonSortByName.TabIndex = 1;
            this.buttonSortByName.Text = "Sort By Name";
            this.buttonSortByName.UseVisualStyleBackColor = true;
            this.buttonSortByName.Click += new System.EventHandler(this.buttonSortByName_Click);
            // 
            // buttonSortByFamily
            // 
            this.buttonSortByFamily.Location = new System.Drawing.Point(145, 458);
            this.buttonSortByFamily.Name = "buttonSortByFamily";
            this.buttonSortByFamily.Size = new System.Drawing.Size(97, 23);
            this.buttonSortByFamily.TabIndex = 2;
            this.buttonSortByFamily.Text = "Sort By Family";
            this.buttonSortByFamily.UseVisualStyleBackColor = true;
            this.buttonSortByFamily.Click += new System.EventHandler(this.buttonSortByFamily_Click);
            // 
            // buttonAdd
            // 
            this.buttonAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonAdd.Location = new System.Drawing.Point(563, 14);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(75, 23);
            this.buttonAdd.TabIndex = 3;
            this.buttonAdd.Text = "Add";
            this.buttonAdd.UseVisualStyleBackColor = true;
            this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);
            // 
            // buttonEdit
            // 
            this.buttonEdit.Location = new System.Drawing.Point(563, 57);
            this.buttonEdit.Name = "buttonEdit";
            this.buttonEdit.Size = new System.Drawing.Size(75, 23);
            this.buttonEdit.TabIndex = 4;
            this.buttonEdit.Text = "Edit";
            this.buttonEdit.UseVisualStyleBackColor = true;
            this.buttonEdit.Click += new System.EventHandler(this.buttonEdit_Click);
            // 
            // buttonDelete
            // 
            this.buttonDelete.Location = new System.Drawing.Point(563, 104);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(75, 23);
            this.buttonDelete.TabIndex = 5;
            this.buttonDelete.Text = "Delete";
            this.buttonDelete.UseVisualStyleBackColor = true;
            this.buttonDelete.Click += new System.EventHandler(this.buttonDelete_Click);
            // 
            // buttonSortByPhone
            // 
            this.buttonSortByPhone.Location = new System.Drawing.Point(284, 458);
            this.buttonSortByPhone.Name = "buttonSortByPhone";
            this.buttonSortByPhone.Size = new System.Drawing.Size(101, 23);
            this.buttonSortByPhone.TabIndex = 6;
            this.buttonSortByPhone.Text = "Sort By Phone";
            this.buttonSortByPhone.UseVisualStyleBackColor = true;
            this.buttonSortByPhone.Click += new System.EventHandler(this.buttonSortByPhone_Click);
            // 
            // FormView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(658, 493);
            this.Controls.Add(this.buttonSortByPhone);
            this.Controls.Add(this.buttonDelete);
            this.Controls.Add(this.buttonEdit);
            this.Controls.Add(this.buttonAdd);
            this.Controls.Add(this.buttonSortByFamily);
            this.Controls.Add(this.buttonSortByName);
            this.Controls.Add(this.listViewForm);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Phone Book";
            this.Load += new System.EventHandler(this.FormView_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView listViewForm;
        private System.Windows.Forms.ColumnHeader columnFirstName;
        private System.Windows.Forms.ColumnHeader columnLastName;
        private System.Windows.Forms.ColumnHeader columnPhone;
        private System.Windows.Forms.ColumnHeader columnAdress;
        private System.Windows.Forms.Button buttonSortByName;
        private System.Windows.Forms.Button buttonSortByFamily;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.Button buttonEdit;
        private System.Windows.Forms.Button buttonDelete;
        private System.Windows.Forms.Button buttonSortByPhone;
    }
}

