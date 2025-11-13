using CargoTransAPISQL.Models;
using CargoTransAPISQL.Data;
using Microsoft.EntityFrameworkCore;
using CargoTransAPISQL.Repositories.Interfaces;

namespace CargoTransAPISQL.Repositories
{
    public class SupplierRepository : ISupplierRepository
    {
        private readonly AppDbContext _context;

        public SupplierRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<SupplierModel>> GetAllAsync()
        {
            return await _context.Suppliers.ToListAsync();
        }

        public async Task<SupplierModel?> GetByIdAsync(int id)
        {
            return await _context.Suppliers.FindAsync(id);
        }

        public async Task<SupplierModel> AddAsync(SupplierModel supplier)
        {
            _context.Suppliers.Add(supplier);
            await _context.SaveChangesAsync();
            return supplier;
        }

        public async Task<bool> UpdateAsync(SupplierModel supplierModel)
        {
            var existingSupplier = await _context.Suppliers.FindAsync(supplierModel.Id);

            if(existingSupplier == null)
            {
                return false;
            }

            existingSupplier.Name = supplierModel.Name;
            existingSupplier.Email = supplierModel.Email;
            existingSupplier.Address = supplierModel.Address;
            existingSupplier.Phone = supplierModel.Phone;

            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var supplierModel = await _context.Suppliers.FirstOrDefaultAsync(x => x.Id == id);

            if(supplierModel == null)
            {
                return false;
            }

            _context.Suppliers.Remove(supplierModel);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}