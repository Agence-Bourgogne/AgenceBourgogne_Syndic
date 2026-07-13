namespace EspaceSyndic.Formulaires.Ecritures
{
    partial class ValidationFactureForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ValidationFactureForm));
            this.gbFactures = new System.Windows.Forms.GroupBox();
            this.dataGridViewEcriture = new System.Windows.Forms.DataGridView();
            this.panelButton = new System.Windows.Forms.Panel();
            this.btnQuit = new System.Windows.Forms.Button();
            this.imageList2 = new System.Windows.Forms.ImageList(this.components);
            this.btnValid = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dataGridViewLiasse = new System.Windows.Forms.DataGridView();
            this.valider = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.gbFactures.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewEcriture)).BeginInit();
            this.panelButton.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewLiasse)).BeginInit();
            this.SuspendLayout();
            // 
            // gbFactures
            // 
            this.gbFactures.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbFactures.Controls.Add(this.dataGridViewEcriture);
            this.gbFactures.Location = new System.Drawing.Point(12, 299);
            this.gbFactures.Name = "gbFactures";
            this.gbFactures.Size = new System.Drawing.Size(760, 221);
            this.gbFactures.TabIndex = 105;
            this.gbFactures.TabStop = false;
            this.gbFactures.Text = "Factures";
            // 
            // dataGridViewEcriture
            // 
            this.dataGridViewEcriture.AllowUserToAddRows = false;
            this.dataGridViewEcriture.AllowUserToDeleteRows = false;
            this.dataGridViewEcriture.AllowUserToResizeRows = false;
            this.dataGridViewEcriture.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewEcriture.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewEcriture.BackgroundColor = System.Drawing.Color.Snow;
            this.dataGridViewEcriture.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewEcriture.Location = new System.Drawing.Point(14, 19);
            this.dataGridViewEcriture.MultiSelect = false;
            this.dataGridViewEcriture.Name = "dataGridViewEcriture";
            this.dataGridViewEcriture.ReadOnly = true;
            this.dataGridViewEcriture.RowHeadersVisible = false;
            this.dataGridViewEcriture.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewEcriture.ShowCellErrors = false;
            this.dataGridViewEcriture.ShowEditingIcon = false;
            this.dataGridViewEcriture.ShowRowErrors = false;
            this.dataGridViewEcriture.Size = new System.Drawing.Size(732, 185);
            this.dataGridViewEcriture.TabIndex = 7;
            this.dataGridViewEcriture.DoubleClick += new System.EventHandler(this.dataGridViewEcriture_DoubleClick);
            // 
            // panelButton
            // 
            this.panelButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelButton.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panelButton.Controls.Add(this.btnQuit);
            this.panelButton.Controls.Add(this.btnValid);
            this.panelButton.Location = new System.Drawing.Point(12, 526);
            this.panelButton.Name = "panelButton";
            this.panelButton.Size = new System.Drawing.Size(760, 35);
            this.panelButton.TabIndex = 106;
            // 
            // btnQuit
            // 
            this.btnQuit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnQuit.CausesValidation = false;
            this.btnQuit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnQuit.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnQuit.ImageIndex = 5;
            this.btnQuit.ImageList = this.imageList2;
            this.btnQuit.Location = new System.Drawing.Point(653, 5);
            this.btnQuit.Name = "btnQuit";
            this.btnQuit.Size = new System.Drawing.Size(100, 25);
            this.btnQuit.TabIndex = 86;
            this.btnQuit.TabStop = false;
            this.btnQuit.Text = "&Quitter";
            this.btnQuit.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnQuit.UseVisualStyleBackColor = true;
            // 
            // imageList2
            // 
            this.imageList2.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList2.ImageStream")));
            this.imageList2.TransparentColor = System.Drawing.Color.Silver;
            this.imageList2.Images.SetKeyName(0, "top.png");
            this.imageList2.Images.SetKeyName(1, "bottom.png");
            this.imageList2.Images.SetKeyName(2, "previous.png");
            this.imageList2.Images.SetKeyName(3, "next.png");
            this.imageList2.Images.SetKeyName(4, "save.png");
            this.imageList2.Images.SetKeyName(5, "quit.png");
            this.imageList2.Images.SetKeyName(6, "print.png");
            this.imageList2.Images.SetKeyName(7, "add.png");
            // 
            // btnValid
            // 
            this.btnValid.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnValid.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnValid.ImageKey = "save.png";
            this.btnValid.ImageList = this.imageList2;
            this.btnValid.Location = new System.Drawing.Point(6, 5);
            this.btnValid.Name = "btnValid";
            this.btnValid.Size = new System.Drawing.Size(100, 25);
            this.btnValid.TabIndex = 2;
            this.btnValid.TabStop = false;
            this.btnValid.Text = "&Valider";
            this.btnValid.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnValid.UseVisualStyleBackColor = true;
            this.btnValid.Click += new System.EventHandler(this.btnValid_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.dataGridViewLiasse);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(760, 281);
            this.groupBox1.TabIndex = 107;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Liasses";
            // 
            // dataGridViewLiasse
            // 
            this.dataGridViewLiasse.AllowUserToAddRows = false;
            this.dataGridViewLiasse.AllowUserToDeleteRows = false;
            this.dataGridViewLiasse.AllowUserToResizeRows = false;
            this.dataGridViewLiasse.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewLiasse.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewLiasse.BackgroundColor = System.Drawing.Color.Snow;
            this.dataGridViewLiasse.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewLiasse.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.valider});
            this.dataGridViewLiasse.Location = new System.Drawing.Point(14, 19);
            this.dataGridViewLiasse.MultiSelect = false;
            this.dataGridViewLiasse.Name = "dataGridViewLiasse";
            this.dataGridViewLiasse.ReadOnly = true;
            this.dataGridViewLiasse.RowHeadersVisible = false;
            this.dataGridViewLiasse.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewLiasse.ShowCellErrors = false;
            this.dataGridViewLiasse.ShowEditingIcon = false;
            this.dataGridViewLiasse.ShowRowErrors = false;
            this.dataGridViewLiasse.Size = new System.Drawing.Size(732, 245);
            this.dataGridViewLiasse.TabIndex = 7;
            this.dataGridViewLiasse.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewLiasse_CellContentClick);
            this.dataGridViewLiasse.SelectionChanged += new System.EventHandler(this.dataGridViewLiasse_SelectionChanged);
            // 
            // valider
            // 
            this.valider.HeaderText = "Valider";
            this.valider.IndeterminateValue = "false";
            this.valider.Name = "valider";
            this.valider.ReadOnly = true;
            // 
            // ValidationFactureForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnQuit;
            this.ClientSize = new System.Drawing.Size(784, 573);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panelButton);
            this.Controls.Add(this.gbFactures);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ValidationFactureForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Validation Factures";
            this.Load += new System.EventHandler(this.ValidationFactureForm_Load);
            this.gbFactures.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewEcriture)).EndInit();
            this.panelButton.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewLiasse)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbFactures;
        private System.Windows.Forms.DataGridView dataGridViewEcriture;
        private System.Windows.Forms.Panel panelButton;
        private System.Windows.Forms.Button btnQuit;
        private System.Windows.Forms.Button btnValid;
        protected System.Windows.Forms.ImageList imageList2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dataGridViewLiasse;
        private System.Windows.Forms.DataGridViewCheckBoxColumn valider;
    }
}