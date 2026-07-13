using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace EspaceSyndic.Formulaires.OperationsGestion
{
    partial class DetailAppelDeFondForm
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private IContainer components = null;

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
            this.components = new Container();
            ComponentResourceManager resources = new ComponentResourceManager(typeof(DetailAppelDeFondForm));
            this.btnRecalc = new Button();
            this.contextMenuStrip1 = new ContextMenuStrip(this.components);
            this.supprimerLélémentToolStripMenuItem = new ToolStripMenuItem();
            this.mettreÀJourLidDeSaisieToolStripMenuItem = new ToolStripMenuItem();
            this.tbTotal = new TextBox();
            this.label1 = new Label();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.tbTotal);
            this.groupBox1.Controls.SetChildIndex(this.lblImmeuble, 0);
            this.groupBox1.Controls.SetChildIndex(this.tbRefImmeuble, 0);
            this.groupBox1.Controls.SetChildIndex(this.tbDateCreation, 0);
            this.groupBox1.Controls.SetChildIndex(this.label3, 0);
            this.groupBox1.Controls.SetChildIndex(this.lblFournisseur, 0);
            this.groupBox1.Controls.SetChildIndex(this.tbFournisseur, 0);
            this.groupBox1.Controls.SetChildIndex(this.lblNature, 0);
            this.groupBox1.Controls.SetChildIndex(this.tbNature, 0);
            this.groupBox1.Controls.SetChildIndex(this.lblBase, 0);
            this.groupBox1.Controls.SetChildIndex(this.tbBase, 0);
            this.groupBox1.Controls.SetChildIndex(this.tbLibNature, 0);
            this.groupBox1.Controls.SetChildIndex(this.tbAdresseFournisseur, 0);
            this.groupBox1.Controls.SetChildIndex(this.tbCpFournisseur, 0);
            this.groupBox1.Controls.SetChildIndex(this.tbVilleFournisseur, 0);
            this.groupBox1.Controls.SetChildIndex(this.label8, 0);
            this.groupBox1.Controls.SetChildIndex(this.tbNomFournisseur, 0);
            this.groupBox1.Controls.SetChildIndex(this.tbMontant, 0);
            this.groupBox1.Controls.SetChildIndex(this.tbCommentaireFournisseur, 0);
            this.groupBox1.Controls.SetChildIndex(this.tbComment, 0);
            this.groupBox1.Controls.SetChildIndex(this.btnNatureAdd, 0);
            this.groupBox1.Controls.SetChildIndex(this.btnFournisseurAdd, 0);
            this.groupBox1.Controls.SetChildIndex(this.label2, 0);
            this.groupBox1.Controls.SetChildIndex(this.cbReglement, 0);
            this.groupBox1.Controls.SetChildIndex(this.tbTotal, 0);
            this.groupBox1.Controls.SetChildIndex(this.label1, 0);
            // 
            // tbCommentaireFournisseur
            // 
            this.tbCommentaireFournisseur.Visible = false;
            // 
            // tbNomFournisseur
            // 
            this.tbNomFournisseur.Visible = false;
            // 
            // tbVilleFournisseur
            // 
            this.tbVilleFournisseur.Visible = false;
            // 
            // tbCpFournisseur
            // 
            this.tbCpFournisseur.Visible = false;
            // 
            // tbAdresseFournisseur
            // 
            this.tbAdresseFournisseur.Visible = false;
            // 
            // tbFournisseur
            // 
            this.tbFournisseur.Visible = false;
            // 
            // lblFournisseur
            // 
            this.lblFournisseur.Visible = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnRecalc);
            this.panel1.Controls.SetChildIndex(this.btnQuit, 0);
            this.panel1.Controls.SetChildIndex(this.btnValid, 0);
            this.panel1.Controls.SetChildIndex(this.btnDelete, 0);
            this.panel1.Controls.SetChildIndex(this.btnEnter, 0);
            this.panel1.Controls.SetChildIndex(this.btnRecalc, 0);
            // 
            // btnEnter
            // 
            this.btnEnter.Location = new Point(545, 7);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.Images.SetKeyName(0, "top.png");
            this.imageList1.Images.SetKeyName(1, "bottom.png");
            this.imageList1.Images.SetKeyName(2, "previous.png");
            this.imageList1.Images.SetKeyName(3, "next.png");
            this.imageList1.Images.SetKeyName(4, "save.png");
            this.imageList1.Images.SetKeyName(5, "quit.png");
            this.imageList1.Images.SetKeyName(6, "print.png");
            this.imageList1.Images.SetKeyName(7, "add.png");
            this.imageList1.Images.SetKeyName(8, "excel.png");
            this.imageList1.Images.SetKeyName(9, "zoom.png");
            this.imageList1.Images.SetKeyName(10, "del.png");
            this.imageList1.Images.SetKeyName(11, "reload.png");
            // 
            // btnRecalc
            // 
            this.btnRecalc.ImageAlign = ContentAlignment.MiddleRight;
            this.btnRecalc.ImageKey = "reload.png";
            this.btnRecalc.ImageList = this.imageList1;
            this.btnRecalc.Location = new Point(329, 6);
            this.btnRecalc.Name = "btnRecalc";
            this.btnRecalc.Size = new Size(100, 25);
            this.btnRecalc.TabIndex = 116;
            this.btnRecalc.Text = "Re&calculer";
            this.btnRecalc.TextAlign = ContentAlignment.MiddleLeft;
            this.btnRecalc.UseVisualStyleBackColor = true;
            this.btnRecalc.Click += new EventHandler(this.btnRecalc_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new ToolStripItem[] {
            this.supprimerLélémentToolStripMenuItem,
            this.mettreÀJourLidDeSaisieToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new Size(198, 48);
            // 
            // supprimerLélémentToolStripMenuItem
            // 
            this.supprimerLélémentToolStripMenuItem.Name = "supprimerLélémentToolStripMenuItem";
            this.supprimerLélémentToolStripMenuItem.Size = new Size(197, 22);
            this.supprimerLélémentToolStripMenuItem.Text = "Supprimer l\'élément";
            this.supprimerLélémentToolStripMenuItem.Click += new EventHandler(this.supprimerLélémentToolStripMenuItem_Click);
            // 
            // mettreÀJourLidDeSaisieToolStripMenuItem
            // 
            this.mettreÀJourLidDeSaisieToolStripMenuItem.Name = "mettreÀJourLidDeSaisieToolStripMenuItem";
            this.mettreÀJourLidDeSaisieToolStripMenuItem.Size = new Size(197, 22);
            this.mettreÀJourLidDeSaisieToolStripMenuItem.Text = "Mettre à jour l\'id de Saisie";
            this.mettreÀJourLidDeSaisieToolStripMenuItem.Click += new EventHandler(this.mettreÀJourLidDeSaisieToolStripMenuItem_Click);
            // 
            // tbTotal
            // 
            this.tbTotal.Enabled = false;
            this.tbTotal.Location = new Point(681, 22);
            this.tbTotal.Name = "tbTotal";
            this.tbTotal.ReadOnly = true;
            this.tbTotal.Size = new Size(65, 20);
            this.tbTotal.TabIndex = 26;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new Point(643, 25);
            this.label1.Name = "label1";
            this.label1.Size = new Size(31, 13);
            this.label1.TabIndex = 27;
            this.label1.Text = "Total";
            // 
            // DetailAppelDeFondForm
            // 
            this.AutoScaleDimensions = new SizeF(6F, 13F);
            this.ClientSize = new Size(784, 653);
            this.Name = "DetailAppelDeFondForm";
            this.Text = "Detail Appel de Fond";
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.gbFactures, 0);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Button btnRecalc;
        private ContextMenuStrip contextMenuStrip1;
        private ToolStripMenuItem supprimerLélémentToolStripMenuItem;
        private ToolStripMenuItem mettreÀJourLidDeSaisieToolStripMenuItem;
        private Label label1;
        private TextBox tbTotal;
    }
}
