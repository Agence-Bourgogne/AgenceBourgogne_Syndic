namespace Gerance.Impressions.CompteLocataire
{
    partial class CompteLocataireForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CompteLocataireForm));
            this.btnPrint = new System.Windows.Forms.Button();
            this.tbRefLocataire = new System.Windows.Forms.TextBox();
            this.lblRefLocataire = new System.Windows.Forms.Label();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.panelButton.SuspendLayout();
            this.gbHeader.SuspendLayout();
            this.gbFactures.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelButton
            // 
            this.panelButton.Controls.Add(this.btnPrint);
            this.panelButton.Controls.SetChildIndex(this.btnQuit, 0);
            this.panelButton.Controls.SetChildIndex(this.btnEnter, 0);
            this.panelButton.Controls.SetChildIndex(this.btnGrid, 0);
            this.panelButton.Controls.SetChildIndex(this.btnExport, 0);
            this.panelButton.Controls.SetChildIndex(this.btnDetail, 0);
            this.panelButton.Controls.SetChildIndex(this.btnPrint, 0);
            // 
            // btnEnter
            // 
            this.btnEnter.Size = new System.Drawing.Size(0, 23);
            // 
            // gbHeader
            // 
            this.gbHeader.Controls.Add(this.tbRefLocataire);
            this.gbHeader.Controls.Add(this.lblRefLocataire);
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
            this.imageList.Images.SetKeyName(11, "print.png");
            // 
            // gbFactures
            // 
            this.gbFactures.Controls.Add(this.reportViewer1);
            this.gbFactures.Controls.SetChildIndex(this.reportViewer1, 0);
            // 
            // btnPrint
            // 
            this.btnPrint.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnPrint.ImageIndex = 11;
            this.btnPrint.ImageList = this.imageList;
            this.btnPrint.Location = new System.Drawing.Point(323, 4);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(80, 25);
            this.btnPrint.TabIndex = 118;
            this.btnPrint.Text = "&Rapport";
            this.btnPrint.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // tbRefLocataire
            // 
            this.tbRefLocataire.Location = new System.Drawing.Point(96, 24);
            this.tbRefLocataire.Name = "tbRefLocataire";
            this.tbRefLocataire.Size = new System.Drawing.Size(100, 20);
            this.tbRefLocataire.TabIndex = 3;
            this.tbRefLocataire.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbRefLocataire_KeyDown);
            this.tbRefLocataire.Validating += new System.ComponentModel.CancelEventHandler(this.tbRefLocataire_Validating);
            // 
            // lblRefLocataire
            // 
            this.lblRefLocataire.AutoSize = true;
            this.lblRefLocataire.ForeColor = System.Drawing.Color.Blue;
            this.lblRefLocataire.Location = new System.Drawing.Point(11, 27);
            this.lblRefLocataire.Name = "lblRefLocataire";
            this.lblRefLocataire.Size = new System.Drawing.Size(74, 13);
            this.lblRefLocataire.TabIndex = 2;
            this.lblRefLocataire.Text = "Réf. &Locataire";
            this.lblRefLocataire.Click += new System.EventHandler(this.lblRefLocataire_Click);
            // 
            // reportViewer1
            // 
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Gerance.Impressions.CompteLocataire.CompteLocataireReport.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(182, 147);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(396, 246);
            this.reportViewer1.TabIndex = 2;
            // 
            // CompteLocataireForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(784, 679);
            this.Name = "CompteLocataireForm";
            this.Text = "Comptes Locataires";
            this.Load += new System.EventHandler(this.CompteLocataireForm_Load);
            this.panelButton.ResumeLayout(false);
            this.gbHeader.ResumeLayout(false);
            this.gbHeader.PerformLayout();
            this.gbFactures.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        protected System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.TextBox tbRefLocataire;
        private System.Windows.Forms.Label lblRefLocataire;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
    }
}
