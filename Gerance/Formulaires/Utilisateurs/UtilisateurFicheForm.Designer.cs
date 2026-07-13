namespace Gerance.Formulaires.Utilisateurs
{
    partial class UtilisateurFicheForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UtilisateurFicheForm));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cbRole = new System.Windows.Forms.ComboBox();
            this.tbPassword = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tbPrenom = new System.Windows.Forms.TextBox();
            this.lblPrenom = new System.Windows.Forms.Label();
            this.tbNom = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tbReference = new System.Windows.Forms.TextBox();
            this.lblReference = new System.Windows.Forms.Label();
            this.ckPassword = new System.Windows.Forms.CheckBox();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(10, 129);
            // 
            // btnEnter
            // 
            this.btnEnter.Size = new System.Drawing.Size(0, 23);
            // 
            // btnLast
            // 
            this.btnLast.Visible = true;
            // 
            // btnNext
            // 
            this.btnNext.Visible = true;
            // 
            // btnPrev
            // 
            this.btnPrev.Visible = true;
            // 
            // btnFirst
            // 
            this.btnFirst.Visible = true;
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.Images.SetKeyName(0, "top.png");
            this.imageList1.Images.SetKeyName(1, "bottom.png");
            this.imageList1.Images.SetKeyName(2, "previous.png");
            this.imageList1.Images.SetKeyName(3, "next.png");
            this.imageList1.Images.SetKeyName(4, "save.png");
            this.imageList1.Images.SetKeyName(5, "quit.png");
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.ckPassword);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.cbRole);
            this.groupBox1.Controls.Add(this.tbPassword);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.tbPrenom);
            this.groupBox1.Controls.Add(this.lblPrenom);
            this.groupBox1.Controls.Add(this.tbNom);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.tbReference);
            this.groupBox1.Controls.Add(this.lblReference);
            this.groupBox1.Location = new System.Drawing.Point(10, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(760, 104);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "&Role:";
            // 
            // cbRole
            // 
            this.cbRole.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbRole.FormattingEnabled = true;
            this.cbRole.Location = new System.Drawing.Point(82, 65);
            this.cbRole.Name = "cbRole";
            this.cbRole.Size = new System.Drawing.Size(283, 21);
            this.cbRole.TabIndex = 9;
            this.cbRole.SelectedIndexChanged += new System.EventHandler(this.cbRole_SelectedIndexChanged);
            // 
            // tbPassword
            // 
            this.tbPassword.Location = new System.Drawing.Point(459, 13);
            this.tbPassword.Name = "tbPassword";
            this.tbPassword.Size = new System.Drawing.Size(283, 20);
            this.tbPassword.TabIndex = 3;
            this.tbPassword.UseSystemPasswordChar = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(385, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "&Mot de Passe:";
            // 
            // tbPrenom
            // 
            this.tbPrenom.Location = new System.Drawing.Point(459, 39);
            this.tbPrenom.Name = "tbPrenom";
            this.tbPrenom.Size = new System.Drawing.Size(283, 20);
            this.tbPrenom.TabIndex = 7;
            // 
            // lblPrenom
            // 
            this.lblPrenom.AutoSize = true;
            this.lblPrenom.Location = new System.Drawing.Point(385, 42);
            this.lblPrenom.Name = "lblPrenom";
            this.lblPrenom.Size = new System.Drawing.Size(46, 13);
            this.lblPrenom.TabIndex = 6;
            this.lblPrenom.Text = "&Prénom:";
            // 
            // tbNom
            // 
            this.tbNom.Location = new System.Drawing.Point(82, 39);
            this.tbNom.Name = "tbNom";
            this.tbNom.Size = new System.Drawing.Size(283, 20);
            this.tbNom.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 42);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(32, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "&Nom:";
            // 
            // tbReference
            // 
            this.tbReference.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tbReference.Location = new System.Drawing.Point(82, 13);
            this.tbReference.Name = "tbReference";
            this.tbReference.Size = new System.Drawing.Size(283, 20);
            this.tbReference.TabIndex = 1;
            this.tbReference.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbReference_KeyDown);
            // 
            // lblReference
            // 
            this.lblReference.AutoSize = true;
            this.lblReference.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblReference.Location = new System.Drawing.Point(6, 16);
            this.lblReference.Name = "lblReference";
            this.lblReference.Size = new System.Drawing.Size(53, 13);
            this.lblReference.TabIndex = 0;
            this.lblReference.Text = "&Utilisateur";
            this.lblReference.Click += new System.EventHandler(this.lblReference_Click);
            // 
            // ckPassword
            // 
            this.ckPassword.AutoSize = true;
            this.ckPassword.Checked = true;
            this.ckPassword.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ckPassword.Location = new System.Drawing.Point(389, 68);
            this.ckPassword.Name = "ckPassword";
            this.ckPassword.Size = new System.Drawing.Size(137, 17);
            this.ckPassword.TabIndex = 10;
            this.ckPassword.Text = "&Cacher le mot de passe";
            this.ckPassword.UseVisualStyleBackColor = true;
            this.ckPassword.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // UtilisateurFicheForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(784, 182);
            this.Controls.Add(this.groupBox1);
            this.Name = "UtilisateurFicheForm";
            this.Text = "Fiche Utilisateur";
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.panel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        protected System.Windows.Forms.TextBox tbPassword;
        protected System.Windows.Forms.Label label1;
        protected System.Windows.Forms.TextBox tbPrenom;
        protected System.Windows.Forms.Label lblPrenom;
        protected System.Windows.Forms.TextBox tbNom;
        protected System.Windows.Forms.Label label4;
        protected System.Windows.Forms.TextBox tbReference;
        protected System.Windows.Forms.Label lblReference;
        protected System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbRole;
        private System.Windows.Forms.CheckBox ckPassword;
    }
}
