namespace Gerance.Impressions.CompteProprietaire
{
    partial class ImpressionCompteProprietaireForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ImpressionCompteProprietaireForm));
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.lblProprio = new System.Windows.Forms.Label();
            this.tbRefProprio = new System.Windows.Forms.TextBox();
            this.btnPrint = new System.Windows.Forms.Button();
            this.panelButton.SuspendLayout();
            this.gbHeader.SuspendLayout();
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
            this.btnEnter.TabIndex = 3;
            // 
            // btnQuit
            // 
            this.btnQuit.TabIndex = 4;
            // 
            // gbHeader
            // 
            this.gbHeader.Controls.Add(this.lblProprio);
            this.gbHeader.Controls.Add(this.tbRefProprio);
            this.gbHeader.TabIndex = 0;
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
            // btnDetail
            // 
            this.btnDetail.TabIndex = 2;
            // 
            // btnExport
            // 
            this.btnExport.TabIndex = 1;
            // 
            // btnGrid
            // 
            this.btnGrid.TabIndex = 0;
            // 
            // gbFactures
            // 
            this.gbFactures.TabIndex = 1;
            // 
            // reportViewer1
            // 
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Gerance.Impressions.CompteProprietaire.ImpressionCompteProprietaireReport.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(194, 216);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(396, 246);
            this.reportViewer1.TabIndex = 22;
            // 
            // lblProprio
            // 
            this.lblProprio.AutoSize = true;
            this.lblProprio.ForeColor = System.Drawing.Color.Blue;
            this.lblProprio.Location = new System.Drawing.Point(11, 27);
            this.lblProprio.Name = "lblProprio";
            this.lblProprio.Size = new System.Drawing.Size(60, 13);
            this.lblProprio.TabIndex = 0;
            this.lblProprio.Text = "&Propriétaire";
            this.lblProprio.Click += new System.EventHandler(this.lblProprio_Click);
            // 
            // tbRefProprio
            // 
            this.tbRefProprio.Location = new System.Drawing.Point(96, 24);
            this.tbRefProprio.Name = "tbRefProprio";
            this.tbRefProprio.Size = new System.Drawing.Size(100, 20);
            this.tbRefProprio.TabIndex = 1;
            this.tbRefProprio.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbRefProprio_KeyDown);
            this.tbRefProprio.Validating += new System.ComponentModel.CancelEventHandler(this.tbRefProprio_Validating);
            // 
            // btnPrint
            // 
            this.btnPrint.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnPrint.ImageIndex = 11;
            this.btnPrint.ImageList = this.imageList;
            this.btnPrint.Location = new System.Drawing.Point(323, 4);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(80, 25);
            this.btnPrint.TabIndex = 119;
            this.btnPrint.Text = "&Imprimer";
            this.btnPrint.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // ImpressionCompteProprietaireForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(784, 679);
            this.Controls.Add(this.reportViewer1);
            this.Name = "ImpressionCompteProprietaireForm";
            this.Text = "Impression Comptes Proprietaires";
            this.Load += new System.EventHandler(this.ImpressionCompteProprietaireForm_Load);
            this.Controls.SetChildIndex(this.gbHeader, 0);
            this.Controls.SetChildIndex(this.panelButton, 0);
            this.Controls.SetChildIndex(this.gbFactures, 0);
            this.Controls.SetChildIndex(this.reportViewer1, 0);
            this.panelButton.ResumeLayout(false);
            this.gbHeader.ResumeLayout(false);
            this.gbHeader.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        protected System.Windows.Forms.Label lblProprio;
        protected System.Windows.Forms.TextBox tbRefProprio;
        protected System.Windows.Forms.Button btnPrint;
    }
}
