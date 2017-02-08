namespace Burk.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ReqSystemIdInDossier : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("udb.DossierObject", "SystemId", "udb.System");
            DropIndex("udb.DossierObject", new[] { "SystemId" });
            AlterColumn("udb.DossierObject", "SystemId", c => c.Int(nullable: false));
            CreateIndex("udb.DossierObject", "SystemId");
            AddForeignKey("udb.DossierObject", "SystemId", "udb.System", "SystemId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("udb.DossierObject", "SystemId", "udb.System");
            DropIndex("udb.DossierObject", new[] { "SystemId" });
            AlterColumn("udb.DossierObject", "SystemId", c => c.Int());
            CreateIndex("udb.DossierObject", "SystemId");
            AddForeignKey("udb.DossierObject", "SystemId", "udb.System", "SystemId");
        }
    }
}
