namespace Burk.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ReqInTableForCascadeDelete : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("udb.Dictionary", "SystemId", "udb.System");
            DropIndex("udb.Dictionary", new[] { "SystemId" });
            AlterColumn("udb.Dictionary", "SystemId", c => c.Int(nullable: false));
            CreateIndex("udb.Dictionary", "SystemId");
            AddForeignKey("udb.Dictionary", "SystemId", "udb.System", "SystemId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("udb.Dictionary", "SystemId", "udb.System");
            DropIndex("udb.Dictionary", new[] { "SystemId" });
            AlterColumn("udb.Dictionary", "SystemId", c => c.Int());
            CreateIndex("udb.Dictionary", "SystemId");
            AddForeignKey("udb.Dictionary", "SystemId", "udb.System", "SystemId");
        }
    }
}
