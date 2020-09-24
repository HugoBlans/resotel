namespace ProjetRESOTEL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class alldb : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ChambreReservees",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    NbPersonne = c.Int(nullable: false),
                    IdentifiantRes = c.Int(nullable: false),
                    Numero = c.Int(nullable: false),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Chambres", t => t.Numero, cascadeDelete: true)
                .ForeignKey("dbo.Reservations", t => t.IdentifiantRes, cascadeDelete: true);
            //.Index(t => t.IdentifiantRes)
            //.Index(t => t.Numero);

            CreateTable(
                "dbo.DemandeOptions",
                c => new
                {
                    IdChambreReservee = c.Int(nullable: false),
                    IdOption = c.Int(nullable: false),
                    NbJour = c.Int(nullable: false),
                })
                .PrimaryKey(t => new { t.IdChambreReservee, t.IdOption })
                .ForeignKey("dbo.ChambreReservees", t => t.IdChambreReservee, cascadeDelete: true)
                .ForeignKey("dbo.Options", t => t.IdOption, cascadeDelete: true);
                //.Index(t => t.IdChambreReservee)
                //.Index(t => t.IdOption);
            
            CreateTable(
                "dbo.Options",
                c => new
                    {
                        NumOption = c.Int(nullable: false, identity: true),
                        Designation = c.String(nullable: false, maxLength: 50, storeType: "nvarchar"),
                        Prix = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.NumOption);

            CreateTable(
                "dbo.Repas",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    EstPetitDejeuner = c.Boolean(nullable: false),
                    DateRepas = c.DateTime(nullable: false, precision: 0),
                    IdChambreReservee = c.Int(nullable: false),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ChambreReservees", t => t.IdChambreReservee, cascadeDelete: true);
                //.Index(t => t.IdChambreReservee);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Repas", "IdChambreReservee", "dbo.ChambreReservees");
            DropForeignKey("dbo.DemandeOptions", "IdOption", "dbo.Options");
            DropForeignKey("dbo.DemandeOptions", "IdChambreReservee", "dbo.ChambreReservees");
            DropForeignKey("dbo.ChambreReservees", "IdentifiantRes", "dbo.Reservations");
            DropForeignKey("dbo.ChambreReservees", "Numero", "dbo.Chambres");
            DropIndex("dbo.Repas", new[] { "IdChambreReservee" });
            DropIndex("dbo.DemandeOptions", new[] { "IdOption" });
            DropIndex("dbo.DemandeOptions", new[] { "IdChambreReservee" });
            DropIndex("dbo.ChambreReservees", new[] { "Numero" });
            DropIndex("dbo.ChambreReservees", new[] { "IdentifiantRes" });
            DropTable("dbo.Repas");
            DropTable("dbo.Options");
            DropTable("dbo.DemandeOptions");
            DropTable("dbo.ChambreReservees");
        }
    }
}
