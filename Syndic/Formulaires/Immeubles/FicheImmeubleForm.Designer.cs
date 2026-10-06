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
            components = new Container();
            ComponentResourceManager resources = new ComponentResourceManager(typeof(FicheImmeubleForm));
            groupBox1 = new GroupBox();
            label2 = new Label();
            ckDesactiv = new CheckBox();
            tbNoteRepart = new TextBox();
            label11 = new Label();
            tbNote = new TextBox();
            label10 = new Label();
            tbLots = new MaskedTextBox();
            label9 = new Label();
            tbCompteBanque = new MaskedTextBox();
            label8 = new Label();
            tbVille = new TextBox();
            label7 = new Label();
            label6 = new Label();
            tbCodePostal = new MaskedTextBox();
            tbAdresse = new TextBox();
            label5 = new Label();
            tbNom = new TextBox();
            label4 = new Label();
            label3 = new Label();
            tbDateCreation = new MaskedTextBox();
            tbNumero = new TextBox();
            lblRef = new Label();
            label1 = new Label();
            groupBox2 = new GroupBox();
            lblExercice = new Label();
            btnEnter = new Button();
            lblTxtImmeuble = new Label();
            lblTitre = new Label();
            dataGridView = new DataGridView();
            btnFirst = new Button();
            imageList1 = new ImageList(components);
            btnPrev = new Button();
            btnNext = new Button();
            btnLast = new Button();
            btnQuit = new Button();
            btnSave = new Button();
            panel1 = new Panel();
            btnModifLot = new Button();
            btnModif = new Button();
            tbAppel = new TextBox();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            ((ISupportInitialize)dataGridView).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(ckDesactiv);
            groupBox1.Controls.Add(tbNoteRepart);
            groupBox1.Controls.Add(label11);
            groupBox1.Controls.Add(tbNote);
            groupBox1.Controls.Add(label10);
            groupBox1.Controls.Add(tbLots);
            groupBox1.Controls.Add(label9);
            groupBox1.Controls.Add(tbCompteBanque);
            groupBox1.Controls.Add(label8);
            groupBox1.Controls.Add(tbVille);
            groupBox1.Controls.Add(label7);
            groupBox1.Controls.Add(label6);
            groupBox1.Controls.Add(tbCodePostal);
            groupBox1.Controls.Add(tbAdresse);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(tbNom);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(tbDateCreation);
            groupBox1.Controls.Add(tbNumero);
            groupBox1.Controls.Add(lblRef);
            groupBox1.Location = new System.Drawing.Point(14, 48);
            groupBox1.Margin = new Padding(4, 3, 4, 3);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(4, 3, 4, 3);
            groupBox1.Size = new System.Drawing.Size(887, 271);
            groupBox1.TabIndex = 1;
            groupBox1.TabStop = false;
            groupBox1.Text = "Description Immeuble";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(410, 218);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(113, 15);
            label2.TabIndex = 21;
            label2.Text = "Note Appel de Fond";
            // 
            // ckDesactiv
            // 
            ckDesactiv.AutoSize = true;
            ckDesactiv.Location = new System.Drawing.Point(16, 217);
            ckDesactiv.Margin = new Padding(4, 3, 4, 3);
            ckDesactiv.Name = "ckDesactiv";
            ckDesactiv.Size = new System.Drawing.Size(76, 19);
            ckDesactiv.TabIndex = 20;
            ckDesactiv.Text = "Désactivé";
            ckDesactiv.UseVisualStyleBackColor = true;
            // 
            // tbNoteRepart
            // 
            tbNoteRepart.AcceptsReturn = true;
            tbNoteRepart.AcceptsTab = true;
            tbNoteRepart.Location = new System.Drawing.Point(540, 118);
            tbNoteRepart.Margin = new Padding(4, 3, 4, 3);
            tbNoteRepart.Multiline = true;
            tbNoteRepart.Name = "tbNoteRepart";
            tbNoteRepart.ScrollBars = ScrollBars.Both;
            tbNoteRepart.Size = new System.Drawing.Size(330, 87);
            tbNoteRepart.TabIndex = 19;
            // 
            // label11
            // 
            label11.Location = new System.Drawing.Point(454, 118);
            label11.Margin = new Padding(4, 0, 4, 0);
            label11.Name = "label11";
            label11.Size = new System.Drawing.Size(84, 58);
            label11.TabIndex = 18;
            label11.Text = "Note &Répartition:";
            // 
            // tbNote
            // 
            tbNote.AcceptsReturn = true;
            tbNote.AcceptsTab = true;
            tbNote.Location = new System.Drawing.Point(100, 118);
            tbNote.Margin = new Padding(4, 3, 4, 3);
            tbNote.Multiline = true;
            tbNote.Name = "tbNote";
            tbNote.ScrollBars = ScrollBars.Both;
            tbNote.Size = new System.Drawing.Size(346, 87);
            tbNote.TabIndex = 17;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new System.Drawing.Point(12, 121);
            label10.Margin = new Padding(4, 0, 4, 0);
            label10.Name = "label10";
            label10.Size = new System.Drawing.Size(36, 15);
            label10.TabIndex = 16;
            label10.Text = "&Note:";
            // 
            // tbLots
            // 
            tbLots.Location = new System.Drawing.Point(540, 84);
            tbLots.Margin = new Padding(4, 3, 4, 3);
            tbLots.Name = "tbLots";
            tbLots.Size = new System.Drawing.Size(94, 23);
            tbLots.TabIndex = 15;
            tbLots.TextChanged += tbTextChanged;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new System.Drawing.Point(454, 88);
            label9.Margin = new Padding(4, 0, 4, 0);
            label9.Name = "label9";
            label9.Size = new System.Drawing.Size(64, 15);
            label9.TabIndex = 14;
            label9.Text = "Nb de &lots:";
            // 
            // tbCompteBanque
            // 
            tbCompteBanque.Location = new System.Drawing.Point(100, 84);
            tbCompteBanque.Margin = new Padding(4, 3, 4, 3);
            tbCompteBanque.Mask = "99999999999";
            tbCompteBanque.Name = "tbCompteBanque";
            tbCompteBanque.PromptChar = ' ';
            tbCompteBanque.Size = new System.Drawing.Size(94, 23);
            tbCompteBanque.TabIndex = 13;
            tbCompteBanque.TextChanged += tbTextChanged;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new System.Drawing.Point(13, 88);
            label8.Margin = new Padding(4, 0, 4, 0);
            label8.Name = "label8";
            label8.Size = new System.Drawing.Size(85, 15);
            label8.TabIndex = 12;
            label8.Text = "Cpt &Banquaire:";
            // 
            // tbVille
            // 
            tbVille.Location = new System.Drawing.Point(695, 55);
            tbVille.Margin = new Padding(4, 3, 4, 3);
            tbVille.Name = "tbVille";
            tbVille.Size = new System.Drawing.Size(174, 23);
            tbVille.TabIndex = 11;
            tbVille.TextChanged += tbTextChanged;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new System.Drawing.Point(651, 59);
            label7.Margin = new Padding(4, 0, 4, 0);
            label7.Name = "label7";
            label7.Size = new System.Drawing.Size(32, 15);
            label7.TabIndex = 10;
            label7.Text = "&Ville:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new System.Drawing.Point(454, 59);
            label6.Margin = new Padding(4, 0, 4, 0);
            label6.Name = "label6";
            label6.Size = new System.Drawing.Size(73, 15);
            label6.TabIndex = 9;
            label6.Text = "&Code Postal:";
            // 
            // tbCodePostal
            // 
            tbCodePostal.Location = new System.Drawing.Point(540, 57);
            tbCodePostal.Margin = new Padding(4, 3, 4, 3);
            tbCodePostal.Name = "tbCodePostal";
            tbCodePostal.Size = new System.Drawing.Size(94, 23);
            tbCodePostal.TabIndex = 8;
            tbCodePostal.TextChanged += tbTextChanged;
            // 
            // tbAdresse
            // 
            tbAdresse.Location = new System.Drawing.Point(100, 55);
            tbAdresse.Margin = new Padding(4, 3, 4, 3);
            tbAdresse.Name = "tbAdresse";
            tbAdresse.Size = new System.Drawing.Size(346, 23);
            tbAdresse.TabIndex = 7;
            tbAdresse.TextChanged += tbTextChanged;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new System.Drawing.Point(12, 60);
            label5.Margin = new Padding(4, 0, 4, 0);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(51, 15);
            label5.TabIndex = 6;
            label5.Text = "&Adresse:";
            // 
            // tbNom
            // 
            tbNom.Location = new System.Drawing.Point(540, 25);
            tbNom.Margin = new Padding(4, 3, 4, 3);
            tbNom.Name = "tbNom";
            tbNom.Size = new System.Drawing.Size(330, 23);
            tbNom.TabIndex = 5;
            tbNom.TextChanged += tbTextChanged;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new System.Drawing.Point(454, 29);
            label4.Margin = new Padding(4, 0, 4, 0);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(37, 15);
            label4.TabIndex = 4;
            label4.Text = "&Nom:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(251, 29);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(82, 15);
            label3.TabIndex = 3;
            label3.Text = "&Date Création:";
            // 
            // tbDateCreation
            // 
            tbDateCreation.Location = new System.Drawing.Point(352, 25);
            tbDateCreation.Margin = new Padding(4, 3, 4, 3);
            tbDateCreation.Mask = "00/00/0000";
            tbDateCreation.Name = "tbDateCreation";
            tbDateCreation.Size = new System.Drawing.Size(94, 23);
            tbDateCreation.TabIndex = 2;
            tbDateCreation.ValidatingType = typeof(System.DateTime);
            tbDateCreation.TextChanged += tbTextChanged;
            // 
            // tbNumero
            // 
            tbNumero.Location = new System.Drawing.Point(100, 25);
            tbNumero.Margin = new Padding(4, 3, 4, 3);
            tbNumero.Name = "tbNumero";
            tbNumero.Size = new System.Drawing.Size(116, 23);
            tbNumero.TabIndex = 1;
            tbNumero.TextChanged += tbTextChanged;
            // 
            // lblRef
            // 
            lblRef.AutoSize = true;
            lblRef.ForeColor = System.Drawing.Color.Blue;
            lblRef.Location = new System.Drawing.Point(12, 29);
            lblRef.Margin = new Padding(4, 0, 4, 0);
            lblRef.Name = "lblRef";
            lblRef.Size = new System.Drawing.Size(62, 15);
            lblRef.TabIndex = 0;
            lblRef.Text = "&Référence:";
            lblRef.Click += lblRef_Click;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            label1.AutoSize = true;
            label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            label1.Location = new System.Drawing.Point(268, 10);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(358, 20);
            label1.TabIndex = 2;
            label1.Text = "Agence Bourgogne : Fichier des Immeubles";
            label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // groupBox2
            // 
            groupBox2.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            groupBox2.Controls.Add(lblExercice);
            groupBox2.Controls.Add(btnEnter);
            groupBox2.Controls.Add(lblTxtImmeuble);
            groupBox2.Controls.Add(lblTitre);
            groupBox2.Controls.Add(dataGridView);
            groupBox2.Location = new System.Drawing.Point(14, 327);
            groupBox2.Margin = new Padding(4, 3, 4, 3);
            groupBox2.Name = "groupBox2";
            groupBox2.Padding = new Padding(4, 3, 4, 3);
            groupBox2.Size = new System.Drawing.Size(887, 299);
            groupBox2.TabIndex = 3;
            groupBox2.TabStop = false;
            groupBox2.Text = "Charges";
            // 
            // lblExercice
            // 
            lblExercice.AutoSize = true;
            lblExercice.ForeColor = System.Drawing.Color.Blue;
            lblExercice.Location = new System.Drawing.Point(419, 18);
            lblExercice.Margin = new Padding(4, 0, 4, 0);
            lblExercice.Name = "lblExercice";
            lblExercice.Size = new System.Drawing.Size(95, 15);
            lblExercice.TabIndex = 117;
            lblExercice.Text = "Exercice Courant";
            lblExercice.Click += lblExercice_Click;
            // 
            // btnEnter
            // 
            btnEnter.Location = new System.Drawing.Point(400, 136);
            btnEnter.Margin = new Padding(4, 3, 4, 3);
            btnEnter.Name = "btnEnter";
            btnEnter.Size = new System.Drawing.Size(88, 27);
            btnEnter.TabIndex = 116;
            btnEnter.Text = "button1";
            btnEnter.UseVisualStyleBackColor = true;
            btnEnter.Click += btnEnter_Click;
            // 
            // lblTxtImmeuble
            // 
            lblTxtImmeuble.AutoSize = true;
            lblTxtImmeuble.ForeColor = System.Drawing.Color.Blue;
            lblTxtImmeuble.Location = new System.Drawing.Point(13, 18);
            lblTxtImmeuble.Margin = new Padding(4, 0, 4, 0);
            lblTxtImmeuble.Name = "lblTxtImmeuble";
            lblTxtImmeuble.Size = new System.Drawing.Size(96, 15);
            lblTxtImmeuble.TabIndex = 2;
            lblTxtImmeuble.Text = "Textes Immeuble";
            lblTxtImmeuble.Click += lblTextesImmeuble_Click;
            lblTxtImmeuble.Enter += lblTitre_Click;
            // 
            // lblTitre
            // 
            lblTitre.AutoSize = true;
            lblTitre.ForeColor = System.Drawing.Color.Blue;
            lblTitre.Location = new System.Drawing.Point(750, 18);
            lblTitre.Margin = new Padding(4, 0, 4, 0);
            lblTitre.Name = "lblTitre";
            lblTitre.Size = new System.Drawing.Size(115, 15);
            lblTitre.TabIndex = 1;
            lblTitre.Text = "Mise à jour des &titres";
            lblTitre.Click += lblTitre_Click;
            // 
            // dataGridView
            // 
            dataGridView.AllowUserToAddRows = false;
            dataGridView.AllowUserToDeleteRows = false;
            dataGridView.AllowUserToResizeRows = false;
            dataGridView.BackgroundColor = System.Drawing.Color.FromArgb(224, 224, 224);
            dataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView.Location = new System.Drawing.Point(16, 50);
            dataGridView.Margin = new Padding(4, 3, 4, 3);
            dataGridView.Name = "dataGridView";
            dataGridView.RowHeadersVisible = false;
            dataGridView.ShowCellErrors = false;
            dataGridView.ShowEditingIcon = false;
            dataGridView.ShowRowErrors = false;
            dataGridView.Size = new System.Drawing.Size(854, 231);
            dataGridView.TabIndex = 0;
            dataGridView.CellValueChanged += dataGridView_CellValueChanged;
            // 
            // btnFirst
            // 
            btnFirst.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            btnFirst.ImageIndex = 0;
            btnFirst.ImageList = imageList1;
            btnFirst.Location = new System.Drawing.Point(5, 6);
            btnFirst.Margin = new Padding(4, 3, 4, 3);
            btnFirst.Name = "btnFirst";
            btnFirst.Size = new System.Drawing.Size(93, 29);
            btnFirst.TabIndex = 4;
            btnFirst.Text = "&Début";
            btnFirst.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            btnFirst.UseVisualStyleBackColor = true;
            btnFirst.Click += btnFirst_Click;
            // 
            // imageList1
            // 
            imageList1.ColorDepth = ColorDepth.Depth8Bit;
            imageList1.ImageStream = (ImageListStreamer)resources.GetObject("imageList1.ImageStream");
            imageList1.TransparentColor = System.Drawing.Color.Silver;
            imageList1.Images.SetKeyName(0, "top.png");
            imageList1.Images.SetKeyName(1, "bottom.png");
            imageList1.Images.SetKeyName(2, "previous.png");
            imageList1.Images.SetKeyName(3, "next.png");
            imageList1.Images.SetKeyName(4, "save.png");
            imageList1.Images.SetKeyName(5, "quit.png");
            // 
            // btnPrev
            // 
            btnPrev.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            btnPrev.ImageIndex = 2;
            btnPrev.ImageList = imageList1;
            btnPrev.Location = new System.Drawing.Point(105, 6);
            btnPrev.Margin = new Padding(4, 3, 4, 3);
            btnPrev.Name = "btnPrev";
            btnPrev.Size = new System.Drawing.Size(93, 29);
            btnPrev.TabIndex = 5;
            btnPrev.Text = "&Précédent";
            btnPrev.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            btnPrev.UseVisualStyleBackColor = true;
            btnPrev.Click += btnPrev_Click;
            // 
            // btnNext
            // 
            btnNext.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            btnNext.ImageIndex = 3;
            btnNext.ImageList = imageList1;
            btnNext.Location = new System.Drawing.Point(205, 6);
            btnNext.Margin = new Padding(4, 3, 4, 3);
            btnNext.Name = "btnNext";
            btnNext.Size = new System.Drawing.Size(93, 29);
            btnNext.TabIndex = 6;
            btnNext.Text = "&Suivant";
            btnNext.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            btnNext.UseVisualStyleBackColor = true;
            btnNext.Click += btnNext_Click;
            // 
            // btnLast
            // 
            btnLast.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            btnLast.ImageIndex = 1;
            btnLast.ImageList = imageList1;
            btnLast.Location = new System.Drawing.Point(306, 6);
            btnLast.Margin = new Padding(4, 3, 4, 3);
            btnLast.Name = "btnLast";
            btnLast.Size = new System.Drawing.Size(93, 29);
            btnLast.TabIndex = 7;
            btnLast.Text = "&Fin";
            btnLast.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            btnLast.UseVisualStyleBackColor = true;
            btnLast.Click += btnLast_Click;
            // 
            // btnQuit
            // 
            btnQuit.CausesValidation = false;
            btnQuit.DialogResult = DialogResult.Cancel;
            btnQuit.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            btnQuit.ImageIndex = 5;
            btnQuit.ImageList = imageList1;
            btnQuit.Location = new System.Drawing.Point(775, 6);
            btnQuit.Margin = new Padding(4, 3, 4, 3);
            btnQuit.Name = "btnQuit";
            btnQuit.Size = new System.Drawing.Size(93, 29);
            btnQuit.TabIndex = 9;
            btnQuit.Text = "&Quitter";
            btnQuit.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            btnQuit.UseVisualStyleBackColor = true;
            btnQuit.Click += btnQuit_Click;
            // 
            // btnSave
            // 
            btnSave.CausesValidation = false;
            btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            btnSave.ImageIndex = 4;
            btnSave.ImageList = imageList1;
            btnSave.Location = new System.Drawing.Point(674, 6);
            btnSave.Margin = new Padding(4, 3, 4, 3);
            btnSave.Name = "btnSave";
            btnSave.Size = new System.Drawing.Size(93, 29);
            btnSave.TabIndex = 8;
            btnSave.Text = "Enregi&strer";
            btnSave.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel1.BorderStyle = BorderStyle.Fixed3D;
            panel1.Controls.Add(btnModifLot);
            panel1.Controls.Add(btnModif);
            panel1.Controls.Add(btnQuit);
            panel1.Controls.Add(btnSave);
            panel1.Controls.Add(btnLast);
            panel1.Controls.Add(btnNext);
            panel1.Controls.Add(btnPrev);
            panel1.Controls.Add(btnFirst);
            panel1.Location = new System.Drawing.Point(14, 632);
            panel1.Margin = new Padding(4, 3, 4, 3);
            panel1.Name = "panel1";
            panel1.Size = new System.Drawing.Size(886, 44);
            panel1.TabIndex = 10;
            // 
            // btnModifLot
            // 
            btnModifLot.Location = new System.Drawing.Point(532, 6);
            btnModifLot.Margin = new Padding(4, 3, 4, 3);
            btnModifLot.Name = "btnModifLot";
            btnModifLot.Size = new System.Drawing.Size(105, 29);
            btnModifLot.TabIndex = 11;
            btnModifLot.Text = "Modif. &Lot";
            btnModifLot.UseVisualStyleBackColor = true;
            btnModifLot.Click += btnModifLot_Click;
            // 
            // btnModif
            // 
            btnModif.Location = new System.Drawing.Point(420, 6);
            btnModif.Margin = new Padding(4, 3, 4, 3);
            btnModif.Name = "btnModif";
            btnModif.Size = new System.Drawing.Size(105, 29);
            btnModif.TabIndex = 10;
            btnModif.Text = "Modi&f. Repart";
            btnModif.UseVisualStyleBackColor = true;
            btnModif.Click += btnModif_Click;
            // 
            // tbAppel
            // 
            tbAppel.AcceptsReturn = true;
            tbAppel.AcceptsTab = true;
            tbAppel.Location = new System.Drawing.Point(554, 261);
            tbAppel.Margin = new Padding(4, 3, 4, 3);
            tbAppel.Multiline = true;
            tbAppel.Name = "tbAppel";
            tbAppel.ScrollBars = ScrollBars.Both;
            tbAppel.Size = new System.Drawing.Size(330, 51);
            tbAppel.TabIndex = 22;
            // 
            // FicheImmeubleForm
            // 
            AcceptButton = btnEnter;
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            CancelButton = btnQuit;
            ClientSize = new System.Drawing.Size(915, 691);
            ControlBox = false;
            Controls.Add(tbAppel);
            Controls.Add(groupBox2);
            Controls.Add(panel1);
            Controls.Add(label1);
            Controls.Add(groupBox1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Margin = new Padding(4, 3, 4, 3);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FicheImmeubleForm";
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Fiche Immeuble";
            FormClosing += FicheImmeubleForm_FormClosing;
            Load += FicheImmeubleForm_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ((ISupportInitialize)dataGridView).EndInit();
            panel1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();

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