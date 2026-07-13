using System.Data.Entity;
using SyndicDocumentsData.Entities;

namespace SyndicDocumentsData.Models
{
    public class BddContext : DbContext
    {
        public DbSet<UserEntitie> Users { get; set; }
        public DbSet<ImmeubleEntitie> Immeubles { get; set; }
        public DbSet<CoproprietaireEntitie> Coproprietaires { get; set; }
        public DbSet<DocumentEntitie> Documents { get; set; }
        public DbSet<ChildrenEntitie> Childrens { get; set; }
        public DbSet<MissingEntitie> MissingEntities { get; set; }
    }
}