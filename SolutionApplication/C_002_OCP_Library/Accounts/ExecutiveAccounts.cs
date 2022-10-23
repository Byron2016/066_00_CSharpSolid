using C_002_OCP_Library.Applicants;

namespace C_002_OCP_Library.Accounts
{
    class ExecutiveAccounts : IAccounts
    {
        public EmployeeModel Create(IApplicantModel person)
        {
            EmployeeModel output = new EmployeeModel();

            output.FirstName = person.FirstName;
            output.LastName = person.LastName;
            output.EmailAddress = $"{person.FirstName}{person.LastName}@acmeEXECUTIVE.com";

            output.isManager = true;
            output.isExecutive = true;

            return output;
        }
    }
}
