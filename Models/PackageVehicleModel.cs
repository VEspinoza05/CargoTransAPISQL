namespace CargoTransAPISQL.Models
{
    public class PackageVehicleModel
    {
        public int VehicleId { get; set; }
        public int PackageId { get; set; }
        public VehicleModel Vehicle { get; set; } = null!;
        public PackageModel Package { get; set; } = null!;
        
    }
}