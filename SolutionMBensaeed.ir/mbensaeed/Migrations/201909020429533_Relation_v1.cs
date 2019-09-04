namespace mbensaeed.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Relation_v1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ActionTypes",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            AddColumn("dbo.Actions", "ActionType_ID", c => c.Int());
            AddColumn("dbo.Actions", "Posts_id", c => c.Int());
            CreateIndex("dbo.Actions", "ActionType_ID");
            CreateIndex("dbo.Actions", "Posts_id");
            AddForeignKey("dbo.Actions", "ActionType_ID", "dbo.ActionTypes", "ID");
            AddForeignKey("dbo.Actions", "Posts_id", "dbo.Posts", "id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Actions", "Posts_id", "dbo.Posts");
            DropForeignKey("dbo.Actions", "ActionType_ID", "dbo.ActionTypes");
            DropIndex("dbo.Actions", new[] { "Posts_id" });
            DropIndex("dbo.Actions", new[] { "ActionType_ID" });
            DropColumn("dbo.Actions", "Posts_id");
            DropColumn("dbo.Actions", "ActionType_ID");
            DropTable("dbo.ActionTypes");
        }
    }
}
