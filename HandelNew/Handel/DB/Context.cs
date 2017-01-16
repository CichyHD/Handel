using Handel.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DB
{
    internal sealed class Configuration : DbMigrationsConfiguration<Context>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }
    }

   public class Context : DbContext
    {
        public Context()
            : base("name=DefaultConnection")
        {
            Database.SetInitializer<Context>(new MigrateDatabaseToLatestVersion<Context, Configuration>());
        }

        public DbSet<ShirtModel> Shirt { get; set; }

        public DbSet<ApplicationUser> ApplicationUser { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<IdentityUserLogin>().HasKey<string>(l => l.UserId);
            modelBuilder.Entity<IdentityRole>().HasKey<string>(r => r.Id);
            modelBuilder.Entity<IdentityUserRole>().HasKey(r => new { r.RoleId, r.UserId });
        }

        public override int SaveChanges()
        {
            var modifiedEntries = ChangeTracker.Entries()
                .Where(x => x.Entity is IBase
                    && (x.State == System.Data.Entity.EntityState.Added
                        || x.State == System.Data.Entity.EntityState.Modified));

            foreach (var entry in modifiedEntries)
            {
                IBase entity = entry.Entity as IBase;
                if (entity != null)
                {
                    string identityName = Thread.CurrentPrincipal.Identity.Name;
                    DateTime now = DateTime.Now;

                    if (entry.State == System.Data.Entity.EntityState.Added)
                    {
                        entity.CreatedDate = now;
                    }
                    else
                    {
                        base.Entry(entity).Property(x => x.CreatedDate).IsModified = false;
                    }
                }
            }

            return base.SaveChanges();
        }
    }
}
