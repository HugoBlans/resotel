namespace ProjetRESOTEL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Clients",
                c => new
                    {
                        IdentifiantCli = c.Int(nullable: false, identity: true),
                        Nom = c.String(nullable: false, maxLength: 80, storeType: "nvarchar"),
                        Prenom = c.String(nullable: false, maxLength: 80, storeType: "nvarchar"),
                        Email = c.String(nullable: false, maxLength: 80, storeType: "nvarchar"),
                        Telephone = c.String(nullable: false, maxLength: 80, storeType: "nvarchar"),
                    })
                .PrimaryKey(t => t.IdentifiantCli);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Identifiant = c.String(nullable: false, maxLength: 80, storeType: "nvarchar"),
                        Role = c.String(nullable: false, maxLength: 80, storeType: "nvarchar"),
                        Email = c.String(maxLength: 80, storeType: "nvarchar"),
                    })
                .PrimaryKey(t => t.Identifiant);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Users");
            DropTable("dbo.Clients");
        }
    }
}
