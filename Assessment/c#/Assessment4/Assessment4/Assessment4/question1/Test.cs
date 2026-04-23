using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assessment4.question1
{
    internal class Test
    {
        static void Main(string[] args)
        {
            Console.Write("Enter first distance in kilometers: ");
            int km1 = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter second distance in kilometers: ");
            int km2 = Convert.ToInt32(Console.ReadLine());

            Distance d1 = new Distance(km1);
            Distance d2 = new Distance(km2);

            Distance d3 = Distance.Add(d1, d2);
 
            Console.WriteLine("\nResult after adding two distances:");
            d3.Display();
        }
    }
}
