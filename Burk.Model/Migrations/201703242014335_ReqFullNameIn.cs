namespace Burk.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ReqFullNameIn : DbMigration
    {
        public override void Up()
        {
            AlterColumn("udb.DossierAttribute", "FullName", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("udb.DossierAttribute", "FullName", c => c.String());
        }
    }
}
