namespace Two_Date
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
            this.dateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.OurLabel = new System.Windows.Forms.Label();
            this.group = new System.Windows.Forms.GroupBox();
            this.fiveRadio = new System.Windows.Forms.RadioButton();
            this.fourRadio = new System.Windows.Forms.RadioButton();
            this.thertRadio = new System.Windows.Forms.RadioButton();
            this.secondRadio = new System.Windows.Forms.RadioButton();
            this.firstRadio = new System.Windows.Forms.RadioButton();
            this.Until = new System.Windows.Forms.Label();
            this.group.SuspendLayout();
            this.SuspendLayout();
            // 
            // dateTimePicker
            // 
            this.dateTimePicker.Location = new System.Drawing.Point(12, 12);
            this.dateTimePicker.MinDate = new System.DateTime(2019, 12, 20, 0, 0, 0, 0);
            this.dateTimePicker.Name = "dateTimePicker";
            this.dateTimePicker.Size = new System.Drawing.Size(200, 20);
            this.dateTimePicker.TabIndex = 5;
            this.dateTimePicker.Value = new System.DateTime(2019, 12, 20, 0, 0, 0, 0);
            this.dateTimePicker.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
            // 
            // OurLabel
            // 
            this.OurLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.OurLabel.Location = new System.Drawing.Point(12, 61);
            this.OurLabel.Name = "OurLabel";
            this.OurLabel.Size = new System.Drawing.Size(244, 23);
            this.OurLabel.TabIndex = 6;
            this.OurLabel.Text = "Choice Date";
            // 
            // group
            // 
            this.group.Controls.Add(this.fiveRadio);
            this.group.Controls.Add(this.fourRadio);
            this.group.Controls.Add(this.thertRadio);
            this.group.Controls.Add(this.secondRadio);
            this.group.Controls.Add(this.firstRadio);
            this.group.Location = new System.Drawing.Point(16, 104);
            this.group.Name = "group";
            this.group.Size = new System.Drawing.Size(240, 211);
            this.group.TabIndex = 0;
            this.group.TabStop = false;
            this.group.Text = "Choice";
            // 
            // fiveRadio
            // 
            this.fiveRadio.AutoSize = true;
            this.fiveRadio.Location = new System.Drawing.Point(19, 168);
            this.fiveRadio.Name = "fiveRadio";
            this.fiveRadio.Size = new System.Drawing.Size(67, 17);
            this.fiveRadio.TabIndex = 4;
            this.fiveRadio.Tag = "5";
            this.fiveRadio.Text = "Seconds";
            this.fiveRadio.UseVisualStyleBackColor = true;
            this.fiveRadio.CheckedChanged += new System.EventHandler(this.firstRadio_CheckedChanged_1);
            // 
            // fourRadio
            // 
            this.fourRadio.AutoSize = true;
            this.fourRadio.Location = new System.Drawing.Point(19, 133);
            this.fourRadio.Name = "fourRadio";
            this.fourRadio.Size = new System.Drawing.Size(56, 17);
            this.fourRadio.TabIndex = 3;
            this.fourRadio.Tag = "4";
            this.fourRadio.Text = "Minuts";
            this.fourRadio.UseVisualStyleBackColor = true;
            this.fourRadio.CheckedChanged += new System.EventHandler(this.firstRadio_CheckedChanged_1);
            // 
            // thertRadio
            // 
            this.thertRadio.AutoSize = true;
            this.thertRadio.Location = new System.Drawing.Point(19, 98);
            this.thertRadio.Name = "thertRadio";
            this.thertRadio.Size = new System.Drawing.Size(49, 17);
            this.thertRadio.TabIndex = 2;
            this.thertRadio.Tag = "3";
            this.thertRadio.Text = "Days";
            this.thertRadio.UseVisualStyleBackColor = true;
            this.thertRadio.CheckedChanged += new System.EventHandler(this.firstRadio_CheckedChanged_1);
            // 
            // secondRadio
            // 
            this.secondRadio.AutoSize = true;
            this.secondRadio.Location = new System.Drawing.Point(19, 63);
            this.secondRadio.Name = "secondRadio";
            this.secondRadio.Size = new System.Drawing.Size(55, 17);
            this.secondRadio.TabIndex = 1;
            this.secondRadio.Tag = "2";
            this.secondRadio.Text = "Month";
            this.secondRadio.UseVisualStyleBackColor = true;
            this.secondRadio.CheckedChanged += new System.EventHandler(this.firstRadio_CheckedChanged_1);
            // 
            // firstRadio
            // 
            this.firstRadio.AutoSize = true;
            this.firstRadio.Checked = true;
            this.firstRadio.Location = new System.Drawing.Point(19, 28);
            this.firstRadio.Name = "firstRadio";
            this.firstRadio.Size = new System.Drawing.Size(52, 17);
            this.firstRadio.TabIndex = 0;
            this.firstRadio.TabStop = true;
            this.firstRadio.Tag = "1";
            this.firstRadio.Text = "Years";
            this.firstRadio.UseVisualStyleBackColor = true;
            this.firstRadio.CheckedChanged += new System.EventHandler(this.firstRadio_CheckedChanged_1);
            // 
            // Until
            // 
            this.Until.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Until.Location = new System.Drawing.Point(12, 38);
            this.Until.Name = "Until";
            this.Until.Size = new System.Drawing.Size(151, 23);
            this.Until.TabIndex = 4;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(268, 327);
            this.Controls.Add(this.Until);
            this.Controls.Add(this.group);
            this.Controls.Add(this.OurLabel);
            this.Controls.Add(this.dateTimePicker);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Between two dates";
            this.group.ResumeLayout(false);
            this.group.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dateTimePicker;
        private System.Windows.Forms.Label OurLabel;
        private System.Windows.Forms.GroupBox group;
        private System.Windows.Forms.RadioButton fiveRadio;
        private System.Windows.Forms.RadioButton fourRadio;
        private System.Windows.Forms.RadioButton thertRadio;
        private System.Windows.Forms.RadioButton secondRadio;
        private System.Windows.Forms.RadioButton firstRadio;
        private System.Windows.Forms.Label Until;
    }
}

