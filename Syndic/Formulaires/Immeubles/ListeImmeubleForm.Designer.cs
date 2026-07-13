using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace EspaceSyndic.Formulaires.Immeubles
{
    partial class ListeImmeubleForm
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private IContainer components = null;

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
            this.components = new Container();
            ComponentResourceManager resources = new ComponentResourceManager(typeof(ListeImmeubleForm));
            this.dataGridView = new DataGridView();
            this.RowMenu = new ContextMenuStrip(this.components);
            this.editionToolStripMenuItem = new ToolStripMenuItem();
            this.BtnEdit = new Button();
            this.imageList1 = new ImageList(this.components);
            this.BtnSave = new Button();
            this.generalMenu = new MenuStrip();
            this.editionToolStripMenuItem1 = new ToolStripMenuItem();
            this.editerToolStripMenuItem = new ToolStripMenuItem();
            this.nouveauToolStripMenuItem = new ToolStripMenuItem();
            this.panel1 = new Panel();
            this.btnFiltre = new Button();
            this.btnExport = new Button();
            this.btnFiche = new Button();
            this.btnNew = new Button();
            this.btnQuit = new Button();
            this.ckActif = new CheckBox();
            ((ISupportInitialize)(this.dataGridView)).BeginInit();
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
            this.dataGridView.Anchor = ((AnchorStyles)((((AnchorStyles.Top | AnchorStyles.Bottom) 
                                                         | AnchorStyles.Left) 
                                                        | AnchorStyles.Right)));
            this.dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.ContextMenuStrip = this.RowMenu;
            this.dataGridView.Location = new Point(16, 33);
            this.dataGridView.Margin = new Padding(4, 4, 4, 4);
            this.dataGridView.MultiSelect = false;
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.ReadOnly = true;
            this.dataGridView.RowHeadersVisible = false;
            this.dataGridView.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView.Size = new Size(1013, 590);
            this.dataGridView.TabIndex = 0;
            this.dataGridView.ColumnDisplayIndexChanged += new DataGridViewColumnEventHandler(this.dataGridView_ColumnDisplayIndexChanged);
            this.dataGridView.DoubleClick += new EventHandler(this.editionToolStripMenuItem_Click);
            this.dataGridView.KeyPress += new KeyPressEventHandler(this.dataGridView_KeyPress);
            // 
            // RowMenu
            // 
            this.RowMenu.ImageScalingSize = new Size(20, 20);
            this.RowMenu.Items.AddRange(new ToolStripItem[] {
            this.editionToolStripMenuItem});
            this.RowMenu.Name = "RowMenu";
            this.RowMenu.Size = new Size(113, 28);
            this.RowMenu.Text = "RowMenu";
            // 
            // editionToolStripMenuItem
            // 
            this.editionToolStripMenuItem.Name = "editionToolStripMenuItem";
            this.editionToolStripMenuItem.Size = new Size(112, 24);
            this.editionToolStripMenuItem.Text = "Fiche";
            this.editionToolStripMenuItem.Click += new EventHandler(this.editionToolStripMenuItem_Click);
            // 
            // BtnEdit
            // 
            this.BtnEdit.Anchor = ((AnchorStyles)((AnchorStyles.Bottom | AnchorStyles.Left)));
            this.BtnEdit.CausesValidation = false;
            this.BtnEdit.ImageAlign = ContentAlignment.MiddleRight;
            this.BtnEdit.ImageIndex = 6;
            this.BtnEdit.ImageList = this.imageList1;
            this.BtnEdit.Location = new Point(4, 5);
            this.BtnEdit.Margin = new Padding(4, 4, 4, 4);
            this.BtnEdit.Name = "BtnEdit";
            this.BtnEdit.Size = new Size(133, 31);
            this.BtnEdit.TabIndex = 1;
            this.BtnEdit.Text = "&Modifier Liste";
            this.BtnEdit.TextAlign = ContentAlignment.MiddleLeft;
            this.BtnEdit.UseVisualStyleBackColor = true;
            this.BtnEdit.Click += new EventHandler(this.BtnEdit_click);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = Color.Silver;
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
            this.BtnSave.Anchor = ((AnchorStyles)((AnchorStyles.Bottom | AnchorStyles.Left)));
            this.BtnSave.ImageAlign = ContentAlignment.MiddleRight;
            this.BtnSave.ImageKey = "save.png";
            this.BtnSave.ImageList = this.imageList1;
            this.BtnSave.Location = new Point(145, 5);
            this.BtnSave.Margin = new Padding(4, 4, 4, 4);
            this.BtnSave.Name = "BtnSave";
            this.BtnSave.Size = new Size(133, 31);
            this.BtnSave.TabIndex = 2;
            this.BtnSave.Text = "Enregi&strer";
            this.BtnSave.TextAlign = ContentAlignment.MiddleLeft;
            this.BtnSave.UseVisualStyleBackColor = true;
            this.BtnSave.Click += new EventHandler(this.BtnSave_Click);
            // 
            // generalMenu
            // 
            this.generalMenu.ImageScalingSize = new Size(20, 20);
            this.generalMenu.Items.AddRange(new ToolStripItem[] {
            this.editionToolStripMenuItem1});
            this.generalMenu.Location = new Point(0, 0);
            this.generalMenu.Name = "generalMenu";
            this.generalMenu.Padding = new Padding(8, 2, 0, 2);
            this.generalMenu.Size = new Size(1045, 28);
            this.generalMenu.TabIndex = 3;
            this.generalMenu.Text = "menuStrip1";
            // 
            // editionToolStripMenuItem1
            // 
            this.editionToolStripMenuItem1.DropDownItems.AddRange(new ToolStripItem[] {
            this.editerToolStripMenuItem,
            this.nouveauToolStripMenuItem});
            this.editionToolStripMenuItem1.Name = "editionToolStripMenuItem1";
            this.editionToolStripMenuItem1.Size = new Size(64, 24);
            this.editionToolStripMenuItem1.Text = "Action";
            // 
            // editerToolStripMenuItem
            // 
            this.editerToolStripMenuItem.Name = "editerToolStripMenuItem";
            this.editerToolStripMenuItem.Size = new Size(143, 26);
            this.editerToolStripMenuItem.Text = "Fiche";
            this.editerToolStripMenuItem.Click += new EventHandler(this.editionToolStripMenuItem_Click);
            // 
            // nouveauToolStripMenuItem
            // 
            this.nouveauToolStripMenuItem.Name = "nouveauToolStripMenuItem";
            this.nouveauToolStripMenuItem.Size = new Size(143, 26);
            this.nouveauToolStripMenuItem.Text = "Nouveau";
            this.nouveauToolStripMenuItem.Click += new EventHandler(this.nouveauToolStripMenuItem_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((AnchorStyles)(((AnchorStyles.Bottom | AnchorStyles.Left) 
                                                  | AnchorStyles.Right)));
            this.panel1.BorderStyle = BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.btnFiltre);
            this.panel1.Controls.Add(this.btnExport);
            this.panel1.Controls.Add(this.btnFiche);
            this.panel1.Controls.Add(this.btnNew);
            this.panel1.Controls.Add(this.btnQuit);
            this.panel1.Controls.Add(this.BtnEdit);
            this.panel1.Controls.Add(this.BtnSave);
            this.panel1.Location = new Point(16, 630);
            this.panel1.Margin = new Padding(4, 4, 4, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new Size(1012, 42);
            this.panel1.TabIndex = 4;
            // 
            // btnFiltre
            // 
            this.btnFiltre.Anchor = ((AnchorStyles)((AnchorStyles.Bottom | AnchorStyles.Left)));
            this.btnFiltre.ImageAlign = ContentAlignment.MiddleRight;
            this.btnFiltre.ImageKey = "zoom.png";
            this.btnFiltre.ImageList = this.imageList1;
            this.btnFiltre.Location = new Point(711, 5);
            this.btnFiltre.Margin = new Padding(4, 4, 4, 4);
            this.btnFiltre.Name = "btnFiltre";
            this.btnFiltre.Size = new Size(133, 31);
            this.btnFiltre.TabIndex = 93;
            this.btnFiltre.Text = "F&iltre";
            this.btnFiltre.TextAlign = ContentAlignment.MiddleLeft;
            this.btnFiltre.UseVisualStyleBackColor = true;
            this.btnFiltre.Click += new EventHandler(this.btnFiltre_Click);
            // 
            // btnExport
            // 
            this.btnExport.Anchor = ((AnchorStyles)((AnchorStyles.Bottom | AnchorStyles.Left)));
            this.btnExport.ImageAlign = ContentAlignment.MiddleRight;
            this.btnExport.ImageKey = "excel.png";
            this.btnExport.ImageList = this.imageList1;
            this.btnExport.Location = new Point(569, 5);
            this.btnExport.Margin = new Padding(4, 4, 4, 4);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new Size(133, 31);
            this.btnExport.TabIndex = 89;
            this.btnExport.Text = "E&xporter";
            this.btnExport.TextAlign = ContentAlignment.MiddleLeft;
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new EventHandler(this.btnExport_Click);
            // 
            // btnFiche
            // 
            this.btnFiche.Anchor = ((AnchorStyles)((AnchorStyles.Bottom | AnchorStyles.Left)));
            this.btnFiche.ImageAlign = ContentAlignment.MiddleRight;
            this.btnFiche.ImageKey = "fiche.png";
            this.btnFiche.ImageList = this.imageList1;
            this.btnFiche.Location = new Point(428, 5);
            this.btnFiche.Margin = new Padding(4, 4, 4, 4);
            this.btnFiche.Name = "btnFiche";
            this.btnFiche.Size = new Size(133, 31);
            this.btnFiche.TabIndex = 88;
            this.btnFiche.Text = "&Fiche";
            this.btnFiche.TextAlign = ContentAlignment.MiddleLeft;
            this.btnFiche.UseVisualStyleBackColor = true;
            this.btnFiche.Click += new EventHandler(this.editionToolStripMenuItem_Click);
            // 
            // btnNew
            // 
            this.btnNew.Anchor = ((AnchorStyles)((AnchorStyles.Bottom | AnchorStyles.Left)));
            this.btnNew.ImageAlign = ContentAlignment.MiddleRight;
            this.btnNew.ImageKey = "add.png";
            this.btnNew.ImageList = this.imageList1;
            this.btnNew.Location = new Point(287, 5);
            this.btnNew.Margin = new Padding(4, 4, 4, 4);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new Size(133, 31);
            this.btnNew.TabIndex = 87;
            this.btnNew.Text = "&Nouveau";
            this.btnNew.TextAlign = ContentAlignment.MiddleLeft;
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new EventHandler(this.nouveauToolStripMenuItem_Click);
            // 
            // btnQuit
            // 
            this.btnQuit.Anchor = ((AnchorStyles)((AnchorStyles.Bottom | AnchorStyles.Right)));
            this.btnQuit.CausesValidation = false;
            this.btnQuit.DialogResult = DialogResult.Cancel;
            this.btnQuit.ImageAlign = ContentAlignment.MiddleRight;
            this.btnQuit.ImageIndex = 5;
            this.btnQuit.ImageList = this.imageList1;
            this.btnQuit.Location = new Point(871, 5);
            this.btnQuit.Margin = new Padding(4, 4, 4, 4);
            this.btnQuit.Name = "btnQuit";
            this.btnQuit.Size = new Size(133, 31);
            this.btnQuit.TabIndex = 86;
            this.btnQuit.Text = "&Quitter";
            this.btnQuit.TextAlign = ContentAlignment.MiddleLeft;
            this.btnQuit.UseVisualStyleBackColor = true;
            // 
            // ckActif
            // 
            this.ckActif.Anchor = ((AnchorStyles)((AnchorStyles.Top | AnchorStyles.Right)));
            this.ckActif.AutoSize = true;
            this.ckActif.Checked = true;
            this.ckActif.CheckState = CheckState.Checked;
            this.ckActif.Location = new Point(880, 5);
            this.ckActif.Margin = new Padding(4, 4, 4, 4);
            this.ckActif.Name = "ckActif";
            this.ckActif.Size = new Size(144, 21);
            this.ckActif.TabIndex = 11;
            this.ckActif.Text = "&Actifs Uniquement";
            this.ckActif.UseVisualStyleBackColor = true;
            this.ckActif.CheckedChanged += new EventHandler(this.ckActif_CheckedChanged);
            // 
            // ListeImmeubleForm
            // 
            this.AutoScaleDimensions = new SizeF(8F, 16F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.CancelButton = this.btnQuit;
            this.ClientSize = new Size(1045, 692);
            this.ControlBox = false;
            this.Controls.Add(this.ckActif);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.generalMenu);
            this.Controls.Add(this.dataGridView);
            this.MainMenuStrip = this.generalMenu;
            this.Margin = new Padding(4, 4, 4, 4);
            this.Name = "ListeImmeubleForm";
            this.ShowInTaskbar = false;
            this.SizeGripStyle = SizeGripStyle.Hide;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Liste Immeubles";
            this.FormClosing += new FormClosingEventHandler(this.FormListClosing);
            this.Load += new EventHandler(this.ListeImmeubleForm_Load);
            ((ISupportInitialize)(this.dataGridView)).EndInit();
            this.RowMenu.ResumeLayout(false);
            this.generalMenu.ResumeLayout(false);
            this.generalMenu.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DataGridView dataGridView;
        private Button BtnEdit;
        private Button BtnSave;
        private ContextMenuStrip RowMenu;
        private ToolStripMenuItem editionToolStripMenuItem;
        private MenuStrip generalMenu;
        private ToolStripMenuItem editionToolStripMenuItem1;
        private ToolStripMenuItem editerToolStripMenuItem;
        private ToolStripMenuItem nouveauToolStripMenuItem;
        private Panel panel1;
        private ImageList imageList1;
        private Button btnQuit;
        private Button btnFiche;
        private Button btnNew;
        private Button btnExport;
        private Button btnFiltre;
        private CheckBox ckActif;
    }
}

