namespace EspaceSyndic.Formulaires.OperationsGestion
{
    partial class MarquerPayeeDialog
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
            lblInfo = new System.Windows.Forms.Label();
            btnAnnuler = new System.Windows.Forms.Button();
            btnValider = new System.Windows.Forms.Button();
            label1 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            richTextBox1 = new System.Windows.Forms.RichTextBox();
            SuspendLayout();
            // 
            // lblInfo
            // 
            lblInfo.AutoSize = true;
            lblInfo.Location = new System.Drawing.Point(13, 9);
            lblInfo.Name = "lblInfo";
            lblInfo.Size = new System.Drawing.Size(103, 15);
            lblInfo.TabIndex = 0;
            lblInfo.Text = "descriptionfacture";
            // 
            // btnAnnuler
            // 
            btnAnnuler.Location = new System.Drawing.Point(12, 179);
            btnAnnuler.Name = "btnAnnuler";
            btnAnnuler.Size = new System.Drawing.Size(75, 23);
            btnAnnuler.TabIndex = 1;
            btnAnnuler.Text = "Annuler";
            btnAnnuler.UseVisualStyleBackColor = true;
            btnAnnuler.Click += btnAnnuler_Click;
            // 
            // btnValider
            // 
            btnValider.Location = new System.Drawing.Point(480, 179);
            btnValider.Name = "btnValider";
            btnValider.Size = new System.Drawing.Size(75, 23);
            btnValider.TabIndex = 2;
            btnValider.Text = "Valider";
            btnValider.UseVisualStyleBackColor = true;
            btnValider.Click += btnValider_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(12, 54);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(104, 15);
            label1.TabIndex = 3;
            label1.Text = "Date de règlement";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(12, 83);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(80, 15);
            label2.TabIndex = 4;
            label2.Text = "Commentaire";
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Location = new System.Drawing.Point(132, 48);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new System.Drawing.Size(200, 23);
            dateTimePicker1.TabIndex = 5;
            // 
            // richTextBox1
            // 
            richTextBox1.Location = new System.Drawing.Point(132, 77);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.Size = new System.Drawing.Size(423, 96);
            richTextBox1.TabIndex = 6;
            richTextBox1.Text = "";
            // 
            // MarquerPayeeDialog
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(563, 206);
            Controls.Add(richTextBox1);
            Controls.Add(dateTimePicker1);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(btnValider);
            Controls.Add(btnAnnuler);
            Controls.Add(lblInfo);
            Name = "MarquerPayeeDialog";
            Text = "MarquerPayeeDialog";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblInfo;
        private System.Windows.Forms.Button btnAnnuler;
        private System.Windows.Forms.Button btnValider;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.RichTextBox richTextBox1;
    }
}