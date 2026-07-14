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
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource4 = new Microsoft.Reporting.WinForms.ReportDataSource();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ImprimerAppelDeFondForm));
            this.immeublecoproBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.ckFerie = new System.Windows.Forms.CheckBox();
            this.lbParametres = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dtFin = new System.Windows.Forms.DateTimePicker();
            this.dtDeb = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.dtEntete = new System.Windows.Forms.DateTimePicker();
            this.tbLot = new System.Windows.Forms.TextBox();
            this.lblLot = new System.Windows.Forms.Label();
            this.tbRefImmeuble = new System.Windows.Forms.TextBox();
            this.lblImmeuble = new System.Windows.Forms.Label();
            this.tbText = new System.Windows.Forms.RichTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.panelButton = new System.Windows.Forms.Panel();
            this.btnListe = new System.Windows.Forms.Button();
            this.btnEnter = new System.Windows.Forms.Button();
            this.btnRapport = new System.Windows.Forms.Button();
            this.btnQuit = new System.Windows.Forms.Button();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.immeublecoproBindingSource)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.panelButton.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.ckFerie);
            this.groupBox3.Controls.Add(this.lbParametres);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.dtFin);
            this.groupBox3.Controls.Add(this.dtDeb);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.dtEntete);
            this.groupBox3.Controls.Add(this.tbLot);
            this.groupBox3.Controls.Add(this.lblLot);
            this.groupBox3.Controls.Add(this.tbRefImmeuble);
            this.groupBox3.Controls.Add(this.lblImmeuble);
            this.groupBox3.Controls.Add(this.tbText);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Location = new System.Drawing.Point(17, 15);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox3.Size = new System.Drawing.Size(1017, 146);
            this.groupBox3.TabIndex = 0;
            this.groupBox3.TabStop = false;
            // 
            // ckFerie
            // 
            this.ckFerie.AutoSize = true;
            this.ckFerie.Location = new System.Drawing.Point(275, 53);
            this.ckFerie.Margin = new System.Windows.Forms.Padding(4);
            this.ckFerie.Name = "ckFerie";
            this.ckFerie.Size = new System.Drawing.Size(60, 20);
            this.ckFerie.TabIndex = 14;
            this.ckFerie.Text = "Férié";
            this.ckFerie.UseVisualStyleBackColor = true;
            this.ckFerie.CheckedChanged += new System.EventHandler(this.ckFerie_CheckedChanged);
            // 
            // lbParametres
            // 
            this.lbParametres.AutoSize = true;
            this.lbParametres.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbParametres.ForeColor = System.Drawing.Color.Blue;
            this.lbParametres.Location = new System.Drawing.Point(271, 27);
            this.lbParametres.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbParametres.Name = "lbParametres";
            this.lbParametres.Size = new System.Drawing.Size(85, 17);
            this.lbParametres.TabIndex = 13;
            this.lbParametres.Text = "&Paramètres:";
            this.lbParametres.Click += new System.EventHandler(this.lbParametres_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(241, 113);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(22, 16);
            this.label2.TabIndex = 12;
            this.label2.Text = "&au";
            // 
            // dtFin
            // 
            this.dtFin.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtFin.Location = new System.Drawing.Point(275, 111);
            this.dtFin.Margin = new System.Windows.Forms.Padding(4);
            this.dtFin.Name = "dtFin";
            this.dtFin.Size = new System.Drawing.Size(111, 22);
            this.dtFin.TabIndex = 11;
            // 
            // dtDeb
            // 
            this.dtDeb.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtDeb.Location = new System.Drawing.Point(125, 111);
            this.dtDeb.Margin = new System.Windows.Forms.Padding(4);
            this.dtDeb.Name = "dtDeb";
            this.dtDeb.Size = new System.Drawing.Size(111, 22);
            this.dtDeb.TabIndex = 10;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Blue;
            this.label1.Location = new System.Drawing.Point(24, 113);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 16);
            this.label1.TabIndex = 9;
            this.label1.Text = "&Ecritures du:";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // dtEntete
            // 
            this.dtEntete.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtEntete.Location = new System.Drawing.Point(125, 81);
            this.dtEntete.Margin = new System.Windows.Forms.Padding(4);
            this.dtEntete.Name = "dtEntete";
            this.dtEntete.Size = new System.Drawing.Size(111, 22);
            this.dtEntete.TabIndex = 8;
            // 
            // tbLot
            // 
            this.tbLot.Location = new System.Drawing.Point(125, 50);
            this.tbLot.Margin = new System.Windows.Forms.Padding(4);
            this.tbLot.Name = "tbLot";
            this.tbLot.Size = new System.Drawing.Size(93, 22);
            this.tbLot.TabIndex = 3;
            this.tbLot.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbRefImmeuble_KeyPress);
            this.tbLot.Validating += new System.ComponentModel.CancelEventHandler(this.tbLot_Validating);
            // 
            // lblLot
            // 
            this.lblLot.AutoSize = true;
            this.lblLot.ForeColor = System.Drawing.Color.Blue;
            this.lblLot.Location = new System.Drawing.Point(24, 54);
            this.lblLot.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblLot.Name = "lblLot";
            this.lblLot.Size = new System.Drawing.Size(25, 16);
            this.lblLot.TabIndex = 2;
            this.lblLot.Text = "&Lot";
            this.lblLot.Click += new System.EventHandler(this.lblLot_Click);
            // 
            // tbRefImmeuble
            // 
            this.tbRefImmeuble.Location = new System.Drawing.Point(125, 23);
            this.tbRefImmeuble.Margin = new System.Windows.Forms.Padding(4);
            this.tbRefImmeuble.Name = "tbRefImmeuble";
            this.tbRefImmeuble.Size = new System.Drawing.Size(93, 22);
            this.tbRefImmeuble.TabIndex = 1;
            this.tbRefImmeuble.DoubleClick += new System.EventHandler(this.lblImmeuble_Click);
            this.tbRefImmeuble.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbRefImmeuble_KeyPress);
            this.tbRefImmeuble.Validating += new System.ComponentModel.CancelEventHandler(this.tbRefImmeuble_Validating);
            // 
            // lblImmeuble
            // 
            this.lblImmeuble.AutoSize = true;
            this.lblImmeuble.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblImmeuble.ForeColor = System.Drawing.Color.Blue;
            this.lblImmeuble.Location = new System.Drawing.Point(24, 27);
            this.lblImmeuble.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblImmeuble.Name = "lblImmeuble";
            this.lblImmeuble.Size = new System.Drawing.Size(79, 17);
            this.lblImmeuble.TabIndex = 0;
            this.lblImmeuble.Text = "&Immeubles:";
            this.lblImmeuble.Click += new System.EventHandler(this.lblImmeuble_Click);
            // 
            // tbText
            // 
            this.tbText.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbText.Location = new System.Drawing.Point(415, 23);
            this.tbText.Margin = new System.Windows.Forms.Padding(4);
            this.tbText.Name = "tbText";
            this.tbText.Size = new System.Drawing.Size(575, 109);
            this.tbText.TabIndex = 8;
            this.tbText.TabStop = false;
            this.tbText.Text = "";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(24, 84);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 16);
            this.label3.TabIndex = 6;
            this.label3.Text = "&Date Entete:";
            // 
            // reportViewer1
            // 
            this.reportViewer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.reportViewer1.IsDocumentMapWidthFixed = true;
            reportDataSource4.Name = "copro_immeuble";
            reportDataSource4.Value = this.immeublecoproBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource4);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "EspaceSyndic.Impressions.AppelDeFond.AppelDeFondMasterReport.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(17, 169);
            this.reportViewer1.Margin = new System.Windows.Forms.Padding(4);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.PageCountMode = Microsoft.Reporting.WinForms.PageCountMode.Actual;
            this.reportViewer1.ShowFindControls = false;
            this.reportViewer1.Size = new System.Drawing.Size(1011, 594);
            this.reportViewer1.TabIndex = 1;
            this.reportViewer1.ReportExport += new Microsoft.Reporting.WinForms.ExportEventHandler(this.reportViewer1_ReportExport);
            this.reportViewer1.RenderingComplete += new Microsoft.Reporting.WinForms.RenderingCompleteEventHandler(this.reportViewer1_RenderingComplete);
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
            this.imageList1.Images.SetKeyName(7, "loupe.png");
            // 
            // panelButton
            // 
            this.panelButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelButton.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panelButton.Controls.Add(this.button1);
            this.panelButton.Controls.Add(this.btnListe);
            this.panelButton.Controls.Add(this.btnEnter);
            this.panelButton.Controls.Add(this.btnRapport);
            this.panelButton.Controls.Add(this.btnQuit);
            this.panelButton.Location = new System.Drawing.Point(17, 778);
            this.panelButton.Margin = new System.Windows.Forms.Padding(4);
            this.panelButton.Name = "panelButton";
            this.panelButton.Size = new System.Drawing.Size(1012, 42);
            this.panelButton.TabIndex = 2;
            // 
            // btnListe
            // 
            this.btnListe.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnListe.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnListe.ImageIndex = 7;
            this.btnListe.ImageList = this.imageList1;
            this.btnListe.Location = new System.Drawing.Point(149, 3);
            this.btnListe.Margin = new System.Windows.Forms.Padding(4);
            this.btnListe.Name = "btnListe";
            this.btnListe.Size = new System.Drawing.Size(133, 31);
            this.btnListe.TabIndex = 1;
            this.btnListe.Text = "&Choisir";
            this.btnListe.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnListe.UseVisualStyleBackColor = true;
            this.btnListe.Click += new System.EventHandler(this.btnListe_Click);
            // 
            // btnEnter
            // 
            this.btnEnter.Location = new System.Drawing.Point(551, 4);
            this.btnEnter.Margin = new System.Windows.Forms.Padding(4);
            this.btnEnter.Name = "btnEnter";
            this.btnEnter.Size = new System.Drawing.Size(100, 28);
            this.btnEnter.TabIndex = 119;
            this.btnEnter.Text = "button1";
            this.btnEnter.UseVisualStyleBackColor = true;
            this.btnEnter.Click += new System.EventHandler(this.btnEnter_Click);
            // 
            // btnRapport
            // 
            this.btnRapport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnRapport.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnRapport.ImageIndex = 6;
            this.btnRapport.ImageList = this.imageList1;
            this.btnRapport.Location = new System.Drawing.Point(8, 5);
            this.btnRapport.Margin = new System.Windows.Forms.Padding(4);
            this.btnRapport.Name = "btnRapport";
            this.btnRapport.Size = new System.Drawing.Size(133, 31);
            this.btnRapport.TabIndex = 0;
            this.btnRapport.Text = "&Rapport";
            this.btnRapport.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRapport.UseVisualStyleBackColor = true;
            this.btnRapport.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // btnQuit
            // 
            this.btnQuit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnQuit.CausesValidation = false;
            this.btnQuit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnQuit.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnQuit.ImageIndex = 5;
            this.btnQuit.ImageList = this.imageList1;
            this.btnQuit.Location = new System.Drawing.Point(867, 5);
            this.btnQuit.Margin = new System.Windows.Forms.Padding(4);
            this.btnQuit.Name = "btnQuit";
            this.btnQuit.Size = new System.Drawing.Size(133, 31);
            this.btnQuit.TabIndex = 3;
            this.btnQuit.Text = "&Quitter";
            this.btnQuit.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnQuit.UseVisualStyleBackColor = true;
            // 
            // dataGridView
            // 
            this.dataGridView.AllowUserToAddRows = false;
            this.dataGridView.AllowUserToDeleteRows = false;
            this.dataGridView.AllowUserToOrderColumns = true;
            this.dataGridView.AllowUserToResizeRows = false;
            this.dataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke;
            this.dataGridView.Location = new System.Drawing.Point(16, 169);
            this.dataGridView.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridView.MultiSelect = false;
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.ReadOnly = true;
            this.dataGridView.RowHeadersVisible = false;
            this.dataGridView.RowHeadersWidth = 51;
            this.dataGridView.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView.Size = new System.Drawing.Size(1013, 594);
            this.dataGridView.TabIndex = 2;
            this.dataGridView.Visible = false;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(290, 3);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(117, 31);
            this.button1.TabIndex = 120;
            this.button1.Text = "Export Serveur";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // ImprimerAppelDeFondForm
            // 
            this.AcceptButton = this.btnEnter;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnQuit;
            this.ClientSize = new System.Drawing.Size(1045, 836);
            this.Controls.Add(this.dataGridView);
            this.Controls.Add(this.panelButton);
            this.Controls.Add(this.reportViewer1);
            this.Controls.Add(this.groupBox3);
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "ImprimerAppelDeFondForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "23";
            this.Load += new System.EventHandler(this.ValidAppelDeFondForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.immeublecoproBindingSource)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.panelButton.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.ResumeLayout(false);

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
        private Button button1;
    }
}