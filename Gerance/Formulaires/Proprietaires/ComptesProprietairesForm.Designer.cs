namespace Gerance.Formulaires.Proprietaires
{
    partial class ComptesProprietairesForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ComptesProprietairesForm));
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource2 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource3 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource4 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource5 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource6 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource7 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource8 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource9 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource10 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource11 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource12 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource13 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource14 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource15 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource16 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.lblProprio = new System.Windows.Forms.Label();
            this.tbRefProprio = new System.Windows.Forms.TextBox();
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
            // gbHeader
            // 
            this.gbHeader.Controls.Add(this.lblProprio);
            this.gbHeader.Controls.Add(this.tbRefProprio);
            this.gbHeader.TabIndex = 0;
            this.gbHeader.Controls.SetChildIndex(this.label1, 0);
            this.gbHeader.Controls.SetChildIndex(this.dtDebut, 0);
            this.gbHeader.Controls.SetChildIndex(this.label2, 0);
            this.gbHeader.Controls.SetChildIndex(this.dtFin, 0);
            this.gbHeader.Controls.SetChildIndex(this.label3, 0);
            this.gbHeader.Controls.SetChildIndex(this.dtEdition, 0);
            this.gbHeader.Controls.SetChildIndex(this.tbRefProprio, 0);
            this.gbHeader.Controls.SetChildIndex(this.lblProprio, 0);
            // 
            // dtDebut
            // 
            this.dtDebut.ValueChanged += new System.EventHandler(this.dtDebut_ValueChanged);
            // 
            // btnExport
            // 
            this.btnExport.ImageKey = "add.png";
            this.btnExport.Text = "&Mise à Jour";
            this.toolTip1.SetToolTip(this.btnExport, "Mise à Jour des comptes Propriétaires\r\n\r\nLoyers(Réglements Locataires)- Déduction" +
        "s Diverses (Factures)\r\n");
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
            reportDataSource9.Name = "immeuble_copro";
            reportDataSource9.Value = null;
            reportDataSource10.Name = "immeuble_copro";
            reportDataSource10.Value = null;
            reportDataSource11.Name = "immeuble_copro";
            reportDataSource11.Value = null;
            reportDataSource12.Name = "immeuble_copro";
            reportDataSource12.Value = null;
            reportDataSource13.Name = "immeuble_copro";
            reportDataSource13.Value = null;
            reportDataSource14.Name = "immeuble_copro";
            reportDataSource14.Value = null;
            reportDataSource15.Name = "immeuble_copro";
            reportDataSource15.Value = null;
            reportDataSource16.Name = "immeuble_copro";
            reportDataSource16.Value = null;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource2);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource3);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource4);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource5);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource6);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource7);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource8);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource9);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource10);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource11);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource12);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource13);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource14);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource15);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource16);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Gerance.Formulaires.Proprietaires.Impressions.CompteProprioMasterReport.rdlc";
            // 
            // lblProprio
            // 
            this.lblProprio.AutoSize = true;
            this.lblProprio.ForeColor = System.Drawing.Color.Blue;
            this.lblProprio.Location = new System.Drawing.Point(18, 22);
            this.lblProprio.Name = "lblProprio";
            this.lblProprio.Size = new System.Drawing.Size(60, 13);
            this.lblProprio.TabIndex = 0;
            this.lblProprio.Text = "Propriétaire";
            this.lblProprio.Click += new System.EventHandler(this.lblProprio_Click);
            // 
            // tbRefProprio
            // 
            this.tbRefProprio.Location = new System.Drawing.Point(103, 19);
            this.tbRefProprio.Name = "tbRefProprio";
            this.tbRefProprio.Size = new System.Drawing.Size(100, 20);
            this.tbRefProprio.TabIndex = 1;
            this.tbRefProprio.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbRefProprio_KeyDown);
            this.tbRefProprio.Validating += new System.ComponentModel.CancelEventHandler(this.tbRefProprio_Validating);
            // 
            // ComptesProprietairesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(784, 679);
            this.Name = "ComptesProprietairesForm";
            this.Text = "Comptes Proprietaires";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ComptesProprietairesForm_FormClosing);
            this.Load += new System.EventHandler(this.CompteProprietaireForm_Load);
            this.panelButton.ResumeLayout(false);
            this.gbHeader.ResumeLayout(false);
            this.gbHeader.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        protected System.Windows.Forms.Label lblProprio;
        protected System.Windows.Forms.TextBox tbRefProprio;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}
