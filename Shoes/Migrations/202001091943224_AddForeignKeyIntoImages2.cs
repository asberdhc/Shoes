namespace Shoes.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddForeignKeyIntoImages2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Images", "ShoeId", c => c.Int(nullable: false));
            CreateIndex("dbo.Images", "ShoeId");
            AddForeignKey("dbo.Images", "ShoeId", "dbo.Shoes", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Images", "ShoeId", "dbo.Shoes");
            DropIndex("dbo.Images", new[] { "ShoeId" });
            DropColumn("dbo.Images", "ShoeId");
        }
    }
}
