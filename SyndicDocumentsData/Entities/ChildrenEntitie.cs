using System.ComponentModel.DataAnnotations.Schema;

namespace SyndicDocumentsData.Entities;

[Table("Childrens")]
public class ChildrenEntitie : BaseEntitie
{
    public string User_id { get; set; }
    public string Immeuble_id { get; set; }
    public string Copro_id { get; set; }
}