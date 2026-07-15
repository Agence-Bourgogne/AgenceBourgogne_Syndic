using System.ComponentModel;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;

namespace EspaceSyndic.Impressions.Additif
{
    partial class ImprimerAdditifForm
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
            ComponentResourceManager resources = new ComponentResourceManager(typeof(ImprimerAdditifForm));
            ReportDataSource reportDataSource1 = new ReportDataSource();
            tableCoproImmeubleBindingSource = new BindingSource(components);
            imageList1 = new ImageList(components);
            panelButton = new Panel();
            btnWord = new Button();
            btnEnter = new Button();
            btnRapport = new Button();
            btnQuit = new Button();
            reportViewer1 = new ReportViewer();
            groupBox3 = new GroupBox();
            label6 = new Label();
            cbConvoc = new ComboBox();
            dtDateAssemblee = new DateTimePicker();
            dtDateEntete = new DateTimePicker();
            label5 = new Label();
            tbHeure = new MaskedTextBox();
            label4 = new Label();
            tbLieu = new TextBox();
            label2 = new Label();
            label1 = new Label();
            tbRefImmeuble = new TextBox();
            lblImmeuble = new Label();
            tbText = new RichTextBox();
            label3 = new Label();
            ((ISupportInitialize)tableCoproImmeubleBindingSource).BeginInit();
            panelButton.SuspendLayout();
            groupBox3.SuspendLayout();
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
            imageList1.Images.SetKeyName(7, "word.png");
            // 
            // panelButton
            // 
            panelButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panelButton.BorderStyle = BorderStyle.Fixed3D;
            panelButton.Controls.Add(btnWord);
            panelButton.Controls.Add(btnEnter);
            panelButton.Controls.Add(btnRapport);
            panelButton.Controls.Add(btnQuit);
            panelButton.Location = new System.Drawing.Point(14, 663);
            panelButton.Margin = new Padding(4);
            panelButton.Name = "panelButton";
            panelButton.Size = new System.Drawing.Size(869, 41);
            panelButton.TabIndex = 9;
            // 
            // btnWord
            // 
            btnWord.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnWord.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            btnWord.ImageIndex = 7;
            btnWord.ImageList = imageList1;
            btnWord.Location = new System.Drawing.Point(130, 6);
            btnWord.Margin = new Padding(4);
            btnWord.Name = "btnWord";
            btnWord.Size = new System.Drawing.Size(116, 29);
            btnWord.TabIndex = 121;
            btnWord.Text = "&PubliPostage";
            btnWord.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            btnWord.UseVisualStyleBackColor = true;
            btnWord.Click += btnWord_Click;
            // 
            // btnEnter
            // 
            btnEnter.Location = new System.Drawing.Point(389, 5);
            btnEnter.Margin = new Padding(4);
            btnEnter.Name = "btnEnter";
            btnEnter.Size = new System.Drawing.Size(88, 26);
            btnEnter.TabIndex = 120;
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
            btnQuit.Location = new System.Drawing.Point(745, 6);
            btnQuit.Margin = new Padding(4);
            btnQuit.Name = "btnQuit";
            btnQuit.Size = new System.Drawing.Size(116, 29);
            btnQuit.TabIndex = 86;
            btnQuit.Text = "&Quitter";
            btnQuit.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            btnQuit.UseVisualStyleBackColor = true;
            // 
            // reportViewer1
            // 
            reportViewer1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            reportDataSource1.Name = "convocation";
            reportDataSource1.Value = tableCoproImmeubleBindingSource;
            reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            reportViewer1.LocalReport.ReportEmbeddedResource = "EspaceSyndic.Impressions.Additif.ImprimerAdditifReport.rdlc";
            reportViewer1.Location = new System.Drawing.Point(14, 155);
            reportViewer1.Margin = new Padding(4);
            reportViewer1.Name = "reportViewer1";
            reportViewer1.ServerReport.BearerToken = null;
            reportViewer1.Size = new System.Drawing.Size(870, 486);
            reportViewer1.TabIndex = 10;
            // 
            // groupBox3
            // 
            groupBox3.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            groupBox3.Controls.Add(label6);
            groupBox3.Controls.Add(cbConvoc);
            groupBox3.Controls.Add(dtDateAssemblee);
            groupBox3.Controls.Add(dtDateEntete);
            groupBox3.Controls.Add(label5);
            groupBox3.Controls.Add(tbHeure);
            groupBox3.Controls.Add(label4);
            groupBox3.Controls.Add(tbLieu);
            groupBox3.Controls.Add(label2);
            groupBox3.Controls.Add(label1);
            groupBox3.Controls.Add(tbRefImmeuble);
            groupBox3.Controls.Add(lblImmeuble);
            groupBox3.Controls.Add(tbText);
            groupBox3.Controls.Add(label3);
            groupBox3.Location = new System.Drawing.Point(14, 10);
            groupBox3.Margin = new Padding(4);
            groupBox3.Name = "groupBox3";
            groupBox3.Padding = new Padding(4);
            groupBox3.Size = new System.Drawing.Size(871, 137);
            groupBox3.TabIndex = 0;
            groupBox3.TabStop = false;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new System.Drawing.Point(242, 106);
            label6.Margin = new Padding(4, 0, 4, 0);
            label6.Name = "label6";
            label6.Size = new System.Drawing.Size(51, 15);
            label6.TabIndex = 11;
            label6.Text = "&Convoc:";
            // 
            // cbConvoc
            // 
            cbConvoc.DropDownStyle = ComboBoxStyle.DropDownList;
            cbConvoc.FormattingEnabled = true;
            cbConvoc.Items.AddRange(new object[] { "Ordinaire", "Extra Ordinaire" });
            cbConvoc.Location = new System.Drawing.Point(312, 101);
            cbConvoc.Margin = new Padding(4);
            cbConvoc.Name = "cbConvoc";
            cbConvoc.Size = new System.Drawing.Size(130, 23);
            cbConvoc.TabIndex = 12;
            // 
            // dtDateAssemblee
            // 
            dtDateAssemblee.Format = DateTimePickerFormat.Short;
            dtDateAssemblee.Location = new System.Drawing.Point(136, 71);
            dtDateAssemblee.Margin = new Padding(4);
            dtDateAssemblee.Name = "dtDateAssemblee";
            dtDateAssemblee.Size = new System.Drawing.Size(101, 23);
            dtDateAssemblee.TabIndex = 6;
            // 
            // dtDateEntete
            // 
            dtDateEntete.Format = DateTimePickerFormat.Short;
            dtDateEntete.Location = new System.Drawing.Point(136, 45);
            dtDateEntete.Margin = new Padding(4);
            dtDateEntete.Name = "dtDateEntete";
            dtDateEntete.Size = new System.Drawing.Size(101, 23);
            dtDateEntete.TabIndex = 4;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new System.Drawing.Point(21, 106);
            label5.Margin = new Padding(4, 0, 4, 0);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(42, 15);
            label5.TabIndex = 9;
            label5.Text = "&Heure:";
            // 
            // tbHeure
            // 
            tbHeure.Location = new System.Drawing.Point(136, 103);
            tbHeure.Margin = new Padding(4);
            tbHeure.Mask = "00:00";
            tbHeure.Name = "tbHeure";
            tbHeure.Size = new System.Drawing.Size(45, 23);
            tbHeure.TabIndex = 10;
            tbHeure.ValidatingType = typeof(System.DateTime);
            // 
            // label4
            // 
            label4.ForeColor = System.Drawing.Color.FromArgb(0, 0, 192);
            label4.Location = new System.Drawing.Point(242, 22);
            label4.Margin = new Padding(4, 0, 4, 0);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(62, 41);
            label4.TabIndex = 7;
            label4.Text = "&Texte Additif:";
            label4.Click += label4_Click;
            // 
            // tbLieu
            // 
            tbLieu.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            tbLieu.Location = new System.Drawing.Point(493, 103);
            tbLieu.Margin = new Padding(4);
            tbLieu.Name = "tbLieu";
            tbLieu.Size = new System.Drawing.Size(358, 23);
            tbLieu.TabIndex = 14;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(447, 105);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(35, 15);
            label2.TabIndex = 13;
            label2.Text = "&Lieu :";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(21, 79);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(94, 15);
            label1.TabIndex = 5;
            label1.Text = "Date &Assemblée:";
            // 
            // tbRefImmeuble
            // 
            tbRefImmeuble.Location = new System.Drawing.Point(136, 22);
            tbRefImmeuble.Margin = new Padding(4);
            tbRefImmeuble.Name = "tbRefImmeuble";
            tbRefImmeuble.Size = new System.Drawing.Size(80, 23);
            tbRefImmeuble.TabIndex = 2;
            tbRefImmeuble.DoubleClick += tbRefImmeuble_DoubleClick;
            tbRefImmeuble.KeyPress += tbHelpBox_KeyPress;
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
            lblImmeuble.Size = new System.Drawing.Size(55, 13);
            lblImmeuble.TabIndex = 1;
            lblImmeuble.Text = "&Immeuble:";
            lblImmeuble.Click += lblImmeuble_Click;
            // 
            // tbText
            // 
            tbText.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            tbText.Location = new System.Drawing.Point(312, 22);
            tbText.Margin = new Padding(4);
            tbText.Name = "tbText";
            tbText.Size = new System.Drawing.Size(539, 75);
            tbText.TabIndex = 8;
            tbText.Text = "";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(21, 52);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(70, 15);
            label3.TabIndex = 3;
            label3.Text = "&Date Entête:";
            // 
            // ImprimerAdditifForm
            // 
            AcceptButton = btnEnter;
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = btnQuit;
            ClientSize = new System.Drawing.Size(899, 718);
            ControlBox = false;
            Controls.Add(groupBox3);
            Controls.Add(reportViewer1);
            Controls.Add(panelButton);
            Margin = new Padding(4);
            Name = "ImprimerAdditifForm";
            ShowInTaskbar = false;
            SizeGripStyle = SizeGripStyle.Hide;
            StartPosition = FormStartPosition.CenterParent;
            Text = "Additif Convocation";
            FormClosing += ImprimerAdditifForm_FormClosing;
            Load += ImprimerConvocationForm_Load;
            ((ISupportInitialize)tableCoproImmeubleBindingSource).EndInit();
            panelButton.ResumeLayout(false);
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            ResumeLayout(false);

        }

        #endregion

        protected ImageList imageList1;
        private Panel panelButton;
        private Button btnRapport;
        private Button btnQuit;
        private ReportViewer reportViewer1;
        protected GroupBox groupBox3;
        protected Label label1;
        protected TextBox tbRefImmeuble;
        protected Label lblImmeuble;
        private RichTextBox tbText;
        protected Label label3;
        protected Label label4;
        private TextBox tbLieu;
        protected Label label2;
        protected Label label5;
        protected MaskedTextBox tbHeure;
        //private Datasets.CoproprietaireImmeuble coproprietaireImmeuble;
        private BindingSource tableCoproImmeubleBindingSource;
        //private Datasets.CoproprietaireImmeubleTableAdapters.CoproImmeubleTableAdapter coproImmeubleTableAdapter;
        private DateTimePicker dtDateAssemblee;
        private DateTimePicker dtDateEntete;
        protected Label label6;
        private ComboBox cbConvoc;
        private Button btnEnter;
        private Button btnWord;
    }
}