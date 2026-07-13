using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SyndicDocumentsData.Entities
{
    [Table("Coproprietaire")]
    public class CoproprietaireEntitie : BaseEntitie
    {
        [Required]
        [MaxLength(80)]
        [Index("IX_Copropriete_id", IsUnique = true)]
        public String Copropriete_id { get; set; }
        [Required]
        [MaxLength(80)]
        [Index("IX_Reference_copro", IsUnique = true)]
        public String Reference { get; set; }
        [Required]
        public String Nom { get; set; }
        [Required]
        public string Immeuble_id { get; set; }
        public List<object> children = new List<object>();
        public string icon = "file file-copro";
        public CoproprietaireEntitie() : base()
        {
            Console.WriteLine("Copro");
        }
        public string text
        {
            get
            {
                return Nom;
            }
        }
    }
}