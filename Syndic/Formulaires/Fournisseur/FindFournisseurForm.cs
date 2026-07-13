using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using System.Threading.Tasks;
using System.Windows.Forms;
using SyndicData.Controller;
using EspaceSyndic.Formulaires.Common;

namespace EspaceSyndic.Formulaires.Fournisseur
{
    class FindFournisseurForm : FindStdForm
    {
        public FournisseurController controller = new FournisseurController();


        public FindFournisseurForm()
            : base()
        {

        }

        public FindFournisseurForm(TextBox tbResult)
            : base(tbResult)
        {

        }


        public override void FillListFromFilter(string filter)
        {
            source = controller.GetFindList(filter);
            base.FillListFromFilter(filter);
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FindFournisseurForm));
            this.SuspendLayout();
            // 
            // FindFournisseurForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(349, 415);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FindFournisseurForm";
            this.ResumeLayout(false);

        }

    }
}
