using BGLOrderApp.Models.Data;
using Microsoft.EntityFrameworkCore;
using System;

namespace BGLOrderApp.Data
{
    public class OrdersDbContext : DbContext
    {
        public DbSet<Order> Orders { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<OrderItem> OrderDetails { get; set; }

        /// <summary>
        /// Constructor must provide options to base for connection pooling
        /// </summary>
        /// <param name="options"></param>
        public OrdersDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasSequence<int>("Order_seq").StartsAt(0).IncrementsBy(1);
            modelBuilder.Entity<Order>().Property("Id").HasDefaultValueSql("NEXT VALUE FOR Order_seq");

            modelBuilder.HasSequence<int>("Item_seq").StartsAt(0).IncrementsBy(1);
            modelBuilder.Entity<Item>().Property("Id").HasDefaultValueSql("NEXT VALUE FOR Item_seq");

            modelBuilder.Entity<OrderItem>().HasKey(od => new { od.OrderId, od.ItemId });

            modelBuilder.Entity<Item>().HasData(
                new Item() { Id = 9, Name = "Item 1", Description = "Item 1 Description", Price = 10.99M, Status = 0 },
                new Item() { Id = 1, Name = "Item 2", Description = "Item 2 Description", Price = 10.99M, Status = 0 },
                new Item() { Id = 2, Name = "Item 3", Description = "Item 3 Description", Price = 10.99M, Status = 0 },
                new Item() { Id = 3, Name = "Item 4", Description = "Item 4 Description", Price = 10.99M, Status = 1 },
                new Item() { Id = 4, Name = "Item 5", Description = "Item 5 Description", Price = 10.99M, Status = 0 },
                new Item() { Id = 5, Name = "Item 6", Description = "Item 6 Description", Price = 10.99M, Status = 1 },
                new Item() { Id = 6, Name = "Item 7", Description = "Item 7 Description", Price = 10.99M, Status = 0 },
                new Item() { Id = 7, Name = "Item 8", Description = "Item 8 Description", Price = 10.99M, Status = 2 },
                new Item() { Id = 8, Name = "Item 9", Description = "Item 9 Description", Price = 10.99M, Status = 0 });
        }
    }
}
