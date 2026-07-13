namespace Gerance.Impressions.Retards
{
    partial class RetardPaiementForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RetardPaiementForm));
            this.gbList = new System.Windows.Forms.GroupBox();
            this.ckAll = new System.Windows.Forms.CheckBox();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.Selection = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tbRefLocataire = new System.Windows.Forms.TextBox();
            this.lblRefLocataire = new System.Windows.Forms.Label();
            this.dateEcriture = new System.Windows.Forms.DateTimePicker();
            this.label8 = new System.Windows.Forms.Label();
            this.tbSeuil = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btnPrint = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.gbList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnPrint);
            this.panel1.TabIndex = 2;
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
            // btnNext
            // 
            this.btnNext.ImageIndex = 6;
            this.btnNext.Size = new System.Drawing.Size(113, 25);
            this.btnNext.Text = "&Mise En demeure";
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click_1);
            // 
            // btnPrev
            // 
            this.btnPrev.ImageIndex = 7;
            this.btnPrev.Text = "&Liste";
            this.btnPrev.Click += new System.EventHandler(this.btnPrev_Click_1);
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
            this.imageList1.Images.SetKeyName(7, "bulle_repart.png");
            // 
            // gbList
            // 
            this.gbList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbList.Controls.Add(this.ckAll);
            this.gbList.Controls.Add(this.reportViewer1);
            this.gbList.Controls.Add(this.dataGridView);
            this.gbList.Location = new System.Drawing.Point(10, 75);
            this.gbList.Name = "gbList";
            this.gbList.Size = new System.Drawing.Size(760, 410);
            this.gbList.TabIndex = 1;
            this.gbList.TabStop = false;
            // 
            // ckAll
            // 
            this.ckAll.AutoSize = true;
            this.ckAll.Location = new System.Drawing.Point(20, 9);
            this.ckAll.Name = "ckAll";
            this.ckAll.Size = new System.Drawing.Size(85, 17);
            this.ckAll.TabIndex = 2;
            this.ckAll.Text = "Tout Cocher";
            this.ckAll.UseVisualStyleBackColor = true;
            this.ckAll.CheckedChanged += new System.EventHandler(this.ckAll_CheckedChanged);
            // 
            // reportViewer1
            // 
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Gerance.Impressions.Retards.RetardPaiementReport.rdlc";
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
            this.dataGridView.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Selection});
            this.dataGridView.Location = new System.Drawing.Point(20, 29);
            this.dataGridView.MultiSelect = false;
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.RowHeadersVisible = false;
            this.dataGridView.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView.Size = new System.Drawing.Size(717, 361);
            this.dataGridView.TabIndex = 0;
            // 
            // Select
            // 
            this.Selection.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Selection.HeaderText = "";
            this.Selection.Name = "Select";
            this.Selection.Width = 5;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tbRefLocataire);
            this.groupBox1.Controls.Add(this.lblRefLocataire);
            this.groupBox1.Controls.Add(this.dateEcriture);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.tbSeuil);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Location = new System.Drawing.Point(10, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(760, 64);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // tbRefLocataire
            // 
            this.tbRefLocataire.Location = new System.Drawing.Point(635, 23);
            this.tbRefLocataire.Name = "tbRefLocataire";
            this.tbRefLocataire.Size = new System.Drawing.Size(100, 20);
            this.tbRefLocataire.TabIndex = 5;
            this.tbRefLocataire.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbRefLocataire_KeyDown);
            this.tbRefLocataire.Validating += new System.ComponentModel.CancelEventHandler(this.tbRefLocataire_Validating);
            // 
            // lblRefLocataire
            // 
            this.lblRefLocataire.AutoSize = true;
            this.lblRefLocataire.ForeColor = System.Drawing.Color.Blue;
            this.lblRefLocataire.Location = new System.Drawing.Point(550, 26);
            this.lblRefLocataire.Name = "lblRefLocataire";
            this.lblRefLocataire.Size = new System.Drawing.Size(74, 13);
            this.lblRefLocataire.TabIndex = 4;
            this.lblRefLocataire.Text = "Réf. &Locataire";
            this.lblRefLocataire.Click += new System.EventHandler(this.lblRefLocataire_Click);
            // 
            // dateEcriture
            // 
            this.dateEcriture.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateEcriture.Location = new System.Drawing.Point(372, 23);
            this.dateEcriture.Name = "dateEcriture";
            this.dateEcriture.Size = new System.Drawing.Size(85, 20);
            this.dateEcriture.TabIndex = 3;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(291, 26);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(73, 13);
            this.label8.TabIndex = 2;
            this.label8.Text = "Date &Relance";
            // 
            // tbSeuil
            // 
            this.tbSeuil.Location = new System.Drawing.Point(110, 23);
            this.tbSeuil.Name = "tbSeuil";
            this.tbSeuil.Size = new System.Drawing.Size(77, 20);
            this.tbSeuil.TabIndex = 1;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(17, 26);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(88, 13);
            this.label6.TabIndex = 0;
            this.label6.Text = "Seuil de Relance";
            // 
            // btnPrint
            // 
            this.btnPrint.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnPrint.ImageIndex = 6;
            this.btnPrint.ImageList = this.imageList1;
            this.btnPrint.Location = new System.Drawing.Point(348, 5);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(80, 25);
            this.btnPrint.TabIndex = 118;
            this.btnPrint.Text = "&Relancer";
            this.btnPrint.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // RetardPaiementForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(782, 553);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.gbList);
            this.Name = "RetardPaiementForm";
            this.Text = "Retards de Paiement";
            this.Load += new System.EventHandler(this.RetardPaiementForm_Load);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.gbList, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.panel1.ResumeLayout(false);
            this.gbList.ResumeLayout(false);
            this.gbList.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbList;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox tbSeuil;
        private System.Windows.Forms.Label label6;
        protected System.Windows.Forms.DateTimePicker dateEcriture;
        protected System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox tbRefLocataire;
        private System.Windows.Forms.Label lblRefLocataire;
        protected System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Selection;
        private System.Windows.Forms.CheckBox ckAll;
    }
}
