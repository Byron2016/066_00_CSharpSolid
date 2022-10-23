using C_003_LSP_Library.Interfaces;

namespace C_003_LSP_Library.Base
{
    public abstract class BaseEmployee : IEmployee
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public decimal Salary { get; set; }

        public virtual void CalculatePerHourRate(int rank)
        {
            decimal baseAccount = 12.50M;
            Salary = baseAccount + (rank * 2);
        }
    }
}
