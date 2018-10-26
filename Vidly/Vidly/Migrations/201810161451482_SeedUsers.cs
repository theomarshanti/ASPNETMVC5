namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
                INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'5cd35cf0-7344-4e45-aa8a-4dd6b1207fa4', N'guest@vidly.com', 0, N'AOveHN13qEtmFHHy8NPOjO/BMW5cApDrB+CsP7N8KncRLrLTBHmL+KKyLZ7KXc00Jg==', N'bb461118-fd44-430f-96fa-984c9fc8bdef', NULL, 0, 0, NULL, 1, 0, N'guest@vidly.com')
                INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'68fa36f6-a86c-485d-b39f-900ae6bec3f2', N'admin@vidly.com', 0, N'ADD9SIRyBiWtKvpU7wzlBgByAe7eryGwC2GvOsfUaN5oSNelrYpMaPcq05LngSIa9Q==', N'9f4558ae-72dd-4144-95dc-c0f1115f9ee1', NULL, 0, 0, NULL, 1, 0, N'admin@vidly.com')
                
                INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'f0fb0920-ad83-4631-8236-e3704a74793a', N'CanManageMovie')
                
                INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'68fa36f6-a86c-485d-b39f-900ae6bec3f2', N'f0fb0920-ad83-4631-8236-e3704a74793a')
");


        }
        
        public override void Down()
        {
        }
    }
}
