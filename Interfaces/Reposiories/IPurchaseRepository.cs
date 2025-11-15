using CargoTransAPISQL.Models;

namespace CargoTransAPISQL.Repositories.Interfaces
{
    public interface IPurchaseRepository
    {
        Task<IEnumerable<PurchaseModel>> GetAllAsync();
        Task<PurchaseModel?> GetByIdAsync(int id);
        Task<PurchaseModel> AddAsync(PurchaseModel purchase);
        Task<bool> UpdateAsync(PurchaseModel purchase);
        Task<bool> DeleteAsync(int id);
    }
}