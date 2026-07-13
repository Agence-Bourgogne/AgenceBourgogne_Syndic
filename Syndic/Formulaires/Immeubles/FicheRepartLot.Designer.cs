namespace EspaceSyndic.Formulaires.Immeubles
{
    partial class FicheRepartLot
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FicheRepartLot));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnCoproAdd = new System.Windows.Forms.Button();
            this.tbAvance = new System.Windows.Forms.TextBox();
            this.lblReference = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.tbEtage = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.tbBatiment = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.tbCoproprietaire = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tbEscalier = new System.Windows.Forms.TextBox();
            this.tbNumLot = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tbImmeuble = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dataGridViewLots = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.desactiverLeLotToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.réactiverLeLotToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.supprimerLeLotDéfinitivemantToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnQuit = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewLots)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.btnCoproAdd);
            this.groupBox1.Controls.Add(this.tbAvance);
            this.groupBox1.Controls.Add(this.lblReference);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.tbEtage);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.tbBatiment);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.tbCoproprietaire);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.tbEscalier);
            this.groupBox1.Controls.Add(this.tbNumLot);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.tbImmeuble);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(12, 219);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(760, 95);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Description Lot";
            // 
            // btnCoproAdd
            // 
            this.btnCoproAdd.Location = new System.Drawing.Point(565, 21);
            this.btnCoproAdd.Name = "btnCoproAdd";
            this.btnCoproAdd.Size = new System.Drawing.Size(22, 22);
            this.btnCoproAdd.TabIndex = 25;
            this.btnCoproAdd.Text = "+";
            this.btnCoproAdd.UseVisualStyleBackColor = true;
            this.btnCoproAdd.Click += new System.EventHandler(this.btnCoproAdd_Click);
            // 
            // tbAvance
            // 
            this.tbAvance.Location = new System.Drawing.Point(666, 51);
            this.tbAvance.Name = "tbAvance";
            this.tbAvance.Size = new System.Drawing.Size(60, 20);
            this.tbAvance.TabIndex = 13;
            // 
            // lblReference
            // 
            this.lblReference.AutoSize = true;
            this.lblReference.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblReference.ForeColor = System.Drawing.Color.Blue;
            this.lblReference.Location = new System.Drawing.Point(393, 25);
            this.lblReference.Name = "lblReference";
            this.lblReference.Size = new System.Drawing.Size(78, 13);
            this.lblReference.TabIndex = 4;
            this.lblReference.Text = "Copropriétaire :";
            this.lblReference.Click += new System.EventHandler(this.lblReference_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(603, 54);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(50, 13);
            this.label10.TabIndex = 12;
            this.label10.Text = "Avance :";
            // 
            // tbEtage
            // 
            this.tbEtage.Location = new System.Drawing.Point(480, 51);
            this.tbEtage.Name = "tbEtage";
            this.tbEtage.Size = new System.Drawing.Size(81, 20);
            this.tbEtage.TabIndex = 11;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(393, 51);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(41, 13);
            this.label9.TabIndex = 10;
            this.label9.Text = "Etage :";
            // 
            // tbBatiment
            // 
            this.tbBatiment.Location = new System.Drawing.Point(127, 48);
            this.tbBatiment.Name = "tbBatiment";
            this.tbBatiment.Size = new System.Drawing.Size(72, 20);
            this.tbBatiment.TabIndex = 7;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(10, 51);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(54, 13);
            this.label8.TabIndex = 6;
            this.label8.Text = "Batiment :";
            // 
            // tbCoproprietaire
            // 
            this.tbCoproprietaire.Location = new System.Drawing.Point(480, 22);
            this.tbCoproprietaire.Name = "tbCoproprietaire";
            this.tbCoproprietaire.Size = new System.Drawing.Size(81, 20);
            this.tbCoproprietaire.TabIndex = 5;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(209, 51);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(50, 13);
            this.label6.TabIndex = 8;
            this.label6.Text = "Escalier :";
            // 
            // tbEscalier
            // 
            this.tbEscalier.Location = new System.Drawing.Point(306, 48);
            this.tbEscalier.Name = "tbEscalier";
            this.tbEscalier.Size = new System.Drawing.Size(67, 20);
            this.tbEscalier.TabIndex = 9;
            // 
            // tbNumLot
            // 
            this.tbNumLot.Location = new System.Drawing.Point(306, 22);
            this.tbNumLot.Name = "tbNumLot";
            this.tbNumLot.Size = new System.Drawing.Size(67, 20);
            this.tbNumLot.TabIndex = 3;
            this.tbNumLot.Validating += new System.ComponentModel.CancelEventHandler(this.tbNumLot_Validating);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(209, 25);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(83, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "Numéro du Lot :";
            // 
            // tbImmeuble
            // 
            this.tbImmeuble.Location = new System.Drawing.Point(127, 22);
            this.tbImmeuble.Name = "tbImmeuble";
            this.tbImmeuble.Size = new System.Drawing.Size(72, 20);
            this.tbImmeuble.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(111, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Référence Immeuble :";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.dataGridViewLots);
            this.groupBox2.Location = new System.Drawing.Point(12, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(760, 201);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Lots";
            // 
            // dataGridViewLots
            // 
            this.dataGridViewLots.AllowUserToAddRows = false;
            this.dataGridViewLots.AllowUserToDeleteRows = false;
            this.dataGridViewLots.AllowUserToResizeRows = false;
            this.dataGridViewLots.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewLots.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewLots.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dataGridViewLots.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewLots.ContextMenuStrip = this.contextMenuStrip1;
            this.dataGridViewLots.Location = new System.Drawing.Point(14, 19);
            this.dataGridViewLots.MultiSelect = false;
            this.dataGridViewLots.Name = "dataGridViewLots";
            this.dataGridViewLots.RowHeadersVisible = false;
            this.dataGridViewLots.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewLots.ShowCellErrors = false;
            this.dataGridViewLots.ShowEditingIcon = false;
            this.dataGridViewLots.ShowRowErrors = false;
            this.dataGridViewLots.Size = new System.Drawing.Size(732, 165);
            this.dataGridViewLots.TabIndex = 1;
            this.dataGridViewLots.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dataGridViewLots_CellPainting);
            this.dataGridViewLots.CurrentCellChanged += new System.EventHandler(this.dataGridViewLots_Click);
            this.dataGridViewLots.RowPrePaint += new System.Windows.Forms.DataGridViewRowPrePaintEventHandler(this.dataGridViewLots_RowPrePaint);
            this.dataGridViewLots.Click += new System.EventHandler(this.dataGridViewLots_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.desactiverLeLotToolStripMenuItem,
            this.réactiverLeLotToolStripMenuItem,
            this.supprimerLeLotDéfinitivemantToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(223, 70);
            this.contextMenuStrip1.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip1_Opening);
            // 
            // desactiverLeLotToolStripMenuItem
            // 
            this.desactiverLeLotToolStripMenuItem.Name = "desactiverLeLotToolStripMenuItem";
            this.desactiverLeLotToolStripMenuItem.Size = new System.Drawing.Size(222, 22);
            this.desactiverLeLotToolStripMenuItem.Text = "Désactiver le Lot";
            this.desactiverLeLotToolStripMenuItem.Click += new System.EventHandler(this.desactiverLeLotToolStripMenuItem_Click);
            // 
            // réactiverLeLotToolStripMenuItem
            // 
            this.réactiverLeLotToolStripMenuItem.Name = "réactiverLeLotToolStripMenuItem";
            this.réactiverLeLotToolStripMenuItem.Size = new System.Drawing.Size(222, 22);
            this.réactiverLeLotToolStripMenuItem.Text = "Réactiver le Lot";
            this.réactiverLeLotToolStripMenuItem.Click += new System.EventHandler(this.reactiverLeLotToolStripMenuItem_Click);
            // 
            // supprimerLeLotDéfinitivemantToolStripMenuItem
            // 
            this.supprimerLeLotDéfinitivemantToolStripMenuItem.Name = "supprimerLeLotDéfinitivemantToolStripMenuItem";
            this.supprimerLeLotDéfinitivemantToolStripMenuItem.Size = new System.Drawing.Size(222, 22);
            this.supprimerLeLotDéfinitivemantToolStripMenuItem.Text = "Supprimer le Lot définitivement";
            this.supprimerLeLotDéfinitivemantToolStripMenuItem.Click += new System.EventHandler(this.supprimerLeLotDéfinitivemantToolStripMenuItem_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.dataGridView);
            this.groupBox3.Location = new System.Drawing.Point(12, 320);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(760, 245);
            this.groupBox3.TabIndex = 4;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Charges";
            // 
            // dataGridView
            // 
            this.dataGridView.AllowUserToAddRows = false;
            this.dataGridView.AllowUserToDeleteRows = false;
            this.dataGridView.AllowUserToResizeRows = false;
            this.dataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Location = new System.Drawing.Point(14, 28);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.RowHeadersVisible = false;
            this.dataGridView.ShowCellErrors = false;
            this.dataGridView.ShowEditingIcon = false;
            this.dataGridView.ShowRowErrors = false;
            this.dataGridView.Size = new System.Drawing.Size(732, 200);
            this.dataGridView.TabIndex = 0;
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
            this.panel1.Controls.Add(this.btnQuit);
            this.panel1.Controls.Add(this.btnSave);
            this.panel1.Location = new System.Drawing.Point(12, 572);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(760, 39);
            this.panel1.TabIndex = 11;
            // 
            // btnQuit
            // 
            this.btnQuit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnQuit.CausesValidation = false;
            this.btnQuit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnQuit.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnQuit.ImageIndex = 5;
            this.btnQuit.ImageList = this.imageList1;
            this.btnQuit.Location = new System.Drawing.Point(664, 5);
            this.btnQuit.Name = "btnQuit";
            this.btnQuit.Size = new System.Drawing.Size(80, 25);
            this.btnQuit.TabIndex = 9;
            this.btnQuit.Text = "&Quitter";
            this.btnQuit.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnQuit.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.CausesValidation = false;
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSave.ImageIndex = 4;
            this.btnSave.ImageList = this.imageList1;
            this.btnSave.Location = new System.Drawing.Point(578, 5);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(80, 25);
            this.btnSave.TabIndex = 8;
            this.btnSave.Text = "Enregi&strer";
            this.btnSave.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // FicheRepartLot
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 623);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.MinimizeBox = false;
            this.Name = "FicheRepartLot";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Fiche Repartition Lots";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FicheRepartLot_FormClosing);
            this.Load += new System.EventHandler(this.FicheRepartLot_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewLots)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox tbEtage;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox tbBatiment;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox tbCoproprietaire;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tbEscalier;
        private System.Windows.Forms.TextBox tbNumLot;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbImmeuble;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.TextBox tbAvance;
        private System.Windows.Forms.Label lblReference;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.DataGridView dataGridViewLots;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnQuit;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCoproAdd;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem desactiverLeLotToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem réactiverLeLotToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem supprimerLeLotDéfinitivemantToolStripMenuItem;
    }
}