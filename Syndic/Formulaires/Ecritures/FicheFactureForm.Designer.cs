namespace EspaceSyndic.Formulaires.Ecritures
{
    partial class FicheFactureForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FicheFactureForm));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnDel = new System.Windows.Forms.Button();
            this.btnRepart = new System.Windows.Forms.Button();
            this.btnHelp = new System.Windows.Forms.Button();
            this.btnEnter = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnValid = new System.Windows.Forms.Button();
            this.btnQuit = new System.Windows.Forms.Button();
            this.gbCharges = new System.Windows.Forms.GroupBox();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tbLot = new System.Windows.Forms.TextBox();
            this.lblLot = new System.Windows.Forms.Label();
            this.cbReglement = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnFournisseurAdd = new System.Windows.Forms.Button();
            this.btnNatureAdd = new System.Windows.Forms.Button();
            this.tbComment = new System.Windows.Forms.TextBox();
            this.tbCommentaireFournisseur = new System.Windows.Forms.TextBox();
            this.tbMontant = new System.Windows.Forms.TextBox();
            this.tbNomFournisseur = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.tbVilleFournisseur = new System.Windows.Forms.TextBox();
            this.tbCpFournisseur = new System.Windows.Forms.TextBox();
            this.tbAdresseFournisseur = new System.Windows.Forms.TextBox();
            this.tbLibNature = new System.Windows.Forms.TextBox();
            this.tbBase = new System.Windows.Forms.TextBox();
            this.lblBase = new System.Windows.Forms.Label();
            this.tbNature = new System.Windows.Forms.TextBox();
            this.lblNature = new System.Windows.Forms.Label();
            this.tbFournisseur = new System.Windows.Forms.TextBox();
            this.lblFournisseur = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tbDateCreation = new System.Windows.Forms.MaskedTextBox();
            this.tbRefImmeuble = new System.Windows.Forms.TextBox();
            this.lblImmeuble = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnDelLiasse = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.cbLiasse = new System.Windows.Forms.ComboBox();
            this.tbMontantLiasse = new System.Windows.Forms.TextBox();
            this.lblLiasse = new System.Windows.Forms.Label();
            this.tbDiff = new System.Windows.Forms.TextBox();
            this.lblDiff = new System.Windows.Forms.Label();
            this.tbTotal = new System.Windows.Forms.TextBox();
            this.lblTotal = new System.Windows.Forms.Label();
            this.gbFactures = new System.Windows.Forms.GroupBox();
            this.dataGridViewEcriture = new System.Windows.Forms.DataGridView();
            this.RowMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.supprimerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.repartIndividuelleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.enregistrerLaPrésentationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.présentationParDéfautToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.panel1.SuspendLayout();
            this.gbCharges.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.gbFactures.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewEcriture)).BeginInit();
            this.RowMenu.SuspendLayout();
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
            this.imageList1.Images.SetKeyName(7, "add.png");
            this.imageList1.Images.SetKeyName(8, "bulle.png");
            this.imageList1.Images.SetKeyName(9, "bulle_repart.png");
            this.imageList1.Images.SetKeyName(10, "del.png");
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.btnDel);
            this.panel1.Controls.Add(this.btnRepart);
            this.panel1.Controls.Add(this.btnHelp);
            this.panel1.Controls.Add(this.btnEnter);
            this.panel1.Controls.Add(this.btnAdd);
            this.panel1.Controls.Add(this.btnValid);
            this.panel1.Controls.Add(this.btnQuit);
            this.panel1.Location = new System.Drawing.Point(12, 645);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(760, 39);
            this.panel1.TabIndex = 11;
            // 
            // btnDel
            // 
            this.btnDel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnDel.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnDel.ImageIndex = 10;
            this.btnDel.ImageList = this.imageList1;
            this.btnDel.Location = new System.Drawing.Point(431, 6);
            this.btnDel.Name = "btnDel";
            this.btnDel.Size = new System.Drawing.Size(100, 25);
            this.btnDel.TabIndex = 117;
            this.btnDel.Text = "&Supprimer";
            this.btnDel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDel.UseVisualStyleBackColor = true;
            this.btnDel.Click += new System.EventHandler(this.btnDel_Click);
            // 
            // btnRepart
            // 
            this.btnRepart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnRepart.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnRepart.ImageKey = "bulle_repart.png";
            this.btnRepart.ImageList = this.imageList1;
            this.btnRepart.Location = new System.Drawing.Point(325, 6);
            this.btnRepart.Name = "btnRepart";
            this.btnRepart.Size = new System.Drawing.Size(100, 25);
            this.btnRepart.TabIndex = 116;
            this.btnRepart.Text = "Notes Repar&t.";
            this.btnRepart.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRepart.UseVisualStyleBackColor = true;
            this.btnRepart.Click += new System.EventHandler(this.btnRepart_Click);
            // 
            // btnHelp
            // 
            this.btnHelp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnHelp.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnHelp.ImageKey = "bulle.png";
            this.btnHelp.ImageList = this.imageList1;
            this.btnHelp.Location = new System.Drawing.Point(220, 6);
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Size = new System.Drawing.Size(100, 25);
            this.btnHelp.TabIndex = 115;
            this.btnHelp.Text = "Ra&ccourcis";
            this.btnHelp.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnHelp.UseVisualStyleBackColor = true;
            this.btnHelp.Click += new System.EventHandler(this.btnHelp_Click);
            // 
            // btnEnter
            // 
            this.btnEnter.Location = new System.Drawing.Point(563, 8);
            this.btnEnter.Name = "btnEnter";
            this.btnEnter.Size = new System.Drawing.Size(75, 23);
            this.btnEnter.TabIndex = 114;
            this.btnEnter.Text = "button1";
            this.btnEnter.UseVisualStyleBackColor = true;
            this.btnEnter.Click += new System.EventHandler(this.btnEnter_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAdd.CausesValidation = false;
            this.btnAdd.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAdd.ImageIndex = 7;
            this.btnAdd.ImageList = this.imageList1;
            this.btnAdd.Location = new System.Drawing.Point(11, 6);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(100, 25);
            this.btnAdd.TabIndex = 10;
            this.btnAdd.Text = "&Ajouter";
            this.btnAdd.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnValid
            // 
            this.btnValid.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnValid.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnValid.ImageKey = "save.png";
            this.btnValid.ImageList = this.imageList1;
            this.btnValid.Location = new System.Drawing.Point(117, 6);
            this.btnValid.Name = "btnValid";
            this.btnValid.Size = new System.Drawing.Size(100, 25);
            this.btnValid.TabIndex = 11;
            this.btnValid.Text = "&Valider";
            this.btnValid.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnValid.UseVisualStyleBackColor = true;
            this.btnValid.Click += new System.EventHandler(this.btnValid_Click);
            // 
            // btnQuit
            // 
            this.btnQuit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnQuit.CausesValidation = false;
            this.btnQuit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnQuit.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnQuit.ImageIndex = 5;
            this.btnQuit.ImageList = this.imageList1;
            this.btnQuit.Location = new System.Drawing.Point(644, 6);
            this.btnQuit.Name = "btnQuit";
            this.btnQuit.Size = new System.Drawing.Size(100, 25);
            this.btnQuit.TabIndex = 9;
            this.btnQuit.TabStop = false;
            this.btnQuit.Text = "&Quitter";
            this.btnQuit.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnQuit.UseVisualStyleBackColor = true;
            // 
            // gbCharges
            // 
            this.gbCharges.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbCharges.Controls.Add(this.dataGridView);
            this.gbCharges.Location = new System.Drawing.Point(12, 405);
            this.gbCharges.Name = "gbCharges";
            this.gbCharges.Size = new System.Drawing.Size(760, 234);
            this.gbCharges.TabIndex = 99;
            this.gbCharges.TabStop = false;
            this.gbCharges.Text = "Charges";
            // 
            // dataGridView
            // 
            this.dataGridView.AllowUserToAddRows = false;
            this.dataGridView.AllowUserToDeleteRows = false;
            this.dataGridView.AllowUserToResizeColumns = false;
            this.dataGridView.AllowUserToResizeRows = false;
            this.dataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView.BackgroundColor = System.Drawing.Color.Snow;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView.DefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView.Location = new System.Drawing.Point(14, 19);
            this.dataGridView.MultiSelect = false;
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.ReadOnly = true;
            this.dataGridView.RowHeadersVisible = false;
            this.dataGridView.RowHeadersWidth = 31;
            this.dataGridView.ShowCellErrors = false;
            this.dataGridView.ShowEditingIcon = false;
            this.dataGridView.ShowRowErrors = false;
            this.dataGridView.Size = new System.Drawing.Size(732, 200);
            this.dataGridView.TabIndex = 100;
            this.dataGridView.TabStop = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.tbLot);
            this.groupBox1.Controls.Add(this.lblLot);
            this.groupBox1.Controls.Add(this.cbReglement);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.btnFournisseurAdd);
            this.groupBox1.Controls.Add(this.btnNatureAdd);
            this.groupBox1.Controls.Add(this.tbComment);
            this.groupBox1.Controls.Add(this.tbCommentaireFournisseur);
            this.groupBox1.Controls.Add(this.tbMontant);
            this.groupBox1.Controls.Add(this.tbNomFournisseur);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.tbVilleFournisseur);
            this.groupBox1.Controls.Add(this.tbCpFournisseur);
            this.groupBox1.Controls.Add(this.tbAdresseFournisseur);
            this.groupBox1.Controls.Add(this.tbLibNature);
            this.groupBox1.Controls.Add(this.tbBase);
            this.groupBox1.Controls.Add(this.lblBase);
            this.groupBox1.Controls.Add(this.tbNature);
            this.groupBox1.Controls.Add(this.lblNature);
            this.groupBox1.Controls.Add(this.tbFournisseur);
            this.groupBox1.Controls.Add(this.lblFournisseur);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.tbDateCreation);
            this.groupBox1.Controls.Add(this.tbRefImmeuble);
            this.groupBox1.Controls.Add(this.lblImmeuble);
            this.groupBox1.Location = new System.Drawing.Point(12, 75);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(760, 128);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // tbLot
            // 
            this.tbLot.Location = new System.Drawing.Point(504, 22);
            this.tbLot.Name = "tbLot";
            this.tbLot.Size = new System.Drawing.Size(61, 20);
            this.tbLot.TabIndex = 7;
            this.tbLot.Visible = false;
            this.tbLot.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbHelpBox_KeyPress);
            // 
            // lblLot
            // 
            this.lblLot.AutoSize = true;
            this.lblLot.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLot.ForeColor = System.Drawing.Color.Blue;
            this.lblLot.Location = new System.Drawing.Point(473, 25);
            this.lblLot.Name = "lblLot";
            this.lblLot.Size = new System.Drawing.Size(25, 13);
            this.lblLot.TabIndex = 6;
            this.lblLot.Text = "&Lot:";
            this.lblLot.Visible = false;
            this.lblLot.Click += new System.EventHandler(this.lblLot_Click);
            // 
            // cbReglement
            // 
            this.cbReglement.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbReglement.FormattingEnabled = true;
            this.cbReglement.Location = new System.Drawing.Point(86, 99);
            this.cbReglement.Name = "cbReglement";
            this.cbReglement.Size = new System.Drawing.Size(88, 21);
            this.cbReglement.TabIndex = 21;
            this.cbReglement.SelectedIndexChanged += new System.EventHandler(this.cbReglement_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 102);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 13);
            this.label2.TabIndex = 20;
            this.label2.Text = "&Règlement:";
            // 
            // btnFournisseurAdd
            // 
            this.btnFournisseurAdd.Location = new System.Drawing.Point(152, 72);
            this.btnFournisseurAdd.Name = "btnFournisseurAdd";
            this.btnFournisseurAdd.Size = new System.Drawing.Size(22, 22);
            this.btnFournisseurAdd.TabIndex = 17;
            this.btnFournisseurAdd.TabStop = false;
            this.btnFournisseurAdd.Text = "+";
            this.btnFournisseurAdd.UseVisualStyleBackColor = true;
            this.btnFournisseurAdd.Click += new System.EventHandler(this.btnFournisseurAdd_Click);
            // 
            // btnNatureAdd
            // 
            this.btnNatureAdd.Location = new System.Drawing.Point(152, 47);
            this.btnNatureAdd.Name = "btnNatureAdd";
            this.btnNatureAdd.Size = new System.Drawing.Size(22, 22);
            this.btnNatureAdd.TabIndex = 12;
            this.btnNatureAdd.TabStop = false;
            this.btnNatureAdd.Text = "+";
            this.btnNatureAdd.UseVisualStyleBackColor = true;
            this.btnNatureAdd.Click += new System.EventHandler(this.btnNatureAdd_Click);
            // 
            // tbComment
            // 
            this.tbComment.AccessibleDescription = "";
            this.tbComment.AccessibleName = "";
            this.tbComment.Location = new System.Drawing.Point(473, 48);
            this.tbComment.Name = "tbComment";
            this.tbComment.Size = new System.Drawing.Size(273, 20);
            this.tbComment.TabIndex = 14;
            this.tbComment.KeyUp += new System.Windows.Forms.KeyEventHandler(this.tbComment_KeyUp);
            // 
            // tbCommentaireFournisseur
            // 
            this.tbCommentaireFournisseur.Location = new System.Drawing.Point(473, 74);
            this.tbCommentaireFournisseur.Name = "tbCommentaireFournisseur";
            this.tbCommentaireFournisseur.Size = new System.Drawing.Size(273, 20);
            this.tbCommentaireFournisseur.TabIndex = 19;
            // 
            // tbMontant
            // 
            this.tbMontant.Location = new System.Drawing.Point(681, 22);
            this.tbMontant.Name = "tbMontant";
            this.tbMontant.Size = new System.Drawing.Size(65, 20);
            this.tbMontant.TabIndex = 9;
            this.tbMontant.TextChanged += new System.EventHandler(this.tbMontantFac_TextChanged);
            // 
            // tbNomFournisseur
            // 
            this.tbNomFournisseur.Enabled = false;
            this.tbNomFournisseur.Location = new System.Drawing.Point(186, 74);
            this.tbNomFournisseur.Name = "tbNomFournisseur";
            this.tbNomFournisseur.Size = new System.Drawing.Size(273, 20);
            this.tbNomFournisseur.TabIndex = 18;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(626, 25);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(49, 13);
            this.label8.TabIndex = 8;
            this.label8.Text = "&Montant:";
            // 
            // tbVilleFournisseur
            // 
            this.tbVilleFournisseur.Enabled = false;
            this.tbVilleFournisseur.Location = new System.Drawing.Point(473, 99);
            this.tbVilleFournisseur.Name = "tbVilleFournisseur";
            this.tbVilleFournisseur.Size = new System.Drawing.Size(273, 20);
            this.tbVilleFournisseur.TabIndex = 24;
            // 
            // tbCpFournisseur
            // 
            this.tbCpFournisseur.Enabled = false;
            this.tbCpFournisseur.Location = new System.Drawing.Point(382, 99);
            this.tbCpFournisseur.Name = "tbCpFournisseur";
            this.tbCpFournisseur.Size = new System.Drawing.Size(77, 20);
            this.tbCpFournisseur.TabIndex = 23;
            // 
            // tbAdresseFournisseur
            // 
            this.tbAdresseFournisseur.Enabled = false;
            this.tbAdresseFournisseur.Location = new System.Drawing.Point(186, 99);
            this.tbAdresseFournisseur.Name = "tbAdresseFournisseur";
            this.tbAdresseFournisseur.Size = new System.Drawing.Size(191, 20);
            this.tbAdresseFournisseur.TabIndex = 22;
            // 
            // tbLibNature
            // 
            this.tbLibNature.Enabled = false;
            this.tbLibNature.Location = new System.Drawing.Point(186, 48);
            this.tbLibNature.Name = "tbLibNature";
            this.tbLibNature.Size = new System.Drawing.Size(273, 20);
            this.tbLibNature.TabIndex = 13;
            this.tbLibNature.TabStop = false;
            // 
            // tbBase
            // 
            this.tbBase.Location = new System.Drawing.Point(419, 22);
            this.tbBase.Name = "tbBase";
            this.tbBase.Size = new System.Drawing.Size(40, 20);
            this.tbBase.TabIndex = 5;
            this.tbBase.TextChanged += new System.EventHandler(this.tbBase_TextChanged);
            // 
            // lblBase
            // 
            this.lblBase.AutoSize = true;
            this.lblBase.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBase.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblBase.Location = new System.Drawing.Point(379, 25);
            this.lblBase.Name = "lblBase";
            this.lblBase.Size = new System.Drawing.Size(34, 13);
            this.lblBase.TabIndex = 4;
            this.lblBase.Text = "&Base:";
            // 
            // tbNature
            // 
            this.tbNature.Location = new System.Drawing.Point(86, 48);
            this.tbNature.Name = "tbNature";
            this.tbNature.Size = new System.Drawing.Size(65, 20);
            this.tbNature.TabIndex = 11;
            this.tbNature.DoubleClick += new System.EventHandler(this.lblNature_Click);
            this.tbNature.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbHelpBox_KeyPress);
            this.tbNature.Validating += new System.ComponentModel.CancelEventHandler(this.tbNature_Validating);
            // 
            // lblNature
            // 
            this.lblNature.AutoSize = true;
            this.lblNature.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNature.ForeColor = System.Drawing.Color.Blue;
            this.lblNature.Location = new System.Drawing.Point(10, 51);
            this.lblNature.Name = "lblNature";
            this.lblNature.Size = new System.Drawing.Size(42, 13);
            this.lblNature.TabIndex = 10;
            this.lblNature.Text = "&Nature:";
            this.lblNature.Click += new System.EventHandler(this.lblNature_Click);
            // 
            // tbFournisseur
            // 
            this.tbFournisseur.Location = new System.Drawing.Point(86, 74);
            this.tbFournisseur.Name = "tbFournisseur";
            this.tbFournisseur.Size = new System.Drawing.Size(65, 20);
            this.tbFournisseur.TabIndex = 16;
            this.tbFournisseur.DoubleClick += new System.EventHandler(this.lblFournisseur_Click);
            this.tbFournisseur.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbHelpBox_KeyPress);
            this.tbFournisseur.Validating += new System.ComponentModel.CancelEventHandler(this.tbFournisseur_Validating);
            // 
            // lblFournisseur
            // 
            this.lblFournisseur.AutoSize = true;
            this.lblFournisseur.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFournisseur.ForeColor = System.Drawing.Color.Blue;
            this.lblFournisseur.Location = new System.Drawing.Point(11, 77);
            this.lblFournisseur.Name = "lblFournisseur";
            this.lblFournisseur.Size = new System.Drawing.Size(64, 13);
            this.lblFournisseur.TabIndex = 15;
            this.lblFournisseur.Text = "&Fournisseur:";
            this.lblFournisseur.Click += new System.EventHandler(this.lblFournisseur_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(183, 25);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "&Date Création:";
            // 
            // tbDateCreation
            // 
            this.tbDateCreation.Location = new System.Drawing.Point(261, 22);
            this.tbDateCreation.Mask = "00/00/0000";
            this.tbDateCreation.Name = "tbDateCreation";
            this.tbDateCreation.Size = new System.Drawing.Size(81, 20);
            this.tbDateCreation.TabIndex = 3;
            this.tbDateCreation.ValidatingType = typeof(System.DateTime);
            this.tbDateCreation.Enter += new System.EventHandler(this.tbDateCreation_Enter);
            // 
            // tbRefImmeuble
            // 
            this.tbRefImmeuble.Location = new System.Drawing.Point(86, 22);
            this.tbRefImmeuble.Name = "tbRefImmeuble";
            this.tbRefImmeuble.Size = new System.Drawing.Size(65, 20);
            this.tbRefImmeuble.TabIndex = 1;
            this.tbRefImmeuble.DoubleClick += new System.EventHandler(this.lblImmeuble_Click);
            this.tbRefImmeuble.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbHelpBox_KeyPress);
            this.tbRefImmeuble.Validating += new System.ComponentModel.CancelEventHandler(this.tbRefImmeuble_Validating);
            // 
            // lblImmeuble
            // 
            this.lblImmeuble.AutoSize = true;
            this.lblImmeuble.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblImmeuble.ForeColor = System.Drawing.Color.Blue;
            this.lblImmeuble.Location = new System.Drawing.Point(10, 25);
            this.lblImmeuble.Name = "lblImmeuble";
            this.lblImmeuble.Size = new System.Drawing.Size(55, 13);
            this.lblImmeuble.TabIndex = 0;
            this.lblImmeuble.Text = "&Immeuble:";
            this.lblImmeuble.Click += new System.EventHandler(this.lblImmeuble_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.btnDelLiasse);
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
            // btnDelLiasse
            // 
            this.btnDelLiasse.Location = new System.Drawing.Point(400, 22);
            this.btnDelLiasse.Name = "btnDelLiasse";
            this.btnDelLiasse.Size = new System.Drawing.Size(25, 23);
            this.btnDelLiasse.TabIndex = 7;
            this.btnDelLiasse.Text = "-";
            this.toolTip1.SetToolTip(this.btnDelLiasse, "Supprimer la liasse courant");
            this.btnDelLiasse.UseVisualStyleBackColor = true;
            this.btnDelLiasse.Visible = false;
            this.btnDelLiasse.Click += new System.EventHandler(this.btnDelLiasse_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(10, 27);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(40, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "&Liasse:";
            // 
            // cbLiasse
            // 
            this.cbLiasse.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbLiasse.Enabled = false;
            this.cbLiasse.FormattingEnabled = true;
            this.cbLiasse.Location = new System.Drawing.Point(86, 22);
            this.cbLiasse.Name = "cbLiasse";
            this.cbLiasse.Size = new System.Drawing.Size(308, 21);
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
            this.lblTotal.Location = new System.Drawing.Point(431, 27);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(34, 13);
            this.lblTotal.TabIndex = 2;
            this.lblTotal.Text = "&Total:";
            // 
            // gbFactures
            // 
            this.gbFactures.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbFactures.Controls.Add(this.dataGridViewEcriture);
            this.gbFactures.Location = new System.Drawing.Point(12, 209);
            this.gbFactures.Name = "gbFactures";
            this.gbFactures.Size = new System.Drawing.Size(760, 190);
            this.gbFactures.TabIndex = 18;
            this.gbFactures.TabStop = false;
            this.gbFactures.Text = "Factures";
            // 
            // dataGridViewEcriture
            // 
            this.dataGridViewEcriture.AllowUserToAddRows = false;
            this.dataGridViewEcriture.AllowUserToDeleteRows = false;
            this.dataGridViewEcriture.AllowUserToResizeRows = false;
            this.dataGridViewEcriture.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewEcriture.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dataGridViewEcriture.BackgroundColor = System.Drawing.Color.Snow;
            this.dataGridViewEcriture.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewEcriture.ContextMenuStrip = this.RowMenu;
            this.dataGridViewEcriture.Location = new System.Drawing.Point(14, 19);
            this.dataGridViewEcriture.MultiSelect = false;
            this.dataGridViewEcriture.Name = "dataGridViewEcriture";
            this.dataGridViewEcriture.ReadOnly = true;
            this.dataGridViewEcriture.RowHeadersVisible = false;
            this.dataGridViewEcriture.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewEcriture.ShowCellErrors = false;
            this.dataGridViewEcriture.ShowEditingIcon = false;
            this.dataGridViewEcriture.ShowRowErrors = false;
            this.dataGridViewEcriture.Size = new System.Drawing.Size(732, 156);
            this.dataGridViewEcriture.TabIndex = 0;
            this.dataGridViewEcriture.SelectionChanged += new System.EventHandler(this.dataGridViewEcriture_SelectionChanged);
            this.dataGridViewEcriture.DoubleClick += new System.EventHandler(this.dataGridViewEcriture_DoubleClick);
            // 
            // RowMenu
            // 
            this.RowMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.supprimerToolStripMenuItem,
            this.repartIndividuelleToolStripMenuItem,
            this.toolStripSeparator1,
            this.enregistrerLaPrésentationToolStripMenuItem,
            this.présentationParDéfautToolStripMenuItem});
            this.RowMenu.Name = "RowMenu";
            this.RowMenu.Size = new System.Drawing.Size(203, 98);
            this.RowMenu.Text = "RowMenu";
            this.RowMenu.Opening += new System.ComponentModel.CancelEventHandler(this.RowMenu_Opening);
            // 
            // supprimerToolStripMenuItem
            // 
            this.supprimerToolStripMenuItem.Name = "supprimerToolStripMenuItem";
            this.supprimerToolStripMenuItem.Size = new System.Drawing.Size(202, 22);
            this.supprimerToolStripMenuItem.Text = "Supprimer";
            this.supprimerToolStripMenuItem.Click += new System.EventHandler(this.supprimerToolStripMenuItem_Click);
            // 
            // repartIndividuelleToolStripMenuItem
            // 
            this.repartIndividuelleToolStripMenuItem.Name = "repartIndividuelleToolStripMenuItem";
            this.repartIndividuelleToolStripMenuItem.Size = new System.Drawing.Size(202, 22);
            this.repartIndividuelleToolStripMenuItem.Text = "Répartition Individuelle";
            this.repartIndividuelleToolStripMenuItem.Click += new System.EventHandler(this.repartIndividuelleToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(199, 6);
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
            // FicheFactureForm
            // 
            this.AcceptButton = this.btnEnter;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnQuit;
            this.ClientSize = new System.Drawing.Size(784, 691);
            this.Controls.Add(this.gbFactures);
            this.Controls.Add(this.gbCharges);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FicheFactureForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Saisie Facture Fournisseur";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FicheFactureForm_FormClosing);
            this.Load += new System.EventHandler(this.FicheFactureForm_Load);
            this.Shown += new System.EventHandler(this.FicheEcritureForm_Shown);
            this.panel1.ResumeLayout(false);
            this.gbCharges.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.gbFactures.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewEcriture)).EndInit();
            this.RowMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnQuit;
        private System.Windows.Forms.GroupBox gbCharges;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox tbBase;
        private System.Windows.Forms.Label lblBase;
        private System.Windows.Forms.TextBox tbNature;
        private System.Windows.Forms.Label lblNature;
        private System.Windows.Forms.TextBox tbFournisseur;
        private System.Windows.Forms.Label lblFournisseur;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.MaskedTextBox tbDateCreation;
        private System.Windows.Forms.TextBox tbRefImmeuble;
        private System.Windows.Forms.Label lblImmeuble;
        private System.Windows.Forms.TextBox tbLibNature;
        private System.Windows.Forms.TextBox tbMontant;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox tbVilleFournisseur;
        private System.Windows.Forms.TextBox tbCpFournisseur;
        private System.Windows.Forms.TextBox tbAdresseFournisseur;
        private System.Windows.Forms.TextBox tbNomFournisseur;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox tbTotal;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.TextBox tbDiff;
        private System.Windows.Forms.Label lblDiff;
        private System.Windows.Forms.GroupBox gbFactures;
        private System.Windows.Forms.DataGridView dataGridViewEcriture;
        private System.Windows.Forms.TextBox tbCommentaireFournisseur;
        private System.Windows.Forms.TextBox tbMontantLiasse;
        private System.Windows.Forms.Label lblLiasse;
        private System.Windows.Forms.TextBox tbComment;
        private System.Windows.Forms.Button btnNatureAdd;
        private System.Windows.Forms.ComboBox cbLiasse;
        private System.Windows.Forms.Button btnFournisseurAdd;
        private System.Windows.Forms.ContextMenuStrip RowMenu;
        private System.Windows.Forms.ToolStripMenuItem supprimerToolStripMenuItem;
        private System.Windows.Forms.ComboBox cbReglement;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ToolStripMenuItem repartIndividuelleToolStripMenuItem;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnValid;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnEnter;
        private System.Windows.Forms.Button btnHelp;
        private System.Windows.Forms.Button btnRepart;
        protected System.Windows.Forms.TextBox tbLot;
        protected System.Windows.Forms.Label lblLot;
        private System.Windows.Forms.Button btnDel;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem enregistrerLaPrésentationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem présentationParDéfautToolStripMenuItem;
        private System.Windows.Forms.Button btnDelLiasse;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}