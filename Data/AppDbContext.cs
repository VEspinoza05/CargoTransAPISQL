using Microsoft.EntityFrameworkCore;
using CargoTransAPISQL.Models;

namespace CargoTransAPISQL.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<PackageModel> Packages { get; set; }
        public DbSet<VehicleModel> Vehicles { get; set; }
        public DbSet<EmployeeModel> Employees { get; set; }
        public DbSet<PurchaseModel> Purchases { get; set; }
        public DbSet<SupplierModel> Suppliers { get; set; }
        public DbSet<RoleModel> Roles { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<EmployeeModel>()
                .HasMany(e => e.Vehicles)
                .WithOne(e => e.Driver)
                .HasForeignKey(e => e.DriverId)
                .IsRequired(false);

            modelBuilder.Entity<EmployeeModel>()
                .HasMany(e => e.Purchases)
                .WithOne(e => e.SenderEmployee)
                .HasForeignKey(e => e.SenderEmployeeId);

            modelBuilder.Entity<SupplierModel>()
                .HasMany(e => e.Purchases)
                .WithOne(e => e.Supplier)
                .HasForeignKey(e => e.SupplierId);

            modelBuilder.Entity<VehicleModel>()
                .HasMany(e => e.Packages)
                .WithOne(e => e.Vehicle)
                .HasForeignKey(e => e.VehicleId);

            modelBuilder.Entity<EmployeeModel>()
                .HasOne(e => e.Role)
                .WithMany(e => e.Employees)
                .HasForeignKey(e => e.RoleId);

            // Roles
            modelBuilder.Entity<RoleModel>().HasData(
                new RoleModel { Id = 1, Name = "Director Financiero" },
                new RoleModel { Id = 2, Name = "Director De Compras" },
                new RoleModel { Id = 3, Name = "Director De RR.HH" },
                new RoleModel { Id = 4, Name = "CEO" },
                new RoleModel { Id = 5, Name = "Director Operativo" },
                new RoleModel { Id = 6, Name = "Gerente De Sucursal" },
                new RoleModel { Id = 7, Name = "Encargado De Turno " },
                new RoleModel { Id = 8, Name = "Conductor" }
            );
        }
    }
}