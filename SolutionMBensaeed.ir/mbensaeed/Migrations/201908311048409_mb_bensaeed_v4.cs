namespace mbensaeed.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mb_bensaeed_v4 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Posts",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Content = c.String(),
                        ImageUrl = c.String(),
                        IsActive = c.String(),
                        Category = c.String(),
                        PostDate = c.String(),
                        PostTime = c.String(),
                        Labels = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Posts");
        }
    }
}
