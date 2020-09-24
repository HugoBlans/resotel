namespace ProjetRESOTEL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FKrescli : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Reservations",
                c => new
                {
                    IdentifiantRes = c.Int(nullable: false, identity: true),
                    DateReservation = c.DateTime(nullable: false, precision: 0),
                    DateDebutSejour = c.DateTime(nullable: false, precision: 0),
                    NbNuits = c.Int(nullable: false),
                    IdentifiantCli = c.Int(nullable: false),
                })
                .PrimaryKey(t => t.IdentifiantRes)
                .ForeignKey("dbo.Clients", t => t.IdentifiantCli, cascadeDelete: true);
                //.Index(t => t.IdentifiantCli);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Reservations", "IdentifiantCli", "dbo.Clients");
            DropIndex("dbo.Reservations", new[] { "IdentifiantCli" });
            DropTable("dbo.Reservations");
        }
    }
}
