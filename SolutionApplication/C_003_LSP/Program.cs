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

            accountingVP.FirstName = "Emma";
            accountingVP.LastName = "Stone";
            accountingVP.CalculatePerHourRate(4);

            // Employee emp = new Employee();
            // Employee emp = new Manager();
            // Employee emp = new CEO();  //Con este da error, CEO no tiene manager.
            IManaged emp = new Employee();

            emp.FirstName = "Tim";
            emp.LastName = "Corey";
            emp.AssignManager(accountingVP);
            emp.CalculatePerHourRate(2);

            Console.WriteLine($"{emp.FirstName}'s salary is ${emp.Salary}/hour.");

            Console.ReadLine();
        }
    }
}