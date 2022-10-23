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
		
	- Manage messages:
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

    - Capture person Data:
        - Create a class to capture person Data:
		    ```c#
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
		    ```
		- Modify program.cs to use PersonDataCapture class:
			```c#
			namespace C_001_SRP
			{
				internal class Program
				{
					static void Main(string[] args)
					{
						StandardMessages.WelcomeMessage();
						....
			
						Person user = PersonDataCapture.Capture();
						
						// Chequear que nombre y apellido son válidos.
						....
					}
				}
			}
			```
			
    - Manage person validation:
        - Add a new method to display validation error messages:
		    ```c#
			namespace C_001_SRP
			{
				public class StandardMessages
				{
					....
			
					public static void DisplayValidationError(string fielName)
					{
						Console.WriteLine($"No ha proporcionado un {fielName} válido!");
					}
				}
			}
		    ```
			
        - Create a class to manage person validations:
		    ```c#
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
		    ```
		- Modify program.cs to use PersonValidator class:
			```c#
			namespace C_001_SRP
			{
				internal class Program
				{
					static void Main(string[] args)
					{
						....
			
						// Preguntar por información del usuario y Chequear que nombre y apellido son válidos.
						Person user = PersonDataCapture.Capture();
			
						bool isUserValid = PersonValidator.Validate(user);
			
						if (!isUserValid)
						{
							StandardMessages.EndApplication();
							return;
						}
						....
					}
				}
			}
			```
			
    - Account generator:
        - Create a class to generate accounts:
		    ```c#
			namespace C_001_SRP
			{
				public class AccountGenerator
				{
					public static void CreateAccount(Person user)
					{
						// Crear un nombre de usuario para la persona.
						Console.WriteLine($"Su nombre de usuario es {user.FirstName.Substring(0, 1)}{user.LastName}");
					}
				}
			}
		    ```
		- Modify program.cs to use AccountGenerator class:
			```c#
			namespace C_001_SRP
			{
				internal class Program
				{
					static void Main(string[] args)
					{
						....
			
						// Crear un nombre de usuario para la persona.
						AccountGenerator.CreateAccount(user);
						StandardMessages.EndApplication();
					}
				}
			}
			```
			
    - Add close messages:
        - Add close message to EndApplication method:
		    ```c#
			namespace C_001_SRP
			{
				public class StandardMessages
				{
					....
			
					public static void EndApplication()
					{
						Console.WriteLine("Presione enter para cerrar...");
						Console.ReadLine();
					}
			
					....
				}
			}
		    ```

    - We have this final code:
		```c#
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
		```

