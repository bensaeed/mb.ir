namespace mbensaeed.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mamad_v2 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.People", "Name");
        }
        
        public override void Down()
        {
            AddColumn("dbo.People", "Name", c => c.String());
        }
    }
}
