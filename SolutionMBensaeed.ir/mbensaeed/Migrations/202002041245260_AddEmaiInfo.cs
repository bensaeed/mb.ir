namespace mbensaeed.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddEmaiInfo : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.EmailInfoes",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Email = c.String(nullable: false, maxLength: 300),
                        Pass = c.String(nullable: false, maxLength: 300),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.EmailInfoes");
        }
    }
}
