namespace DialogForm
{
    partial class About
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
            this.groupAbout = new System.Windows.Forms.GroupBox();
            this.labelForm = new System.Windows.Forms.Label();
            this.myLabel = new System.Windows.Forms.Label();
            this.linkLabel = new System.Windows.Forms.LinkLabel();
            this.buttonOk = new System.Windows.Forms.Button();
            this.groupAbout.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupAbout
            // 
            this.groupAbout.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupAbout.Controls.Add(this.linkLabel);
            this.groupAbout.Controls.Add(this.myLabel);
            this.groupAbout.Controls.Add(this.labelForm);
            this.groupAbout.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupAbout.Location = new System.Drawing.Point(24, 26);
            this.groupAbout.Name = "groupAbout";
            this.groupAbout.Size = new System.Drawing.Size(362, 181);
            this.groupAbout.TabIndex = 1;
            this.groupAbout.TabStop = false;
            this.groupAbout.Text = "About";
            // 
            // labelForm
            // 
            this.labelForm.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelForm.Location = new System.Drawing.Point(21, 44);
            this.labelForm.Name = "labelForm";
            this.labelForm.Size = new System.Drawing.Size(208, 24);
            this.labelForm.TabIndex = 0;
            this.labelForm.Text = "Super Dialog Form 1.0.0";
            // 
            // myLabel
            // 
            this.myLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.myLabel.Location = new System.Drawing.Point(21, 89);
            this.myLabel.Name = "myLabel";
            this.myLabel.Size = new System.Drawing.Size(208, 24);
            this.myLabel.TabIndex = 1;
            this.myLabel.Text = "Copyright © 2019 by Atriom Krol";
            // 
            // linkLabel
            // 
            this.linkLabel.AutoSize = true;
            this.linkLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.linkLabel.LinkColor = System.Drawing.Color.Red;
            this.linkLabel.Location = new System.Drawing.Point(21, 138);
            this.linkLabel.Name = "linkLabel";
            this.linkLabel.Size = new System.Drawing.Size(164, 17);
            this.linkLabel.TabIndex = 2;
            this.linkLabel.TabStop = true;
            this.linkLabel.Text = "artem_krol@hotmail.com";
            // 
            // buttonOk
            // 
            this.buttonOk.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonOk.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonOk.Location = new System.Drawing.Point(295, 258);
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.Size = new System.Drawing.Size(100, 40);
            this.buttonOk.TabIndex = 0;
            this.buttonOk.Text = "ok";
            this.buttonOk.UseVisualStyleBackColor = true;
            // 
            // About
            // 
            this.AcceptButton = this.buttonOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonOk;
            this.ClientSize = new System.Drawing.Size(415, 313);
            this.Controls.Add(this.buttonOk);
            this.Controls.Add(this.groupAbout);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "About";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "About";
            this.groupAbout.ResumeLayout(false);
            this.groupAbout.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupAbout;
        private System.Windows.Forms.LinkLabel linkLabel;
        private System.Windows.Forms.Label myLabel;
        private System.Windows.Forms.Label labelForm;
        private System.Windows.Forms.Button buttonOk;
    }
}