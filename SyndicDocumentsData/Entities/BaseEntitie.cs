using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.IO;

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
