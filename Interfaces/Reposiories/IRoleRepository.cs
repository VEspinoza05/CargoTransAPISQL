using CargoTransAPISQL.Models;

namespace CargoTransAPISQL.Interfaces
{
    public interface IRoleRepository
    {
        Task<IEnumerable<RoleModel>> GetAllAsync();
    }
}