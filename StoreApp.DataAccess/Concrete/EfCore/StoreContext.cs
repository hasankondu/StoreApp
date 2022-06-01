using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using StoreApp.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace StoreApp.DataAccess.Concrete.EfCore
{
    public class StoreContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            optionsBuilder
                //.UseLazyLoadingProxies()
                //.ConfigureWarnings(w => w.Ignore(CoreEventId.LazyLoadOnDisposedContextWarning))
                .UseSqlServer(@"Server=(localdb)\MSSQLLocalDB; Database=StoreDb; Integrated Security=True;");

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProductCategorySub>()
               .HasKey(x => new { x.CategorySubID, x.ProductID });

        }

        public DbSet<Advertised> Advertiseds { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<CategorySub> CategorySubs { get; set; }
        public DbSet<Favorite> Favorites { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }
    }
}
