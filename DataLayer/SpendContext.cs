using System;
using System.Collections.Generic;
using System.Text;
using DataLayer.Models;
using Microsoft.EntityFrameworkCore;

namespace DataLayer
{
    public class SpendContext : DbContext
    {
        public DbSet<Logging> Loggings { get; set; }
        public DbSet<Severity> Severities { get; set; }
        public DbSet<SpendItem> SpendItems { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=Spend;Trusted_Connection=True;");
    }
}
