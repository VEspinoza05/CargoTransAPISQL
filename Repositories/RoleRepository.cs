using CargoTransAPISQL.Data;
using CargoTransAPISQL.Interfaces;
using CargoTransAPISQL.Models;
using Microsoft.EntityFrameworkCore;

namespace CargoTransAPISQL.Repositories
{
    public class RoleRepository : IRoleRepository
    {
        private readonly AppDbContext _context;

        public RoleRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<RoleModel>> GetAllAsync()
        {
            return await _context.Roles.ToListAsync();
        }

        public async Task<RoleModel?> GetByIdAsync(int id)
        {
            return await _context.Roles.FindAsync(id);
        }
    }
}