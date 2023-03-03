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
    public class TestContext : DbContext//, IDisposable
    {
        public TestContext(DbContextOptions<TestContext> options) : base(options)
        {
            
        }
        public DbSet<Parents> Parents { get; set; }
        public DbSet<Personnes> Personnes { get; set; }

        //public void Dispose()
        //{
        //    this.Database.RollbackTransaction();
        //}


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                SqlConnectionStringBuilder connectionStringBuilder = new SqlConnectionStringBuilder
                {
                    DataSource = "localhost",
                    InitialCatalog = "Preparation",
                    Encrypt = true,
                    TrustServerCertificate = true
                };

                optionsBuilder.UseSqlServer(connectionStringBuilder.ToString());
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Parents>().ToTable("Parents");
            modelBuilder.Entity<Personnes>().ToTable("Personnes");
            base.OnModelCreating(modelBuilder);
        }
    }
}
