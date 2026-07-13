using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using SyndicData.Controller;
using SyndicData.Entites;
using SyndicData.Common;
using CommonProjectsPartners.Utils;
namespace EspaceSyndic.Formulaires.OperationsGestion
{
    public partial class DetailElementOperationForm : Form
    {
        OperationEntite operation;
        public DetailElementOperationForm()
        {
            InitializeComponent();
        }
        public DetailElementOperationForm(string operation_id)
        {
            InitializeComponent();
            operation = OperationController.getController().getEntiteById(operation_id);
        }
        private void DetailElementOperationForm_Load(object sender, EventArgs e)
        {
            btnEnter.Width = 0;
            if (operation != null)
            {
                tbRefImmeuble.Text = operation.Immeuble.reference;
                tbDateCreation.Text = operation.date_reference.ToShortDateString();
                tbBase.Text = operation.base_repart;
                if( operation.Lot != null )
                    tbLot.Text = operation.Lot.numero_lot.ToString();
                if (operation.Nature != null)
                {
                    tbNature.Text = operation.Nature.reference;
                    tbLibNature.Text = operation.Nature.nom;
                }
                tbComment.Text = operation.libelle;
                tbDebit.Text = operation.debit.ToString();
                tbCredit.Text = operation.credit.ToString();
                if (operation.Coproprietaire != null)
                {
                    tbNomCopro.Text = operation.Coproprietaire.NomPrenom;
                    tbRefCopro.Text = operation.Coproprietaire.reference;
                }
                //tbLot.Enabled = true;
                //tbLot.ReadOnly = false;
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (operation == null)
                return;
            if (MessageBox.Show("Cette Opération est irréversible\r\nVoulez-vous Continuer", "Attention", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                operation.statut = (int) GlobalConstantes.StatutOperation.Supprime;
                if (OperationController.getController().InsertOrUpdate(operation))
                    this.Close();
            }
        }

        private void btnValid_Click(object sender, EventArgs e)
        {
            LotDescriptionEntite lot = LotDescriptionController.getController().getLotFromRefImmeubleNumLot(tbRefImmeuble.Text, Convertir.ToInt(tbLot.Text));
            if (lot == null)
            {
                MessageBox.Show("Lot Invalide");
                return;
            }
            if (operation.statut == (int)GlobalConstantes.StatutOperation.Supprime)
                operation.statut = (int)GlobalConstantes.StatutOperation.Valide;
            operation.debit = Convertir.ToDecimal(tbDebit.Text);
            operation.credit = Convertir.ToDecimal(tbCredit.Text);
            operation.libelle = tbComment.Text;
            operation.lot_id = lot.id;
            operation.coproprietaire_id = lot.coproprietaire_id;

            if (OperationController.getController().InsertOrUpdate(operation))
                this.Close();

        }
        private void btnEnter_Click(object sender, EventArgs e)
        {
            ControlsWindows.FocusNextTabbedControl(this);
        }

        private void tbLot_Validating(object sender, CancelEventArgs e)
        {
            LotDescriptionEntite lot = LotDescriptionController.getController().getLotFromRefImmeubleNumLot(tbRefImmeuble.Text, Convertir.ToInt(tbLot.Text));
            tbLot.BackColor = Color.White;
            if (lot != null)
            {
                tbNomCopro.Text = lot.Coproprietaire.NomPrenom;
                tbRefCopro.Text = lot.Coproprietaire.reference;
            }
            else
                tbLot.BackColor = Color.Red;
        }

    }
}
