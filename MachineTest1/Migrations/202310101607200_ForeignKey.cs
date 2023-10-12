namespace MachineTest1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ForeignKey : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ProductMasters", "CategoryMaster_CategoryId", "dbo.CategoryMasters");
            DropIndex("dbo.ProductMasters", new[] { "CategoryMaster_CategoryId" });
            RenameColumn(table: "dbo.ProductMasters", name: "CategoryMaster_CategoryId", newName: "CategoryId");
            AlterColumn("dbo.ProductMasters", "CategoryId", c => c.Int(nullable: false));
            CreateIndex("dbo.ProductMasters", "CategoryId");
            AddForeignKey("dbo.ProductMasters", "CategoryId", "dbo.CategoryMasters", "CategoryId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ProductMasters", "CategoryId", "dbo.CategoryMasters");
            DropIndex("dbo.ProductMasters", new[] { "CategoryId" });
            AlterColumn("dbo.ProductMasters", "CategoryId", c => c.Int());
            RenameColumn(table: "dbo.ProductMasters", name: "CategoryId", newName: "CategoryMaster_CategoryId");
            CreateIndex("dbo.ProductMasters", "CategoryMaster_CategoryId");
            AddForeignKey("dbo.ProductMasters", "CategoryMaster_CategoryId", "dbo.CategoryMasters", "CategoryId");
        }
    }
}
