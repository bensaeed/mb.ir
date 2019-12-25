namespace mbensaeed.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _1 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Posts", "ViewCount");
            DropColumn("dbo.Posts", "LikeCount");
            DropColumn("dbo.Posts", "ImageUrl");
            DropColumn("dbo.Posts", "Discriminator");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Posts", "Discriminator", c => c.String(nullable: false, maxLength: 128));
            AddColumn("dbo.Posts", "ImageUrl", c => c.String());
            AddColumn("dbo.Posts", "LikeCount", c => c.Int());
            AddColumn("dbo.Posts", "ViewCount", c => c.Int());
        }
    }
}
