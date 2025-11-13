using CargoTransAPISQL.Data;
using CargoTransAPISQL.Interfaces.Reposiories;
using CargoTransAPISQL.Models;
using Microsoft.EntityFrameworkCore;

namespace CargoTransAPISQL.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly AppDbContext _context;

        public EmployeeRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<EmployeeModel?> GetByEmailAsync(string email)
        {
            return await _context.Employees.Include(u => u.Role)
                .FirstOrDefaultAsync(u => u.Email == email);
        }

        public async Task AddAsync(EmployeeModel employee)
        {
            _context.Employees.Add(employee);
            await _context.SaveChangesAsync();
        }
    }
}