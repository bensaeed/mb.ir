namespace mbensaeed.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddNewFieldToPostComment : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PostComments", "Is_Read", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.PostComments", "Is_Read");
        }
    }
}
