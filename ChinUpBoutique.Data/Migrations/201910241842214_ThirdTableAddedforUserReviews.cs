namespace ChinUpBoutique.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ThirdTableAddedforUserReviews : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UserReview",
                c => new
                    {
                        ReviewID = c.Int(nullable: false, identity: true),
                        StylistID = c.String(),
                        OwnerID = c.Guid(nullable: false),
                        Title = c.String(nullable: false),
                        Content = c.String(nullable: false, maxLength: 300),
                        CreatedUtc = c.DateTimeOffset(nullable: false, precision: 7),
                        ModifiedUtc = c.DateTimeOffset(precision: 7),
                    })
                .PrimaryKey(t => t.ReviewID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.UserReview");
        }
    }
}
