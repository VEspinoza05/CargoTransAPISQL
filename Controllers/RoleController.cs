using CargoTransAPISQL.Interfaces;
using CargoTransAPISQL.Models;
using Microsoft.AspNetCore.Mvc;
using CargoTransAPISQL.Mappers;

namespace CargoTransAPISQL.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RoleController : ControllerBase
    {
        private readonly IRoleRepository _repo;

        public RoleController(IRoleRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<RoleModel>>> GetAll()
        {
            var roles = await _repo.GetAllAsync();
            var rolesDTOs = roles.Select(r => r.ToRoleDTO());
            return Ok(rolesDTOs);
        }
    }
}