namespace Gerance.Formulaires.Indices
{
    partial class UpdateIndiceForm
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
            this.tbLog = new System.Windows.Forms.TextBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnMaj = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // tbLog
            // 
            this.tbLog.Location = new System.Drawing.Point(12, 12);
            this.tbLog.Multiline = true;
            this.tbLog.Name = "tbLog";
            this.tbLog.ReadOnly = true;
            this.tbLog.Size = new System.Drawing.Size(402, 160);
            this.tbLog.TabIndex = 0;
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(224, 206);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "&Fermer";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnMaj
            // 
            this.btnMaj.Location = new System.Drawing.Point(126, 206);
            this.btnMaj.Name = "btnMaj";
            this.btnMaj.Size = new System.Drawing.Size(75, 23);
            this.btnMaj.TabIndex = 2;
            this.btnMaj.Text = "&Maj";
            this.btnMaj.UseVisualStyleBackColor = true;
            this.btnMaj.Click += new System.EventHandler(this.btnMaj_Click);
            // 
            // UpdateIndiceForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(426, 241);
            this.Controls.Add(this.btnMaj);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.tbLog);
            this.Name = "UpdateIndiceForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Mise à jour Indices";
            this.Load += new System.EventHandler(this.UpdateIndiceForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbLog;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnMaj;
    }
}