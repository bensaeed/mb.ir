namespace mbensaeed.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mm_v1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Actions",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        ID_Post = c.String(),
                        ID_ActionType = c.Int(nullable: false),
                        DateShamsi = c.String(),
                        DateMiladi = c.String(),
                        ActionTime = c.String(),
                        IP_Address = c.String(),
                        Browser = c.String(),
                        Device = c.String(),
                        HostName = c.String(),
                        MoreInfo = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            AddColumn("dbo.Posts", "ViewCount", c => c.Int());
            AddColumn("dbo.Posts", "LikeCount", c => c.Int());
            AddColumn("dbo.Posts", "Discriminator", c => c.String(nullable: false, maxLength: 128));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Posts", "Discriminator");
            DropColumn("dbo.Posts", "LikeCount");
            DropColumn("dbo.Posts", "ViewCount");
            DropTable("dbo.Actions");
        }
    }
}
