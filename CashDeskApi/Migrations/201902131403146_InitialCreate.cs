namespace CashDeskApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CameraDbs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PeopleIn = c.Int(nullable: false),
                        PeopleOut = c.Int(nullable: false),
                        IsCashDeskOpen = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.CashDeskDbs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        State = c.Int(nullable: false),
                        CameraId = c.Int(nullable: false),
                        IsOpen = c.Boolean(nullable: false),
                        PeopleCount = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.CashDeskDbs");
            DropTable("dbo.CameraDbs");
        }
    }
}
