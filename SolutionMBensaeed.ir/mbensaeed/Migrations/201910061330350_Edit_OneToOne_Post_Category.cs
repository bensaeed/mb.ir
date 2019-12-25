namespace mbensaeed.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Edit_OneToOne_Post_Category : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Categories", newName: "CatView");
            DropForeignKey("dbo.CategoryPosts", "Category_ID", "dbo.Categories");
            DropForeignKey("dbo.CategoryPosts", "Post_ID", "dbo.Posts");
            DropIndex("dbo.CategoryPosts", new[] { "Category_ID" });
            DropIndex("dbo.CategoryPosts", new[] { "Post_ID" });
            DropPrimaryKey("dbo.CatView");
            AddColumn("dbo.Posts", "CategoryID", c => c.Int(nullable: false));
            AlterColumn("dbo.CatView", "ID", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.CatView", "ID");
            CreateIndex("dbo.Posts", "CategoryID");
            AddForeignKey("dbo.Posts", "CategoryID", "dbo.CatView", "ID", cascadeDelete: true);
            DropTable("dbo.CategoryPosts");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.CategoryPosts",
                c => new
                    {
                        Category_ID = c.Int(nullable: false),
                        Post_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Category_ID, t.Post_ID });
            
            DropForeignKey("dbo.Posts", "CategoryID", "dbo.CatView");
            DropIndex("dbo.Posts", new[] { "CategoryID" });
            DropPrimaryKey("dbo.CatView");
            AlterColumn("dbo.CatView", "ID", c => c.Int(nullable: false));
            DropColumn("dbo.Posts", "CategoryID");
            AddPrimaryKey("dbo.CatView", "ID");
            CreateIndex("dbo.CategoryPosts", "Post_ID");
            CreateIndex("dbo.CategoryPosts", "Category_ID");
            AddForeignKey("dbo.CategoryPosts", "Post_ID", "dbo.Posts", "ID", cascadeDelete: true);
            AddForeignKey("dbo.CategoryPosts", "Category_ID", "dbo.Categories", "ID", cascadeDelete: true);
            RenameTable(name: "dbo.CatView", newName: "Categories");
        }
    }
}
