using C_002_OCP_Library;
using C_002_OCP_Library.Applicants;

namespace C_002_OCP
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<IApplicantModel> applicants = new List<IApplicantModel>
            {
                new PersonModel{ FirstName = "Tim", LastName = "Corey" },
                new ManagerModel{ FirstName = "Sue", LastName = "Store" },
                new ExecutiveModel{ FirstName = "Nancy", LastName = "Roman" }
            };

            List<EmployeeModel> employees = new List<EmployeeModel>();
            // Accounts accountProcessor = new Accounts();

            foreach (var person in applicants)
            {
                employees.Add(person.AccountProcessor.Create(person));
            }

            foreach (var emp in employees)
            {
                Console.WriteLine($"{emp.FirstName} {emp.LastName}: {emp.EmailAddress} IsManager: {emp.isManager} IsExecutive: {emp.isExecutive}");
            }

            Console.ReadLine();
        }
    }
}