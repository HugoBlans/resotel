namespace ProjetRESOTEL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ajoutNumEtage : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Chambres", "NumEtage", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Chambres", "NumEtage");
        }
    }
}
