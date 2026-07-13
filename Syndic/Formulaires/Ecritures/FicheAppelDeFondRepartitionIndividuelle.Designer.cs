using System.ComponentModel;
using System.Windows.Forms;

namespace EspaceSyndic.Formulaires.Ecritures
{
    partial class FicheAppelDeFondRepartitionIndividuelle
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FicheAppelDeFondRepartitionIndividuelle));
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnEnter = new System.Windows.Forms.Button();
            this.btnValid = new System.Windows.Forms.Button();
            this.btnQuit = new System.Windows.Forms.Button();
            this.gbBase = new System.Windows.Forms.GroupBox();
            this.tbGlobal = new System.Windows.Forms.TextBox();
            this.lblGlobal = new System.Windows.Forms.Label();
            this.tbBase = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbMontantActuel = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tbDiff = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.tbMontantTotal = new System.Windows.Forms.TextBox();
            this.lblTotal = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dataGridViewLots = new System.Windows.Forms.DataGridView();
            this.panel1.SuspendLayout();
            this.gbBase.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewLots)).BeginInit();
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
            this.imageList1.Images.SetKeyName(5, "stop.png");
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.btnEnter);
            this.panel1.Controls.Add(this.btnValid);
            this.panel1.Controls.Add(this.btnQuit);
            this.panel1.Location = new System.Drawing.Point(12, 462);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(760, 39);
            this.panel1.TabIndex = 15;
            // 
            // btnEnter
            // 
            this.btnEnter.Location = new System.Drawing.Point(341, 6);
            this.btnEnter.Name = "btnEnter";
            this.btnEnter.Size = new System.Drawing.Size(75, 23);
            this.btnEnter.TabIndex = 116;
            this.btnEnter.Text = "button1";
            this.btnEnter.UseVisualStyleBackColor = true;
            this.btnEnter.Click += new System.EventHandler(this.btnEnter_Click);
            // 
            // btnValid
            // 
            this.btnValid.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnValid.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnValid.ImageKey = "save.png";
            this.btnValid.ImageList = this.imageList1;
            this.btnValid.Location = new System.Drawing.Point(538, 6);
            this.btnValid.Name = "btnValid";
            this.btnValid.Size = new System.Drawing.Size(100, 25);
            this.btnValid.TabIndex = 11;
            this.btnValid.Text = "V&alider";
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
            // gbBase
            // 
            this.gbBase.Controls.Add(this.tbGlobal);
            this.gbBase.Controls.Add(this.lblGlobal);
            this.gbBase.Controls.Add(this.tbBase);
            this.gbBase.Controls.Add(this.label2);
            this.gbBase.Controls.Add(this.tbMontantActuel);
            this.gbBase.Controls.Add(this.label1);
            this.gbBase.Controls.Add(this.tbDiff);
            this.gbBase.Controls.Add(this.label9);
            this.gbBase.Controls.Add(this.tbMontantTotal);
            this.gbBase.Controls.Add(this.lblTotal);
            this.gbBase.Location = new System.Drawing.Point(12, 9);
            this.gbBase.Name = "gbBase";
            this.gbBase.Size = new System.Drawing.Size(760, 55);
            this.gbBase.TabIndex = 0;
            this.gbBase.TabStop = false;
            // 
            // tbGlobal
            // 
            this.tbGlobal.Location = new System.Drawing.Point(287, 19);
            this.tbGlobal.Name = "tbGlobal";
            this.tbGlobal.Size = new System.Drawing.Size(52, 20);
            this.tbGlobal.TabIndex = 3;
            this.tbGlobal.Validating += new System.ComponentModel.CancelEventHandler(this.tbGlobal_Validating);
            // 
            // lblGlobal
            // 
            this.lblGlobal.AutoSize = true;
            this.lblGlobal.Location = new System.Drawing.Point(202, 22);
            this.lblGlobal.Name = "lblGlobal";
            this.lblGlobal.Size = new System.Drawing.Size(79, 13);
            this.lblGlobal.TabIndex = 2;
            this.lblGlobal.Text = "&Valeur Globale:";
            // 
            // tbBase
            // 
            this.tbBase.Enabled = false;
            this.tbBase.Location = new System.Drawing.Point(77, 19);
            this.tbBase.Name = "tbBase";
            this.tbBase.Size = new System.Drawing.Size(52, 20);
            this.tbBase.TabIndex = 1;
            this.tbBase.UseWaitCursor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Base:";
            this.label2.UseWaitCursor = true;
            // 
            // tbMontantActuel
            // 
            this.tbMontantActuel.Enabled = false;
            this.tbMontantActuel.Location = new System.Drawing.Point(545, 19);
            this.tbMontantActuel.Name = "tbMontantActuel";
            this.tbMontantActuel.Size = new System.Drawing.Size(52, 20);
            this.tbMontantActuel.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(494, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Somme";
            // 
            // tbDiff
            // 
            this.tbDiff.Enabled = false;
            this.tbDiff.Location = new System.Drawing.Point(684, 19);
            this.tbDiff.Name = "tbDiff";
            this.tbDiff.Size = new System.Drawing.Size(52, 20);
            this.tbDiff.TabIndex = 9;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(619, 22);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(59, 13);
            this.label9.TabIndex = 8;
            this.label9.Text = "Différence:";
            // 
            // tbMontantTotal
            // 
            this.tbMontantTotal.Location = new System.Drawing.Point(419, 19);
            this.tbMontantTotal.Name = "tbMontantTotal";
            this.tbMontantTotal.Size = new System.Drawing.Size(52, 20);
            this.tbMontantTotal.TabIndex = 5;
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Location = new System.Drawing.Point(364, 22);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(49, 13);
            this.lblTotal.TabIndex = 4;
            this.lblTotal.Text = "Montant:";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.dataGridViewLots);
            this.groupBox2.Location = new System.Drawing.Point(12, 70);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(760, 386);
            this.groupBox2.TabIndex = 13;
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
            this.dataGridViewLots.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dataGridViewLots.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dataGridViewLots.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewLots.Location = new System.Drawing.Point(14, 19);
            this.dataGridViewLots.MultiSelect = false;
            this.dataGridViewLots.Name = "dataGridViewLots";
            this.dataGridViewLots.RowHeadersVisible = false;
            this.dataGridViewLots.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewLots.ShowCellErrors = false;
            this.dataGridViewLots.ShowEditingIcon = false;
            this.dataGridViewLots.ShowRowErrors = false;
            this.dataGridViewLots.Size = new System.Drawing.Size(732, 348);
            this.dataGridViewLots.TabIndex = 1;
            this.dataGridViewLots.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewLots_CellEndEdit);
            this.dataGridViewLots.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dataGridViewLots_CellPainting);
            this.dataGridViewLots.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewLots_CellValueChanged);
            // 
            // FicheAppelDeFondRepartitionIndividuelle
            // 
            this.AcceptButton = this.btnEnter;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnQuit;
            this.ClientSize = new System.Drawing.Size(784, 509);
            this.ControlBox = false;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.gbBase);
            this.Controls.Add(this.groupBox2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FicheAppelDeFondRepartitionIndividuelle";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Appel De Fond Repartition Individuelle";
            this.Load += new System.EventHandler(this.FicheAppelDeFondRepartitionIndividuelle_Load);
            this.panel1.ResumeLayout(false);
            this.gbBase.ResumeLayout(false);
            this.gbBase.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewLots)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private ImageList imageList1;
        private Panel panel1;
        private Button btnValid;
        private Button btnQuit;
        private GroupBox gbBase;
        private TextBox tbBase;
        private Label label2;
        private TextBox tbMontantActuel;
        private Label label1;
        private TextBox tbDiff;
        private Label label9;
        private TextBox tbMontantTotal;
        private Label lblTotal;
        private GroupBox groupBox2;
        private DataGridView dataGridViewLots;
        private TextBox tbGlobal;
        private Label lblGlobal;
        private Button btnEnter;
    }
}