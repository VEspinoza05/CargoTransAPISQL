using CargoTransAPISQL.Models;
using CargoTransAPISQL.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CargoTransAPISQL.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PackageController : ControllerBase
    {
        private readonly IPackageRepository _repo;

        public PackageController(IPackageRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PackageModel>>> GetAll()
        {
            var productos = await _repo.GetAllAsync();
            return Ok(productos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PackageModel>> GetById(int id)
        {
            var package = await _repo.GetByIdAsync(id);
            if (package == null)
                return NotFound();

            return Ok(package);
        }

        [HttpPost]
        public async Task<ActionResult<PackageModel>> Create(PackageModel package)
        {
            var nuevo = await _repo.AddAsync(package);
            return CreatedAtAction(nameof(GetById), new { id = nuevo.Id }, nuevo);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, PackageModel package)
        {
            if (id != package.Id)
                return BadRequest();

            await _repo.UpdateAsync(package);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _repo.DeleteAsync(id);
            return NoContent();
        }
    }
}