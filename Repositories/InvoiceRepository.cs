using CargoTransAPISQL.Models;
using CargoTransAPISQL.Data;
using Microsoft.EntityFrameworkCore;
using CargoTransAPISQL.Repositories.Interfaces;
using CargoTransAPISQL.Interfaces.Reposiories;

namespace CargoTransAPISQL.Repositories
{
    public class InvoiceRepository : IInvoiceRepository
    {
        private readonly AppDbContext _context;

        public InvoiceRepository(AppDbContext context, IPackageRepository packageRepository)
        {
            _context = context;
            
        }

        public async Task<InvoiceModel> AddAsync(InvoiceModel invoice)
        {
            invoice.BillingDate = DateTime.Now;
            _context.Invoices.Add(invoice);
            await _context.SaveChangesAsync();
            return invoice;
        }
    }
}