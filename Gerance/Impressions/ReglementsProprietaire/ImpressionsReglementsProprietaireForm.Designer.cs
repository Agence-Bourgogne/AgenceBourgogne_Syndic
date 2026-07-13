namespace Gerance.Impressions.ReglementsProprietaire
{
    partial class ImpressionsReglementsProprietaireForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ImpressionsReglementsProprietaireForm));
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource2 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource3 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource4 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource5 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource6 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource7 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource8 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
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
            // dtFin
            // 
            this.dtFin.Location = new System.Drawing.Point(205, 19);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(178, 22);
            // 
            // dtDebut
            // 
            this.dtDebut.Location = new System.Drawing.Point(85, 19);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(4, 22);
            this.label1.Size = new System.Drawing.Size(78, 13);
            this.label1.Text = "&Réglements du";
            // 
            // btnExport
            // 
            this.btnExport.ImageKey = "add.png";
            this.btnExport.Text = "&Mise à Jour";
            this.toolTip1.SetToolTip(this.btnExport, "Enregistrement des Ecriture de Réglements\r\nsur les comptes Proprietaires.\r\n");
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
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Gerance.Impressions.ReglementsProprietaire.ListeVirementsLoyers.rdlc";
            // 
            // ImpressionsReglementsProprietaireForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(784, 679);
            this.Name = "ImpressionsReglementsProprietaireForm";
            this.Text = "Impression Règlements Propriétaires";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ImpressionsReglementsProprietaireForm_FormClosing);
            this.Load += new System.EventHandler(this.ImpressionsReglementsProprietaireForm_Load);
            this.panelButton.ResumeLayout(false);
            this.gbHeader.ResumeLayout(false);
            this.gbHeader.PerformLayout();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.ToolTip toolTip1;
    }
}
