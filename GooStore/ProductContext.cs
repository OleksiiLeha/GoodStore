using System;
using System.Collections.Generic;
using System.Text;
using GoodStore.Model;
using Microsoft.EntityFrameworkCore;

namespace GoodStore
{
    class ProductContext : DbContext
    {
        public DbSet<Batch> Batches { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductsInBatch> ProductsInBatches { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string conStr = @"Server=(localdb)\mssqllocaldb;Database = GoodStore; AttachDbFilename = E:\GL\projects\GooStore\GooStore\AppData\GoodStore.mdf;Trusted_Connection=True;";
            optionsBuilder.UseSqlServer(conStr);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProductsInBatch>().HasKey(k => new {k.ProductName, k.BatchId});
        }
    }
}
