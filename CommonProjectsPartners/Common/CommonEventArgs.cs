using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonProjectsPartners.Common
{
    public class CommonEventArgs
    {
        public string newRef;
        public string newRef2;
        public string newRef3;
        public CommonEventArgs(string newRef, string newRef2 = "", string newRef3 = "")
        {
            this.newRef = newRef;
            this.newRef2 = newRef2;
            this.newRef3 = newRef3;
        }
    }
}
