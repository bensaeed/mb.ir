namespace mbensaeed.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class category_dropID : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.CategoryPosts", "Category_ID", "dbo.Categories");
            DropPrimaryKey("dbo.Categories");
            AlterColumn("dbo.Categories", "ID", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.Categories", "ID");
            AddForeignKey("dbo.CategoryPosts", "Category_ID", "dbo.Categories", "ID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CategoryPosts", "Category_ID", "dbo.Categories");
            DropPrimaryKey("dbo.Categories");
            AlterColumn("dbo.Categories", "ID", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Categories", "ID");
            AddForeignKey("dbo.CategoryPosts", "Category_ID", "dbo.Categories", "ID", cascadeDelete: true);
        }
    }
}
