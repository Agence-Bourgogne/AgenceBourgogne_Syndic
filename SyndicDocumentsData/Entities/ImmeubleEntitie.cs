using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;

namespace SyndicDocumentsData.Entities
{
    [Table("Immeubles")]
    public class ImmeubleEntitie : BaseEntitie
    {
//        public int id { get; set; }
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
        public List<object> children = new List<object>();
        
        public ImmeubleEntitie() : base()
        {
            Console.WriteLine("ImmeubleEntitie");
        }
        public string text
        {
            get 
            {
                return Addresse;
            }
        }
//        public ImmeubleEntitie(string immeuble_id, string reference, string text)
//        {
//            this.Immeuble_id = immeuble_id;
//            this.Reference = reference;
//            this.Addresse = text;
////            FillCoproprietes();
//        }
        //public void FillCoproprietes()
        //{
        //    if ( Immeuble_id == "1")
        //    {
        //        //children.Add(new DocumentEntitie(id + "_1_2", "myref", "Bilan", "2"));
        //        //children.Add(new CoproprieteEntitie(id + "_1", "ref1", "Lot 101", "1"));
        //        //children.Add(new CoproprieteEntitie(id + "_2", "ref2", "Lot 102", "2"));
        //        //children.Add(new CoproprieteEntitie(id + "_3", "ref3", "Lot 103", "3"));
        //    }
        //    if (Immeuble_id == "2")
        //    {
        //        //children.Add(new DocumentEntitie(id + "_1_2", "myref", "Bilan", "2"));
        //        //children.Add(new CoproprieteEntitie(id + "_1", "ref1", "Lot 201", "4"));
        //        //children.Add(new CoproprieteEntitie(id + "_2", "ref2", "Lot 202", "5"));
        //    }
        //}
    }
}