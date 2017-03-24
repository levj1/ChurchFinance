namespace ChurchFinanceSite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'08b5d813-4a99-4a78-870a-b4bfd4b7ec87', N'finance.admin@gmail.com', 0, N'ABigV3a0vm63SBbFmRtY4/EzSpPpY/UokWKB/2rZpn67++kVLMcTy6eQTP+WvQ5p8w==', N'490f9af1-bab6-4549-9139-9e3e596c13d2', NULL, 0, 0, NULL, 1, 0, N'finance.admin@gmail.com')
                INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'1e05a7e3-a3db-4093-9185-8cebcbfc4b70', N'church.member@gmail.com', 0, N'AL4tBrIfybMlzLKltqWi4VM7QJJcSg2POHQiNIwvAPDajKliXqRP4HL2LJzk+k3GGA==', N'7d35a3d5-ad18-446d-8c87-4b595b506f36', NULL, 0, 0, NULL, 1, 0, N'church.member@gmail.com')
                
                INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'5eed9d36-a99a-490b-a291-4f7da1c5c262', N'CanManageFinance')

                INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'08b5d813-4a99-4a78-870a-b4bfd4b7ec87', N'5eed9d36-a99a-490b-a291-4f7da1c5c262')


            ");
        }
        
        public override void Down()
        {
        }
    }
}
