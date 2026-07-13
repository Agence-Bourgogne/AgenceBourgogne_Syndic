namespace Gerance.Formulaires.Natures
{
    partial class NatureFicheForm
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NatureFicheForm));
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tbRefComptable = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tbDeclaration = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbPart = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tbNom = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tbReference = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(10, 185);
            // 
            // btnEnter
            // 
            this.btnEnter.Size = new System.Drawing.Size(0, 23);
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
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tbRefComptable);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.tbDeclaration);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.tbPart);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.tbNom);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.tbReference);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(760, 161);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Nature";
            // 
            // tbRefComptable
            // 
            this.tbRefComptable.Location = new System.Drawing.Point(136, 123);
            this.tbRefComptable.Name = "tbRefComptable";
            this.tbRefComptable.Size = new System.Drawing.Size(100, 20);
            this.tbRefComptable.TabIndex = 15;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(9, 126);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(110, 13);
            this.label6.TabIndex = 14;
            this.label6.Text = "Référence Comptable";
            // 
            // tbDeclaration
            // 
            this.tbDeclaration.Location = new System.Drawing.Point(136, 98);
            this.tbDeclaration.Name = "tbDeclaration";
            this.tbDeclaration.Size = new System.Drawing.Size(100, 20);
            this.tbDeclaration.TabIndex = 13;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 101);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "Déclaration";
            // 
            // tbPart
            // 
            this.tbPart.Location = new System.Drawing.Point(136, 72);
            this.tbPart.Name = "tbPart";
            this.tbPart.Size = new System.Drawing.Size(100, 20);
            this.tbPart.TabIndex = 11;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 75);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Part Locative";
            // 
            // tbNom
            // 
            this.tbNom.Location = new System.Drawing.Point(136, 45);
            this.tbNom.Name = "tbNom";
            this.tbNom.Size = new System.Drawing.Size(291, 20);
            this.tbNom.TabIndex = 9;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 48);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(32, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Nom:";
            // 
            // tbReference
            // 
            this.tbReference.Location = new System.Drawing.Point(136, 19);
            this.tbReference.Name = "tbReference";
            this.tbReference.Size = new System.Drawing.Size(100, 20);
            this.tbReference.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Référence";
            // 
            // NatureFicheForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(784, 234);
            this.Controls.Add(this.groupBox1);
            this.Name = "NatureFicheForm";
            this.Text = "Fiche Nature";
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.panel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox tbRefComptable;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tbDeclaration;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbPart;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbNom;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbReference;
        private System.Windows.Forms.Label label2;
//        private System.Windows.Forms.ImageList imageList1;
    }
}
