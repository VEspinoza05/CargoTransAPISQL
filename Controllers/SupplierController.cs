using CargoTransAPISQL.DTOs.Supplier;
using CargoTransAPISQL.Mappers;
using CargoTransAPISQL.Models;
using CargoTransAPISQL.Repositories.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CargoTransAPISQL.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SupplierController : ControllerBase
    {
        private readonly ISupplierRepository _repo;

        public SupplierController(ISupplierRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<SupplierModel>>> GetAll()
        {
            var suppliers = await _repo.GetAllAsync();
            var supplierDTOs = suppliers.Select(s => s.ToSupplierDTO());
            return Ok(supplierDTOs);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SupplierModel>> GetById(int id)
        {
            var supplier = await _repo.GetByIdAsync(id);
            if (supplier == null)
                return NotFound();

            return Ok(supplier.ToSupplierDTO());
        }

        [HttpPost]
        public async Task<ActionResult<SupplierModel>> Create(NewSupplierDTO newSupplierDTO)
        {
            SupplierModel supplier = new SupplierModel()
            {
                Name = newSupplierDTO.Name,
                Email = newSupplierDTO.Email,
                Address = newSupplierDTO.Address,
                Phone = newSupplierDTO.Phone
            };

            var newSupplier = await _repo.AddAsync(supplier);
            return CreatedAtAction(nameof(GetById), new { id = newSupplier.Id }, newSupplier.ToSupplierDTO());
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UpdateSupplierDTO updateSupplierDTO)
        {
            var supplier = updateSupplierDTO.ToSupplierFromUpdateDTO(id);

            var result = await _repo.UpdateAsync(supplier);

            if(result == false)
            {
                return NotFound("Supplier not found");
            }
            else
            {
                return Ok("Supplier updated successfully");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _repo.DeleteAsync(id);

            if(result == false)
            {
                return NotFound("Supplier not found");
            }
            else
            {
                return Ok("Supplier deleted successfully");
            }
        }

    }
}