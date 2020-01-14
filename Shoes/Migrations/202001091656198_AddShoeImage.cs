namespace Shoes.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddShoeImage : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Images",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RawImage = c.Binary(),
                        ColorHex = c.String(),
                        Shoe_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Shoes", t => t.Shoe_Id)
                .Index(t => t.Shoe_Id);
            
            CreateTable(
                "dbo.Shoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 15),
                        Description = c.String(maxLength: 255),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ImagesId = c.Int(nullable: false),
                        IsEnabled = c.Byte(nullable: false),
                        Updated = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Images", "Shoe_Id", "dbo.Shoes");
            DropIndex("dbo.Images", new[] { "Shoe_Id" });
            DropTable("dbo.Shoes");
            DropTable("dbo.Images");
        }
    }
}
