namespace Pricelist_Portal_Khantil_Anton_43650.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TestMigration3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Orders", "headphones_ID", c => c.Int());
            AddColumn("dbo.Orders", "tVs_TV_ID", c => c.Int());
            CreateIndex("dbo.Orders", "headphones_ID");
            CreateIndex("dbo.Orders", "tVs_TV_ID");
            AddForeignKey("dbo.Orders", "headphones_ID", "dbo.Headphones", "ID");
            AddForeignKey("dbo.Orders", "tVs_TV_ID", "dbo.TVs", "TV_ID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Orders", "tVs_TV_ID", "dbo.TVs");
            DropForeignKey("dbo.Orders", "headphones_ID", "dbo.Headphones");
            DropIndex("dbo.Orders", new[] { "tVs_TV_ID" });
            DropIndex("dbo.Orders", new[] { "headphones_ID" });
            DropColumn("dbo.Orders", "tVs_TV_ID");
            DropColumn("dbo.Orders", "headphones_ID");
        }
    }
}
