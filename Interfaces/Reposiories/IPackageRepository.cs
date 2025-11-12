using CargoTransAPISQL.Models;

namespace CargoTransAPISQL.Repositories.Interfaces
{
    public interface IPackageRepository
    {
        Task<IEnumerable<PackageModel>> GetAllAsync();
        Task<PackageModel?> GetByIdAsync(int id);
        Task<PackageModel> AddAsync(PackageModel PackageModel);
        Task UpdateAsync(PackageModel PackageModel);
        Task DeleteAsync(int id);
    }
}