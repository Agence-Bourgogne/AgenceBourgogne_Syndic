namespace Gerance.Formulaires.Reglements
{
    partial class ReglementLocataireForm
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReglementLocataireForm));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tbLblProprio = new System.Windows.Forms.TextBox();
            this.lblProprio = new System.Windows.Forms.Label();
            this.tbPrenomProprio = new System.Windows.Forms.TextBox();
            this.tbNomProprio = new System.Windows.Forms.TextBox();
            this.tbRefProprio = new System.Windows.Forms.TextBox();
            this.tbNumLot = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tbNomImmeuble = new System.Windows.Forms.TextBox();
            this.tbRefImmeuble = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbPrenomLocataire = new System.Windows.Forms.TextBox();
            this.tbNomLocataire = new System.Windows.Forms.TextBox();
            this.tbRefLocataire = new System.Windows.Forms.TextBox();
            this.lblRefLocataire = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tbBanque = new System.Windows.Forms.TextBox();
            this.lblBanque = new System.Windows.Forms.Label();
            this.tbTire = new System.Windows.Forms.TextBox();
            this.lblTire = new System.Windows.Forms.Label();
            this.cbReglement = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.tbMontant = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.tbLibelle = new System.Windows.Forms.TextBox();
            this.dtReg = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.tbBaseHono = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tbMontantDu = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.btnDelete = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnDelete);
            this.panel1.Location = new System.Drawing.Point(10, 558);
            this.panel1.Controls.SetChildIndex(this.btnFirst, 0);
            this.panel1.Controls.SetChildIndex(this.btnPrev, 0);
            this.panel1.Controls.SetChildIndex(this.btnNext, 0);
            this.panel1.Controls.SetChildIndex(this.btnLast, 0);
            this.panel1.Controls.SetChildIndex(this.btnSave, 0);
            this.panel1.Controls.SetChildIndex(this.btnQuit, 0);
            this.panel1.Controls.SetChildIndex(this.btnEnter, 0);
            this.panel1.Controls.SetChildIndex(this.btnDelete, 0);
            // 
            // btnEnter
            // 
            this.btnEnter.Size = new System.Drawing.Size(0, 23);
            // 
            // btnQuit
            // 
            this.btnQuit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // btnNext
            // 
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click_1);
            // 
            // btnPrev
            // 
            this.btnPrev.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPrev.Click += new System.EventHandler(this.btnPrev_Click_1);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.Images.SetKeyName(0, "top.png");
            this.imageList1.Images.SetKeyName(1, "bottom.png");
            this.imageList1.Images.SetKeyName(2, "previous.png");
            this.imageList1.Images.SetKeyName(3, "next.png");
            this.imageList1.Images.SetKeyName(4, "save.png");
            this.imageList1.Images.SetKeyName(5, "quit.png");
            this.imageList1.Images.SetKeyName(6, "stop.png");
            this.imageList1.Images.SetKeyName(7, "zoom.png");
            this.imageList1.Images.SetKeyName(8, "print.png");
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.tbLblProprio);
            this.groupBox1.Controls.Add(this.lblProprio);
            this.groupBox1.Controls.Add(this.tbPrenomProprio);
            this.groupBox1.Controls.Add(this.tbNomProprio);
            this.groupBox1.Controls.Add(this.tbRefProprio);
            this.groupBox1.Controls.Add(this.tbNumLot);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.tbNomImmeuble);
            this.groupBox1.Controls.Add(this.tbRefImmeuble);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.tbPrenomLocataire);
            this.groupBox1.Controls.Add(this.tbNomLocataire);
            this.groupBox1.Controls.Add(this.tbRefLocataire);
            this.groupBox1.Controls.Add(this.lblRefLocataire);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(758, 100);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // tbLblProprio
            // 
            this.tbLblProprio.Location = new System.Drawing.Point(80, 92);
            this.tbLblProprio.Name = "tbLblProprio";
            this.tbLblProprio.Size = new System.Drawing.Size(100, 20);
            this.tbLblProprio.TabIndex = 13;
            this.tbLblProprio.Text = "Proprietaire";
            // 
            // lblProprio
            // 
            this.lblProprio.AutoSize = true;
            this.lblProprio.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblProprio.Location = new System.Drawing.Point(12, 71);
            this.lblProprio.Name = "lblProprio";
            this.lblProprio.Size = new System.Drawing.Size(60, 13);
            this.lblProprio.TabIndex = 9;
            this.lblProprio.Text = "Propriétaire";
            // 
            // tbPrenomProprio
            // 
            this.tbPrenomProprio.Enabled = false;
            this.tbPrenomProprio.Location = new System.Drawing.Point(501, 68);
            this.tbPrenomProprio.Name = "tbPrenomProprio";
            this.tbPrenomProprio.ReadOnly = true;
            this.tbPrenomProprio.Size = new System.Drawing.Size(243, 20);
            this.tbPrenomProprio.TabIndex = 12;
            // 
            // tbNomProprio
            // 
            this.tbNomProprio.Enabled = false;
            this.tbNomProprio.Location = new System.Drawing.Point(226, 68);
            this.tbNomProprio.Name = "tbNomProprio";
            this.tbNomProprio.ReadOnly = true;
            this.tbNomProprio.Size = new System.Drawing.Size(243, 20);
            this.tbNomProprio.TabIndex = 11;
            // 
            // tbRefProprio
            // 
            this.tbRefProprio.Enabled = false;
            this.tbRefProprio.Location = new System.Drawing.Point(97, 68);
            this.tbRefProprio.Name = "tbRefProprio";
            this.tbRefProprio.ReadOnly = true;
            this.tbRefProprio.Size = new System.Drawing.Size(100, 20);
            this.tbRefProprio.TabIndex = 10;
            // 
            // tbNumLot
            // 
            this.tbNumLot.Enabled = false;
            this.tbNumLot.Location = new System.Drawing.Point(688, 42);
            this.tbNumLot.Name = "tbNumLot";
            this.tbNumLot.ReadOnly = true;
            this.tbNumLot.Size = new System.Drawing.Size(56, 20);
            this.tbNumLot.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(606, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Numéro du lot:";
            // 
            // tbNomImmeuble
            // 
            this.tbNomImmeuble.Enabled = false;
            this.tbNomImmeuble.Location = new System.Drawing.Point(226, 42);
            this.tbNomImmeuble.Name = "tbNomImmeuble";
            this.tbNomImmeuble.ReadOnly = true;
            this.tbNomImmeuble.Size = new System.Drawing.Size(243, 20);
            this.tbNomImmeuble.TabIndex = 6;
            // 
            // tbRefImmeuble
            // 
            this.tbRefImmeuble.Enabled = false;
            this.tbRefImmeuble.Location = new System.Drawing.Point(97, 42);
            this.tbRefImmeuble.Name = "tbRefImmeuble";
            this.tbRefImmeuble.ReadOnly = true;
            this.tbRefImmeuble.Size = new System.Drawing.Size(100, 20);
            this.tbRefImmeuble.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Immeuble";
            // 
            // tbPrenomLocataire
            // 
            this.tbPrenomLocataire.Enabled = false;
            this.tbPrenomLocataire.Location = new System.Drawing.Point(501, 18);
            this.tbPrenomLocataire.Name = "tbPrenomLocataire";
            this.tbPrenomLocataire.ReadOnly = true;
            this.tbPrenomLocataire.Size = new System.Drawing.Size(243, 20);
            this.tbPrenomLocataire.TabIndex = 3;
            // 
            // tbNomLocataire
            // 
            this.tbNomLocataire.Enabled = false;
            this.tbNomLocataire.Location = new System.Drawing.Point(226, 18);
            this.tbNomLocataire.Name = "tbNomLocataire";
            this.tbNomLocataire.ReadOnly = true;
            this.tbNomLocataire.Size = new System.Drawing.Size(243, 20);
            this.tbNomLocataire.TabIndex = 2;
            // 
            // tbRefLocataire
            // 
            this.tbRefLocataire.HideSelection = false;
            this.tbRefLocataire.Location = new System.Drawing.Point(97, 18);
            this.tbRefLocataire.Name = "tbRefLocataire";
            this.tbRefLocataire.Size = new System.Drawing.Size(100, 20);
            this.tbRefLocataire.TabIndex = 1;
            this.tbRefLocataire.ReadOnlyChanged += new System.EventHandler(this.tbRefLocataire_ReadOnlyChanged);
            this.tbRefLocataire.KeyDown += new System.Windows.Forms.KeyEventHandler(this.standard_KeyDown);
            this.tbRefLocataire.Validating += new System.ComponentModel.CancelEventHandler(this.tbRefLocataire_Validating);
            // 
            // lblRefLocataire
            // 
            this.lblRefLocataire.AutoSize = true;
            this.lblRefLocataire.ForeColor = System.Drawing.Color.Blue;
            this.lblRefLocataire.Location = new System.Drawing.Point(12, 21);
            this.lblRefLocataire.Name = "lblRefLocataire";
            this.lblRefLocataire.Size = new System.Drawing.Size(74, 13);
            this.lblRefLocataire.TabIndex = 0;
            this.lblRefLocataire.Text = "&Réf. Locataire";
            this.lblRefLocataire.Click += new System.EventHandler(this.lblRefLocataire_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.tbBanque);
            this.groupBox2.Controls.Add(this.lblBanque);
            this.groupBox2.Controls.Add(this.tbTire);
            this.groupBox2.Controls.Add(this.lblTire);
            this.groupBox2.Controls.Add(this.cbReglement);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.tbMontant);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.tbLibelle);
            this.groupBox2.Controls.Add(this.dtReg);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.tbBaseHono);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.tbMontantDu);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Location = new System.Drawing.Point(10, 118);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(760, 110);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Règlement";
            // 
            // tbBanque
            // 
            this.tbBanque.Location = new System.Drawing.Point(540, 72);
            this.tbBanque.Name = "tbBanque";
            this.tbBanque.Size = new System.Drawing.Size(206, 20);
            this.tbBanque.TabIndex = 40;
            // 
            // lblBanque
            // 
            this.lblBanque.AutoSize = true;
            this.lblBanque.Location = new System.Drawing.Point(477, 74);
            this.lblBanque.Name = "lblBanque";
            this.lblBanque.Size = new System.Drawing.Size(44, 13);
            this.lblBanque.TabIndex = 39;
            this.lblBanque.Text = "Ban&que";
            // 
            // tbTire
            // 
            this.tbTire.Location = new System.Drawing.Point(282, 71);
            this.tbTire.Name = "tbTire";
            this.tbTire.Size = new System.Drawing.Size(189, 20);
            this.tbTire.TabIndex = 38;
            // 
            // lblTire
            // 
            this.lblTire.AutoSize = true;
            this.lblTire.Location = new System.Drawing.Point(190, 75);
            this.lblTire.Name = "lblTire";
            this.lblTire.Size = new System.Drawing.Size(25, 13);
            this.lblTire.TabIndex = 37;
            this.lblTire.Text = "&Tiré";
            // 
            // cbReglement
            // 
            this.cbReglement.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbReglement.FormattingEnabled = true;
            this.cbReglement.Location = new System.Drawing.Point(79, 71);
            this.cbReglement.Name = "cbReglement";
            this.cbReglement.Size = new System.Drawing.Size(85, 21);
            this.cbReglement.TabIndex = 36;
            this.cbReglement.SelectedIndexChanged += new System.EventHandler(this.cbReglement_SelectedIndexChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(9, 75);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(58, 13);
            this.label9.TabIndex = 35;
            this.label9.Text = "Rè&glement";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(618, 48);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(46, 13);
            this.label8.TabIndex = 33;
            this.label8.Text = "Montant";
            // 
            // tbMontant
            // 
            this.tbMontant.Location = new System.Drawing.Point(681, 45);
            this.tbMontant.Name = "tbMontant";
            this.tbMontant.Size = new System.Drawing.Size(65, 20);
            this.tbMontant.TabIndex = 34;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(190, 48);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(37, 13);
            this.label7.TabIndex = 31;
            this.label7.Text = "&Libellé";
            // 
            // tbLibelle
            // 
            this.tbLibelle.Location = new System.Drawing.Point(282, 45);
            this.tbLibelle.Name = "tbLibelle";
            this.tbLibelle.Size = new System.Drawing.Size(317, 20);
            this.tbLibelle.TabIndex = 32;
            this.tbLibelle.KeyUp += new System.Windows.Forms.KeyEventHandler(this.tbLibelle_KeyPress);
            // 
            // dtReg
            // 
            this.dtReg.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtReg.Location = new System.Drawing.Point(79, 45);
            this.dtReg.Name = "dtReg";
            this.dtReg.Size = new System.Drawing.Size(85, 20);
            this.dtReg.TabIndex = 30;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(9, 48);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(56, 13);
            this.label6.TabIndex = 29;
            this.label6.Text = "&Date Reg.";
            // 
            // tbBaseHono
            // 
            this.tbBaseHono.Enabled = false;
            this.tbBaseHono.Location = new System.Drawing.Point(282, 19);
            this.tbBaseHono.Name = "tbBaseHono";
            this.tbBaseHono.ReadOnly = true;
            this.tbBaseHono.Size = new System.Drawing.Size(100, 20);
            this.tbBaseHono.TabIndex = 3;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(190, 22);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(80, 13);
            this.label5.TabIndex = 2;
            this.label5.Text = "&Base Honoraire";
            // 
            // tbMontantDu
            // 
            this.tbMontantDu.Enabled = false;
            this.tbMontantDu.Location = new System.Drawing.Point(79, 19);
            this.tbMontantDu.Name = "tbMontantDu";
            this.tbMontantDu.ReadOnly = true;
            this.tbMontantDu.Size = new System.Drawing.Size(85, 20);
            this.tbMontantDu.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 22);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(61, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Montant dû";
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.dataGridView);
            this.groupBox3.Location = new System.Drawing.Point(10, 234);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(760, 318);
            this.groupBox3.TabIndex = 12;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Règlements des 30 Derniers Jours";
            // 
            // dataGridView
            // 
            this.dataGridView.AllowUserToAddRows = false;
            this.dataGridView.AllowUserToResizeRows = false;
            this.dataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Location = new System.Drawing.Point(15, 22);
            this.dataGridView.MultiSelect = false;
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.ReadOnly = true;
            this.dataGridView.RowHeadersVisible = false;
            this.dataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView.Size = new System.Drawing.Size(731, 284);
            this.dataGridView.TabIndex = 0;
            this.dataGridView.SelectionChanged += new System.EventHandler(this.dataGridView_SelectionChanged);
            this.dataGridView.DoubleClick += new System.EventHandler(this.dataGridView_DoubleClick);
            // 
            // btnDelete
            // 
            this.btnDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnDelete.ImageKey = "stop.png";
            this.btnDelete.ImageList = this.imageList1;
            this.btnDelete.Location = new System.Drawing.Point(406, 5);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(80, 25);
            this.btnDelete.TabIndex = 118;
            this.btnDelete.Text = "&Annuler";
            this.btnDelete.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // ReglementLocataireForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(782, 605);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "ReglementLocataireForm";
            this.Text = "Enregistrement des règlements";
            this.Load += new System.EventHandler(this.ReglementLocataireForm_Load);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.groupBox2, 0);
            this.Controls.SetChildIndex(this.groupBox3, 0);
            this.panel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox tbRefLocataire;
        private System.Windows.Forms.Label lblRefLocataire;
        private System.Windows.Forms.TextBox tbPrenomLocataire;
        private System.Windows.Forms.TextBox tbNomLocataire;
        protected System.Windows.Forms.TextBox tbRefImmeuble;
        protected System.Windows.Forms.Label label2;
        protected System.Windows.Forms.TextBox tbNomImmeuble;
        protected System.Windows.Forms.TextBox tbNumLot;
        protected System.Windows.Forms.Label label1;
        protected System.Windows.Forms.Label lblProprio;
        private System.Windows.Forms.TextBox tbPrenomProprio;
        private System.Windows.Forms.TextBox tbNomProprio;
        protected System.Windows.Forms.TextBox tbRefProprio;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox tbBaseHono;
        protected System.Windows.Forms.Label label5;
        protected System.Windows.Forms.TextBox tbMontantDu;
        protected System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.TextBox tbBanque;
        private System.Windows.Forms.Label lblBanque;
        private System.Windows.Forms.TextBox tbTire;
        private System.Windows.Forms.Label lblTire;
        private System.Windows.Forms.ComboBox cbReglement;
        protected System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox tbMontant;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox tbLibelle;
        private System.Windows.Forms.DateTimePicker dtReg;
        protected System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.TextBox tbLblProprio;
    }
}
