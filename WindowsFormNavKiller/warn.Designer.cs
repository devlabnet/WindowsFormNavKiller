﻿namespace WindowsFormNavKiller
{
    partial class warnForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(warnForm));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.warnLabel = new System.Windows.Forms.Label();
            this.ZHPLabel = new System.Windows.Forms.LinkLabel();
            this.ADWLabel = new System.Windows.Forms.LinkLabel();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::WindowsFormNavKiller.Properties.Resources.Warning;
            resources.ApplyResources(this.pictureBox1, "pictureBox1");
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.TabStop = false;
            // 
            // warnLabel
            // 
            resources.ApplyResources(this.warnLabel, "warnLabel");
            this.warnLabel.Name = "warnLabel";
            // 
            // ZHPLabel
            // 
            resources.ApplyResources(this.ZHPLabel, "ZHPLabel");
            this.ZHPLabel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.ZHPLabel.Name = "ZHPLabel";
            this.ZHPLabel.TabStop = true;
            this.ZHPLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.ZHPLabel_LinkClicked);
            // 
            // ADWLabel
            // 
            resources.ApplyResources(this.ADWLabel, "ADWLabel");
            this.ADWLabel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.ADWLabel.Name = "ADWLabel";
            this.ADWLabel.TabStop = true;
            this.ADWLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.ADWLabel_LinkClicked);
            // 
            // warnForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.Controls.Add(this.ADWLabel);
            this.Controls.Add(this.ZHPLabel);
            this.Controls.Add(this.warnLabel);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "warnForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.TopMost = true;
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label warnLabel;
        private System.Windows.Forms.LinkLabel ZHPLabel;
        private System.Windows.Forms.LinkLabel ADWLabel;
    }
}