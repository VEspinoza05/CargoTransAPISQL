using CargoTransAPISQL.DTOs.Package;

namespace CargoTransAPISQL.DTOs.Invoice
{
    public class NewInvoiceDTO
    {
        public double PricePerPound { get; set; }
        public double Pounds { get; set; }
        public double Total { get; set; }
        public ICollection<NewPackageDTO> Packages { get; set; } = new List<NewPackageDTO>();
    }
}