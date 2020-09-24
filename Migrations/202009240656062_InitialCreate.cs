namespace ProjetRESOTEL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
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
        }
    }
}
