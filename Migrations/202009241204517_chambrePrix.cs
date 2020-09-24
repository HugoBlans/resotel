namespace ProjetRESOTEL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class chambrePrix : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Chambres",
                c => new
                    {
                        Numero = c.Int(nullable: false, identity: true),
                        NbLit = c.Int(nullable: false),
                        LitEnfant = c.Boolean(nullable: false),
                        LitDouble = c.Boolean(nullable: false),
                        DateDernierMenage = c.DateTime(nullable: false, precision: 0),
                    })
                .PrimaryKey(t => t.Numero);
            
            CreateTable(
                "dbo.Prix",
                c => new
                    {
                        idPrix = c.Int(nullable: false, identity: true),
                        prix = c.Decimal(nullable: false, precision: 18, scale: 2),
                        NbNuit = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.idPrix);

            CreateTable(
                "dbo.PrixChambres",
                c => new
                {
                    Prix_idPrix = c.Int(nullable: false),
                    Chambre_Numero = c.Int(nullable: false),
                })
                .PrimaryKey(t => new { t.Prix_idPrix, t.Chambre_Numero })
                .ForeignKey("dbo.Prix", t => t.Prix_idPrix, cascadeDelete: true)
                .ForeignKey("dbo.Chambres", t => t.Chambre_Numero, cascadeDelete: true);
                //.Index(t => t.Prix_idPrix)
                //.Index(t => t.Chambre_Numero);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PrixChambres", "Chambre_Numero", "dbo.Chambres");
            DropForeignKey("dbo.PrixChambres", "Prix_idPrix", "dbo.Prix");
            DropIndex("dbo.PrixChambres", new[] { "Chambre_Numero" });
            DropIndex("dbo.PrixChambres", new[] { "Prix_idPrix" });
            DropTable("dbo.PrixChambres");
            DropTable("dbo.Prix");
            DropTable("dbo.Chambres");
        }
    }
}
