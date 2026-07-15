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
            ComponentResourceManager resources = new ComponentResourceManager(typeof(ScanUtilForm));
            pictureBox1 = new PictureBox();
            menuStrip1 = new MenuStrip();
            rotation90ToolStripMenuItem = new ToolStripMenuItem();
            rotation90ToolStripMenuItem1 = new ToolStripMenuItem();
            rotation90AntiHoraireToolStripMenuItem = new ToolStripMenuItem();
            rotation180ToolStripMenuItem = new ToolStripMenuItem();
            fichierToolStripMenuItem = new ToolStripMenuItem();
            enregistrerToolStripMenuItem = new ToolStripMenuItem();
            ourvirToolStripMenuItem = new ToolStripMenuItem();
            imprimerToolStripMenuItem = new ToolStripMenuItem();
            panel1 = new Panel();
            btnEnter = new Button();
            btnAcquire = new Button();
            ((ISupportInitialize)pictureBox1).BeginInit();
            menuStrip1.SuspendLayout();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pictureBox1.BackColor = System.Drawing.Color.White;
            pictureBox1.ImageLocation = "";
            pictureBox1.Location = new System.Drawing.Point(14, 31);
            pictureBox1.Margin = new Padding(4, 3, 4, 3);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new System.Drawing.Size(346, 428);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 3;
            pictureBox1.TabStop = false;
            // 
            // menuStrip1
            // 
            menuStrip1.Font = new System.Drawing.Font("Tahoma", 8.25F);
            menuStrip1.Items.AddRange(new ToolStripItem[] { rotation90ToolStripMenuItem, fichierToolStripMenuItem });
            menuStrip1.Location = new System.Drawing.Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Padding = new Padding(7, 2, 0, 2);
            menuStrip1.Size = new System.Drawing.Size(374, 24);
            menuStrip1.TabIndex = 4;
            menuStrip1.Text = "menuStrip1";
            // 
            // rotation90ToolStripMenuItem
            // 
            rotation90ToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { rotation90ToolStripMenuItem1, rotation90AntiHoraireToolStripMenuItem, rotation180ToolStripMenuItem });
            rotation90ToolStripMenuItem.Name = "rotation90ToolStripMenuItem";
            rotation90ToolStripMenuItem.Size = new System.Drawing.Size(49, 20);
            rotation90ToolStripMenuItem.Text = "Image";
            // 
            // rotation90ToolStripMenuItem1
            // 
            rotation90ToolStripMenuItem1.Name = "rotation90ToolStripMenuItem1";
            rotation90ToolStripMenuItem1.ShortcutKeys = Keys.Control | Keys.D9;
            rotation90ToolStripMenuItem1.Size = new System.Drawing.Size(291, 22);
            rotation90ToolStripMenuItem1.Text = "Rotation 90° Horaire";
            rotation90ToolStripMenuItem1.Click += rotation90ToolStripMenuItem1_Click;
            // 
            // rotation90AntiHoraireToolStripMenuItem
            // 
            rotation90AntiHoraireToolStripMenuItem.Name = "rotation90AntiHoraireToolStripMenuItem";
            rotation90AntiHoraireToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.Shift | Keys.D9;
            rotation90AntiHoraireToolStripMenuItem.Size = new System.Drawing.Size(291, 22);
            rotation90AntiHoraireToolStripMenuItem.Text = "Rotation 90+ Anti Horaire";
            rotation90AntiHoraireToolStripMenuItem.Click += rotation90AntiHoraireToolStripMenuItem_Click;
            // 
            // rotation180ToolStripMenuItem
            // 
            rotation180ToolStripMenuItem.Name = "rotation180ToolStripMenuItem";
            rotation180ToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.D8;
            rotation180ToolStripMenuItem.Size = new System.Drawing.Size(291, 22);
            rotation180ToolStripMenuItem.Text = "Rotation 180°";
            rotation180ToolStripMenuItem.Click += rotation180ToolStripMenuItem_Click;
            // 
            // fichierToolStripMenuItem
            // 
            fichierToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { enregistrerToolStripMenuItem, ourvirToolStripMenuItem, imprimerToolStripMenuItem });
            fichierToolStripMenuItem.Name = "fichierToolStripMenuItem";
            fichierToolStripMenuItem.Size = new System.Drawing.Size(50, 20);
            fichierToolStripMenuItem.Text = "Fichier";
            // 
            // enregistrerToolStripMenuItem
            // 
            enregistrerToolStripMenuItem.Name = "enregistrerToolStripMenuItem";
            enregistrerToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.S;
            enregistrerToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            enregistrerToolStripMenuItem.Text = "Enregistrer";
            enregistrerToolStripMenuItem.Click += enregistrerToolStripMenuItem_Click;
            // 
            // ourvirToolStripMenuItem
            // 
            ourvirToolStripMenuItem.Name = "ourvirToolStripMenuItem";
            ourvirToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.O;
            ourvirToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            ourvirToolStripMenuItem.Text = "Ouvir";
            ourvirToolStripMenuItem.Click += ourvirToolStripMenuItem_Click;
            // 
            // imprimerToolStripMenuItem
            // 
            imprimerToolStripMenuItem.Name = "imprimerToolStripMenuItem";
            imprimerToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.I;
            imprimerToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            imprimerToolStripMenuItem.Text = "Imprimer";
            imprimerToolStripMenuItem.Click += imprimerToolStripMenuItem_Click;
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel1.BorderStyle = BorderStyle.Fixed3D;
            panel1.Controls.Add(btnEnter);
            panel1.Controls.Add(btnAcquire);
            panel1.Location = new System.Drawing.Point(14, 482);
            panel1.Margin = new Padding(4, 3, 4, 3);
            panel1.Name = "panel1";
            panel1.Size = new System.Drawing.Size(346, 37);
            panel1.TabIndex = 6;
            // 
            // btnEnter
            // 
            btnEnter.Location = new System.Drawing.Point(287, 3);
            btnEnter.Margin = new Padding(4, 3, 4, 3);
            btnEnter.Name = "btnEnter";
            btnEnter.Size = new System.Drawing.Size(30, 27);
            btnEnter.TabIndex = 1;
            btnEnter.Text = "btnEnter";
            btnEnter.UseVisualStyleBackColor = true;
            btnEnter.Click += btnEnter_Click;
            // 
            // btnAcquire
            // 
            btnAcquire.Anchor = AnchorStyles.Bottom;
            btnAcquire.Location = new System.Drawing.Point(131, 3);
            btnAcquire.Margin = new Padding(4, 3, 4, 3);
            btnAcquire.Name = "btnAcquire";
            btnAcquire.Size = new System.Drawing.Size(88, 27);
            btnAcquire.TabIndex = 0;
            btnAcquire.Text = "&Acquisition";
            btnAcquire.UseVisualStyleBackColor = true;
            btnAcquire.Click += btnAcquire_Click;
            // 
            // ScanUtilForm
            // 
            AcceptButton = btnEnter;
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(374, 535);
            Controls.Add(panel1);
            Controls.Add(menuStrip1);
            Controls.Add(pictureBox1);
            Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(4, 3, 4, 3);
            Name = "ScanUtilForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Acquisition document";
            Load += ScanUtilForm_Load;
            ((ISupportInitialize)pictureBox1).EndInit();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            panel1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();

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
        protected ToolStripMenuItem enregistrerToolStripMenuItem;
        protected ToolStripMenuItem ourvirToolStripMenuItem;
        private Button btnEnter;
        private ToolStripMenuItem imprimerToolStripMenuItem;
    }
}