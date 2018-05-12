namespace Pricelist_Portal_Khantil_Anton_43650.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ColumnsDataLengthChanged : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.TVs", "EnergyClass", c => c.String(maxLength: 50));
            AlterColumn("dbo.TVs", "ScreenDiagonal", c => c.String(maxLength: 50));
            AlterColumn("dbo.TVs", "SmartTV", c => c.String(maxLength: 50));
            AlterColumn("dbo.TVs", "WiFi", c => c.String(maxLength: 50));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.TVs", "WiFi", c => c.String(maxLength: 10));
            AlterColumn("dbo.TVs", "SmartTV", c => c.String(maxLength: 10));
            AlterColumn("dbo.TVs", "ScreenDiagonal", c => c.String(maxLength: 10));
            AlterColumn("dbo.TVs", "EnergyClass", c => c.String(maxLength: 5));
        }
    }
}
