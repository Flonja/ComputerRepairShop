namespace VanjaReparatieWinkool.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fresh : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AssignmentModels",
                c => new
                    {
                        AssignmentId = c.Int(nullable: false, identity: true),
                        Omschrijving = c.String(),
                        Status = c.Int(nullable: false),
                        StartDatum = c.DateTime(nullable: false),
                        EindDatum = c.DateTime(nullable: false),
                        Uren = c.Double(nullable: false),
                        Klant_Id = c.String(maxLength: 128),
                        Werknemer_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.AssignmentId)
                .ForeignKey("dbo.AspNetUsers", t => t.Klant_Id)
                .ForeignKey("dbo.AspNetUsers", t => t.Werknemer_Id)
                .Index(t => t.Klant_Id)
                .Index(t => t.Werknemer_Id);
            
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
                        Voornaam = c.String(),
                        Achternaam = c.String(),
                        Adres = c.String(),
                        Postcode = c.String(),
                        Provincie = c.Int(),
                        CustomerId = c.Int(),
                        EmployeeId = c.Int(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
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
                "dbo.PartModels",
                c => new
                    {
                        PartId = c.Int(nullable: false, identity: true),
                        Naam = c.String(),
                        Leverancier = c.String(),
                        Aantal = c.Int(nullable: false),
                        Prijs = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.PartId);
            
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
                "dbo.PartModelAssignmentModels",
                c => new
                    {
                        PartModel_PartId = c.Int(nullable: false),
                        AssignmentModel_AssignmentId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.PartModel_PartId, t.AssignmentModel_AssignmentId })
                .ForeignKey("dbo.PartModels", t => t.PartModel_PartId, cascadeDelete: true)
                .ForeignKey("dbo.AssignmentModels", t => t.AssignmentModel_AssignmentId, cascadeDelete: true)
                .Index(t => t.PartModel_PartId)
                .Index(t => t.AssignmentModel_AssignmentId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.AssignmentModels", "Werknemer_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.PartModelAssignmentModels", "AssignmentModel_AssignmentId", "dbo.AssignmentModels");
            DropForeignKey("dbo.PartModelAssignmentModels", "PartModel_PartId", "dbo.PartModels");
            DropForeignKey("dbo.AssignmentModels", "Klant_Id", "dbo.AspNetUsers");
            DropIndex("dbo.PartModelAssignmentModels", new[] { "AssignmentModel_AssignmentId" });
            DropIndex("dbo.PartModelAssignmentModels", new[] { "PartModel_PartId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AssignmentModels", new[] { "Werknemer_Id" });
            DropIndex("dbo.AssignmentModels", new[] { "Klant_Id" });
            DropTable("dbo.PartModelAssignmentModels");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.PartModels");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.AssignmentModels");
        }
    }
}
