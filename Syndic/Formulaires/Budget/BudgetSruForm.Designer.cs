namespace EspaceSyndic.Formulaires.Budget
{
    partial class BudgetSruForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BudgetSruForm));
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnExport = new System.Windows.Forms.Button();
            this.btnPrint = new System.Windows.Forms.Button();
            this.btnEnter = new System.Windows.Forms.Button();
            this.btnDel = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnQuit = new System.Windows.Forms.Button();
            this.gbBudget = new System.Windows.Forms.GroupBox();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnExerciceAdd = new System.Windows.Forms.Button();
            this.lblNature = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.tbLibNature = new System.Windows.Forms.TextBox();
            this.tbMontant = new System.Windows.Forms.TextBox();
            this.tbBase = new System.Windows.Forms.TextBox();
            this.lblBase = new System.Windows.Forms.Label();
            this.tbNature = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cbExercice = new System.Windows.Forms.ComboBox();
            this.tbAdresse = new System.Windows.Forms.TextBox();
            this.tbNom = new System.Windows.Forms.TextBox();
            this.tbRefImmeuble = new System.Windows.Forms.TextBox();
            this.lblImmeuble = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.gbBudget.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.SystemColors.Control;
            this.imageList1.Images.SetKeyName(0, "top.png");
            this.imageList1.Images.SetKeyName(1, "bottom.png");
            this.imageList1.Images.SetKeyName(2, "previous.png");
            this.imageList1.Images.SetKeyName(3, "next.png");
            this.imageList1.Images.SetKeyName(4, "save.png");
            this.imageList1.Images.SetKeyName(5, "quit.png");
            this.imageList1.Images.SetKeyName(6, "print.png");
            this.imageList1.Images.SetKeyName(7, "add.png");
            this.imageList1.Images.SetKeyName(8, "del.png");
            this.imageList1.Images.SetKeyName(9, "excel.png");
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.btnExport);
            this.panel1.Controls.Add(this.btnPrint);
            this.panel1.Controls.Add(this.btnEnter);
            this.panel1.Controls.Add(this.btnDel);
            this.panel1.Controls.Add(this.btnAdd);
            this.panel1.Controls.Add(this.btnQuit);
            this.panel1.Location = new System.Drawing.Point(12, 567);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(760, 39);
            this.panel1.TabIndex = 2;
            // 
            // btnExport
            // 
            this.btnExport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnExport.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnExport.ImageKey = "excel.png";
            this.btnExport.ImageList = this.imageList1;
            this.btnExport.Location = new System.Drawing.Point(326, 6);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(100, 25);
            this.btnExport.TabIndex = 4;
            this.btnExport.Text = "E&xporter";
            this.btnExport.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnPrint.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnPrint.ImageKey = "print.png";
            this.btnPrint.ImageList = this.imageList1;
            this.btnPrint.Location = new System.Drawing.Point(221, 6);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(100, 25);
            this.btnPrint.TabIndex = 2;
            this.btnPrint.Text = "&Imprimer";
            this.btnPrint.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // btnEnter
            // 
            this.btnEnter.Location = new System.Drawing.Point(497, 5);
            this.btnEnter.Name = "btnEnter";
            this.btnEnter.Size = new System.Drawing.Size(75, 23);
            this.btnEnter.TabIndex = 2;
            this.btnEnter.Text = "button1";
            this.btnEnter.UseVisualStyleBackColor = true;
            this.btnEnter.Click += new System.EventHandler(this.btnEnter_Click);
            // 
            // btnDel
            // 
            this.btnDel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnDel.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnDel.ImageKey = "del.png";
            this.btnDel.ImageList = this.imageList1;
            this.btnDel.Location = new System.Drawing.Point(116, 6);
            this.btnDel.Name = "btnDel";
            this.btnDel.Size = new System.Drawing.Size(100, 25);
            this.btnDel.TabIndex = 1;
            this.btnDel.Text = "&Supprimer";
            this.btnDel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDel.UseVisualStyleBackColor = true;
            this.btnDel.Click += new System.EventHandler(this.btnDel_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAdd.CausesValidation = false;
            this.btnAdd.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAdd.ImageIndex = 7;
            this.btnAdd.ImageList = this.imageList1;
            this.btnAdd.Location = new System.Drawing.Point(11, 6);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(100, 25);
            this.btnAdd.TabIndex = 0;
            this.btnAdd.Text = "&Ajouter";
            this.btnAdd.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
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
            this.btnQuit.TabIndex = 3;
            this.btnQuit.TabStop = false;
            this.btnQuit.Text = "&Quitter";
            this.btnQuit.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnQuit.UseVisualStyleBackColor = true;
            // 
            // gbBudget
            // 
            this.gbBudget.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbBudget.Controls.Add(this.dataGridView);
            this.gbBudget.Location = new System.Drawing.Point(12, 142);
            this.gbBudget.Name = "gbBudget";
            this.gbBudget.Size = new System.Drawing.Size(760, 404);
            this.gbBudget.TabIndex = 1;
            this.gbBudget.TabStop = false;
            this.gbBudget.Text = "Budget";
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
            this.dataGridView.Size = new System.Drawing.Size(732, 370);
            this.dataGridView.TabIndex = 0;
            this.dataGridView.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dataGridViewBudget_CellFormatting);
            this.dataGridView.SelectionChanged += new System.EventHandler(this.dataGridViewBudget_SelectionChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.btnExerciceAdd);
            this.groupBox1.Controls.Add(this.lblNature);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.tbLibNature);
            this.groupBox1.Controls.Add(this.tbMontant);
            this.groupBox1.Controls.Add(this.tbBase);
            this.groupBox1.Controls.Add(this.lblBase);
            this.groupBox1.Controls.Add(this.tbNature);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.cbExercice);
            this.groupBox1.Controls.Add(this.tbAdresse);
            this.groupBox1.Controls.Add(this.tbNom);
            this.groupBox1.Controls.Add(this.tbRefImmeuble);
            this.groupBox1.Controls.Add(this.lblImmeuble);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(760, 112);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // btnExerciceAdd
            // 
            this.btnExerciceAdd.Location = new System.Drawing.Point(176, 45);
            this.btnExerciceAdd.Name = "btnExerciceAdd";
            this.btnExerciceAdd.Size = new System.Drawing.Size(22, 22);
            this.btnExerciceAdd.TabIndex = 13;
            this.btnExerciceAdd.TabStop = false;
            this.btnExerciceAdd.Text = "+";
            this.btnExerciceAdd.UseVisualStyleBackColor = true;
            this.btnExerciceAdd.Click += new System.EventHandler(this.btnNouvelExerciceAdd_Click);
            // 
            // lblNature
            // 
            this.lblNature.AutoSize = true;
            this.lblNature.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNature.ForeColor = System.Drawing.Color.Blue;
            this.lblNature.Location = new System.Drawing.Point(194, 75);
            this.lblNature.Name = "lblNature";
            this.lblNature.Size = new System.Drawing.Size(42, 13);
            this.lblNature.TabIndex = 8;
            this.lblNature.Text = "&Nature:";
            this.lblNature.Click += new System.EventHandler(this.lblNature_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(609, 75);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(49, 13);
            this.label8.TabIndex = 11;
            this.label8.Text = "&Montant:";
            // 
            // tbLibNature
            // 
            this.tbLibNature.Enabled = false;
            this.tbLibNature.Location = new System.Drawing.Point(308, 72);
            this.tbLibNature.Name = "tbLibNature";
            this.tbLibNature.Size = new System.Drawing.Size(295, 20);
            this.tbLibNature.TabIndex = 10;
            this.tbLibNature.TabStop = false;
            // 
            // tbMontant
            // 
            this.tbMontant.Location = new System.Drawing.Point(667, 72);
            this.tbMontant.Name = "tbMontant";
            this.tbMontant.Size = new System.Drawing.Size(82, 20);
            this.tbMontant.TabIndex = 12;
            // 
            // tbBase
            // 
            this.tbBase.Location = new System.Drawing.Point(92, 72);
            this.tbBase.Name = "tbBase";
            this.tbBase.Size = new System.Drawing.Size(82, 20);
            this.tbBase.TabIndex = 7;
            // 
            // lblBase
            // 
            this.lblBase.AutoSize = true;
            this.lblBase.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBase.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblBase.Location = new System.Drawing.Point(17, 75);
            this.lblBase.Name = "lblBase";
            this.lblBase.Size = new System.Drawing.Size(34, 13);
            this.lblBase.TabIndex = 6;
            this.lblBase.Text = "&Base:";
            // 
            // tbNature
            // 
            this.tbNature.Location = new System.Drawing.Point(247, 72);
            this.tbNature.Name = "tbNature";
            this.tbNature.Size = new System.Drawing.Size(55, 20);
            this.tbNature.TabIndex = 9;
            this.tbNature.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbHelpBox_KeyPress);
            this.tbNature.Validating += new System.ComponentModel.CancelEventHandler(this.tbNature_Validating);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 48);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "&Exercice";
            // 
            // cbExercice
            // 
            this.cbExercice.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbExercice.FormattingEnabled = true;
            this.cbExercice.Location = new System.Drawing.Point(92, 45);
            this.cbExercice.Name = "cbExercice";
            this.cbExercice.Size = new System.Drawing.Size(82, 21);
            this.cbExercice.TabIndex = 5;
            this.cbExercice.SelectedIndexChanged += new System.EventHandler(this.cbExercice_SelectedIndexChanged);
            // 
            // tbAdresse
            // 
            this.tbAdresse.Enabled = false;
            this.tbAdresse.Location = new System.Drawing.Point(473, 19);
            this.tbAdresse.Name = "tbAdresse";
            this.tbAdresse.Size = new System.Drawing.Size(273, 20);
            this.tbAdresse.TabIndex = 3;
            this.tbAdresse.TabStop = false;
            // 
            // tbNom
            // 
            this.tbNom.Enabled = false;
            this.tbNom.Location = new System.Drawing.Point(194, 19);
            this.tbNom.Name = "tbNom";
            this.tbNom.Size = new System.Drawing.Size(273, 20);
            this.tbNom.TabIndex = 2;
            this.tbNom.TabStop = false;
            // 
            // tbRefImmeuble
            // 
            this.tbRefImmeuble.Location = new System.Drawing.Point(92, 19);
            this.tbRefImmeuble.Name = "tbRefImmeuble";
            this.tbRefImmeuble.Size = new System.Drawing.Size(82, 20);
            this.tbRefImmeuble.TabIndex = 1;
            this.tbRefImmeuble.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbHelpBox_KeyPress);
            this.tbRefImmeuble.Validating += new System.ComponentModel.CancelEventHandler(this.tbRefImmeuble_Validating);
            // 
            // lblImmeuble
            // 
            this.lblImmeuble.AutoSize = true;
            this.lblImmeuble.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblImmeuble.ForeColor = System.Drawing.Color.Blue;
            this.lblImmeuble.Location = new System.Drawing.Point(16, 22);
            this.lblImmeuble.Name = "lblImmeuble";
            this.lblImmeuble.Size = new System.Drawing.Size(55, 13);
            this.lblImmeuble.TabIndex = 0;
            this.lblImmeuble.Text = "&Immeuble:";
            this.lblImmeuble.Click += new System.EventHandler(this.lblImmeuble_Click);
            // 
            // BudgetSruForm
            // 
            this.AcceptButton = this.btnEnter;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnQuit;
            this.ClientSize = new System.Drawing.Size(784, 618);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.gbBudget);
            this.Controls.Add(this.panel1);
            this.Name = "BudgetSruForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Budget";
            this.Load += new System.EventHandler(this.BudgetSruForm_Load);
            this.panel1.ResumeLayout(false);
            this.gbBudget.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Button btnEnter;
        private System.Windows.Forms.Button btnDel;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnQuit;
        private System.Windows.Forms.GroupBox gbBudget;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox tbAdresse;
        private System.Windows.Forms.TextBox tbNom;
        private System.Windows.Forms.TextBox tbRefImmeuble;
        private System.Windows.Forms.Label lblImmeuble;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbExercice;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox tbLibNature;
        private System.Windows.Forms.TextBox tbMontant;
        private System.Windows.Forms.TextBox tbBase;
        private System.Windows.Forms.Label lblBase;
        private System.Windows.Forms.TextBox tbNature;
        private System.Windows.Forms.Label lblNature;
        private System.Windows.Forms.Button btnExerciceAdd;
        private System.Windows.Forms.Button btnExport;
    }
}