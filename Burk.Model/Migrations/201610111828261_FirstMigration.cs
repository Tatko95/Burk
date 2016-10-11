namespace Burk.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FirstMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "udb.DictionaryAttribute",
                c => new
                    {
                        DicAttributeId = c.Int(nullable: false, identity: true),
                        DictionaryId = c.Int(),
                        FullName = c.String(nullable: false),
                        ShortName = c.String(),
                        UID = c.Int(nullable: false),
                        DicAttributeLevelRefId = c.Int(nullable: false),
                        LanguageId = c.Int(),
                    })
                .PrimaryKey(t => t.DicAttributeId)
                .ForeignKey("udb.DictionaryAttribute", t => t.DicAttributeLevelRefId)
                .ForeignKey("udb.Dictionary", t => t.DictionaryId)
                .ForeignKey("udb.Language", t => t.LanguageId)
                .Index(t => t.DictionaryId)
                .Index(t => t.DicAttributeLevelRefId)
                .Index(t => t.LanguageId);
            
            CreateTable(
                "udb.Dictionary",
                c => new
                    {
                        DictionaryId = c.Int(nullable: false, identity: true),
                        FullName = c.String(nullable: false),
                        ShortName = c.String(),
                        UID = c.Int(nullable: false),
                        SystemId = c.Int(),
                        LanguageId = c.Int(),
                    })
                .PrimaryKey(t => t.DictionaryId)
                .ForeignKey("udb.Language", t => t.LanguageId)
                .ForeignKey("udb.System", t => t.SystemId)
                .Index(t => t.SystemId)
                .Index(t => t.LanguageId);
            
            CreateTable(
                "udb.Language",
                c => new
                    {
                        LanguageId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.LanguageId);
            
            CreateTable(
                "udb.System",
                c => new
                    {
                        SystemId = c.Int(nullable: false, identity: true),
                        FullName = c.String(nullable: false),
                        ShortName = c.String(),
                        LanguageId = c.Int(),
                        UID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.SystemId)
                .ForeignKey("udb.Language", t => t.LanguageId)
                .Index(t => t.LanguageId);
            
            CreateTable(
                "udb.DictionaryValue",
                c => new
                    {
                        DicValueId = c.Int(nullable: false, identity: true),
                        DicAttributeId = c.Int(),
                        FullName = c.String(),
                        ShortName = c.String(),
                        StartDate = c.DateTime(),
                        EndDate = c.DateTime(),
                        UID = c.Int(nullable: false),
                        LanguageId = c.Int(),
                    })
                .PrimaryKey(t => t.DicValueId)
                .ForeignKey("udb.DictionaryAttribute", t => t.DicAttributeId)
                .ForeignKey("udb.Language", t => t.LanguageId)
                .Index(t => t.DicAttributeId)
                .Index(t => t.LanguageId);
            
            CreateTable(
                "udb.DossierAttribute",
                c => new
                    {
                        DosAttributeId = c.Int(nullable: false, identity: true),
                        DosInsetId = c.Int(),
                        DictionaryId = c.Int(),
                        FullName = c.String(),
                        ShortName = c.String(),
                        ValueName = c.String(),
                        UID = c.Int(nullable: false),
                        GridId = c.Int(),
                        LanguageId = c.Int(),
                    })
                .PrimaryKey(t => t.DosAttributeId)
                .ForeignKey("udb.Dictionary", t => t.DictionaryId)
                .ForeignKey("udb.DossierGrid", t => t.GridId)
                .ForeignKey("udb.DossiertInset", t => t.DosInsetId)
                .ForeignKey("udb.Language", t => t.LanguageId)
                .Index(t => t.DosInsetId)
                .Index(t => t.DictionaryId)
                .Index(t => t.GridId)
                .Index(t => t.LanguageId);
            
            CreateTable(
                "udb.DossierGrid",
                c => new
                    {
                        DosGridId = c.Int(nullable: false, identity: true),
                        DictionaryId = c.Int(),
                        FullName = c.String(nullable: false),
                        ShortName = c.String(),
                        GridName = c.String(),
                        UID = c.Int(nullable: false),
                        LanguageId = c.Int(),
                    })
                .PrimaryKey(t => t.DosGridId)
                .ForeignKey("udb.Dictionary", t => t.DictionaryId)
                .ForeignKey("udb.Language", t => t.LanguageId)
                .Index(t => t.DictionaryId)
                .Index(t => t.LanguageId);
            
            CreateTable(
                "udb.DossiertInset",
                c => new
                    {
                        DosInsetId = c.Int(nullable: false, identity: true),
                        DosObjectId = c.Int(),
                        FullName = c.String(),
                        ShortName = c.String(),
                        UID = c.Int(nullable: false),
                        LanguageId = c.Int(),
                    })
                .PrimaryKey(t => t.DosInsetId)
                .ForeignKey("udb.Language", t => t.LanguageId)
                .ForeignKey("udb.DossierObject", t => t.DosObjectId)
                .Index(t => t.DosObjectId)
                .Index(t => t.LanguageId);
            
            CreateTable(
                "udb.DossierObject",
                c => new
                    {
                        DosObjectId = c.Int(nullable: false, identity: true),
                        FullName = c.String(),
                        ShortName = c.String(),
                        SystemId = c.Int(),
                        UID = c.Int(nullable: false),
                        LanguageId = c.Int(),
                    })
                .PrimaryKey(t => t.DosObjectId)
                .ForeignKey("udb.Language", t => t.LanguageId)
                .ForeignKey("udb.System", t => t.SystemId)
                .Index(t => t.SystemId)
                .Index(t => t.LanguageId);
            
            CreateTable(
                "udb.DossierLink",
                c => new
                    {
                        DosLinkId = c.Int(nullable: false, identity: true),
                        DosList1Id = c.Int(),
                        DosList2Id = c.Int(),
                    })
                .PrimaryKey(t => t.DosLinkId)
                .ForeignKey("udb.DossierList", t => t.DosList1Id)
                .ForeignKey("udb.DossierList", t => t.DosList2Id)
                .Index(t => t.DosList1Id)
                .Index(t => t.DosList2Id);
            
            CreateTable(
                "udb.DossierList",
                c => new
                    {
                        DosListId = c.Int(nullable: false, identity: true),
                        DosObjectId = c.Int(),
                        DosInsetId = c.Int(),
                        DosListRefId = c.Int(nullable: false),
                        CreateDate = c.DateTime(),
                        CreateUser = c.String(),
                        DeleteDate = c.DateTime(),
                        DeleteUser = c.String(),
                    })
                .PrimaryKey(t => t.DosListId)
                .ForeignKey("udb.DossierList", t => t.DosListRefId)
                .ForeignKey("udb.DossiertInset", t => t.DosInsetId)
                .ForeignKey("udb.DossierObject", t => t.DosObjectId)
                .Index(t => t.DosObjectId)
                .Index(t => t.DosInsetId)
                .Index(t => t.DosListRefId);
            
            CreateTable(
                "udb.DossierValue",
                c => new
                    {
                        DosValueId = c.Int(nullable: false, identity: true),
                        DosListId = c.Int(),
                        UserEdit = c.String(),
                        EditDate = c.DateTime(),
                        Text1 = c.String(),
                        Test2 = c.String(),
                        Text3 = c.String(),
                        Text4 = c.String(),
                        Text5 = c.String(),
                        Test6 = c.String(),
                        Text7 = c.String(),
                        Text8 = c.String(),
                        Text9 = c.String(),
                        Test10 = c.String(),
                        Text11 = c.String(),
                        Text12 = c.String(),
                        Text13 = c.String(),
                        Test14 = c.String(),
                        Text15 = c.String(),
                        Text16 = c.String(),
                        Text17 = c.String(),
                        Test18 = c.String(),
                        Text19 = c.String(),
                        Text20 = c.String(),
                        Date1 = c.DateTime(),
                        Date2 = c.DateTime(),
                        Date3 = c.DateTime(),
                        Date4 = c.DateTime(),
                        Date5 = c.DateTime(),
                        Date6 = c.DateTime(),
                        Date7 = c.DateTime(),
                        Date8 = c.DateTime(),
                        Date9 = c.DateTime(),
                        Date10 = c.DateTime(),
                        Number1 = c.Int(nullable: false),
                        Number2 = c.Int(nullable: false),
                        Number3 = c.Int(nullable: false),
                        Number4 = c.Int(nullable: false),
                        Number5 = c.Int(nullable: false),
                        Number6 = c.Int(nullable: false),
                        Number7 = c.Int(nullable: false),
                        Number8 = c.Int(nullable: false),
                        Number9 = c.Int(nullable: false),
                        Number10 = c.Int(nullable: false),
                        Number11 = c.Int(nullable: false),
                        Number12 = c.Int(nullable: false),
                        Number13 = c.Int(nullable: false),
                        Number14 = c.Int(nullable: false),
                        Number15 = c.Int(nullable: false),
                        Number16 = c.Int(nullable: false),
                        Number17 = c.Int(nullable: false),
                        Number18 = c.Int(nullable: false),
                        Number19 = c.Int(nullable: false),
                        Number20 = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.DosValueId)
                .ForeignKey("udb.DossierList", t => t.DosListId)
                .Index(t => t.DosListId);
            
            CreateTable(
                "udb.GridValue",
                c => new
                    {
                        GridId = c.Int(nullable: false, identity: true),
                        DosValueId = c.Int(),
                        AttributeId = c.Int(),
                        Text1 = c.String(),
                        Test2 = c.String(),
                        Text3 = c.String(),
                        Text4 = c.String(),
                        Text5 = c.String(),
                        Test6 = c.String(),
                        Text7 = c.String(),
                        Text8 = c.String(),
                        Text9 = c.String(),
                        Test10 = c.String(),
                        Text11 = c.String(),
                        Text12 = c.String(),
                        Text13 = c.String(),
                        Test14 = c.String(),
                        Text15 = c.String(),
                        Text16 = c.String(),
                        Text17 = c.String(),
                        Test18 = c.String(),
                        Text19 = c.String(),
                        Text20 = c.String(),
                        Date1 = c.DateTime(),
                        Date2 = c.DateTime(),
                        Date3 = c.DateTime(),
                        Date4 = c.DateTime(),
                        Date5 = c.DateTime(),
                        Date6 = c.DateTime(),
                        Date7 = c.DateTime(),
                        Date8 = c.DateTime(),
                        Date9 = c.DateTime(),
                        Date10 = c.DateTime(),
                        Number1 = c.Int(nullable: false),
                        Number2 = c.Int(nullable: false),
                        Number3 = c.Int(nullable: false),
                        Number4 = c.Int(nullable: false),
                        Number5 = c.Int(nullable: false),
                        Number6 = c.Int(nullable: false),
                        Number7 = c.Int(nullable: false),
                        Number8 = c.Int(nullable: false),
                        Number9 = c.Int(nullable: false),
                        Number10 = c.Int(nullable: false),
                        Number11 = c.Int(nullable: false),
                        Number12 = c.Int(nullable: false),
                        Number13 = c.Int(nullable: false),
                        Number14 = c.Int(nullable: false),
                        Number15 = c.Int(nullable: false),
                        Number16 = c.Int(nullable: false),
                        Number17 = c.Int(nullable: false),
                        Number18 = c.Int(nullable: false),
                        Number19 = c.Int(nullable: false),
                        Number20 = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.GridId)
                .ForeignKey("udb.DossierAttribute", t => t.AttributeId)
                .ForeignKey("udb.DossierValue", t => t.DosValueId)
                .Index(t => t.DosValueId)
                .Index(t => t.AttributeId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("udb.GridValue", "DosValueId", "udb.DossierValue");
            DropForeignKey("udb.GridValue", "AttributeId", "udb.DossierAttribute");
            DropForeignKey("udb.DossierValue", "DosListId", "udb.DossierList");
            DropForeignKey("udb.DossierLink", "DosList2Id", "udb.DossierList");
            DropForeignKey("udb.DossierLink", "DosList1Id", "udb.DossierList");
            DropForeignKey("udb.DossierList", "DosObjectId", "udb.DossierObject");
            DropForeignKey("udb.DossierList", "DosInsetId", "udb.DossiertInset");
            DropForeignKey("udb.DossierList", "DosListRefId", "udb.DossierList");
            DropForeignKey("udb.DossierAttribute", "LanguageId", "udb.Language");
            DropForeignKey("udb.DossierAttribute", "DosInsetId", "udb.DossiertInset");
            DropForeignKey("udb.DossiertInset", "DosObjectId", "udb.DossierObject");
            DropForeignKey("udb.DossierObject", "SystemId", "udb.System");
            DropForeignKey("udb.DossierObject", "LanguageId", "udb.Language");
            DropForeignKey("udb.DossiertInset", "LanguageId", "udb.Language");
            DropForeignKey("udb.DossierAttribute", "GridId", "udb.DossierGrid");
            DropForeignKey("udb.DossierGrid", "LanguageId", "udb.Language");
            DropForeignKey("udb.DossierGrid", "DictionaryId", "udb.Dictionary");
            DropForeignKey("udb.DossierAttribute", "DictionaryId", "udb.Dictionary");
            DropForeignKey("udb.DictionaryValue", "LanguageId", "udb.Language");
            DropForeignKey("udb.DictionaryValue", "DicAttributeId", "udb.DictionaryAttribute");
            DropForeignKey("udb.DictionaryAttribute", "LanguageId", "udb.Language");
            DropForeignKey("udb.DictionaryAttribute", "DictionaryId", "udb.Dictionary");
            DropForeignKey("udb.Dictionary", "SystemId", "udb.System");
            DropForeignKey("udb.System", "LanguageId", "udb.Language");
            DropForeignKey("udb.Dictionary", "LanguageId", "udb.Language");
            DropForeignKey("udb.DictionaryAttribute", "DicAttributeLevelRefId", "udb.DictionaryAttribute");
            DropIndex("udb.GridValue", new[] { "AttributeId" });
            DropIndex("udb.GridValue", new[] { "DosValueId" });
            DropIndex("udb.DossierValue", new[] { "DosListId" });
            DropIndex("udb.DossierList", new[] { "DosListRefId" });
            DropIndex("udb.DossierList", new[] { "DosInsetId" });
            DropIndex("udb.DossierList", new[] { "DosObjectId" });
            DropIndex("udb.DossierLink", new[] { "DosList2Id" });
            DropIndex("udb.DossierLink", new[] { "DosList1Id" });
            DropIndex("udb.DossierObject", new[] { "LanguageId" });
            DropIndex("udb.DossierObject", new[] { "SystemId" });
            DropIndex("udb.DossiertInset", new[] { "LanguageId" });
            DropIndex("udb.DossiertInset", new[] { "DosObjectId" });
            DropIndex("udb.DossierGrid", new[] { "LanguageId" });
            DropIndex("udb.DossierGrid", new[] { "DictionaryId" });
            DropIndex("udb.DossierAttribute", new[] { "LanguageId" });
            DropIndex("udb.DossierAttribute", new[] { "GridId" });
            DropIndex("udb.DossierAttribute", new[] { "DictionaryId" });
            DropIndex("udb.DossierAttribute", new[] { "DosInsetId" });
            DropIndex("udb.DictionaryValue", new[] { "LanguageId" });
            DropIndex("udb.DictionaryValue", new[] { "DicAttributeId" });
            DropIndex("udb.System", new[] { "LanguageId" });
            DropIndex("udb.Dictionary", new[] { "LanguageId" });
            DropIndex("udb.Dictionary", new[] { "SystemId" });
            DropIndex("udb.DictionaryAttribute", new[] { "LanguageId" });
            DropIndex("udb.DictionaryAttribute", new[] { "DicAttributeLevelRefId" });
            DropIndex("udb.DictionaryAttribute", new[] { "DictionaryId" });
            DropTable("udb.GridValue");
            DropTable("udb.DossierValue");
            DropTable("udb.DossierList");
            DropTable("udb.DossierLink");
            DropTable("udb.DossierObject");
            DropTable("udb.DossiertInset");
            DropTable("udb.DossierGrid");
            DropTable("udb.DossierAttribute");
            DropTable("udb.DictionaryValue");
            DropTable("udb.System");
            DropTable("udb.Language");
            DropTable("udb.Dictionary");
            DropTable("udb.DictionaryAttribute");
        }
    }
}
