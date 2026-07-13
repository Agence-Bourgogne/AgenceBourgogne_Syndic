using System.ComponentModel;
using System.Windows.Forms;

namespace EspaceSyndic.Formulaires.Common
{
    partial class LogForm
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
            this.rtLog = new System.Windows.Forms.RichTextBox();
            this.BtnClose = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // rtLog
            // 
            this.rtLog.Location = new System.Drawing.Point(25, 23);
            this.rtLog.Name = "rtLog";
            this.rtLog.Size = new System.Drawing.Size(503, 269);
            this.rtLog.TabIndex = 0;
            this.rtLog.Text = "";
            // 
            // BtnClose
            // 
            this.BtnClose.Location = new System.Drawing.Point(231, 306);
            this.BtnClose.Name = "BtnClose";
            this.BtnClose.Size = new System.Drawing.Size(75, 23);
            this.BtnClose.TabIndex = 1;
            this.BtnClose.Text = "Fermer";
            this.BtnClose.UseVisualStyleBackColor = true;
            this.BtnClose.Click += new System.EventHandler(this.BtnClose_Click);
            // 
            // LogForm
            // 
            this.ClientSize = new System.Drawing.Size(560, 341);
            this.Controls.Add(this.BtnClose);
            this.Controls.Add(this.rtLog);
            this.Name = "LogForm";
            this.Text = "Informations";
            this.ResumeLayout(false);

        }

        #endregion

        public RichTextBox rtLog;
        private Button BtnClose;


    }
}