using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Runtime.Serialization;
namespace SyndicDocumentsData.Entities
{
    [Table("Documents")]
    public class DocumentEntitie : BaseEntitie
    {
//        public int id { get; set; }
        public String text { get; set; }
        public String immeuble_id { get; set; }
        public String copro_id { get; set; }
        public string icon = "file file-pdf";
        [IgnoreDataMemberAttribute]
        public byte[] content { get; set; }
        public DocumentEntitie() : base()
        {
        }

        public string document_id 
        {
            get { return Guid; }
        }
        public DocumentEntitie(string text, string document_id, byte[] content, String immeuble_id, string copro_id)
        {
            this.text = text;
            this.Guid = document_id;
            this.content = content;
            this.immeuble_id = immeuble_id;
            this.copro_id = copro_id;
        }
    }
}