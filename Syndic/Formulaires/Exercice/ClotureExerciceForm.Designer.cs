using System.ComponentModel;
using System.Windows.Forms;

namespace EspaceSyndic.Formulaires.Exercice
{
    partial class ClotureExerciceForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ClotureExerciceForm));
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnExercice = new System.Windows.Forms.Button();
            this.btnDetail = new System.Windows.Forms.Button();
            this.btnExport = new System.Windows.Forms.Button();
            this.btnEnter = new System.Windows.Forms.Button();
            this.btnCloture = new System.Windows.Forms.Button();
            this.btnShowGrid = new System.Windows.Forms.Button();
            this.btnQuit = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnExerciceAdd = new System.Windows.Forms.Button();
            this.lblCredit = new System.Windows.Forms.Label();
            this.tbCredit = new System.Windows.Forms.TextBox();
            this.lblMontant = new System.Windows.Forms.Label();
            this.tbMontant = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dtFin = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.tbSolde = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cbTypeOpe = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dtDeb = new System.Windows.Forms.DateTimePicker();
            this.tbAdresse = new System.Windows.Forms.TextBox();
            this.tbNom = new System.Windows.Forms.TextBox();
            this.tbRefImmeuble = new System.Windows.Forms.TextBox();
            this.lblImmeuble = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
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
            this.imageList1.Images.SetKeyName(8, "del.png");
            this.imageList1.Images.SetKeyName(9, "excel.png");
            this.imageList1.Images.SetKeyName(10, "zoom.png");
            this.imageList1.Images.SetKeyName(11, "loupe.png");
            this.imageList1.Images.SetKeyName(12, "panier_out.png");
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.btnExercice);
            this.panel1.Controls.Add(this.btnDetail);
            this.panel1.Controls.Add(this.btnExport);
            this.panel1.Controls.Add(this.btnEnter);
            this.panel1.Controls.Add(this.btnCloture);
            this.panel1.Controls.Add(this.btnShowGrid);
            this.panel1.Controls.Add(this.btnQuit);
            this.panel1.Location = new System.Drawing.Point(16, 721);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1012, 47);
            this.panel1.TabIndex = 4;
            // 
            // btnExercice
            // 
            this.btnExercice.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnExercice.CausesValidation = false;
            this.btnExercice.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnExercice.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnExercice.ImageIndex = 11;
            this.btnExercice.ImageList = this.imageList1;
            this.btnExercice.Location = new System.Drawing.Point(585, 7);
            this.btnExercice.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnExercice.Name = "btnExercice";
            this.btnExercice.Size = new System.Drawing.Size(133, 31);
            this.btnExercice.TabIndex = 18;
            this.btnExercice.TabStop = false;
            this.btnExercice.Text = "&Réf. Exercice";
            this.btnExercice.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExercice.UseVisualStyleBackColor = true;
            this.btnExercice.Click += new System.EventHandler(this.btnExercice_Click);
            // 
            // btnDetail
            // 
            this.btnDetail.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnDetail.CausesValidation = false;
            this.btnDetail.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnDetail.ImageIndex = 10;
            this.btnDetail.ImageList = this.imageList1;
            this.btnDetail.Location = new System.Drawing.Point(443, 7);
            this.btnDetail.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnDetail.Name = "btnDetail";
            this.btnDetail.Size = new System.Drawing.Size(133, 31);
            this.btnDetail.TabIndex = 17;
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
            this.btnExport.ImageIndex = 9;
            this.btnExport.ImageList = this.imageList1;
            this.btnExport.Location = new System.Drawing.Point(300, 7);
            this.btnExport.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(133, 31);
            this.btnExport.TabIndex = 16;
            this.btnExport.TabStop = false;
            this.btnExport.Text = "E&xporter";
            this.btnExport.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // btnEnter
            // 
            this.btnEnter.Location = new System.Drawing.Point(738, 8);
            this.btnEnter.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnEnter.Name = "btnEnter";
            this.btnEnter.Size = new System.Drawing.Size(100, 28);
            this.btnEnter.TabIndex = 2;
            this.btnEnter.Text = "button1";
            this.btnEnter.UseVisualStyleBackColor = true;
            this.btnEnter.Click += new System.EventHandler(this.btnEnter_Click);
            // 
            // btnCloture
            // 
            this.btnCloture.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCloture.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCloture.ImageIndex = 12;
            this.btnCloture.ImageList = this.imageList1;
            this.btnCloture.Location = new System.Drawing.Point(157, 7);
            this.btnCloture.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnCloture.Name = "btnCloture";
            this.btnCloture.Size = new System.Drawing.Size(133, 31);
            this.btnCloture.TabIndex = 1;
            this.btnCloture.Text = "&Cloturer";
            this.btnCloture.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCloture.UseVisualStyleBackColor = true;
            this.btnCloture.Click += new System.EventHandler(this.btnCloture_Click);
            // 
            // btnShowGrid
            // 
            this.btnShowGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnShowGrid.CausesValidation = false;
            this.btnShowGrid.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnShowGrid.ImageIndex = 7;
            this.btnShowGrid.ImageList = this.imageList1;
            this.btnShowGrid.Location = new System.Drawing.Point(15, 7);
            this.btnShowGrid.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnShowGrid.Name = "btnShowGrid";
            this.btnShowGrid.Size = new System.Drawing.Size(133, 31);
            this.btnShowGrid.TabIndex = 0;
            this.btnShowGrid.Text = "&Afficher la liste";
            this.btnShowGrid.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnShowGrid.UseVisualStyleBackColor = true;
            this.btnShowGrid.Click += new System.EventHandler(this.btnShowGrid_Click);
            // 
            // btnQuit
            // 
            this.btnQuit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnQuit.CausesValidation = false;
            this.btnQuit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnQuit.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnQuit.ImageIndex = 5;
            this.btnQuit.ImageList = this.imageList1;
            this.btnQuit.Location = new System.Drawing.Point(859, 7);
            this.btnQuit.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnQuit.Name = "btnQuit";
            this.btnQuit.Size = new System.Drawing.Size(133, 31);
            this.btnQuit.TabIndex = 3;
            this.btnQuit.TabStop = false;
            this.btnQuit.Text = "&Quitter";
            this.btnQuit.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnQuit.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.btnExerciceAdd);
            this.groupBox1.Controls.Add(this.lblCredit);
            this.groupBox1.Controls.Add(this.tbCredit);
            this.groupBox1.Controls.Add(this.lblMontant);
            this.groupBox1.Controls.Add(this.tbMontant);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.dtFin);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.tbSolde);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.cbTypeOpe);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.dtDeb);
            this.groupBox1.Controls.Add(this.tbAdresse);
            this.groupBox1.Controls.Add(this.tbNom);
            this.groupBox1.Controls.Add(this.tbRefImmeuble);
            this.groupBox1.Controls.Add(this.lblImmeuble);
            this.groupBox1.Location = new System.Drawing.Point(16, 15);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Size = new System.Drawing.Size(1013, 123);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // btnExerciceAdd
            // 
            this.btnExerciceAdd.Location = new System.Drawing.Point(529, 50);
            this.btnExerciceAdd.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnExerciceAdd.Name = "btnExerciceAdd";
            this.btnExerciceAdd.Size = new System.Drawing.Size(29, 27);
            this.btnExerciceAdd.TabIndex = 16;
            this.btnExerciceAdd.TabStop = false;
            this.btnExerciceAdd.Text = "+";
            this.btnExerciceAdd.UseVisualStyleBackColor = true;
            this.btnExerciceAdd.Click += new System.EventHandler(this.btnNouvelExerciceAdd_Click);
            // 
            // lblCredit
            // 
            this.lblCredit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCredit.AutoSize = true;
            this.lblCredit.Location = new System.Drawing.Point(808, 86);
            this.lblCredit.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCredit.Name = "lblCredit";
            this.lblCredit.Size = new System.Drawing.Size(42, 16);
            this.lblCredit.TabIndex = 14;
            this.lblCredit.Text = "Crédit";
            // 
            // tbCredit
            // 
            this.tbCredit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.tbCredit.Enabled = false;
            this.tbCredit.Location = new System.Drawing.Point(884, 81);
            this.tbCredit.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tbCredit.Name = "tbCredit";
            this.tbCredit.Size = new System.Drawing.Size(108, 22);
            this.tbCredit.TabIndex = 15;
            // 
            // lblMontant
            // 
            this.lblMontant.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblMontant.AutoSize = true;
            this.lblMontant.Location = new System.Drawing.Point(557, 86);
            this.lblMontant.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMontant.Name = "lblMontant";
            this.lblMontant.Size = new System.Drawing.Size(54, 16);
            this.lblMontant.TabIndex = 12;
            this.lblMontant.Text = "Montant";
            // 
            // tbMontant
            // 
            this.tbMontant.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.tbMontant.Enabled = false;
            this.tbMontant.Location = new System.Drawing.Point(631, 81);
            this.tbMontant.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tbMontant.Name = "tbMontant";
            this.tbMontant.Size = new System.Drawing.Size(108, 22);
            this.tbMontant.TabIndex = 13;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(372, 55);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(25, 16);
            this.label1.TabIndex = 6;
            this.label1.Text = "&Fin";
            // 
            // dtFin
            // 
            this.dtFin.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtFin.Location = new System.Drawing.Point(416, 52);
            this.dtFin.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dtFin.Name = "dtFin";
            this.dtFin.Size = new System.Drawing.Size(108, 22);
            this.dtFin.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(21, 86);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(185, 16);
            this.label5.TabIndex = 10;
            this.label5.Text = "Solde Bilan Exercice en cours";
            // 
            // tbSolde
            // 
            this.tbSolde.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.tbSolde.Enabled = false;
            this.tbSolde.Location = new System.Drawing.Point(259, 81);
            this.tbSolde.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tbSolde.Name = "tbSolde";
            this.tbSolde.Size = new System.Drawing.Size(108, 22);
            this.tbSolde.TabIndex = 11;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(561, 55);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 16);
            this.label3.TabIndex = 8;
            this.label3.Text = "&Type Op.";
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
            this.cbTypeOpe.Location = new System.Drawing.Point(631, 52);
            this.cbTypeOpe.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cbTypeOpe.Name = "cbTypeOpe";
            this.cbTypeOpe.Size = new System.Drawing.Size(363, 24);
            this.cbTypeOpe.TabIndex = 9;
            this.cbTypeOpe.SelectedIndexChanged += new System.EventHandler(this.cbTypeOpe_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 59);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(175, 16);
            this.label2.TabIndex = 4;
            this.label2.Text = "Date &Début Nouvel exercice";
            // 
            // dtDeb
            // 
            this.dtDeb.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtDeb.Location = new System.Drawing.Point(259, 52);
            this.dtDeb.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dtDeb.Name = "dtDeb";
            this.dtDeb.Size = new System.Drawing.Size(108, 22);
            this.dtDeb.TabIndex = 5;
            this.dtDeb.ValueChanged += new System.EventHandler(this.dtDeb_ValueChanged);
            // 
            // tbAdresse
            // 
            this.tbAdresse.Enabled = false;
            this.tbAdresse.Location = new System.Drawing.Point(631, 23);
            this.tbAdresse.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tbAdresse.Name = "tbAdresse";
            this.tbAdresse.Size = new System.Drawing.Size(363, 22);
            this.tbAdresse.TabIndex = 3;
            this.tbAdresse.TabStop = false;
            // 
            // tbNom
            // 
            this.tbNom.Enabled = false;
            this.tbNom.Location = new System.Drawing.Point(259, 23);
            this.tbNom.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tbNom.Name = "tbNom";
            this.tbNom.Size = new System.Drawing.Size(363, 22);
            this.tbNom.TabIndex = 2;
            this.tbNom.TabStop = false;
            // 
            // tbRefImmeuble
            // 
            this.tbRefImmeuble.Location = new System.Drawing.Point(123, 23);
            this.tbRefImmeuble.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tbRefImmeuble.Name = "tbRefImmeuble";
            this.tbRefImmeuble.Size = new System.Drawing.Size(108, 22);
            this.tbRefImmeuble.TabIndex = 1;
            this.tbRefImmeuble.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbHelpBox_KeyPress);
            this.tbRefImmeuble.Validating += new System.ComponentModel.CancelEventHandler(this.tbRefImmeuble_Validating);
            // 
            // lblImmeuble
            // 
            this.lblImmeuble.AutoSize = true;
            this.lblImmeuble.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblImmeuble.ForeColor = System.Drawing.Color.Blue;
            this.lblImmeuble.Location = new System.Drawing.Point(21, 27);
            this.lblImmeuble.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblImmeuble.Name = "lblImmeuble";
            this.lblImmeuble.Size = new System.Drawing.Size(72, 17);
            this.lblImmeuble.TabIndex = 0;
            this.lblImmeuble.Text = "&Immeuble:";
            this.lblImmeuble.Click += new System.EventHandler(this.lblImmeuble_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.dataGridView);
            this.groupBox2.Location = new System.Drawing.Point(16, 145);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox2.Size = new System.Drawing.Size(1013, 555);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
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
            this.dataGridView.Location = new System.Drawing.Point(24, 25);
            this.dataGridView.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dataGridView.MultiSelect = false;
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.ReadOnly = true;
            this.dataGridView.RowHeadersVisible = false;
            this.dataGridView.RowHeadersWidth = 51;
            this.dataGridView.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView.Size = new System.Drawing.Size(969, 510);
            this.dataGridView.TabIndex = 0;
            // 
            // ClotureExerciceForm
            // 
            this.AcceptButton = this.btnEnter;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnQuit;
            this.ClientSize = new System.Drawing.Size(1045, 784);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "ClotureExerciceForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Cloture Exercice";
            this.Load += new System.EventHandler(this.ClotureExerciceForm_Load);
            this.panel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private ImageList imageList1;
        private Panel panel1;
        private Button btnEnter;
        private Button btnCloture;
        private Button btnShowGrid;
        private Button btnQuit;
        private GroupBox groupBox1;
        private TextBox tbRefImmeuble;
        private Label lblImmeuble;
        private TextBox tbAdresse;
        private TextBox tbNom;
        private Label label2;
        private DateTimePicker dtDeb;
        private GroupBox groupBox2;
        private DataGridView dataGridView;
        private Label label3;
        private ComboBox cbTypeOpe;
        private Label label5;
        private TextBox tbSolde;
        private Label label1;
        private DateTimePicker dtFin;
        private Button btnDetail;
        private Button btnExport;
        private Label lblCredit;
        private TextBox tbCredit;
        private Label lblMontant;
        private TextBox tbMontant;
        private Button btnExercice;
        private Button btnExerciceAdd;
    }
}