using System;
using System.Data;
using System.Windows.Forms;
using SyndicData.Controller;
using SyndicData.Entites;
using CommonProjectsPartners.Utils;
using SyndicData.Common;

namespace EspaceSyndic.Formulaires.Immeubles
{

    public partial class TitreRepartImmeubleForm : Form
    {
        public string immeuble_id = "";
        bool bInit = false;
        bool bChangeInProgress;
        public TitreRepartImmeubleForm()
        {
            InitializeComponent();
        }

        private void TitreRepartImmeubleForm_Load(object sender, EventArgs e)
        {
            DataTable repartitions = ImmeubleRepartitionController.getController().getRepartitionImmeuble(immeuble_id);
            foreach ( DataRow row in repartitions.Rows)
            {
                int idx = dataGridView.Rows.Add();
                DataGridViewRow rowGrid = dataGridView.Rows[idx];
                rowGrid.Tag = row;
                DataGridViewCellCollection cells = rowGrid.Cells;

                cells[0].Value = row["reference"];

                switch ((int)row["type_ventilation"])
                {
                    case (int) GlobalConstantes.TypeRepartition.Millieme:
                        cells[1].Value = GlobalConstantes.TypeRepartition.Millieme;
                        break;
                    case (int)GlobalConstantes.TypeRepartition.Individuelle:
                        cells[1].Value = GlobalConstantes.TypeRepartition.Individuelle;
                        break;
                }
                cells[1].Tag = (int)row["type_ventilation"];
                cells[2].Value = row["nom"];
                cells[3].Value = row["ligne"];
                cells[4].Value = row["colonne"];
            }
            cbRepart.Items.Add( GlobalConstantes.TypeRepartition.Millieme);
            cbRepart.Items.Add(GlobalConstantes.TypeRepartition.Individuelle);
            bInit = true;
            dataGridView_SelectionChanged(null, null);
        }

        private void dataGridView_SelectionChanged(object sender, EventArgs e)
        {
            if (!bInit)
                return;
            DataGridViewRow rowGrid = dataGridView.SelectedRows[0];
            DataRow row = (DataRow) rowGrid.Tag;
            bChangeInProgress = true;
            tbBase.Text = rowGrid.Cells["reference"].Value.ToString();
            tbTitre.Text = rowGrid.Cells["nom"].Value.ToString();
            tbLigne.Text = rowGrid.Cells["ligne"].Value.ToString();
            tbColonne.Text = rowGrid.Cells["colonne"].Value.ToString();
            cbRepart.SelectedIndex = (int)rowGrid.Cells["repartition"].Tag;

            if (row != null)
            {
                tbBase.Enabled = tbLigne.Enabled = tbColonne.Enabled = false;
            }
            else
                tbBase.Enabled = tbLigne.Enabled = tbColonne.Enabled = true;
            bChangeInProgress = false;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            bool bOk = true;
            ImmeubleRepartitionController controller = ImmeubleRepartitionController.getController();
            foreach (DataGridViewRow rowGrid in dataGridView.Rows)
            {
                DataRow row = (DataRow)rowGrid.Tag;
                ImmeubleRepartitionEntite entite = new ImmeubleRepartitionEntite(row);

                if (row == null)
                {
                    entite.reference = rowGrid.Cells["reference"].Value.ToString();
                    if (controller.ExistRepartitionReference ( immeuble_id, entite.reference))
                    {
                        MessageBox.Show ( String.Format("Base Existante pour cet immeuble", entite.reference));
                        return;
                    }
                    if (rowGrid.Cells["reference"].Value.ToString() == "")
                    {
                        MessageBox.Show("Vous devez définir la base");
                        return;
                    }
                    entite.immeuble_id = immeuble_id;
                }
                entite.nom = rowGrid.Cells["nom"].Value.ToString();
                entite.type_ventilation = (int) rowGrid.Cells["repartition"].Tag;
                entite.ligne = Convertir.ToInt(rowGrid.Cells["ligne"].Value.ToString());
                entite.colonne = Convertir.ToInt(rowGrid.Cells["colonne"].Value.ToString());
                if (entite.ligne <= 0)
                    entite.ligne = 1;
                bOk = controller.InsertOrUpdate(entite);
                if (!bOk)
                    break;
            }
            if (bOk)
                Close();
        }

        private void cbRepart_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (bChangeInProgress || !bInit)
                return;

            DataGridViewRow rowGrid = dataGridView.SelectedRows[0];
            if (rowGrid == null)
                return;
            rowGrid.Cells["repartition"].Tag = cbRepart.SelectedIndex;
            if (cbRepart.SelectedIndex >= 0)
            {
                rowGrid.Cells["repartition"].Value = cbRepart.SelectedItem.ToString();
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            int idx = dataGridView.Rows.Add();
            DataGridViewRow row = dataGridView.Rows[idx];
            row.Cells["reference"].Value = "";
            row.Cells["nom"].Value = "";
            row.Cells["ligne"].Value = "";
            row.Cells["colonne"].Value = "";
            row.Cells["repartition"].Value = "";
            row.Cells["repartition"].Tag = -1;
            row.Selected = true;
            dataGridView.CurrentCell = row.Cells[0];
            dataGridView_SelectionChanged(null, null);
        }

        private void tbBase_TextChanged(object sender, EventArgs e)
        {
            if (bChangeInProgress || !bInit)
                return;

            DataGridViewRow rowGrid = dataGridView.SelectedRows[0];

            if (rowGrid != null)
            {
                rowGrid.Cells["reference"].Value = tbBase.Text;
            }
        }
        private void tbTitre_TextChanged(object sender, EventArgs e)
        {
            if (bChangeInProgress || !bInit)
                return;
            DataGridViewRow rowGrid = dataGridView.SelectedRows[0];

            if (rowGrid != null)
            {
                rowGrid.Cells["nom"].Value = tbTitre.Text;
            }
        }


        private void tbLigne_TextChanged(object sender, EventArgs e)
        {
            if (bChangeInProgress || !bInit)
                return;
            DataGridViewRow rowGrid = dataGridView.SelectedRows[0];

            if (rowGrid != null)
            {
                rowGrid.Cells["ligne"].Value = tbLigne.Text;
            }
        }

        private void tbColonne_TextChanged(object sender, EventArgs e)
        {
            if (bChangeInProgress || !bInit)
                return;
            DataGridViewRow rowGrid = dataGridView.SelectedRows[0];

            if (rowGrid != null)
            {
                rowGrid.Cells["colonne"].Value = tbColonne.Text;
            }
        }
    }
}
