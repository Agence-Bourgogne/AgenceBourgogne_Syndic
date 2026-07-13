using System.ComponentModel;
using System.Windows.Forms;

namespace EspaceSyndic.Formulaires.Budget
{
    partial class NouvelExerciceForm
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
            this.dtFin = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.dtDeb = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tbReference = new System.Windows.Forms.TextBox();
            this.lblBase = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tbCoeff = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.rdReel = new System.Windows.Forms.RadioButton();
            this.rdVote = new System.Windows.Forms.RadioButton();
            this.rdNone = new System.Windows.Forms.RadioButton();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dtFin
            // 
            this.dtFin.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtFin.Location = new System.Drawing.Point(234, 19);
            this.dtFin.Name = "dtFin";
            this.dtFin.Size = new System.Drawing.Size(82, 20);
            this.dtFin.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(204, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(20, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "&Au";
            // 
            // dtDeb
            // 
            this.dtDeb.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtDeb.Location = new System.Drawing.Point(88, 19);
            this.dtDeb.Name = "dtDeb";
            this.dtDeb.Size = new System.Drawing.Size(82, 20);
            this.dtDeb.TabIndex = 1;
            this.dtDeb.ValueChanged += new System.EventHandler(this.dtDeb_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(25, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(21, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "&Du";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tbReference);
            this.groupBox1.Controls.Add(this.lblBase);
            this.groupBox1.Controls.Add(this.dtFin);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.dtDeb);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(346, 100);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Exercice";
            // 
            // tbReference
            // 
            this.tbReference.Location = new System.Drawing.Point(88, 52);
            this.tbReference.Name = "tbReference";
            this.tbReference.Size = new System.Drawing.Size(82, 20);
            this.tbReference.TabIndex = 5;
            // 
            // lblBase
            // 
            this.lblBase.AutoSize = true;
            this.lblBase.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBase.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblBase.Location = new System.Drawing.Point(25, 56);
            this.lblBase.Name = "lblBase";
            this.lblBase.Size = new System.Drawing.Size(60, 13);
            this.lblBase.TabIndex = 4;
            this.lblBase.Text = "&Référence:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.tbCoeff);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.rdReel);
            this.groupBox2.Controls.Add(this.rdVote);
            this.groupBox2.Controls.Add(this.rdNone);
            this.groupBox2.Location = new System.Drawing.Point(12, 118);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(346, 156);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Budget";
            // 
            // tbCoeff
            // 
            this.tbCoeff.Location = new System.Drawing.Point(189, 119);
            this.tbCoeff.Name = "tbCoeff";
            this.tbCoeff.Size = new System.Drawing.Size(44, 20);
            this.tbCoeff.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label1.Location = new System.Drawing.Point(106, 123);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "&Coefficient (%):";
            // 
            // rdReel
            // 
            this.rdReel.AutoSize = true;
            this.rdReel.Location = new System.Drawing.Point(28, 77);
            this.rdReel.Name = "rdReel";
            this.rdReel.Size = new System.Drawing.Size(158, 17);
            this.rdReel.TabIndex = 2;
            this.rdReel.TabStop = true;
            this.rdReel.Text = "Créer à partir du Réali&sé N-1";
            this.rdReel.UseVisualStyleBackColor = true;
            // 
            // rdVote
            // 
            this.rdVote.AutoSize = true;
            this.rdVote.Location = new System.Drawing.Point(28, 54);
            this.rdVote.Name = "rdVote";
            this.rdVote.Size = new System.Drawing.Size(181, 17);
            this.rdVote.TabIndex = 1;
            this.rdVote.TabStop = true;
            this.rdVote.Text = "Créer à partir du budget &Voté N-1";
            this.rdVote.UseVisualStyleBackColor = true;
            // 
            // rdNone
            // 
            this.rdNone.AutoSize = true;
            this.rdNone.Checked = true;
            this.rdNone.Location = new System.Drawing.Point(28, 31);
            this.rdNone.Name = "rdNone";
            this.rdNone.Size = new System.Drawing.Size(99, 17);
            this.rdNone.TabIndex = 0;
            this.rdNone.TabStop = true;
            this.rdNone.Text = "Saisie &Manuelle";
            this.rdNone.UseVisualStyleBackColor = true;
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(100, 290);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 2;
            this.btnOk.Text = "&Ok";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(201, 290);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "Annuler";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // NouvelExerciceForm
            // 
            this.AcceptButton = this.btnOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(370, 321);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "NouvelExerciceForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Nouvel Exercice";
            this.Load += new System.EventHandler(this.NouvelExerciceForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DateTimePicker dtFin;
        private Label label3;
        private DateTimePicker dtDeb;
        private Label label2;
        private GroupBox groupBox1;
        private TextBox tbReference;
        private Label lblBase;
        private GroupBox groupBox2;
        private RadioButton rdReel;
        private RadioButton rdVote;
        private RadioButton rdNone;
        private Button btnOk;
        private Button btnCancel;
        private TextBox tbCoeff;
        private Label label1;
    }
}