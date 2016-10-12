using Burk.Model.UDB;
using Burk.Model.Users;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Data.Entity;

namespace Burk.Model.Context
{
    public class ModelContext : IdentityDbContext<User, Role, string, UserLogin, UserRole, UserClaim>
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
        public DbSet<FeatureInObject> FeatureInObject { get; set; }
        public DbSet<FeatureInObjectInRole> FeatureInObjectInRole { get; set; }
        public DbSet<RoleInUser> RoleInUser { get; set; }
        public DbSet<UserInSystem> UserInSystem { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<User>().ToTable("AspNetUsers", "user");
            modelBuilder.Entity<Role>().ToTable("AspNetRoles", "user");
            modelBuilder.Entity<UserClaim>().ToTable("AspNetUserClaims", "user");
            modelBuilder.Entity<UserLogin>().ToTable("AspNetUserLogins", "user");
            modelBuilder.Entity<UserRole>().ToTable("AspNetUserRoles", "user");
        }

        public static ModelContext Create()
        {
            return new ModelContext();
        }
    }
}
