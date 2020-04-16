namespace SomeNumber
{
    partial class Games
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
            this.mylabel = new System.Windows.Forms.Label();
            this.Start = new System.Windows.Forms.Button();
            this.againLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // mylabel
            // 
            this.mylabel.AutoSize = true;
            this.mylabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.mylabel.Location = new System.Drawing.Point(74, 38);
            this.mylabel.Name = "mylabel";
            this.mylabel.Size = new System.Drawing.Size(0, 23);
            this.mylabel.TabIndex = 0;
            this.mylabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.mylabel.UseCompatibleTextRendering = true;
            // 
            // Start
            // 
            this.Start.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Start.Location = new System.Drawing.Point(115, 112);
            this.Start.Name = "Start";
            this.Start.Size = new System.Drawing.Size(146, 32);
            this.Start.TabIndex = 1;
            this.Start.Text = "StartGame";
            this.Start.UseVisualStyleBackColor = true;
            this.Start.Click += new System.EventHandler(this.Quation_Click);
            // 
            // againLabel
            // 
            this.againLabel.AutoSize = true;
            this.againLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.againLabel.Location = new System.Drawing.Point(74, 63);
            this.againLabel.Name = "againLabel";
            this.againLabel.Size = new System.Drawing.Size(0, 20);
            this.againLabel.TabIndex = 2;
            this.againLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // Games
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(392, 219);
            this.Controls.Add(this.againLabel);
            this.Controls.Add(this.Start);
            this.Controls.Add(this.mylabel);
            this.MaximizeBox = false;
            this.Name = "Games";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Game";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label mylabel;
        private System.Windows.Forms.Button Start;
        private System.Windows.Forms.Label againLabel;
    }
}

