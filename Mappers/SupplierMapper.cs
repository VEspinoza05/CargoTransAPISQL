using CargoTransAPISQL.DTOs.Supplier;
using CargoTransAPISQL.Models;

namespace CargoTransAPISQL.Mappers
{
    public static class SupplierMapper
    {
        public static SupplierDTO ToSupplierDTO(this SupplierModel supplierModel)
        {
            return new SupplierDTO
            {
                Id = supplierModel.Id,
                Name = supplierModel.Name,
                Email = supplierModel.Email,
                Address = supplierModel.Address,
                Phone = supplierModel.Phone
            };
        }

        public static SupplierModel ToSupplierFromUpdateDTO(this UpdateSupplierDTO updateSupplierDTO, int id)
        {
            return new SupplierModel
            {
                Id = id,
                Name = updateSupplierDTO.Name,
                Email = updateSupplierDTO.Email,
                Address = updateSupplierDTO.Address,
                Phone = updateSupplierDTO.Phone 
            };
        }
    }
}