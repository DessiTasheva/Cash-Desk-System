namespace CashDeskApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Events : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.EventDbs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PeopleIn = c.Int(nullable: false),
                        PeopleOut = c.Int(nullable: false),
                        UTCTimestamp = c.DateTime(nullable: false),
                        CameraId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.EventDbs");
        }
    }
}
