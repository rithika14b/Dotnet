using System;
using System.Collections.Generic;

namespace Assessment1
{
internal class Employee
    {
        public int Id;
        public string Name;
        public string Department;
        public double Salary;
    }

    class Program
    {
        static void Main()
        {
            List<Employee> employees = new List<Employee>();
            int choice;

            do
            {
                Console.WriteLine("<-- Employee Management Menu -->");
                Console.WriteLine("1. Add New Employee");
                Console.WriteLine("2. View All Employees");
                Console.WriteLine("3. Search Employee by ID");
                Console.WriteLine("4. Update Employee Details");
                Console.WriteLine("5. Delete Employee");
                Console.WriteLine("6. Exit");
                Console.WriteLine("====================================");
                Console.WriteLine("Enter your choice: ");

                choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        Employee emp = new Employee();
                        Console.Write("Enter ID: ");
                        emp.Id = Convert.ToInt32(Console.ReadLine());

                        Console.Write("Enter Name: ");
                        emp.Name = Console.ReadLine();

                        Console.Write("Enter Department: ");
                        emp.Department = Console.ReadLine();

                        Console.Write("Enter Salary: ");
                        emp.Salary = Convert.ToDouble(Console.ReadLine());

                        employees.Add(emp);
                        Console.WriteLine("Employee added successfully!");
                        break;

                    case 2:
                        if (employees.Count == 0)
                        {
                            Console.WriteLine("No employees found.");
                        }
                        else
                        {
                            foreach (var e in employees)
                            {
                                Console.WriteLine($"ID: {e.Id}, Name: {e.Name}, Dept: {e.Department}, Salary: {e.Salary}");
                            }
                        }
                        break;

                    case 3:
                        Console.Write("Enter ID to search: ");
                        int searchId = Convert.ToInt32(Console.ReadLine());
                        var found = employees.Find(e => e.Id == searchId);

                        if (found != null)
                        {
                            Console.WriteLine($"ID: {found.Id}, Name: {found.Name}, Dept: {found.Department}, Salary: {found.Salary}");
                        }
                        else
                        {
                            Console.WriteLine("Employee not found.");
                        }
                        break;

                    case 4:
                        Console.Write("Enter ID to update: ");
                        int updateId = Convert.ToInt32(Console.ReadLine());
                        var empToUpdate = employees.Find(e => e.Id == updateId);

                        if (empToUpdate != null)
                        {
                            Console.Write("Enter New Name: ");
                            empToUpdate.Name = Console.ReadLine();

                            Console.Write("Enter New Department: ");
                            empToUpdate.Department = Console.ReadLine();

                            Console.Write("Enter New Salary: ");
                            empToUpdate.Salary = Convert.ToDouble(Console.ReadLine());

                            Console.WriteLine("Employee updated successfully!");
                        }
                        else
                        {
                            Console.WriteLine("Employee not found.");
                        }
                        break;

                    case 5:
                        Console.Write("Enter ID to delete: ");
                        int deleteId = Convert.ToInt32(Console.ReadLine());
                        var empToDelete = employees.Find(e => e.Id == deleteId);

                        if (empToDelete != null)
                        {
                            employees.Remove(empToDelete);
                            Console.WriteLine("Employee deleted successfully!");
                        }
                        else
                        {
                            Console.WriteLine("Employee not found.");
                        }
                        break;

                    case 6:
                        Console.WriteLine("Exiting program...");
                        break;

                    default:
                        Console.WriteLine("Invalid choice. Try again.");
                        break;
                }

            } while (choice != 6);
        }
    }
}

