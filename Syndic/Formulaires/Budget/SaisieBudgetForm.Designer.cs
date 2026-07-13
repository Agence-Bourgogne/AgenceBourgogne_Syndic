using System.ComponentModel;
using System.Windows.Forms;

namespace EspaceSyndic.Formulaires.Budget
{
    partial class SaisieBudgetForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SaisieBudgetForm));
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.dataGridViewExercice = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.nouvelExerciceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.modifierExerciceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cloturerExerciceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.budget_a_VoterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.budgetApprouveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tbLibNature = new System.Windows.Forms.TextBox();
            this.btnExerciceAdd = new System.Windows.Forms.Button();
            this.tbMontant = new System.Windows.Forms.TextBox();
            this.tbBase = new System.Windows.Forms.TextBox();
            this.lblBase = new System.Windows.Forms.Label();
            this.tbNature = new System.Windows.Forms.TextBox();
            this.lblNature = new System.Windows.Forms.Label();
            this.tbRefImmeuble = new System.Windows.Forms.TextBox();
            this.lblImmeuble = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnPrint = new System.Windows.Forms.Button();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.btnEnter = new System.Windows.Forms.Button();
            this.btnDel = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnQuit = new System.Windows.Forms.Button();
            this.gbBudget = new System.Windows.Forms.GroupBox();
            this.dataGridViewBudget = new System.Windows.Forms.DataGridView();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewExercice)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.gbBudget.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewBudget)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.dataGridViewExercice);
            this.groupBox3.Controls.Add(this.tbLibNature);
            this.groupBox3.Controls.Add(this.btnExerciceAdd);
            this.groupBox3.Controls.Add(this.tbMontant);
            this.groupBox3.Controls.Add(this.tbBase);
            this.groupBox3.Controls.Add(this.lblBase);
            this.groupBox3.Controls.Add(this.tbNature);
            this.groupBox3.Controls.Add(this.lblNature);
            this.groupBox3.Controls.Add(this.tbRefImmeuble);
            this.groupBox3.Controls.Add(this.lblImmeuble);
            this.groupBox3.Location = new System.Drawing.Point(12, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(760, 263);
            this.groupBox3.TabIndex = 0;
            this.groupBox3.TabStop = false;
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(603, 234);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(49, 13);
            this.label8.TabIndex = 9;
            this.label8.Text = "&Montant:";
            // 
            // dataGridViewExercice
            // 
            this.dataGridViewExercice.AllowUserToAddRows = false;
            this.dataGridViewExercice.AllowUserToDeleteRows = false;
            this.dataGridViewExercice.AllowUserToOrderColumns = true;
            this.dataGridViewExercice.AllowUserToResizeRows = false;
            this.dataGridViewExercice.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewExercice.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewExercice.BackgroundColor = System.Drawing.Color.White;
            this.dataGridViewExercice.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewExercice.ContextMenuStrip = this.contextMenuStrip1;
            this.dataGridViewExercice.Location = new System.Drawing.Point(151, 19);
            this.dataGridViewExercice.MultiSelect = false;
            this.dataGridViewExercice.Name = "dataGridViewExercice";
            this.dataGridViewExercice.ReadOnly = true;
            this.dataGridViewExercice.RowHeadersVisible = false;
            this.dataGridViewExercice.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dataGridViewExercice.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewExercice.Size = new System.Drawing.Size(592, 197);
            this.dataGridViewExercice.StandardTab = true;
            this.dataGridViewExercice.TabIndex = 2;
            this.dataGridViewExercice.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dataGridViewExercice_CellFormatting);
            this.dataGridViewExercice.SelectionChanged += new System.EventHandler(this.dataGridViewExercice_SelectionChanged);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nouvelExerciceToolStripMenuItem,
            this.modifierExerciceToolStripMenuItem,
            this.cloturerExerciceToolStripMenuItem,
            this.toolStripSeparator1,
            this.budget_a_VoterToolStripMenuItem,
            this.budgetApprouveToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(159, 120);
            // 
            // nouvelExerciceToolStripMenuItem
            // 
            this.nouvelExerciceToolStripMenuItem.Name = "nouvelExerciceToolStripMenuItem";
            this.nouvelExerciceToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.nouvelExerciceToolStripMenuItem.Text = "Nouvel Exercice";
            this.nouvelExerciceToolStripMenuItem.Click += new System.EventHandler(this.nouvelExerciceToolStripMenuItem_Click);
            // 
            // modifierExerciceToolStripMenuItem
            // 
            this.modifierExerciceToolStripMenuItem.Name = "modifierExerciceToolStripMenuItem";
            this.modifierExerciceToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.modifierExerciceToolStripMenuItem.Text = "Modifier Exercice";
            this.modifierExerciceToolStripMenuItem.Click += new System.EventHandler(this.modifierExerciceToolStripMenuItem_Click);
            // 
            // cloturerExerciceToolStripMenuItem
            // 
            this.cloturerExerciceToolStripMenuItem.Name = "cloturerExerciceToolStripMenuItem";
            this.cloturerExerciceToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.cloturerExerciceToolStripMenuItem.Text = "Cloturer Exercice";
            this.cloturerExerciceToolStripMenuItem.Click += new System.EventHandler(this.cloturerExerciceToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(155, 6);
            // 
            // budget_a_VoterToolStripMenuItem
            // 
            this.budget_a_VoterToolStripMenuItem.Name = "budget_a_VoterToolStripMenuItem";
            this.budget_a_VoterToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.budget_a_VoterToolStripMenuItem.Text = "Budget à Voter";
            this.budget_a_VoterToolStripMenuItem.Click += new System.EventHandler(this.budget_a_VoterToolStripMenuItem_Click);
            // 
            // budgetApprouveToolStripMenuItem
            // 
            this.budgetApprouveToolStripMenuItem.Name = "budgetApprouveToolStripMenuItem";
            this.budgetApprouveToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.budgetApprouveToolStripMenuItem.Text = "Budget Approuvé";
            this.budgetApprouveToolStripMenuItem.Click += new System.EventHandler(this.budgetApprouveToolStripMenuItem_Click);
            // 
            // tbLibNature
            // 
            this.tbLibNature.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.tbLibNature.Enabled = false;
            this.tbLibNature.Location = new System.Drawing.Point(263, 231);
            this.tbLibNature.Name = "tbLibNature";
            this.tbLibNature.Size = new System.Drawing.Size(334, 20);
            this.tbLibNature.TabIndex = 8;
            this.tbLibNature.TabStop = false;
            // 
            // btnExerciceAdd
            // 
            this.btnExerciceAdd.Location = new System.Drawing.Point(86, 49);
            this.btnExerciceAdd.Name = "btnExerciceAdd";
            this.btnExerciceAdd.Size = new System.Drawing.Size(22, 22);
            this.btnExerciceAdd.TabIndex = 3;
            this.btnExerciceAdd.TabStop = false;
            this.btnExerciceAdd.Text = "&+";
            this.btnExerciceAdd.UseVisualStyleBackColor = true;
            this.btnExerciceAdd.Click += new System.EventHandler(this.btnExerciceAdd_Click);
            // 
            // tbMontant
            // 
            this.tbMontant.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.tbMontant.Location = new System.Drawing.Point(661, 231);
            this.tbMontant.Name = "tbMontant";
            this.tbMontant.Size = new System.Drawing.Size(82, 20);
            this.tbMontant.TabIndex = 10;
            // 
            // tbBase
            // 
            this.tbBase.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.tbBase.Location = new System.Drawing.Point(86, 231);
            this.tbBase.Name = "tbBase";
            this.tbBase.Size = new System.Drawing.Size(55, 20);
            this.tbBase.TabIndex = 5;
            this.tbBase.Validating += new System.ComponentModel.CancelEventHandler(this.tbBase_Validating);
            // 
            // lblBase
            // 
            this.lblBase.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblBase.AutoSize = true;
            this.lblBase.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBase.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblBase.Location = new System.Drawing.Point(11, 234);
            this.lblBase.Name = "lblBase";
            this.lblBase.Size = new System.Drawing.Size(34, 13);
            this.lblBase.TabIndex = 4;
            this.lblBase.Text = "&Base:";
            // 
            // tbNature
            // 
            this.tbNature.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.tbNature.Location = new System.Drawing.Point(202, 231);
            this.tbNature.Name = "tbNature";
            this.tbNature.Size = new System.Drawing.Size(55, 20);
            this.tbNature.TabIndex = 7;
            this.tbNature.DoubleClick += new System.EventHandler(this.lblNature_Click);
            this.tbNature.Validating += new System.ComponentModel.CancelEventHandler(this.tbNature_Validating);
            // 
            // lblNature
            // 
            this.lblNature.AutoSize = true;
            this.lblNature.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNature.ForeColor = System.Drawing.Color.Blue;
            this.lblNature.Location = new System.Drawing.Point(148, 106);
            this.lblNature.Name = "lblNature";
            this.lblNature.Size = new System.Drawing.Size(42, 13);
            this.lblNature.TabIndex = 6;
            this.lblNature.Text = "&Nature:";
            this.lblNature.Click += new System.EventHandler(this.lblNature_Click);
            // 
            // tbRefImmeuble
            // 
            this.tbRefImmeuble.Location = new System.Drawing.Point(86, 23);
            this.tbRefImmeuble.Name = "tbRefImmeuble";
            this.tbRefImmeuble.Size = new System.Drawing.Size(55, 20);
            this.tbRefImmeuble.TabIndex = 1;
            this.tbRefImmeuble.DoubleClick += new System.EventHandler(this.lblImmeuble_Click);
            this.tbRefImmeuble.Validating += new System.ComponentModel.CancelEventHandler(this.tbRefImmeuble_Validating);
            // 
            // lblImmeuble
            // 
            this.lblImmeuble.AutoSize = true;
            this.lblImmeuble.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblImmeuble.ForeColor = System.Drawing.Color.Blue;
            this.lblImmeuble.Location = new System.Drawing.Point(10, 26);
            this.lblImmeuble.Name = "lblImmeuble";
            this.lblImmeuble.Size = new System.Drawing.Size(55, 13);
            this.lblImmeuble.TabIndex = 0;
            this.lblImmeuble.Text = "&Immeuble:";
            this.lblImmeuble.Click += new System.EventHandler(this.lblImmeuble_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.btnPrint);
            this.panel1.Controls.Add(this.btnEnter);
            this.panel1.Controls.Add(this.btnDel);
            this.panel1.Controls.Add(this.btnAdd);
            this.panel1.Controls.Add(this.btnQuit);
            this.panel1.Location = new System.Drawing.Point(12, 640);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(760, 39);
            this.panel1.TabIndex = 3;
            // 
            // btnPrint
            // 
            this.btnPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnPrint.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnPrint.ImageKey = "print.png";
            this.btnPrint.ImageList = this.imageList1;
            this.btnPrint.Location = new System.Drawing.Point(226, 5);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(100, 25);
            this.btnPrint.TabIndex = 2;
            this.btnPrint.Text = "&Imprimer";
            this.btnPrint.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
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
            this.imageList1.Images.SetKeyName(8, "del.png");
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
            this.btnDel.Location = new System.Drawing.Point(121, 6);
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
            this.gbBudget.Controls.Add(this.dataGridViewBudget);
            this.gbBudget.Location = new System.Drawing.Point(12, 281);
            this.gbBudget.Name = "gbBudget";
            this.gbBudget.Size = new System.Drawing.Size(760, 341);
            this.gbBudget.TabIndex = 1;
            this.gbBudget.TabStop = false;
            this.gbBudget.Text = "Budget";
            // 
            // dataGridViewBudget
            // 
            this.dataGridViewBudget.AllowUserToAddRows = false;
            this.dataGridViewBudget.AllowUserToDeleteRows = false;
            this.dataGridViewBudget.AllowUserToResizeRows = false;
            this.dataGridViewBudget.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewBudget.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewBudget.BackgroundColor = System.Drawing.Color.Snow;
            this.dataGridViewBudget.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewBudget.Location = new System.Drawing.Point(14, 19);
            this.dataGridViewBudget.MultiSelect = false;
            this.dataGridViewBudget.Name = "dataGridViewBudget";
            this.dataGridViewBudget.ReadOnly = true;
            this.dataGridViewBudget.RowHeadersVisible = false;
            this.dataGridViewBudget.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewBudget.ShowCellErrors = false;
            this.dataGridViewBudget.ShowEditingIcon = false;
            this.dataGridViewBudget.ShowRowErrors = false;
            this.dataGridViewBudget.Size = new System.Drawing.Size(732, 307);
            this.dataGridViewBudget.TabIndex = 0;
            this.dataGridViewBudget.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dataGridViewBudget_CellFormatting);
            this.dataGridViewBudget.SelectionChanged += new System.EventHandler(this.dataGridViewBudget_SelectionChanged);
            // 
            // SaisieBudgetForm
            // 
            this.AcceptButton = this.btnEnter;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnQuit;
            this.ClientSize = new System.Drawing.Size(784, 691);
            this.Controls.Add(this.gbBudget);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.groupBox3);
            this.Name = "SaisieBudgetForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Budget et Exercice";
            this.Load += new System.EventHandler(this.SaisieBudgetForm_Load);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewExercice)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.gbBudget.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewBudget)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private GroupBox groupBox3;
        private Panel panel1;
        private Button btnAdd;
        private Button btnQuit;
        private TextBox tbRefImmeuble;
        private Label lblImmeuble;
        private ImageList imageList1;
        private GroupBox gbBudget;
        private DataGridView dataGridViewBudget;
        private TextBox tbNature;
        private Label lblNature;
        private TextBox tbBase;
        private Label lblBase;
        private TextBox tbMontant;
        private Label label8;
        protected Button btnExerciceAdd;
        private TextBox tbLibNature;
        private Button btnDel;
        private Button btnPrint;
        private DataGridView dataGridViewExercice;
        private ContextMenuStrip contextMenuStrip1;
        private ToolStripMenuItem cloturerExerciceToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripMenuItem budget_a_VoterToolStripMenuItem;
        private ToolStripMenuItem budgetApprouveToolStripMenuItem;
        private ToolStripMenuItem nouvelExerciceToolStripMenuItem;
        private ToolStripMenuItem modifierExerciceToolStripMenuItem;
        private Button btnEnter;
    }
}