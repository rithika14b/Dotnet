using System;
using System.Collections.Generic;
using System.Linq;

namespace Assignment4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            StringLength();
            Reverse();
            stackelement();

        }

        //String length
        static void StringLength()
        {
            Console.Write("Enter a string: ");
            string str = Console.ReadLine();

            Console.Write("Enter position to remove : ");
            int position = Convert.ToInt32(Console.ReadLine());

            if (position < 0 || position >= str.Length)
            {
                Console.WriteLine("Invalid position");
            }
            else
            {
                string result = str.Remove(position, 1);
                Console.WriteLine("Result: " + result);
            }
        }


        //reverse string

        static void Reverse()
        {
            Console.Write("Enter a string: ");
            string input = Console.ReadLine();

            if (string.IsNullOrEmpty(input) || input.Length == 1)
            {

                Console.WriteLine("Result: " + input);
            }
            else
            {
                char first = input[0];
                char last = input[input.Length - 1];

                string middle = input.Substring(1, input.Length - 2);

                string result = last + middle + first;

                Console.WriteLine("Result: " + result);
            }
        }


        //stack element

        static void stackelement()
        {
            Stack<int> stack = new Stack<int>();

            Console.Write("Enter number of elements: ");
            int n = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter elements:");
            for (int i = 0; i < n; i++)
            {
                int value = Convert.ToInt32(Console.ReadLine());
                stack.Push(value);
            }

            List<int> list = stack.ToList();

            list.Sort((a, b) => b.CompareTo(a));

            Stack<int> sortedStack = new Stack<int>();

            foreach (int item in list)
            {
                sortedStack.Push(item);
            }

            Console.WriteLine("Stack elements in descending order:");
            foreach (int item in sortedStack)
            {
                Console.WriteLine(item);
            }


        }
    }
}
