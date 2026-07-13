using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace EspaceSyndic.Formulaires.OperationsGestion
{
    partial class DetailReglementForm
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
            ComponentResourceManager resources = new ComponentResourceManager(typeof(DetailReglementForm));
            this.tbLibCopro = new TextBox();
            this.tbCopro = new TextBox();
            this.lblCopro = new Label();
            this.tbLot = new TextBox();
            this.lblLot = new Label();
            this.contextMenuStrip1 = new ContextMenuStrip(this.components);
            this.supprimerLélémentToolStripMenuItem = new ToolStripMenuItem();
            this.mettreÀJourLidDeSaisieToolStripMenuItem = new ToolStripMenuItem();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tbLot);
            this.groupBox1.Controls.Add(this.lblLot);
            this.groupBox1.Controls.Add(this.tbLibCopro);
            this.groupBox1.Controls.Add(this.tbCopro);
            this.groupBox1.Controls.Add(this.lblCopro);
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
            this.groupBox1.Controls.SetChildIndex(this.lblCopro, 0);
            this.groupBox1.Controls.SetChildIndex(this.tbCopro, 0);
            this.groupBox1.Controls.SetChildIndex(this.tbLibCopro, 0);
            this.groupBox1.Controls.SetChildIndex(this.lblLot, 0);
            this.groupBox1.Controls.SetChildIndex(this.tbLot, 0);
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
            // tbNature
            // 
            this.tbNature.Validating += new CancelEventHandler(this.tbNature_Validating);
            // 
            // tbFournisseur
            // 
            this.tbFournisseur.Visible = false;
            // 
            // lblFournisseur
            // 
            this.lblFournisseur.Visible = false;
            // 
            // tbRefImmeuble
            // 
            this.tbRefImmeuble.Validating += new CancelEventHandler(this.tbRefImmeuble_Validating);
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
            // 
            // tbLibCopro
            // 
            this.tbLibCopro.Enabled = false;
            this.tbLibCopro.Location = new Point(473, 74);
            this.tbLibCopro.Name = "tbLibCopro";
            this.tbLibCopro.Size = new Size(273, 20);
            this.tbLibCopro.TabIndex = 28;
            this.tbLibCopro.TabStop = false;
            // 
            // tbCopro
            // 
            this.tbCopro.Enabled = false;
            this.tbCopro.Location = new Point(373, 74);
            this.tbCopro.Name = "tbCopro";
            this.tbCopro.Size = new Size(65, 20);
            this.tbCopro.TabIndex = 27;
            this.tbCopro.Validating += new CancelEventHandler(this.tbCopro_Validating);
            // 
            // lblCopro
            // 
            this.lblCopro.AutoSize = true;
            this.lblCopro.ForeColor = Color.Black;
            this.lblCopro.Location = new Point(298, 77);
            this.lblCopro.Name = "lblCopro";
            this.lblCopro.Size = new Size(75, 13);
            this.lblCopro.TabIndex = 26;
            this.lblCopro.Text = "Co&propriétaire:";
            // 
            // tbLot
            // 
            this.tbLot.Location = new Point(86, 74);
            this.tbLot.Name = "tbLot";
            this.tbLot.Size = new Size(65, 20);
            this.tbLot.TabIndex = 30;
            this.tbLot.Validating += new CancelEventHandler(this.tbLot_Validating);
            // 
            // lblLot
            // 
            this.lblLot.AutoSize = true;
            this.lblLot.ForeColor = Color.Blue;
            this.lblLot.Location = new Point(11, 77);
            this.lblLot.Name = "lblLot";
            this.lblLot.Size = new Size(25, 13);
            this.lblLot.TabIndex = 29;
            this.lblLot.Text = "&Lot:";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new ToolStripItem[] {
            this.supprimerLélémentToolStripMenuItem,
            this.mettreÀJourLidDeSaisieToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new Size(198, 70);
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
            // DetailReglementForm
            // 
            this.AutoScaleDimensions = new SizeF(6F, 13F);
            this.ClientSize = new Size(784, 653);
            this.Name = "DetailReglementForm";
            this.Text = "Detail Reglement";
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

        protected TextBox tbLibCopro;
        private TextBox tbCopro;
        private Label lblCopro;
        private TextBox tbLot;
        private Label lblLot;
        private ContextMenuStrip contextMenuStrip1;
        private ToolStripMenuItem supprimerLélémentToolStripMenuItem;
        private ToolStripMenuItem mettreÀJourLidDeSaisieToolStripMenuItem;
    }
}
