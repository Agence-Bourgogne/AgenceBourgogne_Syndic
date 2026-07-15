using System.ComponentModel;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;

namespace EspaceSyndic.Impressions.Budget
{
    partial class ImprimerBudgetForm
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
            ComponentResourceManager resources = new ComponentResourceManager(typeof(ImprimerBudgetForm));
            ReportDataSource reportDataSource1 = new ReportDataSource();
            imageList1 = new ImageList(components);
            groupBox3 = new GroupBox();
            cbExercice = new ComboBox();
            label4 = new Label();
            dtEdition = new DateTimePicker();
            label3 = new Label();
            dtFin = new DateTimePicker();
            label2 = new Label();
            dtDeb = new DateTimePicker();
            label1 = new Label();
            tbRefImmeuble = new TextBox();
            lblImmeuble = new Label();
            reportViewer1 = new ReportViewer();
            panelButton = new Panel();
            btnEnter = new Button();
            btnRapport = new Button();
            btnQuit = new Button();
            groupBox3.SuspendLayout();
            panelButton.SuspendLayout();
            SuspendLayout();
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
            // 
            // groupBox3
            // 
            groupBox3.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            groupBox3.Controls.Add(cbExercice);
            groupBox3.Controls.Add(label4);
            groupBox3.Controls.Add(dtEdition);
            groupBox3.Controls.Add(label3);
            groupBox3.Controls.Add(dtFin);
            groupBox3.Controls.Add(label2);
            groupBox3.Controls.Add(dtDeb);
            groupBox3.Controls.Add(label1);
            groupBox3.Controls.Add(tbRefImmeuble);
            groupBox3.Controls.Add(lblImmeuble);
            groupBox3.Location = new System.Drawing.Point(14, 14);
            groupBox3.Margin = new Padding(4);
            groupBox3.Name = "groupBox3";
            groupBox3.Padding = new Padding(4);
            groupBox3.Size = new System.Drawing.Size(886, 66);
            groupBox3.TabIndex = 7;
            groupBox3.TabStop = false;
            // 
            // cbExercice
            // 
            cbExercice.DropDownStyle = ComboBoxStyle.DropDownList;
            cbExercice.FormattingEnabled = true;
            cbExercice.Location = new System.Drawing.Point(294, 22);
            cbExercice.Margin = new Padding(4);
            cbExercice.Name = "cbExercice";
            cbExercice.Size = new System.Drawing.Size(89, 23);
            cbExercice.TabIndex = 12;
            cbExercice.SelectedIndexChanged += cbExercice_SelectedIndexChanged;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new System.Drawing.Point(231, 25);
            label4.Margin = new Padding(4, 0, 4, 0);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(49, 15);
            label4.TabIndex = 11;
            label4.Text = "&Exercice";
            // 
            // dtEdition
            // 
            dtEdition.Format = DateTimePickerFormat.Short;
            dtEdition.Location = new System.Drawing.Point(770, 22);
            dtEdition.Margin = new Padding(4);
            dtEdition.Name = "dtEdition";
            dtEdition.Size = new System.Drawing.Size(98, 23);
            dtEdition.TabIndex = 10;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(718, 25);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(44, 15);
            label3.TabIndex = 9;
            label3.Text = "&Edition";
            // 
            // dtFin
            // 
            dtFin.Enabled = false;
            dtFin.Format = DateTimePickerFormat.Short;
            dtFin.Location = new System.Drawing.Point(606, 22);
            dtFin.Margin = new Padding(4);
            dtFin.Name = "dtFin";
            dtFin.Size = new System.Drawing.Size(98, 23);
            dtFin.TabIndex = 8;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(571, 25);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(22, 15);
            label2.TabIndex = 7;
            label2.Text = "&Au";
            // 
            // dtDeb
            // 
            dtDeb.Enabled = false;
            dtDeb.Format = DateTimePickerFormat.Short;
            dtDeb.Location = new System.Drawing.Point(466, 23);
            dtDeb.Margin = new Padding(4);
            dtDeb.Name = "dtDeb";
            dtDeb.Size = new System.Drawing.Size(98, 23);
            dtDeb.TabIndex = 6;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(428, 26);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(22, 15);
            label1.TabIndex = 5;
            label1.Text = "&Du";
            // 
            // tbRefImmeuble
            // 
            tbRefImmeuble.Location = new System.Drawing.Point(102, 22);
            tbRefImmeuble.Margin = new Padding(4);
            tbRefImmeuble.Name = "tbRefImmeuble";
            tbRefImmeuble.Size = new System.Drawing.Size(82, 23);
            tbRefImmeuble.TabIndex = 4;
            tbRefImmeuble.DoubleClick += lblImmeuble_Click;
            // 
            // lblImmeuble
            // 
            lblImmeuble.AutoSize = true;
            lblImmeuble.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            lblImmeuble.ForeColor = System.Drawing.Color.Blue;
            lblImmeuble.Location = new System.Drawing.Point(13, 25);
            lblImmeuble.Margin = new Padding(4, 0, 4, 0);
            lblImmeuble.Name = "lblImmeuble";
            lblImmeuble.Size = new System.Drawing.Size(55, 13);
            lblImmeuble.TabIndex = 3;
            lblImmeuble.Text = "&Immeuble:";
            lblImmeuble.Click += lblImmeuble_Click;
            // 
            // reportViewer1
            // 
            reportViewer1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            reportViewer1.IsDocumentMapWidthFixed = true;
            reportDataSource1.Name = "Immeuble";
            reportDataSource1.Value = null;
            reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            reportViewer1.LocalReport.ReportEmbeddedResource = "EspaceSyndic.Impressions.Budget.TableauComptableAnnexe3.rdlc";
            reportViewer1.Location = new System.Drawing.Point(15, 94);
            reportViewer1.Margin = new Padding(4);
            reportViewer1.Name = "reportViewer1";
            reportViewer1.PageCountMode = PageCountMode.Actual;
            reportViewer1.ServerReport.BearerToken = null;
            reportViewer1.ShowFindControls = false;
            reportViewer1.Size = new System.Drawing.Size(885, 612);
            reportViewer1.TabIndex = 8;
            // 
            // panelButton
            // 
            panelButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panelButton.BorderStyle = BorderStyle.Fixed3D;
            panelButton.Controls.Add(btnEnter);
            panelButton.Controls.Add(btnRapport);
            panelButton.Controls.Add(btnQuit);
            panelButton.Location = new System.Drawing.Point(14, 728);
            panelButton.Margin = new Padding(4);
            panelButton.Name = "panelButton";
            panelButton.Size = new System.Drawing.Size(886, 41);
            panelButton.TabIndex = 9;
            // 
            // btnEnter
            // 
            btnEnter.Location = new System.Drawing.Point(398, 5);
            btnEnter.Margin = new Padding(4);
            btnEnter.Name = "btnEnter";
            btnEnter.Size = new System.Drawing.Size(88, 26);
            btnEnter.TabIndex = 121;
            btnEnter.Text = "button1";
            btnEnter.UseVisualStyleBackColor = true;
            // 
            // btnRapport
            // 
            btnRapport.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnRapport.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            btnRapport.ImageIndex = 6;
            btnRapport.ImageList = imageList1;
            btnRapport.Location = new System.Drawing.Point(7, 6);
            btnRapport.Margin = new Padding(4);
            btnRapport.Name = "btnRapport";
            btnRapport.Size = new System.Drawing.Size(116, 29);
            btnRapport.TabIndex = 87;
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
            btnQuit.Location = new System.Drawing.Point(762, 6);
            btnQuit.Margin = new Padding(4);
            btnQuit.Name = "btnQuit";
            btnQuit.Size = new System.Drawing.Size(116, 29);
            btnQuit.TabIndex = 86;
            btnQuit.Text = "&Quitter";
            btnQuit.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            btnQuit.UseVisualStyleBackColor = true;
            // 
            // ImprimerBudgetForm
            // 
            AcceptButton = btnEnter;
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = btnQuit;
            ClientSize = new System.Drawing.Size(914, 784);
            Controls.Add(panelButton);
            Controls.Add(reportViewer1);
            Controls.Add(groupBox3);
            Margin = new Padding(4);
            Name = "ImprimerBudgetForm";
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "Imprimer Budget";
            Load += ImprimerBudgetForm_Load;
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            panelButton.ResumeLayout(false);
            ResumeLayout(false);

        }

        #endregion

        protected ImageList imageList1;
        protected GroupBox groupBox3;
        private DateTimePicker dtEdition;
        private Label label3;
        private DateTimePicker dtFin;
        private Label label2;
        private DateTimePicker dtDeb;
        private Label label1;
        protected TextBox tbRefImmeuble;
        protected Label lblImmeuble;
        private ReportViewer reportViewer1;
        private Panel panelButton;
        private Button btnEnter;
        private Button btnRapport;
        private Button btnQuit;
        private ComboBox cbExercice;
        private Label label4;
    }
}