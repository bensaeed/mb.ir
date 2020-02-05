namespace mbensaeed.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EditEmaiInfo : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.EmailInfoes", "FromEmail", c => c.String(nullable: false, maxLength: 100));
            AddColumn("dbo.EmailInfoes", "ToEmail", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.EmailInfoes", "Pass", c => c.String(nullable: false, maxLength: 100));
            DropColumn("dbo.EmailInfoes", "Email");
        }
        
        public override void Down()
        {
            AddColumn("dbo.EmailInfoes", "Email", c => c.String(nullable: false, maxLength: 300));
            AlterColumn("dbo.EmailInfoes", "Pass", c => c.String(nullable: false, maxLength: 300));
            DropColumn("dbo.EmailInfoes", "ToEmail");
            DropColumn("dbo.EmailInfoes", "FromEmail");
        }
    }
}
