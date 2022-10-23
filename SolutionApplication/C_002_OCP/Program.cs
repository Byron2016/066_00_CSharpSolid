using C_002_OCP_Library;

namespace C_002_OCP
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<PersonModel> applicants = new List<PersonModel>
            {
                new PersonModel{ FirstName = "Tim", LastName = "Corey" },
                new PersonModel{ FirstName = "Sue", LastName = "Store", TypeOfEmployee = EmployeeType.Manager },
                new PersonModel{ FirstName = "Nancy", LastName = "Roman", TypeOfEmployee = EmployeeType.Executive }
            };

            List<EmployeeModel> employees = new List<EmployeeModel>();
            Accounts accountProcessor = new Accounts();

            foreach (var person in applicants)
            {
                employees.Add(accountProcessor.Create(person));
            }

            foreach (var emp in employees)
            {
                Console.WriteLine($"{emp.FirstName} {emp.LastName}: {emp.EmailAddress} IsManager: {emp.isManager} IsExecutive: {emp.isExecutive}");
            }

            Console.ReadLine();
        }
    }
}