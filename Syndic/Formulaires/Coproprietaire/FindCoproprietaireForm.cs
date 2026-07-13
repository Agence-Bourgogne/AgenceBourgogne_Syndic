using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using System.Threading.Tasks;
using System.Windows.Forms;
using SyndicData.Controller;
using EspaceSyndic.Formulaires.Common;
using SyndicData.Common;
using System.Drawing;
using CommonProjectsPartners.Utils;

namespace EspaceSyndic.Formulaires.Coproprietaire
{
    public class FindCoproprietaireForm : FindStdForm
    {
        private TextBox tbGerant;
        private Label label3;
        public CoproprietaireController controller = new CoproprietaireController();

        public FindCoproprietaireForm()
            : base()
        {
            InitializeComponent();
            AdapteControls();
            dataGridView.CellPainting += dataGridView_CellPainting;
        }

        public FindCoproprietaireForm(TextBox tbResult)
            : base(tbResult)
        {
            InitializeComponent();
            AdapteControls();
            dataGridView.CellPainting += dataGridView_CellPainting;
        }

        void dataGridView_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView.Rows[e.RowIndex];
                if (Convertir.ToInt(row.Cells["statut"].Value) != (int)GlobalConstantes.StatutData.Actif)
                {
                    row.DefaultCellStyle.BackColor = Color.OrangeRed;
                }
            }
        }

        public override void FillListFromFilter(string filter)
        {
            if (tbGerant.Text != "")
                filter += String.Format(" and LOWER(nomcomp) like LOWER('{0}%') ", tbGerant.Text);
            source = controller.GetFindListStatut(filter);
            base.FillListFromFilter(filter);
            DataGridViewColumnCollection cols = dataGridView.Columns;
            cols["statut"].Visible = false;
        }

        private void AdapteControls()
        {
            int decal = 168;
            System.Drawing.Size size = dataGridView.Size;
            dataGridView.Size = new System.Drawing.Size(size.Width + decal, size.Height);
            dataGridView.TabIndex = 6;
            valid.TabIndex = 7;
            cancel.TabIndex = 8;
        }
        private void InitializeComponent()
        {
            this.tbGerant = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(12, 410);
            this.panel1.Size = new System.Drawing.Size(553, 35);
            // 
            // cancel
            // 
            this.cancel.Location = new System.Drawing.Point(296, 5);
            // 
            // valid
            // 
            this.valid.Location = new System.Drawing.Point(213, 5);
            // 
            // tbNom
            // 
            this.tbNom.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            // 
            // btnEnter
            // 
            this.btnEnter.Size = new System.Drawing.Size(0, 23);
            // 
            // tbGerant
            // 
            this.tbGerant.Location = new System.Drawing.Point(428, 6);
            this.tbGerant.Name = "tbGerant";
            this.tbGerant.Size = new System.Drawing.Size(137, 20);
            this.tbGerant.TabIndex = 5;
            this.tbGerant.TextChanged += new System.EventHandler(this.tbGerant_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(383, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(39, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Gérant";
            // 
            // FindCoproprietaireForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(577, 455);
            this.Controls.Add(this.tbGerant);
            this.Controls.Add(this.label3);
            this.Name = "FindCoproprietaireForm";
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.tbRef, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.tbNom, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.tbGerant, 0);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void tbGerant_TextChanged(object sender, EventArgs e)
        {
            FillListFromTbFilter();
        }

    }
}
