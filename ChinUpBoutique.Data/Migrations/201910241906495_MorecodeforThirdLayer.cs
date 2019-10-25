namespace ChinUpBoutique.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MorecodeforThirdLayer : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.UserReview", "Content", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.UserReview", "Content", c => c.String(nullable: false, maxLength: 300));
        }
    }
}
