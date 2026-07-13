namespace EspaceSyndic.Formulaires.OperationsGestion
{
    partial class OperationsGestionForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OperationsGestionForm));
            this.gbParams = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tbBase = new System.Windows.Forms.TextBox();
            this.ckValid = new System.Windows.Forms.CheckBox();
            this.tbLibelle = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tbMontant = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbFournisseur = new System.Windows.Forms.TextBox();
            this.lblFournisseur = new System.Windows.Forms.Label();
            this.ckFin = new System.Windows.Forms.CheckBox();
            this.ckDebut = new System.Windows.Forms.CheckBox();
            this.dateFin = new System.Windows.Forms.DateTimePicker();
            this.tbNature = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbLot = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.dateDebut = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.cbTypeOpe = new System.Windows.Forms.ComboBox();
            this.tbRefImmeuble = new System.Windows.Forms.TextBox();
            this.lblImmeuble = new System.Windows.Forms.Label();
            this.gbFactures = new System.Windows.Forms.GroupBox();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.annulerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.modifierToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.modifierNumeroLotToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.genererLaFactureToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gnererLeReglementToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.supprimerLesÉlémentsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnDetail = new System.Windows.Forms.Button();
            this.btnExport = new System.Windows.Forms.Button();
            this.btnGrid = new System.Windows.Forms.Button();
            this.btnQuit = new System.Windows.Forms.Button();
            this.btnEnter = new System.Windows.Forms.Button();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.enregistrerLaPrésentationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.présentationParDéfautToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gbParams.SuspendLayout();
            this.gbFactures.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbParams
            // 
            this.gbParams.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbParams.Controls.Add(this.label6);
            this.gbParams.Controls.Add(this.tbBase);
            this.gbParams.Controls.Add(this.ckValid);
            this.gbParams.Controls.Add(this.tbLibelle);
            this.gbParams.Controls.Add(this.label5);
            this.gbParams.Controls.Add(this.tbMontant);
            this.gbParams.Controls.Add(this.label2);
            this.gbParams.Controls.Add(this.tbFournisseur);
            this.gbParams.Controls.Add(this.lblFournisseur);
            this.gbParams.Controls.Add(this.ckFin);
            this.gbParams.Controls.Add(this.ckDebut);
            this.gbParams.Controls.Add(this.dateFin);
            this.gbParams.Controls.Add(this.tbNature);
            this.gbParams.Controls.Add(this.label3);
            this.gbParams.Controls.Add(this.tbLot);
            this.gbParams.Controls.Add(this.label4);
            this.gbParams.Controls.Add(this.dateDebut);
            this.gbParams.Controls.Add(this.label1);
            this.gbParams.Controls.Add(this.cbTypeOpe);
            this.gbParams.Controls.Add(this.tbRefImmeuble);
            this.gbParams.Controls.Add(this.lblImmeuble);
            this.gbParams.Location = new System.Drawing.Point(12, 12);
            this.gbParams.Name = "gbParams";
            this.gbParams.Size = new System.Drawing.Size(805, 103);
            this.gbParams.TabIndex = 0;
            this.gbParams.TabStop = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(651, 27);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(31, 13);
            this.label6.TabIndex = 6;
            this.label6.Text = "&Base";
            // 
            // tbBase
            // 
            this.tbBase.Location = new System.Drawing.Point(700, 24);
            this.tbBase.Name = "tbBase";
            this.tbBase.Size = new System.Drawing.Size(46, 20);
            this.tbBase.TabIndex = 7;
            this.tbBase.Validating += new System.ComponentModel.CancelEventHandler(this.tbBase_Validating);
            // 
            // ckValid
            // 
            this.ckValid.AutoSize = true;
            this.ckValid.Checked = true;
            this.ckValid.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ckValid.Location = new System.Drawing.Point(507, 77);
            this.ckValid.Name = "ckValid";
            this.ckValid.Size = new System.Drawing.Size(166, 17);
            this.ckValid.TabIndex = 20;
            this.ckValid.Text = "Eléments Validés Unqiuement";
            this.ckValid.UseVisualStyleBackColor = true;
            this.ckValid.CheckedChanged += new System.EventHandler(this.ckValid_CheckedChanged);
            // 
            // tbLibelle
            // 
            this.tbLibelle.Location = new System.Drawing.Point(218, 75);
            this.tbLibelle.Name = "tbLibelle";
            this.tbLibelle.Size = new System.Drawing.Size(254, 20);
            this.tbLibelle.TabIndex = 19;
            this.tbLibelle.Validating += new System.ComponentModel.CancelEventHandler(this.tbLibelle_Validating);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(168, 78);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(37, 13);
            this.label5.TabIndex = 18;
            this.label5.Text = "&Libellé";
            // 
            // tbMontant
            // 
            this.tbMontant.Location = new System.Drawing.Point(81, 75);
            this.tbMontant.Name = "tbMontant";
            this.tbMontant.Size = new System.Drawing.Size(66, 20);
            this.tbMontant.TabIndex = 17;
            this.tbMontant.Validating += new System.ComponentModel.CancelEventHandler(this.tbMontant_Validating);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 78);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 13);
            this.label2.TabIndex = 16;
            this.label2.Text = "&Montant";
            // 
            // tbFournisseur
            // 
            this.tbFournisseur.Location = new System.Drawing.Point(579, 53);
            this.tbFournisseur.Name = "tbFournisseur";
            this.tbFournisseur.Size = new System.Drawing.Size(65, 20);
            this.tbFournisseur.TabIndex = 15;
            this.tbFournisseur.DoubleClick += new System.EventHandler(this.lblFournisseur_Click);
            this.tbFournisseur.Validating += new System.ComponentModel.CancelEventHandler(this.tbFournisseur_Validating);
            // 
            // lblFournisseur
            // 
            this.lblFournisseur.AutoSize = true;
            this.lblFournisseur.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFournisseur.ForeColor = System.Drawing.Color.Blue;
            this.lblFournisseur.Location = new System.Drawing.Point(504, 56);
            this.lblFournisseur.Name = "lblFournisseur";
            this.lblFournisseur.Size = new System.Drawing.Size(64, 13);
            this.lblFournisseur.TabIndex = 14;
            this.lblFournisseur.Text = "&Fournisseur:";
            this.lblFournisseur.Click += new System.EventHandler(this.lblFournisseur_Click);
            // 
            // ckFin
            // 
            this.ckFin.AutoSize = true;
            this.ckFin.Location = new System.Drawing.Point(329, 52);
            this.ckFin.Name = "ckFin";
            this.ckFin.Size = new System.Drawing.Size(39, 17);
            this.ckFin.TabIndex = 12;
            this.ckFin.Text = "A&u";
            this.ckFin.UseVisualStyleBackColor = true;
            // 
            // ckDebut
            // 
            this.ckDebut.AutoSize = true;
            this.ckDebut.Location = new System.Drawing.Point(174, 52);
            this.ckDebut.Name = "ckDebut";
            this.ckDebut.Size = new System.Drawing.Size(40, 17);
            this.ckDebut.TabIndex = 10;
            this.ckDebut.Text = "Du";
            this.ckDebut.UseVisualStyleBackColor = true;
            // 
            // dateFin
            // 
            this.dateFin.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateFin.Location = new System.Drawing.Point(375, 50);
            this.dateFin.Name = "dateFin";
            this.dateFin.Size = new System.Drawing.Size(97, 20);
            this.dateFin.TabIndex = 13;
            // 
            // tbNature
            // 
            this.tbNature.Location = new System.Drawing.Point(82, 50);
            this.tbNature.Name = "tbNature";
            this.tbNature.Size = new System.Drawing.Size(65, 20);
            this.tbNature.TabIndex = 9;
            this.tbNature.DoubleClick += new System.EventHandler(this.lblNature_Click);
            this.tbNature.Validating += new System.ComponentModel.CancelEventHandler(this.tbNature_Validating);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.Blue;
            this.label3.Location = new System.Drawing.Point(6, 53);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(39, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "&Nature";
            this.label3.Click += new System.EventHandler(this.lblNature_Click);
            // 
            // tbLot
            // 
            this.tbLot.Location = new System.Drawing.Point(579, 24);
            this.tbLot.Name = "tbLot";
            this.tbLot.Size = new System.Drawing.Size(46, 20);
            this.tbLot.TabIndex = 5;
            this.tbLot.Validating += new System.ComponentModel.CancelEventHandler(this.tbRefImmeuble_Validating);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(504, 27);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(22, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "&Lot";
            // 
            // dateDebut
            // 
            this.dateDebut.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateDebut.Location = new System.Drawing.Point(218, 50);
            this.dateDebut.Name = "dateDebut";
            this.dateDebut.Size = new System.Drawing.Size(97, 20);
            this.dateDebut.TabIndex = 11;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(168, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(31, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "&Type";
            // 
            // cbTypeOpe
            // 
            this.cbTypeOpe.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTypeOpe.FormattingEnabled = true;
            this.cbTypeOpe.Items.AddRange(new object[] {
            "Factures",
            "Appels de Fonds",
            "Règlements",
            "Opérations",
            "Opérations Dépenses",
            "Opérations Recettes"});
            this.cbTypeOpe.Location = new System.Drawing.Point(218, 25);
            this.cbTypeOpe.Name = "cbTypeOpe";
            this.cbTypeOpe.Size = new System.Drawing.Size(254, 21);
            this.cbTypeOpe.TabIndex = 3;
            this.cbTypeOpe.SelectedIndexChanged += new System.EventHandler(this.cbTypeOpe_SelectedIndexChanged);
            // 
            // tbRefImmeuble
            // 
            this.tbRefImmeuble.Location = new System.Drawing.Point(82, 24);
            this.tbRefImmeuble.Name = "tbRefImmeuble";
            this.tbRefImmeuble.Size = new System.Drawing.Size(65, 20);
            this.tbRefImmeuble.TabIndex = 1;
            this.tbRefImmeuble.DoubleClick += new System.EventHandler(this.tbRefImmeuble_DoubleClick);
            this.tbRefImmeuble.Validating += new System.ComponentModel.CancelEventHandler(this.tbRefImmeuble_Validating);
            // 
            // lblImmeuble
            // 
            this.lblImmeuble.AutoSize = true;
            this.lblImmeuble.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblImmeuble.ForeColor = System.Drawing.Color.Blue;
            this.lblImmeuble.Location = new System.Drawing.Point(6, 27);
            this.lblImmeuble.Name = "lblImmeuble";
            this.lblImmeuble.Size = new System.Drawing.Size(55, 13);
            this.lblImmeuble.TabIndex = 0;
            this.lblImmeuble.Text = "&Immeuble:";
            this.lblImmeuble.Click += new System.EventHandler(this.tbRefImmeuble_DoubleClick);
            // 
            // gbFactures
            // 
            this.gbFactures.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbFactures.Controls.Add(this.dataGridView);
            this.gbFactures.Location = new System.Drawing.Point(12, 121);
            this.gbFactures.Name = "gbFactures";
            this.gbFactures.Size = new System.Drawing.Size(805, 507);
            this.gbFactures.TabIndex = 20;
            this.gbFactures.TabStop = false;
            // 
            // dataGridView
            // 
            this.dataGridView.AllowUserToAddRows = false;
            this.dataGridView.AllowUserToDeleteRows = false;
            this.dataGridView.AllowUserToOrderColumns = true;
            this.dataGridView.AllowUserToResizeRows = false;
            this.dataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView.BackgroundColor = System.Drawing.Color.Snow;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.ContextMenuStrip = this.contextMenuStrip1;
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
            this.dataGridView.Size = new System.Drawing.Size(777, 472);
            this.dataGridView.TabIndex = 0;
            this.dataGridView.ColumnDisplayIndexChanged += new System.Windows.Forms.DataGridViewColumnEventHandler(this.dataGridView_ColumnDisplayIndexChanged);
            this.dataGridView.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView_ColumnHeaderMouseClick);
            this.dataGridView.SelectionChanged += new System.EventHandler(this.dataGridView_SelectionChanged);
            this.dataGridView.DoubleClick += new System.EventHandler(this.dataGridView_DoubleClick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.annulerToolStripMenuItem,
            this.modifierToolStripMenuItem,
            this.modifierNumeroLotToolStripMenuItem,
            this.genererLaFactureToolStripMenuItem,
            this.gnererLeReglementToolStripMenuItem,
            this.supprimerLesÉlémentsToolStripMenuItem,
            this.toolStripSeparator1,
            this.enregistrerLaPrésentationToolStripMenuItem,
            this.présentationParDéfautToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(203, 208);
            this.contextMenuStrip1.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip1_Opening);
            // 
            // annulerToolStripMenuItem
            // 
            this.annulerToolStripMenuItem.Name = "annulerToolStripMenuItem";
            this.annulerToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            this.annulerToolStripMenuItem.Text = "Annuler l\'élément";
            this.annulerToolStripMenuItem.Click += new System.EventHandler(this.annulerToolStripMenuItem_Click);
            // 
            // modifierToolStripMenuItem
            // 
            this.modifierToolStripMenuItem.Name = "modifierToolStripMenuItem";
            this.modifierToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            this.modifierToolStripMenuItem.Text = "Modifier l\'élément";
            this.modifierToolStripMenuItem.Click += new System.EventHandler(this.modifierToolStripMenuItem_Click);
            // 
            // modifierNumeroLotToolStripMenuItem
            // 
            this.modifierNumeroLotToolStripMenuItem.Enabled = false;
            this.modifierNumeroLotToolStripMenuItem.Name = "modifierNumeroLotToolStripMenuItem";
            this.modifierNumeroLotToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            this.modifierNumeroLotToolStripMenuItem.Text = "Modifier Numero Lot";
            this.modifierNumeroLotToolStripMenuItem.Click += new System.EventHandler(this.modifierNumeroLotToolStripMenuItem_Click);
            // 
            // genererLaFactureToolStripMenuItem
            // 
            this.genererLaFactureToolStripMenuItem.Name = "genererLaFactureToolStripMenuItem";
            this.genererLaFactureToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            this.genererLaFactureToolStripMenuItem.Text = "Generer La Facture";
            this.genererLaFactureToolStripMenuItem.Click += new System.EventHandler(this.genererLaFactureToolStripMenuItem_Click);
            // 
            // gnererLeReglementToolStripMenuItem
            // 
            this.gnererLeReglementToolStripMenuItem.Name = "gnererLeReglementToolStripMenuItem";
            this.gnererLeReglementToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            this.gnererLeReglementToolStripMenuItem.Text = "Génerer Le Reglement";
            this.gnererLeReglementToolStripMenuItem.Click += new System.EventHandler(this.genererLeReglementToolStripMenuItem_Click);
            // 
            // supprimerLesÉlémentsToolStripMenuItem
            // 
            this.supprimerLesÉlémentsToolStripMenuItem.Name = "supprimerLesÉlémentsToolStripMenuItem";
            this.supprimerLesÉlémentsToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            this.supprimerLesÉlémentsToolStripMenuItem.Text = "Supprimer les éléments";
            this.supprimerLesÉlémentsToolStripMenuItem.Click += new System.EventHandler(this.supprimerLesÉlémentsToolStripMenuItem_Click);
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
            this.imageList1.Images.SetKeyName(7, "add.png");
            this.imageList1.Images.SetKeyName(8, "excel.png");
            this.imageList1.Images.SetKeyName(9, "zoom.png");
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.btnDetail);
            this.panel1.Controls.Add(this.btnExport);
            this.panel1.Controls.Add(this.btnGrid);
            this.panel1.Controls.Add(this.btnQuit);
            this.panel1.Controls.Add(this.btnEnter);
            this.panel1.Location = new System.Drawing.Point(10, 638);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(805, 39);
            this.panel1.TabIndex = 21;
            // 
            // btnDetail
            // 
            this.btnDetail.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnDetail.CausesValidation = false;
            this.btnDetail.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnDetail.ImageIndex = 9;
            this.btnDetail.ImageList = this.imageList1;
            this.btnDetail.Location = new System.Drawing.Point(223, 6);
            this.btnDetail.Name = "btnDetail";
            this.btnDetail.Size = new System.Drawing.Size(100, 25);
            this.btnDetail.TabIndex = 15;
            this.btnDetail.TabStop = false;
            this.btnDetail.Text = "&Détail";
            this.btnDetail.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDetail.UseVisualStyleBackColor = true;
            this.btnDetail.Click += new System.EventHandler(this.btnDetail_Click);
            // 
            // btnExport
            // 
            this.btnExport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnExport.CausesValidation = false;
            this.btnExport.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnExport.ImageIndex = 8;
            this.btnExport.ImageList = this.imageList1;
            this.btnExport.Location = new System.Drawing.Point(117, 6);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(100, 25);
            this.btnExport.TabIndex = 14;
            this.btnExport.TabStop = false;
            this.btnExport.Text = "E&xporter";
            this.btnExport.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // btnGrid
            // 
            this.btnGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnGrid.CausesValidation = false;
            this.btnGrid.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnGrid.ImageIndex = 7;
            this.btnGrid.ImageList = this.imageList1;
            this.btnGrid.Location = new System.Drawing.Point(9, 6);
            this.btnGrid.Name = "btnGrid";
            this.btnGrid.Size = new System.Drawing.Size(100, 25);
            this.btnGrid.TabIndex = 13;
            this.btnGrid.TabStop = false;
            this.btnGrid.Text = "&Afficher Liste";
            this.btnGrid.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGrid.UseVisualStyleBackColor = true;
            this.btnGrid.Click += new System.EventHandler(this.btnGrid_Click);
            // 
            // btnQuit
            // 
            this.btnQuit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnQuit.CausesValidation = false;
            this.btnQuit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnQuit.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnQuit.ImageIndex = 5;
            this.btnQuit.ImageList = this.imageList1;
            this.btnQuit.Location = new System.Drawing.Point(689, 6);
            this.btnQuit.Name = "btnQuit";
            this.btnQuit.Size = new System.Drawing.Size(100, 25);
            this.btnQuit.TabIndex = 9;
            this.btnQuit.TabStop = false;
            this.btnQuit.Text = "&Quitter";
            this.btnQuit.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnQuit.UseVisualStyleBackColor = true;
            // 
            // btnEnter
            // 
            this.btnEnter.Location = new System.Drawing.Point(397, 6);
            this.btnEnter.Name = "btnEnter";
            this.btnEnter.Size = new System.Drawing.Size(75, 23);
            this.btnEnter.TabIndex = 12;
            this.btnEnter.Text = "button1";
            this.btnEnter.UseVisualStyleBackColor = true;
            this.btnEnter.Click += new System.EventHandler(this.btnEnter_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(181, 6);
            // 
            // enregistrerLaPrésentationToolStripMenuItem
            // 
            this.enregistrerLaPrésentationToolStripMenuItem.Name = "enregistrerLaPrésentationToolStripMenuItem";
            this.enregistrerLaPrésentationToolStripMenuItem.Size = new System.Drawing.Size(202, 22);
            this.enregistrerLaPrésentationToolStripMenuItem.Text = "Enregistrer la présentation";
            this.enregistrerLaPrésentationToolStripMenuItem.Click += new System.EventHandler(this.enregistrerLaPrésentationToolStripMenuItem_Click);
            // 
            // présentationParDéfautToolStripMenuItem
            // 
            this.présentationParDéfautToolStripMenuItem.Name = "présentationParDéfautToolStripMenuItem";
            this.présentationParDéfautToolStripMenuItem.Size = new System.Drawing.Size(202, 22);
            this.présentationParDéfautToolStripMenuItem.Text = "Présentation par défaut";
            this.présentationParDéfautToolStripMenuItem.Click += new System.EventHandler(this.présentationParDéfautToolStripMenuItem_Click);
            // 
            // OperationsGestionForm
            // 
            this.AcceptButton = this.btnEnter;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnQuit;
            this.ClientSize = new System.Drawing.Size(827, 689);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.gbFactures);
            this.Controls.Add(this.gbParams);
            this.Name = "OperationsGestionForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Operations de Gestion";
            this.Load += new System.EventHandler(this.OperationsGestion_Load);
            this.gbParams.ResumeLayout(false);
            this.gbParams.PerformLayout();
            this.gbFactures.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbParams;
        private System.Windows.Forms.DateTimePicker dateDebut;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbTypeOpe;
        private System.Windows.Forms.TextBox tbRefImmeuble;
        private System.Windows.Forms.Label lblImmeuble;
        private System.Windows.Forms.GroupBox gbFactures;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnGrid;
        private System.Windows.Forms.Button btnEnter;
        protected System.Windows.Forms.TextBox tbLot;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.DateTimePicker dateFin;
        protected System.Windows.Forms.TextBox tbNature;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox ckFin;
        private System.Windows.Forms.CheckBox ckDebut;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem annulerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem modifierToolStripMenuItem;
        private System.Windows.Forms.Button btnDetail;
        private System.Windows.Forms.TextBox tbFournisseur;
        private System.Windows.Forms.Label lblFournisseur;
        public System.Windows.Forms.Button btnQuit;
        private System.Windows.Forms.Label label5;
        protected System.Windows.Forms.TextBox tbMontant;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbLibelle;
        private System.Windows.Forms.CheckBox ckValid;
        private System.Windows.Forms.Label label6;
        protected System.Windows.Forms.TextBox tbBase;
        private System.Windows.Forms.ToolStripMenuItem modifierNumeroLotToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem genererLaFactureToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gnererLeReglementToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem supprimerLesÉlémentsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem enregistrerLaPrésentationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem présentationParDéfautToolStripMenuItem;
    }
}