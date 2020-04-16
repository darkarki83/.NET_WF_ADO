namespace My_Cloak
{
    partial class Cloak
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
            this.components = new System.ComponentModel.Container();
            this.Start = new System.Windows.Forms.Button();
            this.Stop = new System.Windows.Forms.Button();
            this.OurTime = new System.Windows.Forms.Label();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.choice = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // Start
            // 
            this.Start.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Start.Location = new System.Drawing.Point(24, 38);
            this.Start.Name = "Start";
            this.Start.Size = new System.Drawing.Size(113, 45);
            this.Start.TabIndex = 0;
            this.Start.Text = "Start";
            this.Start.UseVisualStyleBackColor = true;
            this.Start.Click += new System.EventHandler(this.Start_Click);
            // 
            // Stop
            // 
            this.Stop.Enabled = false;
            this.Stop.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Stop.Location = new System.Drawing.Point(208, 38);
            this.Stop.Name = "Stop";
            this.Stop.Size = new System.Drawing.Size(107, 45);
            this.Stop.TabIndex = 1;
            this.Stop.Text = "Stop";
            this.Stop.UseVisualStyleBackColor = true;
            this.Stop.Click += new System.EventHandler(this.Stop_Click);
            // 
            // OurTime
            // 
            this.OurTime.Enabled = false;
            this.OurTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.OurTime.Location = new System.Drawing.Point(149, 115);
            this.OurTime.Name = "OurTime";
            this.OurTime.Size = new System.Drawing.Size(57, 36);
            this.OurTime.TabIndex = 2;
            this.OurTime.Text = "0\r\n";
            this.OurTime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // timer
            // 
            this.timer.Interval = 1000;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // choice
            // 
            this.choice.AutoSize = true;
            this.choice.Checked = true;
            this.choice.CheckState = System.Windows.Forms.CheckState.Checked;
            this.choice.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.choice.Location = new System.Drawing.Point(94, 188);
            this.choice.Name = "choice";
            this.choice.Size = new System.Drawing.Size(163, 24);
            this.choice.TabIndex = 3;
            this.choice.Text = "you want new timer";
            this.choice.UseVisualStyleBackColor = true;
            // 
            // Cloak
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(343, 247);
            this.Controls.Add(this.choice);
            this.Controls.Add(this.OurTime);
            this.Controls.Add(this.Stop);
            this.Controls.Add(this.Start);
            this.MaximizeBox = false;
            this.Name = "Cloak";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "NewTimer";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Start;
        private System.Windows.Forms.Button Stop;
        private System.Windows.Forms.Label OurTime;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.CheckBox choice;
    }
}

