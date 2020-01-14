namespace Shoes.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removeForeignKey : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Shoes", "ImagesId", "dbo.Images");
            DropIndex("dbo.Shoes", new[] { "ImagesId" });
            DropColumn("dbo.Shoes", "ImagesId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Shoes", "ImagesId", c => c.Int(nullable: false));
            CreateIndex("dbo.Shoes", "ImagesId");
            AddForeignKey("dbo.Shoes", "ImagesId", "dbo.Images", "Id", cascadeDelete: true);
        }
    }
}
