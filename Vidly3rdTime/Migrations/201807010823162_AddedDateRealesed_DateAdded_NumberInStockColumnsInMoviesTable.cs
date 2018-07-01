namespace Vidly3rdTime.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedDateRealesed_DateAdded_NumberInStockColumnsInMoviesTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Movies", "DateRealesed", c => c.DateTime(nullable: false));
            AddColumn("dbo.Movies", "DateAdded", c => c.DateTime(nullable: false));
            AddColumn("dbo.Movies", "NumberInStock", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Movies", "NumberInStock");
            DropColumn("dbo.Movies", "DateAdded");
            DropColumn("dbo.Movies", "DateRealesed");
        }
    }
}
