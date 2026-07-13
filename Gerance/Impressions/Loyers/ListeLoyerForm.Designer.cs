namespace Gerance.Impressions.Loyers
{
    partial class ListeLoyerForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ListeLoyerForm));
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource2 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource3 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource4 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource5 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource6 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource7 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource8 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.tbRefLocataire = new System.Windows.Forms.TextBox();
            this.lblRefLocataire = new System.Windows.Forms.Label();
            this.panelButton.SuspendLayout();
            this.gbHeader.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnEnter
            // 
            this.btnEnter.Size = new System.Drawing.Size(0, 23);
            // 
            // btnRapport
            // 
            this.btnRapport.Click += new System.EventHandler(this.btnRapport_Click);
            // 
            // gbHeader
            // 
            this.gbHeader.Controls.Add(this.tbRefLocataire);
            this.gbHeader.Controls.Add(this.lblRefLocataire);
            this.gbHeader.TabIndex = 0;
            this.gbHeader.Controls.SetChildIndex(this.label1, 0);
            this.gbHeader.Controls.SetChildIndex(this.dtDebut, 0);
            this.gbHeader.Controls.SetChildIndex(this.label2, 0);
            this.gbHeader.Controls.SetChildIndex(this.dtFin, 0);
            this.gbHeader.Controls.SetChildIndex(this.label3, 0);
            this.gbHeader.Controls.SetChildIndex(this.dtEdition, 0);
            this.gbHeader.Controls.SetChildIndex(this.lblRefLocataire, 0);
            this.gbHeader.Controls.SetChildIndex(this.tbRefLocataire, 0);
            // 
            // dtEdition
            // 
            this.dtEdition.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.TabIndex = 6;
            // 
            // dtFin
            // 
            this.dtFin.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.TabIndex = 4;
            // 
            // dtDebut
            // 
            this.dtDebut.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.TabIndex = 2;
            // 
            // btnExport
            // 
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
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
            // 
            // reportViewer1
            // 
            reportDataSource1.Name = "immeuble_copro";
            reportDataSource1.Value = null;
            reportDataSource2.Name = "immeuble_copro";
            reportDataSource2.Value = null;
            reportDataSource3.Name = "immeuble_copro";
            reportDataSource3.Value = null;
            reportDataSource4.Name = "immeuble_copro";
            reportDataSource4.Value = null;
            reportDataSource5.Name = "immeuble_copro";
            reportDataSource5.Value = null;
            reportDataSource6.Name = "immeuble_copro";
            reportDataSource6.Value = null;
            reportDataSource7.Name = "immeuble_copro";
            reportDataSource7.Value = null;
            reportDataSource8.Name = "immeuble_copro";
            reportDataSource8.Value = null;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource2);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource3);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource4);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource5);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource6);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource7);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource8);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Gerance.Impressions.Loyers.ListeLoyerReport.rdlc";
            this.reportViewer1.TabIndex = 1;
            // 
            // tbRefLocataire
            // 
            this.tbRefLocataire.Location = new System.Drawing.Point(102, 19);
            this.tbRefLocataire.Name = "tbRefLocataire";
            this.tbRefLocataire.Size = new System.Drawing.Size(100, 20);
            this.tbRefLocataire.TabIndex = 1;
            this.tbRefLocataire.KeyUp += new System.Windows.Forms.KeyEventHandler(this.tbRefLocataire_KeyUp);
            this.tbRefLocataire.Validating += new System.ComponentModel.CancelEventHandler(this.tbRefLocataire_Validating);
            // 
            // lblRefLocataire
            // 
            this.lblRefLocataire.AutoSize = true;
            this.lblRefLocataire.ForeColor = System.Drawing.Color.Blue;
            this.lblRefLocataire.Location = new System.Drawing.Point(17, 22);
            this.lblRefLocataire.Name = "lblRefLocataire";
            this.lblRefLocataire.Size = new System.Drawing.Size(74, 13);
            this.lblRefLocataire.TabIndex = 0;
            this.lblRefLocataire.Text = "Réf. &Locataire";
            this.lblRefLocataire.Click += new System.EventHandler(this.lblRefLocataire_Click);
            // 
            // ListeLoyerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(784, 679);
            this.Name = "ListeLoyerForm";
            this.Text = "Liste Loyers";
            this.Load += new System.EventHandler(this.ListeLoyerForm_Load);
            this.panelButton.ResumeLayout(false);
            this.gbHeader.ResumeLayout(false);
            this.gbHeader.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox tbRefLocataire;
        private System.Windows.Forms.Label lblRefLocataire;
    }
}
