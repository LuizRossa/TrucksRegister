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
    }
}
