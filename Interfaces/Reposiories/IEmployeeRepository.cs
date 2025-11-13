using CargoTransAPISQL.Models;

namespace CargoTransAPISQL.Interfaces.Reposiories
{
    public interface IEmployeeRepository
    {
        Task<EmployeeModel?> GetByEmailAsync(string email);
        Task AddAsync(EmployeeModel employee);
    }
}