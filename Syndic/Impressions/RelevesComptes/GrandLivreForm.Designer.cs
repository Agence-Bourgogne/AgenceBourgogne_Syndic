namespace EspaceSyndic.Impressions.RelevesComptes
{
    partial class GrandLivreForm
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
            anneeMinimale = new System.Windows.Forms.NumericUpDown();
            anneesLabelDebut = new System.Windows.Forms.Label();
            anneesLabelMiddle = new System.Windows.Forms.Label();
            anneeMaximale = new System.Windows.Forms.NumericUpDown();
            exercices = new System.Windows.Forms.DataGridView();
            editerBtn = new System.Windows.Forms.Button();
            progressExport = new System.Windows.Forms.ProgressBar();
            ((System.ComponentModel.ISupportInitialize)anneeMinimale).BeginInit();
            ((System.ComponentModel.ISupportInitialize)anneeMaximale).BeginInit();
            ((System.ComponentModel.ISupportInitialize)exercices).BeginInit();
            SuspendLayout();
            // 
            // anneeMinimale
            // 
            anneeMinimale.Location = new System.Drawing.Point(105, 11);
            anneeMinimale.Maximum = new decimal(new int[] { 2099, 0, 0, 0 });
            anneeMinimale.Minimum = new decimal(new int[] { 2000, 0, 0, 0 });
            anneeMinimale.Name = "anneeMinimale";
            anneeMinimale.Size = new System.Drawing.Size(120, 23);
            anneeMinimale.TabIndex = 0;
            anneeMinimale.Value = new decimal(new int[] { 2000, 0, 0, 0 });
            // 
            // anneesLabelDebut
            // 
            anneesLabelDebut.AutoSize = true;
            anneesLabelDebut.Location = new System.Drawing.Point(12, 13);
            anneesLabelDebut.Name = "anneesLabelDebut";
            anneesLabelDebut.Size = new System.Drawing.Size(87, 15);
            anneesLabelDebut.TabIndex = 1;
            anneesLabelDebut.Text = "Exercices entre ";
            // 
            // anneesLabelMiddle
            // 
            anneesLabelMiddle.AutoSize = true;
            anneesLabelMiddle.Location = new System.Drawing.Point(244, 13);
            anneesLabelMiddle.Name = "anneesLabelMiddle";
            anneesLabelMiddle.Size = new System.Drawing.Size(17, 15);
            anneesLabelMiddle.TabIndex = 2;
            anneesLabelMiddle.Text = "et";
            // 
            // anneeMaximale
            // 
            anneeMaximale.Location = new System.Drawing.Point(289, 11);
            anneeMaximale.Maximum = new decimal(new int[] { 2100, 0, 0, 0 });
            anneeMaximale.Minimum = new decimal(new int[] { 2001, 0, 0, 0 });
            anneeMaximale.Name = "anneeMaximale";
            anneeMaximale.Size = new System.Drawing.Size(120, 23);
            anneeMaximale.TabIndex = 1;
            anneeMaximale.Value = new decimal(new int[] { 2100, 0, 0, 0 });
            // 
            // exercices
            // 
            exercices.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            exercices.Location = new System.Drawing.Point(12, 40);
            exercices.Name = "exercices";
            exercices.Size = new System.Drawing.Size(776, 398);
            exercices.TabIndex = 3;
            // 
            // editerBtn
            // 
            editerBtn.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            editerBtn.AutoSize = true;
            editerBtn.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            editerBtn.Enabled = false;
            editerBtn.Location = new System.Drawing.Point(741, 8);
            editerBtn.Name = "editerBtn";
            editerBtn.Size = new System.Drawing.Size(47, 25);
            editerBtn.TabIndex = 4;
            editerBtn.Text = "Éditer";
            editerBtn.UseVisualStyleBackColor = true;
            editerBtn.Click += editerBtn_Click;
            // 
            // progressExport
            // 
            progressExport.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            progressExport.Location = new System.Drawing.Point(12, 40);
            progressExport.Name = "progressExport";
            progressExport.Size = new System.Drawing.Size(776, 23);
            progressExport.TabIndex = 5;
            progressExport.Visible = false;
            // 
            // GrandLivreForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(800, 450);
            Controls.Add(progressExport);
            Controls.Add(editerBtn);
            Controls.Add(exercices);
            Controls.Add(anneeMaximale);
            Controls.Add(anneesLabelMiddle);
            Controls.Add(anneesLabelDebut);
            Controls.Add(anneeMinimale);
            Name = "GrandLivreForm";
            Text = "Édition du Grand Livre";
            ((System.ComponentModel.ISupportInitialize)anneeMinimale).EndInit();
            ((System.ComponentModel.ISupportInitialize)anneeMaximale).EndInit();
            ((System.ComponentModel.ISupportInitialize)exercices).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.NumericUpDown anneeMinimale;
        private System.Windows.Forms.Label anneesLabelDebut;
        private System.Windows.Forms.Label anneesLabelMiddle;
        private System.Windows.Forms.NumericUpDown anneeMaximale;
        private System.Windows.Forms.DataGridView exercices;
        private System.Windows.Forms.Button editerBtn;
        private System.Windows.Forms.ProgressBar progressExport;
    }
}