namespace Pricelist_Portal_Khantil_Anton_43650.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TestMigration4 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Orders", "headphones_ID", "dbo.Headphones");
            DropForeignKey("dbo.Orders", "tVs_TV_ID", "dbo.TVs");
            DropIndex("dbo.Orders", new[] { "headphones_ID" });
            DropIndex("dbo.Orders", new[] { "tVs_TV_ID" });
            AddColumn("dbo.Orders", "HeadphoneEntryNo", c => c.Long());
            AddColumn("dbo.Orders", "TVEntryNo", c => c.Long());
            DropColumn("dbo.Orders", "headphones_ID");
            DropColumn("dbo.Orders", "tVs_TV_ID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Orders", "tVs_TV_ID", c => c.Int());
            AddColumn("dbo.Orders", "headphones_ID", c => c.Int());
            DropColumn("dbo.Orders", "TVEntryNo");
            DropColumn("dbo.Orders", "HeadphoneEntryNo");
            CreateIndex("dbo.Orders", "tVs_TV_ID");
            CreateIndex("dbo.Orders", "headphones_ID");
            AddForeignKey("dbo.Orders", "tVs_TV_ID", "dbo.TVs", "TV_ID");
            AddForeignKey("dbo.Orders", "headphones_ID", "dbo.Headphones", "ID");
        }
    }
}
