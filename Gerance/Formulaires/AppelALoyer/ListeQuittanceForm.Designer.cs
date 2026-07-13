namespace Gerance.Formulaires.AppelALoyer
{
    partial class ListeQuittanceForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ListeQuittanceForm));
            this.dateDebut = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.tbRefLocataire = new System.Windows.Forms.TextBox();
            this.lblLocataire = new System.Windows.Forms.Label();
            this.tbRefProprio = new System.Windows.Forms.TextBox();
            this.lblProprio = new System.Windows.Forms.Label();
            this.tbNomProprio = new System.Windows.Forms.TextBox();
            this.tbNomLocataire = new System.Windows.Forms.TextBox();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnPrint = new System.Windows.Forms.Button();
            this.panelButton.SuspendLayout();
            this.gbHeader.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelButton
            // 
            this.panelButton.Controls.Add(this.btnPrint);
            this.panelButton.Controls.Add(this.btnDelete);
            this.panelButton.Controls.SetChildIndex(this.btnQuit, 0);
            this.panelButton.Controls.SetChildIndex(this.btnEnter, 0);
            this.panelButton.Controls.SetChildIndex(this.btnGrid, 0);
            this.panelButton.Controls.SetChildIndex(this.btnExport, 0);
            this.panelButton.Controls.SetChildIndex(this.btnDetail, 0);
            this.panelButton.Controls.SetChildIndex(this.btnDelete, 0);
            this.panelButton.Controls.SetChildIndex(this.btnPrint, 0);
            // 
            // btnEnter
            // 
            this.btnEnter.Size = new System.Drawing.Size(0, 23);
            // 
            // gbHeader
            // 
            this.gbHeader.Controls.Add(this.tbNomLocataire);
            this.gbHeader.Controls.Add(this.tbNomProprio);
            this.gbHeader.Controls.Add(this.tbRefProprio);
            this.gbHeader.Controls.Add(this.lblProprio);
            this.gbHeader.Controls.Add(this.tbRefLocataire);
            this.gbHeader.Controls.Add(this.lblLocataire);
            this.gbHeader.Controls.Add(this.dateDebut);
            this.gbHeader.Controls.Add(this.label2);
            this.gbHeader.Size = new System.Drawing.Size(760, 83);
            // 
            // imageList
            // 
            this.imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList.ImageStream")));
            this.imageList.Images.SetKeyName(0, "top.png");
            this.imageList.Images.SetKeyName(1, "bottom.png");
            this.imageList.Images.SetKeyName(2, "previous.png");
            this.imageList.Images.SetKeyName(3, "next.png");
            this.imageList.Images.SetKeyName(4, "save.png");
            this.imageList.Images.SetKeyName(5, "quit.png");
            this.imageList.Images.SetKeyName(6, "edit.png");
            this.imageList.Images.SetKeyName(7, "add.png");
            this.imageList.Images.SetKeyName(8, "fiche.png");
            this.imageList.Images.SetKeyName(9, "excel.png");
            this.imageList.Images.SetKeyName(10, "zoom.png");
            this.imageList.Images.SetKeyName(11, "stop.png");
            this.imageList.Images.SetKeyName(12, "print.png");
            // 
            // gbFactures
            // 
            this.gbFactures.Location = new System.Drawing.Point(12, 101);
            this.gbFactures.Size = new System.Drawing.Size(760, 515);
            // 
            // dateDebut
            // 
            this.dateDebut.CustomFormat = "MMMM yyy";
            this.dateDebut.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateDebut.Location = new System.Drawing.Point(90, 20);
            this.dateDebut.Name = "dateDebut";
            this.dateDebut.Size = new System.Drawing.Size(97, 20);
            this.dateDebut.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Pour le &mois";
            // 
            // tbRefLocataire
            // 
            this.tbRefLocataire.Location = new System.Drawing.Point(363, 20);
            this.tbRefLocataire.Name = "tbRefLocataire";
            this.tbRefLocataire.Size = new System.Drawing.Size(65, 20);
            this.tbRefLocataire.TabIndex = 12;
            this.tbRefLocataire.Validating += new System.ComponentModel.CancelEventHandler(this.tbRefLocataire_Validating);
            // 
            // lblLocataire
            // 
            this.lblLocataire.AutoSize = true;
            this.lblLocataire.ForeColor = System.Drawing.Color.Blue;
            this.lblLocataire.Location = new System.Drawing.Point(294, 23);
            this.lblLocataire.Name = "lblLocataire";
            this.lblLocataire.Size = new System.Drawing.Size(51, 13);
            this.lblLocataire.TabIndex = 11;
            this.lblLocataire.Text = "&Locataire";
            this.lblLocataire.Click += new System.EventHandler(this.lblLocataire_Click);
            // 
            // tbRefProprio
            // 
            this.tbRefProprio.Location = new System.Drawing.Point(363, 46);
            this.tbRefProprio.Name = "tbRefProprio";
            this.tbRefProprio.Size = new System.Drawing.Size(65, 20);
            this.tbRefProprio.TabIndex = 14;
            this.tbRefProprio.Validating += new System.ComponentModel.CancelEventHandler(this.tbRefProprio_Validating);
            // 
            // lblProprio
            // 
            this.lblProprio.AutoSize = true;
            this.lblProprio.ForeColor = System.Drawing.Color.Blue;
            this.lblProprio.Location = new System.Drawing.Point(294, 49);
            this.lblProprio.Name = "lblProprio";
            this.lblProprio.Size = new System.Drawing.Size(60, 13);
            this.lblProprio.TabIndex = 13;
            this.lblProprio.Text = "&Propriétaire";
            this.lblProprio.Click += new System.EventHandler(this.lblProprio_Click);
            // 
            // tbNomProprio
            // 
            this.tbNomProprio.Enabled = false;
            this.tbNomProprio.Location = new System.Drawing.Point(473, 46);
            this.tbNomProprio.Name = "tbNomProprio";
            this.tbNomProprio.ReadOnly = true;
            this.tbNomProprio.Size = new System.Drawing.Size(268, 20);
            this.tbNomProprio.TabIndex = 15;
            // 
            // tbNomLocataire
            // 
            this.tbNomLocataire.Enabled = false;
            this.tbNomLocataire.Location = new System.Drawing.Point(473, 20);
            this.tbNomLocataire.Name = "tbNomLocataire";
            this.tbNomLocataire.ReadOnly = true;
            this.tbNomLocataire.Size = new System.Drawing.Size(268, 20);
            this.tbNomLocataire.TabIndex = 16;
            // 
            // btnDelete
            // 
            this.btnDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnDelete.ImageKey = "stop.png";
            this.btnDelete.ImageList = this.imageList;
            this.btnDelete.Location = new System.Drawing.Point(323, 4);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(80, 25);
            this.btnDelete.TabIndex = 118;
            this.btnDelete.Text = "&Annuler";
            this.btnDelete.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnPrint.ImageKey = "print.png";
            this.btnPrint.ImageList = this.imageList;
            this.btnPrint.Location = new System.Drawing.Point(409, 4);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(80, 25);
            this.btnPrint.TabIndex = 119;
            this.btnPrint.Text = "&Imprimer";
            this.btnPrint.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // ListeQuittanceForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(784, 679);
            this.Name = "ListeQuittanceForm";
            this.Text = "Quittances du mois";
            this.Load += new System.EventHandler(this.ListeQuittanceForm_Load);
            this.panelButton.ResumeLayout(false);
            this.gbHeader.ResumeLayout(false);
            this.gbHeader.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dateDebut;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbRefLocataire;
        private System.Windows.Forms.Label lblLocataire;
        private System.Windows.Forms.TextBox tbRefProprio;
        private System.Windows.Forms.Label lblProprio;
        private System.Windows.Forms.TextBox tbNomProprio;
        private System.Windows.Forms.TextBox tbNomLocataire;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnPrint;
    }
}
