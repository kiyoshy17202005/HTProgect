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

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite(@"Data source = Demo.db");

    }
}