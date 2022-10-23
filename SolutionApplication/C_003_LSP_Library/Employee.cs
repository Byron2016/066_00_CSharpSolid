namespace C_003_LSP_Library
{
    public class Employee
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public Employee Manager { get; set; }
        public decimal Salary { get; set; }

        public virtual void AssignManager(Employee manager)
        {
            //Simulate doing other task here - otherwise, this sould be
            // a property set statement, not a method.
            Manager = manager;
        }

        public virtual void CalculatePerHourRate(int rank)
        {
            decimal baseAccount = 12.50M;
            Salary = baseAccount + (rank * 2);
        }

    }
}
