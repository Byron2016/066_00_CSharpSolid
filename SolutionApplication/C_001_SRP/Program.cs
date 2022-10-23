using System;

namespace C_001_SRP
{
    internal class Program
    {
        static void Main(string[] args)
        {
            StandardMessages.WelcomeMessage();

            // Preguntar por información del usuario
            Person user = new Person();

            Console.WriteLine("Cuál es su primer nombre: ");
            user.FirstName = Console.ReadLine();

            Console.WriteLine("Cuál es su apellido: ");
            user.LastName = Console.ReadLine();

            // Chequear que nombre y apellido son válidos.
            if (string.IsNullOrEmpty(user.FirstName))
            {
                Console.WriteLine("No ha proporcionado un nombre inválido!");
                StandardMessages.EndApplication();
                return;
            }

            if (string.IsNullOrEmpty(user.LastName))
            {
                Console.WriteLine("No ha proporcionado un apellido inválido!");
                StandardMessages.EndApplication();
                return;
            }

            // Crear un nombre de usuario para la persona.
            Console.WriteLine($"Su nombre de usuario es {user.FirstName.Substring(0, 1)}{user.LastName}");
            StandardMessages.EndApplication();
        }
    }
}