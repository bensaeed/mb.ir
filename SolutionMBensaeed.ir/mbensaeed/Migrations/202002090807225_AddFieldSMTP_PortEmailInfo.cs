namespace mbensaeed.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddFieldSMTP_PortEmailInfo : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.EmailInfoes", "SMTP_Port", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.EmailInfoes", "SMTP_Port");
        }
    }
}
