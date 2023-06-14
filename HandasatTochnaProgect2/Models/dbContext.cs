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

        public Body DefultBody { get; set; } = Body.Instance;
        public Pants DefultPants { get; set; } = Pants.Instance;
        public Shirt DefultShirt { get; set; } = Shirt.Instance;

        public dbContext()
        {
            // Initialize Body, Shirt, and Pants with existing data from the database
            using (var db = new dbContext())
            {
                DefultBody = db.Bodies.FirstOrDefault();
                DefultShirt = db.Shirts.FirstOrDefault();
                DefultPants = db.Pants.FirstOrDefault();
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User2Item>().HasKey(nameof(User2Item.itemId), nameof(User2Item.userName));
        }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite(@"Data source = Demo.db");
    }
}