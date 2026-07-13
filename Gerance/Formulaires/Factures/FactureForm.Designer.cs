namespace Gerance.Formulaires.Factures
{
    partial class FactureForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FactureForm));
            this.lblRefLocataire = new System.Windows.Forms.Label();
            this.tbRefLocataire = new System.Windows.Forms.TextBox();
            this.tbNomLocataire = new System.Windows.Forms.TextBox();
            this.tbPrenomLocataire = new System.Windows.Forms.TextBox();
            this.tbRefProprio = new System.Windows.Forms.TextBox();
            this.tbNomProprio = new System.Windows.Forms.TextBox();
            this.tbPrenomProprio = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tbNumLot = new System.Windows.Forms.TextBox();
            this.lblLot = new System.Windows.Forms.Label();
            this.tbNomImmeuble = new System.Windows.Forms.TextBox();
            this.tbRefImmeuble = new System.Windows.Forms.TextBox();
            this.lblRefImmeuble = new System.Windows.Forms.Label();
            this.test = new System.Windows.Forms.GroupBox();
            this.tbDesiFournisseur = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.dtEcriture = new System.Windows.Forms.DateTimePicker();
            this.label8 = new System.Windows.Forms.Label();
            this.tbMontant = new System.Windows.Forms.TextBox();
            this.cbReglement = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnFournisseurAdd = new System.Windows.Forms.Button();
            this.btnNatureAdd = new System.Windows.Forms.Button();
            this.tbLibelle = new System.Windows.Forms.TextBox();
            this.tbNomFournisseur = new System.Windows.Forms.TextBox();
            this.tbLibNature = new System.Windows.Forms.TextBox();
            this.tbNature = new System.Windows.Forms.TextBox();
            this.lblNature = new System.Windows.Forms.Label();
            this.tbFournisseur = new System.Windows.Forms.TextBox();
            this.lblFournisseur = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.gbFactures = new System.Windows.Forms.GroupBox();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.btnDelete = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.test.SuspendLayout();
            this.gbFactures.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnDelete);
            this.panel1.Location = new System.Drawing.Point(10, 520);
            this.panel1.Size = new System.Drawing.Size(795, 39);
            this.panel1.TabIndex = 2;
            this.panel1.Controls.SetChildIndex(this.btnFirst, 0);
            this.panel1.Controls.SetChildIndex(this.btnPrev, 0);
            this.panel1.Controls.SetChildIndex(this.btnNext, 0);
            this.panel1.Controls.SetChildIndex(this.btnLast, 0);
            this.panel1.Controls.SetChildIndex(this.btnSave, 0);
            this.panel1.Controls.SetChildIndex(this.btnQuit, 0);
            this.panel1.Controls.SetChildIndex(this.btnEnter, 0);
            this.panel1.Controls.SetChildIndex(this.btnDelete, 0);
            // 
            // btnEnter
            // 
            this.btnEnter.Size = new System.Drawing.Size(0, 23);
            // 
            // btnQuit
            // 
            this.btnQuit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnQuit.Location = new System.Drawing.Point(697, 5);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Location = new System.Drawing.Point(611, 5);
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
            this.imageList1.Images.SetKeyName(6, "stop.png");
            // 
            // lblRefLocataire
            // 
            this.lblRefLocataire.AutoSize = true;
            this.lblRefLocataire.ForeColor = System.Drawing.Color.Blue;
            this.lblRefLocataire.Location = new System.Drawing.Point(12, 46);
            this.lblRefLocataire.Name = "lblRefLocataire";
            this.lblRefLocataire.Size = new System.Drawing.Size(74, 13);
            this.lblRefLocataire.TabIndex = 5;
            this.lblRefLocataire.Text = "&Réf. Locataire";
            this.lblRefLocataire.Click += new System.EventHandler(this.lblRefLocataire_Click);
            // 
            // tbRefLocataire
            // 
            this.tbRefLocataire.Location = new System.Drawing.Point(97, 43);
            this.tbRefLocataire.Name = "tbRefLocataire";
            this.tbRefLocataire.Size = new System.Drawing.Size(100, 20);
            this.tbRefLocataire.TabIndex = 6;
            this.tbRefLocataire.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbRefLocataire_KeyDown);
            this.tbRefLocataire.Validating += new System.ComponentModel.CancelEventHandler(this.tbRefLocataire_Validating);
            // 
            // tbNomLocataire
            // 
            this.tbNomLocataire.Enabled = false;
            this.tbNomLocataire.Location = new System.Drawing.Point(226, 43);
            this.tbNomLocataire.Name = "tbNomLocataire";
            this.tbNomLocataire.ReadOnly = true;
            this.tbNomLocataire.Size = new System.Drawing.Size(243, 20);
            this.tbNomLocataire.TabIndex = 7;
            // 
            // tbPrenomLocataire
            // 
            this.tbPrenomLocataire.Enabled = false;
            this.tbPrenomLocataire.Location = new System.Drawing.Point(485, 43);
            this.tbPrenomLocataire.Name = "tbPrenomLocataire";
            this.tbPrenomLocataire.ReadOnly = true;
            this.tbPrenomLocataire.Size = new System.Drawing.Size(294, 20);
            this.tbPrenomLocataire.TabIndex = 8;
            // 
            // tbRefProprio
            // 
            this.tbRefProprio.Enabled = false;
            this.tbRefProprio.Location = new System.Drawing.Point(97, 72);
            this.tbRefProprio.Name = "tbRefProprio";
            this.tbRefProprio.ReadOnly = true;
            this.tbRefProprio.Size = new System.Drawing.Size(100, 20);
            this.tbRefProprio.TabIndex = 10;
            // 
            // tbNomProprio
            // 
            this.tbNomProprio.Enabled = false;
            this.tbNomProprio.Location = new System.Drawing.Point(226, 72);
            this.tbNomProprio.Name = "tbNomProprio";
            this.tbNomProprio.ReadOnly = true;
            this.tbNomProprio.Size = new System.Drawing.Size(243, 20);
            this.tbNomProprio.TabIndex = 11;
            // 
            // tbPrenomProprio
            // 
            this.tbPrenomProprio.Enabled = false;
            this.tbPrenomProprio.Location = new System.Drawing.Point(485, 72);
            this.tbPrenomProprio.Name = "tbPrenomProprio";
            this.tbPrenomProprio.ReadOnly = true;
            this.tbPrenomProprio.Size = new System.Drawing.Size(294, 20);
            this.tbPrenomProprio.TabIndex = 12;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 75);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Propriétaire";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.tbNumLot);
            this.groupBox1.Controls.Add(this.lblLot);
            this.groupBox1.Controls.Add(this.tbNomImmeuble);
            this.groupBox1.Controls.Add(this.tbRefImmeuble);
            this.groupBox1.Controls.Add(this.lblRefImmeuble);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.tbPrenomProprio);
            this.groupBox1.Controls.Add(this.tbNomProprio);
            this.groupBox1.Controls.Add(this.tbRefProprio);
            this.groupBox1.Controls.Add(this.tbPrenomLocataire);
            this.groupBox1.Controls.Add(this.tbNomLocataire);
            this.groupBox1.Controls.Add(this.tbRefLocataire);
            this.groupBox1.Controls.Add(this.lblRefLocataire);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(793, 108);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // tbNumLot
            // 
            this.tbNumLot.Location = new System.Drawing.Point(723, 16);
            this.tbNumLot.Name = "tbNumLot";
            this.tbNumLot.Size = new System.Drawing.Size(56, 20);
            this.tbNumLot.TabIndex = 4;
            this.tbNumLot.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbNumLot_KeyDown);
            this.tbNumLot.Validating += new System.ComponentModel.CancelEventHandler(this.tbNumLot_Validating);
            // 
            // lblLot
            // 
            this.lblLot.AutoSize = true;
            this.lblLot.ForeColor = System.Drawing.Color.Blue;
            this.lblLot.Location = new System.Drawing.Point(641, 19);
            this.lblLot.Name = "lblLot";
            this.lblLot.Size = new System.Drawing.Size(76, 13);
            this.lblLot.TabIndex = 3;
            this.lblLot.Text = "Numéro du &lot:";
            this.lblLot.Click += new System.EventHandler(this.lblLot_Click);
            // 
            // tbNomImmeuble
            // 
            this.tbNomImmeuble.Enabled = false;
            this.tbNomImmeuble.Location = new System.Drawing.Point(226, 16);
            this.tbNomImmeuble.Name = "tbNomImmeuble";
            this.tbNomImmeuble.ReadOnly = true;
            this.tbNomImmeuble.Size = new System.Drawing.Size(243, 20);
            this.tbNomImmeuble.TabIndex = 2;
            // 
            // tbRefImmeuble
            // 
            this.tbRefImmeuble.Location = new System.Drawing.Point(97, 16);
            this.tbRefImmeuble.Name = "tbRefImmeuble";
            this.tbRefImmeuble.Size = new System.Drawing.Size(100, 20);
            this.tbRefImmeuble.TabIndex = 1;
            this.tbRefImmeuble.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbRefImmeuble_KeyDown);
            this.tbRefImmeuble.Validating += new System.ComponentModel.CancelEventHandler(this.tbRefImmeuble_Validating);
            // 
            // lblRefImmeuble
            // 
            this.lblRefImmeuble.AutoSize = true;
            this.lblRefImmeuble.ForeColor = System.Drawing.Color.Blue;
            this.lblRefImmeuble.Location = new System.Drawing.Point(12, 19);
            this.lblRefImmeuble.Name = "lblRefImmeuble";
            this.lblRefImmeuble.Size = new System.Drawing.Size(52, 13);
            this.lblRefImmeuble.TabIndex = 0;
            this.lblRefImmeuble.Text = "&Immeuble";
            this.lblRefImmeuble.Click += new System.EventHandler(this.lblRefImmeuble_Click);
            // 
            // test
            // 
            this.test.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.test.Controls.Add(this.tbDesiFournisseur);
            this.test.Controls.Add(this.label5);
            this.test.Controls.Add(this.dtEcriture);
            this.test.Controls.Add(this.label8);
            this.test.Controls.Add(this.tbMontant);
            this.test.Controls.Add(this.cbReglement);
            this.test.Controls.Add(this.label2);
            this.test.Controls.Add(this.btnFournisseurAdd);
            this.test.Controls.Add(this.btnNatureAdd);
            this.test.Controls.Add(this.tbLibelle);
            this.test.Controls.Add(this.tbNomFournisseur);
            this.test.Controls.Add(this.tbLibNature);
            this.test.Controls.Add(this.tbNature);
            this.test.Controls.Add(this.lblNature);
            this.test.Controls.Add(this.tbFournisseur);
            this.test.Controls.Add(this.lblFournisseur);
            this.test.Controls.Add(this.label4);
            this.test.Location = new System.Drawing.Point(10, 126);
            this.test.Name = "test";
            this.test.Size = new System.Drawing.Size(795, 104);
            this.test.TabIndex = 1;
            this.test.TabStop = false;
            // 
            // tbDesiFournisseur
            // 
            this.tbDesiFournisseur.AccessibleDescription = "";
            this.tbDesiFournisseur.AccessibleName = "";
            this.tbDesiFournisseur.Location = new System.Drawing.Point(487, 72);
            this.tbDesiFournisseur.Name = "tbDesiFournisseur";
            this.tbDesiFournisseur.Size = new System.Drawing.Size(294, 20);
            this.tbDesiFournisseur.TabIndex = 16;
            this.tbDesiFournisseur.Visible = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(430, 22);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(37, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Libellé";
            // 
            // dtEcriture
            // 
            this.dtEcriture.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtEcriture.Location = new System.Drawing.Point(99, 16);
            this.dtEcriture.Name = "dtEcriture";
            this.dtEcriture.Size = new System.Drawing.Size(86, 20);
            this.dtEcriture.TabIndex = 1;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(231, 22);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(46, 13);
            this.label8.TabIndex = 2;
            this.label8.Text = "Montant";
            // 
            // tbMontant
            // 
            this.tbMontant.Location = new System.Drawing.Point(295, 19);
            this.tbMontant.Name = "tbMontant";
            this.tbMontant.Size = new System.Drawing.Size(65, 20);
            this.tbMontant.TabIndex = 3;
            // 
            // cbReglement
            // 
            this.cbReglement.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbReglement.FormattingEnabled = true;
            this.cbReglement.Location = new System.Drawing.Point(693, 43);
            this.cbReglement.Name = "cbReglement";
            this.cbReglement.Size = new System.Drawing.Size(88, 21);
            this.cbReglement.TabIndex = 11;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(617, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "&Règlement:";
            // 
            // btnFournisseurAdd
            // 
            this.btnFournisseurAdd.Location = new System.Drawing.Point(165, 70);
            this.btnFournisseurAdd.Name = "btnFournisseurAdd";
            this.btnFournisseurAdd.Size = new System.Drawing.Size(22, 22);
            this.btnFournisseurAdd.TabIndex = 14;
            this.btnFournisseurAdd.TabStop = false;
            this.btnFournisseurAdd.Text = "+";
            this.btnFournisseurAdd.UseVisualStyleBackColor = true;
            this.btnFournisseurAdd.Click += new System.EventHandler(this.btnFournisseurAdd_Click);
            // 
            // btnNatureAdd
            // 
            this.btnNatureAdd.Location = new System.Drawing.Point(165, 41);
            this.btnNatureAdd.Name = "btnNatureAdd";
            this.btnNatureAdd.Size = new System.Drawing.Size(22, 22);
            this.btnNatureAdd.TabIndex = 8;
            this.btnNatureAdd.TabStop = false;
            this.btnNatureAdd.Text = "+";
            this.btnNatureAdd.UseVisualStyleBackColor = true;
            this.btnNatureAdd.Click += new System.EventHandler(this.btnNatureAdd_Click);
            // 
            // tbLibelle
            // 
            this.tbLibelle.AccessibleDescription = "";
            this.tbLibelle.AccessibleName = "";
            this.tbLibelle.Location = new System.Drawing.Point(487, 19);
            this.tbLibelle.Name = "tbLibelle";
            this.tbLibelle.Size = new System.Drawing.Size(294, 20);
            this.tbLibelle.TabIndex = 5;
            // 
            // tbNomFournisseur
            // 
            this.tbNomFournisseur.Enabled = false;
            this.tbNomFournisseur.Location = new System.Drawing.Point(228, 72);
            this.tbNomFournisseur.Name = "tbNomFournisseur";
            this.tbNomFournisseur.Size = new System.Drawing.Size(239, 20);
            this.tbNomFournisseur.TabIndex = 15;
            // 
            // tbLibNature
            // 
            this.tbLibNature.Enabled = false;
            this.tbLibNature.Location = new System.Drawing.Point(228, 43);
            this.tbLibNature.Name = "tbLibNature";
            this.tbLibNature.Size = new System.Drawing.Size(239, 20);
            this.tbLibNature.TabIndex = 9;
            this.tbLibNature.TabStop = false;
            // 
            // tbNature
            // 
            this.tbNature.Location = new System.Drawing.Point(99, 42);
            this.tbNature.Name = "tbNature";
            this.tbNature.Size = new System.Drawing.Size(65, 20);
            this.tbNature.TabIndex = 7;
            this.tbNature.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbNature_KeyDown);
            this.tbNature.Validating += new System.ComponentModel.CancelEventHandler(this.tbNature_Validating);
            // 
            // lblNature
            // 
            this.lblNature.AutoSize = true;
            this.lblNature.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNature.ForeColor = System.Drawing.Color.Blue;
            this.lblNature.Location = new System.Drawing.Point(10, 48);
            this.lblNature.Name = "lblNature";
            this.lblNature.Size = new System.Drawing.Size(42, 13);
            this.lblNature.TabIndex = 6;
            this.lblNature.Text = "&Nature:";
            this.lblNature.Click += new System.EventHandler(this.lblNature_Click);
            // 
            // tbFournisseur
            // 
            this.tbFournisseur.Location = new System.Drawing.Point(99, 71);
            this.tbFournisseur.Name = "tbFournisseur";
            this.tbFournisseur.Size = new System.Drawing.Size(65, 20);
            this.tbFournisseur.TabIndex = 13;
            this.tbFournisseur.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbFournisseur_KeyDown);
            this.tbFournisseur.Validating += new System.ComponentModel.CancelEventHandler(this.tbFournisseur_Validating);
            // 
            // lblFournisseur
            // 
            this.lblFournisseur.AutoSize = true;
            this.lblFournisseur.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFournisseur.ForeColor = System.Drawing.Color.Blue;
            this.lblFournisseur.Location = new System.Drawing.Point(11, 75);
            this.lblFournisseur.Name = "lblFournisseur";
            this.lblFournisseur.Size = new System.Drawing.Size(64, 13);
            this.lblFournisseur.TabIndex = 12;
            this.lblFournisseur.Text = "&Fournisseur:";
            this.lblFournisseur.Click += new System.EventHandler(this.lblFournisseur_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 22);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(72, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "&Date Ecriture:";
            // 
            // gbFactures
            // 
            this.gbFactures.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbFactures.Controls.Add(this.dataGridView);
            this.gbFactures.Location = new System.Drawing.Point(10, 236);
            this.gbFactures.Name = "gbFactures";
            this.gbFactures.Size = new System.Drawing.Size(795, 278);
            this.gbFactures.TabIndex = 3;
            this.gbFactures.TabStop = false;
            this.gbFactures.Text = "Factures";
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
            this.dataGridView.BackgroundColor = System.Drawing.Color.Snow;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Location = new System.Drawing.Point(14, 19);
            this.dataGridView.MultiSelect = false;
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.ReadOnly = true;
            this.dataGridView.RowHeadersVisible = false;
            this.dataGridView.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView.ShowCellErrors = false;
            this.dataGridView.ShowEditingIcon = false;
            this.dataGridView.ShowRowErrors = false;
            this.dataGridView.Size = new System.Drawing.Size(767, 243);
            this.dataGridView.TabIndex = 0;
            this.dataGridView.SelectionChanged += new System.EventHandler(this.dataGridView_SelectionChanged);
            // 
            // btnDelete
            // 
            this.btnDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnDelete.ImageKey = "stop.png";
            this.btnDelete.ImageList = this.imageList1;
            this.btnDelete.Location = new System.Drawing.Point(355, 5);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(80, 25);
            this.btnDelete.TabIndex = 119;
            this.btnDelete.Text = "&Annuler";
            this.btnDelete.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // FactureForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(817, 571);
            this.Controls.Add(this.gbFactures);
            this.Controls.Add(this.test);
            this.Controls.Add(this.groupBox1);
            this.Name = "FactureForm";
            this.Text = "Saisie des Frais";
            this.Load += new System.EventHandler(this.FactureForm_Load);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.test, 0);
            this.Controls.SetChildIndex(this.gbFactures, 0);
            this.panel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.test.ResumeLayout(false);
            this.test.PerformLayout();
            this.gbFactures.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblRefLocataire;
        private System.Windows.Forms.TextBox tbRefLocataire;
        private System.Windows.Forms.TextBox tbNomLocataire;
        private System.Windows.Forms.TextBox tbPrenomLocataire;
        protected System.Windows.Forms.TextBox tbRefProprio;
        private System.Windows.Forms.TextBox tbNomProprio;
        private System.Windows.Forms.TextBox tbPrenomProprio;
        protected System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox1;
        protected System.Windows.Forms.TextBox tbNumLot;
        protected System.Windows.Forms.Label lblLot;
        protected System.Windows.Forms.TextBox tbNomImmeuble;
        protected System.Windows.Forms.TextBox tbRefImmeuble;
        protected System.Windows.Forms.Label lblRefImmeuble;
        private System.Windows.Forms.GroupBox test;
        private System.Windows.Forms.ComboBox cbReglement;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnFournisseurAdd;
        private System.Windows.Forms.Button btnNatureAdd;
        private System.Windows.Forms.TextBox tbLibelle;
        private System.Windows.Forms.TextBox tbNomFournisseur;
        private System.Windows.Forms.TextBox tbLibNature;
        private System.Windows.Forms.TextBox tbNature;
        private System.Windows.Forms.Label lblNature;
        private System.Windows.Forms.TextBox tbFournisseur;
        private System.Windows.Forms.Label lblFournisseur;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox gbFactures;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox tbMontant;
        private System.Windows.Forms.DateTimePicker dtEcriture;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.TextBox tbDesiFournisseur;

    }
}
