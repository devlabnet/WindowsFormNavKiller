namespace WindowsFormNavKiller
{
    partial class Form1
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.groupChrome = new System.Windows.Forms.GroupBox();
            this.clearChrome = new System.Windows.Forms.CheckBox();
            this.killChrome = new System.Windows.Forms.Button();
            this.groupFireFox = new System.Windows.Forms.GroupBox();
            this.clearFireFox = new System.Windows.Forms.CheckBox();
            this.killFireFox = new System.Windows.Forms.Button();
            this.groupEdge = new System.Windows.Forms.GroupBox();
            this.clearEdge = new System.Windows.Forms.CheckBox();
            this.killEdge = new System.Windows.Forms.Button();
            this.textBox = new System.Windows.Forms.RichTextBox();
            this.recycleBinBox = new System.Windows.Forms.GroupBox();
            this.emptyBin = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.groupChrome.SuspendLayout();
            this.groupFireFox.SuspendLayout();
            this.groupEdge.SuspendLayout();
            this.recycleBinBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox
            // 
            this.pictureBox.BackgroundImage = global::WindowsFormNavKiller.Properties.Resources.Devil;
            this.pictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox.Location = new System.Drawing.Point(12, 12);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(150, 150);
            this.pictureBox.TabIndex = 0;
            this.pictureBox.TabStop = false;
            // 
            // groupChrome
            // 
            this.groupChrome.Controls.Add(this.clearChrome);
            this.groupChrome.Controls.Add(this.killChrome);
            this.groupChrome.Location = new System.Drawing.Point(182, 12);
            this.groupChrome.Name = "groupChrome";
            this.groupChrome.Size = new System.Drawing.Size(208, 46);
            this.groupChrome.TabIndex = 3;
            this.groupChrome.TabStop = false;
            this.groupChrome.Text = "Chrome";
            // 
            // clearChrome
            // 
            this.clearChrome.AutoSize = true;
            this.clearChrome.Checked = true;
            this.clearChrome.CheckState = System.Windows.Forms.CheckState.Checked;
            this.clearChrome.Location = new System.Drawing.Point(18, 19);
            this.clearChrome.Name = "clearChrome";
            this.clearChrome.Size = new System.Drawing.Size(84, 17);
            this.clearChrome.TabIndex = 1;
            this.clearChrome.Text = "Clear Cache";
            this.clearChrome.UseVisualStyleBackColor = true;
            // 
            // killChrome
            // 
            this.killChrome.Location = new System.Drawing.Point(110, 16);
            this.killChrome.Name = "killChrome";
            this.killChrome.Size = new System.Drawing.Size(75, 23);
            this.killChrome.TabIndex = 0;
            this.killChrome.Text = "KILL";
            this.killChrome.UseVisualStyleBackColor = true;
            this.killChrome.Click += new System.EventHandler(this.killChrome_Click);
            // 
            // groupFireFox
            // 
            this.groupFireFox.Controls.Add(this.clearFireFox);
            this.groupFireFox.Controls.Add(this.killFireFox);
            this.groupFireFox.Location = new System.Drawing.Point(182, 64);
            this.groupFireFox.Name = "groupFireFox";
            this.groupFireFox.Size = new System.Drawing.Size(208, 46);
            this.groupFireFox.TabIndex = 4;
            this.groupFireFox.TabStop = false;
            this.groupFireFox.Text = "Firefox";
            // 
            // clearFireFox
            // 
            this.clearFireFox.AutoSize = true;
            this.clearFireFox.Checked = true;
            this.clearFireFox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.clearFireFox.Location = new System.Drawing.Point(18, 19);
            this.clearFireFox.Name = "clearFireFox";
            this.clearFireFox.Size = new System.Drawing.Size(84, 17);
            this.clearFireFox.TabIndex = 1;
            this.clearFireFox.Text = "Clear Cache";
            this.clearFireFox.UseVisualStyleBackColor = true;
            // 
            // killFireFox
            // 
            this.killFireFox.Location = new System.Drawing.Point(110, 16);
            this.killFireFox.Name = "killFireFox";
            this.killFireFox.Size = new System.Drawing.Size(75, 23);
            this.killFireFox.TabIndex = 0;
            this.killFireFox.Text = "KILL";
            this.killFireFox.UseVisualStyleBackColor = true;
            this.killFireFox.Click += new System.EventHandler(this.killFireFox_Click);
            // 
            // groupEdge
            // 
            this.groupEdge.Controls.Add(this.clearEdge);
            this.groupEdge.Controls.Add(this.killEdge);
            this.groupEdge.Location = new System.Drawing.Point(182, 116);
            this.groupEdge.Name = "groupEdge";
            this.groupEdge.Size = new System.Drawing.Size(208, 46);
            this.groupEdge.TabIndex = 4;
            this.groupEdge.TabStop = false;
            this.groupEdge.Text = "Microsoft Edge";
            // 
            // clearEdge
            // 
            this.clearEdge.AutoSize = true;
            this.clearEdge.Checked = true;
            this.clearEdge.CheckState = System.Windows.Forms.CheckState.Checked;
            this.clearEdge.Location = new System.Drawing.Point(18, 19);
            this.clearEdge.Name = "clearEdge";
            this.clearEdge.Size = new System.Drawing.Size(84, 17);
            this.clearEdge.TabIndex = 1;
            this.clearEdge.Text = "Clear Cache";
            this.clearEdge.UseVisualStyleBackColor = true;
            // 
            // killEdge
            // 
            this.killEdge.Location = new System.Drawing.Point(110, 16);
            this.killEdge.Name = "killEdge";
            this.killEdge.Size = new System.Drawing.Size(75, 23);
            this.killEdge.TabIndex = 0;
            this.killEdge.Text = "KILL";
            this.killEdge.UseVisualStyleBackColor = true;
            this.killEdge.Click += new System.EventHandler(this.killEdge_Click);
            // 
            // textBox
            // 
            this.textBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox.Location = new System.Drawing.Point(14, 218);
            this.textBox.Name = "textBox";
            this.textBox.ReadOnly = true;
            this.textBox.Size = new System.Drawing.Size(378, 141);
            this.textBox.TabIndex = 5;
            this.textBox.Text = "";
            this.textBox.DoubleClick += new System.EventHandler(this.textBox_DoubleClick);
            // 
            // recycleBinBox
            // 
            this.recycleBinBox.Controls.Add(this.emptyBin);
            this.recycleBinBox.Location = new System.Drawing.Point(14, 169);
            this.recycleBinBox.Name = "recycleBinBox";
            this.recycleBinBox.Size = new System.Drawing.Size(378, 43);
            this.recycleBinBox.TabIndex = 6;
            this.recycleBinBox.TabStop = false;
            this.recycleBinBox.Text = "Recycle Bin";
            // 
            // emptyBin
            // 
            this.emptyBin.AutoSize = true;
            this.emptyBin.Checked = true;
            this.emptyBin.CheckState = System.Windows.Forms.CheckState.Checked;
            this.emptyBin.Location = new System.Drawing.Point(130, 17);
            this.emptyBin.Name = "emptyBin";
            this.emptyBin.Size = new System.Drawing.Size(118, 17);
            this.emptyBin.TabIndex = 0;
            this.emptyBin.TabStop = false;
            this.emptyBin.Text = "Empty Recycle Box";
            this.emptyBin.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(404, 371);
            this.Controls.Add(this.recycleBinBox);
            this.Controls.Add(this.textBox);
            this.Controls.Add(this.groupEdge);
            this.Controls.Add(this.groupFireFox);
            this.Controls.Add(this.groupChrome);
            this.Controls.Add(this.pictureBox);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Navigator Killer";
            this.TopMost = true;
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.groupChrome.ResumeLayout(false);
            this.groupChrome.PerformLayout();
            this.groupFireFox.ResumeLayout(false);
            this.groupFireFox.PerformLayout();
            this.groupEdge.ResumeLayout(false);
            this.groupEdge.PerformLayout();
            this.recycleBinBox.ResumeLayout(false);
            this.recycleBinBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.GroupBox groupChrome;
        private System.Windows.Forms.CheckBox clearChrome;
        private System.Windows.Forms.Button killChrome;
        private System.Windows.Forms.GroupBox groupFireFox;
        private System.Windows.Forms.CheckBox clearFireFox;
        private System.Windows.Forms.Button killFireFox;
        private System.Windows.Forms.GroupBox groupEdge;
        private System.Windows.Forms.CheckBox clearEdge;
        private System.Windows.Forms.Button killEdge;
        private System.Windows.Forms.RichTextBox textBox;
        private System.Windows.Forms.GroupBox recycleBinBox;
        private System.Windows.Forms.CheckBox emptyBin;
    }
}

