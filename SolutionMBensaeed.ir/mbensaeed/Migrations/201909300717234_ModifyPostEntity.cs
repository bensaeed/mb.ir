namespace mbensaeed.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModifyPostEntity : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Posts", "Category_ID", "dbo.Categories");
            DropIndex("dbo.Posts", new[] { "Category_ID" });
            RenameColumn(table: "dbo.Posts", name: "Category_ID", newName: "CategoryID");
            AlterColumn("dbo.Posts", "CategoryID", c => c.Int(nullable: false));
            CreateIndex("dbo.Posts", "CategoryID");
            AddForeignKey("dbo.Posts", "CategoryID", "dbo.Categories", "ID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Posts", "CategoryID", "dbo.Categories");
            DropIndex("dbo.Posts", new[] { "CategoryID" });
            AlterColumn("dbo.Posts", "CategoryID", c => c.Int());
            RenameColumn(table: "dbo.Posts", name: "CategoryID", newName: "Category_ID");
            CreateIndex("dbo.Posts", "Category_ID");
            AddForeignKey("dbo.Posts", "Category_ID", "dbo.Categories", "ID");
        }
    }
}
