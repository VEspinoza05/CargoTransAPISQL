namespace CargoTransAPISQL.Models
{
    public class EmployeeModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Role { get; set; } = string.Empty;
        public DateTime StartDate { get; set; }
        public string Status { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string ContractType { get; set; } = string.Empty;
        public string Shift { get; set; } = string.Empty;
        public ICollection<VehicleModel> Vehicles { get; set; } = new List<VehicleModel>();
        public ICollection<PurchaseModel> Purchases { get; set; } = new List<PurchaseModel>();
    }
}