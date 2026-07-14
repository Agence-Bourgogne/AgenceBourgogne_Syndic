using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace SyndicDocumentsData.Entities;

[Table("Documents")]
public class DocumentEntitie : BaseEntitie
{
    public string text { get; set; }
    public string immeuble_id { get; set; }
    public string copro_id { get; set; }
    public string icon = "file file-pdf";
    [IgnoreDataMember]
    public byte[] content { get; set; }

    public string document_id => Guid;

    public DocumentEntitie(string text, string document_id, byte[] content, string immeuble_id, string copro_id)
    {
        this.text = text;
        Guid = document_id;
        this.content = content;
        this.immeuble_id = immeuble_id;
        this.copro_id = copro_id;
    }
}