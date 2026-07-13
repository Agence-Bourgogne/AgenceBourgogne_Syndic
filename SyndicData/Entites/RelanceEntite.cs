using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SyndicData.Entites
{
    public class RelanceEntite
    {
        public string coproprietaire_id;
        public string immeuble_id;
        public string lot_id;
        public int type_relance;

        public RelanceEntite(string immeuble_id, string coproprietaire_id, string lot_id, int type_relance)
        {
            this.immeuble_id = immeuble_id;
            this.lot_id = lot_id;
            this.coproprietaire_id = coproprietaire_id;
            this.type_relance = type_relance;
        }
    }
}
