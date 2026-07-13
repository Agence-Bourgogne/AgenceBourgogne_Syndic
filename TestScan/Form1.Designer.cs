namespace TestScan
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
            this.btnWIA = new System.Windows.Forms.Button();
            this.btnTwain = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.rotation90ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rotation90ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.rotation90AntiHoraireToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rotation180ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fichierToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.enregistrerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ourvirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnWIA
            // 
            this.btnWIA.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnWIA.Location = new System.Drawing.Point(43, 336);
            this.btnWIA.Name = "btnWIA";
            this.btnWIA.Size = new System.Drawing.Size(75, 23);
            this.btnWIA.TabIndex = 0;
            this.btnWIA.Text = "&WIA";
            this.btnWIA.UseVisualStyleBackColor = true;
            this.btnWIA.Click += new System.EventHandler(this.btnWIA_Click);
            // 
            // btnTwain
            // 
            this.btnTwain.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnTwain.Location = new System.Drawing.Point(151, 336);
            this.btnTwain.Name = "btnTwain";
            this.btnTwain.Size = new System.Drawing.Size(75, 23);
            this.btnTwain.TabIndex = 1;
            this.btnTwain.Text = "&Twain";
            this.btnTwain.UseVisualStyleBackColor = true;
            this.btnTwain.Click += new System.EventHandler(this.btnTwain_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.BackColor = System.Drawing.Color.White;
            this.pictureBox1.ImageLocation = "";
            this.pictureBox1.Location = new System.Drawing.Point(12, 30);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(240, 300);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.rotation90ToolStripMenuItem,
            this.fichierToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(264, 24);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // rotation90ToolStripMenuItem
            // 
            this.rotation90ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.rotation90ToolStripMenuItem1,
            this.rotation90AntiHoraireToolStripMenuItem,
            this.rotation180ToolStripMenuItem});
            this.rotation90ToolStripMenuItem.Name = "rotation90ToolStripMenuItem";
            this.rotation90ToolStripMenuItem.Size = new System.Drawing.Size(49, 20);
            this.rotation90ToolStripMenuItem.Text = "Image";
            // 
            // rotation90ToolStripMenuItem1
            // 
            this.rotation90ToolStripMenuItem1.Name = "rotation90ToolStripMenuItem1";
            this.rotation90ToolStripMenuItem1.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D9)));
            this.rotation90ToolStripMenuItem1.Size = new System.Drawing.Size(261, 22);
            this.rotation90ToolStripMenuItem1.Text = "Rotation 90° Horaire";
            this.rotation90ToolStripMenuItem1.Click += new System.EventHandler(this.rotation90ToolStripMenuItem1_Click);
            // 
            // rotation90AntiHoraireToolStripMenuItem
            // 
            this.rotation90AntiHoraireToolStripMenuItem.Name = "rotation90AntiHoraireToolStripMenuItem";
            this.rotation90AntiHoraireToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.D9)));
            this.rotation90AntiHoraireToolStripMenuItem.Size = new System.Drawing.Size(261, 22);
            this.rotation90AntiHoraireToolStripMenuItem.Text = "Rotation 90+ Anti Horaire";
            this.rotation90AntiHoraireToolStripMenuItem.Click += new System.EventHandler(this.rotation90AntiHoraireToolStripMenuItem_Click);
            // 
            // rotation180ToolStripMenuItem
            // 
            this.rotation180ToolStripMenuItem.Name = "rotation180ToolStripMenuItem";
            this.rotation180ToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D8)));
            this.rotation180ToolStripMenuItem.Size = new System.Drawing.Size(261, 22);
            this.rotation180ToolStripMenuItem.Text = "Rotation 180°";
            this.rotation180ToolStripMenuItem.Click += new System.EventHandler(this.rotation180ToolStripMenuItem_Click);
            // 
            // fichierToolStripMenuItem
            // 
            this.fichierToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.enregistrerToolStripMenuItem,
            this.ourvirToolStripMenuItem});
            this.fichierToolStripMenuItem.Name = "fichierToolStripMenuItem";
            this.fichierToolStripMenuItem.Size = new System.Drawing.Size(50, 20);
            this.fichierToolStripMenuItem.Text = "Fichier";
            // 
            // enregistrerToolStripMenuItem
            // 
            this.enregistrerToolStripMenuItem.Name = "enregistrerToolStripMenuItem";
            this.enregistrerToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.enregistrerToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.enregistrerToolStripMenuItem.Text = "Enregistrer";
            this.enregistrerToolStripMenuItem.Click += new System.EventHandler(this.enregistrerToolStripMenuItem_Click);
            // 
            // ourvirToolStripMenuItem
            // 
            this.ourvirToolStripMenuItem.Name = "ourvirToolStripMenuItem";
            this.ourvirToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.ourvirToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.ourvirToolStripMenuItem.Text = "Ourvir";
            this.ourvirToolStripMenuItem.Click += new System.EventHandler(this.ourvirToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(264, 371);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnTwain);
            this.Controls.Add(this.btnWIA);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Scanner";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnWIA;
        private System.Windows.Forms.Button btnTwain;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem rotation90ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rotation90ToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem rotation90AntiHoraireToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rotation180ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fichierToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem enregistrerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ourvirToolStripMenuItem;
    }
}

