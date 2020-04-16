namespace HomeW22
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
            this.GroupBox = new System.Windows.Forms.GroupBox();
            this.checkFamale = new System.Windows.Forms.CheckBox();
            this.checkMale = new System.Windows.Forms.CheckBox();
            this.dateTime = new System.Windows.Forms.DateTimePicker();
            this.textBox7 = new System.Windows.Forms.TextBox();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.TextBox = new System.Windows.Forms.GroupBox();
            this.listBox = new System.Windows.Forms.ListBox();
            this.comboBox = new System.Windows.Forms.ComboBox();
            this.GroupBox.SuspendLayout();
            this.TextBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // GroupBox
            // 
            this.GroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GroupBox.Controls.Add(this.comboBox);
            this.GroupBox.Controls.Add(this.checkFamale);
            this.GroupBox.Controls.Add(this.checkMale);
            this.GroupBox.Controls.Add(this.dateTime);
            this.GroupBox.Controls.Add(this.textBox7);
            this.GroupBox.Controls.Add(this.textBox6);
            this.GroupBox.Controls.Add(this.textBox2);
            this.GroupBox.Controls.Add(this.textBox1);
            this.GroupBox.Controls.Add(this.label7);
            this.GroupBox.Controls.Add(this.label6);
            this.GroupBox.Controls.Add(this.label5);
            this.GroupBox.Controls.Add(this.label4);
            this.GroupBox.Controls.Add(this.label3);
            this.GroupBox.Controls.Add(this.label2);
            this.GroupBox.Controls.Add(this.label1);
            this.GroupBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.GroupBox.Location = new System.Drawing.Point(23, 25);
            this.GroupBox.Name = "GroupBox";
            this.GroupBox.Size = new System.Drawing.Size(360, 397);
            this.GroupBox.TabIndex = 1;
            this.GroupBox.TabStop = false;
            this.GroupBox.Text = "Fill resume";
            // 
            // checkFamale
            // 
            this.checkFamale.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.checkFamale.Location = new System.Drawing.Point(247, 187);
            this.checkFamale.Name = "checkFamale";
            this.checkFamale.Size = new System.Drawing.Size(80, 17);
            this.checkFamale.TabIndex = 4;
            this.checkFamale.Tag = "7";
            this.checkFamale.Text = "Famale";
            this.checkFamale.UseVisualStyleBackColor = true;
            this.checkFamale.CheckedChanged += new System.EventHandler(this.checkFamale_CheckedChanged);
            // 
            // checkMale
            // 
            this.checkMale.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.checkMale.Location = new System.Drawing.Point(134, 187);
            this.checkMale.Name = "checkMale";
            this.checkMale.Size = new System.Drawing.Size(80, 17);
            this.checkMale.TabIndex = 3;
            this.checkMale.Tag = "7";
            this.checkMale.Text = "Male";
            this.checkMale.UseVisualStyleBackColor = true;
            this.checkMale.CheckedChanged += new System.EventHandler(this.checkMale_CheckedChanged);
            // 
            // dateTime
            // 
            this.dateTime.Location = new System.Drawing.Point(134, 135);
            this.dateTime.Name = "dateTime";
            this.dateTime.Size = new System.Drawing.Size(206, 26);
            this.dateTime.TabIndex = 2;
            this.dateTime.Tag = "5";
            this.dateTime.ValueChanged += new System.EventHandler(this.dateTime_ValueChanged);
            // 
            // textBox7
            // 
            this.textBox7.Location = new System.Drawing.Point(134, 343);
            this.textBox7.Name = "textBox7";
            this.textBox7.Size = new System.Drawing.Size(206, 26);
            this.textBox7.TabIndex = 7;
            this.textBox7.Tag = "13";
            this.textBox7.TextChanged += new System.EventHandler(this.textBox7_TextChanged_1);
            // 
            // textBox6
            // 
            this.textBox6.Location = new System.Drawing.Point(134, 291);
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new System.Drawing.Size(206, 26);
            this.textBox6.TabIndex = 6;
            this.textBox6.Tag = "11";
            this.textBox6.TextChanged += new System.EventHandler(this.textBox7_TextChanged_1);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(134, 83);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(206, 26);
            this.textBox2.TabIndex = 1;
            this.textBox2.Tag = "3";
            this.textBox2.TextChanged += new System.EventHandler(this.textBox7_TextChanged_1);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(134, 32);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(206, 26);
            this.textBox1.TabIndex = 0;
            this.textBox1.Tag = "1";
            this.textBox1.TextChanged += new System.EventHandler(this.textBox7_TextChanged_1);
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(19, 343);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(100, 27);
            this.label7.TabIndex = 14;
            this.label7.Text = "&Subject :";
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(19, 291);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(100, 27);
            this.label6.TabIndex = 13;
            this.label6.Text = "&Education :";
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(19, 239);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(100, 27);
            this.label5.TabIndex = 12;
            this.label5.Text = "&Telephon :";
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(19, 187);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(100, 27);
            this.label4.TabIndex = 11;
            this.label4.Text = "&Gender";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(19, 135);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 27);
            this.label3.TabIndex = 10;
            this.label3.Text = "&Birth :";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(19, 83);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 27);
            this.label2.TabIndex = 9;
            this.label2.Text = "F&amily :";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(19, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 27);
            this.label1.TabIndex = 8;
            this.label1.Text = "&Name :";
            // 
            // TextBox
            // 
            this.TextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TextBox.Controls.Add(this.listBox);
            this.TextBox.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.TextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.TextBox.Location = new System.Drawing.Point(406, 27);
            this.TextBox.Name = "TextBox";
            this.TextBox.Size = new System.Drawing.Size(351, 395);
            this.TextBox.TabIndex = 0;
            this.TextBox.TabStop = false;
            // 
            // listBox
            // 
            this.listBox.FormattingEnabled = true;
            this.listBox.ItemHeight = 20;
            this.listBox.Location = new System.Drawing.Point(18, 27);
            this.listBox.Name = "listBox";
            this.listBox.SelectionMode = System.Windows.Forms.SelectionMode.None;
            this.listBox.Size = new System.Drawing.Size(309, 344);
            this.listBox.TabIndex = 0;
            // 
            // comboBox
            // 
            this.comboBox.FormatString = "+972547285882";
            this.comboBox.FormattingEnabled = true;
            this.comboBox.Location = new System.Drawing.Point(134, 239);
            this.comboBox.Name = "comboBox";
            this.comboBox.Size = new System.Drawing.Size(206, 28);
            this.comboBox.TabIndex = 15;
            this.comboBox.Tag = "9";
            this.comboBox.TextChanged += new System.EventHandler(this.comboBox_TextChanged);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(769, 447);
            this.Controls.Add(this.TextBox);
            this.Controls.Add(this.GroupBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Your resume";
            this.GroupBox.ResumeLayout(false);
            this.GroupBox.PerformLayout();
            this.TextBox.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox GroupBox;
        private System.Windows.Forms.GroupBox TextBox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox7;
        private System.Windows.Forms.TextBox textBox6;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.ListBox listBox;
        private System.Windows.Forms.DateTimePicker dateTime;
        private System.Windows.Forms.CheckBox checkFamale;
        private System.Windows.Forms.CheckBox checkMale;
        private System.Windows.Forms.ComboBox comboBox;
    }
}

