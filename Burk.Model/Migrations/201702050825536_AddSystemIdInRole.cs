namespace Burk.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddSystemIdInRole : DbMigration
    {
        public override void Up()
        {
            AddColumn("user.Roles", "SystemId", c => c.Int());
            CreateIndex("user.Roles", "SystemId");
            AddForeignKey("user.Roles", "SystemId", "udb.System", "SystemId");
        }
        
        public override void Down()
        {
            DropForeignKey("user.Roles", "SystemId", "udb.System");
            DropIndex("user.Roles", new[] { "SystemId" });
            DropColumn("user.Roles", "SystemId");
        }
    }
}