3. Open Closed Principle
    - Create new projects with these caracteristics:
        - Project Type: Console App
	    - Projects Name: C_002_OCP
        - Framework: .NET 6.0 (Long-term support) 
        - Do not use top-level-statements: true

    - Create new projects with these caracteristics:
        - Project Type: Class Library
	    - Projects Name: C_002_OCP_Library
        - Framework: .NET 6.0 (Long-term support) 

    - We have this initial code:
        - Into C_002_OCP_Library project
			- PersonModel
				```c#
				namespace C_002_OCP_Library
				{
					public class PersonModel
					{
						public string? FirstName { get; set; }
						public string? LastName { get; set; }
					}
				}
				```
			- EmployeeModel
				```c#
				namespace C_002_OCP_Library
				{
					public class EmployeeModel
					{
						public string? FirstName { get; set; }
						public string? LastName { get; set; }
						public string? EmailAddress { get; set; }
					}
				}
				```
			- Accounts
				```c#
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
				
							return output;
						}
					}
				}
				```
				
        - Into C_002_OCP project
		    ```c#
			using C_002_OCP_Library;
			
			namespace C_002_OCP
			{
				public class Program
				{
					static void Main(string[] args)
					{
						List<PersonModel> applicants = new List<PersonModel>
						{
							new PersonModel{ FirstName = "Tim", LastName = "Corey" },
							new PersonModel{ FirstName = "Sue", LastName = "Store" },
							new PersonModel{ FirstName = "Nancy", LastName = "Roman" }
						};
			
						List<EmployeeModel> employees = new List<EmployeeModel>();
						Accounts accountProcessor = new Accounts();
			
						foreach (var person in applicants)
						{
							employees.Add(accountProcessor.Create(person));
						}
			
						foreach (var emp in employees)
						{
							Console.WriteLine($"{emp.FirstName} {emp.LastName}: {emp.EmailAddress}");
						}
			
						Console.ReadLine();
					}
				}
			}
		    ```

    - The wrong way: We are going to add two new types of employee: manager and executive.
        - Into C_002_OCP_Library project
			- EmployeeModel
				```c#
				namespace C_002_OCP_Library
				{
					public class EmployeeModel
					{
						....
						public bool isManager { get; set; } = false;
						public bool isExecutive { get; set; } = false;
					}
				}
				```
			- EmployeeType
				```c#
				namespace C_002_OCP_Library
				{
					public enum EmployeeType
					{
						Staff,
						Manager,
						Executive
					}
				}
				```
			- PersonModel
				```c#
				namespace C_002_OCP_Library
				{
					public class PersonModel
					{
						....
						public EmployeeType TypeOfEmployee { get; set; } = EmployeeType.Staff;
					}
				}
				```

			- Accounts
				```c#
				namespace C_002_OCP_Library
				{
					public class Accounts
					{
						public EmployeeModel Create(PersonModel person)
						{
							....
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
				```
				
        - Into C_002_OCP project
		    ```c#
			using C_002_OCP_Library;
			
			namespace C_002_OCP
			{
				public class Program
				{
					static void Main(string[] args)
					{
						List<PersonModel> applicants = new List<PersonModel>
						{
							new PersonModel{ FirstName = "Tim", LastName = "Corey" },
							new PersonModel{ FirstName = "Sue", LastName = "Store", TypeOfEmployee = EmployeeType.Manager },
							new PersonModel{ FirstName = "Nancy", LastName = "Roman", TypeOfEmployee = EmployeeType.Executive }
						};
			
						....
			
						foreach (var emp in employees)
						{
							Console.WriteLine($"{emp.FirstName} {emp.LastName}: {emp.EmailAddress} IsManager: { emp.isManager } IsExecutive: { emp.isExecutive }");
						}
			
						....
					}
				}
			}
		    ```
			
    - The right way: We are going to add two new types of employee: manager and executive.
        - Return all to initial state.
        - Into C_002_OCP_Library project
			- EmployeeModel
				```c#
				namespace C_002_OCP_Library
				{
					public class EmployeeModel
					{
						....
						public bool isManager { get; set; } = false;
						public bool isExecutive { get; set; } = false;
					}
				}
				```
				
        - Into C_002_OCP project
		    ```c#
			using C_002_OCP_Library;
			
			namespace C_002_OCP
			{
				public class Program
				{
					static void Main(string[] args)
					{
						List<PersonModel> applicants = new List<PersonModel>
						{
							new PersonModel{ FirstName = "Tim", LastName = "Corey" },
							new PersonModel{ FirstName = "Sue", LastName = "Store" },
							new PersonModel{ FirstName = "Nancy", LastName = "Roman" }
						};
			
						....
			
						foreach (var emp in employees)
						{
							Console.WriteLine($"{emp.FirstName} {emp.LastName}: {emp.EmailAddress} IsManager: { emp.isManager } IsExecutive: { emp.isExecutive }");
						}
			
						....
					}
				}
			}
		    ```
			
		- Do not tie yourself directly to classes.
			- Into C_002_OCP_Library project
				- IApplicantModel
					```c#
					namespace C_002_OCP_Library
					{
						public interface IApplicantModel
						{
							string? FirstName { get; set; }
							string? LastName { get; set; }
							IAccounts AccountProcessor { get; set; }
						}
					}
					```
				- PersonModel
					```c#
					namespace C_002_OCP_Library
					{
						public class PersonModel : IApplicantModel
						{
							....
							public IAccounts AccountProcessor { get; set; } = new Accounts();
						}
					}
					```
				- IAccounts
					```c#
					namespace C_002_OCP_Library
					{
						public interface IAccounts
						{
							EmployeeModel Create(IApplicantModel person);
						}
					}
					```
				- Accounts
					```c#
					namespace C_002_OCP_Library
					{
						public class Accounts : IAccounts
						{
							public EmployeeModel Create(IApplicantModel person)
							{
								EmployeeModel output = new EmployeeModel();
					
								output.FirstName = person.FirstName;
								output.LastName = person.LastName;
								output.EmailAddress = $"{person.FirstName.Substring(0, 1)}{person.LastName}@acme.com";
					
								return output;
							}
						}
					}
					```
					
			- Into C_002_OCP project
				```c#
				using C_002_OCP_Library;
				
				namespace C_002_OCP
				{
					public class Program
					{
						static void Main(string[] args)
						{
							List<IApplicantModel> applicants = new List<IApplicantModel>
							{
								....
							};
				
							....
							// Accounts accountProcessor = new Accounts();
							foreach (var person in applicants)
							{
								employees.Add(person.AccountProcessor.Create(person));
							}
				
							foreach (var emp in employees)
							{
								Console.WriteLine($"{emp.FirstName} {emp.LastName}: {emp.EmailAddress} IsManager: { emp.isManager } IsExecutive: { emp.isExecutive }");
							}
				
							....
						}
					}
				}
				```
				
        - Define a Person like a manager.
			- Into C_002_OCP_Library project
				- ManagerAccounts
					```c#
					namespace C_002_OCP_Library
					{
						public class ManagerAccounts : IAccounts
						{
							public EmployeeModel Create(IApplicantModel person)
							{
								EmployeeModel output = new EmployeeModel();
					
								output.FirstName = person.FirstName;
								output.LastName = person.LastName;
								output.EmailAddress = $"{person.FirstName.Substring(0, 1)}{person.LastName}@acmeMANAGER.com";
					
								output.isManager = true;
					
								return output;
							}
						}
					}
					```
				- ManagerModel
					```c#
					namespace C_002_OCP_Library
					{
						public class ManagerModel : IApplicantModel
						{
							public string FirstName { get; set; }
							public string LastName { get; set; }
							public IAccounts AccountProcessor { get; set; } = new ManagerAccounts();
						}
					}
					```
					
			- Into C_002_OCP project
				```c#
				namespace C_002_OCP
				{
					public class Program
					{
						static void Main(string[] args)
						{
							List<IApplicantModel> applicants = new List<IApplicantModel>
							{
								....
								new ManagerModel{ FirstName = "Sue", LastName = "Store" },
								....
							};
							....
						}
					}
				}
				```
				
        - Define a Person like a executive.
			- Into C_002_OCP_Library project
				- ExecutiveAccounts
					```c#
					namespace C_002_OCP_Library
					{
						class ExecutiveAccounts : IAccounts
						{
							public EmployeeModel Create(IApplicantModel person)
							{
								EmployeeModel output = new EmployeeModel();
					
								output.FirstName = person.FirstName;
								output.LastName = person.LastName;
								output.EmailAddress = $"{person.FirstName}{person.LastName}@acmeEXECUTIVE.com";
					
								output.isManager = true;
								output.isExecutive = true;
					
								return output;
							}
						}
					}
					```
				- ExecutiveModel
					```c#
					namespace C_002_OCP_Library
					{
						public class ExecutiveModel : IApplicantModel
						{
							public string FirstName { get; set; }
							public string LastName { get; set; }
							public IAccounts AccountProcessor { get; set; } = new ExecutiveAccounts();
						}
					}
					```
					
			- Into C_002_OCP project
				```c#
				namespace C_002_OCP
				{
					public class Program
					{
						static void Main(string[] args)
						{
							List<IApplicantModel> applicants = new List<IApplicantModel>
							{
								....
								new ManagerModel{ FirstName = "Sue", LastName = "Store" },
								new ExecutiveModel{ FirstName = "Nancy", LastName = "Roman" }
							};
							....
						}
					}
				}
				```
				
    - Diferences between wrong and right way
		- With wrong way we have to modified
			- Programs
			- Account
			- EmployeeModel
			- EmployeeType
			- PersonModel
			
		- With right way we have to modified
			- Programs
			- IAccounts
			- Accounts
			- ManagerAccounts
			- EmployeeModel
			- IApplicantModel
			- PersonModel
			- ManagerModel
			
    - Order into folders
		```
		SolutionApplication.DTOs
		└─── 002_OCP 
			│
			└─── C_002_OCP_Library
				│
				└─── Accounts
				│	│
				│	└─── Accounts.cs
				│	│
				│	└─── ExecutiveAccounts.cs
				│	│
				│	└─── IAccounts.cs
				│	│
				│	└─── ManagerAccounts.cs
				│
				└─── Applicants
					│
					└─── ExecutiveModel.cs
					│
					└─── IApplicantModel.cs
					│
					└─── ManagerModel.cs
					│
					└─── PersonModel.cs
	
		```
		
