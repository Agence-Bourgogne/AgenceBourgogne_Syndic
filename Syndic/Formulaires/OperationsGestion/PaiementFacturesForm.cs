using System.Windows.Forms;
using SyndicData.Controller;
using SyndicData.Entites;

namespace EspaceSyndic.Formulaires.OperationsGestion
{
    public partial class PaiementFacturesForm : Form
    {
        public PaiementFacturesForm()
        {
            InitializeComponent();

            dgvFactures = new DataGridView
            {
                Dock = DockStyle.Fill,
                AutoGenerateColumns = false,
                AllowUserToAddRows = false,
                ReadOnly = true
            };

            dgvFactures.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Liasse",
                DataPropertyName = "NomLiasse"
            });

            dgvFactures.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Immeuble",
                DataPropertyName = "NomImmeuble"
            });

            dgvFactures.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Référence",
                DataPropertyName = "ReferenceImmeuble"
            });

            dgvFactures.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Fournisseur",
                DataPropertyName = "NomFournisseur"
            });

            dgvFactures.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Date facture",
                DataPropertyName = "DateFacture"
            });

            dgvFactures.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Montant",
                DataPropertyName = "MontantFacture",
                DefaultCellStyle = new DataGridViewCellStyle
                {
                    Format = "C2"
                }
            });

            var btnPayer = new DataGridViewButtonColumn
            {
                HeaderText = "",
                Text = "Marquer payée",
                UseColumnTextForButtonValue = true
            };

            dgvFactures.Columns.Add(btnPayer);

            dgvFactures.CellClick += DgvFactures_CellClick;

            dgvFactures.DataSource = SaisieFactureController
                .getController()
                .GetFactures();

            Controls.Add(dgvFactures);
        }

        private void DgvFactures_CellClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            if (e.ColumnIndex == dgvFactures.Columns.Count - 1)
            {
                var facture = (FacturePresenter) dgvFactures.Rows[e.RowIndex].DataBoundItem;

                using var dialog = new MarquerPayeeDialog(facture);

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    MessageBox.Show(
                        $"La facture {facture.NomFournisseur} est marquée comme payée.",
                        "Paiement",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
            }
        }
    }
}
