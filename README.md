<div>
	<div>
		<img src=https://raw.githubusercontent.com/Byron2016/00_forImages/main/images/Logo_01_00.png align=left alt=MyLogo width=200>
	</div>
	&nbsp;
	<div>
		<h1>066_00_CSharpSolid</h1>
	</div>
</div>

&nbsp;

## Project Description

**SolutionApplication** is a practice of **Design Patterns** the use of **SOLID principles**. following IamTimCorey's tutorial.</br> 
&nbsp;
    - [Design Patterns: Single Responsibility Principle Explained Practically in C# (The S in SOLID)](https://www.youtube.com/watch?v=5RwhyZnVRS8&list=PLLWMQd6PeGY3ob0Ga6vn1czFZfW6e-FLr&index=2).</br>
    - [Design Patterns: Open Closed Principle Explained Practically in C# (The O in SOLID)](https://www.youtube.com/watch?v=VFlk43QGEgc&list=PLLWMQd6PeGY3ob0Ga6vn1czFZfW6e-FLr&index=3).</br>
    - [Design Patterns: Liskov Substitution Principle Explained Practically in C# (The L in SOLID)](https://www.youtube.com/watch?v=-3UXq2krhyw&list=PLLWMQd6PeGY3ob0Ga6vn1czFZfW6e-FLr&index=4).</br>
    - [Design Patterns: Interface Segregation Principle Explained Practically in C# (The I in SOLID)](https://www.youtube.com/watch?v=y1JiMGP51NE&list=PLLWMQd6PeGY3ob0Ga6vn1czFZfW6e-FLr&index=5).</br>
    - [Design Patterns: Dependency Inversion Principle Explained Practically in C# (The D in SOLID)](https://www.youtube.com/watch?v=NnZZMkwI6KI&list=PLLWMQd6PeGY3ob0Ga6vn1czFZfW6e-FLr&index=6).</br>
&nbsp;

## Steps
1. Create a new Blanck Solution:
	- Solution Name: SolutionApplication

2. Single Responsibility Principle
    - Create new projects with these caracteristics:
        - Project Type: Console App
	    - Projects Name: C_001_SRP
        - Framework: .NET 6.0 (Long-term support) 
        - Do not use top-level-statements: true

    - We have this initial code:
		```c#
		namespace C_001_SRP
		{
			internal class Program
			{
				static void Main(string[] args)
				{
					Console.WriteLine("Bienvenido a mi aplicación");
		
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
						Console.ReadLine();
						return;
					}
		
					if (string.IsNullOrEmpty(user.LastName))
					{
						Console.WriteLine("No ha proporcionado un apellido inválido!");
						Console.ReadLine();
						return;
					}
		
					// Crear un nombre de usuario para la persona.
					Console.WriteLine($"Su nombre de usuario es {user.FirstName.Substring(0, 1)}{user.LastName}");
					Console.ReadLine();
				}
			}
		}
		```
    - Create a class to manage messages:
		```c#
		namespace C_001_SRP
		{
			public class StandardMessages
			{
				public static void WelcomeMessage()
				{
					Console.WriteLine("Bienvenido a mi aplicación");
				}
		
				public static void EndApplication()
				{
					Console.ReadLine();
				}
			}
		}
		```

    - Modify program.cs to use StandardMessages class:
		```c#
		namespace C_001_SRP
		{
			internal class Program
			{
				static void Main(string[] args)
				{
					StandardMessages.WelcomeMessage();
		
					....
		
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
		```