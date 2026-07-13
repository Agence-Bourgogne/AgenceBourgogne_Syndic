using System;
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
