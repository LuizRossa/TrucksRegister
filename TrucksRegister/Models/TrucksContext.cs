using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;

namespace TrucksRegister.Models
{

    public class TrucksContext : DbContext
    {
        public TrucksContext() { }

        public TrucksContext(DbContextOptions<TrucksContext> options) : base(options) { }

        public DbSet<Trucks> Trucks { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
            .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
            .AddJsonFile("appsettings.json")
            .Build();

            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(configuration.GetConnectionString("TrucksDatabase"));
            }
        }
    }
}
