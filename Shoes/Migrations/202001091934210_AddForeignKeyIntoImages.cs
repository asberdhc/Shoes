namespace Shoes.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddForeignKeyIntoImages : DbMigration
    {
        public override void Up()
        {
            Sql("TRUNCATE TABLE Images");
            Sql("TRUNCATE TABLE Shoes");
        }
        
        public override void Down()
        {
        }
    }
}
