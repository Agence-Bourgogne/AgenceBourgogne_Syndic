using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SyndicDocumentsData.Entities
{
    [Table("Childrens")]
    public class ChildrenEntitie : BaseEntitie
    {
        public string User_id { get; set; }
        public string Immeuble_id { get; set; }
        public string Copro_id { get; set; }

        public ChildrenEntitie()
            : base()
        {

        }
    }
}
