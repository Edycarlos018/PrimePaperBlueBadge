namespace PrimePaper.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dropdwnlist : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.Contract", "CustomerID");
            CreateIndex("dbo.Contract", "ProductId");
            AddForeignKey("dbo.Contract", "CustomerID", "dbo.Customer", "CustomerID", cascadeDelete: true);
            AddForeignKey("dbo.Contract", "ProductId", "dbo.Product", "ProductId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Contract", "ProductId", "dbo.Product");
            DropForeignKey("dbo.Contract", "CustomerID", "dbo.Customer");
            DropIndex("dbo.Contract", new[] { "ProductId" });
            DropIndex("dbo.Contract", new[] { "CustomerID" });
        }
    }
}
