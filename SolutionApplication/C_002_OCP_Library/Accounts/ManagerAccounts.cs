using C_002_OCP_Library.Applicants;

namespace C_002_OCP_Library.Accounts
{
    public class ManagerAccounts : IAccounts
    {
        public EmployeeModel Create(IApplicantModel person)
        {
            EmployeeModel output = new EmployeeModel();

            output.FirstName = person.FirstName;
            output.LastName = person.LastName;
            output.EmailAddress = $"{person.FirstName.Substring(0, 1)}{person.LastName}@acmeMANAGER.com";

            output.isManager = true;

            return output;
        }
    }
}
