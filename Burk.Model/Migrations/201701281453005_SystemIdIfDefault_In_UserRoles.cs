namespace Burk.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SystemIdIfDefault_In_UserRoles : DbMigration
    {
        public override void Up()
        {
            AddColumn("user.UserRoles", "SystemIdIfRoleDefault", c => c.Int());
            CreateIndex("user.UserRoles", "SystemIdIfRoleDefault");
            AddForeignKey("user.UserRoles", "SystemIdIfRoleDefault", "udb.System", "SystemId");
        }
        
        public override void Down()
        {
            DropForeignKey("user.UserRoles", "SystemIdIfRoleDefault", "udb.System");
            DropIndex("user.UserRoles", new[] { "SystemIdIfRoleDefault" });
            DropColumn("user.UserRoles", "SystemIdIfRoleDefault");
        }
    }
}
