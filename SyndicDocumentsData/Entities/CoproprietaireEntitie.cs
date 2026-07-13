using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SyndicDocumentsData.Entities;

[Table("Coproprietaire")]
public class CoproprietaireEntitie : BaseEntitie
{
    [Required]
    [MaxLength(80)]
    [Index("IX_Copropriete_id", IsUnique = true)]
    public string Copropriete_id { get; set; }
    [Required]
    [MaxLength(80)]
    [Index("IX_Reference_copro", IsUnique = true)]
    public string Reference { get; set; }
    [Required]
    public string Nom { get; set; }
    [Required]
    public string Immeuble_id { get; set; }
    public List<object> children = [];
    public string icon = "file file-copro";
    public CoproprietaireEntitie()
    {
        Console.WriteLine(@"Copro");
    }
    public string text => Nom;
}