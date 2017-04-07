namespace Burk.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddFieldInAttribute : DbMigration
    {
        public override void Up()
        {
            AddColumn("udb.DossierAttribute", "AttributeTypeName", c => c.String());
            AddColumn("udb.DossierAttribute", "AttributeTypeIndex", c => c.Int(nullable: false));
            AddColumn("udb.DossierAttribute", "X", c => c.Int(nullable: false));
            AddColumn("udb.DossierAttribute", "Y", c => c.Int(nullable: false));
            AddColumn("udb.DossierAttribute", "Width", c => c.Int(nullable: false));
            AddColumn("udb.DossierAttribute", "Height", c => c.Int(nullable: false));
            DropColumn("udb.DossierAttribute", "ValueName");
            DropColumn("udb.DossierAttribute", "Index");
        }
        
        public override void Down()
        {
            AddColumn("udb.DossierAttribute", "Index", c => c.Int(nullable: false));
            AddColumn("udb.DossierAttribute", "ValueName", c => c.String());
            DropColumn("udb.DossierAttribute", "Height");
            DropColumn("udb.DossierAttribute", "Width");
            DropColumn("udb.DossierAttribute", "Y");
            DropColumn("udb.DossierAttribute", "X");
            DropColumn("udb.DossierAttribute", "AttributeTypeIndex");
            DropColumn("udb.DossierAttribute", "AttributeTypeName");
        }
    }
}
