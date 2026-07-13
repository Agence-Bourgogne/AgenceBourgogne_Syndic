using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SyndicDocumentsData.Entities
{
    [Table("Users")]
    public class UserEntitie : BaseEntitie
    {
        [Required]
        [MaxLength(80)]
        [Index("IX_Code", IsUnique=true)]
        public string Code { get; set; }
        public string Password { get; set; }

        public UserEntitie() : base()
        {
            Password = "";
        }
    }
}