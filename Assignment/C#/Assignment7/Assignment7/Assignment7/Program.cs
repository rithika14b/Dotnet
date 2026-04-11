using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment7
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Squareno();
            letter();

        }  
        //first code

        static void Squareno()
        {
            Console.WriteLine("Enter numbers separated by commas:");
            string input = Console.ReadLine();

            var result = input
                .Split(',')
                .Select(x => int.Parse(x.Trim()))
                .Select(n => new { Number = n, Square = n * n })
                .Where(x => x.Square > 20);

            Console.WriteLine("Output:");
            foreach (var item in result)
            {
                Console.WriteLine($"{item.Number} - {item.Square}");
            }
        }



        //second code

        static void letter()
        {
            Console.WriteLine("Enter words separated by commas:");
            string input = Console.ReadLine();

            string[] words = input.Split(',');

            Console.WriteLine("Output:");
            foreach (string w in words)
            {
                string word = w.Trim().ToLower();

                if (word.Length > 0 && word[0] == 'a' && word[word.Length - 1] == 'm')
                {
                    Console.WriteLine(word);
                }
            }
        }


        // third code


        
    }
}


