﻿using C_002_OCP_Library.Accounts;

namespace C_002_OCP_Library.Applicants
{
    public class PersonModel : IApplicantModel
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }

        public IAccounts AccountProcessor { get; set; } = new C_002_OCP_Library.Accounts.Accounts();
    }
}
