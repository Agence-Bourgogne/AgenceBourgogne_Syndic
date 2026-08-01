using System;
using System.Windows.Forms;
using SyndicData.Entites;

namespace EspaceSyndic.Formulaires.OperationsGestion
{
    public partial class MarquerPayeeDialog : Form
    {
        private readonly FacturePresenter _facture;

        public MarquerPayeeDialog(FacturePresenter facture)
        {
            InitializeComponent();

            _facture = facture;

            lblInfo.Text =
                $"Confirmer le paiement de la facture de {_facture.NomFournisseur}\n" +
                $"Montant : {_facture.MontantFacture:C2}";
        }

        private void btnValider_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnAnnuler_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
