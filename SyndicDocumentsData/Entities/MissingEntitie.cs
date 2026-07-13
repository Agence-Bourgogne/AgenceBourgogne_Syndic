using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SyndicDocumentsData.Entities
{
    [Table("Missing")]
    public class MissingEntitie : BaseEntitie
    {
        public String Email { get; set; }
        public DateTime DateExpire { get; set; }
        public MissingEntitie(String Email)
            : base()
        {
            this.Email = Email;
            DateExpire = DateTime.Now.AddDays(1);
        }
        public MissingEntitie()
            : base()
        {
        }

    }
}