4. Liskov Substitution Principle
    - Create new projects with these caracteristics:
        - Project Type: Console App
	    - Projects Name: C_003_LSP
        - Framework: .NET 6.0 (Long-term support) 
        - Do not use top-level-statements: true

    - Create new projects with these caracteristics:
        - Project Type: Class Library
	    - Projects Name: C_003_LSP_Library
        - Framework: .NET 6.0 (Long-term support) 
		
	- Definition: 
		- If S is a subtype of T then objects of type T may be replaced with objects of type S without breaking the program. Covariance, contravariance, preconditions, post conditions
			- Coviariance talks about the return type of a method. So it´s saying if you have return type that returned type can´t change.
			- Contravariance talks about the input type
			- Pre conditions you cannot strenghten them. 
			- Post conditions 
		- NOTE: The inicial code example breaks this principle because we can not remplace into Program class
			- From 
				```c#
				Employee emp = new Employee();
				```
			- To
				```c#
				Employee emp = new CEO();
				```
				</br>
			It brokes application because CEO does not have a manager. 
			
    - We have this initial code:
        - Into C_003_LSP_Library project
			- Employee
				```c#
				namespace C_003_LSP_Library
				{
					public class Employee
					{
						public string FirstName { get; set; }
						public string LastName { get; set; }
				
						public Employee Manager { get; set; }
						public decimal Salary { get; set; }
				
						public virtual void AssignManager(Employee manager)
						{
							//Simulate doing other task here - otherwise, this sould be
							// a property set statement, not a method.
							Manager = manager;
						}
				
						public virtual void CalculatePerHourRate(int rank)
						{
							decimal baseAccount = 12.50M;
							Salary = baseAccount + (rank * 2);
						}
				
					}
				}
				```
			- Manager
				```c#
				namespace C_003_LSP_Library
				{
					public class Manager : Employee
					{
						public override void CalculatePerHourRate(int rank)
						{
							decimal baseAmount = 19.75M;
							Salary = baseAmount + (rank * 4);
						}
				
						public void GeneratePerfomanceReview()
						{
							// Simulate reviewing a direct report
							Console.WriteLine("I'm reviewing a direct report's performance.");
						}
					}
				}
				```
			- CEO
				```c#
				namespace C_003_LSP_Library
				{
					public class CEO : Employee
					{
						public override void CalculatePerHourRate(int rank)
						{
							decimal baseAmount = 150M;
							Salary = baseAmount * rank;
						}
				
						public override void AssignManager(Employee manager)
						{
							throw new InvalidOperationException("The CEO has no manager");
						}
				
						public void GeneratePerfomanceReview()
						{
							// Simulate reviewing a direct report
							Console.WriteLine("I'm reviewing a direct report's performance.");
						}
				
						public void FireSomeone()
						{
							// Simulate firing someone
							Console.WriteLine("You're fired!");
						}
					}
				}
				```
        - Into C_003_LSP project
			- Program
				```c#
				using C_003_LSP_Library;
				
				namespace C_003_LSP
				{
					public class Program
					{
						static void Main(string[] args)
						{
							Manager accountingVP = new Manager();
				
							accountingVP.FirstName = "Emma";
							accountingVP.LastName = "Stone";
							accountingVP.CalculatePerHourRate(4);
				
							// Employee emp = new Employee();
							// Employee emp = new Manager();
							Employee emp = new CEO();  //Con este da error, CEO no tiene manager.
				
							emp.FirstName = "Tim";
							emp.LastName = "Corey";
							emp.AssignManager(accountingVP);
							emp.CalculatePerHourRate(2);
				
							Console.WriteLine($"{emp.FirstName}'s salary is ${emp.Salary}/hour.");
				
							Console.ReadLine();
						}
					}
				}
				```
				
    - Become a LSP compliace:
		- Into C_003_LSP_Library project
			- Interfaces
				- IEmployee
					```c#
					namespace C_003_LSP_Library.Interfaces
					{
						public interface IEmployee
						{
							string FirstName { get; set; }
							string LastName { get; set; }
							decimal Salary { get; set; }
					
							void CalculatePerHourRate(int rank);
						}
					}
					```
				- IManaged
					```c#
					namespace C_003_LSP_Library.Interfaces
					{
						public interface IManaged : IEmployee
						{
							IEmployee Manager { get; set; }
							void AssignManager(IEmployee manager);
						}
					}
					```
				- IManager
					```c#
					namespace C_003_LSP_Library.Interfaces
					{
						public interface IManager : IEmployee
						{
							void GeneratePerfomanceReview();
						}
					}
					```
			- Base classes
				- BaseEmployee
					```c#
					using C_003_LSP_Library.Interfaces;
					
					namespace C_003_LSP_Library.Base
					{
						public abstract class BaseEmployee : IEmployee
						{
							public string FirstName { get; set; }
							public string LastName { get; set; }
							public decimal Salary { get; set; }
					
							public virtual void CalculatePerHourRate(int rank)
							{
								decimal baseAccount = 12.50M;
								Salary = baseAccount + (rank * 2);
							}
						}
					}
					```
			- Implement interfaces and inheritance
				- Employee
					```c#
					namespace C_003_LSP_Library
					{
						public class Employee : BaseEmployee, IManaged
						{
							public IEmployee Manager { get; set; } = null;
					
							public void AssignManager(IEmployee manager)
							{
								//Simulate doing other task here - otherwise, this sould be
								// a property set statement, not a method.
								Manager = manager;
							}
						}
					}
					```
				- Manager
					```c#
					using C_003_LSP_Library.Interfaces;
					
					namespace C_003_LSP_Library
					{
						public class Manager : Employee, IManager
						{
							public override void CalculatePerHourRate(int rank)
							{
								decimal baseAmount = 19.75M;
								Salary = baseAmount + (rank * 4);
							}
					
							public void GeneratePerfomanceReview()
							{
								// Simulate reviewing a direct report
								Console.WriteLine("I'm reviewing a direct report's performance.");
							}
						}
					}
					```
				- CEO
					```c#
					using C_003_LSP_Library.Base;
					using C_003_LSP_Library.Interfaces;
					
					namespace C_003_LSP_Library
					{
						public class CEO : BaseEmployee, IManager
						{
							public override void CalculatePerHourRate(int rank)
							{
								decimal baseAmount = 150M;
								Salary = baseAmount * rank;
							}
					
							public void GeneratePerfomanceReview()
							{
								// Simulate reviewing a direct report
								Console.WriteLine("I'm reviewing a direct report's performance.");
							}
					
							public void FireSomeone()
							{
								// Simulate firing someone
								Console.WriteLine("You're fired!");
							}
						}
					}
					```
					
        - Into C_003_LSP project
			- Program
				```c#
				using C_003_LSP_Library;
				using C_003_LSP_Library.Base;
				using C_003_LSP_Library.Interfaces;
				
				namespace C_003_LSP
				{
					public class Program
					{
						static void Main(string[] args)
						{
							IManager accountingVP = new CEO();
							// IManager accountingVP = new Manager();
				
							....
				
							// Employee emp = new Employee();
							// Employee emp = new Manager();
							// Employee emp = new CEO();  //Con este da error, CEO no tiene manager.
							IManaged emp = new Employee();
				
							....
						}
					}
				}
				```