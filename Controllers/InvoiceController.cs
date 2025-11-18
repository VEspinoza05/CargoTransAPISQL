using CargoTransAPISQL.DTOs.Employee;
using CargoTransAPISQL.DTOs.Invoice;
using CargoTransAPISQL.Interfaces.Reposiories;
using CargoTransAPISQL.Mappers;
using CargoTransAPISQL.Models;
using CargoTransAPISQL.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CargoTransAPISQL.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class InvoiceController : ControllerBase
    {
        private readonly IInvoiceRepository _repo;
        private readonly IPackageRepository _packageRepository;

        public InvoiceController(IInvoiceRepository repo, IPackageRepository packageRepository)
        {
            _repo = repo;
            _packageRepository = packageRepository;
        }

        [HttpPost]
        public async Task<ActionResult> Create(NewInvoiceDTO invoiceDTO)
        {
            var newInvoice = await _repo.AddAsync(invoiceDTO.ToInvoiceFromNewDTO());
            var newPackages = invoiceDTO.Packages;
            foreach(var package in newPackages)
            {
                var newPkg = package.ToPackageFromNewDTO();
                newPkg.InvoiceId = newInvoice.Id;
                await _packageRepository.AddAsync(newPkg);
            }
            return Ok();
        }
    }
}