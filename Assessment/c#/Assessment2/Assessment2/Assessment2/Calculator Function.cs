using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assessment2
{
    internal class Calculator_Function
    {
        public delegate int Calculator(int a, int b);
        public static int Add(int a, int b)
            {
                return a + b;
            }
            public static int Sub(int a, int b)
            {
                return a - b;
            }
            public static int Multiply(int a, int b)
            {
                return a * b;
            }
            public static void Calculate(string operation, int x, int y, Calculator calc)
            {
                int result = calc(x, y);
                Console.WriteLine(operation + " : " + result);
            }

            static void Main()
            {
                Console.Write("Enter first number: ");
                int num1 = Convert.ToInt32(Console.ReadLine());

                Console.Write("Enter second number: ");
                int num2 = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("\nCalculator Results:");

                Calculate("Addition", num1, num2, Add);
                Calculate("Subtraction", num1, num2, Sub);
                Calculate("Multiply", num1, num2, Multiply);
            }
        
    }
}
