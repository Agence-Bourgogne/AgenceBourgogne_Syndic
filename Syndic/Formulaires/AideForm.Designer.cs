namespace EspaceSyndic.Formulaires
{
    partial class AideForm
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
            this.tbAide = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // tbAide
            // 
            this.tbAide.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbAide.Location = new System.Drawing.Point(12, 12);
            this.tbAide.Name = "tbAide";
            this.tbAide.ReadOnly = true;
            this.tbAide.Size = new System.Drawing.Size(518, 382);
            this.tbAide.TabIndex = 0;
            this.tbAide.Text = "";
            // 
            // AideForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(542, 406);
            this.Controls.Add(this.tbAide);
            this.Name = "AideForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Aide";
            this.Load += new System.EventHandler(this.AideForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox tbAide;
    }
}