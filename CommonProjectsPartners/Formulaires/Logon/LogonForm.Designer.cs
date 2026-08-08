using System.ComponentModel;
using System.Windows.Forms;

namespace CommonProjectsPartners.Formulaires.Logon
{
    partial class LogonForm
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
            label1 = new Label();
            tbUser = new TextBox();
            tbPassword = new TextBox();
            label2 = new Label();
            btnValid = new Button();
            pictureBox1 = new PictureBox();
            labelMessage = new Label();
            ((ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = System.Drawing.Color.Transparent;
            label1.Location = new System.Drawing.Point(240, 85);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(60, 15);
            label1.TabIndex = 0;
            label1.Text = "&Utilisateur";
            // 
            // tbUser
            // 
            tbUser.CausesValidation = false;
            tbUser.CharacterCasing = CharacterCasing.Upper;
            tbUser.Location = new System.Drawing.Point(340, 82);
            tbUser.Margin = new Padding(4, 3, 4, 3);
            tbUser.Name = "tbUser";
            tbUser.Size = new System.Drawing.Size(174, 23);
            tbUser.TabIndex = 1;
            tbUser.TextChanged += tbUser_TextChanged;
            // 
            // tbPassword
            // 
            tbPassword.Location = new System.Drawing.Point(340, 112);
            tbPassword.Margin = new Padding(4, 3, 4, 3);
            tbPassword.Name = "tbPassword";
            tbPassword.PasswordChar = '*';
            tbPassword.Size = new System.Drawing.Size(174, 23);
            tbPassword.TabIndex = 3;
            tbPassword.TextChanged += tbUser_TextChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = System.Drawing.Color.Transparent;
            label2.Location = new System.Drawing.Point(240, 115);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(77, 15);
            label2.TabIndex = 2;
            label2.Text = "&Mot de Passe";
            // 
            // btnValid
            // 
            btnValid.BackColor = System.Drawing.SystemColors.Control;
            btnValid.Location = new System.Drawing.Point(340, 155);
            btnValid.Margin = new Padding(4, 3, 4, 3);
            btnValid.Name = "btnValid";
            btnValid.Size = new System.Drawing.Size(175, 23);
            btnValid.TabIndex = 4;
            btnValid.Text = "&Valider";
            btnValid.UseVisualStyleBackColor = false;
            btnValid.Click += IDOK_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = System.Drawing.Color.White;
            pictureBox1.Image = Properties.Resources.stop2;
            pictureBox1.Location = new System.Drawing.Point(493, 20);
            pictureBox1.Margin = new Padding(4, 3, 4, 3);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new System.Drawing.Size(19, 18);
            pictureBox1.TabIndex = 5;
            pictureBox1.TabStop = false;
            pictureBox1.Click += pictureBox1_Click;
            // 
            // labelMessage
            // 
            labelMessage.AutoSize = true;
            labelMessage.BackColor = System.Drawing.Color.White;
            labelMessage.Location = new System.Drawing.Point(199, 49);
            labelMessage.Name = "labelMessage";
            labelMessage.Size = new System.Drawing.Size(0, 15);
            labelMessage.TabIndex = 6;
            // 
            // LogonForm
            // 
            AcceptButton = btnValid;
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = System.Drawing.Color.FromArgb(255, 224, 192);
            BackgroundImage = Properties.Resources.login;
            BackgroundImageLayout = ImageLayout.None;
            ClientSize = new System.Drawing.Size(614, 231);
            ControlBox = false;
            Controls.Add(labelMessage);
            Controls.Add(pictureBox1);
            Controls.Add(btnValid);
            Controls.Add(tbPassword);
            Controls.Add(label2);
            Controls.Add(tbUser);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(4, 3, 4, 3);
            Name = "LogonForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Identification";
            TransparencyKey = System.Drawing.Color.FromArgb(255, 224, 192);
            FormClosing += LogonForm_FormClosing;
            Load += LogonForm_Load;
            ((ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion

        private Label label1;
        private TextBox tbUser;
        private TextBox tbPassword;
        private Label label2;
        private Button btnValid;
        private PictureBox pictureBox1;
        private Label labelMessage;
    }
}