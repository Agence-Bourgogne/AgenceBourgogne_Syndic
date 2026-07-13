namespace Gerance.Formulaires.Reglements
{
    partial class RéglementProprietairesSyndicForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RéglementProprietairesSyndicForm));
            this.reglement = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.cbMonth = new System.Windows.Forms.ComboBox();
            this.ckAll = new System.Windows.Forms.CheckBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.panelButton.SuspendLayout();
            this.gbHeader.SuspendLayout();
            this.gbFactures.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelButton
            // 
            this.panelButton.Controls.Add(this.btnSave);
            this.panelButton.Controls.SetChildIndex(this.btnQuit, 0);
            this.panelButton.Controls.SetChildIndex(this.btnEnter, 0);
            this.panelButton.Controls.SetChildIndex(this.btnGrid, 0);
            this.panelButton.Controls.SetChildIndex(this.btnExport, 0);
            this.panelButton.Controls.SetChildIndex(this.btnDetail, 0);
            this.panelButton.Controls.SetChildIndex(this.btnSave, 0);
            // 
            // btnEnter
            // 
            this.btnEnter.Size = new System.Drawing.Size(0, 23);
            // 
            // gbHeader
            // 
            this.gbHeader.Controls.Add(this.cbMonth);
            this.gbHeader.Controls.Add(this.label1);
            // 
            // imageList
            // 
            this.imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList.ImageStream")));
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
            this.imageList.Images.SetKeyName(10, "zoom.png");
            // 
            // btnDetail
            // 
            this.btnDetail.Visible = false;
            // 
            // btnExport
            // 
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // gbFactures
            // 
            this.gbFactures.Controls.Add(this.ckAll);
            this.gbFactures.Controls.SetChildIndex(this.ckAll, 0);
            // 
            // reglement
            // 
            this.reglement.HeaderText = "Réglement";
            this.reglement.Name = "reglement";
            this.reglement.ReadOnly = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "&Pour le mois ";
            // 
            // cbMonth
            // 
            this.cbMonth.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbMonth.FormattingEnabled = true;
            this.cbMonth.Location = new System.Drawing.Point(93, 24);
            this.cbMonth.Name = "cbMonth";
            this.cbMonth.Size = new System.Drawing.Size(136, 21);
            this.cbMonth.TabIndex = 9;
            this.cbMonth.SelectedIndexChanged += new System.EventHandler(this.cbMonth_SelectedIndexChanged);
            // 
            // ckAll
            // 
            this.ckAll.AutoSize = true;
            this.ckAll.Location = new System.Drawing.Point(14, 518);
            this.ckAll.Name = "ckAll";
            this.ckAll.Size = new System.Drawing.Size(85, 17);
            this.ckAll.TabIndex = 1;
            this.ckAll.Text = "Tout Cocher";
            this.ckAll.UseVisualStyleBackColor = true;
            this.ckAll.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // btnSave
            // 
            this.btnSave.CausesValidation = false;
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSave.ImageIndex = 4;
            this.btnSave.ImageList = this.imageList;
            this.btnSave.Location = new System.Drawing.Point(567, 5);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(80, 25);
            this.btnSave.TabIndex = 19;
            this.btnSave.Text = "&Générer";
            this.btnSave.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.UseVisualStyleBackColor = true;
            // 
            // RéglementProprietairesSyndicForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(784, 679);
            this.Name = "RéglementProprietairesSyndicForm";
            this.Text = "Réglements Propprietaires Syndic";
            this.panelButton.ResumeLayout(false);
            this.gbHeader.ResumeLayout(false);
            this.gbHeader.PerformLayout();
            this.gbFactures.ResumeLayout(false);
            this.gbFactures.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbMonth;
//        private System.Windows.Forms.DataGridViewCheckBoxColumn relance;
        private System.Windows.Forms.CheckBox ckAll;
        private System.Windows.Forms.DataGridViewCheckBoxColumn reglement;
        protected System.Windows.Forms.Button btnSave;

    }
}
