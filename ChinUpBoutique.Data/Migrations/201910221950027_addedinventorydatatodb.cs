namespace ChinUpBoutique.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedinventorydatatodb : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Inventory",
                c => new
                    {
                        ItemID = c.Int(nullable: false, identity: true),
                        ItemName = c.String(),
                        SkuNumber = c.Int(nullable: false),
                        ItemDescription = c.String(),
                        ItemPrice = c.Double(nullable: false),
                        TypeOfItem = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ItemID);
            
            AlterColumn("dbo.Appointment", "CustomerID", c => c.Guid(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Appointment", "CustomerID", c => c.Guid());
            DropTable("dbo.Inventory");
        }
    }
}
