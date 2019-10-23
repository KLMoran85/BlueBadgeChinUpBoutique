namespace ChinUpBoutique.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatedinventorycode : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Inventory", "SkuNumber", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Inventory", "SkuNumber", c => c.Int(nullable: false));
        }
    }
}
