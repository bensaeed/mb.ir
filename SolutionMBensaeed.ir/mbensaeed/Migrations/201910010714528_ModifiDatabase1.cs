namespace mbensaeed.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModifiDatabase1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Posts", "CategoryID", "dbo.Categories");
            DropIndex("dbo.Posts", new[] { "CategoryID" });
            CreateTable(
                "dbo.CategoryPosts",
                c => new
                    {
                        Category_ID = c.Int(nullable: false),
                        Post_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Category_ID, t.Post_ID })
                .ForeignKey("dbo.Categories", t => t.Category_ID, cascadeDelete: true)
                .ForeignKey("dbo.Posts", t => t.Post_ID, cascadeDelete: true)
                .Index(t => t.Category_ID)
                .Index(t => t.Post_ID);
            
            DropColumn("dbo.Posts", "CategoryID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Posts", "CategoryID", c => c.Int(nullable: false));
            DropForeignKey("dbo.CategoryPosts", "Post_ID", "dbo.Posts");
            DropForeignKey("dbo.CategoryPosts", "Category_ID", "dbo.Categories");
            DropIndex("dbo.CategoryPosts", new[] { "Post_ID" });
            DropIndex("dbo.CategoryPosts", new[] { "Category_ID" });
            DropTable("dbo.CategoryPosts");
            CreateIndex("dbo.Posts", "CategoryID");
            AddForeignKey("dbo.Posts", "CategoryID", "dbo.Categories", "ID", cascadeDelete: true);
        }
    }
}
