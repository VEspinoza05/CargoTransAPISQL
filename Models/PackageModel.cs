namespace CargoTransAPISQL.Models
{
    public class PackageModel
    {
        public int Id { get; set; }
        public string Sender { get; set; } = string.Empty;
        public string Recipient { get; set; } = string.Empty;
        public string Weight { get; set; } = string.Empty;
        public string Dimensions { get; set; } = string.Empty;
        public string ContentType { get; set; } = string.Empty;
        public string Observations { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
        public DateTime ReceptionDate { get; set; }
        public DateTime DeliveryDate { get; set; }
        public int VehicleId { get; set; }
        public VehicleModel Vehicle { get; set; } = null!;
    }
}