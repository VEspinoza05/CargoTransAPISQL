using Microsoft.EntityFrameworkCore;
using CargoTransAPISQL.Models;

namespace CargoTransAPISQL.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<PackageModel> Packages { get; set; }
        public DbSet<VehicleModel> Vehicles { get; set; }
        public DbSet<PackageVehicleModel> PackageVehicles { get; set; }
        public DbSet<EmployeeModel> Employees { get; set; }
        public DbSet<PurchaseModel> Purchases { get; set; }
        public DbSet<SupplierModel> Suppliers { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PackageVehicleModel>(e => e.HasKey( e => new { e.VehicleId, e.PackageId }));

            modelBuilder.Entity<EmployeeModel>()
                .HasMany(e => e.Vehicles)
                .WithOne(e => e.Driver)
                .HasForeignKey(e => e.DriverId);

            modelBuilder.Entity<EmployeeModel>()
                .HasMany(e => e.Purchases)
                .WithOne(e => e.SenderEmployee)
                .HasForeignKey(e => e.SenderEmployeeId);

            modelBuilder.Entity<SupplierModel>()
                .HasMany(e => e.Purchases)
                .WithOne(e => e.Supplier)
                .HasForeignKey(e => e.SupplierId);

            modelBuilder.Entity<PackageVehicleModel>()
                .HasOne(e => e.Vehicle)
                .WithMany(e => e.PackageVehicles)
                .HasForeignKey(e => e.VehicleId);

            modelBuilder.Entity<PackageVehicleModel>()
                .HasOne(e => e.Package)
                .WithMany(e => e.PackageVehicles)
                .HasForeignKey(e => e.PackageId);  
        }
    }
}