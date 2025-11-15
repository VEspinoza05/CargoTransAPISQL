namespace CargoTransAPISQL.DTOs.Purchase
{
    public class UpdatePurchaseDTO
    {
        public int SupplierId { get; set; }
        public string ProductName { get; set; } = string.Empty;
        public string ProductDescription { get; set; } = string.Empty;
        public int Quantity { get; set; }
        public double UnitPrice { get; set; }
        public double Total { get; set; }
        public string Status { get; set; } = string.Empty;
    }
}