namespace mbensaeed.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Modify_TblComment : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Comments",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        FullName = c.String(),
                        PhoneNumber = c.String(),
                        Email = c.String(),
                        CommentUser = c.String(),
                        SendDate = c.String(),
                        SendTime = c.String(),
                        Is_Read = c.String(),
                        ReadTime = c.String(),
                        ReadDateMiladi = c.String(),
                        ReadDateShamsi = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Comments");
        }
    }
}
