namespace C_002_OCP_Library
{
    public interface IApplicantModel
    {
        string? FirstName { get; set; }
        string? LastName { get; set; }
        IAccounts AccountProcessor { get; set; }
    }
}
