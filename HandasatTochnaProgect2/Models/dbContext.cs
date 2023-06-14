using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HandasatTochnaProgect2.Models
{
    public class dbContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public DbSet<ItemToSell> Shop { get; set; }

        public DbSet<Item> ItemsList { get; set; }

        public DbSet<Avatar> Avatars { get; set; }

        public DbSet<User2Item> Users2Items { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User2Item>().HasKey(nameof(User2Item.itemId), nameof(User2Item.userName));
        }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite(@"Data source = Demo.db");
    }
}