namespace SyndicDocumentsData.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Migre2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Documents", "immeuble_id", c => c.String());
            AddColumn("dbo.Documents", "copro_id", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Documents", "copro_id");
            DropColumn("dbo.Documents", "immeuble_id");
        }
    }
}
