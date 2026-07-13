using System.ComponentModel;
using System.Windows.Forms;
using EspaceSyndic.Formulaires.Controles;

namespace EspaceSyndic.Impressions.Convocations
{
    partial class PvAssembleeForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PvAssembleeForm));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.panelButton = new System.Windows.Forms.Panel();
            this.btnRepart = new System.Windows.Forms.Button();
            this.btnWord = new System.Windows.Forms.Button();
            this.btnEnter = new System.Windows.Forms.Button();
            this.btnRapport = new System.Windows.Forms.Button();
            this.btnQuit = new System.Windows.Forms.Button();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.immeubleUserControl = new EspaceSyndic.Formulaires.Controles.ImmeubleUserControl();
            this.dtDateEntete = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dtDateAssemblee = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.tbHeure = new System.Windows.Forms.MaskedTextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cbConvoc = new System.Windows.Forms.ComboBox();
            this.tbLieu = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.panelButton.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tbLieu);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.cbConvoc);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.tbHeure);
            this.groupBox1.Controls.Add(this.dtDateAssemblee);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.dtDateEntete);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.comboBox1);
            this.groupBox1.Controls.Add(this.immeubleUserControl);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(768, 99);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(522, 24);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(240, 21);
            this.comboBox1.TabIndex = 4;
            // 
            // dataGridView
            // 
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Location = new System.Drawing.Point(12, 117);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.Size = new System.Drawing.Size(768, 386);
            this.dataGridView.TabIndex = 1;
            // 
            // panelButton
            // 
            this.panelButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelButton.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panelButton.Controls.Add(this.btnRepart);
            this.panelButton.Controls.Add(this.btnWord);
            this.panelButton.Controls.Add(this.btnEnter);
            this.panelButton.Controls.Add(this.btnRapport);
            this.panelButton.Controls.Add(this.btnQuit);
            this.panelButton.Location = new System.Drawing.Point(12, 526);
            this.panelButton.Name = "panelButton";
            this.panelButton.Size = new System.Drawing.Size(768, 35);
            this.panelButton.TabIndex = 10;
            // 
            // btnRepart
            // 
            this.btnRepart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnRepart.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnRepart.ImageIndex = 8;
            this.btnRepart.ImageList = this.imageList1;
            this.btnRepart.Location = new System.Drawing.Point(220, 4);
            this.btnRepart.Name = "btnRepart";
            this.btnRepart.Size = new System.Drawing.Size(100, 25);
            this.btnRepart.TabIndex = 122;
            this.btnRepart.Text = "&Note Convoc.";
            this.btnRepart.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRepart.UseVisualStyleBackColor = true;
            // 
            // btnWord
            // 
            this.btnWord.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnWord.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnWord.ImageIndex = 7;
            this.btnWord.ImageList = this.imageList1;
            this.btnWord.Location = new System.Drawing.Point(114, 4);
            this.btnWord.Name = "btnWord";
            this.btnWord.Size = new System.Drawing.Size(100, 25);
            this.btnWord.TabIndex = 121;
            this.btnWord.Text = "&PubliPostage";
            this.btnWord.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnWord.UseVisualStyleBackColor = true;
            // 
            // btnEnter
            // 
            this.btnEnter.Location = new System.Drawing.Point(546, 3);
            this.btnEnter.Name = "btnEnter";
            this.btnEnter.Size = new System.Drawing.Size(75, 23);
            this.btnEnter.TabIndex = 120;
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
            this.btnRapport.Location = new System.Drawing.Point(6, 4);
            this.btnRapport.Name = "btnRapport";
            this.btnRapport.Size = new System.Drawing.Size(100, 25);
            this.btnRapport.TabIndex = 87;
            this.btnRapport.Text = "&Rapport";
            this.btnRapport.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRapport.UseVisualStyleBackColor = true;
            // 
            // btnQuit
            // 
            this.btnQuit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnQuit.CausesValidation = false;
            this.btnQuit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnQuit.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnQuit.ImageIndex = 5;
            this.btnQuit.ImageList = this.imageList1;
            this.btnQuit.Location = new System.Drawing.Point(660, 4);
            this.btnQuit.Name = "btnQuit";
            this.btnQuit.Size = new System.Drawing.Size(100, 25);
            this.btnQuit.TabIndex = 86;
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
            this.imageList1.Images.SetKeyName(7, "word.png");
            this.imageList1.Images.SetKeyName(8, "bulle_repart.png");
            // 
            // immeubleUserControl
            // 
            this.immeubleUserControl.Location = new System.Drawing.Point(8, 21);
            this.immeubleUserControl.Name = "immeubleUserControl";
            this.immeubleUserControl.Reference = "";
            this.immeubleUserControl.Size = new System.Drawing.Size(175, 26);
            this.immeubleUserControl.TabIndex = 0;
            this.immeubleUserControl.ValidatingControl += new EspaceSyndic.Formulaires.Controles.ValidatingEventHandler(this.immeubleUserControl1_ValidatingControle);
            // 
            // dtDateEntete
            // 
            this.dtDateEntete.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtDateEntete.Location = new System.Drawing.Point(270, 24);
            this.dtDateEntete.Name = "dtDateEntete";
            this.dtDateEntete.Size = new System.Drawing.Size(87, 20);
            this.dtDateEntete.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(189, 27);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "&Date Entête:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(438, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "&Assemblée";
            // 
            // dtDateAssemblee
            // 
            this.dtDateAssemblee.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtDateAssemblee.Location = new System.Drawing.Point(91, 49);
            this.dtDateAssemblee.Name = "dtDateAssemblee";
            this.dtDateAssemblee.Size = new System.Drawing.Size(87, 20);
            this.dtDateAssemblee.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "&Prévue:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(189, 51);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(39, 13);
            this.label5.TabIndex = 7;
            this.label5.Text = "&Heure:";
            // 
            // tbHeure
            // 
            this.tbHeure.Location = new System.Drawing.Point(270, 49);
            this.tbHeure.Mask = "00:00";
            this.tbHeure.Name = "tbHeure";
            this.tbHeure.Size = new System.Drawing.Size(39, 20);
            this.tbHeure.TabIndex = 8;
            this.tbHeure.ValidatingType = typeof(System.DateTime);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(438, 51);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(34, 13);
            this.label6.TabIndex = 9;
            this.label6.Text = "&Type:";
            // 
            // cbConvoc
            // 
            this.cbConvoc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbConvoc.FormattingEnabled = true;
            this.cbConvoc.Items.AddRange(new object[] {
            "Ordinaire",
            "Extra Ordinaire"});
            this.cbConvoc.Location = new System.Drawing.Point(522, 49);
            this.cbConvoc.Name = "cbConvoc";
            this.cbConvoc.Size = new System.Drawing.Size(112, 21);
            this.cbConvoc.TabIndex = 10;
            // 
            // tbLieu
            // 
            this.tbLieu.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbLieu.Location = new System.Drawing.Point(91, 73);
            this.tbLieu.Name = "tbLieu";
            this.tbLieu.Size = new System.Drawing.Size(671, 20);
            this.tbLieu.TabIndex = 12;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(11, 75);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(33, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "&Lieu :";
            // 
            // PvAssembleeForm
            // 
            this.AcceptButton = this.btnEnter;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnQuit;
            this.ClientSize = new System.Drawing.Size(792, 573);
            this.Controls.Add(this.panelButton);
            this.Controls.Add(this.dataGridView);
            this.Controls.Add(this.groupBox1);
            this.Name = "PvAssembleeForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Convocation Assemblée";
            this.Load += new System.EventHandler(this.PvAssembleeForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.panelButton.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private GroupBox groupBox1;
        private ImmeubleUserControl immeubleUserControl;
        private ComboBox comboBox1;
        private DataGridView dataGridView;
        private Panel panelButton;
        private Button btnRepart;
        private Button btnWord;
        private Button btnEnter;
        private Button btnRapport;
        private Button btnQuit;
        protected ImageList imageList1;
        private Label label1;
        private DateTimePicker dtDateEntete;
        protected Label label3;
        private DateTimePicker dtDateAssemblee;
        protected Label label2;
        protected Label label5;
        protected MaskedTextBox tbHeure;
        protected Label label6;
        private ComboBox cbConvoc;
        private TextBox tbLieu;
        protected Label label4;
    }
}