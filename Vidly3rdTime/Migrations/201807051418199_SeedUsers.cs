namespace Vidly3rdTime.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'29dce202-6591-4fa6-8ad2-5221f5887647', N'guest@vidly.com', 0, N'AKT+XLtg63HFRaFYMOPiXNDFYJNh7ZI3cAbXh30NGn4/A9VOiwigU0lW2Ptc5MvYsw==', N'e5859724-caaf-46be-9cb1-e10a6f878693', NULL, 0, 0, NULL, 1, 0, N'guest@vidly.com')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'5f9a6366-51c4-4ca3-b822-516e836b6453', N'admin@vidly.com', 0, N'AOpNSu4mQ4BjRbzNsclCe0h4E1M/W+K1BY4qFc+bXylQTUgfXni73zQqrwvO9iWmlg==', N'ea334879-2422-4c72-a0c8-c54a7269032a', NULL, 0, 0, NULL, 1, 0, N'admin@vidly.com')

INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'b4902af9-0ea3-4570-8130-e943cdc391cf', N'CanManageMovies')

INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'5f9a6366-51c4-4ca3-b822-516e836b6453', N'b4902af9-0ea3-4570-8130-e943cdc391cf')


");

        }
        
        public override void Down()
        {
        }
    }
}
