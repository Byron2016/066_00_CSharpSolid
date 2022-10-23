namespace C_002_OCP_Library
{
    public class Accounts
    {
        public EmployeeModel Create(PersonModel person)
        {
            EmployeeModel output = new EmployeeModel();

            output.FirstName = person.FirstName;
            output.LastName = person.LastName;
            output.EmailAddress = $"{person.FirstName.Substring(0, 1)}{person.LastName}@acme.com";

            //if(person.TypeOfEmployee == EmployeeType.Manager)
            //{
            //    output.isManager = true;
            //}

            switch (person.TypeOfEmployee)
            {
                case EmployeeType.Staff:
                    break;
                case EmployeeType.Manager:
                    output.isManager = true;
                    break;
                case EmployeeType.Executive:
                    output.isManager = true;
                    output.isExecutive = true;
                    break;
                default:
                    break;
            }

            return output;
        }
    }
}
