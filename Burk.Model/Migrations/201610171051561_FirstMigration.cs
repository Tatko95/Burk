namespace Burk.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FirstMigration : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("user.Roles", "SystemId", "udb.System");
            DropIndex("user.Roles", new[] { "SystemId" });
            AddColumn("udb.Dictionary", "IsSystem", c => c.Boolean(nullable: false));
            AddColumn("udb.DossierObject", "IsDefault", c => c.Boolean(nullable: false));
            DropColumn("user.Roles", "SystemId");
        }
        
        public override void Down()
        {
            AddColumn("user.Roles", "SystemId", c => c.Int(nullable: false));
            DropColumn("udb.DossierObject", "IsDefault");
            DropColumn("udb.Dictionary", "IsSystem");
            CreateIndex("user.Roles", "SystemId");
            AddForeignKey("user.Roles", "SystemId", "udb.System", "SystemId", cascadeDelete: true);
        }
    }
}
