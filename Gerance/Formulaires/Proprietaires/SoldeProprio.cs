using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gerance.Formulaires.Proprietaires
{
    class SoldeProprio
    {
        public string reference;
        public decimal loyers;
        public decimal deductions;
        public SoldeProprio(string reference, decimal loyers, decimal deductions)
        {
            this.reference = reference;
            this.loyers = loyers;
            this.deductions = deductions;
        }
    }
}
