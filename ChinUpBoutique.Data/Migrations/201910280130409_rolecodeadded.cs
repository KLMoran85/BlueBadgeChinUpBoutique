namespace ChinUpBoutique.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class rolecodeadded : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Appointment", "SelectedStylistID", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Appointment", "SelectedStylistID");
        }
    }
}
