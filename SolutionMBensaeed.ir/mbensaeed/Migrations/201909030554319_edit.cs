namespace mbensaeed.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class edit : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Actions", newName: "Activities");
            RenameTable(name: "dbo.ActionTypes", newName: "ActivityTypes");
            RenameColumn(table: "dbo.Activities", name: "ActionType_ID", newName: "ActivityType_ID");
            RenameIndex(table: "dbo.Activities", name: "IX_ActionType_ID", newName: "IX_ActivityType_ID");
            CreateTable(
                "dbo.Images",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Url = c.String(),
                        TitleUrl = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Images");
            RenameIndex(table: "dbo.Activities", name: "IX_ActivityType_ID", newName: "IX_ActionType_ID");
            RenameColumn(table: "dbo.Activities", name: "ActivityType_ID", newName: "ActionType_ID");
            RenameTable(name: "dbo.ActivityTypes", newName: "ActionTypes");
            RenameTable(name: "dbo.Activities", newName: "Actions");
        }
    }
}
