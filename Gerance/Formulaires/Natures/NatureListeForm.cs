using System.Data;
using System.Windows.Forms;
using GeranceData.Controller;

namespace Gerance.Formulaires.Natures
{
    public partial class NatureListeForm : Common.CommonListeForm
    {
        public NatureListeForm()
        {
            InitializeComponent();
        }
        protected override DataTable getFormListe()
        {
            return NatureController.getController().GetList();
        }
        protected override void HideAndResizeColumns(DataGridViewColumnCollection cols)
        {
            base.HideAndResizeColumns(cols);
            cols["id"].Visible = false;
            cols["statut"].Visible = false;
            cols["type_charge"].Visible = false;
            cols["budgetisable"].Visible = false;
            cols["nom"].MinimumWidth = 180;
        }
        protected override void ShowFicheForm(string entite_id)
        {
            NatureFicheForm form = new NatureFicheForm(entite_id);
            ShowForm(form);
        }

    }
}
