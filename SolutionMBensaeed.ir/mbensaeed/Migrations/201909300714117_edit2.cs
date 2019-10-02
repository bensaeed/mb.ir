namespace mbensaeed.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class edit2 : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Posts", new[] { "Image_ID" });
            RenameColumn(table: "dbo.Posts", name: "Image_ID", newName: "ImageId");
            AlterColumn("dbo.Posts", "ImageId", c => c.String(maxLength: 128));
            CreateIndex("dbo.Posts", "ImageId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Posts", new[] { "ImageId" });
            AlterColumn("dbo.Posts", "ImageId", c => c.String(nullable: false, maxLength: 128));
            RenameColumn(table: "dbo.Posts", name: "ImageId", newName: "Image_ID");
            CreateIndex("dbo.Posts", "Image_ID");
        }
    }
}
