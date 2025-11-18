namespace CargoTransAPISQL.Models
{
    public class VehicleModel
    {
        public int Id { get; set; }
        public string VehicleLicensePlate { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty;
        public string Capacity { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
        public int? DriverId { get; set; }
        public DateTime EnterDate { get; set; }
        public string Brand { get; set; } = string.Empty;
        public string Model { get; set; } = string.Empty;
        public string Serial { get; set; } = string.Empty;
        public double? Latitude { get; set; }
        public double? Longitude { get; set; }
        public ICollection<PackageModel> Packages { get; set; } = new List<PackageModel>();
        public EmployeeModel? Driver { get; set; }
    }
}