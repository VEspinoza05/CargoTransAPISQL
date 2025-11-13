using CargoTransAPISQL.Models;

namespace CargoTransAPISQL.Repositories.Interfaces
{
    public interface ISupplierRepository
    {
        Task<IEnumerable<SupplierModel>> GetAllAsync();
        Task<SupplierModel?> GetByIdAsync(int id);
        Task<SupplierModel> AddAsync(SupplierModel supplier);
        Task<bool> UpdateAsync(SupplierModel supplier);
        Task<bool> DeleteAsync(int id);
    }
}