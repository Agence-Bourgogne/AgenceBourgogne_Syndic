namespace EspaceSyndic.Formulaires.Ecritures
{
    partial class FicheReglementForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FicheReglementForm));
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cbLiasse = new System.Windows.Forms.ComboBox();
            this.tbMontantLiasse = new System.Windows.Forms.TextBox();
            this.lblLiasse = new System.Windows.Forms.Label();
            this.tbDiff = new System.Windows.Forms.TextBox();
            this.lblDiff = new System.Windows.Forms.Label();
            this.tbTotal = new System.Windows.Forms.TextBox();
            this.lblTotal = new System.Windows.Forms.Label();
            this.panelButton = new System.Windows.Forms.Panel();
            this.btnHelp = new System.Windows.Forms.Button();
            this.imageList2 = new System.Windows.Forms.ImageList(this.components);
            this.btnEnter = new System.Windows.Forms.Button();
            this.btnQuit = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.gbFactures = new System.Windows.Forms.GroupBox();
            this.dataGridViewEcriture = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.dataGridViewLots = new System.Windows.Forms.DataGridView();
            this.reglement = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tbBanque = new System.Windows.Forms.TextBox();
            this.lblBanque = new System.Windows.Forms.Label();
            this.tbEmetteur = new System.Windows.Forms.TextBox();
            this.lblEmetteur = new System.Windows.Forms.Label();
            this.tbLibNature = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbLibelle = new System.Windows.Forms.TextBox();
            this.tbNature = new System.Windows.Forms.TextBox();
            this.lblNature = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tbMontant = new System.Windows.Forms.TextBox();
            this.lblDebit = new System.Windows.Forms.Label();
            this.tbDate = new System.Windows.Forms.MaskedTextBox();
            this.tbLibCopro = new System.Windows.Forms.TextBox();
            this.tbCopro = new System.Windows.Forms.TextBox();
            this.lblCopro = new System.Windows.Forms.Label();
            this.btnDelete = new System.Windows.Forms.Button();
            this.groupBox3.SuspendLayout();
            this.panelButton.SuspendLayout();
            this.gbFactures.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewEcriture)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewLots)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.cbLiasse);
            this.groupBox3.Controls.Add(this.tbMontantLiasse);
            this.groupBox3.Controls.Add(this.lblLiasse);
            this.groupBox3.Controls.Add(this.tbDiff);
            this.groupBox3.Controls.Add(this.lblDiff);
            this.groupBox3.Controls.Add(this.tbTotal);
            this.groupBox3.Controls.Add(this.lblTotal);
            this.groupBox3.Location = new System.Drawing.Point(12, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(760, 57);
            this.groupBox3.TabIndex = 1;
            this.groupBox3.TabStop = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(5, 25);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(40, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "L&iasse:";
            // 
            // cbLiasse
            // 
            this.cbLiasse.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbLiasse.FormattingEnabled = true;
            this.cbLiasse.Location = new System.Drawing.Point(86, 22);
            this.cbLiasse.Name = "cbLiasse";
            this.cbLiasse.Size = new System.Drawing.Size(306, 21);
            this.cbLiasse.TabIndex = 1;
            this.cbLiasse.SelectedIndexChanged += new System.EventHandler(this.cbLiasse_SelectedIndexChanged);
            // 
            // tbMontantLiasse
            // 
            this.tbMontantLiasse.Enabled = false;
            this.tbMontantLiasse.Location = new System.Drawing.Point(571, 22);
            this.tbMontantLiasse.Name = "tbMontantLiasse";
            this.tbMontantLiasse.Size = new System.Drawing.Size(52, 20);
            this.tbMontantLiasse.TabIndex = 4;
            // 
            // lblLiasse
            // 
            this.lblLiasse.AutoSize = true;
            this.lblLiasse.Location = new System.Drawing.Point(528, 27);
            this.lblLiasse.Name = "lblLiasse";
            this.lblLiasse.Size = new System.Drawing.Size(37, 13);
            this.lblLiasse.TabIndex = 3;
            this.lblLiasse.Text = "Liasse";
            // 
            // tbDiff
            // 
            this.tbDiff.Enabled = false;
            this.tbDiff.Location = new System.Drawing.Point(694, 22);
            this.tbDiff.Name = "tbDiff";
            this.tbDiff.Size = new System.Drawing.Size(52, 20);
            this.tbDiff.TabIndex = 6;
            // 
            // lblDiff
            // 
            this.lblDiff.AutoSize = true;
            this.lblDiff.Location = new System.Drawing.Point(629, 27);
            this.lblDiff.Name = "lblDiff";
            this.lblDiff.Size = new System.Drawing.Size(59, 13);
            this.lblDiff.TabIndex = 5;
            this.lblDiff.Text = "Différence:";
            // 
            // tbTotal
            // 
            this.tbTotal.Location = new System.Drawing.Point(471, 22);
            this.tbTotal.Name = "tbTotal";
            this.tbTotal.Size = new System.Drawing.Size(52, 20);
            this.tbTotal.TabIndex = 3;
            this.tbTotal.TextChanged += new System.EventHandler(this.tbTotal_TextChanged);
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Location = new System.Drawing.Point(412, 27);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(34, 13);
            this.lblTotal.TabIndex = 2;
            this.lblTotal.Text = "&Total:";
            // 
            // panelButton
            // 
            this.panelButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelButton.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panelButton.Controls.Add(this.btnDelete);
            this.panelButton.Controls.Add(this.btnHelp);
            this.panelButton.Controls.Add(this.btnEnter);
            this.panelButton.Controls.Add(this.btnQuit);
            this.panelButton.Controls.Add(this.btnAdd);
            this.panelButton.Controls.Add(this.btnSave);
            this.panelButton.Location = new System.Drawing.Point(12, 477);
            this.panelButton.Name = "panelButton";
            this.panelButton.Size = new System.Drawing.Size(760, 35);
            this.panelButton.TabIndex = 2;
            // 
            // btnHelp
            // 
            this.btnHelp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnHelp.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnHelp.ImageKey = "bulle.png";
            this.btnHelp.ImageList = this.imageList2;
            this.btnHelp.Location = new System.Drawing.Point(321, 4);
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Size = new System.Drawing.Size(100, 25);
            this.btnHelp.TabIndex = 3;
            this.btnHelp.Text = "Aide";
            this.btnHelp.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnHelp.UseVisualStyleBackColor = true;
            this.btnHelp.Click += new System.EventHandler(this.btnHelp_Click);
            // 
            // imageList2
            // 
            this.imageList2.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList2.ImageStream")));
            this.imageList2.TransparentColor = System.Drawing.Color.Silver;
            this.imageList2.Images.SetKeyName(0, "top.png");
            this.imageList2.Images.SetKeyName(1, "bottom.png");
            this.imageList2.Images.SetKeyName(2, "previous.png");
            this.imageList2.Images.SetKeyName(3, "next.png");
            this.imageList2.Images.SetKeyName(4, "save.png");
            this.imageList2.Images.SetKeyName(5, "quit.png");
            this.imageList2.Images.SetKeyName(6, "print.png");
            this.imageList2.Images.SetKeyName(7, "add.png");
            this.imageList2.Images.SetKeyName(8, "bulle.png");
            this.imageList2.Images.SetKeyName(9, "del.png");
            // 
            // btnEnter
            // 
            this.btnEnter.Location = new System.Drawing.Point(572, 4);
            this.btnEnter.Name = "btnEnter";
            this.btnEnter.Size = new System.Drawing.Size(75, 23);
            this.btnEnter.TabIndex = 4;
            this.btnEnter.Text = "button1";
            this.btnEnter.UseVisualStyleBackColor = true;
            this.btnEnter.Click += new System.EventHandler(this.btnEnter_Click);
            // 
            // btnQuit
            // 
            this.btnQuit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnQuit.CausesValidation = false;
            this.btnQuit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnQuit.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnQuit.ImageIndex = 5;
            this.btnQuit.ImageList = this.imageList2;
            this.btnQuit.Location = new System.Drawing.Point(653, 4);
            this.btnQuit.Name = "btnQuit";
            this.btnQuit.Size = new System.Drawing.Size(100, 25);
            this.btnQuit.TabIndex = 5;
            this.btnQuit.Text = "&Quitter";
            this.btnQuit.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnQuit.UseVisualStyleBackColor = true;
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAdd.CausesValidation = false;
            this.btnAdd.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAdd.ImageIndex = 7;
            this.btnAdd.ImageList = this.imageList2;
            this.btnAdd.Location = new System.Drawing.Point(5, 4);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(100, 25);
            this.btnAdd.TabIndex = 0;
            this.btnAdd.Text = "&Ajouter";
            this.btnAdd.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSave.ImageKey = "save.png";
            this.btnSave.ImageList = this.imageList2;
            this.btnSave.Location = new System.Drawing.Point(112, 4);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(100, 25);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "&Valider";
            this.btnSave.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // gbFactures
            // 
            this.gbFactures.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbFactures.Controls.Add(this.dataGridViewEcriture);
            this.gbFactures.Location = new System.Drawing.Point(12, 295);
            this.gbFactures.Name = "gbFactures";
            this.gbFactures.Size = new System.Drawing.Size(760, 166);
            this.gbFactures.TabIndex = 104;
            this.gbFactures.TabStop = false;
            this.gbFactures.Text = "Règlements";
            // 
            // dataGridViewEcriture
            // 
            this.dataGridViewEcriture.AllowUserToAddRows = false;
            this.dataGridViewEcriture.AllowUserToDeleteRows = false;
            this.dataGridViewEcriture.AllowUserToResizeRows = false;
            this.dataGridViewEcriture.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewEcriture.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewEcriture.BackgroundColor = System.Drawing.Color.Snow;
            this.dataGridViewEcriture.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewEcriture.Location = new System.Drawing.Point(14, 19);
            this.dataGridViewEcriture.MultiSelect = false;
            this.dataGridViewEcriture.Name = "dataGridViewEcriture";
            this.dataGridViewEcriture.ReadOnly = true;
            this.dataGridViewEcriture.RowHeadersVisible = false;
            this.dataGridViewEcriture.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewEcriture.ShowCellErrors = false;
            this.dataGridViewEcriture.ShowEditingIcon = false;
            this.dataGridViewEcriture.ShowRowErrors = false;
            this.dataGridViewEcriture.Size = new System.Drawing.Size(732, 131);
            this.dataGridViewEcriture.TabIndex = 22;
            this.dataGridViewEcriture.SelectionChanged += new System.EventHandler(this.dataGridViewEcriture_SelectionChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.comboBox1);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.dataGridViewLots);
            this.groupBox1.Controls.Add(this.tbBanque);
            this.groupBox1.Controls.Add(this.lblBanque);
            this.groupBox1.Controls.Add(this.tbEmetteur);
            this.groupBox1.Controls.Add(this.lblEmetteur);
            this.groupBox1.Controls.Add(this.tbLibNature);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.tbLibelle);
            this.groupBox1.Controls.Add(this.tbNature);
            this.groupBox1.Controls.Add(this.lblNature);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.tbMontant);
            this.groupBox1.Controls.Add(this.lblDebit);
            this.groupBox1.Controls.Add(this.tbDate);
            this.groupBox1.Controls.Add(this.tbLibCopro);
            this.groupBox1.Controls.Add(this.tbCopro);
            this.groupBox1.Controls.Add(this.lblCopro);
            this.groupBox1.Location = new System.Drawing.Point(12, 75);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(760, 214);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(632, 71);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(113, 21);
            this.comboBox1.TabIndex = 17;
            this.comboBox1.Visible = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(598, 74);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(32, 13);
            this.label5.TabIndex = 16;
            this.label5.Text = "&Regl:";
            this.label5.Visible = false;
            // 
            // dataGridViewLots
            // 
            this.dataGridViewLots.AllowUserToAddRows = false;
            this.dataGridViewLots.AllowUserToDeleteRows = false;
            this.dataGridViewLots.AllowUserToResizeRows = false;
            this.dataGridViewLots.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewLots.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewLots.BackgroundColor = System.Drawing.Color.Snow;
            this.dataGridViewLots.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewLots.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.reglement});
            this.dataGridViewLots.Location = new System.Drawing.Point(9, 97);
            this.dataGridViewLots.MultiSelect = false;
            this.dataGridViewLots.Name = "dataGridViewLots";
            this.dataGridViewLots.ReadOnly = true;
            this.dataGridViewLots.RowHeadersVisible = false;
            this.dataGridViewLots.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewLots.ShowCellErrors = false;
            this.dataGridViewLots.ShowEditingIcon = false;
            this.dataGridViewLots.ShowRowErrors = false;
            this.dataGridViewLots.Size = new System.Drawing.Size(736, 99);
            this.dataGridViewLots.TabIndex = 41;
            // 
            // reglement
            // 
            this.reglement.HeaderText = "Règlement";
            this.reglement.Name = "reglement";
            this.reglement.ReadOnly = true;
            // 
            // tbBanque
            // 
            this.tbBanque.Location = new System.Drawing.Point(471, 71);
            this.tbBanque.Name = "tbBanque";
            this.tbBanque.Size = new System.Drawing.Size(121, 20);
            this.tbBanque.TabIndex = 15;
            // 
            // lblBanque
            // 
            this.lblBanque.AutoSize = true;
            this.lblBanque.Location = new System.Drawing.Point(412, 74);
            this.lblBanque.Name = "lblBanque";
            this.lblBanque.Size = new System.Drawing.Size(47, 13);
            this.lblBanque.TabIndex = 14;
            this.lblBanque.Text = "&Banque:";
            // 
            // tbEmetteur
            // 
            this.tbEmetteur.Location = new System.Drawing.Point(85, 71);
            this.tbEmetteur.Name = "tbEmetteur";
            this.tbEmetteur.Size = new System.Drawing.Size(307, 20);
            this.tbEmetteur.TabIndex = 13;
            // 
            // lblEmetteur
            // 
            this.lblEmetteur.AutoSize = true;
            this.lblEmetteur.Location = new System.Drawing.Point(5, 74);
            this.lblEmetteur.Name = "lblEmetteur";
            this.lblEmetteur.Size = new System.Drawing.Size(52, 13);
            this.lblEmetteur.TabIndex = 12;
            this.lblEmetteur.Text = "&Emetteur:";
            // 
            // tbLibNature
            // 
            this.tbLibNature.Enabled = false;
            this.tbLibNature.Location = new System.Drawing.Point(156, 45);
            this.tbLibNature.Name = "tbLibNature";
            this.tbLibNature.Size = new System.Drawing.Size(236, 20);
            this.tbLibNature.TabIndex = 9;
            this.tbLibNature.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(412, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "&Libellé:";
            // 
            // tbLibelle
            // 
            this.tbLibelle.AccessibleDescription = "";
            this.tbLibelle.AccessibleName = "";
            this.tbLibelle.Location = new System.Drawing.Point(471, 45);
            this.tbLibelle.Name = "tbLibelle";
            this.tbLibelle.Size = new System.Drawing.Size(273, 20);
            this.tbLibelle.TabIndex = 11;
            this.tbLibelle.KeyUp += new System.Windows.Forms.KeyEventHandler(this.tbLibelle_KeyUp);
            // 
            // tbNature
            // 
            this.tbNature.Location = new System.Drawing.Point(85, 45);
            this.tbNature.Name = "tbNature";
            this.tbNature.Size = new System.Drawing.Size(65, 20);
            this.tbNature.TabIndex = 8;
            this.tbNature.DoubleClick += new System.EventHandler(this.tbNature_DoubleClick);
            this.tbNature.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbHelpBox_KeyPress);
            this.tbNature.Validating += new System.ComponentModel.CancelEventHandler(this.tbNature_Validating);
            // 
            // lblNature
            // 
            this.lblNature.AutoSize = true;
            this.lblNature.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNature.ForeColor = System.Drawing.Color.Blue;
            this.lblNature.Location = new System.Drawing.Point(4, 48);
            this.lblNature.Name = "lblNature";
            this.lblNature.Size = new System.Drawing.Size(42, 13);
            this.lblNature.TabIndex = 7;
            this.lblNature.Text = "&Nature:";
            this.lblNature.Click += new System.EventHandler(this.lblNature_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(629, 18);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(36, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "&Date :";
            // 
            // tbMontant
            // 
            this.tbMontant.Location = new System.Drawing.Point(471, 19);
            this.tbMontant.Name = "tbMontant";
            this.tbMontant.Size = new System.Drawing.Size(49, 20);
            this.tbMontant.TabIndex = 4;
            this.tbMontant.TextChanged += new System.EventHandler(this.tbMontant_TextChanged);
            this.tbMontant.Validating += new System.ComponentModel.CancelEventHandler(this.tbMontant_Validating);
            // 
            // lblDebit
            // 
            this.lblDebit.AutoSize = true;
            this.lblDebit.Location = new System.Drawing.Point(412, 22);
            this.lblDebit.Name = "lblDebit";
            this.lblDebit.Size = new System.Drawing.Size(49, 13);
            this.lblDebit.TabIndex = 3;
            this.lblDebit.Text = "&Montant:";
            // 
            // tbDate
            // 
            this.tbDate.Location = new System.Drawing.Point(681, 15);
            this.tbDate.Mask = "00/00/0000";
            this.tbDate.Name = "tbDate";
            this.tbDate.Size = new System.Drawing.Size(65, 20);
            this.tbDate.TabIndex = 6;
            this.tbDate.ValidatingType = typeof(System.DateTime);
            this.tbDate.Enter += new System.EventHandler(this.tbDate_Enter);
            // 
            // tbLibCopro
            // 
            this.tbLibCopro.Enabled = false;
            this.tbLibCopro.Location = new System.Drawing.Point(157, 19);
            this.tbLibCopro.Name = "tbLibCopro";
            this.tbLibCopro.ReadOnly = true;
            this.tbLibCopro.Size = new System.Drawing.Size(236, 20);
            this.tbLibCopro.TabIndex = 2;
            this.tbLibCopro.TabStop = false;
            // 
            // tbCopro
            // 
            this.tbCopro.Location = new System.Drawing.Point(86, 19);
            this.tbCopro.Name = "tbCopro";
            this.tbCopro.Size = new System.Drawing.Size(65, 20);
            this.tbCopro.TabIndex = 1;
            this.tbCopro.DoubleClick += new System.EventHandler(this.lblCopro_Click);
            this.tbCopro.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbHelpBox_KeyPress);
            this.tbCopro.Validating += new System.ComponentModel.CancelEventHandler(this.tbCopro_Validating);
            // 
            // lblCopro
            // 
            this.lblCopro.AutoSize = true;
            this.lblCopro.ForeColor = System.Drawing.Color.Blue;
            this.lblCopro.Location = new System.Drawing.Point(4, 22);
            this.lblCopro.Name = "lblCopro";
            this.lblCopro.Size = new System.Drawing.Size(75, 13);
            this.lblCopro.TabIndex = 0;
            this.lblCopro.Text = "Co&propriétaire:";
            this.lblCopro.Click += new System.EventHandler(this.lblCopro_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnDelete.ImageKey = "del.png";
            this.btnDelete.ImageList = this.imageList2;
            this.btnDelete.Location = new System.Drawing.Point(215, 4);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(100, 25);
            this.btnDelete.TabIndex = 2;
            this.btnDelete.Text = "&Supprimer";
            this.btnDelete.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // FicheReglementForm
            // 
            this.AcceptButton = this.btnEnter;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnQuit;
            this.ClientSize = new System.Drawing.Size(784, 524);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.gbFactures);
            this.Controls.Add(this.panelButton);
            this.Controls.Add(this.groupBox3);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FicheReglementForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Saisie Reglements";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FicheReglementForm_FormClosing);
            this.Load += new System.EventHandler(this.FicheReglementForm_Load);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.panelButton.ResumeLayout(false);
            this.gbFactures.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewEcriture)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewLots)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        protected System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label4;
        protected System.Windows.Forms.ComboBox cbLiasse;
        protected System.Windows.Forms.TextBox tbMontantLiasse;
        protected System.Windows.Forms.Label lblLiasse;
        protected System.Windows.Forms.TextBox tbDiff;
        protected System.Windows.Forms.Label lblDiff;
        protected System.Windows.Forms.TextBox tbTotal;
        protected System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Panel panelButton;
        private System.Windows.Forms.Button btnQuit;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.GroupBox gbFactures;
        private System.Windows.Forms.DataGridView dataGridViewEcriture;
        private System.Windows.Forms.GroupBox groupBox1;
        protected System.Windows.Forms.TextBox tbLibCopro;
        private System.Windows.Forms.TextBox tbCopro;
        private System.Windows.Forms.Label lblCopro;
        private System.Windows.Forms.TextBox tbMontant;
        private System.Windows.Forms.Label lblDebit;
        private System.Windows.Forms.MaskedTextBox tbDate;
        private System.Windows.Forms.Label label3;
        protected System.Windows.Forms.TextBox tbLibNature;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbLibelle;
        private System.Windows.Forms.TextBox tbNature;
        private System.Windows.Forms.Label lblNature;
        private System.Windows.Forms.TextBox tbBanque;
        private System.Windows.Forms.Label lblBanque;
        private System.Windows.Forms.TextBox tbEmetteur;
        private System.Windows.Forms.Label lblEmetteur;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridView dataGridViewLots;
        private System.Windows.Forms.DataGridViewTextBoxColumn reglement;
        protected System.Windows.Forms.ImageList imageList2;
        private System.Windows.Forms.Button btnEnter;
        private System.Windows.Forms.Button btnHelp;
        private System.Windows.Forms.Button btnDelete;
    }
}