using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using System.Threading.Tasks;
using System.Windows.Forms;
using SyndicData.Controller;
using EspaceSyndic.Formulaires.Common;

namespace EspaceSyndic.Formulaires.Immeubles
{
    class FindImmeubleForm : FindStdForm
    {
        public ImmeubleController controller = new ImmeubleController();
        public FindImmeubleForm()
            : base()
        {
        }
        public FindImmeubleForm(TextBox tbResult)
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
            this.SuspendLayout();
            // 
            // FindImmeubleForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(345, 413);
            this.Name = "FindImmeubleForm";
            this.ResumeLayout(false);

        }
    }
}
