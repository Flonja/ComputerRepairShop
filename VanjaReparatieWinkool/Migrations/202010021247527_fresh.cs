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
                        Klant_CustomerId = c.Int(),
                        Werknemer_EmployeeId = c.Int(),
                    })
                .PrimaryKey(t => t.AssignmentId)
                .ForeignKey("dbo.CustomerModels", t => t.Klant_CustomerId)
                .ForeignKey("dbo.EmployeeModels", t => t.Werknemer_EmployeeId)
                .Index(t => t.Klant_CustomerId)
                .Index(t => t.Werknemer_EmployeeId);
            
            CreateTable(
                "dbo.CustomerModels",
                c => new
                    {
                        CustomerId = c.Int(nullable: false, identity: true),
                        Voornaam = c.String(),
                        Achternaam = c.String(),
                        Adres = c.String(),
                        Postcode = c.String(),
                        Provincie = c.String(),
                    })
                .PrimaryKey(t => t.CustomerId);
            
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
                "dbo.EmployeeModels",
                c => new
                    {
                        EmployeeId = c.Int(nullable: false, identity: true),
                        Voornaam = c.String(),
                        Achternaam = c.String(),
                        Adres = c.String(),
                        Postcode = c.String(),
                        Provincie = c.String(),
                    })
                .PrimaryKey(t => t.EmployeeId);
            
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
            DropForeignKey("dbo.AssignmentModels", "Werknemer_EmployeeId", "dbo.EmployeeModels");
            DropForeignKey("dbo.PartModelAssignmentModels", "AssignmentModel_AssignmentId", "dbo.AssignmentModels");
            DropForeignKey("dbo.PartModelAssignmentModels", "PartModel_PartId", "dbo.PartModels");
            DropForeignKey("dbo.AssignmentModels", "Klant_CustomerId", "dbo.CustomerModels");
            DropIndex("dbo.PartModelAssignmentModels", new[] { "AssignmentModel_AssignmentId" });
            DropIndex("dbo.PartModelAssignmentModels", new[] { "PartModel_PartId" });
            DropIndex("dbo.AssignmentModels", new[] { "Werknemer_EmployeeId" });
            DropIndex("dbo.AssignmentModels", new[] { "Klant_CustomerId" });
            DropTable("dbo.PartModelAssignmentModels");
            DropTable("dbo.EmployeeModels");
            DropTable("dbo.PartModels");
            DropTable("dbo.CustomerModels");
            DropTable("dbo.AssignmentModels");
        }
    }
}
