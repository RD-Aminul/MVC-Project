namespace RailwayReservation.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Classes",
                c => new
                    {
                        ClassID = c.Int(nullable: false, identity: true),
                        ClassName = c.String(maxLength: 50),
                        Fare = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.ClassID);
            
            CreateTable(
                "dbo.Passengers",
                c => new
                    {
                        PassengerID = c.Int(nullable: false, identity: true),
                        PassengerName = c.String(),
                        PassengerEmail = c.String(),
                        PassengerPhone = c.String(),
                        JourneyDate = c.DateTime(nullable: false),
                        ImageName = c.String(),
                        ImageUrl = c.String(),
                        TrainNo = c.Int(nullable: false),
                        ClassID = c.Int(nullable: false),
                        RouteID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PassengerID)
                .ForeignKey("dbo.Classes", t => t.ClassID, cascadeDelete: true)
                .ForeignKey("dbo.Routes", t => t.RouteID, cascadeDelete: true)
                .ForeignKey("dbo.Trains", t => t.TrainNo, cascadeDelete: true)
                .Index(t => t.TrainNo)
                .Index(t => t.ClassID)
                .Index(t => t.RouteID);
            
            CreateTable(
                "dbo.Routes",
                c => new
                    {
                        RouteID = c.Int(nullable: false, identity: true),
                        RouteName = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.RouteID);
            
            CreateTable(
                "dbo.Trains",
                c => new
                    {
                        TrainNo = c.Int(nullable: false, identity: true),
                        TrainName = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.TrainNo);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                        Discriminator = c.String(nullable: false, maxLength: 128),
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
            DropForeignKey("dbo.Passengers", "TrainNo", "dbo.Trains");
            DropForeignKey("dbo.Passengers", "RouteID", "dbo.Routes");
            DropForeignKey("dbo.Passengers", "ClassID", "dbo.Classes");
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.Passengers", new[] { "RouteID" });
            DropIndex("dbo.Passengers", new[] { "ClassID" });
            DropIndex("dbo.Passengers", new[] { "TrainNo" });
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Trains");
            DropTable("dbo.Routes");
            DropTable("dbo.Passengers");
            DropTable("dbo.Classes");
        }
    }
}
