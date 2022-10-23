namespace C_002_OCP_Library
{
    public class EmployeeModel
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? EmailAddress { get; set; }
        public bool isManager { get; set; } = false;   // Queda
        public bool isExecutive { get; set; } = false; // Queda
    }
}
