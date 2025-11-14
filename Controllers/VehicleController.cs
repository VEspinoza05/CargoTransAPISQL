using CargoTransAPISQL.DTOs.Vehicle;
using CargoTransAPISQL.Interfaces.Reposiories;
using CargoTransAPISQL.Mappers;
using CargoTransAPISQL.Models;
using Microsoft.AspNetCore.Mvc;

namespace CargoTransAPISQL.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VehicleController : ControllerBase
    {
        private readonly IVehicleRepository _repo;
        private readonly IEmployeeRepository _employeeRepo;

        public VehicleController(IVehicleRepository repo, IEmployeeRepository employeeRepo)
        {
            _repo = repo;
            _employeeRepo = employeeRepo;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<VehicleModel>>> GetAll()
        {
            var vehicles = await _repo.GetAllAsync();
            var supplierDTOs = vehicles.Select(s => s.ToVehicleDTO());
            return Ok(supplierDTOs);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<VehicleModel>> GetById(int id)
        {
            var vehicle = await _repo.GetByIdAsync(id);
            if (vehicle == null)
                return NotFound();

            return Ok(vehicle.ToVehicleDTO());
        }

        [HttpPost]
        public async Task<ActionResult<VehicleModel>> Create(NewVehicleDTO newVehicleDTO)
        {
            if(newVehicleDTO.DriverId != null)
            {
                var exists = await _employeeRepo.Exists(newVehicleDTO.DriverId);
                if(exists == false)
                {
                    return NotFound("Driver not found");
                }
            } 

            var vehicle = newVehicleDTO.ToVehicleFromNewDTO();
            vehicle.EnterDate = DateTime.Now;
            var newVehicle = await _repo.AddAsync(vehicle);
            return CreatedAtAction(nameof(GetById), new { id = newVehicle.Id }, newVehicle.ToVehicleDTO());
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UpdateVehicleDTO updateVehicleDTO)
        {
            if(updateVehicleDTO.DriverId != null)
            {
                var exists = await _employeeRepo.Exists(updateVehicleDTO.DriverId);
                if(exists == false)
                {
                    return NotFound("Driver not found");
                }
            } 

            var vehicle = updateVehicleDTO.ToVehicleFromUpdateDTO(id);

            var result = await _repo.UpdateAsync(vehicle);

            if(result == false)
            {
                return NotFound("Vehicle not found");
            }
            else
            {
                return Ok("Vehicle updated successfully");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _repo.DeleteAsync(id);

            if(result == false)
            {
                return NotFound("Vehicle not found");
            }
            else
            {
                return Ok("Vehicle deleted successfully");
            }
        }
    }
}