using CargoTransAPISQL.DTOs.Role;
using CargoTransAPISQL.Models;

namespace CargoTransAPISQL.Mappers
{
    public static class RoleMapper
    {
        public static RoleDTO ToRoleDTO(this RoleModel roleModel)
        {
            return new RoleDTO()
            {
                Id = roleModel.Id,
                Name = roleModel.Name,
            };
        }
    }
}