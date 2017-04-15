namespace Burk.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EditNameFieldInDossierValue : DbMigration
    {
        public override void Up()
        {
            AddColumn("udb.DossierValue", "Text2", c => c.String());
            AddColumn("udb.DossierValue", "Text6", c => c.String());
            AddColumn("udb.DossierValue", "Text10", c => c.String());
            AddColumn("udb.DossierValue", "Text14", c => c.String());
            AddColumn("udb.DossierValue", "Text18", c => c.String());
            DropColumn("udb.DossierValue", "Test2");
            DropColumn("udb.DossierValue", "Test6");
            DropColumn("udb.DossierValue", "Test10");
            DropColumn("udb.DossierValue", "Test14");
            DropColumn("udb.DossierValue", "Test18");
        }
        
        public override void Down()
        {
            AddColumn("udb.DossierValue", "Test18", c => c.String());
            AddColumn("udb.DossierValue", "Test14", c => c.String());
            AddColumn("udb.DossierValue", "Test10", c => c.String());
            AddColumn("udb.DossierValue", "Test6", c => c.String());
            AddColumn("udb.DossierValue", "Test2", c => c.String());
            DropColumn("udb.DossierValue", "Text18");
            DropColumn("udb.DossierValue", "Text14");
            DropColumn("udb.DossierValue", "Text10");
            DropColumn("udb.DossierValue", "Text6");
            DropColumn("udb.DossierValue", "Text2");
        }
    }
}
