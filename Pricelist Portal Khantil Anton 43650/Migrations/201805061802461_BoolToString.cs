namespace Pricelist_Portal_Khantil_Anton_43650.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BoolToString : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.TVs");
            DropTable("dbo.Headphones");
            CreateTable(
                "dbo.Headphones",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Brand = c.String(nullable: false, maxLength: 60),
                        ProductCode = c.String(maxLength: 60),
                        Price = c.Decimal(nullable: false, precision: 10, scale: 2),
                        Amount = c.Int(nullable: false),
                        MaxWorkingTime = c.String(maxLength: 10),
                        TransmissionType = c.String(maxLength: 20),
                        HaveMicrophone = c.String(maxLength: 10),
                        Range = c.String(maxLength: 10),
                        Details = c.String(maxLength: 1024),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.TVs",
                c => new
                    {
                        TV_ID = c.Int(nullable: false, identity: true),
                        Brand = c.String(nullable: false, maxLength: 60),
                        ProductCode = c.String(maxLength: 60),
                        Price = c.Decimal(nullable: false, precision: 10, scale: 2),
                        Amount = c.Int(nullable: false),
                        EnergyClass = c.String(maxLength: 5),
                        ScreenDiagonal = c.String(maxLength: 10),
                        SmartTV = c.String(maxLength: 10),
                        WiFi = c.String(maxLength: 10),
                        Details = c.String(maxLength: 1024),
                    })
                .PrimaryKey(t => t.TV_ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.TVs");
            DropTable("dbo.Headphones");
        }
    }
}
