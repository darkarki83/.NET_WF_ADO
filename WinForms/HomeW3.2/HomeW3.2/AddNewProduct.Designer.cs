namespace HomeW3._2
{
    partial class AddNewProduct
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
            this.allProduct = new System.Windows.Forms.GroupBox();
            this.listName = new System.Windows.Forms.ListBox();
            this.listPrice = new System.Windows.Forms.ListBox();
            this.textPrice = new System.Windows.Forms.TextBox();
            this.add = new System.Windows.Forms.Button();
            this.changeProduct = new System.Windows.Forms.Button();
            this.delete = new System.Windows.Forms.Button();
            this.name = new System.Windows.Forms.Label();
            this.price = new System.Windows.Forms.Label();
            this.textName = new System.Windows.Forms.TextBox();
            this.addToMap = new System.Windows.Forms.Button();
            this.exit = new System.Windows.Forms.Button();
            this.allProduct.SuspendLayout();
            this.SuspendLayout();
            // 
            // allProduct
            // 
            this.allProduct.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.allProduct.Controls.Add(this.listPrice);
            this.allProduct.Controls.Add(this.listName);
            this.allProduct.Location = new System.Drawing.Point(24, 30);
            this.allProduct.Name = "allProduct";
            this.allProduct.Size = new System.Drawing.Size(458, 406);
            this.allProduct.TabIndex = 4;
            this.allProduct.TabStop = false;
            this.allProduct.Text = "All Product";
            // 
            // listName
            // 
            this.listName.FormattingEnabled = true;
            this.listName.Location = new System.Drawing.Point(21, 19);
            this.listName.Name = "listName";
            this.listName.Size = new System.Drawing.Size(188, 368);
            this.listName.TabIndex = 0;
            this.listName.SelectedIndexChanged += new System.EventHandler(this.listName_SelectedIndexChanged);
            // 
            // listPrice
            // 
            this.listPrice.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.listPrice.FormattingEnabled = true;
            this.listPrice.Location = new System.Drawing.Point(254, 19);
            this.listPrice.Name = "listPrice";
            this.listPrice.Size = new System.Drawing.Size(188, 368);
            this.listPrice.TabIndex = 1;
            this.listPrice.SelectedIndexChanged += new System.EventHandler(this.listPrice_SelectedIndexChanged);
            // 
            // textPrice
            // 
            this.textPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textPrice.Location = new System.Drawing.Point(230, 503);
            this.textPrice.Name = "textPrice";
            this.textPrice.Size = new System.Drawing.Size(204, 22);
            this.textPrice.TabIndex = 8;
            this.textPrice.TextChanged += new System.EventHandler(this.textPrice_TextChanged);
            // 
            // add
            // 
            this.add.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.add.Location = new System.Drawing.Point(520, 49);
            this.add.Name = "add";
            this.add.Size = new System.Drawing.Size(110, 28);
            this.add.TabIndex = 0;
            this.add.Text = "Add &new";
            this.add.UseVisualStyleBackColor = true;
            this.add.Click += new System.EventHandler(this.add_Click);
            // 
            // changeProduct
            // 
            this.changeProduct.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.changeProduct.Location = new System.Drawing.Point(520, 105);
            this.changeProduct.Name = "changeProduct";
            this.changeProduct.Size = new System.Drawing.Size(110, 28);
            this.changeProduct.TabIndex = 1;
            this.changeProduct.Text = "&Change";
            this.changeProduct.UseVisualStyleBackColor = true;
            this.changeProduct.Click += new System.EventHandler(this.changeProduct_Click);
            // 
            // delete
            // 
            this.delete.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.delete.Location = new System.Drawing.Point(520, 163);
            this.delete.Name = "delete";
            this.delete.Size = new System.Drawing.Size(110, 28);
            this.delete.TabIndex = 2;
            this.delete.Text = "&Delete";
            this.delete.UseVisualStyleBackColor = true;
            this.delete.Click += new System.EventHandler(this.delete_Click);
            // 
            // name
            // 
            this.name.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.name.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.name.Location = new System.Drawing.Point(42, 460);
            this.name.Name = "name";
            this.name.Size = new System.Drawing.Size(162, 23);
            this.name.TabIndex = 5;
            // 
            // price
            // 
            this.price.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.price.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.price.Location = new System.Drawing.Point(42, 503);
            this.price.Name = "price";
            this.price.Size = new System.Drawing.Size(162, 23);
            this.price.TabIndex = 6;
            // 
            // textName
            // 
            this.textName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textName.Location = new System.Drawing.Point(230, 460);
            this.textName.Name = "textName";
            this.textName.Size = new System.Drawing.Size(204, 22);
            this.textName.TabIndex = 7;
            this.textName.TextChanged += new System.EventHandler(this.textName_TextChanged);
            // 
            // addToMap
            // 
            this.addToMap.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.addToMap.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.addToMap.Location = new System.Drawing.Point(520, 498);
            this.addToMap.Name = "addToMap";
            this.addToMap.Size = new System.Drawing.Size(110, 28);
            this.addToMap.TabIndex = 9;
            this.addToMap.Text = "&Add To Shop";
            this.addToMap.UseVisualStyleBackColor = true;
            this.addToMap.Click += new System.EventHandler(this.addToMap_Click);
            // 
            // exit
            // 
            this.exit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.exit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.exit.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.exit.Location = new System.Drawing.Point(520, 408);
            this.exit.Name = "exit";
            this.exit.Size = new System.Drawing.Size(110, 28);
            this.exit.TabIndex = 3;
            this.exit.Text = "&Exit";
            this.exit.UseVisualStyleBackColor = true;
            this.exit.Click += new System.EventHandler(this.exit_Click);
            // 
            // AddNewProduct
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.exit;
            this.ClientSize = new System.Drawing.Size(655, 564);
            this.Controls.Add(this.exit);
            this.Controls.Add(this.addToMap);
            this.Controls.Add(this.textName);
            this.Controls.Add(this.price);
            this.Controls.Add(this.name);
            this.Controls.Add(this.delete);
            this.Controls.Add(this.changeProduct);
            this.Controls.Add(this.add);
            this.Controls.Add(this.textPrice);
            this.Controls.Add(this.allProduct);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddNewProduct";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AddNewProduct";
            this.Load += new System.EventHandler(this.AddNewProduct_Load);
            this.allProduct.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox allProduct;
        private System.Windows.Forms.ListBox listPrice;
        private System.Windows.Forms.ListBox listName;
        private System.Windows.Forms.TextBox textPrice;
        private System.Windows.Forms.Button add;
        private System.Windows.Forms.Button changeProduct;
        private System.Windows.Forms.Button delete;
        private System.Windows.Forms.Label name;
        private System.Windows.Forms.Label price;
        private System.Windows.Forms.TextBox textName;
        private System.Windows.Forms.Button addToMap;
        private System.Windows.Forms.Button exit;
    }
}