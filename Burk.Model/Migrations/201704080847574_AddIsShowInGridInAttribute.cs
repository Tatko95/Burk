namespace Burk.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddIsShowInGridInAttribute : DbMigration
    {
        public override void Up()
        {
            AddColumn("udb.DossierAttribute", "IsShowInGrid", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("udb.DossierAttribute", "IsShowInGrid");
        }
    }
}
