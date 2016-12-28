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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
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
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.groupChrome.SuspendLayout();
            this.groupFireFox.SuspendLayout();
            this.groupEdge.SuspendLayout();
            this.recycleBinBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // groupChrome
            // 
            this.groupChrome.Controls.Add(this.clearChrome);
            this.groupChrome.Controls.Add(this.killChrome);
            resources.ApplyResources(this.groupChrome, "groupChrome");
            this.groupChrome.Name = "groupChrome";
            this.groupChrome.TabStop = false;
            // 
            // clearChrome
            // 
            resources.ApplyResources(this.clearChrome, "clearChrome");
            this.clearChrome.Checked = true;
            this.clearChrome.CheckState = System.Windows.Forms.CheckState.Checked;
            this.clearChrome.Name = "clearChrome";
            this.clearChrome.UseVisualStyleBackColor = true;
            // 
            // killChrome
            // 
            resources.ApplyResources(this.killChrome, "killChrome");
            this.killChrome.Name = "killChrome";
            this.killChrome.UseVisualStyleBackColor = true;
            this.killChrome.Click += new System.EventHandler(this.killChrome_Click);
            // 
            // groupFireFox
            // 
            this.groupFireFox.Controls.Add(this.clearFireFox);
            this.groupFireFox.Controls.Add(this.killFireFox);
            resources.ApplyResources(this.groupFireFox, "groupFireFox");
            this.groupFireFox.Name = "groupFireFox";
            this.groupFireFox.TabStop = false;
            // 
            // clearFireFox
            // 
            resources.ApplyResources(this.clearFireFox, "clearFireFox");
            this.clearFireFox.Checked = true;
            this.clearFireFox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.clearFireFox.Name = "clearFireFox";
            this.clearFireFox.UseVisualStyleBackColor = true;
            // 
            // killFireFox
            // 
            resources.ApplyResources(this.killFireFox, "killFireFox");
            this.killFireFox.Name = "killFireFox";
            this.killFireFox.UseVisualStyleBackColor = true;
            this.killFireFox.Click += new System.EventHandler(this.killFireFox_Click);
            // 
            // groupEdge
            // 
            this.groupEdge.Controls.Add(this.clearEdge);
            this.groupEdge.Controls.Add(this.killEdge);
            resources.ApplyResources(this.groupEdge, "groupEdge");
            this.groupEdge.Name = "groupEdge";
            this.groupEdge.TabStop = false;
            // 
            // clearEdge
            // 
            resources.ApplyResources(this.clearEdge, "clearEdge");
            this.clearEdge.Checked = true;
            this.clearEdge.CheckState = System.Windows.Forms.CheckState.Checked;
            this.clearEdge.Name = "clearEdge";
            this.clearEdge.UseVisualStyleBackColor = true;
            // 
            // killEdge
            // 
            resources.ApplyResources(this.killEdge, "killEdge");
            this.killEdge.Name = "killEdge";
            this.killEdge.UseVisualStyleBackColor = true;
            this.killEdge.Click += new System.EventHandler(this.killEdge_Click);
            // 
            // textBox
            // 
            resources.ApplyResources(this.textBox, "textBox");
            this.textBox.Name = "textBox";
            this.textBox.ReadOnly = true;
            this.textBox.DoubleClick += new System.EventHandler(this.textBox_DoubleClick);
            // 
            // recycleBinBox
            // 
            this.recycleBinBox.Controls.Add(this.emptyBin);
            resources.ApplyResources(this.recycleBinBox, "recycleBinBox");
            this.recycleBinBox.Name = "recycleBinBox";
            this.recycleBinBox.TabStop = false;
            // 
            // emptyBin
            // 
            resources.ApplyResources(this.emptyBin, "emptyBin");
            this.emptyBin.Checked = true;
            this.emptyBin.CheckState = System.Windows.Forms.CheckState.Checked;
            this.emptyBin.Name = "emptyBin";
            this.emptyBin.TabStop = false;
            this.emptyBin.UseVisualStyleBackColor = true;
            // 
            // pictureBox
            // 
            this.pictureBox.BackgroundImage = global::WindowsFormNavKiller.Properties.Resources.Devil;
            resources.ApplyResources(this.pictureBox, "pictureBox");
            this.pictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.TabStop = false;
            // 
            // Form1
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.recycleBinBox);
            this.Controls.Add(this.textBox);
            this.Controls.Add(this.groupEdge);
            this.Controls.Add(this.groupFireFox);
            this.Controls.Add(this.groupChrome);
            this.Controls.Add(this.pictureBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.TopMost = true;
            this.groupChrome.ResumeLayout(false);
            this.groupChrome.PerformLayout();
            this.groupFireFox.ResumeLayout(false);
            this.groupFireFox.PerformLayout();
            this.groupEdge.ResumeLayout(false);
            this.groupEdge.PerformLayout();
            this.recycleBinBox.ResumeLayout(false);
            this.recycleBinBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
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

