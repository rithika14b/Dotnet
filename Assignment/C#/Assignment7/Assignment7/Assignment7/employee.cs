using System;
using System.Collections.Generic;
using System.Linq;

namespace Assignment7
    {
    //third code
        class Employee
        {
            public int EmpId { get; set; }
            public string EmpName { get; set; }
            public string EmpCity { get; set; }
            public double EmpSalary { get; set; }
        }

        class Program2
        {
            static void Main(string[] args)
            {
               
                List<Employee> employees = new List<Employee>()
            {
                new Employee { EmpId = 101, EmpName = "Ramesh", EmpCity = "Bangalore", EmpSalary = 50000 },
                new Employee { EmpId = 102, EmpName = "Suresh", EmpCity = "Chennai", EmpSalary = 42000 },
                new Employee { EmpId = 103, EmpName = "Anita", EmpCity = "Bangalore", EmpSalary = 60000 },
                new Employee { EmpId = 104, EmpName = "Kiran", EmpCity = "Hyderabad", EmpSalary = 48000 },
                new Employee { EmpId = 105, EmpName = "Bhavya", EmpCity = "Bangalore", EmpSalary = 40000 }
            };

             
                Console.WriteLine("---- All Employees ----");
                DisplayEmployees(employees);

             
                Console.WriteLine("\n---- Employees with Salary > 45000 ----");
                var highSalary = employees.Where(e => e.EmpSalary > 45000);
                DisplayEmployees(highSalary);

            
                var bangaloreEmployees = employees
                    .Where(e => e.EmpCity.Equals("Bangalore", StringComparison.OrdinalIgnoreCase));
                DisplayEmployees(bangaloreEmployees);

                
                Console.WriteLine("\n---- Employees Sorted by Name (Ascending) ----");
                var sortedByName = employees.OrderBy(e => e.EmpName);
                DisplayEmployees(sortedByName);

                Console.ReadLine();
            }

          
            static void DisplayEmployees(IEnumerable<Employee> empList)
            {
                foreach (var emp in empList)
                {
                    Console.WriteLine(
                        $"ID: {emp.EmpId}, Name: {emp.EmpName}, City: {emp.EmpCity}, Salary: {emp.EmpSalary}");
                }
            }
        }
    }


