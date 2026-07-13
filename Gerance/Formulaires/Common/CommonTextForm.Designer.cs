namespace Gerance.Formulaires.Common
{
    partial class CommonTextForm
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
            this.tbText = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cancel = new System.Windows.Forms.Button();
            this.valid = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbText
            // 
            this.tbText.AcceptsReturn = true;
            this.tbText.AcceptsTab = true;
            this.tbText.Location = new System.Drawing.Point(13, 13);
            this.tbText.Multiline = true;
            this.tbText.Name = "tbText";
            this.tbText.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tbText.Size = new System.Drawing.Size(349, 136);
            this.tbText.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.cancel);
            this.panel1.Controls.Add(this.valid);
            this.panel1.Location = new System.Drawing.Point(13, 160);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(349, 35);
            this.panel1.TabIndex = 103;
            // 
            // cancel
            // 
            this.cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancel.Location = new System.Drawing.Point(173, 4);
            this.cancel.Name = "cancel";
            this.cancel.Size = new System.Drawing.Size(75, 23);
            this.cancel.TabIndex = 4;
            this.cancel.Text = "&Annuler";
            this.cancel.UseVisualStyleBackColor = true;
            // 
            // valid
            // 
            this.valid.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.valid.Location = new System.Drawing.Point(90, 4);
            this.valid.Name = "valid";
            this.valid.Size = new System.Drawing.Size(75, 23);
            this.valid.TabIndex = 3;
            this.valid.Text = "&Valider";
            this.valid.UseVisualStyleBackColor = true;
            // 
            // CommonTextForm
            // 
            this.AcceptButton = this.valid;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancel;
            this.ClientSize = new System.Drawing.Size(374, 207);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.tbText);
            this.Name = "CommonTextForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "CommonTextForm";
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.TextBox tbText;
        protected System.Windows.Forms.Panel panel1;
        protected System.Windows.Forms.Button cancel;
        protected System.Windows.Forms.Button valid;
    }
}