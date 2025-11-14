using CargoTransAPISQL.Models;

namespace CargoTransAPISQL.Interfaces.Reposiories
{
    public interface IVehicleRepository
    {
        Task<IEnumerable<VehicleModel>> GetAllAsync();
        Task<VehicleModel?> GetByIdAsync(int id);
        Task<VehicleModel> AddAsync(VehicleModel vehicleModel);
        Task<bool> UpdateAsync(VehicleModel vehicleModel);
        Task<bool> DeleteAsync(int id);
    }
}