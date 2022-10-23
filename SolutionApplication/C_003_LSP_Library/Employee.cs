using C_003_LSP_Library.Base;
using C_003_LSP_Library.Interfaces;

namespace C_003_LSP_Library
{
    public class Employee : BaseEmployee, IManaged
    {
        public IEmployee Manager { get; set; } = null;

        public void AssignManager(IEmployee manager)
        {
            //Simulate doing other task here - otherwise, this sould be
            // a property set statement, not a method.
            Manager = manager;
        }
    }
}
