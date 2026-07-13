namespace EspaceSyndic.Formulaires.Extranet
{
    partial class PublishDocument
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PublishDocument));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnDelete = new System.Windows.Forms.PictureBox();
            this.btnFolder = new System.Windows.Forms.PictureBox();
            this.btnFiles = new System.Windows.Forms.PictureBox();
            this.ListFilesView = new System.Windows.Forms.DataGridView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.listCopro = new System.Windows.Forms.ListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbRefImmeuble = new System.Windows.Forms.TextBox();
            this.lblImmeuble = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnEnter = new System.Windows.Forms.Button();
            this.btnQuit = new System.Windows.Forms.Button();
            this.btnPublish = new System.Windows.Forms.Button();
            this.syndicDataset = new EspaceSyndic.syndicDataset();
            this.coproprietaireBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.coproprietaireTableAdapter = new EspaceSyndic.syndicDatasetTableAdapters.coproprietaireTableAdapter();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnDelete)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnFolder)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnFiles)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ListFilesView)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.syndicDataset)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.coproprietaireBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.btnDelete);
            this.groupBox1.Controls.Add(this.btnFolder);
            this.groupBox1.Controls.Add(this.btnFiles);
            this.groupBox1.Controls.Add(this.ListFilesView);
            this.groupBox1.Location = new System.Drawing.Point(16, 15);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(964, 293);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Fichiers";
            // 
            // btnDelete
            // 
            this.btnDelete.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.btnDelete.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDelete.Image = global::EspaceSyndic.Properties.Resources.erase;
            this.btnDelete.Location = new System.Drawing.Point(77, 103);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(32, 32);
            this.btnDelete.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btnDelete.TabIndex = 8;
            this.btnDelete.TabStop = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnFolder
            // 
            this.btnFolder.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.btnFolder.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnFolder.Image = ((System.Drawing.Image)(resources.GetObject("btnFolder.Image")));
            this.btnFolder.Location = new System.Drawing.Point(77, 62);
            this.btnFolder.Name = "btnFolder";
            this.btnFolder.Size = new System.Drawing.Size(32, 32);
            this.btnFolder.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btnFolder.TabIndex = 7;
            this.btnFolder.TabStop = false;
            this.btnFolder.Click += new System.EventHandler(this.btnFolder_Click);
            // 
            // btnFiles
            // 
            this.btnFiles.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.btnFiles.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnFiles.Image = global::EspaceSyndic.Properties.Resources.files;
            this.btnFiles.Location = new System.Drawing.Point(77, 22);
            this.btnFiles.Name = "btnFiles";
            this.btnFiles.Size = new System.Drawing.Size(32, 32);
            this.btnFiles.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btnFiles.TabIndex = 6;
            this.btnFiles.TabStop = false;
            this.btnFiles.Click += new System.EventHandler(this.btnFiles_Click);
            // 
            // ListFilesView
            // 
            this.ListFilesView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ListFilesView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ListFilesView.Location = new System.Drawing.Point(115, 22);
            this.ListFilesView.Name = "ListFilesView";
            this.ListFilesView.RowTemplate.Height = 24;
            this.ListFilesView.Size = new System.Drawing.Size(829, 264);
            this.ListFilesView.TabIndex = 5;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.listCopro);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.tbRefImmeuble);
            this.groupBox2.Controls.Add(this.lblImmeuble);
            this.groupBox2.Location = new System.Drawing.Point(16, 316);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox2.Size = new System.Drawing.Size(964, 278);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Portée";
            // 
            // listCopro
            // 
            this.listCopro.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listCopro.FormattingEnabled = true;
            this.listCopro.ItemHeight = 16;
            this.listCopro.Location = new System.Drawing.Point(115, 48);
            this.listCopro.Margin = new System.Windows.Forms.Padding(4);
            this.listCopro.Name = "listCopro";
            this.listCopro.Size = new System.Drawing.Size(829, 212);
            this.listCopro.TabIndex = 3;
            this.listCopro.SelectedIndexChanged += new System.EventHandler(this.listCopro_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(11, 52);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(98, 17);
            this.label3.TabIndex = 2;
            this.label3.Text = "Copropriétaire";
            // 
            // tbRefImmeuble
            // 
            this.tbRefImmeuble.Location = new System.Drawing.Point(115, 16);
            this.tbRefImmeuble.Margin = new System.Windows.Forms.Padding(4);
            this.tbRefImmeuble.Name = "tbRefImmeuble";
            this.tbRefImmeuble.Size = new System.Drawing.Size(131, 22);
            this.tbRefImmeuble.TabIndex = 1;
            this.tbRefImmeuble.DoubleClick += new System.EventHandler(this.tbRefImmeuble_DoubleClick);
            this.tbRefImmeuble.Validating += new System.ComponentModel.CancelEventHandler(this.tbRefImmeuble_Validating);
            // 
            // lblImmeuble
            // 
            this.lblImmeuble.AutoSize = true;
            this.lblImmeuble.ForeColor = System.Drawing.Color.Black;
            this.lblImmeuble.Location = new System.Drawing.Point(8, 20);
            this.lblImmeuble.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblImmeuble.Name = "lblImmeuble";
            this.lblImmeuble.Size = new System.Drawing.Size(68, 17);
            this.lblImmeuble.TabIndex = 0;
            this.lblImmeuble.Text = "&Immeuble";
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.btnEnter);
            this.panel1.Controls.Add(this.btnQuit);
            this.panel1.Controls.Add(this.btnPublish);
            this.panel1.Location = new System.Drawing.Point(16, 630);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(963, 42);
            this.panel1.TabIndex = 102;
            // 
            // btnEnter
            // 
            this.btnEnter.Location = new System.Drawing.Point(12, 6);
            this.btnEnter.Margin = new System.Windows.Forms.Padding(4);
            this.btnEnter.Name = "btnEnter";
            this.btnEnter.Size = new System.Drawing.Size(100, 28);
            this.btnEnter.TabIndex = 113;
            this.btnEnter.Text = "button1";
            this.btnEnter.UseVisualStyleBackColor = true;
            // 
            // btnQuit
            // 
            this.btnQuit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnQuit.CausesValidation = false;
            this.btnQuit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnQuit.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnQuit.ImageIndex = 5;
            this.btnQuit.Location = new System.Drawing.Point(821, 6);
            this.btnQuit.Margin = new System.Windows.Forms.Padding(4);
            this.btnQuit.Name = "btnQuit";
            this.btnQuit.Size = new System.Drawing.Size(133, 31);
            this.btnQuit.TabIndex = 112;
            this.btnQuit.Text = "&Quitter";
            this.btnQuit.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnQuit.UseVisualStyleBackColor = true;
            this.btnQuit.Click += new System.EventHandler(this.btnQuit_Click);
            // 
            // btnPublish
            // 
            this.btnPublish.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPublish.CausesValidation = false;
            this.btnPublish.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnPublish.ImageIndex = 7;
            this.btnPublish.Location = new System.Drawing.Point(680, 6);
            this.btnPublish.Margin = new System.Windows.Forms.Padding(4);
            this.btnPublish.Name = "btnPublish";
            this.btnPublish.Size = new System.Drawing.Size(133, 28);
            this.btnPublish.TabIndex = 110;
            this.btnPublish.Text = "&Publier";
            this.btnPublish.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPublish.UseVisualStyleBackColor = true;
            this.btnPublish.Click += new System.EventHandler(this.btnPublish_Click);
            // 
            // syndicDataset
            // 
            this.syndicDataset.DataSetName = "syndicDataset";
            this.syndicDataset.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // coproprietaireBindingSource
            // 
            this.coproprietaireBindingSource.DataMember = "coproprietaire";
            this.coproprietaireBindingSource.DataSource = this.syndicDataset;
            // 
            // coproprietaireTableAdapter
            // 
            this.coproprietaireTableAdapter.ClearBeforeFill = true;
            // 
            // PublishDocument
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnQuit;
            this.ClientSize = new System.Drawing.Size(996, 688);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PublishDocument";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Publication Document";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.PublishDocument_FormClosed);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnDelete)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnFolder)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnFiles)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ListFilesView)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.syndicDataset)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.coproprietaireBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ListBox listCopro;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbRefImmeuble;
        private System.Windows.Forms.Label lblImmeuble;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnEnter;
        private System.Windows.Forms.Button btnQuit;
        private System.Windows.Forms.Button btnPublish;
        private System.Windows.Forms.DataGridView ListFilesView;
        private System.Windows.Forms.PictureBox btnFiles;
        private System.Windows.Forms.PictureBox btnFolder;
        private syndicDataset syndicDataset;
        private System.Windows.Forms.BindingSource coproprietaireBindingSource;
        private syndicDatasetTableAdapters.coproprietaireTableAdapter coproprietaireTableAdapter;
        private System.Windows.Forms.PictureBox btnDelete;
    }
}