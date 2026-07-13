using System.Data.Entity.Migrations;

namespace SyndicDocumentsData.Migrations
{
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Coproprietaire",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Copropriete_id = c.String(nullable: false, maxLength: 80),
                        Reference = c.String(nullable: false, maxLength: 80),
                        Nom = c.String(nullable: false),
                        Immeuble_id = c.String(nullable: false),
                        audit_created = c.DateTime(nullable: false),
                        audit_updated = c.DateTime(),
                        Guid = c.String(),
                    })
                .PrimaryKey(t => t.id)
                .Index(t => t.Copropriete_id, unique: true)
                .Index(t => t.Reference, unique: true, name: "IX_Reference_copro");
            
            CreateTable(
                "dbo.Documents",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        text = c.String(),
                        document_id = c.String(nullable: false),
                        content = c.Binary(),
                        audit_created = c.DateTime(nullable: false),
                        audit_updated = c.DateTime(),
                        Guid = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Immeubles",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Immeuble_id = c.String(nullable: false, maxLength: 80),
                        Reference = c.String(nullable: false, maxLength: 80),
                        Addresse = c.String(nullable: false),
                        audit_created = c.DateTime(nullable: false),
                        audit_updated = c.DateTime(),
                        Guid = c.String(),
                    })
                .PrimaryKey(t => t.id)
                .Index(t => t.Immeuble_id, unique: true)
                .Index(t => t.Reference, unique: true);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Code = c.String(nullable: false, maxLength: 80),
                        Password = c.String(),
                        Key = c.String(),
                        audit_created = c.DateTime(nullable: false),
                        audit_updated = c.DateTime(),
                        Guid = c.String(),
                    })
                .PrimaryKey(t => t.id)
                .Index(t => t.Code, unique: true);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.Users", new[] { "Code" });
            DropIndex("dbo.Immeubles", new[] { "Reference" });
            DropIndex("dbo.Immeubles", new[] { "Immeuble_id" });
            DropIndex("dbo.Coproprietaire", "IX_Reference_copro");
            DropIndex("dbo.Coproprietaire", new[] { "Copropriete_id" });
            DropTable("dbo.Users");
            DropTable("dbo.Immeubles");
            DropTable("dbo.Documents");
            DropTable("dbo.Coproprietaire");
        }
    }
}
