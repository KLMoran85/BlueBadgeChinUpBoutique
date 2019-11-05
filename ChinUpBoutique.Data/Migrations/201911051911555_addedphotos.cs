namespace ChinUpBoutique.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedphotos : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Inventory", "Photo", c => c.Binary());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Inventory", "Photo");
        }
    }
}
