namespace Burk.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddIndexInUDB : DbMigration
    {
        public override void Up()
        {
            AddColumn("udb.DossierAttribute", "Index", c => c.Int(nullable: false));
            AddColumn("udb.DossierGrid", "Index", c => c.Int(nullable: false));
            AddColumn("udb.DossiertInset", "Index", c => c.Int(nullable: false));
            AddColumn("udb.DossierObject", "Index", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("udb.DossierObject", "Index");
            DropColumn("udb.DossiertInset", "Index");
            DropColumn("udb.DossierGrid", "Index");
            DropColumn("udb.DossierAttribute", "Index");
        }
    }
}
