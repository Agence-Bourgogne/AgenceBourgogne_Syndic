namespace EspaceSyndic.Formulaires.Immeubles
{
    partial class ListeImmeubleForm
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ListeImmeubleForm));
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.RowMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.editionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.BtnEdit = new System.Windows.Forms.Button();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.BtnSave = new System.Windows.Forms.Button();
            this.generalMenu = new System.Windows.Forms.MenuStrip();
            this.editionToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.editerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nouveauToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnFiltre = new System.Windows.Forms.Button();
            this.btnExport = new System.Windows.Forms.Button();
            this.btnFiche = new System.Windows.Forms.Button();
            this.btnNew = new System.Windows.Forms.Button();
            this.btnQuit = new System.Windows.Forms.Button();
            this.ckActif = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.RowMenu.SuspendLayout();
            this.generalMenu.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
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
            this.dataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.ContextMenuStrip = this.RowMenu;
            this.dataGridView.Location = new System.Drawing.Point(16, 33);
            this.dataGridView.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dataGridView.MultiSelect = false;
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.ReadOnly = true;
            this.dataGridView.RowHeadersVisible = false;
            this.dataGridView.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView.Size = new System.Drawing.Size(1013, 590);
            this.dataGridView.TabIndex = 0;
            this.dataGridView.ColumnDisplayIndexChanged += new System.Windows.Forms.DataGridViewColumnEventHandler(this.dataGridView_ColumnDisplayIndexChanged);
            this.dataGridView.DoubleClick += new System.EventHandler(this.editionToolStripMenuItem_Click);
            this.dataGridView.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dataGridView_KeyPress);
            // 
            // RowMenu
            // 
            this.RowMenu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.RowMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editionToolStripMenuItem});
            this.RowMenu.Name = "RowMenu";
            this.RowMenu.Size = new System.Drawing.Size(113, 28);
            this.RowMenu.Text = "RowMenu";
            // 
            // editionToolStripMenuItem
            // 
            this.editionToolStripMenuItem.Name = "editionToolStripMenuItem";
            this.editionToolStripMenuItem.Size = new System.Drawing.Size(112, 24);
            this.editionToolStripMenuItem.Text = "Fiche";
            this.editionToolStripMenuItem.Click += new System.EventHandler(this.editionToolStripMenuItem_Click);
            // 
            // BtnEdit
            // 
            this.BtnEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.BtnEdit.CausesValidation = false;
            this.BtnEdit.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnEdit.ImageIndex = 6;
            this.BtnEdit.ImageList = this.imageList1;
            this.BtnEdit.Location = new System.Drawing.Point(4, 5);
            this.BtnEdit.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.BtnEdit.Name = "BtnEdit";
            this.BtnEdit.Size = new System.Drawing.Size(133, 31);
            this.BtnEdit.TabIndex = 1;
            this.BtnEdit.Text = "&Modifier Liste";
            this.BtnEdit.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnEdit.UseVisualStyleBackColor = true;
            this.BtnEdit.Click += new System.EventHandler(this.BtnEdit_click);
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
            this.imageList1.Images.SetKeyName(6, "edit.png");
            this.imageList1.Images.SetKeyName(7, "add.png");
            this.imageList1.Images.SetKeyName(8, "fiche.png");
            this.imageList1.Images.SetKeyName(9, "excel.png");
            this.imageList1.Images.SetKeyName(10, "zoom.png");
            // 
            // BtnSave
            // 
            this.BtnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.BtnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnSave.ImageKey = "save.png";
            this.BtnSave.ImageList = this.imageList1;
            this.BtnSave.Location = new System.Drawing.Point(145, 5);
            this.BtnSave.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.BtnSave.Name = "BtnSave";
            this.BtnSave.Size = new System.Drawing.Size(133, 31);
            this.BtnSave.TabIndex = 2;
            this.BtnSave.Text = "Enregi&strer";
            this.BtnSave.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnSave.UseVisualStyleBackColor = true;
            this.BtnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // generalMenu
            // 
            this.generalMenu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.generalMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editionToolStripMenuItem1});
            this.generalMenu.Location = new System.Drawing.Point(0, 0);
            this.generalMenu.Name = "generalMenu";
            this.generalMenu.Padding = new System.Windows.Forms.Padding(8, 2, 0, 2);
            this.generalMenu.Size = new System.Drawing.Size(1045, 28);
            this.generalMenu.TabIndex = 3;
            this.generalMenu.Text = "menuStrip1";
            // 
            // editionToolStripMenuItem1
            // 
            this.editionToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editerToolStripMenuItem,
            this.nouveauToolStripMenuItem});
            this.editionToolStripMenuItem1.Name = "editionToolStripMenuItem1";
            this.editionToolStripMenuItem1.Size = new System.Drawing.Size(64, 24);
            this.editionToolStripMenuItem1.Text = "Action";
            // 
            // editerToolStripMenuItem
            // 
            this.editerToolStripMenuItem.Name = "editerToolStripMenuItem";
            this.editerToolStripMenuItem.Size = new System.Drawing.Size(143, 26);
            this.editerToolStripMenuItem.Text = "Fiche";
            this.editerToolStripMenuItem.Click += new System.EventHandler(this.editionToolStripMenuItem_Click);
            // 
            // nouveauToolStripMenuItem
            // 
            this.nouveauToolStripMenuItem.Name = "nouveauToolStripMenuItem";
            this.nouveauToolStripMenuItem.Size = new System.Drawing.Size(143, 26);
            this.nouveauToolStripMenuItem.Text = "Nouveau";
            this.nouveauToolStripMenuItem.Click += new System.EventHandler(this.nouveauToolStripMenuItem_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.btnFiltre);
            this.panel1.Controls.Add(this.btnExport);
            this.panel1.Controls.Add(this.btnFiche);
            this.panel1.Controls.Add(this.btnNew);
            this.panel1.Controls.Add(this.btnQuit);
            this.panel1.Controls.Add(this.BtnEdit);
            this.panel1.Controls.Add(this.BtnSave);
            this.panel1.Location = new System.Drawing.Point(16, 630);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1012, 42);
            this.panel1.TabIndex = 4;
            // 
            // btnFiltre
            // 
            this.btnFiltre.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnFiltre.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnFiltre.ImageKey = "zoom.png";
            this.btnFiltre.ImageList = this.imageList1;
            this.btnFiltre.Location = new System.Drawing.Point(711, 5);
            this.btnFiltre.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnFiltre.Name = "btnFiltre";
            this.btnFiltre.Size = new System.Drawing.Size(133, 31);
            this.btnFiltre.TabIndex = 93;
            this.btnFiltre.Text = "F&iltre";
            this.btnFiltre.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnFiltre.UseVisualStyleBackColor = true;
            this.btnFiltre.Click += new System.EventHandler(this.btnFiltre_Click);
            // 
            // btnExport
            // 
            this.btnExport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnExport.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnExport.ImageKey = "excel.png";
            this.btnExport.ImageList = this.imageList1;
            this.btnExport.Location = new System.Drawing.Point(569, 5);
            this.btnExport.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(133, 31);
            this.btnExport.TabIndex = 89;
            this.btnExport.Text = "E&xporter";
            this.btnExport.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // btnFiche
            // 
            this.btnFiche.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnFiche.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnFiche.ImageKey = "fiche.png";
            this.btnFiche.ImageList = this.imageList1;
            this.btnFiche.Location = new System.Drawing.Point(428, 5);
            this.btnFiche.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnFiche.Name = "btnFiche";
            this.btnFiche.Size = new System.Drawing.Size(133, 31);
            this.btnFiche.TabIndex = 88;
            this.btnFiche.Text = "&Fiche";
            this.btnFiche.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnFiche.UseVisualStyleBackColor = true;
            this.btnFiche.Click += new System.EventHandler(this.editionToolStripMenuItem_Click);
            // 
            // btnNew
            // 
            this.btnNew.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnNew.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnNew.ImageKey = "add.png";
            this.btnNew.ImageList = this.imageList1;
            this.btnNew.Location = new System.Drawing.Point(287, 5);
            this.btnNew.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(133, 31);
            this.btnNew.TabIndex = 87;
            this.btnNew.Text = "&Nouveau";
            this.btnNew.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.nouveauToolStripMenuItem_Click);
            // 
            // btnQuit
            // 
            this.btnQuit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnQuit.CausesValidation = false;
            this.btnQuit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnQuit.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnQuit.ImageIndex = 5;
            this.btnQuit.ImageList = this.imageList1;
            this.btnQuit.Location = new System.Drawing.Point(871, 5);
            this.btnQuit.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnQuit.Name = "btnQuit";
            this.btnQuit.Size = new System.Drawing.Size(133, 31);
            this.btnQuit.TabIndex = 86;
            this.btnQuit.Text = "&Quitter";
            this.btnQuit.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnQuit.UseVisualStyleBackColor = true;
            // 
            // ckActif
            // 
            this.ckActif.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ckActif.AutoSize = true;
            this.ckActif.Checked = true;
            this.ckActif.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ckActif.Location = new System.Drawing.Point(880, 5);
            this.ckActif.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ckActif.Name = "ckActif";
            this.ckActif.Size = new System.Drawing.Size(144, 21);
            this.ckActif.TabIndex = 11;
            this.ckActif.Text = "&Actifs Uniquement";
            this.ckActif.UseVisualStyleBackColor = true;
            this.ckActif.CheckedChanged += new System.EventHandler(this.ckActif_CheckedChanged);
            // 
            // ListeImmeubleForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnQuit;
            this.ClientSize = new System.Drawing.Size(1045, 692);
            this.ControlBox = false;
            this.Controls.Add(this.ckActif);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.generalMenu);
            this.Controls.Add(this.dataGridView);
            this.MainMenuStrip = this.generalMenu;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "ListeImmeubleForm";
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Liste Immeubles";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormListClosing);
            this.Load += new System.EventHandler(this.ListeImmeubleForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.RowMenu.ResumeLayout(false);
            this.generalMenu.ResumeLayout(false);
            this.generalMenu.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.Button BtnEdit;
        private System.Windows.Forms.Button BtnSave;
        private System.Windows.Forms.ContextMenuStrip RowMenu;
        private System.Windows.Forms.ToolStripMenuItem editionToolStripMenuItem;
        private System.Windows.Forms.MenuStrip generalMenu;
        private System.Windows.Forms.ToolStripMenuItem editionToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem editerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nouveauToolStripMenuItem;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Button btnQuit;
        private System.Windows.Forms.Button btnFiche;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.Button btnFiltre;
        private System.Windows.Forms.CheckBox ckActif;
    }
}

