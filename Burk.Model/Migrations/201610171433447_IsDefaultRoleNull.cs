namespace Burk.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IsDefaultRoleNull : DbMigration
    {
        public override void Up()
        {
            AlterColumn("user.Roles", "IsDefault", c => c.Boolean());
        }
        
        public override void Down()
        {
            AlterColumn("user.Roles", "IsDefault", c => c.Boolean(nullable: false));
        }
    }
}
