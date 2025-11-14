using CargoTransAPISQL.Data;
using CargoTransAPISQL.Interfaces.Reposiories;
using CargoTransAPISQL.Models;
using Microsoft.EntityFrameworkCore;

namespace CargoTransAPISQL.Repositories
{
    public class VehicleRepository : IVehicleRepository
    {
        private readonly AppDbContext _context;

        public VehicleRepository(AppDbContext context)
        {
            _context = context;
        }
        
        public async Task<VehicleModel> AddAsync(VehicleModel vehicleModel)
        {
            _context.Vehicles.Add(vehicleModel);
            await _context.SaveChangesAsync();
            return vehicleModel;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var vehicleModel = await _context.Vehicles.FirstOrDefaultAsync(x => x.Id == id);

            if(vehicleModel == null)
            {
                return false;
            }

            _context.Vehicles.Remove(vehicleModel);
            await _context.SaveChangesAsync();
            return true;
        }
        

        public async Task<IEnumerable<VehicleModel>> GetAllAsync()
        {
            return await _context.Vehicles.ToListAsync();
        }

        public async Task<VehicleModel?> GetByIdAsync(int id)
        {
            return await _context.Vehicles.FindAsync(id);
        }

        public async Task<bool> UpdateAsync(VehicleModel vehicleModel)
        {
            var existingVehicles = await _context.Vehicles.FindAsync(vehicleModel.Id);

            if(existingVehicles == null)
            {
                return false;
            }

            existingVehicles.VehicleLicensePlate = vehicleModel.VehicleLicensePlate;
            existingVehicles.Type = vehicleModel.Type;
            existingVehicles.Capacity = vehicleModel.Capacity;
            existingVehicles.Status = vehicleModel.Status;
            existingVehicles.DriverId = vehicleModel.DriverId;
            existingVehicles.Brand = vehicleModel.Brand;
            existingVehicles.Model = vehicleModel.Model;
            existingVehicles.Serial = vehicleModel.Serial;
            

            await _context.SaveChangesAsync();

            return true;
        }
    }
}