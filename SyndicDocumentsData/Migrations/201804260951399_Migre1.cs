using System.Data.Entity.Migrations;

namespace SyndicDocumentsData.Migrations
{
    public partial class Migre1 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Users", "Key");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Users", "Key", c => c.String());
        }
    }
}
