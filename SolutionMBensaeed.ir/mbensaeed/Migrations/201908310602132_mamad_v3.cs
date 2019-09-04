namespace mbensaeed.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mamad_v3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.People", "Name", c => c.String(nullable: false, maxLength: 100));
        }
        
        public override void Down()
        {
            DropColumn("dbo.People", "Name");
        }
    }
}
