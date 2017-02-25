namespace Burk.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RequiredFullNameInDictionaryVaklue : DbMigration
    {
        public override void Up()
        {
            AlterColumn("udb.DictionaryValue", "FullName", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("udb.DictionaryValue", "FullName", c => c.String());
        }
    }
}
