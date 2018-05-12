namespace Pricelist_Portal_Khantil_Anton_43650.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class HeadphoneClumnLengthChanged : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Headphones", "MaxWorkingTime", c => c.String(maxLength: 50));
            AlterColumn("dbo.Headphones", "TransmissionType", c => c.String(maxLength: 50));
            AlterColumn("dbo.Headphones", "HaveMicrophone", c => c.String(maxLength: 50));
            AlterColumn("dbo.Headphones", "Range", c => c.String(maxLength: 50));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Headphones", "Range", c => c.String(maxLength: 10));
            AlterColumn("dbo.Headphones", "HaveMicrophone", c => c.String(maxLength: 10));
            AlterColumn("dbo.Headphones", "TransmissionType", c => c.String(maxLength: 20));
            AlterColumn("dbo.Headphones", "MaxWorkingTime", c => c.String(maxLength: 10));
        }
    }
}
