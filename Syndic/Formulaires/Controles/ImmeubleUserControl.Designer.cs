namespace EspaceSyndic.Formulaires.Controles
{
    partial class ImmeubleUserControl
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

        #region Code généré par le Concepteur de composants

        /// <summary> 
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas 
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.tbRefImmeuble = new System.Windows.Forms.TextBox();
            this.lblImmeuble = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // tbRefImmeuble
            // 
            this.tbRefImmeuble.Location = new System.Drawing.Point(82, 0);
            this.tbRefImmeuble.Name = "tbRefImmeuble";
            this.tbRefImmeuble.Size = new System.Drawing.Size(93, 20);
            this.tbRefImmeuble.TabIndex = 4;
            this.tbRefImmeuble.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbRefImmeuble_KeyPress);
            this.tbRefImmeuble.Validating += new System.ComponentModel.CancelEventHandler(this.tbRefImmeuble_Validating);
            // 
            // lblImmeuble
            // 
            this.lblImmeuble.AutoSize = true;
            this.lblImmeuble.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblImmeuble.ForeColor = System.Drawing.Color.Blue;
            this.lblImmeuble.Location = new System.Drawing.Point(0, 3);
            this.lblImmeuble.Name = "lblImmeuble";
            this.lblImmeuble.Size = new System.Drawing.Size(55, 13);
            this.lblImmeuble.TabIndex = 3;
            this.lblImmeuble.Text = "&Immeuble:";
            this.lblImmeuble.Click += new System.EventHandler(this.lblImmeuble_Click);
            // 
            // ImmeubleUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tbRefImmeuble);
            this.Controls.Add(this.lblImmeuble);
            this.Name = "ImmeubleUserControl";
            this.Size = new System.Drawing.Size(175, 20);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.TextBox tbRefImmeuble;
        public System.Windows.Forms.Label lblImmeuble;
    }
}
