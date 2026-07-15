using System.ComponentModel;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;

namespace EspaceSyndic.Impressions.AppelDeFond
{
    partial class ImprimerAppelDeFondForm
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
            ComponentResourceManager resources = new ComponentResourceManager(typeof(ImprimerAppelDeFondForm));
            immeublecoproBindingSource = new BindingSource(components);
            groupBox3 = new GroupBox();
            ckFerie = new CheckBox();
            lbParametres = new Label();
            label2 = new Label();
            dtFin = new DateTimePicker();
            dtDeb = new DateTimePicker();
            label1 = new Label();
            dtEntete = new DateTimePicker();
            tbLot = new TextBox();
            lblLot = new Label();
            tbRefImmeuble = new TextBox();
            lblImmeuble = new Label();
            tbText = new RichTextBox();
            label3 = new Label();
            reportViewer1 = new ReportViewer();
            imageList1 = new ImageList(components);
            panelButton = new Panel();
            btnListe = new Button();
            btnEnter = new Button();
            btnRapport = new Button();
            btnQuit = new Button();
            dataGridView = new DataGridView();
            ((ISupportInitialize)immeublecoproBindingSource).BeginInit();
            groupBox3.SuspendLayout();
            panelButton.SuspendLayout();
            ((ISupportInitialize)dataGridView).BeginInit();
            SuspendLayout();
            // 
            // groupBox3
            // 
            groupBox3.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            groupBox3.Controls.Add(ckFerie);
            groupBox3.Controls.Add(lbParametres);
            groupBox3.Controls.Add(label2);
            groupBox3.Controls.Add(dtFin);
            groupBox3.Controls.Add(dtDeb);
            groupBox3.Controls.Add(label1);
            groupBox3.Controls.Add(dtEntete);
            groupBox3.Controls.Add(tbLot);
            groupBox3.Controls.Add(lblLot);
            groupBox3.Controls.Add(tbRefImmeuble);
            groupBox3.Controls.Add(lblImmeuble);
            groupBox3.Controls.Add(tbText);
            groupBox3.Controls.Add(label3);
            groupBox3.Location = new System.Drawing.Point(15, 14);
            groupBox3.Margin = new Padding(4);
            groupBox3.Name = "groupBox3";
            groupBox3.Padding = new Padding(4);
            groupBox3.Size = new System.Drawing.Size(890, 137);
            groupBox3.TabIndex = 0;
            groupBox3.TabStop = false;
            // 
            // ckFerie
            // 
            ckFerie.AutoSize = true;
            ckFerie.Location = new System.Drawing.Point(241, 50);
            ckFerie.Margin = new Padding(4);
            ckFerie.Name = "ckFerie";
            ckFerie.Size = new System.Drawing.Size(51, 19);
            ckFerie.TabIndex = 14;
            ckFerie.Text = "Férié";
            ckFerie.UseVisualStyleBackColor = true;
            ckFerie.CheckedChanged += ckFerie_CheckedChanged;
            // 
            // lbParametres
            // 
            lbParametres.AutoSize = true;
            lbParametres.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            lbParametres.ForeColor = System.Drawing.Color.Blue;
            lbParametres.Location = new System.Drawing.Point(237, 25);
            lbParametres.Margin = new Padding(4, 0, 4, 0);
            lbParametres.Name = "lbParametres";
            lbParametres.Size = new System.Drawing.Size(63, 13);
            lbParametres.TabIndex = 13;
            lbParametres.Text = "&Paramètres:";
            lbParametres.Click += lbParametres_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(211, 106);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(20, 15);
            label2.TabIndex = 12;
            label2.Text = "&au";
            // 
            // dtFin
            // 
            dtFin.Format = DateTimePickerFormat.Short;
            dtFin.Location = new System.Drawing.Point(241, 104);
            dtFin.Margin = new Padding(4);
            dtFin.Name = "dtFin";
            dtFin.Size = new System.Drawing.Size(98, 23);
            dtFin.TabIndex = 11;
            // 
            // dtDeb
            // 
            dtDeb.Format = DateTimePickerFormat.Short;
            dtDeb.Location = new System.Drawing.Point(109, 104);
            dtDeb.Margin = new Padding(4);
            dtDeb.Name = "dtDeb";
            dtDeb.Size = new System.Drawing.Size(98, 23);
            dtDeb.TabIndex = 10;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.ForeColor = System.Drawing.Color.Blue;
            label1.Location = new System.Drawing.Point(21, 106);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(72, 15);
            label1.TabIndex = 9;
            label1.Text = "&Ecritures du:";
            label1.Click += label1_Click;
            // 
            // dtEntete
            // 
            dtEntete.Format = DateTimePickerFormat.Short;
            dtEntete.Location = new System.Drawing.Point(109, 76);
            dtEntete.Margin = new Padding(4);
            dtEntete.Name = "dtEntete";
            dtEntete.Size = new System.Drawing.Size(98, 23);
            dtEntete.TabIndex = 8;
            // 
            // tbLot
            // 
            tbLot.Location = new System.Drawing.Point(109, 47);
            tbLot.Margin = new Padding(4);
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
            lblLot.Location = new System.Drawing.Point(21, 51);
            lblLot.Margin = new Padding(4, 0, 4, 0);
            lblLot.Name = "lblLot";
            lblLot.Size = new System.Drawing.Size(24, 15);
            lblLot.TabIndex = 2;
            lblLot.Text = "&Lot";
            lblLot.Click += lblLot_Click;
            // 
            // tbRefImmeuble
            // 
            tbRefImmeuble.Location = new System.Drawing.Point(109, 22);
            tbRefImmeuble.Margin = new Padding(4);
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
            lblImmeuble.Location = new System.Drawing.Point(21, 25);
            lblImmeuble.Margin = new Padding(4, 0, 4, 0);
            lblImmeuble.Name = "lblImmeuble";
            lblImmeuble.Size = new System.Drawing.Size(60, 13);
            lblImmeuble.TabIndex = 0;
            lblImmeuble.Text = "&Immeubles:";
            lblImmeuble.Click += lblImmeuble_Click;
            // 
            // tbText
            // 
            tbText.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            tbText.Location = new System.Drawing.Point(363, 22);
            tbText.Margin = new Padding(4);
            tbText.Name = "tbText";
            tbText.Size = new System.Drawing.Size(504, 102);
            tbText.TabIndex = 8;
            tbText.TabStop = false;
            tbText.Text = "";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(21, 79);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(70, 15);
            label3.TabIndex = 6;
            label3.Text = "&Date Entete:";
            // 
            // reportViewer1
            // 
            reportViewer1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            reportViewer1.IsDocumentMapWidthFixed = true;
            reportDataSource1.Name = "copro_immeuble";
            reportDataSource1.Value = immeublecoproBindingSource;
            reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            reportViewer1.LocalReport.ReportEmbeddedResource = "EspaceSyndic.Impressions.AppelDeFond.AppelDeFondMasterReport.rdlc";
            reportViewer1.Location = new System.Drawing.Point(15, 158);
            reportViewer1.Margin = new Padding(4);
            reportViewer1.Name = "reportViewer1";
            reportViewer1.PageCountMode = PageCountMode.Actual;
            reportViewer1.ServerReport.BearerToken = null;
            reportViewer1.ShowFindControls = false;
            reportViewer1.Size = new System.Drawing.Size(885, 557);
            reportViewer1.TabIndex = 1;
            reportViewer1.ReportExport += reportViewer1_ReportExport;
            reportViewer1.RenderingComplete += reportViewer1_RenderingComplete;
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
            imageList1.Images.SetKeyName(7, "loupe.png");
            // 
            // panelButton
            // 
            panelButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panelButton.BorderStyle = BorderStyle.Fixed3D;
            panelButton.Controls.Add(btnListe);
            panelButton.Controls.Add(btnEnter);
            panelButton.Controls.Add(btnRapport);
            panelButton.Controls.Add(btnQuit);
            panelButton.Location = new System.Drawing.Point(15, 729);
            panelButton.Margin = new Padding(4);
            panelButton.Name = "panelButton";
            panelButton.Size = new System.Drawing.Size(886, 40);
            panelButton.TabIndex = 2;
            // 
            // btnListe
            // 
            btnListe.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnListe.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            btnListe.ImageIndex = 7;
            btnListe.ImageList = imageList1;
            btnListe.Location = new System.Drawing.Point(130, 3);
            btnListe.Margin = new Padding(4);
            btnListe.Name = "btnListe";
            btnListe.Size = new System.Drawing.Size(116, 29);
            btnListe.TabIndex = 1;
            btnListe.Text = "&Choisir";
            btnListe.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            btnListe.UseVisualStyleBackColor = true;
            btnListe.Click += btnListe_Click;
            // 
            // btnEnter
            // 
            btnEnter.Location = new System.Drawing.Point(482, 4);
            btnEnter.Margin = new Padding(4);
            btnEnter.Name = "btnEnter";
            btnEnter.Size = new System.Drawing.Size(88, 26);
            btnEnter.TabIndex = 119;
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
            btnRapport.Margin = new Padding(4);
            btnRapport.Name = "btnRapport";
            btnRapport.Size = new System.Drawing.Size(116, 29);
            btnRapport.TabIndex = 0;
            btnRapport.Text = "&Rapport";
            btnRapport.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            btnRapport.UseVisualStyleBackColor = true;
            btnRapport.Click += btnPrint_Click;
            // 
            // btnQuit
            // 
            btnQuit.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnQuit.CausesValidation = false;
            btnQuit.DialogResult = DialogResult.Cancel;
            btnQuit.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            btnQuit.ImageIndex = 5;
            btnQuit.ImageList = imageList1;
            btnQuit.Location = new System.Drawing.Point(759, 5);
            btnQuit.Margin = new Padding(4);
            btnQuit.Name = "btnQuit";
            btnQuit.Size = new System.Drawing.Size(116, 29);
            btnQuit.TabIndex = 3;
            btnQuit.Text = "&Quitter";
            btnQuit.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            btnQuit.UseVisualStyleBackColor = true;
            // 
            // dataGridView
            // 
            dataGridView.AllowUserToAddRows = false;
            dataGridView.AllowUserToDeleteRows = false;
            dataGridView.AllowUserToOrderColumns = true;
            dataGridView.AllowUserToResizeRows = false;
            dataGridView.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView.EditMode = DataGridViewEditMode.EditOnKeystroke;
            dataGridView.Location = new System.Drawing.Point(14, 158);
            dataGridView.Margin = new Padding(4);
            dataGridView.MultiSelect = false;
            dataGridView.Name = "dataGridView";
            dataGridView.ReadOnly = true;
            dataGridView.RowHeadersVisible = false;
            dataGridView.RowHeadersWidth = 51;
            dataGridView.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView.Size = new System.Drawing.Size(886, 557);
            dataGridView.TabIndex = 2;
            dataGridView.Visible = false;
            // 
            // ImprimerAppelDeFondForm
            // 
            AcceptButton = btnEnter;
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = btnQuit;
            ClientSize = new System.Drawing.Size(914, 784);
            Controls.Add(dataGridView);
            Controls.Add(panelButton);
            Controls.Add(reportViewer1);
            Controls.Add(groupBox3);
            KeyPreview = true;
            Margin = new Padding(4);
            Name = "ImprimerAppelDeFondForm";
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "23";
            Load += ValidAppelDeFondForm_Load;
            ((ISupportInitialize)immeublecoproBindingSource).EndInit();
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            panelButton.ResumeLayout(false);
            ((ISupportInitialize)dataGridView).EndInit();
            ResumeLayout(false);

        }

        #endregion

        protected GroupBox groupBox3;
        protected Label label3;
        private RichTextBox tbText;
        private ReportViewer reportViewer1;
        protected TextBox tbRefImmeuble;
        protected Label lblImmeuble;
        protected ImageList imageList1;
        private Panel panelButton;
        private Button btnRapport;
        private Button btnQuit;
        protected TextBox tbLot;
        private Label lblLot;
        private BindingSource immeublecoproBindingSource;
        private Button btnEnter;
        private Label label2;
        private DateTimePicker dtFin;
        private DateTimePicker dtDeb;
        protected Label label1;
        private DateTimePicker dtEntete;
        private Button btnListe;
        private DataGridView dataGridView;
        protected Label lbParametres;
        private CheckBox ckFerie;
    }
}