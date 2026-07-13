using System.Data;
using System.Windows.Forms;
using GeranceData.Controller;
namespace Gerance.Formulaires.Fournisseurs
{
    public partial class FournisseurListeForm : Common.CommonListeForm
    {
        public FournisseurListeForm()
        {
            InitializeComponent();
        }
        protected override DataTable getFormListe()
        {
            return FournisseurController.getController().GetList();
        }
        protected override void HideAndResizeColumns(DataGridViewColumnCollection cols)
        {
            base.HideAndResizeColumns(cols);
            dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            cols["id"].Visible = false;
            cols["audit_created"].Visible = false;
            cols["audit_created_by"].Visible = false;
            cols["audit_updated"].Visible = false;
            cols["audit_updated_by"].Visible = false;
            cols["statut"].Visible = false;
        }
        protected override void ShowFicheForm(string entite_id)
        {
            var form = new FournisseurFicheForm(entite_id);
            ShowForm(form);
        }
    }
}
