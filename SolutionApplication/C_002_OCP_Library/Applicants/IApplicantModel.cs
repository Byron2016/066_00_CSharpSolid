using C_002_OCP_Library.Accounts;

namespace C_002_OCP_Library.Applicants
{
    public interface IApplicantModel
    {
        string? FirstName { get; set; }
        string? LastName { get; set; }
        IAccounts AccountProcessor { get; set; }
    }
}
