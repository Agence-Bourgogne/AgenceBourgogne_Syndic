using System.ComponentModel;
using System.Windows.Forms;

namespace EspaceSyndic.Formulaires.OperationsGestion
{
    partial class DetailOperationForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DetailOperationForm));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbReglement = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnFournisseurAdd = new System.Windows.Forms.Button();
            this.btnNatureAdd = new System.Windows.Forms.Button();
            this.tbComment = new System.Windows.Forms.TextBox();
            this.tbCommentaireFournisseur = new System.Windows.Forms.TextBox();
            this.tbMontant = new System.Windows.Forms.TextBox();
            this.tbNomFournisseur = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.tbVilleFournisseur = new System.Windows.Forms.TextBox();
            this.tbCpFournisseur = new System.Windows.Forms.TextBox();
            this.tbAdresseFournisseur = new System.Windows.Forms.TextBox();
            this.tbLibNature = new System.Windows.Forms.TextBox();
            this.tbBase = new System.Windows.Forms.TextBox();
            this.lblBase = new System.Windows.Forms.Label();
            this.tbNature = new System.Windows.Forms.TextBox();
            this.lblNature = new System.Windows.Forms.Label();
            this.tbFournisseur = new System.Windows.Forms.TextBox();
            this.lblFournisseur = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tbDateCreation = new System.Windows.Forms.MaskedTextBox();
            this.tbRefImmeuble = new System.Windows.Forms.TextBox();
            this.lblImmeuble = new System.Windows.Forms.Label();
            this.gbFactures = new System.Windows.Forms.GroupBox();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnExport = new System.Windows.Forms.Button();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.btnEnter = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnValid = new System.Windows.Forms.Button();
            this.btnQuit = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.gbFactures.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.cbReglement);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.btnFournisseurAdd);
            this.groupBox1.Controls.Add(this.btnNatureAdd);
            this.groupBox1.Controls.Add(this.tbComment);
            this.groupBox1.Controls.Add(this.tbCommentaireFournisseur);
            this.groupBox1.Controls.Add(this.tbMontant);
            this.groupBox1.Controls.Add(this.tbNomFournisseur);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.tbVilleFournisseur);
            this.groupBox1.Controls.Add(this.tbCpFournisseur);
            this.groupBox1.Controls.Add(this.tbAdresseFournisseur);
            this.groupBox1.Controls.Add(this.tbLibNature);
            this.groupBox1.Controls.Add(this.tbBase);
            this.groupBox1.Controls.Add(this.lblBase);
            this.groupBox1.Controls.Add(this.tbNature);
            this.groupBox1.Controls.Add(this.lblNature);
            this.groupBox1.Controls.Add(this.tbFournisseur);
            this.groupBox1.Controls.Add(this.lblFournisseur);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.tbDateCreation);
            this.groupBox1.Controls.Add(this.tbRefImmeuble);
            this.groupBox1.Controls.Add(this.lblImmeuble);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(760, 133);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            // 
            // cbReglement
            // 
            this.cbReglement.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbReglement.FormattingEnabled = true;
            this.cbReglement.Location = new System.Drawing.Point(86, 99);
            this.cbReglement.Name = "cbReglement";
            this.cbReglement.Size = new System.Drawing.Size(88, 21);
            this.cbReglement.TabIndex = 20;
            this.cbReglement.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 102);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 13);
            this.label2.TabIndex = 19;
            this.label2.Text = "&Règlement:";
            this.label2.Visible = false;
            // 
            // btnFournisseurAdd
            // 
            this.btnFournisseurAdd.Location = new System.Drawing.Point(152, 72);
            this.btnFournisseurAdd.Name = "btnFournisseurAdd";
            this.btnFournisseurAdd.Size = new System.Drawing.Size(22, 22);
            this.btnFournisseurAdd.TabIndex = 25;
            this.btnFournisseurAdd.Text = "+";
            this.btnFournisseurAdd.UseVisualStyleBackColor = true;
            this.btnFournisseurAdd.Visible = false;
            // 
            // btnNatureAdd
            // 
            this.btnNatureAdd.Location = new System.Drawing.Point(152, 47);
            this.btnNatureAdd.Name = "btnNatureAdd";
            this.btnNatureAdd.Size = new System.Drawing.Size(22, 22);
            this.btnNatureAdd.TabIndex = 24;
            this.btnNatureAdd.Text = "+";
            this.btnNatureAdd.UseVisualStyleBackColor = true;
            this.btnNatureAdd.Visible = false;
            // 
            // tbComment
            // 
            this.tbComment.AccessibleDescription = "";
            this.tbComment.AccessibleName = "";
            this.tbComment.Location = new System.Drawing.Point(473, 48);
            this.tbComment.Name = "tbComment";
            this.tbComment.Size = new System.Drawing.Size(273, 20);
            this.tbComment.TabIndex = 14;
            // 
            // tbCommentaireFournisseur
            // 
            this.tbCommentaireFournisseur.Location = new System.Drawing.Point(473, 74);
            this.tbCommentaireFournisseur.Name = "tbCommentaireFournisseur";
            this.tbCommentaireFournisseur.Size = new System.Drawing.Size(273, 20);
            this.tbCommentaireFournisseur.TabIndex = 18;
            // 
            // tbMontant
            // 
            this.tbMontant.Location = new System.Drawing.Point(525, 22);
            this.tbMontant.Name = "tbMontant";
            this.tbMontant.Size = new System.Drawing.Size(65, 20);
            this.tbMontant.TabIndex = 11;
            // 
            // tbNomFournisseur
            // 
            this.tbNomFournisseur.Enabled = false;
            this.tbNomFournisseur.Location = new System.Drawing.Point(186, 74);
            this.tbNomFournisseur.Name = "tbNomFournisseur";
            this.tbNomFournisseur.Size = new System.Drawing.Size(273, 20);
            this.tbNomFournisseur.TabIndex = 19;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(470, 25);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(49, 13);
            this.label8.TabIndex = 10;
            this.label8.Text = "&Montant:";
            // 
            // tbVilleFournisseur
            // 
            this.tbVilleFournisseur.Enabled = false;
            this.tbVilleFournisseur.Location = new System.Drawing.Point(473, 99);
            this.tbVilleFournisseur.Name = "tbVilleFournisseur";
            this.tbVilleFournisseur.Size = new System.Drawing.Size(273, 20);
            this.tbVilleFournisseur.TabIndex = 22;
            // 
            // tbCpFournisseur
            // 
            this.tbCpFournisseur.Enabled = false;
            this.tbCpFournisseur.Location = new System.Drawing.Point(382, 99);
            this.tbCpFournisseur.Name = "tbCpFournisseur";
            this.tbCpFournisseur.Size = new System.Drawing.Size(77, 20);
            this.tbCpFournisseur.TabIndex = 21;
            // 
            // tbAdresseFournisseur
            // 
            this.tbAdresseFournisseur.Enabled = false;
            this.tbAdresseFournisseur.Location = new System.Drawing.Point(186, 99);
            this.tbAdresseFournisseur.Name = "tbAdresseFournisseur";
            this.tbAdresseFournisseur.Size = new System.Drawing.Size(191, 20);
            this.tbAdresseFournisseur.TabIndex = 20;
            // 
            // tbLibNature
            // 
            this.tbLibNature.Enabled = false;
            this.tbLibNature.Location = new System.Drawing.Point(186, 48);
            this.tbLibNature.Name = "tbLibNature";
            this.tbLibNature.Size = new System.Drawing.Size(273, 20);
            this.tbLibNature.TabIndex = 15;
            this.tbLibNature.TabStop = false;
            // 
            // tbBase
            // 
            this.tbBase.Location = new System.Drawing.Point(419, 22);
            this.tbBase.Name = "tbBase";
            this.tbBase.Size = new System.Drawing.Size(40, 20);
            this.tbBase.TabIndex = 9;
            // 
            // lblBase
            // 
            this.lblBase.AutoSize = true;
            this.lblBase.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBase.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblBase.Location = new System.Drawing.Point(379, 25);
            this.lblBase.Name = "lblBase";
            this.lblBase.Size = new System.Drawing.Size(34, 13);
            this.lblBase.TabIndex = 8;
            this.lblBase.Text = "&Base:";
            // 
            // tbNature
            // 
            this.tbNature.Location = new System.Drawing.Point(86, 48);
            this.tbNature.Name = "tbNature";
            this.tbNature.Size = new System.Drawing.Size(65, 20);
            this.tbNature.TabIndex = 13;
            this.tbNature.DoubleClick += new System.EventHandler(this.lblNature_Click);
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
            this.lblNature.TabIndex = 12;
            this.lblNature.Text = "&Nature:";
            this.lblNature.Click += new System.EventHandler(this.lblNature_Click);
            // 
            // tbFournisseur
            // 
            this.tbFournisseur.Location = new System.Drawing.Point(86, 74);
            this.tbFournisseur.Name = "tbFournisseur";
            this.tbFournisseur.Size = new System.Drawing.Size(65, 20);
            this.tbFournisseur.TabIndex = 17;
            this.tbFournisseur.DoubleClick += new System.EventHandler(this.lblFournisseur_Click);
            this.tbFournisseur.Validating += new System.ComponentModel.CancelEventHandler(this.tbFournisseur_Validating);
            // 
            // lblFournisseur
            // 
            this.lblFournisseur.AutoSize = true;
            this.lblFournisseur.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFournisseur.ForeColor = System.Drawing.Color.Blue;
            this.lblFournisseur.Location = new System.Drawing.Point(11, 77);
            this.lblFournisseur.Name = "lblFournisseur";
            this.lblFournisseur.Size = new System.Drawing.Size(64, 13);
            this.lblFournisseur.TabIndex = 16;
            this.lblFournisseur.Text = "&Fournisseur:";
            this.lblFournisseur.Click += new System.EventHandler(this.lblFournisseur_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(183, 25);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "&Date Création:";
            // 
            // tbDateCreation
            // 
            this.tbDateCreation.Location = new System.Drawing.Point(261, 22);
            this.tbDateCreation.Mask = "00/00/0000";
            this.tbDateCreation.Name = "tbDateCreation";
            this.tbDateCreation.Size = new System.Drawing.Size(81, 20);
            this.tbDateCreation.TabIndex = 7;
            this.tbDateCreation.ValidatingType = typeof(System.DateTime);
            // 
            // tbRefImmeuble
            // 
            this.tbRefImmeuble.Location = new System.Drawing.Point(86, 22);
            this.tbRefImmeuble.Name = "tbRefImmeuble";
            this.tbRefImmeuble.Size = new System.Drawing.Size(65, 20);
            this.tbRefImmeuble.TabIndex = 5;
            // 
            // lblImmeuble
            // 
            this.lblImmeuble.AutoSize = true;
            this.lblImmeuble.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblImmeuble.ForeColor = System.Drawing.Color.Blue;
            this.lblImmeuble.Location = new System.Drawing.Point(10, 25);
            this.lblImmeuble.Name = "lblImmeuble";
            this.lblImmeuble.Size = new System.Drawing.Size(55, 13);
            this.lblImmeuble.TabIndex = 4;
            this.lblImmeuble.Text = "&Immeuble:";
            // 
            // gbFactures
            // 
            this.gbFactures.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbFactures.Controls.Add(this.dataGridView);
            this.gbFactures.Location = new System.Drawing.Point(12, 151);
            this.gbFactures.Name = "gbFactures";
            this.gbFactures.Size = new System.Drawing.Size(760, 445);
            this.gbFactures.TabIndex = 19;
            this.gbFactures.TabStop = false;
            this.gbFactures.Text = "Repartition";
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
            this.dataGridView.Location = new System.Drawing.Point(14, 19);
            this.dataGridView.MultiSelect = false;
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.ReadOnly = true;
            this.dataGridView.RowHeadersVisible = false;
            this.dataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView.ShowCellErrors = false;
            this.dataGridView.ShowEditingIcon = false;
            this.dataGridView.ShowRowErrors = false;
            this.dataGridView.Size = new System.Drawing.Size(732, 411);
            this.dataGridView.TabIndex = 0;
            this.dataGridView.SelectionChanged += new System.EventHandler(this.dataGridView_SelectionChanged);
            this.dataGridView.DoubleClick += new System.EventHandler(this.dataGridView_DoubleClick);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.btnExport);
            this.panel1.Controls.Add(this.btnEnter);
            this.panel1.Controls.Add(this.btnDelete);
            this.panel1.Controls.Add(this.btnValid);
            this.panel1.Controls.Add(this.btnQuit);
            this.panel1.Location = new System.Drawing.Point(12, 602);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(760, 39);
            this.panel1.TabIndex = 20;
            // 
            // btnExport
            // 
            this.btnExport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnExport.CausesValidation = false;
            this.btnExport.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnExport.ImageIndex = 8;
            this.btnExport.ImageList = this.imageList1;
            this.btnExport.Location = new System.Drawing.Point(223, 6);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(100, 25);
            this.btnExport.TabIndex = 115;
            this.btnExport.TabStop = false;
            this.btnExport.Text = "E&xporter";
            this.btnExport.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
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
            this.imageList1.Images.SetKeyName(9, "zoom.png");
            this.imageList1.Images.SetKeyName(10, "del.png");
            // 
            // btnEnter
            // 
            this.btnEnter.Location = new System.Drawing.Point(341, 6);
            this.btnEnter.Name = "btnEnter";
            this.btnEnter.Size = new System.Drawing.Size(75, 23);
            this.btnEnter.TabIndex = 114;
            this.btnEnter.Text = "button1";
            this.btnEnter.UseVisualStyleBackColor = true;
            this.btnEnter.Click += new System.EventHandler(this.btnEnter_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnDelete.CausesValidation = false;
            this.btnDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnDelete.ImageIndex = 10;
            this.btnDelete.ImageList = this.imageList1;
            this.btnDelete.Location = new System.Drawing.Point(11, 6);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(100, 25);
            this.btnDelete.TabIndex = 10;
            this.btnDelete.Text = "&Supprimer";
            this.btnDelete.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnValid
            // 
            this.btnValid.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnValid.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnValid.ImageKey = "save.png";
            this.btnValid.ImageList = this.imageList1;
            this.btnValid.Location = new System.Drawing.Point(117, 6);
            this.btnValid.Name = "btnValid";
            this.btnValid.Size = new System.Drawing.Size(100, 25);
            this.btnValid.TabIndex = 11;
            this.btnValid.Text = "&Valider";
            this.btnValid.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnValid.UseVisualStyleBackColor = true;
            this.btnValid.Click += new System.EventHandler(this.btnValid_Click);
            // 
            // btnQuit
            // 
            this.btnQuit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnQuit.CausesValidation = false;
            this.btnQuit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnQuit.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnQuit.ImageIndex = 5;
            this.btnQuit.ImageList = this.imageList1;
            this.btnQuit.Location = new System.Drawing.Point(644, 6);
            this.btnQuit.Name = "btnQuit";
            this.btnQuit.Size = new System.Drawing.Size(100, 25);
            this.btnQuit.TabIndex = 9;
            this.btnQuit.TabStop = false;
            this.btnQuit.Text = "&Quitter";
            this.btnQuit.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnQuit.UseVisualStyleBackColor = true;
            // 
            // DetailOperationForm
            // 
            this.AcceptButton = this.btnEnter;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnQuit;
            this.ClientSize = new System.Drawing.Size(784, 653);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.gbFactures);
            this.Controls.Add(this.groupBox1);
            this.Name = "DetailOperationForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Annulation Modification Facture";
            this.Load += new System.EventHandler(this.DetailOperationForm_Load);
            this.Shown += new System.EventHandler(this.AnnulationFactureForm_Shown);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.gbFactures.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        protected GroupBox groupBox1;
        protected ComboBox cbReglement;
        protected Label label2;
        protected Button btnFournisseurAdd;
        protected Button btnNatureAdd;
        protected TextBox tbComment;
        protected TextBox tbCommentaireFournisseur;
        protected TextBox tbMontant;
        protected TextBox tbNomFournisseur;
        protected Label label8;
        protected TextBox tbVilleFournisseur;
        protected TextBox tbCpFournisseur;
        protected TextBox tbAdresseFournisseur;
        protected TextBox tbLibNature;
        protected TextBox tbBase;
        protected Label lblBase;
        protected TextBox tbNature;
        protected Label lblNature;
        protected TextBox tbFournisseur;
        protected Label lblFournisseur;
        protected Label label3;
        protected MaskedTextBox tbDateCreation;
        protected TextBox tbRefImmeuble;
        protected Label lblImmeuble;
        protected GroupBox gbFactures;
        protected DataGridView dataGridView;
        protected Panel panel1;
        protected Button btnEnter;
        protected Button btnDelete;
        protected Button btnValid;
        protected Button btnQuit;
        private Button btnExport;
        protected ImageList imageList1;
    }
}