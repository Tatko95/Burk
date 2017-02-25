namespace Burk.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ForeignKeyDicValueToDic : DbMigration
    {
        public override void Up()
        {
            AddColumn("udb.DictionaryValue", "DictionaryId", c => c.Int(nullable: false));
            CreateIndex("udb.DictionaryValue", "DictionaryId");
            AddForeignKey("udb.DictionaryValue", "DictionaryId", "udb.Dictionary", "DictionaryId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("udb.DictionaryValue", "DictionaryId", "udb.Dictionary");
            DropIndex("udb.DictionaryValue", new[] { "DictionaryId" });
            DropColumn("udb.DictionaryValue", "DictionaryId");
        }
    }
}
