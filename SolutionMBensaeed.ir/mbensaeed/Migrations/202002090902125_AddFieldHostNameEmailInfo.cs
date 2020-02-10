namespace mbensaeed.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddFieldHostNameEmailInfo : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.EmailInfoes", "HostName", c => c.String(nullable: false, maxLength: 100));
        }
        
        public override void Down()
        {
            DropColumn("dbo.EmailInfoes", "HostName");
        }
    }
}
