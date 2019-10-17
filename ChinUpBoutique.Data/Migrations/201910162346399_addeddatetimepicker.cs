namespace ChinUpBoutique.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addeddatetimepicker : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Appointment", "DateOfAppointment", c => c.DateTime(nullable: false));
            DropColumn("dbo.Appointment", "DateTime");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Appointment", "DateTime", c => c.DateTime(nullable: false));
            DropColumn("dbo.Appointment", "DateOfAppointment");
        }
    }
}
