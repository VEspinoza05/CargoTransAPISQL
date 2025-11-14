namespace CargoTransAPISQL.DTOs.Employee
{
    public class EmployeeDTO
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public int RoleId { get; set; }
        public string RoleName { get; set; } = string.Empty;
        public DateTime StartDate { get; set; }
        public string Status { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string ContractType { get; set; } = string.Empty;
        public string Shift { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
    }
}