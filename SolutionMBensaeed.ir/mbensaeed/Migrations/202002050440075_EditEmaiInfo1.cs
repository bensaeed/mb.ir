namespace mbensaeed.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EditEmaiInfo1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.EmailInfoes", "IsActive", c => c.String(maxLength: 1));
        }
        
        public override void Down()
        {
            DropColumn("dbo.EmailInfoes", "IsActive");
        }
    }
}
