using Microsoft.EntityFrameworkCore;
using System.Data.SqlClient;

namespace Preparation.Models
{
    public class PreparationContext:DbContext
    {
        public PreparationContext(DbContextOptions<PreparationContext> options) : base(options)  {  }

        public DbSet<Parents> Parents { get; set; }
        public DbSet<Personnes> Personnes { get; set; }

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
