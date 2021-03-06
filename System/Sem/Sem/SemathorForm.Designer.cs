﻿namespace Sem
{
    partial class SemathorForm
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
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.buttonCreate = new System.Windows.Forms.Button();
            this.NumberPlace = new System.Windows.Forms.Label();
            this.NewThread = new System.Windows.Forms.Label();
            this.WaitThread = new System.Windows.Forms.Label();
            this.WorkThread = new System.Windows.Forms.Label();
            this.listBoxWork = new System.Windows.Forms.ListBox();
            this.listBoxWait = new System.Windows.Forms.ListBox();
            this.listBoxNew = new System.Windows.Forms.ListBox();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.SuspendLayout();
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.numericUpDown1.Location = new System.Drawing.Point(154, 299);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericUpDown1.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(127, 22);
            this.numericUpDown1.TabIndex = 18;
            this.numericUpDown1.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.numericUpDown1.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
            // 
            // buttonCreate
            // 
            this.buttonCreate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonCreate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonCreate.Location = new System.Drawing.Point(431, 287);
            this.buttonCreate.Name = "buttonCreate";
            this.buttonCreate.Size = new System.Drawing.Size(136, 33);
            this.buttonCreate.TabIndex = 17;
            this.buttonCreate.Text = "Create Thread";
            this.buttonCreate.UseVisualStyleBackColor = true;
            this.buttonCreate.Click += new System.EventHandler(this.buttonCreate_Click);
            // 
            // NumberPlace
            // 
            this.NumberPlace.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.NumberPlace.AutoSize = true;
            this.NumberPlace.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.NumberPlace.Location = new System.Drawing.Point(93, 261);
            this.NumberPlace.Name = "NumberPlace";
            this.NumberPlace.Size = new System.Drawing.Size(261, 16);
            this.NumberPlace.TabIndex = 16;
            this.NumberPlace.Text = " Number of places in the semaphore ";
            // 
            // NewThread
            // 
            this.NewThread.AutoSize = true;
            this.NewThread.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.NewThread.Location = new System.Drawing.Point(572, 54);
            this.NewThread.Name = "NewThread";
            this.NewThread.Size = new System.Drawing.Size(100, 16);
            this.NewThread.TabIndex = 12;
            this.NewThread.Text = "New Threads";
            // 
            // WaitThread
            // 
            this.WaitThread.AutoSize = true;
            this.WaitThread.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.WaitThread.Location = new System.Drawing.Point(326, 54);
            this.WaitThread.Name = "WaitThread";
            this.WaitThread.Size = new System.Drawing.Size(101, 16);
            this.WaitThread.TabIndex = 11;
            this.WaitThread.Text = "Wait Threads";
            // 
            // WorkThread
            // 
            this.WorkThread.AutoSize = true;
            this.WorkThread.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.WorkThread.Location = new System.Drawing.Point(62, 54);
            this.WorkThread.Name = "WorkThread";
            this.WorkThread.Size = new System.Drawing.Size(106, 16);
            this.WorkThread.TabIndex = 10;
            this.WorkThread.Text = "Work Threads";
            // 
            // listBoxWork
            // 
            this.listBoxWork.FormattingEnabled = true;
            this.listBoxWork.Location = new System.Drawing.Point(21, 89);
            this.listBoxWork.Name = "listBoxWork";
            this.listBoxWork.Size = new System.Drawing.Size(205, 147);
            this.listBoxWork.TabIndex = 22;
            this.listBoxWork.DoubleClick += new System.EventHandler(this.listBoxWork_DoubleClick);
            // 
            // listBoxWait
            // 
            this.listBoxWait.FormattingEnabled = true;
            this.listBoxWait.Location = new System.Drawing.Point(279, 89);
            this.listBoxWait.Name = "listBoxWait";
            this.listBoxWait.Size = new System.Drawing.Size(205, 147);
            this.listBoxWait.TabIndex = 23;
            // 
            // listBoxNew
            // 
            this.listBoxNew.FormattingEnabled = true;
            this.listBoxNew.Location = new System.Drawing.Point(534, 89);
            this.listBoxNew.Name = "listBoxNew";
            this.listBoxNew.Size = new System.Drawing.Size(205, 147);
            this.listBoxNew.TabIndex = 24;
            this.listBoxNew.DoubleClick += new System.EventHandler(this.listBoxNew_DoubleClick);
            // 
            // SemathorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(760, 373);
            this.Controls.Add(this.listBoxNew);
            this.Controls.Add(this.listBoxWait);
            this.Controls.Add(this.listBoxWork);
            this.Controls.Add(this.numericUpDown1);
            this.Controls.Add(this.buttonCreate);
            this.Controls.Add(this.NumberPlace);
            this.Controls.Add(this.NewThread);
            this.Controls.Add(this.WaitThread);
            this.Controls.Add(this.WorkThread);
            this.Name = "SemathorForm";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Button buttonCreate;
        private System.Windows.Forms.Label NumberPlace;
        private System.Windows.Forms.Label NewThread;
        private System.Windows.Forms.Label WaitThread;
        private System.Windows.Forms.Label WorkThread;
        private System.Windows.Forms.ListBox listBoxWork;
        private System.Windows.Forms.ListBox listBoxWait;
        private System.Windows.Forms.ListBox listBoxNew;
    }
}

