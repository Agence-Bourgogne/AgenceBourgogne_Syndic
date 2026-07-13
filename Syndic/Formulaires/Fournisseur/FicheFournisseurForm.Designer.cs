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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FicheFournisseurForm));
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbReglement = new System.Windows.Forms.ComboBox();
            this.tbUrsaff = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.tbApe = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.tbSecu = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.tbSiret = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.tbComment = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.tbTel = new System.Windows.Forms.MaskedTextBox();
            this.tbVille = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.tbCodePostal = new System.Windows.Forms.MaskedTextBox();
            this.tbAdresse = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tbInterlocuteur = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbNom = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tbRef = new System.Windows.Forms.TextBox();
            this.lblRef = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnEnter = new System.Windows.Forms.Button();
            this.btnQuit = new System.Windows.Forms.Button();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.btnSave = new System.Windows.Forms.Button();
            this.btnLast = new System.Windows.Forms.Button();
            this.btnNext = new System.Windows.Forms.Button();
            this.btnPrev = new System.Windows.Forms.Button();
            this.btnFirst = new System.Windows.Forms.Button();
            this.ckDesactiv = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
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
            this.label1.Location = new System.Drawing.Point(205, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(282, 20);
            this.label1.TabIndex = 4;
            this.label1.Text = "Agence Bourgogne : Fournisseurs";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.ckDesactiv);
            this.groupBox1.Controls.Add(this.cbReglement);
            this.groupBox1.Controls.Add(this.tbUrsaff);
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Controls.Add(this.tbApe);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.tbSecu);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.tbSiret);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.tbComment);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.tbTel);
            this.groupBox1.Controls.Add(this.tbVille);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.tbCodePostal);
            this.groupBox1.Controls.Add(this.tbAdresse);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.tbInterlocuteur);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.tbNom);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.tbRef);
            this.groupBox1.Controls.Add(this.lblRef);
            this.groupBox1.Location = new System.Drawing.Point(12, 32);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(760, 291);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Description Fournisseur";
            // 
            // cbReglement
            // 
            this.cbReglement.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbReglement.FormattingEnabled = true;
            this.cbReglement.Location = new System.Drawing.Point(84, 122);
            this.cbReglement.Name = "cbReglement";
            this.cbReglement.Size = new System.Drawing.Size(92, 21);
            this.cbReglement.TabIndex = 37;
            // 
            // tbUrsaff
            // 
            this.tbUrsaff.Location = new System.Drawing.Point(652, 241);
            this.tbUrsaff.Name = "tbUrsaff";
            this.tbUrsaff.Size = new System.Drawing.Size(100, 20);
            this.tbUrsaff.TabIndex = 35;
            this.tbUrsaff.TextChanged += new System.EventHandler(this.tbTextChanged);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(576, 244);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(57, 13);
            this.label14.TabIndex = 34;
            this.label14.Text = "Num &Ursaf";
            // 
            // tbApe
            // 
            this.tbApe.Location = new System.Drawing.Point(461, 241);
            this.tbApe.Name = "tbApe";
            this.tbApe.Size = new System.Drawing.Size(100, 20);
            this.tbApe.TabIndex = 33;
            this.tbApe.TextChanged += new System.EventHandler(this.tbTextChanged);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(385, 244);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(56, 13);
            this.label13.TabIndex = 32;
            this.label13.Text = "&Code APE";
            // 
            // tbSecu
            // 
            this.tbSecu.Location = new System.Drawing.Point(275, 241);
            this.tbSecu.Name = "tbSecu";
            this.tbSecu.Size = new System.Drawing.Size(100, 20);
            this.tbSecu.TabIndex = 31;
            this.tbSecu.TextChanged += new System.EventHandler(this.tbTextChanged);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(199, 244);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(60, 13);
            this.label12.TabIndex = 30;
            this.label12.Text = "&Num. Sécu";
            // 
            // tbSiret
            // 
            this.tbSiret.Location = new System.Drawing.Point(84, 238);
            this.tbSiret.Name = "tbSiret";
            this.tbSiret.Size = new System.Drawing.Size(100, 20);
            this.tbSiret.TabIndex = 29;
            this.tbSiret.TextChanged += new System.EventHandler(this.tbTextChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(8, 241);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(28, 13);
            this.label11.TabIndex = 28;
            this.label11.Text = "&Siret";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(8, 125);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(58, 13);
            this.label10.TabIndex = 22;
            this.label10.Text = "&Règlement";
            // 
            // tbComment
            // 
            this.tbComment.AcceptsReturn = true;
            this.tbComment.Location = new System.Drawing.Point(84, 149);
            this.tbComment.Multiline = true;
            this.tbComment.Name = "tbComment";
            this.tbComment.Size = new System.Drawing.Size(668, 83);
            this.tbComment.TabIndex = 27;
            this.tbComment.TextChanged += new System.EventHandler(this.tbTextChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(8, 152);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(76, 13);
            this.label9.TabIndex = 26;
            this.label9.Text = "Com&mentaires:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(385, 125);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(58, 13);
            this.label8.TabIndex = 24;
            this.label8.Text = "&Téléphone";
            // 
            // tbTel
            // 
            this.tbTel.Location = new System.Drawing.Point(461, 122);
            this.tbTel.Mask = "00 00 00 00 00";
            this.tbTel.Name = "tbTel";
            this.tbTel.Size = new System.Drawing.Size(100, 20);
            this.tbTel.TabIndex = 25;
            this.tbTel.TextChanged += new System.EventHandler(this.tbTextChanged);
            // 
            // tbVille
            // 
            this.tbVille.Location = new System.Drawing.Point(461, 96);
            this.tbVille.Name = "tbVille";
            this.tbVille.Size = new System.Drawing.Size(291, 20);
            this.tbVille.TabIndex = 21;
            this.tbVille.TextChanged += new System.EventHandler(this.tbTextChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(385, 99);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(29, 13);
            this.label7.TabIndex = 20;
            this.label7.Text = "&Ville:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(385, 73);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(67, 13);
            this.label6.TabIndex = 18;
            this.label6.Text = "Code &Postal:";
            // 
            // tbCodePostal
            // 
            this.tbCodePostal.Location = new System.Drawing.Point(461, 70);
            this.tbCodePostal.Mask = "00000";
            this.tbCodePostal.Name = "tbCodePostal";
            this.tbCodePostal.Size = new System.Drawing.Size(81, 20);
            this.tbCodePostal.TabIndex = 19;
            this.tbCodePostal.TextChanged += new System.EventHandler(this.tbTextChanged);
            // 
            // tbAdresse
            // 
            this.tbAdresse.AcceptsReturn = true;
            this.tbAdresse.Location = new System.Drawing.Point(84, 70);
            this.tbAdresse.Multiline = true;
            this.tbAdresse.Name = "tbAdresse";
            this.tbAdresse.Size = new System.Drawing.Size(291, 46);
            this.tbAdresse.TabIndex = 17;
            this.tbAdresse.TextChanged += new System.EventHandler(this.tbTextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(8, 73);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(51, 13);
            this.label5.TabIndex = 16;
            this.label5.Text = "&Adresse :";
            // 
            // tbInterlocuteur
            // 
            this.tbInterlocuteur.Location = new System.Drawing.Point(463, 45);
            this.tbInterlocuteur.Name = "tbInterlocuteur";
            this.tbInterlocuteur.Size = new System.Drawing.Size(291, 20);
            this.tbInterlocuteur.TabIndex = 9;
            this.tbInterlocuteur.TextChanged += new System.EventHandler(this.tbTextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(387, 48);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "&Interlocuteur:";
            // 
            // tbNom
            // 
            this.tbNom.Location = new System.Drawing.Point(83, 45);
            this.tbNom.Name = "tbNom";
            this.tbNom.Size = new System.Drawing.Size(291, 20);
            this.tbNom.TabIndex = 7;
            this.tbNom.TextChanged += new System.EventHandler(this.tbTextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 48);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(32, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "&Nom:";
            // 
            // tbRef
            // 
            this.tbRef.Location = new System.Drawing.Point(83, 19);
            this.tbRef.Name = "tbRef";
            this.tbRef.Size = new System.Drawing.Size(100, 20);
            this.tbRef.TabIndex = 5;
            this.tbRef.TextChanged += new System.EventHandler(this.tbTextChanged);
            // 
            // lblRef
            // 
            this.lblRef.AutoSize = true;
            this.lblRef.ForeColor = System.Drawing.Color.Blue;
            this.lblRef.Location = new System.Drawing.Point(7, 22);
            this.lblRef.Name = "lblRef";
            this.lblRef.Size = new System.Drawing.Size(57, 13);
            this.lblRef.TabIndex = 4;
            this.lblRef.Text = "Référence";
            this.lblRef.Click += new System.EventHandler(this.lblRef_Click);
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
            this.panel1.Location = new System.Drawing.Point(12, 341);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(760, 39);
            this.panel1.TabIndex = 6;
            // 
            // btnEnter
            // 
            this.btnEnter.Location = new System.Drawing.Point(398, 7);
            this.btnEnter.Name = "btnEnter";
            this.btnEnter.Size = new System.Drawing.Size(75, 23);
            this.btnEnter.TabIndex = 115;
            this.btnEnter.Text = "button1";
            this.btnEnter.UseVisualStyleBackColor = true;
            this.btnEnter.Click += new System.EventHandler(this.btnEnter_Click);
            // 
            // btnQuit
            // 
            this.btnQuit.CausesValidation = false;
            this.btnQuit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnQuit.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnQuit.ImageIndex = 5;
            this.btnQuit.ImageList = this.imageList1;
            this.btnQuit.Location = new System.Drawing.Point(649, 5);
            this.btnQuit.Name = "btnQuit";
            this.btnQuit.Size = new System.Drawing.Size(100, 25);
            this.btnQuit.TabIndex = 91;
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
            this.btnSave.Location = new System.Drawing.Point(540, 5);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(100, 25);
            this.btnSave.TabIndex = 90;
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
            this.btnLast.Location = new System.Drawing.Point(266, 5);
            this.btnLast.Name = "btnLast";
            this.btnLast.Size = new System.Drawing.Size(80, 25);
            this.btnLast.TabIndex = 89;
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
            this.btnNext.Location = new System.Drawing.Point(180, 5);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(80, 25);
            this.btnNext.TabIndex = 88;
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
            this.btnPrev.Location = new System.Drawing.Point(94, 5);
            this.btnPrev.Name = "btnPrev";
            this.btnPrev.Size = new System.Drawing.Size(80, 25);
            this.btnPrev.TabIndex = 87;
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
            this.btnFirst.Location = new System.Drawing.Point(8, 5);
            this.btnFirst.Name = "btnFirst";
            this.btnFirst.Size = new System.Drawing.Size(80, 25);
            this.btnFirst.TabIndex = 86;
            this.btnFirst.Text = "Début";
            this.btnFirst.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnFirst.UseVisualStyleBackColor = true;
            this.btnFirst.Click += new System.EventHandler(this.btnFirst_Click);
            // 
            // ckDesactiv
            // 
            this.ckDesactiv.AutoSize = true;
            this.ckDesactiv.Location = new System.Drawing.Point(11, 268);
            this.ckDesactiv.Name = "ckDesactiv";
            this.ckDesactiv.Size = new System.Drawing.Size(74, 17);
            this.ckDesactiv.TabIndex = 38;
            this.ckDesactiv.Text = "Désactivé";
            this.ckDesactiv.UseVisualStyleBackColor = true;
            // 
            // FicheFournisseurForm
            // 
            this.AcceptButton = this.btnEnter;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnQuit;
            this.ClientSize = new System.Drawing.Size(784, 391);
            this.ControlBox = false;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FicheFournisseurForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Fiche Fournisseur";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FicheFournisseurForm_FormClosing);
            this.Load += new System.EventHandler(this.FicheFournisseurForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

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
        private Button btnEnter;
        private CheckBox ckDesactiv;
    }
}