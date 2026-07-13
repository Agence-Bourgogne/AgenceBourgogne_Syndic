namespace EspaceSyndic.Formulaires.Utilisateurs
{
    partial class WebUserForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WebUserForm));
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.btnDelDoc = new System.Windows.Forms.Button();
            this.btnQuit = new System.Windows.Forms.Button();
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.btnNew = new System.Windows.Forms.Button();
            this.btnDelUser = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.btnNewCopro = new System.Windows.Forms.Button();
            this.btnDelCopro = new System.Windows.Forms.Button();
            this.btnAddDoc = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.listDoc = new System.Windows.Forms.ListBox();
            this.treeView = new System.Windows.Forms.TreeView();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "folder_open.png");
            this.imageList1.Images.SetKeyName(1, "immeuble.png");
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.tableLayoutPanel2);
            this.panel1.Location = new System.Drawing.Point(16, 640);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1475, 66);
            this.panel1.TabIndex = 8;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel2.ColumnCount = 8;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel2.Controls.Add(this.btnDelDoc, 5, 0);
            this.tableLayoutPanel2.Controls.Add(this.btnQuit, 7, 0);
            this.tableLayoutPanel2.Controls.Add(this.btnNew, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.btnDelUser, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.button1, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.btnNewCopro, 3, 0);
            this.tableLayoutPanel2.Controls.Add(this.btnDelCopro, 4, 0);
            this.tableLayoutPanel2.Controls.Add(this.btnAddDoc, 6, 0);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(2, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 58F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(1460, 58);
            this.tableLayoutPanel2.TabIndex = 94;
            // 
            // btnDelDoc
            // 
            this.btnDelDoc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDelDoc.CausesValidation = false;
            this.btnDelDoc.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnDelDoc.Image = ((System.Drawing.Image)(resources.GetObject("btnDelDoc.Image")));
            this.btnDelDoc.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnDelDoc.Location = new System.Drawing.Point(914, 6);
            this.btnDelDoc.Margin = new System.Windows.Forms.Padding(4);
            this.btnDelDoc.Name = "btnDelDoc";
            this.btnDelDoc.Size = new System.Drawing.Size(174, 45);
            this.btnDelDoc.TabIndex = 103;
            this.btnDelDoc.Text = "Supprimer \r\ndocument";
            this.btnDelDoc.UseVisualStyleBackColor = true;
            this.btnDelDoc.Click += new System.EventHandler(this.btnDelDoc_Click);
            // 
            // btnQuit
            // 
            this.btnQuit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.btnQuit.CausesValidation = false;
            this.btnQuit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnQuit.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnQuit.ImageIndex = 5;
            this.btnQuit.ImageList = this.imageList;
            this.btnQuit.Location = new System.Drawing.Point(1278, 6);
            this.btnQuit.Margin = new System.Windows.Forms.Padding(4);
            this.btnQuit.Name = "btnQuit";
            this.btnQuit.Size = new System.Drawing.Size(178, 45);
            this.btnQuit.TabIndex = 102;
            this.btnQuit.Text = "&Quitter";
            this.btnQuit.UseVisualStyleBackColor = true;
            this.btnQuit.Click += new System.EventHandler(this.btnQuit_Click);
            // 
            // imageList
            // 
            this.imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList.ImageStream")));
            this.imageList.TransparentColor = System.Drawing.Color.Silver;
            this.imageList.Images.SetKeyName(0, "top.png");
            this.imageList.Images.SetKeyName(1, "bottom.png");
            this.imageList.Images.SetKeyName(2, "previous.png");
            this.imageList.Images.SetKeyName(3, "next.png");
            this.imageList.Images.SetKeyName(4, "save.png");
            this.imageList.Images.SetKeyName(5, "quit.png");
            this.imageList.Images.SetKeyName(6, "edit.png");
            this.imageList.Images.SetKeyName(7, "add.png");
            this.imageList.Images.SetKeyName(8, "fiche.png");
            this.imageList.Images.SetKeyName(9, "excel.png");
            this.imageList.Images.SetKeyName(10, "stop.png");
            // 
            // btnNew
            // 
            this.btnNew.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNew.AutoSize = true;
            this.btnNew.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnNew.ImageKey = "add.png";
            this.btnNew.ImageList = this.imageList;
            this.btnNew.Location = new System.Drawing.Point(4, 6);
            this.btnNew.Margin = new System.Windows.Forms.Padding(4);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(174, 45);
            this.btnNew.TabIndex = 88;
            this.btnNew.Text = "&Nouvel \r\nUtilisateur";
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // btnDelUser
            // 
            this.btnDelUser.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDelUser.AutoSize = true;
            this.btnDelUser.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnDelUser.ImageKey = "stop.png";
            this.btnDelUser.ImageList = this.imageList;
            this.btnDelUser.Location = new System.Drawing.Point(186, 6);
            this.btnDelUser.Margin = new System.Windows.Forms.Padding(4);
            this.btnDelUser.Name = "btnDelUser";
            this.btnDelUser.Size = new System.Drawing.Size(174, 45);
            this.btnDelUser.TabIndex = 91;
            this.btnDelUser.Text = "Supprimer \r\nUtilisateur";
            this.btnDelUser.UseVisualStyleBackColor = true;
            this.btnDelUser.Click += new System.EventHandler(this.btnDelUser_Click);
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button1.ImageKey = "fiche.png";
            this.button1.ImageList = this.imageList;
            this.button1.Location = new System.Drawing.Point(368, 6);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(174, 45);
            this.button1.TabIndex = 93;
            this.button1.Text = "Modifier\r\nUtilisateur";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.UpdateUser);
            // 
            // btnNewCopro
            // 
            this.btnNewCopro.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNewCopro.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnNewCopro.ImageKey = "add.png";
            this.btnNewCopro.ImageList = this.imageList;
            this.btnNewCopro.Location = new System.Drawing.Point(550, 6);
            this.btnNewCopro.Margin = new System.Windows.Forms.Padding(4);
            this.btnNewCopro.Name = "btnNewCopro";
            this.btnNewCopro.Size = new System.Drawing.Size(174, 45);
            this.btnNewCopro.TabIndex = 100;
            this.btnNewCopro.Text = "Nouvelle \r\nCopro";
            this.btnNewCopro.UseVisualStyleBackColor = true;
            this.btnNewCopro.Click += new System.EventHandler(this.btnNewCopro_Click);
            // 
            // btnDelCopro
            // 
            this.btnDelCopro.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDelCopro.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnDelCopro.ImageKey = "stop.png";
            this.btnDelCopro.ImageList = this.imageList;
            this.btnDelCopro.Location = new System.Drawing.Point(732, 6);
            this.btnDelCopro.Margin = new System.Windows.Forms.Padding(4);
            this.btnDelCopro.Name = "btnDelCopro";
            this.btnDelCopro.Size = new System.Drawing.Size(174, 45);
            this.btnDelCopro.TabIndex = 99;
            this.btnDelCopro.Text = "Supprimer \r\nCopro";
            this.btnDelCopro.UseVisualStyleBackColor = true;
            this.btnDelCopro.Click += new System.EventHandler(this.btnDelCopro_Click);
            // 
            // btnAddDoc
            // 
            this.btnAddDoc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddDoc.CausesValidation = false;
            this.btnAddDoc.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnAddDoc.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAddDoc.Location = new System.Drawing.Point(1096, 6);
            this.btnAddDoc.Margin = new System.Windows.Forms.Padding(4);
            this.btnAddDoc.Name = "btnAddDoc";
            this.btnAddDoc.Size = new System.Drawing.Size(174, 45);
            this.btnAddDoc.TabIndex = 98;
            this.btnAddDoc.Text = "Ajouter \r\ndocument";
            this.btnAddDoc.UseVisualStyleBackColor = true;
            this.btnAddDoc.Click += new System.EventHandler(this.btnAddDoc_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.Controls.Add(this.listDoc, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.treeView, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.dataGridView, 0, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(16, 12);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1469, 621);
            this.tableLayoutPanel1.TabIndex = 10;
            // 
            // listDoc
            // 
            this.listDoc.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listDoc.FormattingEnabled = true;
            this.listDoc.ItemHeight = 16;
            this.listDoc.Location = new System.Drawing.Point(982, 4);
            this.listDoc.Margin = new System.Windows.Forms.Padding(4);
            this.listDoc.Name = "listDoc";
            this.listDoc.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.listDoc.Size = new System.Drawing.Size(483, 612);
            this.listDoc.TabIndex = 11;
            this.listDoc.SelectedIndexChanged += new System.EventHandler(this.listDoc_SelectedIndexChanged);
            // 
            // treeView
            // 
            this.treeView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.treeView.ImageIndex = 0;
            this.treeView.ImageList = this.imageList1;
            this.treeView.Location = new System.Drawing.Point(493, 4);
            this.treeView.Margin = new System.Windows.Forms.Padding(4);
            this.treeView.Name = "treeView";
            this.treeView.SelectedImageIndex = 0;
            this.treeView.Size = new System.Drawing.Size(481, 613);
            this.treeView.TabIndex = 2;
            this.treeView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView_AfterSelect);
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
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Location = new System.Drawing.Point(4, 4);
            this.dataGridView.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridView.MultiSelect = false;
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.ReadOnly = true;
            this.dataGridView.RowHeadersVisible = false;
            this.dataGridView.RowHeadersWidth = 51;
            this.dataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView.Size = new System.Drawing.Size(481, 613);
            this.dataGridView.TabIndex = 1;
            this.dataGridView.SelectionChanged += new System.EventHandler(this.dataGridView_SelectionChanged);
            // 
            // WebUserForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1511, 698);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "WebUserForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Utilisateurs Web";
            this.Load += new System.EventHandler(this.WebUserForm_Load);
            this.panel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ImageList imageList1;
        public System.Windows.Forms.Panel panel1;
        public System.Windows.Forms.ImageList imageList;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TreeView treeView;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        public System.Windows.Forms.Button btnNewCopro;
        public System.Windows.Forms.Button btnDelCopro;
        public System.Windows.Forms.Button btnAddDoc;
        public System.Windows.Forms.Button button1;
        public System.Windows.Forms.Button btnDelUser;
        public System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.ListBox listDoc;
        public System.Windows.Forms.Button btnDelDoc;
        public System.Windows.Forms.Button btnQuit;
    }
}