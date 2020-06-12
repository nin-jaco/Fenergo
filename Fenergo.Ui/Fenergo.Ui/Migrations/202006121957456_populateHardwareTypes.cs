namespace Fenergo.Ui.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class populateHardwareTypes : DbMigration
    {
        public override void Up()
        {
            Sql("insert into HardwareTypes (Id, Name) values (1,'Printer')");
            Sql("insert into HardwareTypes (Id, Name) values (2,'Screen')");
            Sql("insert into HardwareTypes (Id, Name) values (3,'Laptop')");
            Sql("insert into HardwareTypes (Id, Name) values (4,'Keyboard')");
            Sql("insert into HardwareTypes (Id, Name) values (5,'Mouse')");
        }
        
        public override void Down()
        {
        }
    }
}
