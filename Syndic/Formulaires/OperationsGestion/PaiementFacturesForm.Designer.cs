namespace EspaceSyndic.Formulaires.OperationsGestion
{
    partial class PaiementFacturesForm
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
            dgvFactures = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgvFactures).BeginInit();
            SuspendLayout();
            // 
            // dgvFactures
            // 
            dgvFactures.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvFactures.Location = new System.Drawing.Point(12, 12);
            dgvFactures.Name = "dgvFactures";
            dgvFactures.Size = new System.Drawing.Size(776, 426);
            dgvFactures.TabIndex = 0;
            // 
            // PaiementFacturesForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(800, 450);
            Controls.Add(dgvFactures);
            Name = "PaiementFacturesForm";
            Text = "Paiement des factures";
            ((System.ComponentModel.ISupportInitialize)dgvFactures).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.DataGridView dgvFactures;
    }
}