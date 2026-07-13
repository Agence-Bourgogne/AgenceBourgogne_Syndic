using System.ComponentModel;
using System.Windows.Forms;

namespace EspaceSyndic.Formulaires.Immeubles
{
    partial class TitreRepartImmeubleForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TitreRepartImmeubleForm));
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnQuit = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.Factures = new System.Windows.Forms.GroupBox();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.reference = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.repartition = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nom = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ligne = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colonne = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.tbColonne = new System.Windows.Forms.TextBox();
            this.lblColonne = new System.Windows.Forms.Label();
            this.tbLigne = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cbRepart = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tbTitre = new System.Windows.Forms.TextBox();
            this.lblTitre = new System.Windows.Forms.Label();
            this.tbBase = new System.Windows.Forms.TextBox();
            this.lblBase = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.Factures.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
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
            this.imageList1.Images.SetKeyName(6, "add.png");
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.btnQuit);
            this.panel1.Controls.Add(this.btnAdd);
            this.panel1.Controls.Add(this.btnSave);
            this.panel1.Location = new System.Drawing.Point(16, 347);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(564, 35);
            this.panel1.TabIndex = 102;
            // 
            // btnQuit
            // 
            this.btnQuit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnQuit.CausesValidation = false;
            this.btnQuit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnQuit.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnQuit.ImageIndex = 5;
            this.btnQuit.ImageList = this.imageList1;
            this.btnQuit.Location = new System.Drawing.Point(447, 4);
            this.btnQuit.Name = "btnQuit";
            this.btnQuit.Size = new System.Drawing.Size(100, 25);
            this.btnQuit.TabIndex = 86;
            this.btnQuit.Text = "&Quitter";
            this.btnQuit.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnQuit.UseVisualStyleBackColor = true;
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAdd.CausesValidation = false;
            this.btnAdd.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAdd.ImageIndex = 5;
            this.btnAdd.ImageList = this.imageList1;
            this.btnAdd.Location = new System.Drawing.Point(12, 4);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(100, 25);
            this.btnAdd.TabIndex = 1;
            this.btnAdd.Text = "&Ajouter";
            this.btnAdd.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Visible = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSave.ImageKey = "save.png";
            this.btnSave.ImageList = this.imageList1;
            this.btnSave.Location = new System.Drawing.Point(341, 4);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(100, 25);
            this.btnSave.TabIndex = 2;
            this.btnSave.Text = "&Enregistrer";
            this.btnSave.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // Factures
            // 
            this.Factures.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Factures.Controls.Add(this.dataGridView);
            this.Factures.Location = new System.Drawing.Point(16, 102);
            this.Factures.Name = "Factures";
            this.Factures.Size = new System.Drawing.Size(564, 228);
            this.Factures.TabIndex = 103;
            this.Factures.TabStop = false;
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
            this.dataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.reference,
            this.repartition,
            this.nom,
            this.ligne,
            this.colonne});
            this.dataGridView.Location = new System.Drawing.Point(14, 19);
            this.dataGridView.MultiSelect = false;
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.ReadOnly = true;
            this.dataGridView.RowHeadersVisible = false;
            this.dataGridView.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView.ShowCellErrors = false;
            this.dataGridView.ShowEditingIcon = false;
            this.dataGridView.ShowRowErrors = false;
            this.dataGridView.Size = new System.Drawing.Size(535, 193);
            this.dataGridView.TabIndex = 0;
            this.dataGridView.SelectionChanged += new System.EventHandler(this.dataGridView_SelectionChanged);
            // 
            // reference
            // 
            this.reference.HeaderText = "Base";
            this.reference.Name = "reference";
            this.reference.ReadOnly = true;
            // 
            // repartition
            // 
            this.repartition.HeaderText = "Répartition";
            this.repartition.Name = "repartition";
            this.repartition.ReadOnly = true;
            // 
            // nom
            // 
            this.nom.HeaderText = "Titre";
            this.nom.MinimumWidth = 250;
            this.nom.Name = "nom";
            this.nom.ReadOnly = true;
            // 
            // ligne
            // 
            this.ligne.HeaderText = "Ligne";
            this.ligne.Name = "ligne";
            this.ligne.ReadOnly = true;
            // 
            // colonne
            // 
            this.colonne.HeaderText = "Colonne";
            this.colonne.Name = "colonne";
            this.colonne.ReadOnly = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.tbColonne);
            this.groupBox3.Controls.Add(this.lblColonne);
            this.groupBox3.Controls.Add(this.tbLigne);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.cbRepart);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.tbTitre);
            this.groupBox3.Controls.Add(this.lblTitre);
            this.groupBox3.Controls.Add(this.tbBase);
            this.groupBox3.Controls.Add(this.lblBase);
            this.groupBox3.Location = new System.Drawing.Point(16, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(564, 84);
            this.groupBox3.TabIndex = 0;
            this.groupBox3.TabStop = false;
            // 
            // tbColonne
            // 
            this.tbColonne.Location = new System.Drawing.Point(497, 55);
            this.tbColonne.Name = "tbColonne";
            this.tbColonne.Size = new System.Drawing.Size(52, 20);
            this.tbColonne.TabIndex = 10;
            this.tbColonne.TextChanged += new System.EventHandler(this.tbColonne_TextChanged);
            // 
            // lblColonne
            // 
            this.lblColonne.AutoSize = true;
            this.lblColonne.Location = new System.Drawing.Point(424, 58);
            this.lblColonne.Name = "lblColonne";
            this.lblColonne.Size = new System.Drawing.Size(52, 13);
            this.lblColonne.TabIndex = 9;
            this.lblColonne.Text = "&Colonne: ";
            // 
            // tbLigne
            // 
            this.tbLigne.Location = new System.Drawing.Point(318, 55);
            this.tbLigne.Name = "tbLigne";
            this.tbLigne.Size = new System.Drawing.Size(52, 20);
            this.tbLigne.TabIndex = 8;
            this.tbLigne.TextChanged += new System.EventHandler(this.tbLigne_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(245, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "&Ligne : ";
            // 
            // cbRepart
            // 
            this.cbRepart.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbRepart.Enabled = false;
            this.cbRepart.FormattingEnabled = true;
            this.cbRepart.Location = new System.Drawing.Point(86, 54);
            this.cbRepart.Name = "cbRepart";
            this.cbRepart.Size = new System.Drawing.Size(110, 21);
            this.cbRepart.TabIndex = 6;
            this.cbRepart.SelectedIndexChanged += new System.EventHandler(this.cbRepart_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 57);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "&Répartition: ";
            // 
            // tbTitre
            // 
            this.tbTitre.Location = new System.Drawing.Point(196, 21);
            this.tbTitre.Name = "tbTitre";
            this.tbTitre.Size = new System.Drawing.Size(353, 20);
            this.tbTitre.TabIndex = 4;
            this.tbTitre.TextChanged += new System.EventHandler(this.tbTitre_TextChanged);
            // 
            // lblTitre
            // 
            this.lblTitre.AutoSize = true;
            this.lblTitre.Location = new System.Drawing.Point(153, 24);
            this.lblTitre.Name = "lblTitre";
            this.lblTitre.Size = new System.Drawing.Size(34, 13);
            this.lblTitre.TabIndex = 3;
            this.lblTitre.Text = "Titre :";
            // 
            // tbBase
            // 
            this.tbBase.Location = new System.Drawing.Point(86, 21);
            this.tbBase.Name = "tbBase";
            this.tbBase.Size = new System.Drawing.Size(52, 20);
            this.tbBase.TabIndex = 2;
            this.tbBase.TextChanged += new System.EventHandler(this.tbBase_TextChanged);
            // 
            // lblBase
            // 
            this.lblBase.AutoSize = true;
            this.lblBase.Location = new System.Drawing.Point(13, 24);
            this.lblBase.Name = "lblBase";
            this.lblBase.Size = new System.Drawing.Size(40, 13);
            this.lblBase.TabIndex = 1;
            this.lblBase.Text = "&Base : ";
            // 
            // TitreRepartImmeubleForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnQuit;
            this.ClientSize = new System.Drawing.Size(592, 394);
            this.ControlBox = false;
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.Factures);
            this.Controls.Add(this.panel1);
            this.Name = "TitreRepartImmeubleForm";
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Titres Repartition";
            this.Load += new System.EventHandler(this.TitreRepartImmeubleForm_Load);
            this.panel1.ResumeLayout(false);
            this.Factures.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        protected ImageList imageList1;
        private Panel panel1;
        private Button btnQuit;
        private Button btnAdd;
        private Button btnSave;
        protected GroupBox Factures;
        protected DataGridView dataGridView;
        protected GroupBox groupBox3;
        protected TextBox tbTitre;
        protected Label lblTitre;
        protected TextBox tbBase;
        protected Label lblBase;
        private ComboBox cbRepart;
        protected Label label1;
        protected TextBox tbColonne;
        protected Label lblColonne;
        protected TextBox tbLigne;
        protected Label label2;
        private DataGridViewTextBoxColumn reference;
        private DataGridViewTextBoxColumn repartition;
        private DataGridViewTextBoxColumn nom;
        private DataGridViewTextBoxColumn ligne;
        private DataGridViewTextBoxColumn colonne;
    }
}