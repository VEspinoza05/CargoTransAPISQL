namespace CargoTransAPISQL.Models
{
    public class InvoiceModel
    {
        public int Id { get; set; }
        public double PricePerPound { get; set; }
        public double Pounds { get; set; }
        public double Total { get; set; }
        public DateTime BillingDate { get; set; }
        public ICollection<PackageModel> Packages { get; set; } = new List<PackageModel>();
    }

}