using Domain.Entities;
using Infra.Mappings;
using Microsoft.EntityFrameworkCore;
using Shared;
using System;

namespace Infra.Context
{
    public class MainDataContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<SubCategory> SubCategories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProductMap());
            modelBuilder.ApplyConfiguration(new CategoryMap());
            modelBuilder.ApplyConfiguration(new SubCategoryMap());

            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(Runtime.ConnectionString,
                options => options.CommandTimeout((int)TimeSpan.FromMinutes(10).TotalSeconds));
        }
    }
}
