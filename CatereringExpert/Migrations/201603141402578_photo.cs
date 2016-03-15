namespace CatereringExpert.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class photo : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Files", "Caterers_ID", "dbo.Caterers");
            DropIndex("dbo.Files", new[] { "Caterers_ID" });
            DropTable("dbo.Files");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Files",
                c => new
                    {
                        FileId = c.Int(nullable: false, identity: true),
                        FileName = c.String(maxLength: 255),
                        ContentType = c.String(maxLength: 100),
                        Content = c.Binary(),
                        FileType = c.Int(nullable: false),
                        PersonId = c.Int(nullable: false),
                        Caterers_ID = c.Int(),
                    })
                .PrimaryKey(t => t.FileId);
            
            CreateIndex("dbo.Files", "Caterers_ID");
            AddForeignKey("dbo.Files", "Caterers_ID", "dbo.Caterers", "ID");
        }
    }
}
