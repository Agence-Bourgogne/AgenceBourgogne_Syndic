namespace Gerance.Formulaires.Common
{
    partial class RechercheMultiForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RechercheMultiForm));
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnEnter = new System.Windows.Forms.Button();
            this.btnQuit = new System.Windows.Forms.Button();
            this.btnLoca = new System.Windows.Forms.Button();
            this.btnPropri = new System.Windows.Forms.Button();
            this.btnBien = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tbNomLoca = new System.Windows.Forms.TextBox();
            this.tbNomProprio = new System.Windows.Forms.TextBox();
            this.tbNomBien = new System.Windows.Forms.TextBox();
            this.tbRefLocataire = new System.Windows.Forms.TextBox();
            this.lblLocataire = new System.Windows.Forms.Label();
            this.tbRefProprio = new System.Windows.Forms.TextBox();
            this.lblProprio = new System.Windows.Forms.Label();
            this.tbReference = new System.Windows.Forms.TextBox();
            this.lblReference = new System.Windows.Forms.Label();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
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
            this.imageList1.Images.SetKeyName(6, "loupe.png");
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.btnEnter);
            this.panel1.Controls.Add(this.btnQuit);
            this.panel1.Controls.Add(this.btnLoca);
            this.panel1.Controls.Add(this.btnPropri);
            this.panel1.Controls.Add(this.btnBien);
            this.panel1.Location = new System.Drawing.Point(12, 497);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(756, 39);
            this.panel1.TabIndex = 2;
            // 
            // btnEnter
            // 
            this.btnEnter.Location = new System.Drawing.Point(451, 6);
            this.btnEnter.Name = "btnEnter";
            this.btnEnter.Size = new System.Drawing.Size(75, 23);
            this.btnEnter.TabIndex = 3;
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
            this.btnQuit.Location = new System.Drawing.Point(664, 5);
            this.btnQuit.Name = "btnQuit";
            this.btnQuit.Size = new System.Drawing.Size(80, 25);
            this.btnQuit.TabIndex = 4;
            this.btnQuit.Text = "&Quitter";
            this.btnQuit.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnQuit.UseVisualStyleBackColor = true;
            // 
            // btnLoca
            // 
            this.btnLoca.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnLoca.ImageIndex = 6;
            this.btnLoca.ImageList = this.imageList1;
            this.btnLoca.Location = new System.Drawing.Point(212, 5);
            this.btnLoca.Name = "btnLoca";
            this.btnLoca.Size = new System.Drawing.Size(100, 25);
            this.btnLoca.TabIndex = 2;
            this.btnLoca.Text = "Fiche Loca";
            this.btnLoca.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLoca.UseVisualStyleBackColor = true;
            this.btnLoca.Click += new System.EventHandler(this.btnLoca_Click);
            // 
            // btnPropri
            // 
            this.btnPropri.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnPropri.ImageIndex = 6;
            this.btnPropri.ImageList = this.imageList1;
            this.btnPropri.Location = new System.Drawing.Point(107, 5);
            this.btnPropri.Name = "btnPropri";
            this.btnPropri.Size = new System.Drawing.Size(100, 25);
            this.btnPropri.TabIndex = 1;
            this.btnPropri.Text = "Fiche Proprio";
            this.btnPropri.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPropri.UseVisualStyleBackColor = true;
            this.btnPropri.Click += new System.EventHandler(this.btnPropri_Click);
            // 
            // btnBien
            // 
            this.btnBien.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnBien.ImageIndex = 6;
            this.btnBien.ImageList = this.imageList1;
            this.btnBien.Location = new System.Drawing.Point(4, 5);
            this.btnBien.Name = "btnBien";
            this.btnBien.Size = new System.Drawing.Size(100, 25);
            this.btnBien.TabIndex = 0;
            this.btnBien.Text = "&Fiche Bien";
            this.btnBien.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBien.UseVisualStyleBackColor = true;
            this.btnBien.Click += new System.EventHandler(this.btnBien_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tbNomLoca);
            this.groupBox1.Controls.Add(this.tbNomProprio);
            this.groupBox1.Controls.Add(this.tbNomBien);
            this.groupBox1.Controls.Add(this.tbRefLocataire);
            this.groupBox1.Controls.Add(this.lblLocataire);
            this.groupBox1.Controls.Add(this.tbRefProprio);
            this.groupBox1.Controls.Add(this.lblProprio);
            this.groupBox1.Controls.Add(this.tbReference);
            this.groupBox1.Controls.Add(this.lblReference);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(756, 89);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // tbNomLoca
            // 
            this.tbNomLoca.Location = new System.Drawing.Point(562, 50);
            this.tbNomLoca.Name = "tbNomLoca";
            this.tbNomLoca.Size = new System.Drawing.Size(173, 20);
            this.tbNomLoca.TabIndex = 8;
            this.tbNomLoca.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbReference_KeyDown);
            this.tbNomLoca.Validating += new System.ComponentModel.CancelEventHandler(this.tbNomBien_Validating);
            // 
            // tbNomProprio
            // 
            this.tbNomProprio.Location = new System.Drawing.Point(302, 50);
            this.tbNomProprio.Name = "tbNomProprio";
            this.tbNomProprio.Size = new System.Drawing.Size(173, 20);
            this.tbNomProprio.TabIndex = 7;
            this.tbNomProprio.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbReference_KeyDown);
            this.tbNomProprio.Validating += new System.ComponentModel.CancelEventHandler(this.tbNomBien_Validating);
            // 
            // tbNomBien
            // 
            this.tbNomBien.Location = new System.Drawing.Point(18, 50);
            this.tbNomBien.Name = "tbNomBien";
            this.tbNomBien.Size = new System.Drawing.Size(173, 20);
            this.tbNomBien.TabIndex = 6;
            this.tbNomBien.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbReference_KeyDown);
            this.tbNomBien.Validating += new System.ComponentModel.CancelEventHandler(this.tbNomBien_Validating);
            // 
            // tbRefLocataire
            // 
            this.tbRefLocataire.Location = new System.Drawing.Point(635, 24);
            this.tbRefLocataire.Name = "tbRefLocataire";
            this.tbRefLocataire.Size = new System.Drawing.Size(100, 20);
            this.tbRefLocataire.TabIndex = 5;
            this.tbRefLocataire.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbReference_KeyDown);
            this.tbRefLocataire.Validating += new System.ComponentModel.CancelEventHandler(this.tbRefLocataire_Validating);
            // 
            // lblLocataire
            // 
            this.lblLocataire.AutoSize = true;
            this.lblLocataire.ForeColor = System.Drawing.Color.Blue;
            this.lblLocataire.Location = new System.Drawing.Point(559, 27);
            this.lblLocataire.Name = "lblLocataire";
            this.lblLocataire.Size = new System.Drawing.Size(54, 13);
            this.lblLocataire.TabIndex = 4;
            this.lblLocataire.Text = "&Locataire:";
            this.lblLocataire.Click += new System.EventHandler(this.lblLocataire_Click);
            // 
            // tbRefProprio
            // 
            this.tbRefProprio.Location = new System.Drawing.Point(375, 24);
            this.tbRefProprio.Name = "tbRefProprio";
            this.tbRefProprio.Size = new System.Drawing.Size(100, 20);
            this.tbRefProprio.TabIndex = 3;
            this.tbRefProprio.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbReference_KeyDown);
            this.tbRefProprio.Validating += new System.ComponentModel.CancelEventHandler(this.tbRefProprio_Validating);
            // 
            // lblProprio
            // 
            this.lblProprio.AutoSize = true;
            this.lblProprio.ForeColor = System.Drawing.Color.Blue;
            this.lblProprio.Location = new System.Drawing.Point(299, 27);
            this.lblProprio.Name = "lblProprio";
            this.lblProprio.Size = new System.Drawing.Size(60, 13);
            this.lblProprio.TabIndex = 2;
            this.lblProprio.Text = "&Propiétaire:";
            this.lblProprio.Click += new System.EventHandler(this.lblProprio_Click);
            // 
            // tbReference
            // 
            this.tbReference.Location = new System.Drawing.Point(91, 24);
            this.tbReference.Name = "tbReference";
            this.tbReference.Size = new System.Drawing.Size(100, 20);
            this.tbReference.TabIndex = 1;
            this.tbReference.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbReference_KeyDown);
            this.tbReference.Validating += new System.ComponentModel.CancelEventHandler(this.tbReference_Validating);
            // 
            // lblReference
            // 
            this.lblReference.AutoSize = true;
            this.lblReference.ForeColor = System.Drawing.Color.Blue;
            this.lblReference.Location = new System.Drawing.Point(15, 27);
            this.lblReference.Name = "lblReference";
            this.lblReference.Size = new System.Drawing.Size(31, 13);
            this.lblReference.TabIndex = 0;
            this.lblReference.Text = "&Bien:";
            this.lblReference.Click += new System.EventHandler(this.lblReference_Click);
            // 
            // dataGridView
            // 
            this.dataGridView.AllowUserToAddRows = false;
            this.dataGridView.AllowUserToDeleteRows = false;
            this.dataGridView.AllowUserToOrderColumns = true;
            this.dataGridView.AllowUserToResizeRows = false;
            this.dataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView.BackgroundColor = System.Drawing.Color.Snow;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Location = new System.Drawing.Point(12, 107);
            this.dataGridView.MultiSelect = false;
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.ReadOnly = true;
            this.dataGridView.RowHeadersVisible = false;
            this.dataGridView.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView.ShowCellErrors = false;
            this.dataGridView.ShowEditingIcon = false;
            this.dataGridView.ShowRowErrors = false;
            this.dataGridView.Size = new System.Drawing.Size(756, 382);
            this.dataGridView.TabIndex = 1;
            // 
            // RechercheMultiForm
            // 
            this.AcceptButton = this.btnEnter;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnQuit;
            this.ClientSize = new System.Drawing.Size(778, 548);
            this.Controls.Add(this.dataGridView);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel1);
            this.Name = "RechercheMultiForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Recherche Multiple";
            this.Load += new System.EventHandler(this.RechercheMultiForm_Load);
            this.panel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        protected System.Windows.Forms.ImageList imageList1;
        protected System.Windows.Forms.Panel panel1;
        protected System.Windows.Forms.Button btnEnter;
        protected System.Windows.Forms.Button btnQuit;
        protected System.Windows.Forms.Button btnLoca;
        protected System.Windows.Forms.Button btnPropri;
        protected System.Windows.Forms.Button btnBien;
        private System.Windows.Forms.GroupBox groupBox1;
        protected System.Windows.Forms.TextBox tbRefLocataire;
        protected System.Windows.Forms.Label lblLocataire;
        protected System.Windows.Forms.TextBox tbRefProprio;
        protected System.Windows.Forms.Label lblProprio;
        protected System.Windows.Forms.TextBox tbReference;
        protected System.Windows.Forms.Label lblReference;
        protected System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.TextBox tbNomLoca;
        private System.Windows.Forms.TextBox tbNomProprio;
        private System.Windows.Forms.TextBox tbNomBien;
    }
}