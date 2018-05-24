namespace Pricelist_Portal_Khantil_Anton_43650.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class OrderTableAdd : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        OrderEntryNo = c.Long(nullable: false, identity: true),
                        CustomerEmail = c.String(nullable: false, maxLength: 50),
                        CustomerPhoneNumber = c.String(nullable: false, maxLength: 10),
                        CustomerName = c.String(nullable: false, maxLength: 100),
                        CustomerAddress = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.OrderEntryNo);
            
            AddColumn("dbo.Headphones", "Order_OrderEntryNo", c => c.Long());
            AddColumn("dbo.TVs", "Order_OrderEntryNo", c => c.Long());
            CreateIndex("dbo.Headphones", "Order_OrderEntryNo");
            CreateIndex("dbo.TVs", "Order_OrderEntryNo");
            AddForeignKey("dbo.Headphones", "Order_OrderEntryNo", "dbo.Orders", "OrderEntryNo");
            AddForeignKey("dbo.TVs", "Order_OrderEntryNo", "dbo.Orders", "OrderEntryNo");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TVs", "Order_OrderEntryNo", "dbo.Orders");
            DropForeignKey("dbo.Headphones", "Order_OrderEntryNo", "dbo.Orders");
            DropIndex("dbo.TVs", new[] { "Order_OrderEntryNo" });
            DropIndex("dbo.Headphones", new[] { "Order_OrderEntryNo" });
            DropColumn("dbo.TVs", "Order_OrderEntryNo");
            DropColumn("dbo.Headphones", "Order_OrderEntryNo");
            DropTable("dbo.Orders");
        }
    }
}
