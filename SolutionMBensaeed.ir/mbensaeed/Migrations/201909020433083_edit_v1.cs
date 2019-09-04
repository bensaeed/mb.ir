namespace mbensaeed.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class edit_v1 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Actions", "ID_Post");
            DropColumn("dbo.Actions", "ID_ActionType");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Actions", "ID_ActionType", c => c.Int(nullable: false));
            AddColumn("dbo.Actions", "ID_Post", c => c.String());
        }
    }
}
