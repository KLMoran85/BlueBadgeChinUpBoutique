namespace ChinUpBoutique.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changestodatabase : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Appointment", "CustomerFirstName", c => c.String(nullable: false));
            AddColumn("dbo.Appointment", "CustomerLastName", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Appointment", "CustomerLastName");
            DropColumn("dbo.Appointment", "CustomerFirstName");
        }
    }
}
