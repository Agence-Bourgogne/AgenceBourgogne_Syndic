namespace Gerance.Formulaires.Locataires
{
    partial class ChargesLocataireForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChargesLocataireForm));
            this.gbHdr = new System.Windows.Forms.GroupBox();
            this.dateEcriture = new System.Windows.Forms.DateTimePicker();
            this.label8 = new System.Windows.Forms.Label();
            this.tbRelles = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.tbCharges = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tbDateEntree = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tbAdresse = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tbNom = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.dateFin = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.dateDeb = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.tbRefLocataire = new System.Windows.Forms.TextBox();
            this.lblRefLocataire = new System.Windows.Forms.Label();
            this.gbList = new System.Windows.Forms.GroupBox();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.btnPrint = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.gbHdr.SuspendLayout();
            this.gbList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnPrint);
            this.panel1.Location = new System.Drawing.Point(10, 553);
            this.panel1.Controls.SetChildIndex(this.btnFirst, 0);
            this.panel1.Controls.SetChildIndex(this.btnPrev, 0);
            this.panel1.Controls.SetChildIndex(this.btnNext, 0);
            this.panel1.Controls.SetChildIndex(this.btnLast, 0);
            this.panel1.Controls.SetChildIndex(this.btnSave, 0);
            this.panel1.Controls.SetChildIndex(this.btnQuit, 0);
            this.panel1.Controls.SetChildIndex(this.btnEnter, 0);
            this.panel1.Controls.SetChildIndex(this.btnPrint, 0);
            // 
            // btnEnter
            // 
            this.btnEnter.Size = new System.Drawing.Size(0, 23);
            // 
            // btnSave
            // 
            this.btnSave.Text = "Enregi&strer";
            // 
            // btnLast
            // 
            this.btnLast.Visible = true;
            // 
            // btnNext
            // 
            this.btnNext.Visible = true;
            // 
            // btnPrev
            // 
            this.btnPrev.Visible = true;
            // 
            // btnFirst
            // 
            this.btnFirst.Visible = true;
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.Images.SetKeyName(0, "top.png");
            this.imageList1.Images.SetKeyName(1, "bottom.png");
            this.imageList1.Images.SetKeyName(2, "previous.png");
            this.imageList1.Images.SetKeyName(3, "next.png");
            this.imageList1.Images.SetKeyName(4, "save.png");
            this.imageList1.Images.SetKeyName(5, "quit.png");
            this.imageList1.Images.SetKeyName(6, "print.png");
            // 
            // gbHdr
            // 
            this.gbHdr.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbHdr.Controls.Add(this.dateEcriture);
            this.gbHdr.Controls.Add(this.label8);
            this.gbHdr.Controls.Add(this.tbRelles);
            this.gbHdr.Controls.Add(this.label7);
            this.gbHdr.Controls.Add(this.tbCharges);
            this.gbHdr.Controls.Add(this.label6);
            this.gbHdr.Controls.Add(this.tbDateEntree);
            this.gbHdr.Controls.Add(this.label5);
            this.gbHdr.Controls.Add(this.tbAdresse);
            this.gbHdr.Controls.Add(this.label4);
            this.gbHdr.Controls.Add(this.tbNom);
            this.gbHdr.Controls.Add(this.label3);
            this.gbHdr.Controls.Add(this.dateFin);
            this.gbHdr.Controls.Add(this.label2);
            this.gbHdr.Controls.Add(this.dateDeb);
            this.gbHdr.Controls.Add(this.label1);
            this.gbHdr.Controls.Add(this.tbRefLocataire);
            this.gbHdr.Controls.Add(this.lblRefLocataire);
            this.gbHdr.Location = new System.Drawing.Point(10, 12);
            this.gbHdr.Name = "gbHdr";
            this.gbHdr.Size = new System.Drawing.Size(760, 117);
            this.gbHdr.TabIndex = 0;
            this.gbHdr.TabStop = false;
            // 
            // dateEcriture
            // 
            this.dateEcriture.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateEcriture.Location = new System.Drawing.Point(314, 23);
            this.dateEcriture.Name = "dateEcriture";
            this.dateEcriture.Size = new System.Drawing.Size(85, 20);
            this.dateEcriture.TabIndex = 3;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(233, 26);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(69, 13);
            this.label8.TabIndex = 2;
            this.label8.Text = "Date E&criture";
            // 
            // tbRelles
            // 
            this.tbRelles.Enabled = false;
            this.tbRelles.Location = new System.Drawing.Point(652, 79);
            this.tbRelles.Name = "tbRelles";
            this.tbRelles.ReadOnly = true;
            this.tbRelles.Size = new System.Drawing.Size(85, 20);
            this.tbRelles.TabIndex = 15;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(604, 82);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(42, 13);
            this.label7.TabIndex = 14;
            this.label7.Text = "Réelles";
            // 
            // tbCharges
            // 
            this.tbCharges.Enabled = false;
            this.tbCharges.Location = new System.Drawing.Point(515, 79);
            this.tbCharges.Name = "tbCharges";
            this.tbCharges.ReadOnly = true;
            this.tbCharges.Size = new System.Drawing.Size(85, 20);
            this.tbCharges.TabIndex = 13;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(422, 82);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(88, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "Charges Réglées";
            // 
            // tbDateEntree
            // 
            this.tbDateEntree.Enabled = false;
            this.tbDateEntree.Location = new System.Drawing.Point(101, 79);
            this.tbDateEntree.Name = "tbDateEntree";
            this.tbDateEntree.ReadOnly = true;
            this.tbDateEntree.Size = new System.Drawing.Size(100, 20);
            this.tbDateEntree.TabIndex = 11;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(16, 82);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(64, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Date Entree";
            // 
            // tbAdresse
            // 
            this.tbAdresse.Enabled = false;
            this.tbAdresse.Location = new System.Drawing.Point(515, 53);
            this.tbAdresse.Name = "tbAdresse";
            this.tbAdresse.ReadOnly = true;
            this.tbAdresse.Size = new System.Drawing.Size(220, 20);
            this.tbAdresse.TabIndex = 9;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(422, 56);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(45, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Adresse";
            // 
            // tbNom
            // 
            this.tbNom.Enabled = false;
            this.tbNom.Location = new System.Drawing.Point(101, 53);
            this.tbNom.Name = "tbNom";
            this.tbNom.ReadOnly = true;
            this.tbNom.Size = new System.Drawing.Size(220, 20);
            this.tbNom.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(16, 56);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(76, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Nom Locataire";
            // 
            // dateFin
            // 
            this.dateFin.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateFin.Location = new System.Drawing.Point(650, 23);
            this.dateFin.Name = "dateFin";
            this.dateFin.Size = new System.Drawing.Size(85, 20);
            this.dateFin.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(606, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(21, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "&Fin";
            // 
            // dateDeb
            // 
            this.dateDeb.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateDeb.Location = new System.Drawing.Point(515, 23);
            this.dateDeb.Name = "dateDeb";
            this.dateDeb.Size = new System.Drawing.Size(85, 20);
            this.dateDeb.TabIndex = 5;
            this.dateDeb.Validated += new System.EventHandler(this.dateDeb_Validated);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(422, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Dé&but Période";
            // 
            // tbRefLocataire
            // 
            this.tbRefLocataire.Location = new System.Drawing.Point(101, 23);
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
            this.lblRefLocataire.Location = new System.Drawing.Point(16, 26);
            this.lblRefLocataire.Name = "lblRefLocataire";
            this.lblRefLocataire.Size = new System.Drawing.Size(74, 13);
            this.lblRefLocataire.TabIndex = 0;
            this.lblRefLocataire.Text = "Réf. &Locataire";
            this.lblRefLocataire.Click += new System.EventHandler(this.lblRefLocataire_Click);
            // 
            // gbList
            // 
            this.gbList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbList.Controls.Add(this.reportViewer1);
            this.gbList.Controls.Add(this.dataGridView);
            this.gbList.Location = new System.Drawing.Point(10, 135);
            this.gbList.Name = "gbList";
            this.gbList.Size = new System.Drawing.Size(760, 403);
            this.gbList.TabIndex = 1;
            this.gbList.TabStop = false;
            // 
            // reportViewer1
            // 
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Gerance.Formulaires.Locataires.ChargesLocataireReport.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(100, 151);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(396, 246);
            this.reportViewer1.TabIndex = 1;
            // 
            // dataGridView
            // 
            this.dataGridView.AllowUserToAddRows = false;
            this.dataGridView.AllowUserToDeleteRows = false;
            this.dataGridView.AllowUserToResizeRows = false;
            this.dataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Location = new System.Drawing.Point(20, 29);
            this.dataGridView.MultiSelect = false;
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.RowHeadersVisible = false;
            this.dataGridView.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dataGridView.Size = new System.Drawing.Size(717, 354);
            this.dataGridView.TabIndex = 0;
            this.dataGridView.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_CellEndEdit);
            this.dataGridView.Enter += new System.EventHandler(this.dataGridView_Enter);
            this.dataGridView.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dataGridView_KeyDown);
            // 
            // btnPrint
            // 
            this.btnPrint.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnPrint.ImageIndex = 6;
            this.btnPrint.ImageList = this.imageList1;
            this.btnPrint.Location = new System.Drawing.Point(348, 5);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(80, 25);
            this.btnPrint.TabIndex = 117;
            this.btnPrint.Text = "&Rapport";
            this.btnPrint.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // ChargesLocataireForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(782, 604);
            this.Controls.Add(this.gbList);
            this.Controls.Add(this.gbHdr);
            this.Name = "ChargesLocataireForm";
            this.Text = "Charges Locataire";
            this.Load += new System.EventHandler(this.ChargesLocataireForm_Load);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.gbHdr, 0);
            this.Controls.SetChildIndex(this.gbList, 0);
            this.panel1.ResumeLayout(false);
            this.gbHdr.ResumeLayout(false);
            this.gbHdr.PerformLayout();
            this.gbList.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbHdr;
        private System.Windows.Forms.TextBox tbCharges;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tbDateEntree;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbAdresse;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbNom;
        private System.Windows.Forms.Label label3;
        protected System.Windows.Forms.DateTimePicker dateFin;
        protected System.Windows.Forms.Label label2;
        protected System.Windows.Forms.DateTimePicker dateDeb;
        protected System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbRefLocataire;
        private System.Windows.Forms.Label lblRefLocataire;
        private System.Windows.Forms.GroupBox gbList;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.TextBox tbRelles;
        private System.Windows.Forms.Label label7;
        protected System.Windows.Forms.DateTimePicker dateEcriture;
        protected System.Windows.Forms.Label label8;
        protected System.Windows.Forms.Button btnPrint;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
    }
}
