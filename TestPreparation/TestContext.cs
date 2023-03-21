using Microsoft.EntityFrameworkCore;
using Preparation.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestPreparation
{
    public class TestContext : Context
    {
        public TestContext(DbContextOptions<Context> options) : base(options)
        {
        }

        public DbSet<Parents> Parents { get; set; }
        public DbSet<Personnes> Personnes { get; set; }

        protected override void OnConfiguring (DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase(databaseName: "PreparationTest");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Parents>().ToTable("Parents");
            modelBuilder.Entity<Personnes>().ToTable("Personnes");
            base.OnModelCreating(modelBuilder);
        }
    }
}
