using Burk.Model.UDB;
using System.Data.Entity;

namespace Burk.Model.Context
{
    public class ModelContext : DbContext
    {
        public ModelContext() : base("connectionStringModel")
        {
        }

        public DbSet<Dictionary> Dictionaries { get; set; }
        public DbSet<DictionaryAttribute> DicAttributes { get; set; }
        public DbSet<DictionaryValue> DicValues { get; set; }
        public DbSet<DossierAttribute> DosAttributes { get; set; }
        public DbSet<DossierGrid> DosGrids { get; set; }
        public DbSet<DossierInset> DosInsets { get; set; }
        public DbSet<DossierLink> DosLinks { get; set; }
        public DbSet<DossierList> DosLists { get; set; }
        public DbSet<DossierObject> DosObjects { get; set; }
        public DbSet<DossierValue> DosValues { get; set; }
        public DbSet<GridValue> GridValues { get; set; }
        public DbSet<Language> Languages { get; set; }
        public DbSet<UDB.System> Systems { get; set; }
    }
}
