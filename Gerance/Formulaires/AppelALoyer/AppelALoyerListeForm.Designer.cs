namespace Gerance.Formulaires.AppelALoyer
{
    partial class AppelALoyerListeForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AppelALoyerListeForm));
            this.dateFin = new System.Windows.Forms.DateTimePicker();
            this.dateDebut = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dateFinTrimestre = new System.Windows.Forms.DateTimePicker();
            this.ckLoyer = new System.Windows.Forms.CheckBox();
            this.cbMonth = new System.Windows.Forms.ComboBox();
            this.lblLocataire = new System.Windows.Forms.Label();
            this.tbRefLocataire = new System.Windows.Forms.TextBox();
            this.tbNomLocataire = new System.Windows.Forms.TextBox();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.btnListe = new System.Windows.Forms.Button();
            this.tbRefImmeuble = new System.Windows.Forms.TextBox();
            this.lblImmeuble = new System.Windows.Forms.Label();
            this.tbNomImmeuble = new System.Windows.Forms.TextBox();
            this.cbType = new System.Windows.Forms.ComboBox();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.ckGul = new System.Windows.Forms.CheckBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.ckNullLoyer = new System.Windows.Forms.CheckBox();
            this.panelButton.SuspendLayout();
            this.gbHeader.SuspendLayout();
            this.gbFactures.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelButton
            // 
            this.panelButton.Controls.Add(this.btnUpdate);
            this.panelButton.Controls.Add(this.btnListe);
            this.panelButton.Location = new System.Drawing.Point(12, 644);
            this.panelButton.Controls.SetChildIndex(this.btnQuit, 0);
            this.panelButton.Controls.SetChildIndex(this.btnEnter, 0);
            this.panelButton.Controls.SetChildIndex(this.btnGrid, 0);
            this.panelButton.Controls.SetChildIndex(this.btnExport, 0);
            this.panelButton.Controls.SetChildIndex(this.btnDetail, 0);
            this.panelButton.Controls.SetChildIndex(this.btnListe, 0);
            this.panelButton.Controls.SetChildIndex(this.btnUpdate, 0);
            // 
            // btnEnter
            // 
            this.btnEnter.Size = new System.Drawing.Size(0, 23);
            // 
            // gbHeader
            // 
            this.gbHeader.Controls.Add(this.ckNullLoyer);
            this.gbHeader.Controls.Add(this.ckGul);
            this.gbHeader.Controls.Add(this.cbType);
            this.gbHeader.Controls.Add(this.tbNomImmeuble);
            this.gbHeader.Controls.Add(this.tbRefImmeuble);
            this.gbHeader.Controls.Add(this.lblImmeuble);
            this.gbHeader.Controls.Add(this.tbNomLocataire);
            this.gbHeader.Controls.Add(this.tbRefLocataire);
            this.gbHeader.Controls.Add(this.lblLocataire);
            this.gbHeader.Controls.Add(this.cbMonth);
            this.gbHeader.Controls.Add(this.ckLoyer);
            this.gbHeader.Controls.Add(this.label3);
            this.gbHeader.Controls.Add(this.dateFinTrimestre);
            this.gbHeader.Controls.Add(this.label2);
            this.gbHeader.Controls.Add(this.label1);
            this.gbHeader.Controls.Add(this.dateFin);
            this.gbHeader.Controls.Add(this.dateDebut);
            this.gbHeader.Size = new System.Drawing.Size(760, 113);
            this.gbHeader.TabIndex = 0;
            this.gbHeader.Text = "Filtrer la Liste";
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
            this.imageList.Images.SetKeyName(12, "bulle_repart.png");
            this.imageList.Images.SetKeyName(13, "edit.png");
            // 
            // btnExport
            // 
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // btnGrid
            // 
            this.btnGrid.ImageIndex = 11;
            this.btnGrid.Text = "&Rapport";
            this.btnGrid.Click += new System.EventHandler(this.btnGrid_Click);
            // 
            // gbFactures
            // 
            this.gbFactures.Controls.Add(this.reportViewer1);
            this.gbFactures.Location = new System.Drawing.Point(12, 131);
            this.gbFactures.Size = new System.Drawing.Size(760, 497);
            this.gbFactures.Controls.SetChildIndex(this.reportViewer1, 0);
            // 
            // dateFin
            // 
            this.dateFin.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateFin.Location = new System.Drawing.Point(439, 25);
            this.dateFin.Name = "dateFin";
            this.dateFin.Size = new System.Drawing.Size(97, 20);
            this.dateFin.TabIndex = 4;
            // 
            // dateDebut
            // 
            this.dateDebut.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateDebut.Location = new System.Drawing.Point(251, 25);
            this.dateDebut.Name = "dateDebut";
            this.dateDebut.Size = new System.Drawing.Size(97, 20);
            this.dateDebut.TabIndex = 2;
            this.dateDebut.Validating += new System.ComponentModel.CancelEventHandler(this.dateDebut_Validating);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(209, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Début";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(363, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "&Fin (Mensuel)";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(556, 28);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Fin (&Trimestriel)";
            // 
            // dateFinTrimestre
            // 
            this.dateFinTrimestre.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateFinTrimestre.Location = new System.Drawing.Point(637, 25);
            this.dateFinTrimestre.Name = "dateFinTrimestre";
            this.dateFinTrimestre.Size = new System.Drawing.Size(97, 20);
            this.dateFinTrimestre.TabIndex = 6;
            // 
            // ckLoyer
            // 
            this.ckLoyer.AutoSize = true;
            this.ckLoyer.Location = new System.Drawing.Point(14, 55);
            this.ckLoyer.Name = "ckLoyer";
            this.ckLoyer.Size = new System.Drawing.Size(119, 17);
            this.ckLoyer.TabIndex = 7;
            this.ckLoyer.Text = "Loyers à &augmenter";
            this.ckLoyer.UseVisualStyleBackColor = true;
            this.ckLoyer.CheckedChanged += new System.EventHandler(this.ckLoyer_CheckedChanged);
            // 
            // cbMonth
            // 
            this.cbMonth.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbMonth.Enabled = false;
            this.cbMonth.FormattingEnabled = true;
            this.cbMonth.Location = new System.Drawing.Point(212, 51);
            this.cbMonth.Name = "cbMonth";
            this.cbMonth.Size = new System.Drawing.Size(136, 21);
            this.cbMonth.TabIndex = 8;
            this.cbMonth.SelectedIndexChanged += new System.EventHandler(this.cbMonth_SelectedIndexChanged);
            // 
            // lblLocataire
            // 
            this.lblLocataire.AutoSize = true;
            this.lblLocataire.ForeColor = System.Drawing.Color.Blue;
            this.lblLocataire.Location = new System.Drawing.Point(363, 54);
            this.lblLocataire.Name = "lblLocataire";
            this.lblLocataire.Size = new System.Drawing.Size(51, 13);
            this.lblLocataire.TabIndex = 9;
            this.lblLocataire.Text = "&Locataire";
            this.lblLocataire.Click += new System.EventHandler(this.lblLocataire_Click);
            // 
            // tbRefLocataire
            // 
            this.tbRefLocataire.Location = new System.Drawing.Point(439, 51);
            this.tbRefLocataire.Name = "tbRefLocataire";
            this.tbRefLocataire.Size = new System.Drawing.Size(97, 20);
            this.tbRefLocataire.TabIndex = 10;
            this.tbRefLocataire.KeyDown += new System.Windows.Forms.KeyEventHandler(this.standard_KeyDown);
            this.tbRefLocataire.Validating += new System.ComponentModel.CancelEventHandler(this.tbRefLocataire_Validating);
            // 
            // tbNomLocataire
            // 
            this.tbNomLocataire.Location = new System.Drawing.Point(559, 52);
            this.tbNomLocataire.Name = "tbNomLocataire";
            this.tbNomLocataire.Size = new System.Drawing.Size(175, 20);
            this.tbNomLocataire.TabIndex = 11;
            this.tbNomLocataire.Validating += new System.ComponentModel.CancelEventHandler(this.tbNomLocataire_Validating);
            // 
            // reportViewer1
            // 
            this.reportViewer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.reportViewer1.IsDocumentMapWidthFixed = true;
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "EspaceSyndic.Impressions.RelevesIndividuels.ReleveIndivMasterReport.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(23, 19);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.PageCountMode = Microsoft.Reporting.WinForms.PageCountMode.Actual;
            this.reportViewer1.ShowFindControls = false;
            this.reportViewer1.Size = new System.Drawing.Size(732, 435);
            this.reportViewer1.TabIndex = 11;
            // 
            // btnListe
            // 
            this.btnListe.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnListe.ImageIndex = 12;
            this.btnListe.ImageList = this.imageList;
            this.btnListe.Location = new System.Drawing.Point(323, 4);
            this.btnListe.Name = "btnListe";
            this.btnListe.Size = new System.Drawing.Size(100, 25);
            this.btnListe.TabIndex = 19;
            this.btnListe.Text = "L&iste";
            this.btnListe.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnListe.UseVisualStyleBackColor = true;
            this.btnListe.Click += new System.EventHandler(this.btnListe_Click);
            // 
            // tbRefImmeuble
            // 
            this.tbRefImmeuble.Location = new System.Drawing.Point(439, 77);
            this.tbRefImmeuble.Name = "tbRefImmeuble";
            this.tbRefImmeuble.Size = new System.Drawing.Size(97, 20);
            this.tbRefImmeuble.TabIndex = 13;
            this.tbRefImmeuble.KeyDown += new System.Windows.Forms.KeyEventHandler(this.standard_KeyDown);
            this.tbRefImmeuble.Validating += new System.ComponentModel.CancelEventHandler(this.tbRefImmeuble_Validating);
            // 
            // lblImmeuble
            // 
            this.lblImmeuble.AutoSize = true;
            this.lblImmeuble.ForeColor = System.Drawing.Color.Blue;
            this.lblImmeuble.Location = new System.Drawing.Point(363, 80);
            this.lblImmeuble.Name = "lblImmeuble";
            this.lblImmeuble.Size = new System.Drawing.Size(52, 13);
            this.lblImmeuble.TabIndex = 12;
            this.lblImmeuble.Text = "&Immeuble";
            this.lblImmeuble.Click += new System.EventHandler(this.lblImmeuble_Click);
            // 
            // tbNomImmeuble
            // 
            this.tbNomImmeuble.Location = new System.Drawing.Point(559, 77);
            this.tbNomImmeuble.Name = "tbNomImmeuble";
            this.tbNomImmeuble.Size = new System.Drawing.Size(175, 20);
            this.tbNomImmeuble.TabIndex = 14;
            this.tbNomImmeuble.Validating += new System.ComponentModel.CancelEventHandler(this.tbNomImmeuble_Validating);
            // 
            // cbType
            // 
            this.cbType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbType.FormattingEnabled = true;
            this.cbType.Location = new System.Drawing.Point(14, 24);
            this.cbType.Name = "cbType";
            this.cbType.Size = new System.Drawing.Size(164, 21);
            this.cbType.TabIndex = 0;
            this.cbType.SelectedIndexChanged += new System.EventHandler(this.cbType_SelectedIndexChanged);
            // 
            // btnUpdate
            // 
            this.btnUpdate.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnUpdate.ImageIndex = 13;
            this.btnUpdate.ImageList = this.imageList;
            this.btnUpdate.Location = new System.Drawing.Point(429, 4);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(100, 25);
            this.btnUpdate.TabIndex = 20;
            this.btnUpdate.Text = "Ma&j Dossiers";
            this.btnUpdate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.toolTip1.SetToolTip(this.btnUpdate, "Mise à jour des biens \r\nGénération des quittances\r\nMise à jour des soldes Locatai" +
        "res");
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // ckGul
            // 
            this.ckGul.AutoSize = true;
            this.ckGul.Location = new System.Drawing.Point(14, 80);
            this.ckGul.Name = "ckGul";
            this.ckGul.Size = new System.Drawing.Size(52, 17);
            this.ckGul.TabIndex = 53;
            this.ckGul.Text = "&G.L.I.";
            this.toolTip1.SetToolTip(this.ckGul, "Garantie Loyer Impayés");
            this.ckGul.UseVisualStyleBackColor = true;
            this.ckGul.CheckedChanged += new System.EventHandler(this.ckGul_CheckedChanged);
            // 
            // ckNullLoyer
            // 
            this.ckNullLoyer.AutoSize = true;
            this.ckNullLoyer.Checked = true;
            this.ckNullLoyer.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ckNullLoyer.Location = new System.Drawing.Point(212, 80);
            this.ckNullLoyer.Name = "ckNullLoyer";
            this.ckNullLoyer.Size = new System.Drawing.Size(75, 17);
            this.ckNullLoyer.TabIndex = 54;
            this.ckNullLoyer.Text = "Loyers > 0";
            this.toolTip1.SetToolTip(this.ckNullLoyer, "Garantie Loyer Impayés");
            this.ckNullLoyer.UseVisualStyleBackColor = true;
            this.ckNullLoyer.CheckedChanged += new System.EventHandler(this.ckNullLoyer_CheckedChanged_1);
            // 
            // AppelALoyerListeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(784, 691);
            this.Name = "AppelALoyerListeForm";
            this.Text = "Appel A Loyer";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AppelALoyerListeForm_FormClosing);
            this.Load += new System.EventHandler(this.AppelALoyerListeForm_Load);
            this.panelButton.ResumeLayout(false);
            this.gbHeader.ResumeLayout(false);
            this.gbHeader.PerformLayout();
            this.gbFactures.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dateFinTrimestre;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dateFin;
        private System.Windows.Forms.DateTimePicker dateDebut;
        private System.Windows.Forms.CheckBox ckLoyer;
        private System.Windows.Forms.ComboBox cbMonth;
        private System.Windows.Forms.TextBox tbNomLocataire;
        private System.Windows.Forms.TextBox tbRefLocataire;
        private System.Windows.Forms.Label lblLocataire;
        private System.Windows.Forms.Button btnListe;
        private System.Windows.Forms.TextBox tbRefImmeuble;
        private System.Windows.Forms.Label lblImmeuble;
        private System.Windows.Forms.TextBox tbNomImmeuble;
        private System.Windows.Forms.ComboBox cbType;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.CheckBox ckGul;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.CheckBox ckNullLoyer;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
    }
}
