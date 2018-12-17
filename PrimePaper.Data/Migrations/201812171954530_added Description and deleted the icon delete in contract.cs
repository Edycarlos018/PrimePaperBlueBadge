namespace PrimePaper.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedDescriptionanddeletedtheicondeleteincontract : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Product", "Description", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Product", "Description");
        }
    }
}
