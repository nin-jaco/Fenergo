namespace Fenergo.Ui.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class basicTables : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Hardwares",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IdHardwareType = c.Byte(nullable: false),
                        Description = c.String(),
                        SerialNumber = c.String(),
                        IdPhoto = c.Int(nullable: false),
                        PurchasePrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        HardwareType_Id = c.Byte(),
                        Photo_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.HardwareTypes", t => t.HardwareType_Id)
                .ForeignKey("dbo.Photos", t => t.Photo_Id)
                .Index(t => t.HardwareType_Id)
                .Index(t => t.Photo_Id);
            
            CreateTable(
                "dbo.HardwareTypes",
                c => new
                    {
                        Id = c.Byte(nullable: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Photos",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FileName = c.String(),
                        FileSize = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Hardwares", "Photo_Id", "dbo.Photos");
            DropForeignKey("dbo.Hardwares", "HardwareType_Id", "dbo.HardwareTypes");
            DropIndex("dbo.Hardwares", new[] { "Photo_Id" });
            DropIndex("dbo.Hardwares", new[] { "HardwareType_Id" });
            DropTable("dbo.Photos");
            DropTable("dbo.HardwareTypes");
            DropTable("dbo.Hardwares");
        }
    }
}
