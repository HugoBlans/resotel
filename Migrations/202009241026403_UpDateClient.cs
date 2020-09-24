namespace ProjetRESOTEL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpDateClient : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Clients", "Nom", c => c.String(nullable: false, maxLength: 25, storeType: "nvarchar"));
            AlterColumn("dbo.Clients", "Prenom", c => c.String(nullable: false, maxLength: 25, storeType: "nvarchar"));
            AlterColumn("dbo.Clients", "Email", c => c.String(nullable: false, maxLength: 50, storeType: "nvarchar"));
            AlterColumn("dbo.Clients", "Telephone", c => c.String(nullable: false, maxLength: 10, storeType: "nvarchar"));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Clients", "Telephone", c => c.String(nullable: false, maxLength: 80, storeType: "nvarchar"));
            AlterColumn("dbo.Clients", "Email", c => c.String(nullable: false, maxLength: 80, storeType: "nvarchar"));
            AlterColumn("dbo.Clients", "Prenom", c => c.String(nullable: false, maxLength: 80, storeType: "nvarchar"));
            AlterColumn("dbo.Clients", "Nom", c => c.String(nullable: false, maxLength: 80, storeType: "nvarchar"));
        }
    }
}
