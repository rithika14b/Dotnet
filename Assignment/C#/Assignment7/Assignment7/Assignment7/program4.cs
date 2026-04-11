using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using TravelConcessionLibrary;

namespace Assignment7
{
    
        class Program4
        {
            const double TotalFare = 500;   // Constant Fare

            static void Main(string[] args)
            {
                string Name;
                int Age;

                Console.WriteLine("Enter Passenger Name:");
                Name = Console.ReadLine();

                Console.WriteLine("Enter Passenger Age:");
                Age = Convert.ToInt32(Console.ReadLine());

                Concession concession = new Concession();
                string result = concession.CalculateConcession(Age, TotalFare);

                Console.WriteLine("\nPassenger Name: " + Name);
                Console.WriteLine(result);

                Console.ReadLine();
            }
        }
    
}
