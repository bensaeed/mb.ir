namespace mbensaeed.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_SeoMetaDescription_to_Post : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Posts", "SeoMetaDescription", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Posts", "SeoMetaDescription");
        }
    }
}
