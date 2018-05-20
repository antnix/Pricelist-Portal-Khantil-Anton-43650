namespace Pricelist_Portal_Khantil_Anton_43650.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RequiredErrorMessage : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.TVs", "ProductCode", c => c.String(nullable: false, maxLength: 60));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.TVs", "ProductCode", c => c.String(maxLength: 60));
        }
    }
}
