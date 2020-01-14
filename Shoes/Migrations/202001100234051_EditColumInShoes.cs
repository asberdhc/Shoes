namespace Shoes.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EditColumInShoes : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Shoes", "IsEnabled", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Shoes", "IsEnabled", c => c.Byte(nullable: false));
        }
    }
}
