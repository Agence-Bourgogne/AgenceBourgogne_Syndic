using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace EspaceSyndic.Formulaires.OperationsGestion
{
    partial class DetailFactureForm
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
            ComponentResourceManager resources = new ComponentResourceManager(typeof(DetailFactureForm));
            this.btnRecalc = new Button();
            this.label1 = new Label();
            this.tbTotal = new TextBox();
            this.contextMenuStrip1 = new ContextMenuStrip(this.components);
            this.supprimerLélémentToolStripMenuItem = new ToolStripMenuItem();
            this.mettreÀJourLidDeSaisieToolStripMenuItem = new ToolStripMenuItem();
            this.tbLot = new TextBox();
            this.lblLot = new Label();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tbLot);
            this.groupBox1.Controls.Add(this.lblLot);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.tbTotal);
            this.groupBox1.TabIndex = 0;
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
            this.groupBox1.Controls.SetChildIndex(this.lblLot, 0);
            this.groupBox1.Controls.SetChildIndex(this.tbLot, 0);
            // 
            // cbReglement
            // 
            this.cbReglement.TabIndex = 23;
            // 
            // label2
            // 
            this.label2.TabIndex = 22;
            // 
            // btnFournisseurAdd
            // 
            this.btnFournisseurAdd.TabIndex = 19;
            // 
            // btnNatureAdd
            // 
            this.btnNatureAdd.TabIndex = 14;
            // 
            // tbComment
            // 
            this.tbComment.TabIndex = 16;
            // 
            // tbCommentaireFournisseur
            // 
            this.tbCommentaireFournisseur.TabIndex = 21;
            // 
            // tbMontant
            // 
            this.tbMontant.Location = new Point(571, 22);
            this.tbMontant.TabIndex = 9;
            // 
            // tbNomFournisseur
            // 
            this.tbNomFournisseur.TabIndex = 20;
            // 
            // label8
            // 
            this.label8.Location = new Point(516, 25);
            this.label8.TabIndex = 8;
            // 
            // tbVilleFournisseur
            // 
            this.tbVilleFournisseur.TabIndex = 26;
            // 
            // tbCpFournisseur
            // 
            this.tbCpFournisseur.TabIndex = 25;
            // 
            // tbAdresseFournisseur
            // 
            this.tbAdresseFournisseur.TabIndex = 24;
            // 
            // tbBase
            // 
            this.tbBase.Location = new Point(376, 22);
            this.tbBase.TabIndex = 5;
            this.tbBase.Text = "0";
            // 
            // lblBase
            // 
            this.lblBase.Location = new Point(348, 25);
            this.lblBase.Size = new Size(31, 13);
            this.lblBase.TabIndex = 4;
            this.lblBase.Text = "Base";
            // 
            // tbFournisseur
            // 
            this.tbFournisseur.TabIndex = 18;
            // 
            // lblFournisseur
            // 
            this.lblFournisseur.TabIndex = 17;
            // 
            // label3
            // 
            this.label3.TabIndex = 2;
            // 
            // tbDateCreation
            // 
            this.tbDateCreation.TabIndex = 3;
            // 
            // tbRefImmeuble
            // 
            this.tbRefImmeuble.TabIndex = 1;
            // 
            // lblImmeuble
            // 
            this.lblImmeuble.TabIndex = 0;
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
            this.btnEnter.Location = new Point(553, 6);
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
            this.btnRecalc.Location = new Point(328, 6);
            this.btnRecalc.Name = "btnRecalc";
            this.btnRecalc.Size = new Size(100, 25);
            this.btnRecalc.TabIndex = 117;
            this.btnRecalc.Text = "Re&calculer";
            this.btnRecalc.TextAlign = ContentAlignment.MiddleLeft;
            this.btnRecalc.UseVisualStyleBackColor = true;
            this.btnRecalc.Click += new EventHandler(this.btnRecalc_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new Point(643, 25);
            this.label1.Name = "label1";
            this.label1.Size = new Size(31, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Total";
            // 
            // tbTotal
            // 
            this.tbTotal.Location = new Point(681, 22);
            this.tbTotal.Name = "tbTotal";
            this.tbTotal.ShortcutsEnabled = false;
            this.tbTotal.Size = new Size(65, 20);
            this.tbTotal.TabIndex = 11;
            this.tbTotal.TabStop = false;
            this.tbTotal.Enter += new EventHandler(this.tbTotal_Enter);
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
            // tbLot
            // 
            this.tbLot.Location = new Point(464, 22);
            this.tbLot.Name = "tbLot";
            this.tbLot.Size = new Size(46, 20);
            this.tbLot.TabIndex = 7;
            // 
            // lblLot
            // 
            this.lblLot.AutoSize = true;
            this.lblLot.Location = new Point(435, 25);
            this.lblLot.Name = "lblLot";
            this.lblLot.Size = new Size(22, 13);
            this.lblLot.TabIndex = 6;
            this.lblLot.Text = "&Lot";
            // 
            // DetailFactureForm
            // 
            this.AutoScaleDimensions = new SizeF(6F, 13F);
            this.ClientSize = new Size(784, 653);
            this.Name = "DetailFactureForm";
            this.Text = "Detail Facture";
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
        private Label label1;
        private TextBox tbTotal;
        private ContextMenuStrip contextMenuStrip1;
        private ToolStripMenuItem supprimerLélémentToolStripMenuItem;
        private ToolStripMenuItem mettreÀJourLidDeSaisieToolStripMenuItem;
        protected TextBox tbLot;
        private Label lblLot;
    }
}
