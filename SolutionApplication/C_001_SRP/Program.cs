using System;

namespace C_001_SRP
{
    internal class Program
    {
        static void Main(string[] args)
        {
            StandardMessages.WelcomeMessage();

            // Preguntar por información del usuario y Chequear que nombre y apellido son válidos.
            Person user = PersonDataCapture.Capture();

            bool isUserValid = PersonValidator.Validate(user);

            if (!isUserValid)
            {
                StandardMessages.EndApplication();
                return;
            }

            // Crear un nombre de usuario para la persona.
            AccountGenerator.CreateAccount(user);

            StandardMessages.EndApplication();
        }
    }
}