using System.Data;
using System.Windows.Forms;
using GeranceData.Controller;
namespace Gerance.Formulaires.Comptables
{
    public partial class ComptableListeForm : Common.CommonListeForm
    {
        public ComptableListeForm()
        {
            InitializeComponent();
        }
        protected override DataTable getFormListe()
        {
            return ComptableController.getController().GetList();
        }
        protected override void HideAndResizeColumns(DataGridViewColumnCollection cols)
        {
            base.HideAndResizeColumns(cols);
            cols["id"].Visible = false;
            cols["statut"].Visible = false;
            cols["note"].Visible = false;
            cols["pays"].Visible = false;
            cols["nom"].MinimumWidth = 140;
            cols["adresse"].MinimumWidth = 140;
        }
        protected override void ShowFicheForm(string entite_id)
        {
            var form = new ComptableFicheForm(entite_id);
            ShowForm(form);
        }
    }
}
