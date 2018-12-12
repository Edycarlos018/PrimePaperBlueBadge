namespace PrimePaper.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedcreatetimeinproduct : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Product", "CreatedUtc", c => c.DateTimeOffset(nullable: false, precision: 7));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Product", "CreatedUtc");
        }
    }
}
