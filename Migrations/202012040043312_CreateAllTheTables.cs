namespace Event.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateAllTheTables : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Evaluations",
                c => new
                    {
                        id = c.Long(nullable: false, identity: true),
                        userId = c.String(),
                        eventId = c.Long(nullable: false),
                        value = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Events", t => t.eventId, cascadeDelete: true)
                .Index(t => t.eventId);
            
            CreateTable(
                "dbo.Events",
                c => new
                    {
                        id = c.Long(nullable: false, identity: true),
                        subject = c.String(),
                        description = c.String(),
                        eventStatus = c.Int(nullable: false),
                        Image = c.String(),
                        eventCategoryId = c.Long(nullable: false),
                        createDate = c.DateTime(),
                        createBy = c.String(),
                        status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.EventCategories", t => t.eventCategoryId, cascadeDelete: true)
                .Index(t => t.eventCategoryId);
            
            CreateTable(
                "dbo.EventCategories",
                c => new
                    {
                        id = c.Long(nullable: false, identity: true),
                        name = c.String(),
                        createDate = c.DateTime(),
                        createBy = c.String(),
                        status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
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
                "dbo.UserInterestCateogries",
                c => new
                    {
                        id = c.Long(nullable: false, identity: true),
                        userId = c.String(),
                        eventCategoryId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.EventCategories", t => t.eventCategoryId, cascadeDelete: true)
                .Index(t => t.eventCategoryId);
            
            CreateTable(
                "dbo.UserParticipantsEvents",
                c => new
                    {
                        id = c.Long(nullable: false, identity: true),
                        userId = c.String(),
                        eventId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Events", t => t.eventId, cascadeDelete: true)
                .Index(t => t.eventId);
            
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
            DropForeignKey("dbo.UserParticipantsEvents", "eventId", "dbo.Events");
            DropForeignKey("dbo.UserInterestCateogries", "eventCategoryId", "dbo.EventCategories");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Evaluations", "eventId", "dbo.Events");
            DropForeignKey("dbo.Events", "eventCategoryId", "dbo.EventCategories");
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.UserParticipantsEvents", new[] { "eventId" });
            DropIndex("dbo.UserInterestCateogries", new[] { "eventCategoryId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.Events", new[] { "eventCategoryId" });
            DropIndex("dbo.Evaluations", new[] { "eventId" });
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.UserParticipantsEvents");
            DropTable("dbo.UserInterestCateogries");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.EventCategories");
            DropTable("dbo.Events");
            DropTable("dbo.Evaluations");
        }
    }
}
