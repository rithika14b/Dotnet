using System;

namespace Assessment1
{
    internal class StoreEmployee
    {
        struct DOB
        {
            public int date;
            public int month;
            public int year;
        }
        struct Employee
        {
            public string name;
            public DOB birth;
        }
        class Employeedetail {
             public static void Main()
            {
                Console.WriteLine("Enter the number of employee");
                int n = int.Parse(Console.ReadLine());
                Employee[] emp = new Employee[n];


                for (int i = 0; i < n; i++)
                {
                    Console.WriteLine("Enter employee details" + (i + 1));
                    Console.Write("Enter Name of employee : ");
                    emp[i].name = Console.ReadLine();

                    Console.WriteLine("Enter birth date of employee");
                    emp[i].birth.date = int.Parse(Console.ReadLine());

                    Console.WriteLine("Enter birth month of employee");
                    emp[i].birth.month = int.Parse(Console.ReadLine());

                    Console.WriteLine("Enter birth year of employee");
                    emp[i].birth.year = int.Parse(Console.ReadLine());

                }
                    Console.WriteLine("<---employee details--->");

                for (int i = 0; i < n; i++)
                {
                    Console.WriteLine("Employee name : " + emp[i].name);
                    Console.WriteLine("Employee dateofbirth" + emp[i].birth.date + emp[i].birth.month + emp[i].birth.year);
                }
            }


        }
    } }
