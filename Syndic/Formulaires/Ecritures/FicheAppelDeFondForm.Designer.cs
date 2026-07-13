using System.ComponentModel;
using System.Windows.Forms;

namespace EspaceSyndic.Formulaires.Ecritures
{
    partial class FicheAppelDeFondForm
    {

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
        protected void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FicheAppelDeFondForm));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnDelLiasse = new System.Windows.Forms.Button();
            this.cbLiasse = new System.Windows.Forms.ComboBox();
            this.tbMontantLiasse = new System.Windows.Forms.TextBox();
            this.lblLiasse = new System.Windows.Forms.Label();
            this.tbDiff = new System.Windows.Forms.TextBox();
            this.lblDiff = new System.Windows.Forms.Label();
            this.tbTotal = new System.Windows.Forms.TextBox();
            this.lblTotal = new System.Windows.Forms.Label();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tbLot = new System.Windows.Forms.TextBox();
            this.lblLot = new System.Windows.Forms.Label();
            this.btnNatureAdd = new System.Windows.Forms.Button();
            this.tbComment = new System.Windows.Forms.TextBox();
            this.tbMontant = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.tbLibNature = new System.Windows.Forms.TextBox();
            this.tbBase = new System.Windows.Forms.TextBox();
            this.lblBase = new System.Windows.Forms.Label();
            this.tbNature = new System.Windows.Forms.TextBox();
            this.lblNature = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tbDateCreation = new System.Windows.Forms.MaskedTextBox();
            this.tbRefImmeuble = new System.Windows.Forms.TextBox();
            this.lblImmeuble = new System.Windows.Forms.Label();
            this.Factures = new System.Windows.Forms.GroupBox();
            this.dataGridViewEcriture = new System.Windows.Forms.DataGridView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.RowMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.editerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.supprimerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnDel = new System.Windows.Forms.Button();
            this.btnRepart = new System.Windows.Forms.Button();
            this.btnHelp = new System.Windows.Forms.Button();
            this.btnEnter = new System.Windows.Forms.Button();
            this.btnQuit = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.groupBox3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.Factures.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewEcriture)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.RowMenu.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.btnDelLiasse);
            this.groupBox3.Controls.Add(this.cbLiasse);
            this.groupBox3.Controls.Add(this.tbMontantLiasse);
            this.groupBox3.Controls.Add(this.lblLiasse);
            this.groupBox3.Controls.Add(this.tbDiff);
            this.groupBox3.Controls.Add(this.lblDiff);
            this.groupBox3.Controls.Add(this.tbTotal);
            this.groupBox3.Controls.Add(this.lblTotal);
            this.groupBox3.Location = new System.Drawing.Point(12, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(760, 57);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "&Liasse";
            // 
            // btnDelLiasse
            // 
            this.btnDelLiasse.Location = new System.Drawing.Point(264, 22);
            this.btnDelLiasse.Name = "btnDelLiasse";
            this.btnDelLiasse.Size = new System.Drawing.Size(25, 23);
            this.btnDelLiasse.TabIndex = 8;
            this.btnDelLiasse.Text = "-";
            this.toolTip1.SetToolTip(this.btnDelLiasse, "Supprimer la liasse courant");
            this.btnDelLiasse.UseVisualStyleBackColor = true;
            this.btnDelLiasse.Visible = false;
            this.btnDelLiasse.Click += new System.EventHandler(this.btnDelLiasse_Click);
            // 
            // cbLiasse
            // 
            this.cbLiasse.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbLiasse.Enabled = false;
            this.cbLiasse.FormattingEnabled = true;
            this.cbLiasse.Location = new System.Drawing.Point(14, 22);
            this.cbLiasse.Name = "cbLiasse";
            this.cbLiasse.Size = new System.Drawing.Size(244, 21);
            this.cbLiasse.TabIndex = 1;
            this.cbLiasse.SelectedIndexChanged += new System.EventHandler(this.cbLiasse_SelectedIndexChanged);
            // 
            // tbMontantLiasse
            // 
            this.tbMontantLiasse.Enabled = false;
            this.tbMontantLiasse.Location = new System.Drawing.Point(566, 22);
            this.tbMontantLiasse.Name = "tbMontantLiasse";
            this.tbMontantLiasse.Size = new System.Drawing.Size(52, 20);
            this.tbMontantLiasse.TabIndex = 4;
            // 
            // lblLiasse
            // 
            this.lblLiasse.AutoSize = true;
            this.lblLiasse.Location = new System.Drawing.Point(523, 27);
            this.lblLiasse.Name = "lblLiasse";
            this.lblLiasse.Size = new System.Drawing.Size(37, 13);
            this.lblLiasse.TabIndex = 3;
            this.lblLiasse.Text = "Liasse";
            // 
            // tbDiff
            // 
            this.tbDiff.Enabled = false;
            this.tbDiff.Location = new System.Drawing.Point(689, 22);
            this.tbDiff.Name = "tbDiff";
            this.tbDiff.Size = new System.Drawing.Size(52, 20);
            this.tbDiff.TabIndex = 6;
            // 
            // lblDiff
            // 
            this.lblDiff.AutoSize = true;
            this.lblDiff.Location = new System.Drawing.Point(624, 27);
            this.lblDiff.Name = "lblDiff";
            this.lblDiff.Size = new System.Drawing.Size(59, 13);
            this.lblDiff.TabIndex = 5;
            this.lblDiff.Text = "Différence:";
            // 
            // tbTotal
            // 
            this.tbTotal.Location = new System.Drawing.Point(466, 22);
            this.tbTotal.Name = "tbTotal";
            this.tbTotal.Size = new System.Drawing.Size(52, 20);
            this.tbTotal.TabIndex = 3;
            this.tbTotal.TextChanged += new System.EventHandler(this.tbTotal_TextChanged);
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Location = new System.Drawing.Point(426, 27);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(34, 13);
            this.lblTotal.TabIndex = 2;
            this.lblTotal.Text = "&Total:";
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
            this.imageList1.Images.SetKeyName(8, "stop.png");
            this.imageList1.Images.SetKeyName(9, "edit.png");
            this.imageList1.Images.SetKeyName(10, "bulle.png");
            this.imageList1.Images.SetKeyName(11, "bulle_repart.png");
            this.imageList1.Images.SetKeyName(12, "del.png");
            this.imageList1.Images.SetKeyName(13, "zoom.png");
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.tbLot);
            this.groupBox1.Controls.Add(this.lblLot);
            this.groupBox1.Controls.Add(this.btnNatureAdd);
            this.groupBox1.Controls.Add(this.tbComment);
            this.groupBox1.Controls.Add(this.tbMontant);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.tbLibNature);
            this.groupBox1.Controls.Add(this.tbBase);
            this.groupBox1.Controls.Add(this.lblBase);
            this.groupBox1.Controls.Add(this.tbNature);
            this.groupBox1.Controls.Add(this.lblNature);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.tbDateCreation);
            this.groupBox1.Controls.Add(this.tbRefImmeuble);
            this.groupBox1.Controls.Add(this.lblImmeuble);
            this.groupBox1.Location = new System.Drawing.Point(12, 75);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(760, 83);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // tbLot
            // 
            this.tbLot.Location = new System.Drawing.Point(506, 22);
            this.tbLot.Name = "tbLot";
            this.tbLot.Size = new System.Drawing.Size(61, 20);
            this.tbLot.TabIndex = 7;
            this.tbLot.Visible = false;
            this.tbLot.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbHelpBox_KeyPress);
            this.tbLot.Validating += new System.ComponentModel.CancelEventHandler(this.tbLot_Validating);
            // 
            // lblLot
            // 
            this.lblLot.AutoSize = true;
            this.lblLot.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLot.ForeColor = System.Drawing.Color.Blue;
            this.lblLot.Location = new System.Drawing.Point(475, 25);
            this.lblLot.Name = "lblLot";
            this.lblLot.Size = new System.Drawing.Size(25, 13);
            this.lblLot.TabIndex = 6;
            this.lblLot.Text = "&Lot:";
            this.lblLot.Visible = false;
            this.lblLot.Click += new System.EventHandler(this.lblLot_Click);
            // 
            // btnNatureAdd
            // 
            this.btnNatureAdd.Location = new System.Drawing.Point(152, 47);
            this.btnNatureAdd.Name = "btnNatureAdd";
            this.btnNatureAdd.Size = new System.Drawing.Size(22, 22);
            this.btnNatureAdd.TabIndex = 12;
            this.btnNatureAdd.TabStop = false;
            this.btnNatureAdd.Text = "+";
            this.btnNatureAdd.UseVisualStyleBackColor = true;
            this.btnNatureAdd.Click += new System.EventHandler(this.btnNatureAdd_Click);
            // 
            // tbComment
            // 
            this.tbComment.AccessibleDescription = "";
            this.tbComment.AccessibleName = "";
            this.tbComment.Location = new System.Drawing.Point(472, 48);
            this.tbComment.Name = "tbComment";
            this.tbComment.Size = new System.Drawing.Size(273, 20);
            this.tbComment.TabIndex = 14;
            this.tbComment.KeyUp += new System.Windows.Forms.KeyEventHandler(this.tbComment_KeyPress);
            // 
            // tbMontant
            // 
            this.tbMontant.Location = new System.Drawing.Point(664, 22);
            this.tbMontant.Name = "tbMontant";
            this.tbMontant.Size = new System.Drawing.Size(81, 20);
            this.tbMontant.TabIndex = 9;
            this.tbMontant.TextChanged += new System.EventHandler(this.tbMontantFac_TextChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(601, 25);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(49, 13);
            this.label8.TabIndex = 8;
            this.label8.Text = "&Montant:";
            // 
            // tbLibNature
            // 
            this.tbLibNature.Enabled = false;
            this.tbLibNature.Location = new System.Drawing.Point(186, 49);
            this.tbLibNature.Name = "tbLibNature";
            this.tbLibNature.Size = new System.Drawing.Size(273, 20);
            this.tbLibNature.TabIndex = 13;
            this.tbLibNature.TabStop = false;
            // 
            // tbBase
            // 
            this.tbBase.Location = new System.Drawing.Point(419, 22);
            this.tbBase.Name = "tbBase";
            this.tbBase.Size = new System.Drawing.Size(40, 20);
            this.tbBase.TabIndex = 5;
            this.tbBase.TextChanged += new System.EventHandler(this.tbBase_TextChanged);
            // 
            // lblBase
            // 
            this.lblBase.AutoSize = true;
            this.lblBase.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBase.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblBase.Location = new System.Drawing.Point(379, 25);
            this.lblBase.Name = "lblBase";
            this.lblBase.Size = new System.Drawing.Size(34, 13);
            this.lblBase.TabIndex = 4;
            this.lblBase.Text = "&Base:";
            // 
            // tbNature
            // 
            this.tbNature.Location = new System.Drawing.Point(86, 48);
            this.tbNature.Name = "tbNature";
            this.tbNature.Size = new System.Drawing.Size(65, 20);
            this.tbNature.TabIndex = 11;
            this.tbNature.DoubleClick += new System.EventHandler(this.lblNature_Click);
            this.tbNature.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbHelpBox_KeyPress);
            this.tbNature.Validating += new System.ComponentModel.CancelEventHandler(this.tbNature_Validating);
            // 
            // lblNature
            // 
            this.lblNature.AutoSize = true;
            this.lblNature.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNature.ForeColor = System.Drawing.Color.Blue;
            this.lblNature.Location = new System.Drawing.Point(10, 51);
            this.lblNature.Name = "lblNature";
            this.lblNature.Size = new System.Drawing.Size(42, 13);
            this.lblNature.TabIndex = 10;
            this.lblNature.Text = "&Nature:";
            this.lblNature.Click += new System.EventHandler(this.lblNature_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(183, 25);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "&Date Création:";
            // 
            // tbDateCreation
            // 
            this.tbDateCreation.Location = new System.Drawing.Point(261, 22);
            this.tbDateCreation.Mask = "00/00/0000";
            this.tbDateCreation.Name = "tbDateCreation";
            this.tbDateCreation.Size = new System.Drawing.Size(81, 20);
            this.tbDateCreation.TabIndex = 3;
            this.tbDateCreation.ValidatingType = typeof(System.DateTime);
            this.tbDateCreation.Enter += new System.EventHandler(this.tbDateCreation_Enter);
            // 
            // tbRefImmeuble
            // 
            this.tbRefImmeuble.Location = new System.Drawing.Point(86, 22);
            this.tbRefImmeuble.Name = "tbRefImmeuble";
            this.tbRefImmeuble.Size = new System.Drawing.Size(65, 20);
            this.tbRefImmeuble.TabIndex = 1;
            this.tbRefImmeuble.DoubleClick += new System.EventHandler(this.lblImmeuble_Click);
            this.tbRefImmeuble.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbHelpBox_KeyPress);
            this.tbRefImmeuble.Validating += new System.ComponentModel.CancelEventHandler(this.tbRefImmeuble_Validating);
            // 
            // lblImmeuble
            // 
            this.lblImmeuble.AutoSize = true;
            this.lblImmeuble.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblImmeuble.ForeColor = System.Drawing.Color.Blue;
            this.lblImmeuble.Location = new System.Drawing.Point(10, 25);
            this.lblImmeuble.Name = "lblImmeuble";
            this.lblImmeuble.Size = new System.Drawing.Size(55, 13);
            this.lblImmeuble.TabIndex = 0;
            this.lblImmeuble.Text = "&Immeuble:";
            this.lblImmeuble.Click += new System.EventHandler(this.lblImmeuble_Click);
            // 
            // Factures
            // 
            this.Factures.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Factures.Controls.Add(this.dataGridViewEcriture);
            this.Factures.Location = new System.Drawing.Point(12, 164);
            this.Factures.Name = "Factures";
            this.Factures.Size = new System.Drawing.Size(760, 190);
            this.Factures.TabIndex = 19;
            this.Factures.TabStop = false;
            this.Factures.Text = "Appel de Fonds";
            // 
            // dataGridViewEcriture
            // 
            this.dataGridViewEcriture.AllowUserToAddRows = false;
            this.dataGridViewEcriture.AllowUserToDeleteRows = false;
            this.dataGridViewEcriture.AllowUserToResizeRows = false;
            this.dataGridViewEcriture.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewEcriture.BackgroundColor = System.Drawing.Color.Snow;
            this.dataGridViewEcriture.Location = new System.Drawing.Point(14, 19);
            this.dataGridViewEcriture.MultiSelect = false;
            this.dataGridViewEcriture.Name = "dataGridViewEcriture";
            this.dataGridViewEcriture.ReadOnly = true;
            this.dataGridViewEcriture.RowHeadersVisible = false;
            this.dataGridViewEcriture.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dataGridViewEcriture.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewEcriture.ShowCellErrors = false;
            this.dataGridViewEcriture.ShowEditingIcon = false;
            this.dataGridViewEcriture.ShowRowErrors = false;
            this.dataGridViewEcriture.Size = new System.Drawing.Size(732, 156);
            this.dataGridViewEcriture.TabIndex = 0;
            this.dataGridViewEcriture.SelectionChanged += new System.EventHandler(this.dataGridViewEcriture_SelectionChanged);
            this.dataGridViewEcriture.DoubleClick += new System.EventHandler(this.dataGridViewEcriture_DoubleClick);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.dataGridView);
            this.groupBox2.Location = new System.Drawing.Point(12, 360);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(760, 245);
            this.groupBox2.TabIndex = 100;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Charges";
            // 
            // dataGridView
            // 
            this.dataGridView.AllowUserToAddRows = false;
            this.dataGridView.AllowUserToDeleteRows = false;
            this.dataGridView.BackgroundColor = System.Drawing.Color.Snow;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView.Location = new System.Drawing.Point(14, 19);
            this.dataGridView.MultiSelect = false;
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.ReadOnly = true;
            this.dataGridView.RowHeadersVisible = false;
            this.dataGridView.RowHeadersWidth = 31;
            this.dataGridView.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dataGridView.ShowCellErrors = false;
            this.dataGridView.ShowEditingIcon = false;
            this.dataGridView.ShowRowErrors = false;
            this.dataGridView.Size = new System.Drawing.Size(732, 200);
            this.dataGridView.TabIndex = 100;
            this.dataGridView.TabStop = false;
            // 
            // RowMenu
            // 
            this.RowMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editerToolStripMenuItem,
            this.supprimerToolStripMenuItem});
            this.RowMenu.Name = "RowMenu";
            this.RowMenu.Size = new System.Drawing.Size(123, 48);
            this.RowMenu.Text = "RowMenu";
            this.RowMenu.Opening += new System.ComponentModel.CancelEventHandler(this.RowMenu_Opening);
            // 
            // editerToolStripMenuItem
            // 
            this.editerToolStripMenuItem.Name = "editerToolStripMenuItem";
            this.editerToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
            this.editerToolStripMenuItem.Text = "Editer";
            // 
            // supprimerToolStripMenuItem
            // 
            this.supprimerToolStripMenuItem.Name = "supprimerToolStripMenuItem";
            this.supprimerToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
            this.supprimerToolStripMenuItem.Text = "Supprimer";
            this.supprimerToolStripMenuItem.Click += new System.EventHandler(this.supprimerToolStripMenuItem_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.btnDel);
            this.panel1.Controls.Add(this.btnRepart);
            this.panel1.Controls.Add(this.btnHelp);
            this.panel1.Controls.Add(this.btnEnter);
            this.panel1.Controls.Add(this.btnQuit);
            this.panel1.Controls.Add(this.btnAdd);
            this.panel1.Controls.Add(this.btnSave);
            this.panel1.Location = new System.Drawing.Point(12, 615);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(760, 35);
            this.panel1.TabIndex = 101;
            // 
            // btnDel
            // 
            this.btnDel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnDel.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnDel.ImageIndex = 12;
            this.btnDel.ImageList = this.imageList1;
            this.btnDel.Location = new System.Drawing.Point(429, 5);
            this.btnDel.Name = "btnDel";
            this.btnDel.Size = new System.Drawing.Size(100, 23);
            this.btnDel.TabIndex = 116;
            this.btnDel.Text = "&Supprimer";
            this.btnDel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDel.UseVisualStyleBackColor = true;
            this.btnDel.Click += new System.EventHandler(this.btnDel_Click);
            // 
            // btnRepart
            // 
            this.btnRepart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnRepart.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnRepart.ImageKey = "bulle_repart.png";
            this.btnRepart.ImageList = this.imageList1;
            this.btnRepart.Location = new System.Drawing.Point(323, 5);
            this.btnRepart.Name = "btnRepart";
            this.btnRepart.Size = new System.Drawing.Size(100, 23);
            this.btnRepart.TabIndex = 115;
            this.btnRepart.Text = "Note Repar&t.";
            this.btnRepart.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRepart.UseVisualStyleBackColor = true;
            this.btnRepart.Click += new System.EventHandler(this.btnRepart_Click);
            // 
            // btnHelp
            // 
            this.btnHelp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnHelp.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnHelp.ImageKey = "bulle.png";
            this.btnHelp.ImageList = this.imageList1;
            this.btnHelp.Location = new System.Drawing.Point(217, 5);
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Size = new System.Drawing.Size(100, 23);
            this.btnHelp.TabIndex = 114;
            this.btnHelp.Text = "Ra&ccourcis";
            this.btnHelp.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnHelp.UseVisualStyleBackColor = true;
            this.btnHelp.Click += new System.EventHandler(this.btnHelp_Click);
            // 
            // btnEnter
            // 
            this.btnEnter.Location = new System.Drawing.Point(571, 6);
            this.btnEnter.Name = "btnEnter";
            this.btnEnter.Size = new System.Drawing.Size(75, 23);
            this.btnEnter.TabIndex = 113;
            this.btnEnter.Text = "button1";
            this.btnEnter.UseVisualStyleBackColor = true;
            this.btnEnter.Click += new System.EventHandler(this.btnEnter_Click);
            // 
            // btnQuit
            // 
            this.btnQuit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnQuit.CausesValidation = false;
            this.btnQuit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnQuit.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnQuit.ImageIndex = 5;
            this.btnQuit.ImageList = this.imageList1;
            this.btnQuit.Location = new System.Drawing.Point(653, 5);
            this.btnQuit.Name = "btnQuit";
            this.btnQuit.Size = new System.Drawing.Size(100, 25);
            this.btnQuit.TabIndex = 112;
            this.btnQuit.Text = "&Quitter";
            this.btnQuit.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnQuit.UseVisualStyleBackColor = true;
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAdd.CausesValidation = false;
            this.btnAdd.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAdd.ImageIndex = 7;
            this.btnAdd.ImageList = this.imageList1;
            this.btnAdd.Location = new System.Drawing.Point(5, 5);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(100, 23);
            this.btnAdd.TabIndex = 110;
            this.btnAdd.Text = "&Ajouter";
            this.btnAdd.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSave.ImageKey = "save.png";
            this.btnSave.ImageList = this.imageList1;
            this.btnSave.Location = new System.Drawing.Point(110, 5);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(100, 23);
            this.btnSave.TabIndex = 111;
            this.btnSave.Text = "&Valider";
            this.btnSave.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnValid_Click);
            // 
            // FicheAppelDeFondForm
            // 
            this.AcceptButton = this.btnEnter;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnQuit;
            this.ClientSize = new System.Drawing.Size(784, 662);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.Factures);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox3);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimizeBox = false;
            this.Name = "FicheAppelDeFondForm";
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Saisie Appel de Fonds";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FicheAppelDeFondForm_FormClosing);
            this.Load += new System.EventHandler(this.Form_Load);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.tbComment_KeyPress);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.Factures.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewEcriture)).EndInit();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.RowMenu.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        protected GroupBox groupBox3;
        protected ComboBox cbLiasse;
        protected TextBox tbMontantLiasse;
        protected Label lblLiasse;
        protected TextBox tbDiff;
        protected Label lblDiff;
        protected TextBox tbTotal;
        protected Label lblTotal;
        protected GroupBox groupBox1;
        protected Button btnNatureAdd;
        protected TextBox tbComment;
        protected TextBox tbMontant;
        protected Label label8;
        protected TextBox tbLibNature;
        protected TextBox tbBase;
        protected Label lblBase;
        protected TextBox tbNature;
        protected Label lblNature;
        protected Label label3;
        protected MaskedTextBox tbDateCreation;
        protected TextBox tbRefImmeuble;
        protected Label lblImmeuble;
        protected GroupBox Factures;
        protected DataGridView dataGridViewEcriture;
        protected GroupBox groupBox2;
        protected DataGridView dataGridView;
        protected ImageList imageList1;
        protected ContextMenuStrip RowMenu;
        protected ToolStripMenuItem editerToolStripMenuItem;
        protected ToolStripMenuItem supprimerToolStripMenuItem;
        private IContainer components;
        private Panel panel1;
        private Button btnQuit;
        private Button btnAdd;
        private Button btnSave;
        private Button btnEnter;
        private Button btnHelp;
        private Button btnRepart;
        private Button btnDel;
        protected TextBox tbLot;
        protected Label lblLot;
        private ToolTip toolTip1;
        private Button btnDelLiasse;
    }
}