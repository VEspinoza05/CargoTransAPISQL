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

        public async Task<EmployeeModel> AddAsync(EmployeeModel employee)
        {
            _context.Employees.Add(employee);
            await _context.SaveChangesAsync();
            return employee;
        }

        public async Task<IEnumerable<EmployeeModel>> GetAllAsync()
        {
            return await _context.Employees
                .Include(e => e.Role)
                .ToListAsync();
        }

        public async Task<EmployeeModel?> GetByIdAsync(int id)
        {
            return await _context.Employees
                .Include(e => e.Role)
                .FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task<bool> UpdateAsync(EmployeeModel employeeModel)
        {
            var existingEmployee = await _context.Employees.FindAsync(employeeModel.Id);

            if(existingEmployee == null)
            {
                return false;
            }

            existingEmployee.FirstName = employeeModel.FirstName;
            existingEmployee.LastName = employeeModel.LastName;
            existingEmployee.RoleId = employeeModel.RoleId;
            existingEmployee.Status = employeeModel.Status;
            existingEmployee.ContractType = employeeModel.ContractType;
            existingEmployee.Shift = employeeModel.Shift;
            existingEmployee.Email = employeeModel.Email;
            
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> UpdatePasswordAsync(int employeeId, string hashedPassword)
        {
            var existingEmployee = await _context.Employees.FindAsync(employeeId);

            if(existingEmployee == null)
            {
                return false;
            }

            existingEmployee.PasswordHash = hashedPassword;

            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var employeeModel = await _context.Employees.FirstOrDefaultAsync(x => x.Id == id);

            if(employeeModel == null)
            {
                return false;
            }

            _context.Employees.Remove(employeeModel);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Exists(int? id)
        {
            if(id == null)
                return false;

            var result = await _context.Employees.FirstOrDefaultAsync(e => e.Id == id);

            if(result == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}