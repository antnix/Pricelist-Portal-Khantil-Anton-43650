namespace Pricelist_Portal_Khantil_Anton_43650.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TestMigration : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Headphones", "Order_OrderEntryNo", "dbo.Orders");
            DropForeignKey("dbo.TVs", "Order_OrderEntryNo", "dbo.Orders");
            DropIndex("dbo.Headphones", new[] { "Order_OrderEntryNo" });
            DropIndex("dbo.TVs", new[] { "Order_OrderEntryNo" });
            DropColumn("dbo.Headphones", "Order_OrderEntryNo");
            DropColumn("dbo.TVs", "Order_OrderEntryNo");
        }
        
        public override void Down()
        {
            AddColumn("dbo.TVs", "Order_OrderEntryNo", c => c.Long());
            AddColumn("dbo.Headphones", "Order_OrderEntryNo", c => c.Long());
            CreateIndex("dbo.TVs", "Order_OrderEntryNo");
            CreateIndex("dbo.Headphones", "Order_OrderEntryNo");
            AddForeignKey("dbo.TVs", "Order_OrderEntryNo", "dbo.Orders", "OrderEntryNo");
            AddForeignKey("dbo.Headphones", "Order_OrderEntryNo", "dbo.Orders", "OrderEntryNo");
        }
    }
}
