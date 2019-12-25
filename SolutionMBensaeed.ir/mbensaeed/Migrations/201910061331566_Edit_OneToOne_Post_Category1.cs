namespace mbensaeed.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Edit_OneToOne_Post_Category1 : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.CatView", newName: "Categories");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.Categories", newName: "CatView");
        }
    }
}
