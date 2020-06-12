namespace Fenergo.Ui.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dataAnnotations : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Hardwares", "Description", c => c.String(nullable: false));
            AlterColumn("dbo.Photos", "FileName", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Photos", "FileName", c => c.String());
            AlterColumn("dbo.Hardwares", "Description", c => c.String());
        }
    }
}
