namespace MachineTest1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CategoryMasters",
                c => new
                    {
                        CategoryId = c.Int(nullable: false, identity: true),
                        CategoryName = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.CategoryId);
            
            CreateTable(
                "dbo.ProductMasters",
                c => new
                    {
                        ProductId = c.Int(nullable: false, identity: true),
                        ProductName = c.String(nullable: false, maxLength: 100),
                        CategoryMaster_CategoryId = c.Int(),
                    })
                .PrimaryKey(t => t.ProductId)
                .ForeignKey("dbo.CategoryMasters", t => t.CategoryMaster_CategoryId)
                .Index(t => t.CategoryMaster_CategoryId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ProductMasters", "CategoryMaster_CategoryId", "dbo.CategoryMasters");
            DropIndex("dbo.ProductMasters", new[] { "CategoryMaster_CategoryId" });
            DropTable("dbo.ProductMasters");
            DropTable("dbo.CategoryMasters");
        }
    }
}
