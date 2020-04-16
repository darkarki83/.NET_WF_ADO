namespace HomeW3._2
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
            this.groupBox = new System.Windows.Forms.GroupBox();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.textPrice = new System.Windows.Forms.TextBox();
            this.price = new System.Windows.Forms.Label();
            this.allItemBox = new System.Windows.Forms.ComboBox();
            this.groupBoxBasket = new System.Windows.Forms.GroupBox();
            this.textBasketPrice = new System.Windows.Forms.TextBox();
            this.priceBasket = new System.Windows.Forms.Label();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.listBasket = new System.Windows.Forms.ListBox();
            this.buttonProduct = new System.Windows.Forms.Button();
            this.groupBox.SuspendLayout();
            this.groupBoxBasket.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox
            // 
            this.groupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox.Controls.Add(this.buttonAdd);
            this.groupBox.Controls.Add(this.textPrice);
            this.groupBox.Controls.Add(this.price);
            this.groupBox.Controls.Add(this.allItemBox);
            this.groupBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox.Location = new System.Drawing.Point(28, 34);
            this.groupBox.Name = "groupBox";
            this.groupBox.Size = new System.Drawing.Size(488, 345);
            this.groupBox.TabIndex = 0;
            this.groupBox.TabStop = false;
            this.groupBox.Text = "All items in the store";
            // 
            // buttonAdd
            // 
            this.buttonAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonAdd.Location = new System.Drawing.Point(351, 28);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(110, 28);
            this.buttonAdd.TabIndex = 1;
            this.buttonAdd.Text = "&Add to Basket";
            this.buttonAdd.UseVisualStyleBackColor = true;
            this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);
            // 
            // textPrice
            // 
            this.textPrice.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.textPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textPrice.Location = new System.Drawing.Point(288, 296);
            this.textPrice.Name = "textPrice";
            this.textPrice.ReadOnly = true;
            this.textPrice.Size = new System.Drawing.Size(179, 26);
            this.textPrice.TabIndex = 3;
            // 
            // price
            // 
            this.price.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.price.AutoSize = true;
            this.price.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.price.Location = new System.Drawing.Point(192, 297);
            this.price.Name = "price";
            this.price.Size = new System.Drawing.Size(44, 20);
            this.price.TabIndex = 2;
            this.price.Text = "Price";
            // 
            // allItemBox
            // 
            this.allItemBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.allItemBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.allItemBox.FormattingEnabled = true;
            this.allItemBox.Items.AddRange(new object[] {
            "auto",
            "doihatsu",
            "subaru"});
            this.allItemBox.Location = new System.Drawing.Point(16, 28);
            this.allItemBox.Name = "allItemBox";
            this.allItemBox.Size = new System.Drawing.Size(297, 28);
            this.allItemBox.TabIndex = 0;
            this.allItemBox.SelectedIndexChanged += new System.EventHandler(this.allItemBox_SelectedIndexChanged);
            // 
            // groupBoxBasket
            // 
            this.groupBoxBasket.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxBasket.Controls.Add(this.textBasketPrice);
            this.groupBoxBasket.Controls.Add(this.priceBasket);
            this.groupBoxBasket.Controls.Add(this.buttonDelete);
            this.groupBoxBasket.Controls.Add(this.listBasket);
            this.groupBoxBasket.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBoxBasket.Location = new System.Drawing.Point(541, 34);
            this.groupBoxBasket.Name = "groupBoxBasket";
            this.groupBoxBasket.Size = new System.Drawing.Size(502, 407);
            this.groupBoxBasket.TabIndex = 1;
            this.groupBoxBasket.TabStop = false;
            this.groupBoxBasket.Text = "yourBasket";
            // 
            // textBasketPrice
            // 
            this.textBasketPrice.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.textBasketPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBasketPrice.Location = new System.Drawing.Point(305, 362);
            this.textBasketPrice.Name = "textBasketPrice";
            this.textBasketPrice.ReadOnly = true;
            this.textBasketPrice.Size = new System.Drawing.Size(179, 26);
            this.textBasketPrice.TabIndex = 3;
            // 
            // priceBasket
            // 
            this.priceBasket.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.priceBasket.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.priceBasket.Location = new System.Drawing.Point(182, 362);
            this.priceBasket.Name = "priceBasket";
            this.priceBasket.Size = new System.Drawing.Size(106, 42);
            this.priceBasket.TabIndex = 2;
            this.priceBasket.Text = "Price Basket";
            // 
            // buttonDelete
            // 
            this.buttonDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonDelete.Location = new System.Drawing.Point(335, 33);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(110, 28);
            this.buttonDelete.TabIndex = 1;
            this.buttonDelete.Text = "&Delete";
            this.buttonDelete.UseVisualStyleBackColor = true;
            this.buttonDelete.Click += new System.EventHandler(this.buttonDelete_Click);
            // 
            // listBasket
            // 
            this.listBasket.FormattingEnabled = true;
            this.listBasket.ItemHeight = 16;
            this.listBasket.Location = new System.Drawing.Point(32, 23);
            this.listBasket.Name = "listBasket";
            this.listBasket.Size = new System.Drawing.Size(247, 308);
            this.listBasket.TabIndex = 0;
            // 
            // buttonProduct
            // 
            this.buttonProduct.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonProduct.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonProduct.Location = new System.Drawing.Point(39, 401);
            this.buttonProduct.Name = "buttonProduct";
            this.buttonProduct.Size = new System.Drawing.Size(110, 28);
            this.buttonProduct.TabIndex = 2;
            this.buttonProduct.Text = "&New Product";
            this.buttonProduct.UseVisualStyleBackColor = true;
            this.buttonProduct.Click += new System.EventHandler(this.buttonProduct_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1065, 470);
            this.Controls.Add(this.buttonProduct);
            this.Controls.Add(this.groupBoxBasket);
            this.Controls.Add(this.groupBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ArtK";
            this.groupBox.ResumeLayout(false);
            this.groupBox.PerformLayout();
            this.groupBoxBasket.ResumeLayout(false);
            this.groupBoxBasket.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox;
        private System.Windows.Forms.GroupBox groupBoxBasket;
        private System.Windows.Forms.ListBox listBasket;
        private System.Windows.Forms.ComboBox allItemBox;
        private System.Windows.Forms.Button buttonProduct;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.TextBox textPrice;
        private System.Windows.Forms.Label price;
        private System.Windows.Forms.TextBox textBasketPrice;
        private System.Windows.Forms.Label priceBasket;
        private System.Windows.Forms.Button buttonDelete;
    }
}

