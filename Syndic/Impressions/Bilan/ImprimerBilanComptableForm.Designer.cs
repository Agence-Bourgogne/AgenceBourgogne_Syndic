namespace EspaceSyndic.Impressions.Bilan
{
    partial class ImprimerBilanComptableForm
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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource2 = new Microsoft.Reporting.WinForms.ReportDataSource();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ImprimerBilanComptableForm));
            this.immeubleBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.dtEdition = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.dtFin = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.dtDebut = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.tbRefImmeuble = new System.Windows.Forms.TextBox();
            this.lblImmeuble = new System.Windows.Forms.Label();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.panelButton = new System.Windows.Forms.Panel();
            this.btnEnter = new System.Windows.Forms.Button();
            this.btnRapport = new System.Windows.Forms.Button();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.btnQuit = new System.Windows.Forms.Button();
            this.btnExport = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.immeubleBindingSource)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.panelButton.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.dtEdition);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.dtFin);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.dtDebut);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.tbRefImmeuble);
            this.groupBox3.Controls.Add(this.lblImmeuble);
            this.groupBox3.Location = new System.Drawing.Point(12, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(760, 57);
            this.groupBox3.TabIndex = 6;
            this.groupBox3.TabStop = false;
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
            this.dtFin.Location = new System.Drawing.Point(470, 19);
            this.dtFin.Name = "dtFin";
            this.dtFin.Size = new System.Drawing.Size(85, 20);
            this.dtFin.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(383, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "&FinTraitement";
            // 
            // dtDebut
            // 
            this.dtDebut.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtDebut.Location = new System.Drawing.Point(275, 19);
            this.dtDebut.Name = "dtDebut";
            this.dtDebut.Size = new System.Drawing.Size(85, 20);
            this.dtDebut.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Blue;
            this.label1.Location = new System.Drawing.Point(180, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "&Début Traitement";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // tbRefImmeuble
            // 
            this.tbRefImmeuble.Location = new System.Drawing.Point(87, 19);
            this.tbRefImmeuble.Name = "tbRefImmeuble";
            this.tbRefImmeuble.Size = new System.Drawing.Size(71, 20);
            this.tbRefImmeuble.TabIndex = 4;
            this.tbRefImmeuble.DoubleClick += new System.EventHandler(this.lblImmeuble_Click);
            this.tbRefImmeuble.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbRefImmeuble_KeyPress);
            this.tbRefImmeuble.Validating += new System.ComponentModel.CancelEventHandler(this.tbRefImmeuble_Validating);
            // 
            // lblImmeuble
            // 
            this.lblImmeuble.AutoSize = true;
            this.lblImmeuble.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblImmeuble.ForeColor = System.Drawing.Color.Blue;
            this.lblImmeuble.Location = new System.Drawing.Point(11, 22);
            this.lblImmeuble.Name = "lblImmeuble";
            this.lblImmeuble.Size = new System.Drawing.Size(55, 13);
            this.lblImmeuble.TabIndex = 3;
            this.lblImmeuble.Text = "&Immeuble:";
            this.lblImmeuble.Click += new System.EventHandler(this.lblImmeuble_Click);
            // 
            // reportViewer1
            // 
            this.reportViewer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.reportViewer1.IsDocumentMapWidthFixed = true;
            reportDataSource2.Name = "Immeuble";
            reportDataSource2.Value = this.immeubleBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource2);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "EspaceSyndic.Impressions.Bilan.ImpressionBilanComptableMasterReport.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(13, 81);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.PageCountMode = Microsoft.Reporting.WinForms.PageCountMode.Actual;
            this.reportViewer1.ShowFindControls = false;
            this.reportViewer1.Size = new System.Drawing.Size(759, 517);
            this.reportViewer1.TabIndex = 7;
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
            this.panelButton.TabIndex = 8;
            // 
            // btnEnter
            // 
            this.btnEnter.Location = new System.Drawing.Point(341, 4);
            this.btnEnter.Name = "btnEnter";
            this.btnEnter.Size = new System.Drawing.Size(75, 23);
            this.btnEnter.TabIndex = 121;
            this.btnEnter.Text = "button1";
            this.btnEnter.UseVisualStyleBackColor = true;
            this.btnEnter.Click += new System.EventHandler(this.btnEnter_Click);
            // 
            // btnRapport
            // 
            this.btnRapport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnRapport.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnRapport.ImageIndex = 6;
            this.btnRapport.ImageList = this.imageList1;
            this.btnRapport.Location = new System.Drawing.Point(6, 4);
            this.btnRapport.Name = "btnRapport";
            this.btnRapport.Size = new System.Drawing.Size(100, 25);
            this.btnRapport.TabIndex = 87;
            this.btnRapport.Text = "&Rapport";
            this.btnRapport.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRapport.UseVisualStyleBackColor = true;
            this.btnRapport.Click += new System.EventHandler(this.btnRapport_Click);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Silver;
            this.imageList1.Images.SetKeyName(0, "top.png");
            this.imageList1.Images.SetKeyName(1, "bottom.png");
            this.imageList1.Images.SetKeyName(2, "previous.png");
            this.imageList1.Images.SetKeyName(3, "next.png");
            this.imageList1.Images.SetKeyName(4, "save.png");
            this.imageList1.Images.SetKeyName(5, "quit.png");
            this.imageList1.Images.SetKeyName(6, "print.png");
            // 
            // btnQuit
            // 
            this.btnQuit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnQuit.CausesValidation = false;
            this.btnQuit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnQuit.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnQuit.ImageIndex = 5;
            this.btnQuit.ImageList = this.imageList1;
            this.btnQuit.Location = new System.Drawing.Point(653, 4);
            this.btnQuit.Name = "btnQuit";
            this.btnQuit.Size = new System.Drawing.Size(100, 25);
            this.btnQuit.TabIndex = 86;
            this.btnQuit.Text = "&Quitter";
            this.btnQuit.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnQuit.UseVisualStyleBackColor = true;
            // 
            // btnExport
            // 
            this.btnExport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnExport.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnExport.ImageIndex = 4;
            this.btnExport.ImageList = this.imageList1;
            this.btnExport.Location = new System.Drawing.Point(112, 4);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(100, 25);
            this.btnExport.TabIndex = 122;
            this.btnExport.Text = "&Export Serveur";
            this.btnExport.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Visible = false;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // ImprimerBilanComptableForm
            // 
            this.AcceptButton = this.btnEnter;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnQuit;
            this.ClientSize = new System.Drawing.Size(784, 679);
            this.Controls.Add(this.panelButton);
            this.Controls.Add(this.reportViewer1);
            this.Controls.Add(this.groupBox3);
            this.Name = "ImprimerBilanComptableForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Bilan Général et Compte Exploitation";
            this.Load += new System.EventHandler(this.ImprimerBilanComptableForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.immeubleBindingSource)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.panelButton.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        protected System.Windows.Forms.GroupBox groupBox3;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.Panel panelButton;
        private System.Windows.Forms.Button btnRapport;
        private System.Windows.Forms.Button btnQuit;
        private System.Windows.Forms.DateTimePicker dtEdition;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dtFin;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtDebut;
        private System.Windows.Forms.Label label1;
        protected System.Windows.Forms.TextBox tbRefImmeuble;
        protected System.Windows.Forms.Label lblImmeuble;
        protected System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.BindingSource immeubleBindingSource;
        private System.Windows.Forms.Button btnEnter;
        private System.Windows.Forms.Button btnExport;
    }
}