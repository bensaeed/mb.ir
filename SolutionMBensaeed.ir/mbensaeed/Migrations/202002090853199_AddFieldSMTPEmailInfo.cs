namespace mbensaeed.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddFieldSMTPEmailInfo : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.EmailInfoes", "SMTP", c => c.String(nullable: false, maxLength: 100));
        }
        
        public override void Down()
        {
            DropColumn("dbo.EmailInfoes", "SMTP");
        }
    }
}
