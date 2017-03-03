namespace ChurchWebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ChurchClaims",
                c => new
                    {
                        ID = c.Guid(nullable: false),
                        UserId = c.Guid(nullable: false),
                        MinistryId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Ministries", t => t.MinistryId, cascadeDelete: true)
                .Index(t => t.MinistryId);
            
            CreateTable(
                "dbo.Ministries",
                c => new
                    {
                        ID = c.Guid(nullable: false),
                        MinistryCategoryId = c.Guid(nullable: false),
                        MinistrySizeId = c.Guid(nullable: false),
                        DenominationId = c.Guid(nullable: false),
                        CountryId = c.Guid(nullable: false),
                        Name = c.String(nullable: false),
                        PhoneNumber1 = c.String(),
                        PhoneNumber2 = c.String(),
                        Email = c.String(nullable: false),
                        Town = c.String(),
                        State = c.String(),
                        Vision = c.String(maxLength: 160),
                        Mission = c.String(maxLength: 160),
                        About = c.String(maxLength: 160),
                        Logo = c.String(),
                        LogoBlob = c.String(),
                        FacebookUrl = c.String(),
                        TwitterUrl = c.String(),
                        YoutubeUrl = c.String(),
                        InstagramUrl = c.String(),
                        Source = c.String(),
                        DateEntered = c.DateTime(nullable: false),
                        DateClaimed = c.DateTime(nullable: false),
                        IsVerified = c.Boolean(nullable: false),
                        IsClaimed = c.Boolean(nullable: false),
                        ChurchType_ID = c.Guid(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.MinistrySizes", t => t.MinistrySizeId, cascadeDelete: true)
                .ForeignKey("dbo.MinistryCategories", t => t.ChurchType_ID)
                .ForeignKey("dbo.Countries", t => t.CountryId, cascadeDelete: true)
                .ForeignKey("dbo.Denominations", t => t.DenominationId, cascadeDelete: true)
                .ForeignKey("dbo.MinistryCategories", t => t.MinistryCategoryId, cascadeDelete: true)
                .Index(t => t.MinistryCategoryId)
                .Index(t => t.MinistrySizeId)
                .Index(t => t.DenominationId)
                .Index(t => t.CountryId)
                .Index(t => t.ChurchType_ID);
            
            CreateTable(
                "dbo.MinistrySizes",
                c => new
                    {
                        ID = c.Guid(nullable: false),
                        Size = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.MinistryCategories",
                c => new
                    {
                        ID = c.Guid(nullable: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Countries",
                c => new
                    {
                        ID = c.Guid(nullable: false),
                        Name = c.String(),
                        Flag = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Denominations",
                c => new
                    {
                        ID = c.Guid(nullable: false),
                        Type = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Vibes",
                c => new
                    {
                        ID = c.Guid(nullable: false),
                        Name = c.String(),
                        Ministry_ID = c.Guid(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Ministries", t => t.Ministry_ID)
                .Index(t => t.Ministry_ID);
            
            CreateTable(
                "dbo.Pastors",
                c => new
                    {
                        iD = c.Guid(nullable: false),
                        MinistyId = c.Guid(nullable: false),
                        Name = c.String(),
                        PhoneNumber1 = c.String(),
                        PhoneNumber2 = c.String(),
                        Email = c.String(),
                        Qualification = c.String(),
                        Biography = c.String(),
                        Picture = c.String(),
                        PictureBlob = c.String(),
                        PictureWithWife = c.String(),
                        PictureWithWifeBlob = c.String(),
                        Facebook = c.String(),
                        Twitter = c.String(),
                        Youtube = c.String(),
                        Instagram = c.String(),
                        VideoIntroduction = c.String(),
                        IsMainPastor = c.Boolean(nullable: false),
                        Ministry_ID = c.Guid(),
                    })
                .PrimaryKey(t => t.iD)
                .ForeignKey("dbo.Ministries", t => t.Ministry_ID)
                .Index(t => t.Ministry_ID);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.ChurchClaims", "MinistryId", "dbo.Ministries");
            DropForeignKey("dbo.Pastors", "Ministry_ID", "dbo.Ministries");
            DropForeignKey("dbo.Vibes", "Ministry_ID", "dbo.Ministries");
            DropForeignKey("dbo.Ministries", "MinistryCategoryId", "dbo.MinistryCategories");
            DropForeignKey("dbo.Ministries", "DenominationId", "dbo.Denominations");
            DropForeignKey("dbo.Ministries", "CountryId", "dbo.Countries");
            DropForeignKey("dbo.Ministries", "ChurchType_ID", "dbo.MinistryCategories");
            DropForeignKey("dbo.Ministries", "MinistrySizeId", "dbo.MinistrySizes");
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.Pastors", new[] { "Ministry_ID" });
            DropIndex("dbo.Vibes", new[] { "Ministry_ID" });
            DropIndex("dbo.Ministries", new[] { "ChurchType_ID" });
            DropIndex("dbo.Ministries", new[] { "CountryId" });
            DropIndex("dbo.Ministries", new[] { "DenominationId" });
            DropIndex("dbo.Ministries", new[] { "MinistrySizeId" });
            DropIndex("dbo.Ministries", new[] { "MinistryCategoryId" });
            DropIndex("dbo.ChurchClaims", new[] { "MinistryId" });
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Pastors");
            DropTable("dbo.Vibes");
            DropTable("dbo.Denominations");
            DropTable("dbo.Countries");
            DropTable("dbo.MinistryCategories");
            DropTable("dbo.MinistrySizes");
            DropTable("dbo.Ministries");
            DropTable("dbo.ChurchClaims");
        }
    }
}
