namespace Vidly3rdTime.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedNmeColumnInMembeshipTypesTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.MembershipTypes", "Name", c => c.String(nullable: false, maxLength: 64));
        }
        
        public override void Down()
        {
            DropColumn("dbo.MembershipTypes", "Name");
        }
    }
}
