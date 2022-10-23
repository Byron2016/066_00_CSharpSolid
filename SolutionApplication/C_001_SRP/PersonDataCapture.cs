namespace C_001_SRP
{
    public class PersonDataCapture
    {
        public static Person Capture()
        {
            // Preguntar por información del usuario
            Person output = new Person();

            Console.WriteLine("Cuál es su primer nombre: ");
            output.FirstName = Console.ReadLine();

            Console.WriteLine("Cuál es su apellido: ");
            output.LastName = Console.ReadLine();

            return output;
        }
    }
}
