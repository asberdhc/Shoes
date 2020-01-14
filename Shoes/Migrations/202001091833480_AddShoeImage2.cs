namespace Shoes.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddShoeImage2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Images", "Shoe_Id", "dbo.Shoes");
            DropIndex("dbo.Images", new[] { "Shoe_Id" });
            DropColumn("dbo.Images", "Shoe_Id");
            DropColumn("dbo.Shoes", "ImagesId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Shoes", "ImagesId", c => c.Int(nullable: false));
            AddColumn("dbo.Images", "Shoe_Id", c => c.Int());
            CreateIndex("dbo.Images", "Shoe_Id");
            AddForeignKey("dbo.Images", "Shoe_Id", "dbo.Shoes", "Id");
        }
    }
}
