using CargoTransAPISQL.Models;

namespace CargoTransAPISQL.Interfaces.Reposiories
{
    public interface IEmployeeRepository
    {
        Task<EmployeeModel?> GetByEmailAsync(string email);
        Task<EmployeeModel> AddAsync(EmployeeModel employee);
        Task<IEnumerable<EmployeeModel>> GetAllAsync();
        Task<EmployeeModel?> GetByIdAsync(int id);
        Task<bool> UpdateAsync(EmployeeModel employeeModel);
        Task<bool> DeleteAsync(int id);
        Task<bool> UpdatePasswordAsync(int employeeId, string hashedPassword);
        Task<bool> Exists(int? id);
    }
}