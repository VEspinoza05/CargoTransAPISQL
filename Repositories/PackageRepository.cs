using CargoTransAPISQL.Models;
using CargoTransAPISQL.Data;
using Microsoft.EntityFrameworkCore;
using CargoTransAPISQL.Repositories.Interfaces;

namespace CargoTransAPISQL.Repositories
{
    public class PackageRepository : IPackageRepository
    {
        private readonly AppDbContext _context;

        public PackageRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<PackageModel>> GetAllAsync()
        {
            return await _context.Packages.ToListAsync();
        }

        public async Task<PackageModel?> GetByIdAsync(int id)
        {
            return await _context.Packages.FindAsync(id);
        }

        public async Task<PackageModel> AddAsync(PackageModel producto)
        {
            _context.Packages.Add(producto);
            await _context.SaveChangesAsync();
            return producto;
        }

        public async Task UpdateAsync(PackageModel producto)
        {
            _context.Entry(producto).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var producto = await _context.Packages.FindAsync(id);
            if (producto != null)
            {
                _context.Packages.Remove(producto);
                await _context.SaveChangesAsync();
            }
        }
    }
}