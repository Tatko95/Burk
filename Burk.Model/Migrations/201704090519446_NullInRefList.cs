namespace Burk.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NullInRefList : DbMigration
    {
        public override void Up()
        {
            DropIndex("udb.DossierList", new[] { "DosListRefId" });
            AlterColumn("udb.DossierList", "DosListRefId", c => c.Int());
            CreateIndex("udb.DossierList", "DosListRefId");
        }
        
        public override void Down()
        {
            DropIndex("udb.DossierList", new[] { "DosListRefId" });
            AlterColumn("udb.DossierList", "DosListRefId", c => c.Int(nullable: false));
            CreateIndex("udb.DossierList", "DosListRefId");
        }
    }
}
