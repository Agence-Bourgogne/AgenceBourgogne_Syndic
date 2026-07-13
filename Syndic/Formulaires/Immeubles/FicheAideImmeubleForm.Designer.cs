namespace EspaceSyndic.Formulaires.Immeubles
{
    partial class FicheAideImmeubleForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FicheAideImmeubleForm));
            this.cbTypeComment = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tbComment = new System.Windows.Forms.RichTextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnEnter = new System.Windows.Forms.Button();
            this.cancel = new System.Windows.Forms.Button();
            this.btnValid = new System.Windows.Forms.Button();
            this.tbRefImmeuble = new System.Windows.Forms.TextBox();
            this.lblImmeuble = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cbTypeComment
            // 
            this.cbTypeComment.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbTypeComment.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTypeComment.FormattingEnabled = true;
            this.cbTypeComment.Location = new System.Drawing.Point(299, 12);
            this.cbTypeComment.Name = "cbTypeComment";
            this.cbTypeComment.Size = new System.Drawing.Size(163, 21);
            this.cbTypeComment.TabIndex = 3;
            this.cbTypeComment.SelectedIndexChanged += new System.EventHandler(this.cbTypeComment_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(177, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(116, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "&Catégorie Commentaire";
            // 
            // tbComment
            // 
            this.tbComment.AcceptsTab = true;
            this.tbComment.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbComment.CausesValidation = false;
            this.tbComment.Font = new System.Drawing.Font("Arial", 10F);
            this.tbComment.Location = new System.Drawing.Point(15, 39);
            this.tbComment.Name = "tbComment";
            this.tbComment.Size = new System.Drawing.Size(447, 218);
            this.tbComment.TabIndex = 4;
            this.tbComment.TabStop = false;
            this.tbComment.Text = "";
            this.tbComment.Enter += new System.EventHandler(this.tbComment_Enter);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.btnEnter);
            this.panel1.Controls.Add(this.cancel);
            this.panel1.Controls.Add(this.btnValid);
            this.panel1.Location = new System.Drawing.Point(15, 275);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(447, 35);
            this.panel1.TabIndex = 103;
            // 
            // btnEnter
            // 
            this.btnEnter.Location = new System.Drawing.Point(365, 5);
            this.btnEnter.Name = "btnEnter";
            this.btnEnter.Size = new System.Drawing.Size(75, 23);
            this.btnEnter.TabIndex = 7;
            this.btnEnter.Text = "button1";
            this.btnEnter.UseVisualStyleBackColor = true;
            this.btnEnter.Click += new System.EventHandler(this.btnEnter_Click);
            // 
            // cancel
            // 
            this.cancel.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancel.Location = new System.Drawing.Point(240, 5);
            this.cancel.Name = "cancel";
            this.cancel.Size = new System.Drawing.Size(75, 23);
            this.cancel.TabIndex = 6;
            this.cancel.Text = "&Annuler";
            this.cancel.UseVisualStyleBackColor = true;
            this.cancel.Click += new System.EventHandler(this.cancel_Click);
            // 
            // btnValid
            // 
            this.btnValid.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnValid.Location = new System.Drawing.Point(157, 5);
            this.btnValid.Name = "btnValid";
            this.btnValid.Size = new System.Drawing.Size(75, 23);
            this.btnValid.TabIndex = 5;
            this.btnValid.Text = "Enregi&strer";
            this.btnValid.UseVisualStyleBackColor = true;
            this.btnValid.Click += new System.EventHandler(this.valid_Click);
            // 
            // tbRefImmeuble
            // 
            this.tbRefImmeuble.Location = new System.Drawing.Point(93, 12);
            this.tbRefImmeuble.Name = "tbRefImmeuble";
            this.tbRefImmeuble.Size = new System.Drawing.Size(65, 20);
            this.tbRefImmeuble.TabIndex = 1;
            this.tbRefImmeuble.DoubleClick += new System.EventHandler(this.lblImmeuble_Click);
            this.tbRefImmeuble.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbRefImmeuble_KeyPress);
            this.tbRefImmeuble.Leave += new System.EventHandler(this.tbRefImmeuble_Leave);
            // 
            // lblImmeuble
            // 
            this.lblImmeuble.AutoSize = true;
            this.lblImmeuble.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblImmeuble.ForeColor = System.Drawing.Color.Blue;
            this.lblImmeuble.Location = new System.Drawing.Point(12, 15);
            this.lblImmeuble.Name = "lblImmeuble";
            this.lblImmeuble.Size = new System.Drawing.Size(55, 13);
            this.lblImmeuble.TabIndex = 0;
            this.lblImmeuble.Text = "&Immeuble:";
            this.lblImmeuble.Click += new System.EventHandler(this.lblImmeuble_Click);
            // 
            // FicheAideImmeubleForm
            // 
            this.AcceptButton = this.btnEnter;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancel;
            this.ClientSize = new System.Drawing.Size(474, 322);
            this.Controls.Add(this.tbRefImmeuble);
            this.Controls.Add(this.lblImmeuble);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.tbComment);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbTypeComment);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FicheAideImmeubleForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Commentaire Immeuble";
            this.Load += new System.EventHandler(this.FicheCommentaireForm_Load);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        protected System.Windows.Forms.ComboBox cbTypeComment;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RichTextBox tbComment;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button cancel;
        private System.Windows.Forms.Button btnValid;
        protected System.Windows.Forms.TextBox tbRefImmeuble;
        protected System.Windows.Forms.Label lblImmeuble;
        private System.Windows.Forms.Button btnEnter;
    }
}