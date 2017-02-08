namespace Burk.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ReqInDossier : DbMigration
    {
        public override void Up()
        {
            AlterColumn("udb.DossierObject", "FullName", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("udb.DossierObject", "FullName", c => c.String());
        }
    }
}
