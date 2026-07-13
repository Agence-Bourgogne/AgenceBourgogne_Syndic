using System.ComponentModel;
using System.Windows.Forms;

namespace EspaceSyndic.Formulaires.OperationsGestion
{
    partial class ModificationLotForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ModificationLotForm));
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnValid = new System.Windows.Forms.Button();
            this.btnQuit = new System.Windows.Forms.Button();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.cbLot = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tbRefImmeuble = new System.Windows.Forms.TextBox();
            this.lblImmeuble = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.btnValid);
            this.panel1.Controls.Add(this.btnQuit);
            this.panel1.Location = new System.Drawing.Point(10, 92);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(449, 39);
            this.panel1.TabIndex = 22;
            // 
            // btnValid
            // 
            this.btnValid.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnValid.CausesValidation = false;
            this.btnValid.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnValid.ImageIndex = 7;
            this.btnValid.ImageList = this.imageList1;
            this.btnValid.Location = new System.Drawing.Point(9, 6);
            this.btnValid.Name = "btnValid";
            this.btnValid.Size = new System.Drawing.Size(100, 25);
            this.btnValid.TabIndex = 13;
            this.btnValid.TabStop = false;
            this.btnValid.Text = "&Valider";
            this.btnValid.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnValid.UseVisualStyleBackColor = true;
            this.btnValid.Click += new System.EventHandler(this.btnValid_Click);
            // 
            // btnQuit
            // 
            this.btnQuit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnQuit.CausesValidation = false;
            this.btnQuit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnQuit.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnQuit.ImageIndex = 5;
            this.btnQuit.ImageList = this.imageList1;
            this.btnQuit.Location = new System.Drawing.Point(333, 6);
            this.btnQuit.Name = "btnQuit";
            this.btnQuit.Size = new System.Drawing.Size(100, 25);
            this.btnQuit.TabIndex = 9;
            this.btnQuit.TabStop = false;
            this.btnQuit.Text = "&Quitter";
            this.btnQuit.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnQuit.UseVisualStyleBackColor = true;
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Silver;
            this.imageList1.Images.SetKeyName(0, "top.png");
            this.imageList1.Images.SetKeyName(1, "bottom.png");
            this.imageList1.Images.SetKeyName(2, "previous.png");
            this.imageList1.Images.SetKeyName(3, "next.png");
            this.imageList1.Images.SetKeyName(4, "save.png");
            this.imageList1.Images.SetKeyName(5, "quit.png");
            this.imageList1.Images.SetKeyName(6, "print.png");
            this.imageList1.Images.SetKeyName(7, "add.png");
            this.imageList1.Images.SetKeyName(8, "excel.png");
            this.imageList1.Images.SetKeyName(9, "zoom.png");
            // 
            // cbLot
            // 
            this.cbLot.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbLot.FormattingEnabled = true;
            this.cbLot.Location = new System.Drawing.Point(89, 47);
            this.cbLot.Name = "cbLot";
            this.cbLot.Size = new System.Drawing.Size(372, 21);
            this.cbLot.TabIndex = 26;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(22, 13);
            this.label1.TabIndex = 25;
            this.label1.Text = "&Lot";
            // 
            // tbRefImmeuble
            // 
            this.tbRefImmeuble.Enabled = false;
            this.tbRefImmeuble.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.tbRefImmeuble.Location = new System.Drawing.Point(89, 21);
            this.tbRefImmeuble.Name = "tbRefImmeuble";
            this.tbRefImmeuble.ReadOnly = true;
            this.tbRefImmeuble.Size = new System.Drawing.Size(65, 20);
            this.tbRefImmeuble.TabIndex = 24;
            // 
            // lblImmeuble
            // 
            this.lblImmeuble.AutoSize = true;
            this.lblImmeuble.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblImmeuble.ForeColor = System.Drawing.Color.Blue;
            this.lblImmeuble.Location = new System.Drawing.Point(13, 24);
            this.lblImmeuble.Name = "lblImmeuble";
            this.lblImmeuble.Size = new System.Drawing.Size(55, 13);
            this.lblImmeuble.TabIndex = 23;
            this.lblImmeuble.Text = "&Immeuble:";
            // 
            // ModificationLotForm
            // 
            this.AcceptButton = this.btnValid;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnQuit;
            this.ClientSize = new System.Drawing.Size(471, 143);
            this.ControlBox = false;
            this.Controls.Add(this.cbLot);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbRefImmeuble);
            this.Controls.Add(this.lblImmeuble);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ModificationLotForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Modification Lot";
            this.Load += new System.EventHandler(this.ModificationLotForm_Load);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Panel panel1;
        private Button btnValid;
        public Button btnQuit;
        private ImageList imageList1;
        private ComboBox cbLot;
        private Label label1;
        private TextBox tbRefImmeuble;
        private Label lblImmeuble;
    }
}