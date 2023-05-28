using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linq_dz
{
    class Firm
    {
        public string Name { get; set; }
        public DateTime FoundingDate { get; set; }
        public string BusinessProfile { get; set; }
        public string DirectorName { get; set; }
        public int EmployeeCount { get; set; }
        public string Address { get; set; }
        public List<Employee> Employees { get; set; }

        public Firm()
        {
            Employees = new List<Employee>();
        }

        public override string ToString()
        {
            return $"Name: {Name}, Founding Date: {FoundingDate}, Business Profile: {BusinessProfile}, Director Name: {DirectorName}, Employee Count: {EmployeeCount}, Address: {Address}\n";
        }
    }

    class Employee
    {
        public string FullName { get; set; }
        public string Position { get; set; }
        public string ContactPhone { get; set; }
        public string Email { get; set; }
        public decimal Salary { get; set; }

        public override string ToString()
        {
            return $"Full Name: {FullName}, Position: {Position}, Contact Phone: {ContactPhone}, Email: {Email}, Salary: {Salary}\n";
        }
    }

    internal class Task1_2_3
    {
        public static void task1()
        {
            List<Firm> firms = new List<Firm> {
                new Firm
                {
                    Name = "ABC Food",
                    FoundingDate = new DateTime(2010, 5, 12),
                    BusinessProfile = "Food",
                    DirectorName = "John Smith",
                    EmployeeCount = 50,
                    Address = "123 Main St, London",
                    Employees = new List<Employee>
                    {
                        new Employee { FullName = "John Doe", Position = "Manager", ContactPhone = "123456789", Email = "johndoe@example.com", Salary = 5000 },
                        new Employee { FullName = "Jane Smith", Position = "Clerk", ContactPhone = "987654321", Email = "janesmith@example.com", Salary = 3000 }
                    }
                },
                // Додайте інші фірми з працівниками
            };

            // Отримати список усіх працівників певної фірми
            string firmName = "ABC Food";
            var employeesOfFirm = firms.FirstOrDefault(firm => firm.Name == firmName)?.Employees;
            if (employeesOfFirm != null)
            {
                Console.WriteLine($"Employees of {firmName}:");
                Console.WriteLine(string.Join(" ", employeesOfFirm));
            }

            // Отримати список усіх працівників певної фірми, в яких заробітна плата більша заданої
            decimal minSalary = 4000;
            var employeesWithSalaryAboveMin = firms.SelectMany(firm => firm.Employees.Where(employee => employee.Salary > minSalary));
            Console.WriteLine($"Employees with salary above {minSalary}:");
            Console.WriteLine(string.Join(" ", employeesWithSalaryAboveMin));

            // Отримати список працівників усіх фірм, в яких є посада "Менеджер"
            var managerEmployees = firms.SelectMany(firm => firm.Employees.Where(employee => employee.Position == "Manager"));
            Console.WriteLine("Manager employees:");
            Console.WriteLine(string.Join(" ", managerEmployees));

            // Отримати список працівників, в яких телефон починається з "23"
            var employeesWithPhoneStartingWith = firms.SelectMany(firm => firm.Employees.Where(employee => employee.ContactPhone.StartsWith("23")));
            Console.WriteLine("Employees with phone starting with '23':");
            Console.WriteLine(string.Join(" ", employeesWithPhoneStartingWith));

            // Отримати список працівників, в яких Email починається з "di"
            var employeesWithEmailStartingWith = firms.SelectMany(firm => firm.Employees.Where(employee => employee.Email.StartsWith("di")));
            Console.WriteLine("Employees with email starting with 'di':");
            Console.WriteLine(string.Join(" ", employeesWithEmailStartingWith));

            // Отримати список працівників з ім'ям Lionel
            string employeeName = "Lionel";
            var employeesWithName = firms.SelectMany(firm => firm.Employees.Where(employee => employee.FullName.Contains(employeeName)));
            Console.WriteLine($"Employees with name '{employeeName}':");
            Console.WriteLine(string.Join(" ", employeesWithName));
        }
    }
}
