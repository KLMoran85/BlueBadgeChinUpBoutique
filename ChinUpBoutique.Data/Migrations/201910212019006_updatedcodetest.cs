namespace ChinUpBoutique.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatedcodetest : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Appointment", "CustomerID", c => c.Int(nullable: false));
            DropColumn("dbo.Appointment", "UserID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Appointment", "UserID", c => c.Int(nullable: false));
            DropColumn("dbo.Appointment", "CustomerID");
        }
    }
}
