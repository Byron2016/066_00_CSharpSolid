using C_002_OCP_Library.Applicants;

namespace C_002_OCP_Library.Accounts
{
    public interface IAccounts
    {
        EmployeeModel Create(IApplicantModel person);
    }
}
