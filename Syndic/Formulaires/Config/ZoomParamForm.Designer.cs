using System.ComponentModel;
using System.Windows.Forms;

namespace EspaceSyndic.Formulaires.Config
{
    partial class ZoomParamForm
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnEnter = new System.Windows.Forms.Button();
            this.cancel = new System.Windows.Forms.Button();
            this.btnValid = new System.Windows.Forms.Button();
            this.tbComment = new System.Windows.Forms.RichTextBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.btnEnter);
            this.panel1.Controls.Add(this.cancel);
            this.panel1.Controls.Add(this.btnValid);
            this.panel1.Location = new System.Drawing.Point(12, 246);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(486, 35);
            this.panel1.TabIndex = 105;
            // 
            // btnEnter
            // 
            this.btnEnter.Location = new System.Drawing.Point(365, 5);
            this.btnEnter.Name = "btnEnter";
            this.btnEnter.Size = new System.Drawing.Size(75, 23);
            this.btnEnter.TabIndex = 7;
            this.btnEnter.Text = "button1";
            this.btnEnter.UseVisualStyleBackColor = true;
            // 
            // cancel
            // 
            this.cancel.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancel.Location = new System.Drawing.Point(260, 5);
            this.cancel.Name = "cancel";
            this.cancel.Size = new System.Drawing.Size(75, 23);
            this.cancel.TabIndex = 6;
            this.cancel.Text = "&Annuler";
            this.cancel.UseVisualStyleBackColor = true;
            // 
            // btnValid
            // 
            this.btnValid.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnValid.Location = new System.Drawing.Point(177, 5);
            this.btnValid.Name = "btnValid";
            this.btnValid.Size = new System.Drawing.Size(75, 23);
            this.btnValid.TabIndex = 5;
            this.btnValid.Text = "Enregi&strer";
            this.btnValid.UseVisualStyleBackColor = true;
            this.btnValid.Click += new System.EventHandler(this.btnValid_Click);
            // 
            // tbComment
            // 
            this.tbComment.AcceptsTab = true;
            this.tbComment.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbComment.CausesValidation = false;
            this.tbComment.Font = new System.Drawing.Font("Arial", 10F);
            this.tbComment.Location = new System.Drawing.Point(12, 12);
            this.tbComment.Name = "tbComment";
            this.tbComment.Size = new System.Drawing.Size(486, 227);
            this.tbComment.TabIndex = 104;
            this.tbComment.TabStop = false;
            this.tbComment.Text = "";
            // 
            // ZoomParamForm
            // 
            this.AcceptButton = this.btnValid;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancel;
            this.ClientSize = new System.Drawing.Size(510, 293);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.tbComment);
            this.Name = "ZoomParamForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Zoom";
            this.Load += new System.EventHandler(this.ZoomParamForm_Load);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Panel panel1;
        private Button btnEnter;
        private Button cancel;
        private Button btnValid;
        private RichTextBox tbComment;
    }
}