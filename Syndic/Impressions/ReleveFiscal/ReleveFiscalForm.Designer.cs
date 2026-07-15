using System.ComponentModel;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;

namespace EspaceSyndic.Impressions.ReleveFiscal
{
    partial class ReleveFiscalForm
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
            ReportDataSource reportDataSource1 = new ReportDataSource();
            ComponentResourceManager resources = new ComponentResourceManager(typeof(ReleveFiscalForm));
            immeublecoproBindingSource = new BindingSource(components);
            syndicDataset = new syndicDataset();
            groupBox3 = new GroupBox();
            tbLot = new TextBox();
            lblLot = new Label();
            dtEdition = new DateTimePicker();
            label3 = new Label();
            dtFin = new DateTimePicker();
            label2 = new Label();
            dtDebut = new DateTimePicker();
            label1 = new Label();
            tbRefImmeuble = new TextBox();
            lblImmeuble = new Label();
            reportViewer1 = new ReportViewer();
            panelButton = new Panel();
            imageList1 = new ImageList(components);
            btnEnter = new Button();
            btnRapport = new Button();
            btnQuit = new Button();
            ((ISupportInitialize)immeublecoproBindingSource).BeginInit();
            ((ISupportInitialize)syndicDataset).BeginInit();
            groupBox3.SuspendLayout();
            panelButton.SuspendLayout();
            SuspendLayout();
            // 
            // immeublecoproBindingSource
            // 
            immeublecoproBindingSource.DataMember = "immeuble_copro";
            immeublecoproBindingSource.DataSource = syndicDataset;
            // 
            // syndicDataset
            // 
            syndicDataset.DataSetName = "syndicDataset";
            syndicDataset.Namespace = "http://tempuri.org/syndicDataset.xsd";
            syndicDataset.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // groupBox3
            // 
            groupBox3.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            groupBox3.Controls.Add(tbLot);
            groupBox3.Controls.Add(lblLot);
            groupBox3.Controls.Add(dtEdition);
            groupBox3.Controls.Add(label3);
            groupBox3.Controls.Add(dtFin);
            groupBox3.Controls.Add(label2);
            groupBox3.Controls.Add(dtDebut);
            groupBox3.Controls.Add(label1);
            groupBox3.Controls.Add(tbRefImmeuble);
            groupBox3.Controls.Add(lblImmeuble);
            groupBox3.Location = new System.Drawing.Point(14, 14);
            groupBox3.Margin = new Padding(4, 3, 4, 3);
            groupBox3.Name = "groupBox3";
            groupBox3.Padding = new Padding(4, 3, 4, 3);
            groupBox3.Size = new System.Drawing.Size(887, 66);
            groupBox3.TabIndex = 0;
            groupBox3.TabStop = false;
            // 
            // tbLot
            // 
            tbLot.Location = new System.Drawing.Point(219, 22);
            tbLot.Margin = new Padding(4, 3, 4, 3);
            tbLot.Name = "tbLot";
            tbLot.Size = new System.Drawing.Size(82, 23);
            tbLot.TabIndex = 3;
            tbLot.KeyPress += tbRefImmeuble_KeyPress;
            tbLot.Validating += tbLot_Validating;
            // 
            // lblLot
            // 
            lblLot.AutoSize = true;
            lblLot.ForeColor = System.Drawing.Color.Blue;
            lblLot.Location = new System.Drawing.Point(187, 25);
            lblLot.Margin = new Padding(4, 0, 4, 0);
            lblLot.Name = "lblLot";
            lblLot.Size = new System.Drawing.Size(24, 15);
            lblLot.TabIndex = 2;
            lblLot.Text = "Lot";
            lblLot.Click += lblLot_Click;
            // 
            // dtEdition
            // 
            dtEdition.Format = DateTimePickerFormat.Short;
            dtEdition.Location = new System.Drawing.Point(770, 22);
            dtEdition.Margin = new Padding(4, 3, 4, 3);
            dtEdition.Name = "dtEdition";
            dtEdition.Size = new System.Drawing.Size(98, 23);
            dtEdition.TabIndex = 9;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(718, 25);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(44, 15);
            label3.TabIndex = 8;
            label3.Text = "&Edition";
            // 
            // dtFin
            // 
            dtFin.Format = DateTimePickerFormat.Short;
            dtFin.Location = new System.Drawing.Point(611, 22);
            dtFin.Margin = new Padding(4, 3, 4, 3);
            dtFin.Name = "dtFin";
            dtFin.Size = new System.Drawing.Size(98, 23);
            dtFin.TabIndex = 7;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(572, 29);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(23, 15);
            label2.TabIndex = 6;
            label2.Text = "&Fin";
            // 
            // dtDebut
            // 
            dtDebut.Format = DateTimePickerFormat.Short;
            dtDebut.Location = new System.Drawing.Point(384, 22);
            dtDebut.Margin = new Padding(4, 3, 4, 3);
            dtDebut.Name = "dtDebut";
            dtDebut.Size = new System.Drawing.Size(98, 23);
            dtDebut.TabIndex = 5;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(327, 25);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(42, 15);
            label1.TabIndex = 4;
            label1.Text = "&Début ";
            // 
            // tbRefImmeuble
            // 
            tbRefImmeuble.Location = new System.Drawing.Point(75, 22);
            tbRefImmeuble.Margin = new Padding(4, 3, 4, 3);
            tbRefImmeuble.Name = "tbRefImmeuble";
            tbRefImmeuble.Size = new System.Drawing.Size(82, 23);
            tbRefImmeuble.TabIndex = 1;
            tbRefImmeuble.DoubleClick += lblImmeuble_Click;
            tbRefImmeuble.KeyPress += tbRefImmeuble_KeyPress;
            tbRefImmeuble.Validating += tbRefImmeuble_Validating;
            // 
            // lblImmeuble
            // 
            lblImmeuble.AutoSize = true;
            lblImmeuble.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            lblImmeuble.ForeColor = System.Drawing.Color.Blue;
            lblImmeuble.Location = new System.Drawing.Point(6, 25);
            lblImmeuble.Margin = new Padding(4, 0, 4, 0);
            lblImmeuble.Name = "lblImmeuble";
            lblImmeuble.Size = new System.Drawing.Size(55, 13);
            lblImmeuble.TabIndex = 0;
            lblImmeuble.Text = "&Immeuble:";
            lblImmeuble.Click += lblImmeuble_Click;
            // 
            // reportViewer1
            // 
            reportViewer1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            reportViewer1.IsDocumentMapWidthFixed = true;
            reportDataSource1.Name = "immeuble_copro";
            reportDataSource1.Value = immeublecoproBindingSource;
            reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            reportViewer1.LocalReport.ReportEmbeddedResource = "EspaceSyndic.Impressions.ReleveFiscal.ReleveFiscalMasterReport.rdlc";
            reportViewer1.Location = new System.Drawing.Point(15, 93);
            reportViewer1.Margin = new Padding(4, 3, 4, 3);
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
            panelButton.Location = new System.Drawing.Point(15, 729);
            panelButton.Margin = new Padding(4, 3, 4, 3);
            panelButton.Name = "panelButton";
            panelButton.Size = new System.Drawing.Size(886, 40);
            panelButton.TabIndex = 1;
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
            // btnEnter
            // 
            btnEnter.Location = new System.Drawing.Point(398, 5);
            btnEnter.Margin = new Padding(4, 3, 4, 3);
            btnEnter.Name = "btnEnter";
            btnEnter.Size = new System.Drawing.Size(88, 27);
            btnEnter.TabIndex = 1;
            btnEnter.Text = "button1";
            btnEnter.UseVisualStyleBackColor = true;
            btnEnter.Click += btnEnter_Click;
            // 
            // btnRapport
            // 
            btnRapport.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnRapport.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            btnRapport.ImageIndex = 6;
            btnRapport.ImageList = imageList1;
            btnRapport.Location = new System.Drawing.Point(7, 5);
            btnRapport.Margin = new Padding(4, 3, 4, 3);
            btnRapport.Name = "btnRapport";
            btnRapport.Size = new System.Drawing.Size(117, 29);
            btnRapport.TabIndex = 0;
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
            btnQuit.Location = new System.Drawing.Point(762, 5);
            btnQuit.Margin = new Padding(4, 3, 4, 3);
            btnQuit.Name = "btnQuit";
            btnQuit.Size = new System.Drawing.Size(117, 29);
            btnQuit.TabIndex = 2;
            btnQuit.Text = "&Quitter";
            btnQuit.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            btnQuit.UseVisualStyleBackColor = true;
            // 
            // ReleveFiscalForm
            // 
            AcceptButton = btnEnter;
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = btnQuit;
            ClientSize = new System.Drawing.Size(915, 783);
            Controls.Add(panelButton);
            Controls.Add(reportViewer1);
            Controls.Add(groupBox3);
            ForeColor = System.Drawing.SystemColors.ControlText;
            Margin = new Padding(4, 3, 4, 3);
            Name = "ReleveFiscalForm";
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "Releve Fiscal";
            Load += ReleveFiscalForm_Load;
            ((ISupportInitialize)immeublecoproBindingSource).EndInit();
            ((ISupportInitialize)syndicDataset).EndInit();
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            panelButton.ResumeLayout(false);
            ResumeLayout(false);

        }

        #endregion

        protected GroupBox groupBox3;
        private DateTimePicker dtEdition;
        private Label label3;
        private DateTimePicker dtFin;
        private Label label2;
        private DateTimePicker dtDebut;
        private Label label1;
        protected TextBox tbRefImmeuble;
        protected Label lblImmeuble;
        private ReportViewer reportViewer1;
        protected TextBox tbLot;
        private Label lblLot;
        private Panel panelButton;
        private Button btnRapport;
        private Button btnQuit;
        private syndicDataset syndicDataset;
        private BindingSource immeublecoproBindingSource;
        protected ImageList imageList1;
        private Button btnEnter;
    }
}