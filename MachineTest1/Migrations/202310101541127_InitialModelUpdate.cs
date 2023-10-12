namespace MachineTest1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialModelUpdate : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.CategoryMasters", "CategoryName", c => c.String(maxLength: 100));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.CategoryMasters", "CategoryName", c => c.String(nullable: false, maxLength: 100));
        }
    }
}
