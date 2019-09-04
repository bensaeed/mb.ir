namespace mbensaeed.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class l : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Posts", "Image_id", c => c.Int());
            CreateIndex("dbo.Posts", "Image_id");
            AddForeignKey("dbo.Posts", "Image_id", "dbo.Images", "id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Posts", "Image_id", "dbo.Images");
            DropIndex("dbo.Posts", new[] { "Image_id" });
            DropColumn("dbo.Posts", "Image_id");
        }
    }
}
