using System;
using System.ComponentModel.DataAnnotations;

namespace SyndicDocumentsData.Entities
{
    public class BaseEntitie
    {
        //public string id 
        //{
        //    get { return Guid; } 
        //}
        public DateTime audit_created { get; set; }
        public DateTime? audit_updated { get; set; }
        [Key]
        public String Guid { get; set; }
        public BaseEntitie()
        {
            audit_created = DateTime.Now;
            Guid = System.Guid.NewGuid().ToString();
        }
    }
}
