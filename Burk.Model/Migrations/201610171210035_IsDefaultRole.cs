namespace Burk.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IsDefaultRole : DbMigration
    {
        public override void Up()
        {
            AddColumn("user.Roles", "IsDefault", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("user.Roles", "IsDefault");
        }
    }
}
