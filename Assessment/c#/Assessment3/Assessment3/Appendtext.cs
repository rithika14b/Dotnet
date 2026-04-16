using System;
using System.IO;

namespace Assessment3
{
    internal class Appendtext
    {
        static void Main(string[] args)
        {
            string filePath = "sample.txt";

            Console.Write("Enter text to append: ");
            string text = Console.ReadLine();

            try
            {
                
                using (StreamWriter writer = new StreamWriter(filePath, true))
                {
                    writer.WriteLine(text);
                }

                Console.WriteLine("Text appended successfully.");
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
            }

        }
    }
}
    

