namespace MyParking.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'5da4d328-e48f-4197-991c-81410a7b2a87', N'admin@myparking.com', 0, N'AFrLYZymrzqq0hON5R2Y5FDcNdmLk6yndROvB9NhtBqSVskS1GnbSAZcVNhuXKN9Xg==', N'1f957e7a-da8b-4ec0-b6cb-ebe0b2c917b8', NULL, 0, 0, NULL, 1, 0, N'admin@myparking.com')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'652ab15e-5488-49f9-9c14-7c8a821654fb', N'guest@myparking.com', 0, N'ACmTs8KOVON6V97W2hA0YHnYe0V8gDkAUxMGNEF7USzPRNgJMMT98o0/qx4Es2x1kw==', N'0cdcf16e-165a-472a-9041-2bb3faf7dfa4', NULL, 0, 0, NULL, 1, 0, N'guest@myparking.com')

INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'f6c002e3-0914-4894-ad30-4ca152c5e031', N'CanManageParkingLots')

INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'5da4d328-e48f-4197-991c-81410a7b2a87', N'f6c002e3-0914-4894-ad30-4ca152c5e031')

");
        }
        
        public override void Down()
        {
        }
    }
}
