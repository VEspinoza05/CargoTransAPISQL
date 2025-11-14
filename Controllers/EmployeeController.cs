using CargoTransAPISQL.DTOs.Employee;
using CargoTransAPISQL.Interfaces.Reposiories;
using CargoTransAPISQL.Mappers;
using CargoTransAPISQL.Models;
using Microsoft.AspNetCore.Mvc;

namespace CargoTransAPISQL.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeRepository _repo;

        public EmployeeController(IEmployeeRepository repo)
        {
            _repo = repo;
        }

        
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EmployeeModel>>> GetAll()
        {
            var employees = await _repo.GetAllAsync();

            var employeeDTOs = employees.Select(s => s.ToEmployeeDTO());
            return Ok(employeeDTOs);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<EmployeeModel>> GetById(int id)
        {
            var employee = await _repo.GetByIdAsync(id);
            if (employee == null)
                return NotFound();

            return Ok(employee.ToEmployeeDTO());
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UpdateEmployeeBasicDataDTO updateEmployeeBasicDataDTO)
        {
            var employee = updateEmployeeBasicDataDTO.ToSupplierFromBasicUpdateDTO(id);

            var result = await _repo.UpdateAsync(employee);

            if(result == false)
            {
                return NotFound("Employee not found");
            }
            else
            {
                return Ok("Employee updated successfully");
            }
        }

        [HttpPut("UpdatePassword/{id}")]
        public async Task<IActionResult> UpdatePassword(int id, NewPasswordEmployeeDTO newPasswordEmployeeDTO)
        {
            string hashedPassword = BCrypt.Net.BCrypt.HashPassword(newPasswordEmployeeDTO.Password);
            var result = await _repo.UpdatePasswordAsync(id,hashedPassword);

            if(result == false)
            {
                return NotFound("Employee not found");
            }
            else
            {
                return Ok("Password updated successfully");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _repo.DeleteAsync(id);

            if(result == false)
            {
                return NotFound("Employee not found");
            }
            else
            {
                return Ok("Employee deleted successfully");
            }
        }
    }
}