namespace Gerance.Formulaires.Locataires
{
    partial class LocataireListeForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LocataireListeForm));
            this.btnFiltre = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
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
            // panel1
            // 
            this.panel1.Controls.Add(this.btnFiltre);
            this.panel1.Controls.SetChildIndex(this.btnSave, 0);
            this.panel1.Controls.SetChildIndex(this.btnEdit, 0);
            this.panel1.Controls.SetChildIndex(this.btnQuit, 0);
            this.panel1.Controls.SetChildIndex(this.btnNew, 0);
            this.panel1.Controls.SetChildIndex(this.btnFiche, 0);
            this.panel1.Controls.SetChildIndex(this.btnExport, 0);
            this.panel1.Controls.SetChildIndex(this.btnFiltre, 0);
            // 
            // btnFiltre
            // 
            this.btnFiltre.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnFiltre.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnFiltre.ImageKey = "zoom.png";
            this.btnFiltre.ImageList = this.imageList;
            this.btnFiltre.Location = new System.Drawing.Point(533, 4);
            this.btnFiltre.Name = "btnFiltre";
            this.btnFiltre.Size = new System.Drawing.Size(100, 25);
            this.btnFiltre.TabIndex = 95;
            this.btnFiltre.Text = "F&iltre";
            this.btnFiltre.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnFiltre.UseVisualStyleBackColor = true;
            this.btnFiltre.Click += new System.EventHandler(this.btnFiltre_Click);
            // 
            // LocataireListeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(784, 562);
            this.Name = "LocataireListeForm";
            this.Text = "Liste Locataires";
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnFiltre;
    }
}
