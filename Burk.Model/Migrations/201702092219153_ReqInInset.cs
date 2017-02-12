namespace Burk.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ReqInInset : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("udb.DossiertInset", "DosObjectId", "udb.DossierObject");
            DropIndex("udb.DossiertInset", new[] { "DosObjectId" });
            AlterColumn("udb.DossiertInset", "DosObjectId", c => c.Int(nullable: false));
            AlterColumn("udb.DossiertInset", "FullName", c => c.String(nullable: false));
            CreateIndex("udb.DossiertInset", "DosObjectId");
            AddForeignKey("udb.DossiertInset", "DosObjectId", "udb.DossierObject", "DosObjectId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("udb.DossiertInset", "DosObjectId", "udb.DossierObject");
            DropIndex("udb.DossiertInset", new[] { "DosObjectId" });
            AlterColumn("udb.DossiertInset", "FullName", c => c.String());
            AlterColumn("udb.DossiertInset", "DosObjectId", c => c.Int());
            CreateIndex("udb.DossiertInset", "DosObjectId");
            AddForeignKey("udb.DossiertInset", "DosObjectId", "udb.DossierObject", "DosObjectId");
        }
    }
}
