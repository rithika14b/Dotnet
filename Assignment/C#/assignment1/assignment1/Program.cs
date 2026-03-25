using System;

namespace assignment1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            checkequal();
            positivenegative();
            operation();
            tables();
            sum();
        }

        public static void checkequal()
        {
            int num1, num2;
            num1 = Convert.ToInt32(Console.ReadLine());
            num2 = Convert.ToInt32(Console.ReadLine());
            if (num1 == num2)
            {
                Console.WriteLine(num1 + "and" + num2 + "are equal");
            }
            else
            {
                Console.WriteLine(num1 + "and" + num2 + "are not equal");
            }
        }


        public static void positivenegative()
        {
            int num;
            Console.Write("Enternumber :");
            num = Convert.ToInt32(Console.ReadLine());
            if (num > 0)
            {
                Console.WriteLine(num + " is positive number");
            }
            else if (num < 0)
            {
                Console.WriteLine(num + " is negative number");
            }
            else
            {
                Console.WriteLine(num + " is zero");
            }
        }



        public static void operation()
        {
            int num1, num2;
            Console.Write("Enter number 1:");
            num1 = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter number 2:");
            num2 = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Result:");

            Console.WriteLine(num1 + "+" + num2 + "=" + (num1 + num2));
            Console.WriteLine(num1 + "-" + num2 + "=" + (num1 - num2));
            Console.WriteLine(num1 + "*" + num2 + "=" + (num1 * num2));
            Console.WriteLine(num1 + "%" + num2 + "=" + (num1 % num2));
        }


        public static void tables()
        {
            int num;
            Console.Write("Enternumber :");
            num = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i <= 10; i++)
            {
                Console.WriteLine(num + "*" + i + "=" + (num * i));
            }
        }


        public static void sum()
        {
            int num1, num2, num3;
            Console.Write("Enter number 1:");
            num1 = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter number 2:");
            num2 = Convert.ToInt32(Console.ReadLine());

            int sum = num1 + num2;
            if (num1 == num2)
                Console.WriteLine("sum : " + sum * 3);
            else
                Console.WriteLine("sum : " + sum);


        }
    }
}
