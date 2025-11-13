namespace CargoTransAPISQL.Models
{
    public class PurchaseModel
    {
        public int Id { get; set; }
        public int SupplierId { get; set; }
        public DateTime RequestDate { get; set; }
        public string ProductName { get; set; } = string.Empty;
        public string ProductDescription { get; set; } = string.Empty;
        public int Quantity { get; set; }
        public double UnitPrice { get; set; }
        public double Total { get; set; }
        public string Status { get; set; } = string.Empty;
        public DateTime? RevisionDate { get; set; }
        public string? RevisionDescription { get; set; }
        public int SenderEmployeeId { get; set; }
        public SupplierModel Supplier { get; set; } = null!;
        public EmployeeModel SenderEmployee { get; set; } = null!;
    }
}