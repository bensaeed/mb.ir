namespace mbensaeed.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class m : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Activities", new[] { "Posts_id" });
            DropIndex("dbo.Posts", new[] { "Image_id" });
            CreateIndex("dbo.Activities", "Posts_ID");
            CreateIndex("dbo.Posts", "Image_ID");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Posts", new[] { "Image_ID" });
            DropIndex("dbo.Activities", new[] { "Posts_ID" });
            CreateIndex("dbo.Posts", "Image_id");
            CreateIndex("dbo.Activities", "Posts_id");
        }
    }
}
