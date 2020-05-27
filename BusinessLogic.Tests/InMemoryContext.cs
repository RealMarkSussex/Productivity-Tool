using System;
using System.Collections.Generic;
using System.Text;
using DataLayer.Models;
using Microsoft.EntityFrameworkCore;

namespace BusinessLogic.Tests.Fakes
{
    public class InMemoryContext : DbContext
    {
        public DbSet<Logging> Loggings { get; set; }
        public DbSet<Severity> Severities { get; set; }
        public DbSet<SpendItem> SpendItems { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseInMemoryDatabase("SpendInMemoryDatabase");
    }
}
