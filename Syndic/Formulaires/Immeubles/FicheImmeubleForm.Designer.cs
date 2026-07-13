using System.ComponentModel;
using System.Windows.Forms;

namespace EspaceSyndic.Formulaires.Immeubles
{
    partial class FicheImmeubleForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FicheImmeubleForm));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ckDesactiv = new System.Windows.Forms.CheckBox();
            this.tbNoteRepart = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.tbNote = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.tbLots = new System.Windows.Forms.MaskedTextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.tbCompteBanque = new System.Windows.Forms.MaskedTextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.tbVille = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.tbCodePostal = new System.Windows.Forms.MaskedTextBox();
            this.tbAdresse = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tbNom = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tbDateCreation = new System.Windows.Forms.MaskedTextBox();
            this.tbNumero = new System.Windows.Forms.TextBox();
            this.lblRef = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblExercice = new System.Windows.Forms.Label();
            this.btnEnter = new System.Windows.Forms.Button();
            this.lblTxtImmeuble = new System.Windows.Forms.Label();
            this.lblTitre = new System.Windows.Forms.Label();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.btnFirst = new System.Windows.Forms.Button();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.btnPrev = new System.Windows.Forms.Button();
            this.btnNext = new System.Windows.Forms.Button();
            this.btnLast = new System.Windows.Forms.Button();
            this.btnQuit = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnModifLot = new System.Windows.Forms.Button();
            this.btnModif = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.tbAppel = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.ckDesactiv);
            this.groupBox1.Controls.Add(this.tbNoteRepart);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.tbNote);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.tbLots);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.tbCompteBanque);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.tbVille);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.tbCodePostal);
            this.groupBox1.Controls.Add(this.tbAdresse);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.tbNom);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.tbDateCreation);
            this.groupBox1.Controls.Add(this.tbNumero);
            this.groupBox1.Controls.Add(this.lblRef);
            this.groupBox1.Location = new System.Drawing.Point(12, 42);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(760, 235);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Description Immeuble";
            // 
            // ckDesactiv
            // 
            this.ckDesactiv.AutoSize = true;
            this.ckDesactiv.Location = new System.Drawing.Point(14, 188);
            this.ckDesactiv.Name = "ckDesactiv";
            this.ckDesactiv.Size = new System.Drawing.Size(74, 17);
            this.ckDesactiv.TabIndex = 20;
            this.ckDesactiv.Text = "Désactivé";
            this.ckDesactiv.UseVisualStyleBackColor = true;
            // 
            // tbNoteRepart
            // 
            this.tbNoteRepart.AcceptsReturn = true;
            this.tbNoteRepart.AcceptsTab = true;
            this.tbNoteRepart.Location = new System.Drawing.Point(463, 102);
            this.tbNoteRepart.Multiline = true;
            this.tbNoteRepart.Name = "tbNoteRepart";
            this.tbNoteRepart.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tbNoteRepart.Size = new System.Drawing.Size(283, 76);
            this.tbNoteRepart.TabIndex = 19;
            // 
            // label11
            // 
            this.label11.Location = new System.Drawing.Point(389, 102);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(72, 50);
            this.label11.TabIndex = 18;
            this.label11.Text = "Note &Répartition:";
            // 
            // tbNote
            // 
            this.tbNote.AcceptsReturn = true;
            this.tbNote.AcceptsTab = true;
            this.tbNote.Location = new System.Drawing.Point(86, 102);
            this.tbNote.Multiline = true;
            this.tbNote.Name = "tbNote";
            this.tbNote.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tbNote.Size = new System.Drawing.Size(297, 76);
            this.tbNote.TabIndex = 17;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(10, 105);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(33, 13);
            this.label10.TabIndex = 16;
            this.label10.Text = "&Note:";
            // 
            // tbLots
            // 
            this.tbLots.Location = new System.Drawing.Point(463, 73);
            this.tbLots.Name = "tbLots";
            this.tbLots.Size = new System.Drawing.Size(81, 20);
            this.tbLots.TabIndex = 15;
            this.tbLots.TextChanged += new System.EventHandler(this.tbTextChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(389, 76);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(58, 13);
            this.label9.TabIndex = 14;
            this.label9.Text = "Nb de &lots:";
            // 
            // tbCompteBanque
            // 
            this.tbCompteBanque.Location = new System.Drawing.Point(86, 73);
            this.tbCompteBanque.Mask = "99999999999";
            this.tbCompteBanque.Name = "tbCompteBanque";
            this.tbCompteBanque.PromptChar = ' ';
            this.tbCompteBanque.Size = new System.Drawing.Size(81, 20);
            this.tbCompteBanque.TabIndex = 13;
            this.tbCompteBanque.TextChanged += new System.EventHandler(this.tbTextChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(11, 76);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(77, 13);
            this.label8.TabIndex = 12;
            this.label8.Text = "Cpt &Banquaire:";
            // 
            // tbVille
            // 
            this.tbVille.Location = new System.Drawing.Point(596, 48);
            this.tbVille.Name = "tbVille";
            this.tbVille.Size = new System.Drawing.Size(150, 20);
            this.tbVille.TabIndex = 11;
            this.tbVille.TextChanged += new System.EventHandler(this.tbTextChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(558, 51);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(29, 13);
            this.label7.TabIndex = 10;
            this.label7.Text = "&Ville:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(389, 51);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(67, 13);
            this.label6.TabIndex = 9;
            this.label6.Text = "&Code Postal:";
            // 
            // tbCodePostal
            // 
            this.tbCodePostal.Location = new System.Drawing.Point(463, 49);
            this.tbCodePostal.Name = "tbCodePostal";
            this.tbCodePostal.Size = new System.Drawing.Size(81, 20);
            this.tbCodePostal.TabIndex = 8;
            this.tbCodePostal.TextChanged += new System.EventHandler(this.tbTextChanged);
            // 
            // tbAdresse
            // 
            this.tbAdresse.Location = new System.Drawing.Point(86, 48);
            this.tbAdresse.Name = "tbAdresse";
            this.tbAdresse.Size = new System.Drawing.Size(297, 20);
            this.tbAdresse.TabIndex = 7;
            this.tbAdresse.TextChanged += new System.EventHandler(this.tbTextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(10, 52);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(48, 13);
            this.label5.TabIndex = 6;
            this.label5.Text = "&Adresse:";
            // 
            // tbNom
            // 
            this.tbNom.Location = new System.Drawing.Point(463, 22);
            this.tbNom.Name = "tbNom";
            this.tbNom.Size = new System.Drawing.Size(283, 20);
            this.tbNom.TabIndex = 5;
            this.tbNom.TextChanged += new System.EventHandler(this.tbTextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(389, 25);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(32, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "&Nom:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(215, 25);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "&Date Création:";
            // 
            // tbDateCreation
            // 
            this.tbDateCreation.Location = new System.Drawing.Point(302, 22);
            this.tbDateCreation.Mask = "00/00/0000";
            this.tbDateCreation.Name = "tbDateCreation";
            this.tbDateCreation.Size = new System.Drawing.Size(81, 20);
            this.tbDateCreation.TabIndex = 2;
            this.tbDateCreation.ValidatingType = typeof(System.DateTime);
            this.tbDateCreation.TextChanged += new System.EventHandler(this.tbTextChanged);
            // 
            // tbNumero
            // 
            this.tbNumero.Location = new System.Drawing.Point(86, 22);
            this.tbNumero.Name = "tbNumero";
            this.tbNumero.Size = new System.Drawing.Size(100, 20);
            this.tbNumero.TabIndex = 1;
            this.tbNumero.TextChanged += new System.EventHandler(this.tbTextChanged);
            // 
            // lblRef
            // 
            this.lblRef.AutoSize = true;
            this.lblRef.ForeColor = System.Drawing.Color.Blue;
            this.lblRef.Location = new System.Drawing.Point(10, 25);
            this.lblRef.Name = "lblRef";
            this.lblRef.Size = new System.Drawing.Size(60, 13);
            this.lblRef.TabIndex = 0;
            this.lblRef.Text = "&Référence:";
            this.lblRef.Click += new System.EventHandler(this.lblRef_Click);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(230, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(358, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "Agence Bourgogne : Fichier des Immeubles";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.lblExercice);
            this.groupBox2.Controls.Add(this.btnEnter);
            this.groupBox2.Controls.Add(this.lblTxtImmeuble);
            this.groupBox2.Controls.Add(this.lblTitre);
            this.groupBox2.Controls.Add(this.dataGridView);
            this.groupBox2.Location = new System.Drawing.Point(12, 283);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(760, 259);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Charges";
            // 
            // lblExercice
            // 
            this.lblExercice.AutoSize = true;
            this.lblExercice.ForeColor = System.Drawing.Color.Blue;
            this.lblExercice.Location = new System.Drawing.Point(359, 16);
            this.lblExercice.Name = "lblExercice";
            this.lblExercice.Size = new System.Drawing.Size(88, 13);
            this.lblExercice.TabIndex = 117;
            this.lblExercice.Text = "Exercice Courant";
            this.lblExercice.Click += new System.EventHandler(this.lblExercice_Click);
            // 
            // btnEnter
            // 
            this.btnEnter.Location = new System.Drawing.Point(343, 118);
            this.btnEnter.Name = "btnEnter";
            this.btnEnter.Size = new System.Drawing.Size(75, 23);
            this.btnEnter.TabIndex = 116;
            this.btnEnter.Text = "button1";
            this.btnEnter.UseVisualStyleBackColor = true;
            this.btnEnter.Click += new System.EventHandler(this.btnEnter_Click);
            // 
            // lblTxtImmeuble
            // 
            this.lblTxtImmeuble.AutoSize = true;
            this.lblTxtImmeuble.ForeColor = System.Drawing.Color.Blue;
            this.lblTxtImmeuble.Location = new System.Drawing.Point(11, 16);
            this.lblTxtImmeuble.Name = "lblTxtImmeuble";
            this.lblTxtImmeuble.Size = new System.Drawing.Size(87, 13);
            this.lblTxtImmeuble.TabIndex = 2;
            this.lblTxtImmeuble.Text = "Textes Immeuble";
            this.lblTxtImmeuble.Click += new System.EventHandler(this.lblTextesImmeuble_Click);
            this.lblTxtImmeuble.Enter += new System.EventHandler(this.lblTitre_Click);
            // 
            // lblTitre
            // 
            this.lblTitre.AutoSize = true;
            this.lblTitre.ForeColor = System.Drawing.Color.Blue;
            this.lblTitre.Location = new System.Drawing.Point(643, 16);
            this.lblTitre.Name = "lblTitre";
            this.lblTitre.Size = new System.Drawing.Size(103, 13);
            this.lblTitre.TabIndex = 1;
            this.lblTitre.Text = "Mise à jour des &titres";
            this.lblTitre.Click += new System.EventHandler(this.lblTitre_Click);
            // 
            // dataGridView
            // 
            this.dataGridView.AllowUserToAddRows = false;
            this.dataGridView.AllowUserToDeleteRows = false;
            this.dataGridView.AllowUserToResizeRows = false;
            this.dataGridView.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Location = new System.Drawing.Point(14, 43);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.RowHeadersVisible = false;
            this.dataGridView.ShowCellErrors = false;
            this.dataGridView.ShowEditingIcon = false;
            this.dataGridView.ShowRowErrors = false;
            this.dataGridView.Size = new System.Drawing.Size(732, 200);
            this.dataGridView.TabIndex = 0;
            this.dataGridView.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_CellValueChanged);
            // 
            // btnFirst
            // 
            this.btnFirst.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnFirst.ImageIndex = 0;
            this.btnFirst.ImageList = this.imageList1;
            this.btnFirst.Location = new System.Drawing.Point(4, 5);
            this.btnFirst.Name = "btnFirst";
            this.btnFirst.Size = new System.Drawing.Size(80, 25);
            this.btnFirst.TabIndex = 4;
            this.btnFirst.Text = "&Début";
            this.btnFirst.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnFirst.UseVisualStyleBackColor = true;
            this.btnFirst.Click += new System.EventHandler(this.btnFirst_Click);
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
            // 
            // btnPrev
            // 
            this.btnPrev.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPrev.ImageIndex = 2;
            this.btnPrev.ImageList = this.imageList1;
            this.btnPrev.Location = new System.Drawing.Point(90, 5);
            this.btnPrev.Name = "btnPrev";
            this.btnPrev.Size = new System.Drawing.Size(80, 25);
            this.btnPrev.TabIndex = 5;
            this.btnPrev.Text = "&Précédent";
            this.btnPrev.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnPrev.UseVisualStyleBackColor = true;
            this.btnPrev.Click += new System.EventHandler(this.btnPrev_Click);
            // 
            // btnNext
            // 
            this.btnNext.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnNext.ImageIndex = 3;
            this.btnNext.ImageList = this.imageList1;
            this.btnNext.Location = new System.Drawing.Point(176, 5);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(80, 25);
            this.btnNext.TabIndex = 6;
            this.btnNext.Text = "&Suivant";
            this.btnNext.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // btnLast
            // 
            this.btnLast.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnLast.ImageIndex = 1;
            this.btnLast.ImageList = this.imageList1;
            this.btnLast.Location = new System.Drawing.Point(262, 5);
            this.btnLast.Name = "btnLast";
            this.btnLast.Size = new System.Drawing.Size(80, 25);
            this.btnLast.TabIndex = 7;
            this.btnLast.Text = "&Fin";
            this.btnLast.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLast.UseVisualStyleBackColor = true;
            this.btnLast.Click += new System.EventHandler(this.btnLast_Click);
            // 
            // btnQuit
            // 
            this.btnQuit.CausesValidation = false;
            this.btnQuit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnQuit.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnQuit.ImageIndex = 5;
            this.btnQuit.ImageList = this.imageList1;
            this.btnQuit.Location = new System.Drawing.Point(664, 5);
            this.btnQuit.Name = "btnQuit";
            this.btnQuit.Size = new System.Drawing.Size(80, 25);
            this.btnQuit.TabIndex = 9;
            this.btnQuit.Text = "&Quitter";
            this.btnQuit.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnQuit.UseVisualStyleBackColor = true;
            this.btnQuit.Click += new System.EventHandler(this.btnQuit_Click);
            // 
            // btnSave
            // 
            this.btnSave.CausesValidation = false;
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSave.ImageIndex = 4;
            this.btnSave.ImageList = this.imageList1;
            this.btnSave.Location = new System.Drawing.Point(578, 5);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(80, 25);
            this.btnSave.TabIndex = 8;
            this.btnSave.Text = "Enregi&strer";
            this.btnSave.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.btnModifLot);
            this.panel1.Controls.Add(this.btnModif);
            this.panel1.Controls.Add(this.btnQuit);
            this.panel1.Controls.Add(this.btnSave);
            this.panel1.Controls.Add(this.btnLast);
            this.panel1.Controls.Add(this.btnNext);
            this.panel1.Controls.Add(this.btnPrev);
            this.panel1.Controls.Add(this.btnFirst);
            this.panel1.Location = new System.Drawing.Point(12, 548);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(760, 39);
            this.panel1.TabIndex = 10;
            // 
            // btnModifLot
            // 
            this.btnModifLot.Location = new System.Drawing.Point(456, 5);
            this.btnModifLot.Name = "btnModifLot";
            this.btnModifLot.Size = new System.Drawing.Size(90, 25);
            this.btnModifLot.TabIndex = 11;
            this.btnModifLot.Text = "Modif. &Lot";
            this.btnModifLot.UseVisualStyleBackColor = true;
            this.btnModifLot.Click += new System.EventHandler(this.btnModifLot_Click);
            // 
            // btnModif
            // 
            this.btnModif.Location = new System.Drawing.Point(360, 5);
            this.btnModif.Name = "btnModif";
            this.btnModif.Size = new System.Drawing.Size(90, 25);
            this.btnModif.TabIndex = 10;
            this.btnModif.Text = "Modi&f. Repart";
            this.btnModif.UseVisualStyleBackColor = true;
            this.btnModif.Click += new System.EventHandler(this.btnModif_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(351, 189);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(102, 13);
            this.label2.TabIndex = 21;
            this.label2.Text = "Note Appel de Fond";
            // 
            // tbAppel
            // 
            this.tbAppel.AcceptsReturn = true;
            this.tbAppel.AcceptsTab = true;
            this.tbAppel.Location = new System.Drawing.Point(475, 226);
            this.tbAppel.Multiline = true;
            this.tbAppel.Name = "tbAppel";
            this.tbAppel.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tbAppel.Size = new System.Drawing.Size(283, 45);
            this.tbAppel.TabIndex = 22;
            // 
            // FicheImmeubleForm
            // 
            this.AcceptButton = this.btnEnter;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnQuit;
            this.ClientSize = new System.Drawing.Size(784, 599);
            this.ControlBox = false;
            this.Controls.Add(this.tbAppel);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FicheImmeubleForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Fiche Immeuble";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FicheImmeubleForm_FormClosing);
            this.Load += new System.EventHandler(this.FicheImmeubleForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GroupBox groupBox1;
        private Label label1;
        private TextBox tbNumero;
        private Label lblRef;
        private MaskedTextBox tbDateCreation;
        private Label label3;
        private Label label6;
        private MaskedTextBox tbCodePostal;
        private TextBox tbAdresse;
        private Label label5;
        private TextBox tbNom;
        private Label label4;
        private TextBox tbVille;
        private Label label7;
        private MaskedTextBox tbCompteBanque;
        private Label label8;
        private MaskedTextBox tbLots;
        private Label label9;
        private GroupBox groupBox2;
        private DataGridView dataGridView;
        private Button btnFirst;
        private ImageList imageList1;
        private Button btnPrev;
        private Button btnNext;
        private Button btnLast;
        private Button btnQuit;
        private Button btnSave;
        private Panel panel1;
        private TextBox tbNote;
        private Label label10;
        private Button btnModif;
        private Button btnModifLot;
        private TextBox tbNoteRepart;
        private Label label11;
        private Label lblTitre;
        private Label lblTxtImmeuble;
        private Button btnEnter;
        private Label lblExercice;
        private CheckBox ckDesactiv;
        private Label label2;
        private TextBox tbAppel;
    }
}