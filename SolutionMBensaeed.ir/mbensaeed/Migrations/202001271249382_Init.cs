namespace mbensaeed.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Activities",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        DateShamsi = c.String(maxLength: 8),
                        DateMiladi = c.String(maxLength: 8),
                        ActionTime = c.String(maxLength: 8),
                        IP_Address = c.String(maxLength: 30),
                        Browser = c.String(maxLength: 100),
                        Device = c.String(maxLength: 500),
                        HostName = c.String(maxLength: 100),
                        MoreInfo = c.String(maxLength: 500),
                        PostId = c.Int(),
                        ActivityTypeId = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.ActivityTypes", t => t.ActivityTypeId)
                .ForeignKey("dbo.Posts", t => t.PostId)
                .Index(t => t.PostId)
                .Index(t => t.ActivityTypeId);
            
            CreateTable(
                "dbo.ActivityTypes",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 20),
                        Description = c.String(maxLength: 100),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Posts",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 300),
                        Content = c.String(nullable: false),
                        IsActive = c.String(maxLength: 1),
                        PostDate = c.String(maxLength: 8),
                        PostTime = c.String(maxLength: 10),
                        Labels = c.String(maxLength: 1000),
                        ImageID = c.String(maxLength: 128),
                        CategoryID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Categories", t => t.CategoryID, cascadeDelete: true)
                .ForeignKey("dbo.Images", t => t.ImageID)
                .Index(t => t.ImageID)
                .Index(t => t.CategoryID);
            
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        DescriptionFa = c.String(nullable: false, maxLength: 200),
                        DescriptionEn = c.String(maxLength: 200),
                        IsActive = c.String(maxLength: 1),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Images",
                c => new
                    {
                        ID = c.String(nullable: false, maxLength: 128),
                        FileName = c.String(nullable: false, maxLength: 60),
                        FileSize = c.String(maxLength: 10),
                        TitleUrl = c.String(maxLength: 50),
                        FileUrl = c.String(nullable: false, maxLength: 1200),
                        FilePathOnServer = c.String(nullable: false, maxLength: 1200),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Comments",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        FullName = c.String(maxLength: 100),
                        PhoneNumber = c.String(nullable: false, maxLength: 30),
                        Email = c.String(maxLength: 120),
                        CommentUser = c.String(nullable: false),
                        SendDate = c.String(maxLength: 8),
                        SendTime = c.String(maxLength: 8),
                        Is_Read = c.String(maxLength: 1),
                        ReadTime = c.String(maxLength: 8),
                        ReadDateMiladi = c.String(maxLength: 8),
                        ReadDateShamsi = c.String(maxLength: 8),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.People",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PostComments",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        PostID = c.Int(nullable: false),
                        FullName = c.String(maxLength: 100),
                        Email = c.String(maxLength: 120),
                        Comment = c.String(nullable: false),
                        SendDate = c.String(maxLength: 8),
                        SendTime = c.String(maxLength: 8),
                        Is_Read = c.String(maxLength: 1),
                        Is_Active = c.String(maxLength: 1),
                        IP_Address = c.String(maxLength: 30),
                        Browser = c.String(maxLength: 100),
                        DeviceInfo = c.String(maxLength: 500),
                        HostName = c.String(maxLength: 100),
                        query = c.String(maxLength: 100),
                        status = c.String(maxLength: 30),
                        country = c.String(maxLength: 100),
                        countryCode = c.String(maxLength: 20),
                        region = c.String(maxLength: 10),
                        regionName = c.String(maxLength: 100),
                        city = c.String(maxLength: 100),
                        district = c.String(maxLength: 100),
                        zip = c.String(maxLength: 80),
                        lat = c.Double(nullable: false),
                        lon = c.Double(nullable: false),
                        timezone = c.String(maxLength: 40),
                        isp = c.String(maxLength: 100),
                        org = c.String(maxLength: 100),
                        _as = c.String(name: "as", maxLength: 100),
                        reverse = c.String(maxLength: 100),
                        mobile = c.Boolean(nullable: false),
                        proxy = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Posts", t => t.PostID, cascadeDelete: true)
                .Index(t => t.PostID);
            
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
            
            CreateTable(
                "dbo.WebsiteVisits",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        DateMiladi = c.String(maxLength: 8),
                        DateShamsi = c.String(maxLength: 8),
                        VisitTime = c.String(maxLength: 8),
                        IP_Address = c.String(maxLength: 30),
                        Browser = c.String(maxLength: 100),
                        DeviceInfo = c.String(maxLength: 500),
                        HostName = c.String(maxLength: 100),
                        query = c.String(maxLength: 100),
                        status = c.String(maxLength: 30),
                        country = c.String(maxLength: 100),
                        countryCode = c.String(maxLength: 20),
                        region = c.String(maxLength: 10),
                        regionName = c.String(maxLength: 100),
                        city = c.String(maxLength: 100),
                        district = c.String(maxLength: 100),
                        zip = c.String(maxLength: 80),
                        lat = c.Double(nullable: false),
                        lon = c.Double(nullable: false),
                        timezone = c.String(maxLength: 40),
                        isp = c.String(maxLength: 100),
                        org = c.String(maxLength: 100),
                        _as = c.String(name: "as", maxLength: 100),
                        reverse = c.String(maxLength: 100),
                        mobile = c.Boolean(nullable: false),
                        proxy = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.PostComments", "PostID", "dbo.Posts");
            DropForeignKey("dbo.Posts", "ImageID", "dbo.Images");
            DropForeignKey("dbo.Posts", "CategoryID", "dbo.Categories");
            DropForeignKey("dbo.Activities", "PostId", "dbo.Posts");
            DropForeignKey("dbo.Activities", "ActivityTypeId", "dbo.ActivityTypes");
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.PostComments", new[] { "PostID" });
            DropIndex("dbo.Posts", new[] { "CategoryID" });
            DropIndex("dbo.Posts", new[] { "ImageID" });
            DropIndex("dbo.Activities", new[] { "ActivityTypeId" });
            DropIndex("dbo.Activities", new[] { "PostId" });
            DropTable("dbo.WebsiteVisits");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.PostComments");
            DropTable("dbo.People");
            DropTable("dbo.Comments");
            DropTable("dbo.Images");
            DropTable("dbo.Categories");
            DropTable("dbo.Posts");
            DropTable("dbo.ActivityTypes");
            DropTable("dbo.Activities");
        }
    }
}
