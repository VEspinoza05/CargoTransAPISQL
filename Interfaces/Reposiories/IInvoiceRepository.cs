using CargoTransAPISQL.Models;

namespace CargoTransAPISQL.Interfaces.Reposiories
{
    public interface IInvoiceRepository
    {
        Task<InvoiceModel> AddAsync(InvoiceModel PackageModel);
    }
}