namespace ChinUpBoutique.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Apptcreatecodeadded : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Appointment", "SelectedStylistID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Appointment", "SelectedStylistID", c => c.Int(nullable: false));
        }
    }
}
