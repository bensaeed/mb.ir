namespace mbensaeed.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModifyActivityEntity : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Activities", "Person_Id", "dbo.People");
            DropIndex("dbo.Activities", new[] { "Person_Id" });
            RenameColumn(table: "dbo.Activities", name: "ActivityType_ID", newName: "ActivityTypeId");
            RenameColumn(table: "dbo.Activities", name: "Posts_ID", newName: "PostId");
            RenameIndex(table: "dbo.Activities", name: "IX_Posts_ID", newName: "IX_PostId");
            RenameIndex(table: "dbo.Activities", name: "IX_ActivityType_ID", newName: "IX_ActivityTypeId");
            DropColumn("dbo.Activities", "Person_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Activities", "Person_Id", c => c.Int());
            RenameIndex(table: "dbo.Activities", name: "IX_ActivityTypeId", newName: "IX_ActivityType_ID");
            RenameIndex(table: "dbo.Activities", name: "IX_PostId", newName: "IX_Posts_ID");
            RenameColumn(table: "dbo.Activities", name: "PostId", newName: "Posts_ID");
            RenameColumn(table: "dbo.Activities", name: "ActivityTypeId", newName: "ActivityType_ID");
            CreateIndex("dbo.Activities", "Person_Id");
            AddForeignKey("dbo.Activities", "Person_Id", "dbo.People", "Id");
        }
    }
}
