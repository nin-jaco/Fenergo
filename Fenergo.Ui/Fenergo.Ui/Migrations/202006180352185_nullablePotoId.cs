namespace Fenergo.Ui.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class nullablePotoId : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Hardwares", "IdPhoto", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Hardwares", "IdPhoto", c => c.Int(nullable: false));
        }
    }
}
