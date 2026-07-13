using System.ComponentModel;
using System.Windows.Forms;

namespace EspaceSyndic.Formulaires.Coproprietaire
{
    partial class FicheCoproprietaireForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FicheCoproprietaireForm));
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ckDesactiv = new System.Windows.Forms.CheckBox();
            this.tbPays = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.tbEmail = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.tbNote = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.ckCommerce = new System.Windows.Forms.CheckBox();
            this.ckDeclaration = new System.Windows.Forms.CheckBox();
            this.ckVente = new System.Windows.Forms.CheckBox();
            this.label9 = new System.Windows.Forms.Label();
            this.cbCivilite = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.tbTel = new System.Windows.Forms.MaskedTextBox();
            this.tbPrenom = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbVille = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.tbCodePostal = new System.Windows.Forms.MaskedTextBox();
            this.tbAdresse = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tbNom = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tbRef = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnQuit = new System.Windows.Forms.Button();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.btnSave = new System.Windows.Forms.Button();
            this.btnLast = new System.Windows.Forms.Button();
            this.btnNext = new System.Windows.Forms.Button();
            this.btnPrev = new System.Windows.Forms.Button();
            this.btnFirst = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label13 = new System.Windows.Forms.Label();
            this.tbTelCompte = new System.Windows.Forms.MaskedTextBox();
            this.tbVilleCompte = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.tbCodePostalCompte = new System.Windows.Forms.MaskedTextBox();
            this.tbAdresseCompte = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.cbCodeEnvoiCompte = new System.Windows.Forms.ComboBox();
            this.tbNomCompte = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnEnter = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(273, 11);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(476, 25);
            this.label1.TabIndex = 3;
            this.label1.Text = "Agence Bourgogne : Fichier des Coproprietaires";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.ckDesactiv);
            this.groupBox1.Controls.Add(this.tbPays);
            this.groupBox1.Controls.Add(this.label18);
            this.groupBox1.Controls.Add(this.tbEmail);
            this.groupBox1.Controls.Add(this.label17);
            this.groupBox1.Controls.Add(this.tbNote);
            this.groupBox1.Controls.Add(this.label16);
            this.groupBox1.Controls.Add(this.ckCommerce);
            this.groupBox1.Controls.Add(this.ckDeclaration);
            this.groupBox1.Controls.Add(this.ckVente);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.cbCivilite);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.tbTel);
            this.groupBox1.Controls.Add(this.tbPrenom);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.tbVille);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.tbCodePostal);
            this.groupBox1.Controls.Add(this.tbAdresse);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.tbNom);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.tbRef);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(16, 51);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(1013, 335);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Description Copropriétaire";
            // 
            // ckDesactiv
            // 
            this.ckDesactiv.AutoSize = true;
            this.ckDesactiv.Location = new System.Drawing.Point(17, 306);
            this.ckDesactiv.Margin = new System.Windows.Forms.Padding(4);
            this.ckDesactiv.Name = "ckDesactiv";
            this.ckDesactiv.Size = new System.Drawing.Size(92, 21);
            this.ckDesactiv.TabIndex = 24;
            this.ckDesactiv.Text = "Désactivé";
            this.ckDesactiv.UseVisualStyleBackColor = true;
            // 
            // tbPays
            // 
            this.tbPays.Location = new System.Drawing.Point(868, 154);
            this.tbPays.Margin = new System.Windows.Forms.Padding(4);
            this.tbPays.Name = "tbPays";
            this.tbPays.Size = new System.Drawing.Size(132, 22);
            this.tbPays.TabIndex = 16;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(767, 158);
            this.label18.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(39, 17);
            this.label18.TabIndex = 15;
            this.label18.Text = "Pays";
            // 
            // tbEmail
            // 
            this.tbEmail.Location = new System.Drawing.Point(617, 198);
            this.tbEmail.Margin = new System.Windows.Forms.Padding(4);
            this.tbEmail.Name = "tbEmail";
            this.tbEmail.Size = new System.Drawing.Size(383, 22);
            this.tbEmail.TabIndex = 20;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(516, 202);
            this.label17.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(42, 17);
            this.label17.TabIndex = 19;
            this.label17.Text = "Email";
            // 
            // tbNote
            // 
            this.tbNote.AcceptsReturn = true;
            this.tbNote.Location = new System.Drawing.Point(115, 194);
            this.tbNote.Margin = new System.Windows.Forms.Padding(4);
            this.tbNote.Multiline = true;
            this.tbNote.Name = "tbNote";
            this.tbNote.Size = new System.Drawing.Size(387, 90);
            this.tbNote.TabIndex = 18;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(13, 198);
            this.label16.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(53, 17);
            this.label16.TabIndex = 17;
            this.label16.Text = "Notes :";
            // 
            // ckCommerce
            // 
            this.ckCommerce.AutoSize = true;
            this.ckCommerce.Location = new System.Drawing.Point(896, 265);
            this.ckCommerce.Margin = new System.Windows.Forms.Padding(4);
            this.ckCommerce.Name = "ckCommerce";
            this.ckCommerce.Size = new System.Drawing.Size(97, 21);
            this.ckCommerce.TabIndex = 23;
            this.ckCommerce.Text = "Commerce";
            this.ckCommerce.UseVisualStyleBackColor = true;
            this.ckCommerce.Click += new System.EventHandler(this.tbTextChanged);
            // 
            // ckDeclaration
            // 
            this.ckDeclaration.AutoSize = true;
            this.ckDeclaration.Location = new System.Drawing.Point(747, 265);
            this.ckDeclaration.Margin = new System.Windows.Forms.Padding(4);
            this.ckDeclaration.Name = "ckDeclaration";
            this.ckDeclaration.Size = new System.Drawing.Size(102, 21);
            this.ckDeclaration.TabIndex = 22;
            this.ckDeclaration.Text = "Déclaration";
            this.ckDeclaration.UseVisualStyleBackColor = true;
            this.ckDeclaration.Click += new System.EventHandler(this.tbTextChanged);
            // 
            // ckVente
            // 
            this.ckVente.AutoSize = true;
            this.ckVente.Location = new System.Drawing.Point(525, 265);
            this.ckVente.Margin = new System.Windows.Forms.Padding(4);
            this.ckVente.Name = "ckVente";
            this.ckVente.Size = new System.Drawing.Size(171, 21);
            this.ckVente.TabIndex = 21;
            this.ckVente.Text = "Dossier remis Huissier";
            this.ckVente.UseVisualStyleBackColor = true;
            this.ckVente.Click += new System.EventHandler(this.tbTextChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(764, 94);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(48, 17);
            this.label9.TabIndex = 17;
            this.label9.Text = "Civilité";
            // 
            // cbCivilite
            // 
            this.cbCivilite.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCivilite.FormattingEnabled = true;
            this.cbCivilite.Location = new System.Drawing.Point(852, 90);
            this.cbCivilite.Margin = new System.Windows.Forms.Padding(4);
            this.cbCivilite.Name = "cbCivilite";
            this.cbCivilite.Size = new System.Drawing.Size(148, 24);
            this.cbCivilite.TabIndex = 16;
            this.cbCivilite.TextChanged += new System.EventHandler(this.tbTextChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(516, 158);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(76, 17);
            this.label8.TabIndex = 15;
            this.label8.Text = "Téléphone";
            // 
            // tbTel
            // 
            this.tbTel.Location = new System.Drawing.Point(617, 154);
            this.tbTel.Margin = new System.Windows.Forms.Padding(4);
            this.tbTel.Mask = "00 00 00 00 00";
            this.tbTel.Name = "tbTel";
            this.tbTel.Size = new System.Drawing.Size(132, 22);
            this.tbTel.TabIndex = 14;
            this.tbTel.TextChanged += new System.EventHandler(this.tbTextChanged);
            // 
            // tbPrenom
            // 
            this.tbPrenom.Location = new System.Drawing.Point(617, 59);
            this.tbPrenom.Margin = new System.Windows.Forms.Padding(4);
            this.tbPrenom.Name = "tbPrenom";
            this.tbPrenom.Size = new System.Drawing.Size(387, 22);
            this.tbPrenom.TabIndex = 5;
            this.tbPrenom.TextChanged += new System.EventHandler(this.tbTextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(516, 63);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 17);
            this.label3.TabIndex = 4;
            this.label3.Text = "Prénom:";
            // 
            // tbVille
            // 
            this.tbVille.Location = new System.Drawing.Point(617, 122);
            this.tbVille.Margin = new System.Windows.Forms.Padding(4);
            this.tbVille.Name = "tbVille";
            this.tbVille.Size = new System.Drawing.Size(387, 22);
            this.tbVille.TabIndex = 13;
            this.tbVille.TextChanged += new System.EventHandler(this.tbTextChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(516, 126);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(38, 17);
            this.label7.TabIndex = 12;
            this.label7.Text = "Ville:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(516, 94);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(88, 17);
            this.label6.TabIndex = 10;
            this.label6.Text = "Code Postal:";
            // 
            // tbCodePostal
            // 
            this.tbCodePostal.Location = new System.Drawing.Point(617, 90);
            this.tbCodePostal.Margin = new System.Windows.Forms.Padding(4);
            this.tbCodePostal.Mask = "00000";
            this.tbCodePostal.Name = "tbCodePostal";
            this.tbCodePostal.Size = new System.Drawing.Size(107, 22);
            this.tbCodePostal.TabIndex = 11;
            this.tbCodePostal.TextChanged += new System.EventHandler(this.tbTextChanged);
            // 
            // tbAdresse
            // 
            this.tbAdresse.AcceptsReturn = true;
            this.tbAdresse.Location = new System.Drawing.Point(115, 90);
            this.tbAdresse.Margin = new System.Windows.Forms.Padding(4);
            this.tbAdresse.Multiline = true;
            this.tbAdresse.Name = "tbAdresse";
            this.tbAdresse.Size = new System.Drawing.Size(387, 56);
            this.tbAdresse.TabIndex = 7;
            this.tbAdresse.TextChanged += new System.EventHandler(this.tbTextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(13, 94);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(68, 17);
            this.label5.TabIndex = 6;
            this.label5.Text = "Adresse :";
            // 
            // tbNom
            // 
            this.tbNom.Location = new System.Drawing.Point(115, 59);
            this.tbNom.Margin = new System.Windows.Forms.Padding(4);
            this.tbNom.Name = "tbNom";
            this.tbNom.Size = new System.Drawing.Size(387, 22);
            this.tbNom.TabIndex = 3;
            this.tbNom.TextChanged += new System.EventHandler(this.tbTextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 63);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 17);
            this.label4.TabIndex = 2;
            this.label4.Text = "Nom:";
            // 
            // tbRef
            // 
            this.tbRef.Location = new System.Drawing.Point(115, 27);
            this.tbRef.Margin = new System.Windows.Forms.Padding(4);
            this.tbRef.Name = "tbRef";
            this.tbRef.Size = new System.Drawing.Size(132, 22);
            this.tbRef.TabIndex = 1;
            this.tbRef.TextChanged += new System.EventHandler(this.tbTextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Blue;
            this.label2.Location = new System.Drawing.Point(13, 31);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 17);
            this.label2.TabIndex = 0;
            this.label2.Text = "Référence";
            this.label2.Click += new System.EventHandler(this.lblRef_Click);
            // 
            // btnQuit
            // 
            this.btnQuit.CausesValidation = false;
            this.btnQuit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnQuit.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnQuit.ImageIndex = 5;
            this.btnQuit.ImageList = this.imageList1;
            this.btnQuit.Location = new System.Drawing.Point(865, 6);
            this.btnQuit.Margin = new System.Windows.Forms.Padding(4);
            this.btnQuit.Name = "btnQuit";
            this.btnQuit.Size = new System.Drawing.Size(133, 31);
            this.btnQuit.TabIndex = 85;
            this.btnQuit.Text = "&Quitter";
            this.btnQuit.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnQuit.UseVisualStyleBackColor = true;
            this.btnQuit.Click += new System.EventHandler(this.btnQuit_Click);
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
            // btnSave
            // 
            this.btnSave.CausesValidation = false;
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSave.ImageIndex = 4;
            this.btnSave.ImageList = this.imageList1;
            this.btnSave.Location = new System.Drawing.Point(720, 6);
            this.btnSave.Margin = new System.Windows.Forms.Padding(4);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(133, 31);
            this.btnSave.TabIndex = 84;
            this.btnSave.Text = "Enregi&strer";
            this.btnSave.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnLast
            // 
            this.btnLast.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnLast.ImageIndex = 1;
            this.btnLast.ImageList = this.imageList1;
            this.btnLast.Location = new System.Drawing.Point(355, 6);
            this.btnLast.Margin = new System.Windows.Forms.Padding(4);
            this.btnLast.Name = "btnLast";
            this.btnLast.Size = new System.Drawing.Size(107, 31);
            this.btnLast.TabIndex = 83;
            this.btnLast.Text = "Fin";
            this.btnLast.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLast.UseVisualStyleBackColor = true;
            this.btnLast.Click += new System.EventHandler(this.btnLast_Click);
            // 
            // btnNext
            // 
            this.btnNext.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnNext.ImageIndex = 3;
            this.btnNext.ImageList = this.imageList1;
            this.btnNext.Location = new System.Drawing.Point(240, 6);
            this.btnNext.Margin = new System.Windows.Forms.Padding(4);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(107, 31);
            this.btnNext.TabIndex = 82;
            this.btnNext.Text = "Suivant";
            this.btnNext.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // btnPrev
            // 
            this.btnPrev.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPrev.ImageIndex = 2;
            this.btnPrev.ImageList = this.imageList1;
            this.btnPrev.Location = new System.Drawing.Point(125, 6);
            this.btnPrev.Margin = new System.Windows.Forms.Padding(4);
            this.btnPrev.Name = "btnPrev";
            this.btnPrev.Size = new System.Drawing.Size(107, 31);
            this.btnPrev.TabIndex = 81;
            this.btnPrev.Text = "Précédent";
            this.btnPrev.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnPrev.UseVisualStyleBackColor = true;
            this.btnPrev.Click += new System.EventHandler(this.btnPrev_Click);
            // 
            // btnFirst
            // 
            this.btnFirst.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnFirst.ImageIndex = 0;
            this.btnFirst.ImageList = this.imageList1;
            this.btnFirst.Location = new System.Drawing.Point(11, 6);
            this.btnFirst.Margin = new System.Windows.Forms.Padding(4);
            this.btnFirst.Name = "btnFirst";
            this.btnFirst.Size = new System.Drawing.Size(107, 31);
            this.btnFirst.TabIndex = 80;
            this.btnFirst.Text = "Début";
            this.btnFirst.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnFirst.UseVisualStyleBackColor = true;
            this.btnFirst.Click += new System.EventHandler(this.btnFirst_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Controls.Add(this.tbTelCompte);
            this.groupBox2.Controls.Add(this.tbVilleCompte);
            this.groupBox2.Controls.Add(this.label14);
            this.groupBox2.Controls.Add(this.label15);
            this.groupBox2.Controls.Add(this.tbCodePostalCompte);
            this.groupBox2.Controls.Add(this.tbAdresseCompte);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.cbCodeEnvoiCompte);
            this.groupBox2.Controls.Add(this.tbNomCompte);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Location = new System.Drawing.Point(16, 395);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox2.Size = new System.Drawing.Size(1013, 164);
            this.groupBox2.TabIndex = 16;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Description Gérant";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(516, 123);
            this.label13.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(76, 17);
            this.label13.TabIndex = 27;
            this.label13.Text = "Téléphone";
            // 
            // tbTelCompte
            // 
            this.tbTelCompte.Location = new System.Drawing.Point(617, 119);
            this.tbTelCompte.Margin = new System.Windows.Forms.Padding(4);
            this.tbTelCompte.Mask = "00 00 00 00 00";
            this.tbTelCompte.Name = "tbTelCompte";
            this.tbTelCompte.Size = new System.Drawing.Size(132, 22);
            this.tbTelCompte.TabIndex = 26;
            this.tbTelCompte.TextChanged += new System.EventHandler(this.tbTextChanged);
            // 
            // tbVilleCompte
            // 
            this.tbVilleCompte.Location = new System.Drawing.Point(617, 87);
            this.tbVilleCompte.Margin = new System.Windows.Forms.Padding(4);
            this.tbVilleCompte.Name = "tbVilleCompte";
            this.tbVilleCompte.Size = new System.Drawing.Size(387, 22);
            this.tbVilleCompte.TabIndex = 25;
            this.tbVilleCompte.TextChanged += new System.EventHandler(this.tbTextChanged);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(516, 91);
            this.label14.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(38, 17);
            this.label14.TabIndex = 24;
            this.label14.Text = "Ville:";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(516, 59);
            this.label15.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(88, 17);
            this.label15.TabIndex = 22;
            this.label15.Text = "Code Postal:";
            // 
            // tbCodePostalCompte
            // 
            this.tbCodePostalCompte.Location = new System.Drawing.Point(617, 55);
            this.tbCodePostalCompte.Margin = new System.Windows.Forms.Padding(4);
            this.tbCodePostalCompte.Mask = "00000";
            this.tbCodePostalCompte.Name = "tbCodePostalCompte";
            this.tbCodePostalCompte.Size = new System.Drawing.Size(107, 22);
            this.tbCodePostalCompte.TabIndex = 23;
            this.tbCodePostalCompte.TextChanged += new System.EventHandler(this.tbTextChanged);
            // 
            // tbAdresseCompte
            // 
            this.tbAdresseCompte.AcceptsReturn = true;
            this.tbAdresseCompte.Location = new System.Drawing.Point(115, 55);
            this.tbAdresseCompte.Margin = new System.Windows.Forms.Padding(4);
            this.tbAdresseCompte.MaxLength = 255;
            this.tbAdresseCompte.Multiline = true;
            this.tbAdresseCompte.Name = "tbAdresseCompte";
            this.tbAdresseCompte.Size = new System.Drawing.Size(387, 56);
            this.tbAdresseCompte.TabIndex = 21;
            this.tbAdresseCompte.TextChanged += new System.EventHandler(this.tbTextChanged);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(13, 59);
            this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(68, 17);
            this.label12.TabIndex = 20;
            this.label12.Text = "Adresse :";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(760, 26);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(48, 17);
            this.label11.TabIndex = 19;
            this.label11.Text = "Civilité";
            // 
            // cbCodeEnvoiCompte
            // 
            this.cbCodeEnvoiCompte.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCodeEnvoiCompte.FormattingEnabled = true;
            this.cbCodeEnvoiCompte.Location = new System.Drawing.Point(848, 22);
            this.cbCodeEnvoiCompte.Margin = new System.Windows.Forms.Padding(4);
            this.cbCodeEnvoiCompte.Name = "cbCodeEnvoiCompte";
            this.cbCodeEnvoiCompte.Size = new System.Drawing.Size(148, 24);
            this.cbCodeEnvoiCompte.TabIndex = 18;
            this.cbCodeEnvoiCompte.TextChanged += new System.EventHandler(this.tbTextChanged);
            // 
            // tbNomCompte
            // 
            this.tbNomCompte.Location = new System.Drawing.Point(115, 23);
            this.tbNomCompte.Margin = new System.Windows.Forms.Padding(4);
            this.tbNomCompte.Name = "tbNomCompte";
            this.tbNomCompte.Size = new System.Drawing.Size(387, 22);
            this.tbNomCompte.TabIndex = 5;
            this.tbNomCompte.TextChanged += new System.EventHandler(this.tbTextChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(13, 27);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(41, 17);
            this.label10.TabIndex = 4;
            this.label10.Text = "Nom:";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.btnEnter);
            this.panel1.Controls.Add(this.btnQuit);
            this.panel1.Controls.Add(this.btnSave);
            this.panel1.Controls.Add(this.btnLast);
            this.panel1.Controls.Add(this.btnNext);
            this.panel1.Controls.Add(this.btnPrev);
            this.panel1.Controls.Add(this.btnFirst);
            this.panel1.Location = new System.Drawing.Point(16, 569);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1012, 47);
            this.panel1.TabIndex = 86;
            // 
            // btnEnter
            // 
            this.btnEnter.Location = new System.Drawing.Point(532, 9);
            this.btnEnter.Margin = new System.Windows.Forms.Padding(4);
            this.btnEnter.Name = "btnEnter";
            this.btnEnter.Size = new System.Drawing.Size(100, 28);
            this.btnEnter.TabIndex = 118;
            this.btnEnter.Text = "button1";
            this.btnEnter.UseVisualStyleBackColor = true;
            this.btnEnter.Click += new System.EventHandler(this.btnEnter_Click);
            // 
            // FicheCoproprietaireForm
            // 
            this.AcceptButton = this.btnEnter;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnQuit;
            this.ClientSize = new System.Drawing.Size(1045, 680);
            this.ControlBox = false;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FicheCoproprietaireForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Fiche Coproprietaire";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FicheCoproprietaireForm_FormClosing);
            this.Load += new System.EventHandler(this.FicheCoproprietaireForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label label1;
        private GroupBox groupBox1;
        private TextBox tbPrenom;
        private Label label3;
        private TextBox tbVille;
        private Label label7;
        private Label label6;
        private MaskedTextBox tbCodePostal;
        private TextBox tbAdresse;
        private Label label5;
        private TextBox tbNom;
        private Label label4;
        private TextBox tbRef;
        private Label label2;
        private Button btnQuit;
        private Button btnSave;
        private Button btnLast;
        private Button btnNext;
        private Button btnPrev;
        private Button btnFirst;
        private ImageList imageList1;
        private Label label8;
        private MaskedTextBox tbTel;
        private Label label9;
        private ComboBox cbCivilite;
        private CheckBox ckCommerce;
        private CheckBox ckDeclaration;
        private CheckBox ckVente;
        private GroupBox groupBox2;
        private TextBox tbNomCompte;
        private Label label10;
        private Label label13;
        private MaskedTextBox tbTelCompte;
        private TextBox tbVilleCompte;
        private Label label14;
        private Label label15;
        private MaskedTextBox tbCodePostalCompte;
        private TextBox tbAdresseCompte;
        private Label label12;
        private Label label11;
        private ComboBox cbCodeEnvoiCompte;
        private Panel panel1;
        private TextBox tbEmail;
        private Label label17;
        private TextBox tbNote;
        private Label label16;
        private TextBox tbPays;
        private Label label18;
        private Button btnEnter;
        private CheckBox ckDesactiv;
    }
}