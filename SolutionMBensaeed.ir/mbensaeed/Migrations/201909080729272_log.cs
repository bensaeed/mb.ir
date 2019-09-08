namespace mbensaeed.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class log : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.WebsiteVisits",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        DateShamsi = c.String(),
                        DateMiladi = c.String(),
                        VisitTime = c.String(),
                        IP_Address = c.String(),
                        Browser = c.String(),
                        DeviceInfo = c.String(),
                        HostName = c.String(),
                        Country = c.String(),
                        countryCode = c.String(),
                        org = c.String(),
                        region = c.String(),
                        regionName = c.String(),
                        city = c.String(),
                        Status = c.String(),
                        timezone = c.String(),
                        mobile = c.String(),
                        proxy = c.String(),
                        isp = c.String(),
                        lon = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.WebsiteVisits");
        }
    }
}
