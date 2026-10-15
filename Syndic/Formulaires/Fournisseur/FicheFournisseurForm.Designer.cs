using System.ComponentModel;
using System.Windows.Forms;

namespace EspaceSyndic.Formulaires.Fournisseur
{
    partial class FicheFournisseurForm
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
            ComponentResourceManager resources = new ComponentResourceManager(typeof(FicheFournisseurForm));
            label1 = new Label();
            groupBox1 = new GroupBox();
            ckDesactiv = new CheckBox();
            cbReglement = new ComboBox();
            tbUrsaff = new TextBox();
            label14 = new Label();
            tbApe = new TextBox();
            label13 = new Label();
            tbSecu = new TextBox();
            label12 = new Label();
            tbSiret = new TextBox();
            label11 = new Label();
            label10 = new Label();
            tbComment = new TextBox();
            label9 = new Label();
            label8 = new Label();
            tbTel = new MaskedTextBox();
            tbVille = new TextBox();
            label7 = new Label();
            label6 = new Label();
            tbCodePostal = new MaskedTextBox();
            tbAdresse = new TextBox();
            label5 = new Label();
            tbInterlocuteur = new TextBox();
            label3 = new Label();
            tbNom = new TextBox();
            label4 = new Label();
            tbRef = new TextBox();
            lblRef = new Label();
            panel1 = new Panel();
            btnQuit = new Button();
            imageList1 = new ImageList(components);
            btnSave = new Button();
            btnLast = new Button();
            btnNext = new Button();
            btnPrev = new Button();
            btnFirst = new Button();
            groupBox1.SuspendLayout();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            label1.AutoSize = true;
            label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            label1.Location = new System.Drawing.Point(239, 10);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(282, 20);
            label1.TabIndex = 4;
            label1.Text = "Agence Bourgogne : Fournisseurs";
            label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(ckDesactiv);
            groupBox1.Controls.Add(cbReglement);
            groupBox1.Controls.Add(tbUrsaff);
            groupBox1.Controls.Add(label14);
            groupBox1.Controls.Add(tbApe);
            groupBox1.Controls.Add(label13);
            groupBox1.Controls.Add(tbSecu);
            groupBox1.Controls.Add(label12);
            groupBox1.Controls.Add(tbSiret);
            groupBox1.Controls.Add(label11);
            groupBox1.Controls.Add(label10);
            groupBox1.Controls.Add(tbComment);
            groupBox1.Controls.Add(label9);
            groupBox1.Controls.Add(label8);
            groupBox1.Controls.Add(tbTel);
            groupBox1.Controls.Add(tbVille);
            groupBox1.Controls.Add(label7);
            groupBox1.Controls.Add(label6);
            groupBox1.Controls.Add(tbCodePostal);
            groupBox1.Controls.Add(tbAdresse);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(tbInterlocuteur);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(tbNom);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(tbRef);
            groupBox1.Controls.Add(lblRef);
            groupBox1.Location = new System.Drawing.Point(14, 37);
            groupBox1.Margin = new Padding(4, 3, 4, 3);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(4, 3, 4, 3);
            groupBox1.Size = new System.Drawing.Size(887, 336);
            groupBox1.TabIndex = 5;
            groupBox1.TabStop = false;
            groupBox1.Text = "Description Fournisseur";
            // 
            // ckDesactiv
            // 
            ckDesactiv.AutoSize = true;
            ckDesactiv.Location = new System.Drawing.Point(13, 309);
            ckDesactiv.Margin = new Padding(4, 3, 4, 3);
            ckDesactiv.Name = "ckDesactiv";
            ckDesactiv.Size = new System.Drawing.Size(76, 19);
            ckDesactiv.TabIndex = 38;
            ckDesactiv.Text = "Désactivé";
            ckDesactiv.UseVisualStyleBackColor = true;
            // 
            // cbReglement
            // 
            cbReglement.DropDownStyle = ComboBoxStyle.DropDownList;
            cbReglement.FormattingEnabled = true;
            cbReglement.Location = new System.Drawing.Point(98, 141);
            cbReglement.Margin = new Padding(4, 3, 4, 3);
            cbReglement.Name = "cbReglement";
            cbReglement.Size = new System.Drawing.Size(107, 23);
            cbReglement.TabIndex = 37;
            // 
            // tbUrsaff
            // 
            tbUrsaff.Location = new System.Drawing.Point(761, 278);
            tbUrsaff.Margin = new Padding(4, 3, 4, 3);
            tbUrsaff.Name = "tbUrsaff";
            tbUrsaff.Size = new System.Drawing.Size(116, 23);
            tbUrsaff.TabIndex = 35;
            tbUrsaff.TextChanged += tbTextChanged;
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Location = new System.Drawing.Point(672, 282);
            label14.Margin = new Padding(4, 0, 4, 0);
            label14.Name = "label14";
            label14.Size = new System.Drawing.Size(64, 15);
            label14.TabIndex = 34;
            label14.Text = "Num &Ursaf";
            // 
            // tbApe
            // 
            tbApe.Location = new System.Drawing.Point(538, 278);
            tbApe.Margin = new Padding(4, 3, 4, 3);
            tbApe.Name = "tbApe";
            tbApe.Size = new System.Drawing.Size(116, 23);
            tbApe.TabIndex = 33;
            tbApe.TextChanged += tbTextChanged;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Location = new System.Drawing.Point(449, 282);
            label13.Margin = new Padding(4, 0, 4, 0);
            label13.Name = "label13";
            label13.Size = new System.Drawing.Size(59, 15);
            label13.TabIndex = 32;
            label13.Text = "&Code APE";
            // 
            // tbSecu
            // 
            tbSecu.Location = new System.Drawing.Point(321, 278);
            tbSecu.Margin = new Padding(4, 3, 4, 3);
            tbSecu.Name = "tbSecu";
            tbSecu.Size = new System.Drawing.Size(116, 23);
            tbSecu.TabIndex = 31;
            tbSecu.TextChanged += tbTextChanged;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new System.Drawing.Point(232, 282);
            label12.Margin = new Padding(4, 0, 4, 0);
            label12.Name = "label12";
            label12.Size = new System.Drawing.Size(65, 15);
            label12.TabIndex = 30;
            label12.Text = "&Num. Sécu";
            // 
            // tbSiret
            // 
            tbSiret.Location = new System.Drawing.Point(98, 275);
            tbSiret.Margin = new Padding(4, 3, 4, 3);
            tbSiret.Name = "tbSiret";
            tbSiret.Size = new System.Drawing.Size(116, 23);
            tbSiret.TabIndex = 29;
            tbSiret.TextChanged += tbTextChanged;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new System.Drawing.Point(9, 278);
            label11.Margin = new Padding(4, 0, 4, 0);
            label11.Name = "label11";
            label11.Size = new System.Drawing.Size(30, 15);
            label11.TabIndex = 28;
            label11.Text = "&Siret";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new System.Drawing.Point(9, 144);
            label10.Margin = new Padding(4, 0, 4, 0);
            label10.Name = "label10";
            label10.Size = new System.Drawing.Size(64, 15);
            label10.TabIndex = 22;
            label10.Text = "&Règlement";
            // 
            // tbComment
            // 
            tbComment.AcceptsReturn = true;
            tbComment.Location = new System.Drawing.Point(98, 172);
            tbComment.Margin = new Padding(4, 3, 4, 3);
            tbComment.Multiline = true;
            tbComment.Name = "tbComment";
            tbComment.Size = new System.Drawing.Size(779, 95);
            tbComment.TabIndex = 27;
            tbComment.TextChanged += tbTextChanged;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new System.Drawing.Point(9, 175);
            label9.Margin = new Padding(4, 0, 4, 0);
            label9.Name = "label9";
            label9.Size = new System.Drawing.Size(88, 15);
            label9.TabIndex = 26;
            label9.Text = "Com&mentaires:";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new System.Drawing.Point(449, 144);
            label8.Margin = new Padding(4, 0, 4, 0);
            label8.Name = "label8";
            label8.Size = new System.Drawing.Size(62, 15);
            label8.TabIndex = 24;
            label8.Text = "&Téléphone";
            // 
            // tbTel
            // 
            tbTel.Location = new System.Drawing.Point(538, 141);
            tbTel.Margin = new Padding(4, 3, 4, 3);
            tbTel.Mask = "00 00 00 00 00";
            tbTel.Name = "tbTel";
            tbTel.Size = new System.Drawing.Size(116, 23);
            tbTel.TabIndex = 25;
            tbTel.TextChanged += tbTextChanged;
            // 
            // tbVille
            // 
            tbVille.Location = new System.Drawing.Point(538, 111);
            tbVille.Margin = new Padding(4, 3, 4, 3);
            tbVille.Name = "tbVille";
            tbVille.Size = new System.Drawing.Size(339, 23);
            tbVille.TabIndex = 21;
            tbVille.TextChanged += tbTextChanged;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new System.Drawing.Point(449, 114);
            label7.Margin = new Padding(4, 0, 4, 0);
            label7.Name = "label7";
            label7.Size = new System.Drawing.Size(32, 15);
            label7.TabIndex = 20;
            label7.Text = "&Ville:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new System.Drawing.Point(449, 84);
            label6.Margin = new Padding(4, 0, 4, 0);
            label6.Name = "label6";
            label6.Size = new System.Drawing.Size(73, 15);
            label6.TabIndex = 18;
            label6.Text = "Code &Postal:";
            // 
            // tbCodePostal
            // 
            tbCodePostal.Location = new System.Drawing.Point(538, 81);
            tbCodePostal.Margin = new Padding(4, 3, 4, 3);
            tbCodePostal.Mask = "00000";
            tbCodePostal.Name = "tbCodePostal";
            tbCodePostal.Size = new System.Drawing.Size(94, 23);
            tbCodePostal.TabIndex = 19;
            tbCodePostal.TextChanged += tbTextChanged;
            // 
            // tbAdresse
            // 
            tbAdresse.AcceptsReturn = true;
            tbAdresse.Location = new System.Drawing.Point(98, 81);
            tbAdresse.Margin = new Padding(4, 3, 4, 3);
            tbAdresse.Multiline = true;
            tbAdresse.Name = "tbAdresse";
            tbAdresse.Size = new System.Drawing.Size(339, 52);
            tbAdresse.TabIndex = 17;
            tbAdresse.TextChanged += tbTextChanged;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new System.Drawing.Point(9, 84);
            label5.Margin = new Padding(4, 0, 4, 0);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(54, 15);
            label5.TabIndex = 16;
            label5.Text = "&Adresse :";
            // 
            // tbInterlocuteur
            // 
            tbInterlocuteur.Location = new System.Drawing.Point(540, 52);
            tbInterlocuteur.Margin = new Padding(4, 3, 4, 3);
            tbInterlocuteur.Name = "tbInterlocuteur";
            tbInterlocuteur.Size = new System.Drawing.Size(339, 23);
            tbInterlocuteur.TabIndex = 9;
            tbInterlocuteur.TextChanged += tbTextChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(451, 55);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(78, 15);
            label3.TabIndex = 8;
            label3.Text = "&Interlocuteur:";
            // 
            // tbNom
            // 
            tbNom.Location = new System.Drawing.Point(97, 52);
            tbNom.Margin = new Padding(4, 3, 4, 3);
            tbNom.Name = "tbNom";
            tbNom.Size = new System.Drawing.Size(339, 23);
            tbNom.TabIndex = 7;
            tbNom.TextChanged += tbTextChanged;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new System.Drawing.Point(8, 55);
            label4.Margin = new Padding(4, 0, 4, 0);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(37, 15);
            label4.TabIndex = 6;
            label4.Text = "&Nom:";
            // 
            // tbRef
            // 
            tbRef.Location = new System.Drawing.Point(97, 22);
            tbRef.Margin = new Padding(4, 3, 4, 3);
            tbRef.Name = "tbRef";
            tbRef.Size = new System.Drawing.Size(116, 23);
            tbRef.TabIndex = 5;
            tbRef.TextChanged += tbTextChanged;
            // 
            // lblRef
            // 
            lblRef.AutoSize = true;
            lblRef.ForeColor = System.Drawing.Color.Blue;
            lblRef.Location = new System.Drawing.Point(8, 25);
            lblRef.Margin = new Padding(4, 0, 4, 0);
            lblRef.Name = "lblRef";
            lblRef.Size = new System.Drawing.Size(59, 15);
            lblRef.TabIndex = 4;
            lblRef.Text = "Référence";
            lblRef.Click += lblRef_Click;
            // 
            // panel1
            // 
            panel1.BorderStyle = BorderStyle.Fixed3D;
            panel1.Controls.Add(btnQuit);
            panel1.Controls.Add(btnSave);
            panel1.Controls.Add(btnLast);
            panel1.Controls.Add(btnNext);
            panel1.Controls.Add(btnPrev);
            panel1.Controls.Add(btnFirst);
            panel1.Location = new System.Drawing.Point(14, 393);
            panel1.Margin = new Padding(4, 3, 4, 3);
            panel1.Name = "panel1";
            panel1.Size = new System.Drawing.Size(886, 44);
            panel1.TabIndex = 6;
            // 
            // btnQuit
            // 
            btnQuit.CausesValidation = false;
            btnQuit.DialogResult = DialogResult.Cancel;
            btnQuit.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            btnQuit.ImageIndex = 5;
            btnQuit.ImageList = imageList1;
            btnQuit.Location = new System.Drawing.Point(757, 6);
            btnQuit.Margin = new Padding(4, 3, 4, 3);
            btnQuit.Name = "btnQuit";
            btnQuit.Size = new System.Drawing.Size(117, 29);
            btnQuit.TabIndex = 91;
            btnQuit.Text = "&Quitter";
            btnQuit.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            btnQuit.UseVisualStyleBackColor = true;
            btnQuit.Click += btnQuit_Click;
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
            // btnSave
            // 
            btnSave.CausesValidation = false;
            btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            btnSave.ImageIndex = 4;
            btnSave.ImageList = imageList1;
            btnSave.Location = new System.Drawing.Point(630, 6);
            btnSave.Margin = new Padding(4, 3, 4, 3);
            btnSave.Name = "btnSave";
            btnSave.Size = new System.Drawing.Size(117, 29);
            btnSave.TabIndex = 90;
            btnSave.Text = "Enregi&strer";
            btnSave.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // btnLast
            // 
            btnLast.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            btnLast.ImageIndex = 1;
            btnLast.ImageList = imageList1;
            btnLast.Location = new System.Drawing.Point(310, 6);
            btnLast.Margin = new Padding(4, 3, 4, 3);
            btnLast.Name = "btnLast";
            btnLast.Size = new System.Drawing.Size(93, 29);
            btnLast.TabIndex = 89;
            btnLast.Text = "Fin";
            btnLast.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            btnLast.UseVisualStyleBackColor = true;
            btnLast.Click += btnLast_Click;
            // 
            // btnNext
            // 
            btnNext.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            btnNext.ImageIndex = 3;
            btnNext.ImageList = imageList1;
            btnNext.Location = new System.Drawing.Point(210, 6);
            btnNext.Margin = new Padding(4, 3, 4, 3);
            btnNext.Name = "btnNext";
            btnNext.Size = new System.Drawing.Size(93, 29);
            btnNext.TabIndex = 88;
            btnNext.Text = "Suivant";
            btnNext.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            btnNext.UseVisualStyleBackColor = true;
            btnNext.Click += btnNext_Click;
            // 
            // btnPrev
            // 
            btnPrev.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            btnPrev.ImageIndex = 2;
            btnPrev.ImageList = imageList1;
            btnPrev.Location = new System.Drawing.Point(110, 6);
            btnPrev.Margin = new Padding(4, 3, 4, 3);
            btnPrev.Name = "btnPrev";
            btnPrev.Size = new System.Drawing.Size(93, 29);
            btnPrev.TabIndex = 87;
            btnPrev.Text = "Précédent";
            btnPrev.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            btnPrev.UseVisualStyleBackColor = true;
            btnPrev.Click += btnPrev_Click;
            // 
            // btnFirst
            // 
            btnFirst.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            btnFirst.ImageIndex = 0;
            btnFirst.ImageList = imageList1;
            btnFirst.Location = new System.Drawing.Point(9, 6);
            btnFirst.Margin = new Padding(4, 3, 4, 3);
            btnFirst.Name = "btnFirst";
            btnFirst.Size = new System.Drawing.Size(93, 29);
            btnFirst.TabIndex = 86;
            btnFirst.Text = "Début";
            btnFirst.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            btnFirst.UseVisualStyleBackColor = true;
            btnFirst.Click += btnFirst_Click;
            // 
            // FicheFournisseurForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            CancelButton = btnQuit;
            ClientSize = new System.Drawing.Size(915, 451);
            ControlBox = false;
            Controls.Add(panel1);
            Controls.Add(groupBox1);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(4, 3, 4, 3);
            MaximizeBox = false;
            Name = "FicheFournisseurForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Fiche Fournisseur";
            FormClosing += FicheFournisseurForm_FormClosing;
            Load += FicheFournisseurForm_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            panel1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion

        private Label label1;
        private GroupBox groupBox1;
        private TextBox tbInterlocuteur;
        private Label label3;
        private TextBox tbNom;
        private Label label4;
        private TextBox tbRef;
        private Label lblRef;
        private TextBox tbUrsaff;
        private Label label14;
        private TextBox tbApe;
        private Label label13;
        private TextBox tbSecu;
        private Label label12;
        private TextBox tbSiret;
        private Label label11;
        private Label label10;
        private TextBox tbComment;
        private Label label9;
        private Label label8;
        private MaskedTextBox tbTel;
        private TextBox tbVille;
        private Label label7;
        private Label label6;
        private MaskedTextBox tbCodePostal;
        private TextBox tbAdresse;
        private Label label5;
        private Panel panel1;
        private Button btnQuit;
        private Button btnSave;
        private Button btnLast;
        private Button btnNext;
        private Button btnPrev;
        private Button btnFirst;
        private ImageList imageList1;
        private ComboBox cbReglement;
        private CheckBox ckDesactiv;
    }
}