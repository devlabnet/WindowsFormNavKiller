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
            this.killEdge = new System.Windows.Forms.Button();
            this.textBox = new System.Windows.Forms.RichTextBox();
            this.recycleBinBox = new System.Windows.Forms.GroupBox();
            this.emptyBin = new System.Windows.Forms.CheckBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.languageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.eToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.goToWebSiteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.groupChrome.SuspendLayout();
            this.groupFireFox.SuspendLayout();
            this.groupEdge.SuspendLayout();
            this.recycleBinBox.SuspendLayout();
            this.menuStrip1.SuspendLayout();
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
            this.groupEdge.Controls.Add(this.killEdge);
            resources.ApplyResources(this.groupEdge, "groupEdge");
            this.groupEdge.Name = "groupEdge";
            this.groupEdge.TabStop = false;
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
            this.emptyBin.Name = "emptyBin";
            this.emptyBin.TabStop = false;
            this.emptyBin.UseVisualStyleBackColor = true;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.languageToolStripMenuItem,
            this.helpToolStripMenuItem});
            resources.ApplyResources(this.menuStrip1, "menuStrip1");
            this.menuStrip1.Name = "menuStrip1";
            // 
            // languageToolStripMenuItem
            // 
            this.languageToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fToolStripMenuItem,
            this.eToolStripMenuItem});
            this.languageToolStripMenuItem.Name = "languageToolStripMenuItem";
            resources.ApplyResources(this.languageToolStripMenuItem, "languageToolStripMenuItem");
            // 
            // fToolStripMenuItem
            // 
            this.fToolStripMenuItem.Image = global::WindowsFormNavKiller.Properties.Resources.France_Flag;
            this.fToolStripMenuItem.Name = "fToolStripMenuItem";
            resources.ApplyResources(this.fToolStripMenuItem, "fToolStripMenuItem");
            this.fToolStripMenuItem.Click += new System.EventHandler(this.fToolStripMenuItem_Click);
            // 
            // eToolStripMenuItem
            // 
            this.eToolStripMenuItem.Image = global::WindowsFormNavKiller.Properties.Resources.United_States_Flag;
            this.eToolStripMenuItem.Name = "eToolStripMenuItem";
            resources.ApplyResources(this.eToolStripMenuItem, "eToolStripMenuItem");
            this.eToolStripMenuItem.Click += new System.EventHandler(this.eToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.goToWebSiteToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            resources.ApplyResources(this.helpToolStripMenuItem, "helpToolStripMenuItem");
            // 
            // goToWebSiteToolStripMenuItem
            // 
            this.goToWebSiteToolStripMenuItem.Image = global::WindowsFormNavKiller.Properties.Resources.support;
            this.goToWebSiteToolStripMenuItem.Name = "goToWebSiteToolStripMenuItem";
            resources.ApplyResources(this.goToWebSiteToolStripMenuItem, "goToWebSiteToolStripMenuItem");
            this.goToWebSiteToolStripMenuItem.Click += new System.EventHandler(this.goToWebSiteToolStripMenuItem_Click);
            // 
            // pictureBox
            // 
            this.pictureBox.BackgroundImage = global::WindowsFormNavKiller.Properties.Resources.Devil;
            resources.ApplyResources(this.pictureBox, "pictureBox");
            this.pictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.TabStop = false;
            this.pictureBox.Click += new System.EventHandler(this.pictureBox_Click);
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
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupChrome.ResumeLayout(false);
            this.groupChrome.PerformLayout();
            this.groupFireFox.ResumeLayout(false);
            this.groupFireFox.PerformLayout();
            this.groupEdge.ResumeLayout(false);
            this.recycleBinBox.ResumeLayout(false);
            this.recycleBinBox.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

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
        private System.Windows.Forms.Button killEdge;
        private System.Windows.Forms.RichTextBox textBox;
        private System.Windows.Forms.GroupBox recycleBinBox;
        private System.Windows.Forms.CheckBox emptyBin;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem languageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem eToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem goToWebSiteToolStripMenuItem;
    }
}

