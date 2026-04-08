using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assessment2
{
    internal class Exceptioncheckno
    {
        static void CheckNumber(int num)
        {
            if (num < 0)
            {
                throw new Exception("Number cannot be negative!");
            }
            else
            {
                Console.WriteLine("Number is valid: " + num);
            }
        }
        static void Main()
        {
            try
            {
                Console.Write("Enter an integer: ");
                int number = Convert.ToInt32(Console.ReadLine());

                CheckNumber(number);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception caught: " + ex.Message);
            }
        }
    }
}
