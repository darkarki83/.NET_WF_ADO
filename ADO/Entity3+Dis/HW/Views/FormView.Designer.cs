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
            this.checkAuthor = new System.Windows.Forms.CheckBox();
            this.checkPress = new System.Windows.Forms.CheckBox();
            this.start = new System.Windows.Forms.Button();
            this.comboAuthor = new System.Windows.Forms.ComboBox();
            this.comboPress = new System.Windows.Forms.ComboBox();
            this.listBooks = new System.Windows.Forms.ListView();
            this.columnName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnAuthor = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnPages = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnPrice = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnPress = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // checkAuthor
            // 
            this.checkAuthor.AutoSize = true;
            this.checkAuthor.Location = new System.Drawing.Point(216, 44);
            this.checkAuthor.Name = "checkAuthor";
            this.checkAuthor.Size = new System.Drawing.Size(94, 17);
            this.checkAuthor.TabIndex = 2;
            this.checkAuthor.Text = "Author Search";
            this.checkAuthor.UseVisualStyleBackColor = true;
            this.checkAuthor.CheckedChanged += new System.EventHandler(this.checkAuthor_CheckedChanged);
            // 
            // checkPress
            // 
            this.checkPress.AutoSize = true;
            this.checkPress.Location = new System.Drawing.Point(216, 104);
            this.checkPress.Name = "checkPress";
            this.checkPress.Size = new System.Drawing.Size(89, 17);
            this.checkPress.TabIndex = 3;
            this.checkPress.Text = "Press Search";
            this.checkPress.UseVisualStyleBackColor = true;
            this.checkPress.CheckedChanged += new System.EventHandler(this.checkPublishing_CheckedChanged);
            // 
            // start
            // 
            this.start.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.start.Location = new System.Drawing.Point(406, 66);
            this.start.Name = "start";
            this.start.Size = new System.Drawing.Size(75, 23);
            this.start.TabIndex = 4;
            this.start.Text = "Start Search";
            this.start.UseVisualStyleBackColor = true;
            this.start.Click += new System.EventHandler(this.start_Click);
            // 
            // comboAuthor
            // 
            this.comboAuthor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboAuthor.Enabled = false;
            this.comboAuthor.FormattingEnabled = true;
            this.comboAuthor.Location = new System.Drawing.Point(13, 42);
            this.comboAuthor.Name = "comboAuthor";
            this.comboAuthor.Size = new System.Drawing.Size(166, 21);
            this.comboAuthor.TabIndex = 0;
            // 
            // comboPress
            // 
            this.comboPress.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboPress.Enabled = false;
            this.comboPress.FormattingEnabled = true;
            this.comboPress.Location = new System.Drawing.Point(13, 100);
            this.comboPress.Name = "comboPress";
            this.comboPress.Size = new System.Drawing.Size(166, 21);
            this.comboPress.TabIndex = 1;
            // 
            // listBooks
            // 
            this.listBooks.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listBooks.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnName,
            this.columnAuthor,
            this.columnPages,
            this.columnPrice,
            this.columnPress});
            this.listBooks.HideSelection = false;
            this.listBooks.Location = new System.Drawing.Point(13, 146);
            this.listBooks.Name = "listBooks";
            this.listBooks.Size = new System.Drawing.Size(504, 274);
            this.listBooks.TabIndex = 5;
            this.listBooks.UseCompatibleStateImageBehavior = false;
            this.listBooks.View = System.Windows.Forms.View.Details;
            // 
            // columnName
            // 
            this.columnName.Text = "Name";
            this.columnName.Width = 140;
            // 
            // columnAuthor
            // 
            this.columnAuthor.Text = "Author";
            this.columnAuthor.Width = 140;
            // 
            // columnPages
            // 
            this.columnPages.Text = "Pages";
            this.columnPages.Width = 80;
            // 
            // columnPrice
            // 
            this.columnPrice.Text = "Price";
            this.columnPrice.Width = 70;
            // 
            // columnPress
            // 
            this.columnPress.Text = "Press";
            this.columnPress.Width = 70;
            // 
            // FormView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(533, 450);
            this.Controls.Add(this.listBooks);
            this.Controls.Add(this.comboPress);
            this.Controls.Add(this.comboAuthor);
            this.Controls.Add(this.start);
            this.Controls.Add(this.checkPress);
            this.Controls.Add(this.checkAuthor);
            this.MaximizeBox = false;
            this.Name = "FormView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MyLibrary";
            this.Load += new System.EventHandler(this.FormView_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox checkAuthor;
        private System.Windows.Forms.CheckBox checkPress;
        private System.Windows.Forms.Button start;
        private System.Windows.Forms.ComboBox comboAuthor;
        private System.Windows.Forms.ComboBox comboPress;
        private System.Windows.Forms.ListView listBooks;
        private System.Windows.Forms.ColumnHeader columnName;
        private System.Windows.Forms.ColumnHeader columnAuthor;
        private System.Windows.Forms.ColumnHeader columnPages;
        private System.Windows.Forms.ColumnHeader columnPrice;
        private System.Windows.Forms.ColumnHeader columnPress;
    }
}

