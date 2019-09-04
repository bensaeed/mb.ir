namespace mbensaeed.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class a : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Posts", "ImageUrl");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Posts", "ImageUrl", c => c.String());
        }
    }
}
