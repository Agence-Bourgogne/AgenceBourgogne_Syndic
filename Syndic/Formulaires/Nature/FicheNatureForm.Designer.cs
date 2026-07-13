namespace EspaceSyndic.Formulaires.Nature
{
    partial class FicheNatureForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FicheNatureForm));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tbNomCompta = new System.Windows.Forms.TextBox();
            this.lblNomCompta = new System.Windows.Forms.Label();
            this.ckBudget = new System.Windows.Forms.CheckBox();
            this.cbTypeCharge = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.tbRefComptable = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tbDeclaration = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbPart = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tbNom = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tbRef = new System.Windows.Forms.TextBox();
            this.lblReference = new System.Windows.Forms.Label();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnEnter = new System.Windows.Forms.Button();
            this.btnQuit = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnLast = new System.Windows.Forms.Button();
            this.btnNext = new System.Windows.Forms.Button();
            this.btnPrev = new System.Windows.Forms.Button();
            this.btnFirst = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.ckDesactiv = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.ckDesactiv);
            this.groupBox1.Controls.Add(this.tbNomCompta);
            this.groupBox1.Controls.Add(this.lblNomCompta);
            this.groupBox1.Controls.Add(this.ckBudget);
            this.groupBox1.Controls.Add(this.cbTypeCharge);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.tbRefComptable);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.tbDeclaration);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.tbPart);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.tbNom);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.tbRef);
            this.groupBox1.Controls.Add(this.lblReference);
            this.groupBox1.Location = new System.Drawing.Point(12, 36);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(760, 247);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Nature";
            // 
            // tbNomCompta
            // 
            this.tbNomCompta.Location = new System.Drawing.Point(334, 123);
            this.tbNomCompta.Name = "tbNomCompta";
            this.tbNomCompta.Size = new System.Drawing.Size(291, 20);
            this.tbNomCompta.TabIndex = 12;
            // 
            // lblNomCompta
            // 
            this.lblNomCompta.AutoSize = true;
            this.lblNomCompta.Location = new System.Drawing.Point(264, 126);
            this.lblNomCompta.Name = "lblNomCompta";
            this.lblNomCompta.Size = new System.Drawing.Size(37, 13);
            this.lblNomCompta.TabIndex = 11;
            this.lblNomCompta.Text = "Libellé";
            // 
            // ckBudget
            // 
            this.ckBudget.AutoSize = true;
            this.ckBudget.Location = new System.Drawing.Point(149, 190);
            this.ckBudget.Name = "ckBudget";
            this.ckBudget.Size = new System.Drawing.Size(87, 17);
            this.ckBudget.TabIndex = 15;
            this.ckBudget.Text = "Budgetisable";
            this.ckBudget.UseVisualStyleBackColor = true;
            this.ckBudget.CheckedChanged += new System.EventHandler(this.ckBudget_CheckedChanged);
            // 
            // cbTypeCharge
            // 
            this.cbTypeCharge.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTypeCharge.FormattingEnabled = true;
            this.cbTypeCharge.Location = new System.Drawing.Point(149, 153);
            this.cbTypeCharge.Name = "cbTypeCharge";
            this.cbTypeCharge.Size = new System.Drawing.Size(291, 21);
            this.cbTypeCharge.TabIndex = 14;
            this.cbTypeCharge.SelectedIndexChanged += new System.EventHandler(this.cbTypeCharge_SelectedIndexChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(9, 156);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(83, 13);
            this.label7.TabIndex = 13;
            this.label7.Text = "Type de Charge";
            // 
            // tbRefComptable
            // 
            this.tbRefComptable.Location = new System.Drawing.Point(149, 123);
            this.tbRefComptable.Name = "tbRefComptable";
            this.tbRefComptable.Size = new System.Drawing.Size(100, 20);
            this.tbRefComptable.TabIndex = 10;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(9, 126);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(134, 13);
            this.label6.TabIndex = 9;
            this.label6.Text = "Référence Plan Comptable";
            // 
            // tbDeclaration
            // 
            this.tbDeclaration.Location = new System.Drawing.Point(149, 98);
            this.tbDeclaration.Name = "tbDeclaration";
            this.tbDeclaration.Size = new System.Drawing.Size(100, 20);
            this.tbDeclaration.TabIndex = 8;
            this.tbDeclaration.TextChanged += new System.EventHandler(this.tbTextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 101);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Déclaration";
            // 
            // tbPart
            // 
            this.tbPart.Location = new System.Drawing.Point(149, 72);
            this.tbPart.Name = "tbPart";
            this.tbPart.Size = new System.Drawing.Size(100, 20);
            this.tbPart.TabIndex = 6;
            this.tbPart.TextChanged += new System.EventHandler(this.tbTextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 75);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Part Locative";
            // 
            // tbNom
            // 
            this.tbNom.Location = new System.Drawing.Point(149, 45);
            this.tbNom.Name = "tbNom";
            this.tbNom.Size = new System.Drawing.Size(291, 20);
            this.tbNom.TabIndex = 4;
            this.tbNom.TextChanged += new System.EventHandler(this.tbTextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 48);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(32, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Nom:";
            // 
            // tbRef
            // 
            this.tbRef.Location = new System.Drawing.Point(149, 19);
            this.tbRef.Name = "tbRef";
            this.tbRef.Size = new System.Drawing.Size(100, 20);
            this.tbRef.TabIndex = 2;
            this.tbRef.TextChanged += new System.EventHandler(this.tbTextChanged);
            // 
            // lblReference
            // 
            this.lblReference.AutoSize = true;
            this.lblReference.ForeColor = System.Drawing.Color.Blue;
            this.lblReference.Location = new System.Drawing.Point(9, 22);
            this.lblReference.Name = "lblReference";
            this.lblReference.Size = new System.Drawing.Size(57, 13);
            this.lblReference.TabIndex = 1;
            this.lblReference.Text = "Référence";
            this.lblReference.Click += new System.EventHandler(this.lblReference_Click);
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
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.btnEnter);
            this.panel1.Controls.Add(this.btnQuit);
            this.panel1.Controls.Add(this.btnSave);
            this.panel1.Controls.Add(this.btnLast);
            this.panel1.Controls.Add(this.btnNext);
            this.panel1.Controls.Add(this.btnPrev);
            this.panel1.Controls.Add(this.btnFirst);
            this.panel1.Location = new System.Drawing.Point(12, 289);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(760, 39);
            this.panel1.TabIndex = 2;
            // 
            // btnEnter
            // 
            this.btnEnter.Location = new System.Drawing.Point(402, 6);
            this.btnEnter.Name = "btnEnter";
            this.btnEnter.Size = new System.Drawing.Size(75, 23);
            this.btnEnter.TabIndex = 117;
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
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
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
            this.btnLast.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
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
            this.btnNext.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
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
            this.btnPrev.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
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
            this.btnFirst.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
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
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(276, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(241, 20);
            this.label5.TabIndex = 8;
            this.label5.Text = "Agence Bourgogne : Natures";
            this.label5.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // ckDesactiv
            // 
            this.ckDesactiv.AutoSize = true;
            this.ckDesactiv.Location = new System.Drawing.Point(149, 213);
            this.ckDesactiv.Name = "ckDesactiv";
            this.ckDesactiv.Size = new System.Drawing.Size(74, 17);
            this.ckDesactiv.TabIndex = 16;
            this.ckDesactiv.Text = "Désactivé";
            this.ckDesactiv.UseVisualStyleBackColor = true;
            // 
            // FicheNatureForm
            // 
            this.AcceptButton = this.btnEnter;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnQuit;
            this.ClientSize = new System.Drawing.Size(784, 340);
            this.ControlBox = false;
            this.Controls.Add(this.label5);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.groupBox1);
            this.Name = "FicheNatureForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Fiche Nature";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FicheNatureForm_FormClosing);
            this.Load += new System.EventHandler(this.FicheNatureForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox tbRef;
        private System.Windows.Forms.Label lblReference;
        private System.Windows.Forms.TextBox tbDeclaration;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbPart;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbNom;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnQuit;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnLast;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Button btnPrev;
        private System.Windows.Forms.Button btnFirst;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbRefComptable;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnEnter;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cbTypeCharge;
        private System.Windows.Forms.CheckBox ckBudget;
        private System.Windows.Forms.TextBox tbNomCompta;
        private System.Windows.Forms.Label lblNomCompta;
        private System.Windows.Forms.CheckBox ckDesactiv;
    }
}