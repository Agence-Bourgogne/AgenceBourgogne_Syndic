namespace Gerance.Formulaires.AppelALoyer
{
    partial class AnnulationQuittanceForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AnnulationQuittanceForm));
            this.gbHdr = new System.Windows.Forms.GroupBox();
            this.label21 = new System.Windows.Forms.Label();
            this.tbNomImmeuble = new System.Windows.Forms.TextBox();
            this.tbNomLocataire = new System.Windows.Forms.TextBox();
            this.tbNomProprio = new System.Windows.Forms.TextBox();
            this.tbRefLocataire = new System.Windows.Forms.TextBox();
            this.lblLocataire = new System.Windows.Forms.Label();
            this.tbRefProprio = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.tbNumLot = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.lblImmeuble = new System.Windows.Forms.Label();
            this.tbRefImmeuble = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dtQuittance = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tbHonoLoc = new System.Windows.Forms.TextBox();
            this.tbHdrQuittance = new System.Windows.Forms.TextBox();
            this.label26 = new System.Windows.Forms.Label();
            this.tbFraisBail = new System.Windows.Forms.TextBox();
            this.label25 = new System.Windows.Forms.Label();
            this.tbCharges = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.tbMontant5 = new System.Windows.Forms.TextBox();
            this.lblPresta5 = new System.Windows.Forms.Label();
            this.tbPresta5 = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.tbMontant4 = new System.Windows.Forms.TextBox();
            this.lblPresta4 = new System.Windows.Forms.Label();
            this.tbPresta4 = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.tbMontant3 = new System.Windows.Forms.TextBox();
            this.lblPresta3 = new System.Windows.Forms.Label();
            this.tbPresta3 = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.tbMontant2 = new System.Windows.Forms.TextBox();
            this.lblPresta2 = new System.Windows.Forms.Label();
            this.tbPresta2 = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.tbMontant1 = new System.Windows.Forms.TextBox();
            this.lblPresta1 = new System.Windows.Forms.Label();
            this.tbPresta1 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tbTVA = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tbAugment = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.tbLoyer = new System.Windows.Forms.TextBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.btnDelete = new System.Windows.Forms.Button();
            this.label30 = new System.Windows.Forms.Label();
            this.tbEtatLieux = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.gbHdr.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnDelete);
            this.panel1.Location = new System.Drawing.Point(10, 325);
            this.panel1.TabIndex = 2;
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
            this.toolTip1.SetToolTip(this.btnSave, "Enregistrer les mofications\r\net \r\nMettre à jour le dossier");
            // 
            // btnPrev
            // 
            this.btnPrev.ImageIndex = 7;
            this.btnPrev.Text = "&Imprimer";
            this.btnPrev.Click += new System.EventHandler(this.btnPrev_Click_1);
            // 
            // btnFirst
            // 
            this.toolTip1.SetToolTip(this.btnFirst, "Annuler la quittance\r\net \r\nMettre à jour le Dossier");
            this.btnFirst.Visible = true;
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
            this.imageList1.Images.SetKeyName(7, "print.png");
            // 
            // gbHdr
            // 
            this.gbHdr.Controls.Add(this.label21);
            this.gbHdr.Controls.Add(this.tbNomImmeuble);
            this.gbHdr.Controls.Add(this.tbNomLocataire);
            this.gbHdr.Controls.Add(this.tbNomProprio);
            this.gbHdr.Controls.Add(this.tbRefLocataire);
            this.gbHdr.Controls.Add(this.lblLocataire);
            this.gbHdr.Controls.Add(this.tbRefProprio);
            this.gbHdr.Controls.Add(this.label19);
            this.gbHdr.Controls.Add(this.tbNumLot);
            this.gbHdr.Controls.Add(this.label18);
            this.gbHdr.Controls.Add(this.lblImmeuble);
            this.gbHdr.Controls.Add(this.tbRefImmeuble);
            this.gbHdr.Location = new System.Drawing.Point(10, 12);
            this.gbHdr.Name = "gbHdr";
            this.gbHdr.Size = new System.Drawing.Size(760, 68);
            this.gbHdr.TabIndex = 0;
            this.gbHdr.TabStop = false;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(15, 42);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(77, 13);
            this.label21.TabIndex = 7;
            this.label21.Text = "Nom Immeuble";
            // 
            // tbNomImmeuble
            // 
            this.tbNomImmeuble.Enabled = false;
            this.tbNomImmeuble.Location = new System.Drawing.Point(95, 39);
            this.tbNomImmeuble.Name = "tbNomImmeuble";
            this.tbNomImmeuble.ReadOnly = true;
            this.tbNomImmeuble.Size = new System.Drawing.Size(205, 20);
            this.tbNomImmeuble.TabIndex = 8;
            // 
            // tbNomLocataire
            // 
            this.tbNomLocataire.Enabled = false;
            this.tbNomLocataire.Location = new System.Drawing.Point(470, 39);
            this.tbNomLocataire.Name = "tbNomLocataire";
            this.tbNomLocataire.ReadOnly = true;
            this.tbNomLocataire.Size = new System.Drawing.Size(268, 20);
            this.tbNomLocataire.TabIndex = 11;
            // 
            // tbNomProprio
            // 
            this.tbNomProprio.Enabled = false;
            this.tbNomProprio.Location = new System.Drawing.Point(470, 13);
            this.tbNomProprio.Name = "tbNomProprio";
            this.tbNomProprio.ReadOnly = true;
            this.tbNomProprio.Size = new System.Drawing.Size(268, 20);
            this.tbNomProprio.TabIndex = 6;
            // 
            // tbRefLocataire
            // 
            this.tbRefLocataire.Location = new System.Drawing.Point(382, 39);
            this.tbRefLocataire.Name = "tbRefLocataire";
            this.tbRefLocataire.Size = new System.Drawing.Size(65, 20);
            this.tbRefLocataire.TabIndex = 10;
            this.tbRefLocataire.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbCommon_KeyDown);
            this.tbRefLocataire.Validating += new System.ComponentModel.CancelEventHandler(this.tbRefLocataire_Validating);
            // 
            // lblLocataire
            // 
            this.lblLocataire.AutoSize = true;
            this.lblLocataire.ForeColor = System.Drawing.Color.Blue;
            this.lblLocataire.Location = new System.Drawing.Point(313, 42);
            this.lblLocataire.Name = "lblLocataire";
            this.lblLocataire.Size = new System.Drawing.Size(51, 13);
            this.lblLocataire.TabIndex = 9;
            this.lblLocataire.Text = "&Locataire";
            this.lblLocataire.Click += new System.EventHandler(this.lblLocataire_Click);
            // 
            // tbRefProprio
            // 
            this.tbRefProprio.Enabled = false;
            this.tbRefProprio.Location = new System.Drawing.Point(382, 13);
            this.tbRefProprio.Name = "tbRefProprio";
            this.tbRefProprio.ReadOnly = true;
            this.tbRefProprio.Size = new System.Drawing.Size(65, 20);
            this.tbRefProprio.TabIndex = 5;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(313, 16);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(60, 13);
            this.label19.TabIndex = 4;
            this.label19.Text = "Propriétaire";
            // 
            // tbNumLot
            // 
            this.tbNumLot.Location = new System.Drawing.Point(235, 13);
            this.tbNumLot.Name = "tbNumLot";
            this.tbNumLot.Size = new System.Drawing.Size(65, 20);
            this.tbNumLot.TabIndex = 3;
            this.tbNumLot.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbCommon_KeyDown);
            this.tbNumLot.Validating += new System.ComponentModel.CancelEventHandler(this.tbNumLot_Validating);
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.ForeColor = System.Drawing.Color.Blue;
            this.label18.Location = new System.Drawing.Point(184, 16);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(22, 13);
            this.label18.TabIndex = 2;
            this.label18.Text = "Lot";
            this.label18.Click += new System.EventHandler(this.lblLot_Click);
            // 
            // lblImmeuble
            // 
            this.lblImmeuble.AutoSize = true;
            this.lblImmeuble.ForeColor = System.Drawing.Color.Blue;
            this.lblImmeuble.Location = new System.Drawing.Point(15, 16);
            this.lblImmeuble.Name = "lblImmeuble";
            this.lblImmeuble.Size = new System.Drawing.Size(52, 13);
            this.lblImmeuble.TabIndex = 0;
            this.lblImmeuble.Text = "&Immeuble";
            this.lblImmeuble.Click += new System.EventHandler(this.lblImmeuble_Click);
            // 
            // tbRefImmeuble
            // 
            this.tbRefImmeuble.Location = new System.Drawing.Point(95, 13);
            this.tbRefImmeuble.Name = "tbRefImmeuble";
            this.tbRefImmeuble.Size = new System.Drawing.Size(65, 20);
            this.tbRefImmeuble.TabIndex = 1;
            this.tbRefImmeuble.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbCommon_KeyDown);
            this.tbRefImmeuble.Validating += new System.ComponentModel.CancelEventHandler(this.tbRefImmeuble_Validating);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label30);
            this.groupBox2.Controls.Add(this.tbEtatLieux);
            this.groupBox2.Controls.Add(this.dtQuittance);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.tbHonoLoc);
            this.groupBox2.Controls.Add(this.tbHdrQuittance);
            this.groupBox2.Controls.Add(this.label26);
            this.groupBox2.Controls.Add(this.tbFraisBail);
            this.groupBox2.Controls.Add(this.label25);
            this.groupBox2.Controls.Add(this.tbCharges);
            this.groupBox2.Controls.Add(this.label15);
            this.groupBox2.Controls.Add(this.tbMontant5);
            this.groupBox2.Controls.Add(this.lblPresta5);
            this.groupBox2.Controls.Add(this.tbPresta5);
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Controls.Add(this.tbMontant4);
            this.groupBox2.Controls.Add(this.lblPresta4);
            this.groupBox2.Controls.Add(this.tbPresta4);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.tbMontant3);
            this.groupBox2.Controls.Add(this.lblPresta3);
            this.groupBox2.Controls.Add(this.tbPresta3);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.tbMontant2);
            this.groupBox2.Controls.Add(this.lblPresta2);
            this.groupBox2.Controls.Add(this.tbPresta2);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.tbMontant1);
            this.groupBox2.Controls.Add(this.lblPresta1);
            this.groupBox2.Controls.Add(this.tbPresta1);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.tbTVA);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.tbAugment);
            this.groupBox2.Controls.Add(this.label17);
            this.groupBox2.Controls.Add(this.tbLoyer);
            this.groupBox2.ForeColor = System.Drawing.Color.Blue;
            this.groupBox2.Location = new System.Drawing.Point(10, 86);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(760, 233);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Prestations Diverses";
            // 
            // dtQuittance
            // 
            this.dtQuittance.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtQuittance.Location = new System.Drawing.Point(89, 44);
            this.dtQuittance.Name = "dtQuittance";
            this.dtQuittance.Size = new System.Drawing.Size(86, 20);
            this.dtQuittance.TabIndex = 2;
            this.dtQuittance.ValueChanged += new System.EventHandler(this.dtQuittance_ValueChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(9, 46);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(82, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "Date &Quittance:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.label1.Location = new System.Drawing.Point(9, 203);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 13);
            this.label1.TabIndex = 33;
            this.label1.Text = "&Hono Loc.";
            // 
            // tbHonoLoc
            // 
            this.tbHonoLoc.Location = new System.Drawing.Point(89, 200);
            this.tbHonoLoc.Name = "tbHonoLoc";
            this.tbHonoLoc.Size = new System.Drawing.Size(65, 20);
            this.tbHonoLoc.TabIndex = 34;
            // 
            // tbHdrQuittance
            // 
            this.tbHdrQuittance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.tbHdrQuittance.Location = new System.Drawing.Point(12, 19);
            this.tbHdrQuittance.Name = "tbHdrQuittance";
            this.tbHdrQuittance.ReadOnly = true;
            this.tbHdrQuittance.Size = new System.Drawing.Size(729, 20);
            this.tbHdrQuittance.TabIndex = 0;
            this.tbHdrQuittance.Text = "Quittance";
            this.tbHdrQuittance.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.label26.Location = new System.Drawing.Point(9, 176);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(55, 13);
            this.label26.TabIndex = 8;
            this.label26.Text = "&Frais adm.";
            // 
            // tbFraisBail
            // 
            this.tbFraisBail.Location = new System.Drawing.Point(89, 173);
            this.tbFraisBail.Name = "tbFraisBail";
            this.tbFraisBail.Size = new System.Drawing.Size(65, 20);
            this.tbFraisBail.TabIndex = 9;
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.label25.Location = new System.Drawing.Point(9, 150);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(46, 13);
            this.label25.TabIndex = 6;
            this.label25.Text = "&Charges";
            // 
            // tbCharges
            // 
            this.tbCharges.Location = new System.Drawing.Point(89, 147);
            this.tbCharges.Name = "tbCharges";
            this.tbCharges.Size = new System.Drawing.Size(65, 20);
            this.tbCharges.TabIndex = 7;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(613, 176);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(46, 13);
            this.label15.TabIndex = 30;
            this.label15.Text = "Montant";
            // 
            // tbMontant5
            // 
            this.tbMontant5.Location = new System.Drawing.Point(676, 173);
            this.tbMontant5.Name = "tbMontant5";
            this.tbMontant5.Size = new System.Drawing.Size(65, 20);
            this.tbMontant5.TabIndex = 31;
            // 
            // lblPresta5
            // 
            this.lblPresta5.AutoSize = true;
            this.lblPresta5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPresta5.Location = new System.Drawing.Point(214, 176);
            this.lblPresta5.Name = "lblPresta5";
            this.lblPresta5.Size = new System.Drawing.Size(103, 13);
            this.lblPresta5.TabIndex = 28;
            this.lblPresta5.Text = "Prestations Diverses";
            this.lblPresta5.Click += new System.EventHandler(this.lblPresta5_Click);
            // 
            // tbPresta5
            // 
            this.tbPresta5.Location = new System.Drawing.Point(327, 173);
            this.tbPresta5.Name = "tbPresta5";
            this.tbPresta5.Size = new System.Drawing.Size(268, 20);
            this.tbPresta5.TabIndex = 29;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(613, 150);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(46, 13);
            this.label13.TabIndex = 26;
            this.label13.Text = "Montant";
            // 
            // tbMontant4
            // 
            this.tbMontant4.Location = new System.Drawing.Point(676, 147);
            this.tbMontant4.Name = "tbMontant4";
            this.tbMontant4.Size = new System.Drawing.Size(65, 20);
            this.tbMontant4.TabIndex = 27;
            // 
            // lblPresta4
            // 
            this.lblPresta4.AutoSize = true;
            this.lblPresta4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPresta4.ForeColor = System.Drawing.Color.Blue;
            this.lblPresta4.Location = new System.Drawing.Point(214, 150);
            this.lblPresta4.Name = "lblPresta4";
            this.lblPresta4.Size = new System.Drawing.Size(103, 13);
            this.lblPresta4.TabIndex = 24;
            this.lblPresta4.Text = "Prestations Diverses";
            this.lblPresta4.Click += new System.EventHandler(this.lblPresta5_Click);
            // 
            // tbPresta4
            // 
            this.tbPresta4.Location = new System.Drawing.Point(327, 147);
            this.tbPresta4.Name = "tbPresta4";
            this.tbPresta4.Size = new System.Drawing.Size(268, 20);
            this.tbPresta4.TabIndex = 25;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(613, 124);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(46, 13);
            this.label11.TabIndex = 22;
            this.label11.Text = "Montant";
            // 
            // tbMontant3
            // 
            this.tbMontant3.Location = new System.Drawing.Point(676, 121);
            this.tbMontant3.Name = "tbMontant3";
            this.tbMontant3.Size = new System.Drawing.Size(65, 20);
            this.tbMontant3.TabIndex = 23;
            // 
            // lblPresta3
            // 
            this.lblPresta3.AutoSize = true;
            this.lblPresta3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPresta3.ForeColor = System.Drawing.Color.Blue;
            this.lblPresta3.Location = new System.Drawing.Point(214, 124);
            this.lblPresta3.Name = "lblPresta3";
            this.lblPresta3.Size = new System.Drawing.Size(103, 13);
            this.lblPresta3.TabIndex = 20;
            this.lblPresta3.Text = "Prestations Diverses";
            this.lblPresta3.Click += new System.EventHandler(this.lblPresta5_Click);
            // 
            // tbPresta3
            // 
            this.tbPresta3.Location = new System.Drawing.Point(327, 121);
            this.tbPresta3.Name = "tbPresta3";
            this.tbPresta3.Size = new System.Drawing.Size(268, 20);
            this.tbPresta3.TabIndex = 21;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(613, 98);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(46, 13);
            this.label9.TabIndex = 18;
            this.label9.Text = "Montant";
            // 
            // tbMontant2
            // 
            this.tbMontant2.Location = new System.Drawing.Point(676, 95);
            this.tbMontant2.Name = "tbMontant2";
            this.tbMontant2.Size = new System.Drawing.Size(65, 20);
            this.tbMontant2.TabIndex = 19;
            // 
            // lblPresta2
            // 
            this.lblPresta2.AutoSize = true;
            this.lblPresta2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPresta2.ForeColor = System.Drawing.Color.Blue;
            this.lblPresta2.Location = new System.Drawing.Point(214, 98);
            this.lblPresta2.Name = "lblPresta2";
            this.lblPresta2.Size = new System.Drawing.Size(103, 13);
            this.lblPresta2.TabIndex = 16;
            this.lblPresta2.Text = "Prestations Diverses";
            this.lblPresta2.Click += new System.EventHandler(this.lblPresta5_Click);
            // 
            // tbPresta2
            // 
            this.tbPresta2.Location = new System.Drawing.Point(327, 95);
            this.tbPresta2.Name = "tbPresta2";
            this.tbPresta2.Size = new System.Drawing.Size(268, 20);
            this.tbPresta2.TabIndex = 17;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(613, 72);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(46, 13);
            this.label8.TabIndex = 14;
            this.label8.Text = "Montant";
            // 
            // tbMontant1
            // 
            this.tbMontant1.Location = new System.Drawing.Point(676, 69);
            this.tbMontant1.Name = "tbMontant1";
            this.tbMontant1.Size = new System.Drawing.Size(65, 20);
            this.tbMontant1.TabIndex = 15;
            // 
            // lblPresta1
            // 
            this.lblPresta1.AutoSize = true;
            this.lblPresta1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPresta1.ForeColor = System.Drawing.Color.Blue;
            this.lblPresta1.Location = new System.Drawing.Point(214, 72);
            this.lblPresta1.Name = "lblPresta1";
            this.lblPresta1.Size = new System.Drawing.Size(103, 13);
            this.lblPresta1.TabIndex = 12;
            this.lblPresta1.Text = "Prestations Diverses";
            this.lblPresta1.Click += new System.EventHandler(this.lblPresta5_Click);
            // 
            // tbPresta1
            // 
            this.tbPresta1.Location = new System.Drawing.Point(327, 69);
            this.tbPresta1.Name = "tbPresta1";
            this.tbPresta1.Size = new System.Drawing.Size(268, 20);
            this.tbPresta1.TabIndex = 13;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.label6.Location = new System.Drawing.Point(9, 124);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(28, 13);
            this.label6.TabIndex = 4;
            this.label6.Text = "&TVA";
            // 
            // tbTVA
            // 
            this.tbTVA.Location = new System.Drawing.Point(89, 121);
            this.tbTVA.Name = "tbTVA";
            this.tbTVA.ReadOnly = true;
            this.tbTVA.Size = new System.Drawing.Size(65, 20);
            this.tbTVA.TabIndex = 5;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.label5.Location = new System.Drawing.Point(9, 98);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(72, 13);
            this.label5.TabIndex = 2;
            this.label5.Text = "&Augmentation";
            // 
            // tbAugment
            // 
            this.tbAugment.Location = new System.Drawing.Point(89, 95);
            this.tbAugment.Name = "tbAugment";
            this.tbAugment.Size = new System.Drawing.Size(65, 20);
            this.tbAugment.TabIndex = 3;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.label17.Location = new System.Drawing.Point(9, 72);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(33, 13);
            this.label17.TabIndex = 3;
            this.label17.Text = "&Loyer";
            // 
            // tbLoyer
            // 
            this.tbLoyer.Location = new System.Drawing.Point(89, 69);
            this.tbLoyer.Name = "tbLoyer";
            this.tbLoyer.Size = new System.Drawing.Size(65, 20);
            this.tbLoyer.TabIndex = 4;
            this.tbLoyer.Validating += new System.ComponentModel.CancelEventHandler(this.tbLoyer_Validating);
            // 
            // btnDelete
            // 
            this.btnDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnDelete.ImageKey = "stop.png";
            this.btnDelete.ImageList = this.imageList1;
            this.btnDelete.Location = new System.Drawing.Point(376, 5);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(80, 25);
            this.btnDelete.TabIndex = 117;
            this.btnDelete.Text = "&Annuler";
            this.btnDelete.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.ForeColor = System.Drawing.Color.Black;
            this.label30.Location = new System.Drawing.Point(214, 203);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(54, 13);
            this.label30.TabIndex = 35;
            this.label30.Text = "&Etat Lieux";
            // 
            // tbEtatLieux
            // 
            this.tbEtatLieux.Location = new System.Drawing.Point(327, 200);
            this.tbEtatLieux.Name = "tbEtatLieux";
            this.tbEtatLieux.Size = new System.Drawing.Size(65, 20);
            this.tbEtatLieux.TabIndex = 36;
            // 
            // AnnulationQuittanceForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(782, 376);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.gbHdr);
            this.Name = "AnnulationQuittanceForm";
            this.Text = "Modification/Annulation Quittance";
            this.Load += new System.EventHandler(this.AnnulationQuittanceForm_Load);
            this.Controls.SetChildIndex(this.gbHdr, 0);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.groupBox2, 0);
            this.panel1.ResumeLayout(false);
            this.gbHdr.ResumeLayout(false);
            this.gbHdr.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbHdr;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.TextBox tbNomImmeuble;
        private System.Windows.Forms.TextBox tbNomLocataire;
        private System.Windows.Forms.TextBox tbNomProprio;
        private System.Windows.Forms.TextBox tbRefLocataire;
        private System.Windows.Forms.Label lblLocataire;
        private System.Windows.Forms.TextBox tbRefProprio;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.TextBox tbNumLot;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label lblImmeuble;
        private System.Windows.Forms.TextBox tbRefImmeuble;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.TextBox tbFraisBail;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.TextBox tbCharges;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox tbMontant5;
        private System.Windows.Forms.Label lblPresta5;
        private System.Windows.Forms.TextBox tbPresta5;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox tbMontant4;
        private System.Windows.Forms.Label lblPresta4;
        private System.Windows.Forms.TextBox tbPresta4;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox tbMontant3;
        private System.Windows.Forms.Label lblPresta3;
        private System.Windows.Forms.TextBox tbPresta3;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox tbMontant2;
        private System.Windows.Forms.Label lblPresta2;
        private System.Windows.Forms.TextBox tbPresta2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox tbMontant1;
        private System.Windows.Forms.Label lblPresta1;
        private System.Windows.Forms.TextBox tbPresta1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tbTVA;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbAugment;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox tbLoyer;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.TextBox tbHdrQuittance;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbHonoLoc;
        private System.Windows.Forms.DateTimePicker dtQuittance;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.TextBox tbEtatLieux;
    }
}
