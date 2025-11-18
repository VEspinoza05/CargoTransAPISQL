namespace CargoTransAPISQL.DTOs.Package
{
    public class NewPackageDTO
    {
        public string Sender { get; set; } = string.Empty;
        public string Recipient { get; set; } = string.Empty;
        public double Weight { get; set; }
        public string Dimensions { get; set; } = string.Empty;
        public string ContentType { get; set; } = string.Empty;
        public string Observations { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
        public DateTime ReceptionDate { get; set; }
        public double? LatitudeDestination { get; set; }
        public double? LongitudeDestination { get; set; }

    }
}