namespace mbensaeed.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EditModifi : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Posts", new[] { "ImageId" });
            CreateIndex("dbo.Posts", "ImageID");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Posts", new[] { "ImageID" });
            CreateIndex("dbo.Posts", "ImageId");
        }
    }
}
