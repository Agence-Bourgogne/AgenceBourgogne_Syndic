using SyndicData.Controller;
using EspaceSyndic.Formulaires.Common;
using SyndicData.Entites;

namespace EspaceSyndic.Formulaires.Coproprietaire
{
    class FindLotCoproprietaireImmeubleForm : FindStdForm
    {
        public ImmeubleEntite immeuble = null;
        public CoproprietaireEntite coproprietaire = null;
        public override void FillListFromFilter(string filter)
        {
            source = LotDescriptionController.getController().getListeLotCoproprietaires(immeuble, coproprietaire);
            base.FillListFromFilter(filter);
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // FindLotCoproprietaireImmeubleForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(349, 415);
            this.Name = "FindLotCoproprietaireImmeubleForm";
            this.ResumeLayout(false);

        }
    }
}
