using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonProjectsPartners.Common
{
    public interface ICommonChangedListener
    {
        void ChangedReference(object sender, CommonEventArgs e);
    }
}
