using System.ComponentModel;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;

namespace EspaceSyndic.Impressions.RelevesComptes
{
    partial class ReleveCompteCoproPrintForm
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
            components = new Container();
            ComponentResourceManager resources = new ComponentResourceManager(typeof(ReleveCompteCoproPrintForm));
            gbParams = new GroupBox();
            cbLot = new ComboBox();
            label1 = new Label();
            tbRefImmeuble = new TextBox();
            lblImmeuble = new Label();
            imageList1 = new ImageList(components);
            panel1 = new Panel();
            btnRapport = new Button();
            btnQuit = new Button();
            btnEnter = new Button();
            reportViewer1 = new ReportViewer();
            gbParams.SuspendLayout();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // gbParams
            // 
            gbParams.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            gbParams.Controls.Add(cbLot);
            gbParams.Controls.Add(label1);
            gbParams.Controls.Add(tbRefImmeuble);
            gbParams.Controls.Add(lblImmeuble);
            gbParams.Location = new System.Drawing.Point(14, 14);
            gbParams.Margin = new Padding(4, 3, 4, 3);
            gbParams.Name = "gbParams";
            gbParams.Padding = new Padding(4, 3, 4, 3);
            gbParams.Size = new System.Drawing.Size(887, 76);
            gbParams.TabIndex = 3;
            gbParams.TabStop = false;
            // 
            // cbLot
            // 
            cbLot.DropDownStyle = ComboBoxStyle.DropDownList;
            cbLot.FormattingEnabled = true;
            cbLot.Location = new System.Drawing.Point(436, 28);
            cbLot.Margin = new Padding(4, 3, 4, 3);
            cbLot.Name = "cbLot";
            cbLot.Size = new System.Drawing.Size(433, 23);
            cbLot.TabIndex = 6;
            cbLot.SelectedIndexChanged += cbLot_SelectedIndexChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(376, 31);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(24, 15);
            label1.TabIndex = 5;
            label1.Text = "&Lot";
            // 
            // tbRefImmeuble
            // 
            tbRefImmeuble.Location = new System.Drawing.Point(96, 28);
            tbRefImmeuble.Margin = new Padding(4, 3, 4, 3);
            tbRefImmeuble.Name = "tbRefImmeuble";
            tbRefImmeuble.Size = new System.Drawing.Size(75, 23);
            tbRefImmeuble.TabIndex = 2;
            tbRefImmeuble.DoubleClick += tbRefImmeuble_DoubleClick;
            tbRefImmeuble.Validating += tbRefImmeuble_Validating;
            // 
            // lblImmeuble
            // 
            lblImmeuble.AutoSize = true;
            lblImmeuble.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            lblImmeuble.ForeColor = System.Drawing.Color.Blue;
            lblImmeuble.Location = new System.Drawing.Point(7, 31);
            lblImmeuble.Margin = new Padding(4, 0, 4, 0);
            lblImmeuble.Name = "lblImmeuble";
            lblImmeuble.Size = new System.Drawing.Size(55, 13);
            lblImmeuble.TabIndex = 1;
            lblImmeuble.Text = "&Immeuble:";
            lblImmeuble.Click += tbRefImmeuble_DoubleClick;
            // 
            // imageList1
            // 
            imageList1.ColorDepth = ColorDepth.Depth8Bit;
            imageList1.ImageStream = (ImageListStreamer)resources.GetObject("imageList1.ImageStream");
            imageList1.TransparentColor = System.Drawing.Color.Silver;
            imageList1.Images.SetKeyName(0, "top.png");
            imageList1.Images.SetKeyName(1, "bottom.png");
            imageList1.Images.SetKeyName(2, "previous.png");
            imageList1.Images.SetKeyName(3, "next.png");
            imageList1.Images.SetKeyName(4, "save.png");
            imageList1.Images.SetKeyName(5, "quit.png");
            imageList1.Images.SetKeyName(6, "print.png");
            imageList1.Images.SetKeyName(7, "add.png");
            imageList1.Images.SetKeyName(8, "zoom.png");
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel1.BorderStyle = BorderStyle.Fixed3D;
            panel1.Controls.Add(btnRapport);
            panel1.Controls.Add(btnQuit);
            panel1.Controls.Add(btnEnter);
            panel1.Location = new System.Drawing.Point(14, 736);
            panel1.Margin = new Padding(4, 3, 4, 3);
            panel1.Name = "panel1";
            panel1.Size = new System.Drawing.Size(886, 44);
            panel1.TabIndex = 22;
            // 
            // btnRapport
            // 
            btnRapport.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnRapport.CausesValidation = false;
            btnRapport.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            btnRapport.ImageIndex = 6;
            btnRapport.ImageList = imageList1;
            btnRapport.Location = new System.Drawing.Point(16, 7);
            btnRapport.Margin = new Padding(4, 3, 4, 3);
            btnRapport.Name = "btnRapport";
            btnRapport.Size = new System.Drawing.Size(117, 29);
            btnRapport.TabIndex = 13;
            btnRapport.TabStop = false;
            btnRapport.Text = "&Rapport";
            btnRapport.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            btnRapport.UseVisualStyleBackColor = true;
            btnRapport.Click += btnRapport_Click;
            // 
            // btnQuit
            // 
            btnQuit.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnQuit.CausesValidation = false;
            btnQuit.DialogResult = DialogResult.Cancel;
            btnQuit.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            btnQuit.ImageIndex = 5;
            btnQuit.ImageList = imageList1;
            btnQuit.Location = new System.Drawing.Point(751, 7);
            btnQuit.Margin = new Padding(4, 3, 4, 3);
            btnQuit.Name = "btnQuit";
            btnQuit.Size = new System.Drawing.Size(117, 29);
            btnQuit.TabIndex = 9;
            btnQuit.TabStop = false;
            btnQuit.Text = "&Quitter";
            btnQuit.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            btnQuit.UseVisualStyleBackColor = true;
            // 
            // btnEnter
            // 
            btnEnter.Location = new System.Drawing.Point(463, 7);
            btnEnter.Margin = new Padding(4, 3, 4, 3);
            btnEnter.Name = "btnEnter";
            btnEnter.Size = new System.Drawing.Size(88, 27);
            btnEnter.TabIndex = 12;
            btnEnter.Text = "button1";
            btnEnter.UseVisualStyleBackColor = true;
            btnEnter.Click += btnEnter_Click;
            // 
            // reportViewer1
            // 
            reportViewer1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            reportViewer1.LocalReport.ReportEmbeddedResource = "EspaceSyndic.Impressions.RelevesComptes.ReleveCompteReport.rdlc";
            reportViewer1.Location = new System.Drawing.Point(14, 97);
            reportViewer1.Margin = new Padding(4, 3, 4, 3);
            reportViewer1.Name = "reportViewer1";
            reportViewer1.ServerReport.BearerToken = null;
            reportViewer1.Size = new System.Drawing.Size(886, 619);
            reportViewer1.TabIndex = 23;
            // 
            // ReleveCompteCoproPrintForm
            // 
            AcceptButton = btnEnter;
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = btnQuit;
            ClientSize = new System.Drawing.Size(912, 795);
            Controls.Add(reportViewer1);
            Controls.Add(panel1);
            Controls.Add(gbParams);
            Margin = new Padding(4, 3, 4, 3);
            Name = "ReleveCompteCoproPrintForm";
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "Releve Compte Coproprietaire";
            Load += ReleveIndividuelPrintForm_Load;
            gbParams.ResumeLayout(false);
            gbParams.PerformLayout();
            panel1.ResumeLayout(false);
            ResumeLayout(false);

        }

        #endregion

        private GroupBox gbParams;
        private TextBox tbRefImmeuble;
        private Label lblImmeuble;
        private ImageList imageList1;
        private Panel panel1;
        private Button btnRapport;
        private Button btnQuit;
        private Button btnEnter;
        private ReportViewer reportViewer1;
        private ComboBox cbLot;
        private Label label1;
    }
}