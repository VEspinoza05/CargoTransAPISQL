
using CargoTransAPISQL.DTOs.Invoice;
using CargoTransAPISQL.Models;

namespace CargoTransAPISQL.Mappers
{
    public static class InvoiceMapper
    {
        public static InvoiceModel ToInvoiceFromNewDTO(this NewInvoiceDTO newInvoiceDTO)
        {
            return new InvoiceModel()
            {
                PricePerPound = newInvoiceDTO.PricePerPound,
                Pounds = newInvoiceDTO.Pounds,
                Total = newInvoiceDTO.Total,
            };
        }

    }
}