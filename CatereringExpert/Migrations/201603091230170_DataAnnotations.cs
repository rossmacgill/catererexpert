namespace CatereringExpert.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DataAnnotations : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Caterers", "CompanyName", c => c.String(nullable: false, maxLength: 60));
            AlterColumn("dbo.Caterers", "PhoneNumber", c => c.String(nullable: false));
            AlterColumn("dbo.Caterers", "EventType", c => c.String(nullable: false));
            AlterColumn("dbo.Caterers", "Foodtype", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Caterers", "Foodtype", c => c.String());
            AlterColumn("dbo.Caterers", "EventType", c => c.String());
            AlterColumn("dbo.Caterers", "PhoneNumber", c => c.String());
            AlterColumn("dbo.Caterers", "CompanyName", c => c.String());
        }
    }
}
