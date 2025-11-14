using CargoTransAPISQL.DTOs.Employee;
using CargoTransAPISQL.Models;

namespace CargoTransAPISQL.Mappers
{
    public static class EmployeeMapper
    {
        public static EmployeeModel ToSupplierFromBasicUpdateDTO(this UpdateEmployeeBasicDataDTO updateEmployeeBasicDataDTO, int id)
        {
            return new EmployeeModel
            {
                Id = id,
                FirstName = updateEmployeeBasicDataDTO.FirstName,
                LastName = updateEmployeeBasicDataDTO.LastName,
                RoleId = updateEmployeeBasicDataDTO.RoleId,
                Status = updateEmployeeBasicDataDTO.Status,
                Phone = updateEmployeeBasicDataDTO.Phone,
                ContractType = updateEmployeeBasicDataDTO.ContractType,
                Shift = updateEmployeeBasicDataDTO.Shift,
                Email = updateEmployeeBasicDataDTO.Email
            };
        }

        public static EmployeeDTO ToEmployeeDTO(this EmployeeModel employeeModel)
        {
            return new EmployeeDTO
            {
                Id = employeeModel.Id,
                FirstName = employeeModel.FirstName,
                LastName = employeeModel.LastName,
                RoleId = employeeModel.RoleId,
                RoleName = employeeModel.Role.Name,
                StartDate = employeeModel.StartDate,
                Status = employeeModel.Status,
                Phone = employeeModel.Phone,
                ContractType = employeeModel.ContractType,
                Shift = employeeModel.Shift,
                Email = employeeModel.Email
            };
        }
    }
}