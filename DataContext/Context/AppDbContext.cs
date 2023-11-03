using Domain.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataContext.Context
{
    public class AppDbContext :IdentityDbContext<AppUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options) { }



        private const string CONNECTION_STRING = "Host=localhost;Port=5432;" +
             "Username=postgres;" +
             "Password=postgres;" +
             "Database=identityandmvc";

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseNpgsql(CONNECTION_STRING);
        }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<IdentityUser>(entity =>
        //    {
        //        entity.HasKey(e => e.Id);
        //    });

        //    modelBuilder.Entity<IdentityRole>(entity =>
        //    {
        //        entity.HasKey(e => e.Id);
        //    });

        //    modelBuilder.Entity<IdentityUserRole<string>>(entity =>
        //    {
        //        entity.HasKey(e => new { e.UserId, e.RoleId });
        //    });

        //    modelBuilder.Entity<IdentityUserLogin<string>>(entity =>
        //    {
        //        entity.HasKey(e => new { e.LoginProvider, e.ProviderKey });
        //    });

        //    modelBuilder.Entity<IdentityUserToken<string>>(entity =>
        //    {
        //        entity.HasKey(e => e.UserId);
        //    });
        //}

        public DbSet<User> Users { get; set; }
        public DbSet<Car> Cars { get; set; }
        
    }
}
