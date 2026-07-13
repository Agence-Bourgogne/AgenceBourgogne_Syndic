using System;
using System.Data;
using System.Windows.Forms;
using SyndicData.Controller;
using SyndicData.Entites;
namespace EspaceSyndic.Formulaires.OperationsGestion
{
    public partial class ModificationLotForm : Form
    {
        ImmeubleEntite immeuble;
        protected int type_saisie ;
        
        SaisieAppelFondEntite appel = null;
        SaisieFactureEntite facture = null;

        public ModificationLotForm()
        {
            InitializeComponent();
        }
        public ModificationLotForm(SaisieAppelFondEntite entite)
        {
            InitializeComponent();
            appel = entite;
            facture = null;
        }
        public ModificationLotForm(SaisieFactureEntite entite)
        {
            InitializeComponent();
            appel = null;
            facture = entite;
        }
        private void FillComboLot()
        {
            if (immeuble == null)
                return;
            cbLot.DataSource = LotDescriptionController.getController().getComboListeLotCoproprietaires(immeuble);
            cbLot.DisplayMember = "nom";
            cbLot.ValueMember = "reference";
            if (appel != null)
            {
                LotDescriptionEntite lot = LotDescriptionController.getController().getEntiteById(appel.lot_id);
                if (lot != null)
                    cbLot.SelectedValue = lot.numero_lot;
            }
            if (facture != null)
            {
                LotDescriptionEntite lot = LotDescriptionController.getController().getEntiteById(facture.lot_id);
                if (lot != null)
                    cbLot.SelectedValue = lot.numero_lot;
            }
        }

        private void ModificationLotForm_Load(object sender, EventArgs e)
        {
            if (appel != null)
                immeuble = appel.Immeuble;
            else
                if (facture != null)
                    immeuble = facture.Immeuble;

            if (immeuble != null)
                tbRefImmeuble.Text = immeuble.reference;

            FillComboLot();
        }

        private void btnValid_Click(object sender, EventArgs e)
        {
            DataRowView row = (DataRowView) cbLot.SelectedItem;
            if (row != null)
            {
                if (appel != null)
                {
                    appel.lot_id = row["id"].ToString();
                    if (SaisieAppelFondController.getController().InsertOrUpdate(appel))
                        this.Close();
                }
                if (facture != null)
                {
                    facture.lot_id = row["id"].ToString();
                    if (SaisieFactureController.getController().InsertOrUpdate(facture))
                        this.Close();
                }
            }
        }
    }
}
