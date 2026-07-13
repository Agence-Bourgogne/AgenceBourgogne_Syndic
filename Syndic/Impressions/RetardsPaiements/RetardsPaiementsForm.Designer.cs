using System.ComponentModel;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;

namespace EspaceSyndic.Impressions.RetardsPaiements
{
    partial class RetardsPaiementsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RetardsPaiementsForm));
            this.gbFactures = new System.Windows.Forms.GroupBox();
            //this.ckAll = new System.Windows.Forms.CheckBox();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.relance = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.effacerLaRelanceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nePasRelancerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.générer1ereRelanceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.générer2ndeRelnceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.envoyerMiseEnDemeureToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reportViewer2 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnGrid = new System.Windows.Forms.Button();
            this.btnList = new System.Windows.Forms.Button();
            this.btnRelance = new System.Windows.Forms.Button();
            this.btnQuit = new System.Windows.Forms.Button();
            this.btnEnter = new System.Windows.Forms.Button();
            this.btnExport = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.ckActif = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cbFiltre = new System.Windows.Forms.ComboBox();
            this.lblRel3 = new System.Windows.Forms.Label();
            this.lblRel2 = new System.Windows.Forms.Label();
            this.lblRel1 = new System.Windows.Forms.Label();
            this.tbSeuil = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dtEdition = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.tbRefImmeuble = new System.Windows.Forms.TextBox();
            this.lblImmeuble = new System.Windows.Forms.Label();
            this.gbFactures.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbFactures
            // 
            this.gbFactures.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            //this.gbFactures.Controls.Add(this.ckAll);
            this.gbFactures.Controls.Add(this.dataGridView);
            this.gbFactures.Controls.Add(this.reportViewer2);
            this.gbFactures.Controls.Add(this.reportViewer1);
            this.gbFactures.Location = new System.Drawing.Point(12, 104);
            this.gbFactures.Name = "gbFactures";
            this.gbFactures.Size = new System.Drawing.Size(778, 518);
            this.gbFactures.TabIndex = 19;
            this.gbFactures.TabStop = false;
            this.gbFactures.Text = "Etat Comptes Coproprietaires";
            // 
            // ckAll
            // 
            //this.ckAll.AutoSize = true;
            //this.ckAll.Location = new System.Drawing.Point(14, 521);
            //this.ckAll.Name = "ckAll";
            //this.ckAll.Size = new System.Drawing.Size(85, 17);
            //this.ckAll.TabIndex = 3;
            //this.ckAll.Text = "Tout Cocher";
            //this.ckAll.UseVisualStyleBackColor = true;
            //this.ckAll.CheckedChanged += new System.EventHandler(this.ckAll_CheckedChanged);
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
            this.dataGridView.BackgroundColor = System.Drawing.Color.Snow;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.relance});
            this.dataGridView.ContextMenuStrip = this.contextMenuStrip1;
            this.dataGridView.Location = new System.Drawing.Point(14, 19);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.ReadOnly = true;
            this.dataGridView.RowHeadersVisible = false;
            this.dataGridView.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView.ShowCellErrors = false;
            this.dataGridView.ShowEditingIcon = false;
            this.dataGridView.ShowRowErrors = false;
            this.dataGridView.Size = new System.Drawing.Size(750, 473);
            this.dataGridView.TabIndex = 0;
            this.dataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_CellContentClick);
            this.dataGridView.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dataGridView_CellFormatting);
            this.dataGridView.DoubleClick += new System.EventHandler(this.dataGridView_DoubleClick);
            // 
            // relance
            // 
            this.relance.HeaderText = "Relance";
            this.relance.Name = "relance";
            this.relance.ReadOnly = true;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.effacerLaRelanceToolStripMenuItem,
            this.nePasRelancerToolStripMenuItem,
            this.générer1ereRelanceToolStripMenuItem,
            this.générer2ndeRelnceToolStripMenuItem,
            this.envoyerMiseEnDemeureToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(200, 114);
            // 
            // effacerLaRelanceToolStripMenuItem
            // 
            this.effacerLaRelanceToolStripMenuItem.Name = "effacerLaRelanceToolStripMenuItem";
            this.effacerLaRelanceToolStripMenuItem.Size = new System.Drawing.Size(199, 22);
            this.effacerLaRelanceToolStripMenuItem.Text = "Effacer Dates de  relance";
            this.effacerLaRelanceToolStripMenuItem.Click += new System.EventHandler(this.effacerLaRelanceToolStripMenuItem_Click);
            // 
            // nePasRelancerToolStripMenuItem
            // 
            this.nePasRelancerToolStripMenuItem.Name = "nePasRelancerToolStripMenuItem";
            this.nePasRelancerToolStripMenuItem.Size = new System.Drawing.Size(199, 22);
            this.nePasRelancerToolStripMenuItem.Text = "Ne Pas Relancer";
            this.nePasRelancerToolStripMenuItem.Click += new System.EventHandler(this.nePasRelancerToolStripMenuItem_Click);
            // 
            // générer1ereRelanceToolStripMenuItem
            // 
            this.générer1ereRelanceToolStripMenuItem.Name = "générer1ereRelanceToolStripMenuItem";
            this.générer1ereRelanceToolStripMenuItem.Size = new System.Drawing.Size(199, 22);
            this.générer1ereRelanceToolStripMenuItem.Text = "Générer 1ere Relance";
            this.générer1ereRelanceToolStripMenuItem.Click += new System.EventHandler(this.générer1ereRelanceToolStripMenuItem_Click);
            // 
            // générer2ndeRelnceToolStripMenuItem
            // 
            this.générer2ndeRelnceToolStripMenuItem.Name = "générer2ndeRelnceToolStripMenuItem";
            this.générer2ndeRelnceToolStripMenuItem.Size = new System.Drawing.Size(199, 22);
            this.générer2ndeRelnceToolStripMenuItem.Text = "Générer 2nde Relance";
            this.générer2ndeRelnceToolStripMenuItem.Click += new System.EventHandler(this.générer2ndeRelnceToolStripMenuItem_Click);
            // 
            // envoyerMiseEnDemeureToolStripMenuItem
            // 
            this.envoyerMiseEnDemeureToolStripMenuItem.Name = "envoyerMiseEnDemeureToolStripMenuItem";
            this.envoyerMiseEnDemeureToolStripMenuItem.Size = new System.Drawing.Size(199, 22);
            this.envoyerMiseEnDemeureToolStripMenuItem.Text = "Envoyer Mise en Demeure";
            this.envoyerMiseEnDemeureToolStripMenuItem.Click += new System.EventHandler(this.envoyerMiseEnDemeureToolStripMenuItem_Click);
            // 
            // reportViewer2
            // 
            this.reportViewer2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.reportViewer2.Location = new System.Drawing.Point(14, 19);
            this.reportViewer2.Name = "reportViewer2";
            this.reportViewer2.Size = new System.Drawing.Size(749, 473);
            this.reportViewer2.TabIndex = 2;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "EspaceSyndic.Impressions.RetardsPaiements.RetardPaiementReport.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(14, 19);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(749, 473);
            this.reportViewer1.TabIndex = 1;
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
            this.imageList1.Images.SetKeyName(8, "excel.png");
            this.imageList1.Images.SetKeyName(9, "word.png");
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.btnGrid);
            this.panel1.Controls.Add(this.btnList);
            this.panel1.Controls.Add(this.btnRelance);
            this.panel1.Controls.Add(this.btnQuit);
            this.panel1.Controls.Add(this.btnEnter);
            this.panel1.Controls.Add(this.btnExport);
            this.panel1.Location = new System.Drawing.Point(12, 640);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(778, 39);
            this.panel1.TabIndex = 20;
            // 
            // btnGrid
            // 
            this.btnGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGrid.CausesValidation = false;
            this.btnGrid.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnGrid.ImageIndex = 7;
            this.btnGrid.ImageList = this.imageList1;
            this.btnGrid.Location = new System.Drawing.Point(267, 6);
            this.btnGrid.Name = "btnGrid";
            this.btnGrid.Size = new System.Drawing.Size(100, 25);
            this.btnGrid.TabIndex = 13;
            this.btnGrid.TabStop = false;
            this.btnGrid.Text = "&Afficher Liste";
            this.btnGrid.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGrid.UseVisualStyleBackColor = true;
            this.btnGrid.Click += new System.EventHandler(this.btnGrid_Click);
            // 
            // btnList
            // 
            this.btnList.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnList.CausesValidation = false;
            this.btnList.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnList.ImageIndex = 6;
            this.btnList.ImageList = this.imageList1;
            this.btnList.Location = new System.Drawing.Point(11, 6);
            this.btnList.Name = "btnList";
            this.btnList.Size = new System.Drawing.Size(120, 25);
            this.btnList.TabIndex = 10;
            this.btnList.Text = "Imprimer la &Liste";
            this.btnList.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnList.UseVisualStyleBackColor = true;
            this.btnList.Click += new System.EventHandler(this.btnList_Click);
            // 
            // btnRelance
            // 
            this.btnRelance.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnRelance.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnRelance.ImageIndex = 9;
            this.btnRelance.ImageList = this.imageList1;
            this.btnRelance.Location = new System.Drawing.Point(140, 6);
            this.btnRelance.Name = "btnRelance";
            this.btnRelance.Size = new System.Drawing.Size(120, 25);
            this.btnRelance.TabIndex = 11;
            this.btnRelance.Text = "Générer &Relances";
            this.btnRelance.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRelance.UseVisualStyleBackColor = true;
            this.btnRelance.Click += new System.EventHandler(this.btnRelance_Click);
            // 
            // btnQuit
            // 
            this.btnQuit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnQuit.CausesValidation = false;
            this.btnQuit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnQuit.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnQuit.ImageIndex = 5;
            this.btnQuit.ImageList = this.imageList1;
            this.btnQuit.Location = new System.Drawing.Point(662, 6);
            this.btnQuit.Name = "btnQuit";
            this.btnQuit.Size = new System.Drawing.Size(100, 25);
            this.btnQuit.TabIndex = 9;
            this.btnQuit.TabStop = false;
            this.btnQuit.Text = "&Quitter";
            this.btnQuit.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnQuit.UseVisualStyleBackColor = true;
            // 
            // btnEnter
            // 
            this.btnEnter.Location = new System.Drawing.Point(529, 7);
            this.btnEnter.Name = "btnEnter";
            this.btnEnter.Size = new System.Drawing.Size(75, 23);
            this.btnEnter.TabIndex = 12;
            this.btnEnter.Text = "button1";
            this.btnEnter.UseVisualStyleBackColor = true;
            this.btnEnter.Click += new System.EventHandler(this.btnEnter_Click);
            // 
            // btnExport
            // 
            this.btnExport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnExport.CausesValidation = false;
            this.btnExport.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnExport.ImageIndex = 8;
            this.btnExport.ImageList = this.imageList1;
            this.btnExport.Location = new System.Drawing.Point(372, 6);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(100, 25);
            this.btnExport.TabIndex = 15;
            this.btnExport.TabStop = false;
            this.btnExport.Text = "E&xporter";
            this.btnExport.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.ckActif);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.cbFiltre);
            this.groupBox3.Controls.Add(this.lblRel3);
            this.groupBox3.Controls.Add(this.lblRel2);
            this.groupBox3.Controls.Add(this.lblRel1);
            this.groupBox3.Controls.Add(this.tbSeuil);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.dtEdition);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.tbRefImmeuble);
            this.groupBox3.Controls.Add(this.lblImmeuble);
            this.groupBox3.Location = new System.Drawing.Point(12, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(778, 77);
            this.groupBox3.TabIndex = 0;
            this.groupBox3.TabStop = false;
            // 
            // ckActif
            // 
            this.ckActif.AutoSize = true;
            this.ckActif.Checked = true;
            this.ckActif.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ckActif.Location = new System.Drawing.Point(618, 49);
            this.ckActif.Name = "ckActif";
            this.ckActif.Size = new System.Drawing.Size(112, 17);
            this.ckActif.TabIndex = 11;
            this.ckActif.Text = "Actifs Uniquement";
            this.ckActif.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "&Filtre";
            // 
            // cbFiltre
            // 
            this.cbFiltre.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFiltre.FormattingEnabled = true;
            this.cbFiltre.Items.AddRange(new object[] {
            "Tous",
            "1ere Relance",
            "2nd Relance",
            "Mise en Demeure"});
            this.cbFiltre.Location = new System.Drawing.Point(87, 45);
            this.cbFiltre.Name = "cbFiltre";
            this.cbFiltre.Size = new System.Drawing.Size(195, 21);
            this.cbFiltre.TabIndex = 10;
            this.cbFiltre.SelectedIndexChanged += new System.EventHandler(this.cbFiltre_SelectedIndexChanged);
            // 
            // lblRel3
            // 
            this.lblRel3.AutoSize = true;
            this.lblRel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.lblRel3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblRel3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblRel3.Location = new System.Drawing.Point(456, 22);
            this.lblRel3.Name = "lblRel3";
            this.lblRel3.Size = new System.Drawing.Size(92, 15);
            this.lblRel3.TabIndex = 6;
            this.lblRel3.Text = "Mise en Demeure";
            // 
            // lblRel2
            // 
            this.lblRel2.AutoSize = true;
            this.lblRel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.lblRel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblRel2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblRel2.Location = new System.Drawing.Point(380, 22);
            this.lblRel2.Name = "lblRel2";
            this.lblRel2.Size = new System.Drawing.Size(70, 15);
            this.lblRel2.TabIndex = 5;
            this.lblRel2.Text = "2nd Relance";
            // 
            // lblRel1
            // 
            this.lblRel1.AutoSize = true;
            this.lblRel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.lblRel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblRel1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblRel1.Location = new System.Drawing.Point(299, 22);
            this.lblRel1.Name = "lblRel1";
            this.lblRel1.Size = new System.Drawing.Size(73, 15);
            this.lblRel1.TabIndex = 4;
            this.lblRel1.Text = "1ere Relance";
            // 
            // tbSeuil
            // 
            this.tbSeuil.Location = new System.Drawing.Point(211, 19);
            this.tbSeuil.Name = "tbSeuil";
            this.tbSeuil.Size = new System.Drawing.Size(71, 20);
            this.tbSeuil.TabIndex = 3;
            this.tbSeuil.Text = "150";
            this.tbSeuil.Validating += new System.ComponentModel.CancelEventHandler(this.tbSeuil_Validating);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(172, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "&Seuil:";
            // 
            // dtEdition
            // 
            this.dtEdition.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtEdition.Location = new System.Drawing.Point(660, 19);
            this.dtEdition.Name = "dtEdition";
            this.dtEdition.Size = new System.Drawing.Size(85, 20);
            this.dtEdition.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(615, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(39, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "&Edition";
            // 
            // tbRefImmeuble
            // 
            this.tbRefImmeuble.Location = new System.Drawing.Point(87, 19);
            this.tbRefImmeuble.Name = "tbRefImmeuble";
            this.tbRefImmeuble.Size = new System.Drawing.Size(71, 20);
            this.tbRefImmeuble.TabIndex = 1;
            this.tbRefImmeuble.DoubleClick += new System.EventHandler(this.tbRefImmeuble_DoubleClick);
            this.tbRefImmeuble.Validating += new System.ComponentModel.CancelEventHandler(this.tbRefImmeuble_Validating);
            // 
            // lblImmeuble
            // 
            this.lblImmeuble.AutoSize = true;
            this.lblImmeuble.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblImmeuble.ForeColor = System.Drawing.Color.Blue;
            this.lblImmeuble.Location = new System.Drawing.Point(11, 22);
            this.lblImmeuble.Name = "lblImmeuble";
            this.lblImmeuble.Size = new System.Drawing.Size(55, 13);
            this.lblImmeuble.TabIndex = 0;
            this.lblImmeuble.Text = "&Immeuble:";
            this.lblImmeuble.Click += new System.EventHandler(this.tbRefImmeuble_DoubleClick);
            // 
            // RetardsPaiementsForm
            // 
            this.AcceptButton = this.btnEnter;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnQuit;
            this.ClientSize = new System.Drawing.Size(802, 691);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.gbFactures);
            this.Name = "RetardsPaiementsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Retards Paiements";
            this.Load += new System.EventHandler(this.RetardsPaiementsForm_Load);
            this.gbFactures.ResumeLayout(false);
            this.gbFactures.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private GroupBox gbFactures;
        private DataGridView dataGridView;
        private ImageList imageList1;
        private Panel panel1;
        private Button btnList;
        private Button btnRelance;
        private Button btnQuit;
        protected GroupBox groupBox3;
        protected TextBox tbSeuil;
        protected Label label1;
        private DateTimePicker dtEdition;
        private Label label3;
        protected TextBox tbRefImmeuble;
        protected Label lblImmeuble;
        private DataGridViewCheckBoxColumn relance;
        private ReportViewer reportViewer1;
        private ReportViewer reportViewer2;
        private Button btnEnter;
        private Button btnGrid;
        private Button btnExport;
        //private System.Windows.Forms.CheckBox ckAll;
        private Label lblRel3;
        private Label lblRel2;
        private Label lblRel1;
        private ContextMenuStrip contextMenuStrip1;
        private ToolStripMenuItem nePasRelancerToolStripMenuItem;
        private ToolStripMenuItem générer1ereRelanceToolStripMenuItem;
        private ToolStripMenuItem générer2ndeRelnceToolStripMenuItem;
        private ToolStripMenuItem envoyerMiseEnDemeureToolStripMenuItem;
        private Label label2;
        private ComboBox cbFiltre;
        private ToolStripMenuItem effacerLaRelanceToolStripMenuItem;
        private CheckBox ckActif;
    }
}