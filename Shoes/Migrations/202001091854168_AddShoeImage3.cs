namespace Shoes.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddShoeImage3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Shoes", "ImagesId", c => c.Int(nullable: false));
            CreateIndex("dbo.Shoes", "ImagesId");
            AddForeignKey("dbo.Shoes", "ImagesId", "dbo.Images", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Shoes", "ImagesId", "dbo.Images");
            DropIndex("dbo.Shoes", new[] { "ImagesId" });
            DropColumn("dbo.Shoes", "ImagesId");
        }
    }
}
