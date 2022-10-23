using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_001_SRP
{
    public class PersonValidator
    {
        public static bool Validate(Person person)
        {
            // Chequear que nombre y apellido son válidos.
            if (string.IsNullOrEmpty(person.FirstName))
            {
                StandardMessages.DisplayValidationError("nombre");
                return false;
            }

            if (string.IsNullOrEmpty(person.LastName))
            {
                StandardMessages.DisplayValidationError("apellido");
                return false;
            }

            return true;
        }
    }
}
