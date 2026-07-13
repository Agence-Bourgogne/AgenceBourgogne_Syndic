namespace EspaceSyndic.Impressions.Additif
{
    partial class ImprimerAdditifForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ImprimerAdditifForm));
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource2 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.tableCoproImmeubleBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.panelButton = new System.Windows.Forms.Panel();
            this.btnWord = new System.Windows.Forms.Button();
            this.btnEnter = new System.Windows.Forms.Button();
            this.btnRapport = new System.Windows.Forms.Button();
            this.btnQuit = new System.Windows.Forms.Button();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cbConvoc = new System.Windows.Forms.ComboBox();
            this.dtDateAssemblee = new System.Windows.Forms.DateTimePicker();
            this.dtDateEntete = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.tbHeure = new System.Windows.Forms.MaskedTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tbLieu = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tbRefImmeuble = new System.Windows.Forms.TextBox();
            this.lblImmeuble = new System.Windows.Forms.Label();
            this.tbText = new System.Windows.Forms.RichTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.BtnExportServeur = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.tableCoproImmeubleBindingSource)).BeginInit();
            this.panelButton.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
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
            this.imageList1.Images.SetKeyName(7, "word.png");
            // 
            // panelButton
            // 
            this.panelButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelButton.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panelButton.Controls.Add(this.BtnExportServeur);
            this.panelButton.Controls.Add(this.btnWord);
            this.panelButton.Controls.Add(this.btnEnter);
            this.panelButton.Controls.Add(this.btnRapport);
            this.panelButton.Controls.Add(this.btnQuit);
            this.panelButton.Location = new System.Drawing.Point(16, 707);
            this.panelButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panelButton.Name = "panelButton";
            this.panelButton.Size = new System.Drawing.Size(993, 43);
            this.panelButton.TabIndex = 9;
            // 
            // btnWord
            // 
            this.btnWord.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnWord.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnWord.ImageIndex = 7;
            this.btnWord.ImageList = this.imageList1;
            this.btnWord.Location = new System.Drawing.Point(149, 6);
            this.btnWord.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnWord.Name = "btnWord";
            this.btnWord.Size = new System.Drawing.Size(133, 31);
            this.btnWord.TabIndex = 121;
            this.btnWord.Text = "&PubliPostage";
            this.btnWord.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnWord.UseVisualStyleBackColor = true;
            this.btnWord.Click += new System.EventHandler(this.btnWord_Click);
            // 
            // btnEnter
            // 
            this.btnEnter.Location = new System.Drawing.Point(445, 5);
            this.btnEnter.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnEnter.Name = "btnEnter";
            this.btnEnter.Size = new System.Drawing.Size(100, 28);
            this.btnEnter.TabIndex = 120;
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
            this.btnRapport.Location = new System.Drawing.Point(8, 6);
            this.btnRapport.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnRapport.Name = "btnRapport";
            this.btnRapport.Size = new System.Drawing.Size(133, 31);
            this.btnRapport.TabIndex = 87;
            this.btnRapport.Text = "&Rapport";
            this.btnRapport.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRapport.UseVisualStyleBackColor = true;
            this.btnRapport.Click += new System.EventHandler(this.btnRapport_Click);
            // 
            // btnQuit
            // 
            this.btnQuit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnQuit.CausesValidation = false;
            this.btnQuit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnQuit.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnQuit.ImageIndex = 5;
            this.btnQuit.ImageList = this.imageList1;
            this.btnQuit.Location = new System.Drawing.Point(851, 6);
            this.btnQuit.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnQuit.Name = "btnQuit";
            this.btnQuit.Size = new System.Drawing.Size(133, 31);
            this.btnQuit.TabIndex = 86;
            this.btnQuit.Text = "&Quitter";
            this.btnQuit.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnQuit.UseVisualStyleBackColor = true;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            reportDataSource2.Name = "convocation";
            reportDataSource2.Value = this.tableCoproImmeubleBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource2);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "EspaceSyndic.Impressions.Additif.ImprimerAdditifReport.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(16, 165);
            this.reportViewer1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(994, 518);
            this.reportViewer1.TabIndex = 10;
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.cbConvoc);
            this.groupBox3.Controls.Add(this.dtDateAssemblee);
            this.groupBox3.Controls.Add(this.dtDateEntete);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.tbHeure);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.tbLieu);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.tbRefImmeuble);
            this.groupBox3.Controls.Add(this.lblImmeuble);
            this.groupBox3.Controls.Add(this.tbText);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Location = new System.Drawing.Point(16, 11);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox3.Size = new System.Drawing.Size(995, 146);
            this.groupBox3.TabIndex = 0;
            this.groupBox3.TabStop = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(277, 113);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(56, 16);
            this.label6.TabIndex = 11;
            this.label6.Text = "&Convoc:";
            // 
            // cbConvoc
            // 
            this.cbConvoc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbConvoc.FormattingEnabled = true;
            this.cbConvoc.Items.AddRange(new object[] {
            "Ordinaire",
            "Extra Ordinaire"});
            this.cbConvoc.Location = new System.Drawing.Point(356, 108);
            this.cbConvoc.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cbConvoc.Name = "cbConvoc";
            this.cbConvoc.Size = new System.Drawing.Size(148, 24);
            this.cbConvoc.TabIndex = 12;
            // 
            // dtDateAssemblee
            // 
            this.dtDateAssemblee.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtDateAssemblee.Location = new System.Drawing.Point(155, 76);
            this.dtDateAssemblee.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dtDateAssemblee.Name = "dtDateAssemblee";
            this.dtDateAssemblee.Size = new System.Drawing.Size(115, 22);
            this.dtDateAssemblee.TabIndex = 6;
            // 
            // dtDateEntete
            // 
            this.dtDateEntete.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtDateEntete.Location = new System.Drawing.Point(155, 48);
            this.dtDateEntete.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dtDateEntete.Name = "dtDateEntete";
            this.dtDateEntete.Size = new System.Drawing.Size(115, 22);
            this.dtDateEntete.TabIndex = 4;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(24, 113);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(47, 16);
            this.label5.TabIndex = 9;
            this.label5.Text = "&Heure:";
            // 
            // tbHeure
            // 
            this.tbHeure.Location = new System.Drawing.Point(155, 110);
            this.tbHeure.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tbHeure.Mask = "00:00";
            this.tbHeure.Name = "tbHeure";
            this.tbHeure.Size = new System.Drawing.Size(51, 22);
            this.tbHeure.TabIndex = 10;
            this.tbHeure.ValidatingType = typeof(System.DateTime);
            // 
            // label4
            // 
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.label4.Location = new System.Drawing.Point(277, 23);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 44);
            this.label4.TabIndex = 7;
            this.label4.Text = "&Texte Additif:";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // tbLieu
            // 
            this.tbLieu.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbLieu.Location = new System.Drawing.Point(563, 110);
            this.tbLieu.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tbLieu.Name = "tbLieu";
            this.tbLieu.Size = new System.Drawing.Size(408, 22);
            this.tbLieu.TabIndex = 14;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(511, 112);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 16);
            this.label2.TabIndex = 13;
            this.label2.Text = "&Lieu :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 84);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(111, 16);
            this.label1.TabIndex = 5;
            this.label1.Text = "Date &Assemblée:";
            // 
            // tbRefImmeuble
            // 
            this.tbRefImmeuble.Location = new System.Drawing.Point(155, 23);
            this.tbRefImmeuble.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tbRefImmeuble.Name = "tbRefImmeuble";
            this.tbRefImmeuble.Size = new System.Drawing.Size(91, 22);
            this.tbRefImmeuble.TabIndex = 2;
            this.tbRefImmeuble.DoubleClick += new System.EventHandler(this.tbRefImmeuble_DoubleClick);
            this.tbRefImmeuble.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbHelpBox_KeyPress);
            this.tbRefImmeuble.Validating += new System.ComponentModel.CancelEventHandler(this.tbRefImmeuble_Validating);
            // 
            // lblImmeuble
            // 
            this.lblImmeuble.AutoSize = true;
            this.lblImmeuble.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblImmeuble.ForeColor = System.Drawing.Color.Blue;
            this.lblImmeuble.Location = new System.Drawing.Point(24, 27);
            this.lblImmeuble.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblImmeuble.Name = "lblImmeuble";
            this.lblImmeuble.Size = new System.Drawing.Size(72, 17);
            this.lblImmeuble.TabIndex = 1;
            this.lblImmeuble.Text = "&Immeuble:";
            this.lblImmeuble.Click += new System.EventHandler(this.lblImmeuble_Click);
            // 
            // tbText
            // 
            this.tbText.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbText.Location = new System.Drawing.Point(356, 23);
            this.tbText.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tbText.Name = "tbText";
            this.tbText.Size = new System.Drawing.Size(615, 80);
            this.tbText.TabIndex = 8;
            this.tbText.Text = "";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(24, 55);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 16);
            this.label3.TabIndex = 3;
            this.label3.Text = "&Date Entête:";
            // 
            // BtnExportServeur
            // 
            this.BtnExportServeur.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.BtnExportServeur.Location = new System.Drawing.Point(290, 6);
            this.BtnExportServeur.Margin = new System.Windows.Forms.Padding(4);
            this.BtnExportServeur.Name = "BtnExportServeur";
            this.BtnExportServeur.Size = new System.Drawing.Size(127, 31);
            this.BtnExportServeur.TabIndex = 122;
            this.BtnExportServeur.Text = "Export Serveur";
            this.BtnExportServeur.UseVisualStyleBackColor = true;
            this.BtnExportServeur.Click += new System.EventHandler(this.button1_Click);
            // 
            // ImprimerAdditifForm
            // 
            this.AcceptButton = this.btnEnter;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnQuit;
            this.ClientSize = new System.Drawing.Size(1027, 766);
            this.ControlBox = false;
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.reportViewer1);
            this.Controls.Add(this.panelButton);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "ImprimerAdditifForm";
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Additif Convocation";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ImprimerAdditifForm_FormClosing);
            this.Load += new System.EventHandler(this.ImprimerConvocationForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tableCoproImmeubleBindingSource)).EndInit();
            this.panelButton.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        protected System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Panel panelButton;
        private System.Windows.Forms.Button btnRapport;
        private System.Windows.Forms.Button btnQuit;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        protected System.Windows.Forms.GroupBox groupBox3;
        protected System.Windows.Forms.Label label1;
        protected System.Windows.Forms.TextBox tbRefImmeuble;
        protected System.Windows.Forms.Label lblImmeuble;
        private System.Windows.Forms.RichTextBox tbText;
        protected System.Windows.Forms.Label label3;
        protected System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbLieu;
        protected System.Windows.Forms.Label label2;
        protected System.Windows.Forms.Label label5;
        protected System.Windows.Forms.MaskedTextBox tbHeure;
        //private Datasets.CoproprietaireImmeuble coproprietaireImmeuble;
        private System.Windows.Forms.BindingSource tableCoproImmeubleBindingSource;
        //private Datasets.CoproprietaireImmeubleTableAdapters.CoproImmeubleTableAdapter coproImmeubleTableAdapter;
        private System.Windows.Forms.DateTimePicker dtDateAssemblee;
        private System.Windows.Forms.DateTimePicker dtDateEntete;
        protected System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cbConvoc;
        private System.Windows.Forms.Button btnEnter;
        private System.Windows.Forms.Button btnWord;
        private System.Windows.Forms.Button BtnExportServeur;
    }
}