using CargoTransAPISQL.DTOs.Purchase;
using CargoTransAPISQL.Mappers;
using CargoTransAPISQL.Models;
using CargoTransAPISQL.Repositories.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CargoTransAPISQL.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PurchaseController : ControllerBase
    {
        private readonly IPurchaseRepository _repo;

        public PurchaseController(IPurchaseRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PurchaseModel>>> GetAll()
        {
            var purchases = await _repo.GetAllAsync();
            var purchaseDTOs = purchases.Select(p => p.ToPurchaseDTO());
            return Ok(purchaseDTOs);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PurchaseModel>> GetById(int id)
        {
            var purchase = await _repo.GetByIdAsync(id);
            if (purchase == null)
                return NotFound();

            return Ok(purchase.ToPurchaseDTO());
        }

        [HttpPost]
        public async Task<ActionResult<PurchaseModel>> Create(NewPurchaseDTO newPurchaseDTO)
        {
            var purchase = newPurchaseDTO.ToPurchaseFromNewDTO();
            purchase.RequestDate = DateTime.Now;
            var newPurchase = await _repo.AddAsync(purchase);

            if(newPurchase == null)
            {
                return BadRequest();
            }

            return CreatedAtAction(nameof(GetById), new { id = newPurchase.Id }, newPurchase.ToPurchaseDTO());
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UpdatePurchaseDTO updatePurchaseDTO)
        {
            var purchase = updatePurchaseDTO.ToPurchaseFromUpdateDTO(id);

            var result = await _repo.UpdateAsync(purchase);

            if(result == null)
            {
                return NotFound("Purchase not found");
            }
            else
            {
                return Ok(purchase.ToPurchaseDTO());
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _repo.DeleteAsync(id);

            if(result == false)
            {
                return NotFound("Purchase not found");
            }
            else
            {
                return Ok("Purchase deleted successfully");
            }
        }

    }
}