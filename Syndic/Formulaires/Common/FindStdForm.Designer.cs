namespace EspaceSyndic.Formulaires.Common
{
    partial class FindStdForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FindStdForm));
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnEnter = new System.Windows.Forms.Button();
            this.cancel = new System.Windows.Forms.Button();
            this.valid = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.tbRef = new System.Windows.Forms.TextBox();
            this.tbNom = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
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
            this.dataGridView.Location = new System.Drawing.Point(12, 47);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.RowHeadersVisible = false;
            this.dataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView.Size = new System.Drawing.Size(387, 359);
            this.dataGridView.TabIndex = 4;
            this.dataGridView.DoubleClick += new System.EventHandler(this.dataGridView_DoubleClick);
            this.dataGridView.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dataGridView_KeyPress);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.btnEnter);
            this.panel1.Controls.Add(this.cancel);
            this.panel1.Controls.Add(this.valid);
            this.panel1.Location = new System.Drawing.Point(12, 412);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(384, 35);
            this.panel1.TabIndex = 5;
            // 
            // btnEnter
            // 
            this.btnEnter.Location = new System.Drawing.Point(288, 4);
            this.btnEnter.Name = "btnEnter";
            this.btnEnter.Size = new System.Drawing.Size(75, 23);
            this.btnEnter.TabIndex = 2;
            this.btnEnter.Text = "button1";
            this.btnEnter.UseVisualStyleBackColor = true;
            this.btnEnter.Click += new System.EventHandler(this.btnEnter_Click);
            // 
            // cancel
            // 
            this.cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancel.Location = new System.Drawing.Point(177, 4);
            this.cancel.Name = "cancel";
            this.cancel.Size = new System.Drawing.Size(75, 23);
            this.cancel.TabIndex = 1;
            this.cancel.Text = "&Annuler";
            this.cancel.UseVisualStyleBackColor = true;
            // 
            // valid
            // 
            this.valid.Location = new System.Drawing.Point(94, 4);
            this.valid.Name = "valid";
            this.valid.Size = new System.Drawing.Size(75, 23);
            this.valid.TabIndex = 0;
            this.valid.Text = "&Valider";
            this.valid.UseVisualStyleBackColor = true;
            this.valid.Click += new System.EventHandler(this.valid_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "&Référence";
            // 
            // tbRef
            // 
            this.tbRef.Location = new System.Drawing.Point(75, 6);
            this.tbRef.Name = "tbRef";
            this.tbRef.Size = new System.Drawing.Size(80, 20);
            this.tbRef.TabIndex = 1;
            this.tbRef.TextChanged += new System.EventHandler(this.tbRef_TextChanged);
            // 
            // tbNom
            // 
            this.tbNom.Location = new System.Drawing.Point(211, 6);
            this.tbNom.Name = "tbNom";
            this.tbNom.Size = new System.Drawing.Size(156, 20);
            this.tbNom.TabIndex = 3;
            this.tbNom.TextChanged += new System.EventHandler(this.tbNom_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(176, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "&Nom";
            // 
            // FindStdForm
            // 
            this.AcceptButton = this.btnEnter;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.CancelButton = this.cancel;
            this.ClientSize = new System.Drawing.Size(407, 452);
            this.ControlBox = false;
            this.Controls.Add(this.tbNom);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbRef);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dataGridView);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FindStdForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Recherche";
            this.Load += new System.EventHandler(this.FindStdForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.DataGridView dataGridView;
        protected System.Windows.Forms.Panel panel1;
        protected System.Windows.Forms.Button cancel;
        protected System.Windows.Forms.Button valid;
        protected System.Windows.Forms.Label label1;
        protected System.Windows.Forms.TextBox tbRef;
        protected System.Windows.Forms.TextBox tbNom;
        protected System.Windows.Forms.Label label2;
        protected System.Windows.Forms.Button btnEnter;
    }
}