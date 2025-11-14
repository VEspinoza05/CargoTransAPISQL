using CargoTransAPISQL.DTOs.Vehicle;
using CargoTransAPISQL.Models;

namespace CargoTransAPISQL.Mappers
{
    public static class VehicleMapper
    {
        public static VehicleDTO ToVehicleDTO(this VehicleModel vehicleModel)
        {
            return new VehicleDTO()
            {
                Id = vehicleModel.Id,
                VehicleLicensePlate = vehicleModel.VehicleLicensePlate,
                Type = vehicleModel.Type,
                Capacity = vehicleModel.Capacity,
                Status = vehicleModel.Status,
                DriverId = vehicleModel.DriverId,
                EnterDate = vehicleModel.EnterDate,
                Brand = vehicleModel.Brand,
                Model = vehicleModel.Model,
                Serial = vehicleModel.Serial,
            };
        }

        public static VehicleModel ToVehicleFromNewDTO(this NewVehicleDTO newVehicleDTO)
        {
            return new VehicleModel()
            {
                VehicleLicensePlate = newVehicleDTO.VehicleLicensePlate,
                Type = newVehicleDTO.Type,
                Capacity = newVehicleDTO.Capacity,
                Status = newVehicleDTO.Status,
                DriverId = newVehicleDTO.DriverId,
                Brand = newVehicleDTO.Brand,
                Model = newVehicleDTO.Model,
                Serial = newVehicleDTO.Serial,
            };
        }

        public static VehicleModel ToVehicleFromUpdateDTO(this UpdateVehicleDTO updateVehicleModel, int id)
        {
            return new VehicleModel()
            {
                Id = id,
                VehicleLicensePlate = updateVehicleModel.VehicleLicensePlate,
                Type = updateVehicleModel.Type,
                Capacity = updateVehicleModel.Capacity,
                Status = updateVehicleModel.Status,
                DriverId = updateVehicleModel.DriverId,
                Brand = updateVehicleModel.Brand,
                Model = updateVehicleModel.Model,
                Serial = updateVehicleModel.Serial,
            };
        }
    }
}