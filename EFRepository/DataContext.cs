using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DomainBasic;


namespace EFRepository
{
    public class DataContext :DbContext
    {
        public DataContext(DbContextOptions options) : base (options)
        {
            var optValues = options;
        }

        public DataContext() : base()
        { }

        public DbSet<Product> Products { get; set; }
        public DbSet<testClass> testClasses { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                @"Server=localhost\i2016;
                DataBase=2021hw20;
                Trusted_Connection=True;"

                );

        }
        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Product>().HasKey(p => p.ProductId);
        //}

    }
}
