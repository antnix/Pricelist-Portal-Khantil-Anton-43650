namespace Pricelist_Portal_Khantil_Anton_43650.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TestMigration2 : DbMigration
    {
        public override void Up()
        {
            RenameColumn("dbo.Orders", "OrderEntryNo", "EntryNo");
        }
        
        public override void Down()
        {
            RenameColumn("dbo.Orders", "EntryNo", "OrderEntryNo");
        }
    }
}
