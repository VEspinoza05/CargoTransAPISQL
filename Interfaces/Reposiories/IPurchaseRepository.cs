using CargoTransAPISQL.Models;

namespace CargoTransAPISQL.Repositories.Interfaces
{
    public interface IPurchaseRepository
    {
        Task<IEnumerable<PurchaseModel>> GetAllAsync();
        Task<PurchaseModel?> GetByIdAsync(int id);
        Task<PurchaseModel?> AddAsync(PurchaseModel purchase);
        Task<PurchaseModel?> UpdateAsync(PurchaseModel purchase);
        Task<PurchaseModel?> ReviewAsync(PurchaseModel purchase);
        Task<bool> DeleteAsync(int id);
    }
}