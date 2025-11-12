using Microsoft.EntityFrameworkCore;
using CargoTransAPISQL.Models;

namespace CargoTransAPISQL.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<PackageModel> Packages { get; set; }
    }
}