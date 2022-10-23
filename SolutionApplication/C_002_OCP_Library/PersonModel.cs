namespace C_002_OCP_Library
{
    public class PersonModel
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public EmployeeType TypeOfEmployee { get; set; } = EmployeeType.Staff;
    }
}
