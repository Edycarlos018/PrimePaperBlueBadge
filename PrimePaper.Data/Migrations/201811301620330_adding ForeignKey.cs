namespace PrimePaper.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addingForeignKey : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Contract", "CustomerID", c => c.Int(nullable: false));
            AddColumn("dbo.Contract", "ProductId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Contract", "ProductId");
            DropColumn("dbo.Contract", "CustomerID");
        }
    }
}
