using System.ComponentModel;
using System.Windows.Forms;

namespace CommonProjectsPartners.Utils
{
    partial class ScanUtilForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ScanUtilForm));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.rotation90ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rotation90ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.rotation90AntiHoraireToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rotation180ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fichierToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.enregistrerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ourvirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.acquisitionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.modeTwainToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.modeWIAToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnEnter = new System.Windows.Forms.Button();
            this.btnAcquire = new System.Windows.Forms.Button();
            this.imprimerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.BackColor = System.Drawing.Color.White;
            this.pictureBox1.ImageLocation = "";
            this.pictureBox1.Location = new System.Drawing.Point(12, 27);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(297, 371);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.rotation90ToolStripMenuItem,
            this.fichierToolStripMenuItem,
            this.acquisitionToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(321, 24);
            this.menuStrip1.TabIndex = 4;
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
            this.ourvirToolStripMenuItem,
            this.imprimerToolStripMenuItem});
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
            this.ourvirToolStripMenuItem.Text = "Ouvir";
            this.ourvirToolStripMenuItem.Click += new System.EventHandler(this.ourvirToolStripMenuItem_Click);
            // 
            // acquisitionToolStripMenuItem
            // 
            this.acquisitionToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.modeTwainToolStripMenuItem,
            this.modeWIAToolStripMenuItem});
            this.acquisitionToolStripMenuItem.Name = "acquisitionToolStripMenuItem";
            this.acquisitionToolStripMenuItem.Size = new System.Drawing.Size(70, 20);
            this.acquisitionToolStripMenuItem.Text = "Acquisition";
            // 
            // modeTwainToolStripMenuItem
            // 
            this.modeTwainToolStripMenuItem.Name = "modeTwainToolStripMenuItem";
            this.modeTwainToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.T)));
            this.modeTwainToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
            this.modeTwainToolStripMenuItem.Text = "Mode Twain";
            this.modeTwainToolStripMenuItem.Click += new System.EventHandler(this.modeTwainToolStripMenuItem_Click);
            // 
            // modeWIAToolStripMenuItem
            // 
            this.modeWIAToolStripMenuItem.Name = "modeWIAToolStripMenuItem";
            this.modeWIAToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.W)));
            this.modeWIAToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
            this.modeWIAToolStripMenuItem.Text = "Mode WIA";
            this.modeWIAToolStripMenuItem.Click += new System.EventHandler(this.modeWIAToolStripMenuItem_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.btnEnter);
            this.panel1.Controls.Add(this.btnAcquire);
            this.panel1.Location = new System.Drawing.Point(12, 418);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(297, 33);
            this.panel1.TabIndex = 6;
            // 
            // btnEnter
            // 
            this.btnEnter.Location = new System.Drawing.Point(246, 3);
            this.btnEnter.Name = "btnEnter";
            this.btnEnter.Size = new System.Drawing.Size(26, 23);
            this.btnEnter.TabIndex = 1;
            this.btnEnter.Text = "btnEnter";
            this.btnEnter.UseVisualStyleBackColor = true;
            this.btnEnter.Click += new System.EventHandler(this.btnEnter_Click);
            // 
            // btnAcquire
            // 
            this.btnAcquire.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnAcquire.Location = new System.Drawing.Point(112, 3);
            this.btnAcquire.Name = "btnAcquire";
            this.btnAcquire.Size = new System.Drawing.Size(75, 23);
            this.btnAcquire.TabIndex = 0;
            this.btnAcquire.Text = "&Acquisition";
            this.btnAcquire.UseVisualStyleBackColor = true;
            this.btnAcquire.Click += new System.EventHandler(this.btnAcquire_Click);
            // 
            // imprimerToolStripMenuItem
            // 
            this.imprimerToolStripMenuItem.Name = "imprimerToolStripMenuItem";
            this.imprimerToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.I)));
            this.imprimerToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.imprimerToolStripMenuItem.Text = "Imprimer";
            this.imprimerToolStripMenuItem.Click += new System.EventHandler(this.imprimerToolStripMenuItem_Click);
            // 
            // ScanUtilForm
            // 
            this.AcceptButton = this.btnEnter;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(321, 464);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.pictureBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ScanUtilForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Acquisition document";
            this.Load += new System.EventHandler(this.ScanUtilForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        protected PictureBox pictureBox1;
        protected MenuStrip menuStrip1;
        protected ToolStripMenuItem rotation90ToolStripMenuItem;
        protected ToolStripMenuItem rotation90ToolStripMenuItem1;
        protected ToolStripMenuItem rotation90AntiHoraireToolStripMenuItem;
        protected ToolStripMenuItem rotation180ToolStripMenuItem;
        protected ToolStripMenuItem fichierToolStripMenuItem;
        protected Panel panel1;
        protected Button btnAcquire;
        protected ToolStripMenuItem acquisitionToolStripMenuItem;
        protected ToolStripMenuItem modeTwainToolStripMenuItem;
        protected ToolStripMenuItem modeWIAToolStripMenuItem;
        protected ToolStripMenuItem enregistrerToolStripMenuItem;
        protected ToolStripMenuItem ourvirToolStripMenuItem;
        private Button btnEnter;
        private ToolStripMenuItem imprimerToolStripMenuItem;
    }
}