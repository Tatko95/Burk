namespace Burk.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IsReqInAttr : DbMigration
    {
        public override void Up()
        {
            AddColumn("udb.DossierAttribute", "IsReq", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("udb.DossierAttribute", "IsReq");
        }
    }
}
