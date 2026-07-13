using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SyndicDocumentsData.Entities;

[Table("Immeubles")]
public class ImmeubleEntitie : BaseEntitie
{
    [Required]
    [MaxLength(80)]
    [Index("IX_Immeuble_id", IsUnique = true)]
    public string Immeuble_id { get; set; }
    [Required]
    [MaxLength(80)]
    [Index("IX_Reference", IsUnique = true)]
    public string Reference { get; set; }
    [Required]
    public string Addresse { get; set; }
    public string icon = "file file-imm";
    public List<object> children = [];
        
    public ImmeubleEntitie()
    {
        Console.WriteLine(@"ImmeubleEntitie");
    }
    public string text => Addresse;
}