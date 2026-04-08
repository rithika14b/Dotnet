using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assessment2
{
    abstract class Student
    {
        public string Name;
        public int StudentId;
        public double Grade;


        public abstract bool IsPassed(double grade);
    }


    class Undergraduate : Student
    {
        public override bool IsPassed(double grade)
        {
            return grade > 70.0;
        }
    }


    class Graduate : Student
    {
        public override bool IsPassed(double grade)
        {
            return grade > 80.0;
        }
    }

    class studentgrade
    {
        static void Main()
        {
            Console.Write("Enter Student Type (UG for Undergraduate / G for Graduate):");
            string type = Console.ReadLine();

            Console.Write("Enter Name:");
            string name = Console.ReadLine();

            Console.Write("Enter Student ID:");
            int id = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter Grade:");
            double grade = Convert.ToDouble(Console.ReadLine());

            if (type.ToUpper() == "UG")
            {
                Undergraduate ug = new Undergraduate();
                ug.Name = name;
                ug.StudentId = id;
                ug.Grade = grade;

                Console.WriteLine("\nUndergraduate Student Details:");
                Console.WriteLine("Name: " + ug.Name);
                Console.WriteLine("ID: " + ug.StudentId);
                Console.WriteLine("Grade: " + ug.Grade);
                Console.WriteLine("Passed: " + ug.IsPassed(ug.Grade));
            }
            else if (type.ToUpper() == "G")
            {
                Graduate g = new Graduate();
                g.Name = name;
                g.StudentId = id;
                g.Grade = grade;

                Console.WriteLine("\nGraduate Student Details:");
                Console.WriteLine("Name: " + g.Name);
                Console.WriteLine("ID: " + g.StudentId);
                Console.WriteLine("Grade: " + g.Grade);
                Console.WriteLine("Passed: " + g.IsPassed(g.Grade));
            }
            else
            {
                Console.WriteLine("Invalid Student Type!");
            }
        }
    }
}
    

