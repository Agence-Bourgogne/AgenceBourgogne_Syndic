namespace Gerance.Formulaires.Common
{
    partial class CommonRapportForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CommonRapportForm));
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.panelButton = new System.Windows.Forms.Panel();
            this.btnExport = new System.Windows.Forms.Button();
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.btnEnter = new System.Windows.Forms.Button();
            this.btnRapport = new System.Windows.Forms.Button();
            this.btnQuit = new System.Windows.Forms.Button();
            this.gbHeader = new System.Windows.Forms.GroupBox();
            this.dtEdition = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.dtFin = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.dtDebut = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.panelButton.SuspendLayout();
            this.gbHeader.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelButton
            // 
            this.panelButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelButton.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panelButton.Controls.Add(this.btnExport);
            this.panelButton.Controls.Add(this.btnEnter);
            this.panelButton.Controls.Add(this.btnRapport);
            this.panelButton.Controls.Add(this.btnQuit);
            this.panelButton.Location = new System.Drawing.Point(12, 632);
            this.panelButton.Name = "panelButton";
            this.panelButton.Size = new System.Drawing.Size(760, 35);
            this.panelButton.TabIndex = 3;
            // 
            // btnExport
            // 
            this.btnExport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnExport.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnExport.ImageKey = "excel.png";
            this.btnExport.ImageList = this.imageList;
            this.btnExport.Location = new System.Drawing.Point(112, 4);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(100, 25);
            this.btnExport.TabIndex = 90;
            this.btnExport.Text = "E&xporter";
            this.btnExport.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExport.UseVisualStyleBackColor = true;
            // 
            // imageList
            // 
            this.imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList.ImageStream")));
            this.imageList.TransparentColor = System.Drawing.Color.Silver;
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
            // btnEnter
            // 
            this.btnEnter.Location = new System.Drawing.Point(341, 4);
            this.btnEnter.Name = "btnEnter";
            this.btnEnter.Size = new System.Drawing.Size(75, 23);
            this.btnEnter.TabIndex = 1;
            this.btnEnter.Text = "button1";
            this.btnEnter.UseVisualStyleBackColor = true;
            this.btnEnter.Click += new System.EventHandler(this.btnEnter_Click);
            // 
            // btnRapport
            // 
            this.btnRapport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnRapport.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnRapport.ImageIndex = 6;
            this.btnRapport.ImageList = this.imageList;
            this.btnRapport.Location = new System.Drawing.Point(6, 4);
            this.btnRapport.Name = "btnRapport";
            this.btnRapport.Size = new System.Drawing.Size(100, 25);
            this.btnRapport.TabIndex = 0;
            this.btnRapport.Text = "&Rapport";
            this.btnRapport.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRapport.UseVisualStyleBackColor = true;
            // 
            // btnQuit
            // 
            this.btnQuit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnQuit.CausesValidation = false;
            this.btnQuit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnQuit.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnQuit.ImageIndex = 5;
            this.btnQuit.ImageList = this.imageList;
            this.btnQuit.Location = new System.Drawing.Point(653, 4);
            this.btnQuit.Name = "btnQuit";
            this.btnQuit.Size = new System.Drawing.Size(100, 25);
            this.btnQuit.TabIndex = 2;
            this.btnQuit.Text = "&Quitter";
            this.btnQuit.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnQuit.UseVisualStyleBackColor = true;
            // 
            // gbHeader
            // 
            this.gbHeader.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbHeader.Controls.Add(this.dtEdition);
            this.gbHeader.Controls.Add(this.label3);
            this.gbHeader.Controls.Add(this.dtFin);
            this.gbHeader.Controls.Add(this.label2);
            this.gbHeader.Controls.Add(this.dtDebut);
            this.gbHeader.Controls.Add(this.label1);
            this.gbHeader.Location = new System.Drawing.Point(12, 12);
            this.gbHeader.Name = "gbHeader";
            this.gbHeader.Size = new System.Drawing.Size(760, 57);
            this.gbHeader.TabIndex = 2;
            this.gbHeader.TabStop = false;
            // 
            // dtEdition
            // 
            this.dtEdition.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtEdition.Location = new System.Drawing.Point(660, 19);
            this.dtEdition.Name = "dtEdition";
            this.dtEdition.Size = new System.Drawing.Size(85, 20);
            this.dtEdition.TabIndex = 10;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(615, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(39, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "&Edition";
            // 
            // dtFin
            // 
            this.dtFin.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtFin.Location = new System.Drawing.Point(524, 19);
            this.dtFin.Name = "dtFin";
            this.dtFin.Size = new System.Drawing.Size(85, 20);
            this.dtFin.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(497, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(21, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "&Fin";
            // 
            // dtDebut
            // 
            this.dtDebut.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtDebut.Location = new System.Drawing.Point(404, 19);
            this.dtDebut.Name = "dtDebut";
            this.dtDebut.Size = new System.Drawing.Size(85, 20);
            this.dtDebut.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(355, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "&Début ";
            // 
            // reportViewer1
            // 
            this.reportViewer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.reportViewer1.IsDocumentMapWidthFixed = true;
            reportDataSource1.Name = "immeuble_copro";
            reportDataSource1.Value = null;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "EspaceSyndic.Impressions.RelevesIndividuels.ReleveIndivMasterReport.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(13, 74);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.PageCountMode = Microsoft.Reporting.WinForms.PageCountMode.Actual;
            this.reportViewer1.ShowFindControls = false;
            this.reportViewer1.Size = new System.Drawing.Size(759, 552);
            this.reportViewer1.TabIndex = 10;
            // 
            // CommonRapportForm
            // 
            this.AcceptButton = this.btnEnter;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnQuit;
            this.ClientSize = new System.Drawing.Size(784, 679);
            this.Controls.Add(this.reportViewer1);
            this.Controls.Add(this.panelButton);
            this.Controls.Add(this.gbHeader);
            this.Name = "CommonRapportForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CommonRapportListeForm";
            this.Load += new System.EventHandler(this.CommonRapportListeForm_Load);
            this.panelButton.ResumeLayout(false);
            this.gbHeader.ResumeLayout(false);
            this.gbHeader.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        protected System.Windows.Forms.Panel panelButton;
        protected System.Windows.Forms.Button btnEnter;
        protected System.Windows.Forms.Button btnRapport;
        protected System.Windows.Forms.Button btnQuit;
        protected System.Windows.Forms.GroupBox gbHeader;
        protected System.Windows.Forms.DateTimePicker dtEdition;
        protected System.Windows.Forms.Label label3;
        protected System.Windows.Forms.DateTimePicker dtFin;
        protected System.Windows.Forms.Label label2;
        protected System.Windows.Forms.DateTimePicker dtDebut;
        protected System.Windows.Forms.Label label1;
        protected System.Windows.Forms.Button btnExport;
        public System.Windows.Forms.ImageList imageList;
        protected Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
    }
}