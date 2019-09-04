namespace mbensaeed.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Actions", "Person_Id", c => c.Int());
            CreateIndex("dbo.Actions", "Person_Id");
            AddForeignKey("dbo.Actions", "Person_Id", "dbo.People", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Actions", "Person_Id", "dbo.People");
            DropIndex("dbo.Actions", new[] { "Person_Id" });
            DropColumn("dbo.Actions", "Person_Id");
        }
    }
}
