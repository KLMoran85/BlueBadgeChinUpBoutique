namespace ChinUpBoutique.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EvenMorecodeforThirdLayer : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.UserReview", "StylistID", c => c.String(maxLength: 128));
            CreateIndex("dbo.UserReview", "StylistID");
            AddForeignKey("dbo.UserReview", "StylistID", "dbo.ApplicationUser", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserReview", "StylistID", "dbo.ApplicationUser");
            DropIndex("dbo.UserReview", new[] { "StylistID" });
            AlterColumn("dbo.UserReview", "StylistID", c => c.String());
        }
    }
}
