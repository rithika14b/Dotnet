using System;

namespace Assignment2
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            number();
            Day();
            Arrayavg();
            Marks();
            copyarray();
            Length();
            reverse();
            SameString();
        }


       
        public static void number()
            {
                Console.Write("Enter a digit: ");
                int num = Convert.ToInt32(Console.ReadLine());

                // First time 
                Console.WriteLine("{0} {0} {0} {0}", num);
                Console.WriteLine("{0}{0}{0}{0}", num);

                // Repeat again
                Console.WriteLine("{0} {0} {0} {0}", num);
                Console.WriteLine("{0}{0}{0}{0}", num);
            }
        



        
            public static void Day()
            {
                Console.Write("Enter day number (1-7): ");
                int day = Convert.ToInt32(Console.ReadLine());

                switch (day)
                {
                    case 1:
                        Console.WriteLine("Monday");
                        break;
                    case 2:
                        Console.WriteLine("Tuesday");
                        break;
                    case 3:
                        Console.WriteLine("Wednesday");
                        break;
                    case 4:
                        Console.WriteLine("Thursday");
                        break;
                    case 5:
                        Console.WriteLine("Friday");
                        break;
                    case 6:
                        Console.WriteLine("Saturday");
                        break;
                    case 7:
                        Console.WriteLine("Sunday");
                        break;
                    default:
                        Console.WriteLine("Invalid day number! Please enter a number between 1 and 7.");
                        break;
                }
            }
        



        //Array

        
            public static void Arrayavg()
            {
                // Assigning values to the array
                int[] arr = { 10, 20, 30, 40, 50 };

                int sum = 0;
                int min = arr[0];
                int max = arr[0];


                for (int i = 0; i < arr.Length; i++)
                {
                    sum += arr[i];

                    if (arr[i] < min)
                        min = arr[i];

                    if (arr[i] > max)
                        max = arr[i];
                }


                double average = (double)sum / arr.Length;


                Console.WriteLine("Array Elements: ");
                foreach (int num in arr)
                {
                    Console.Write(num + " ");
                }

                Console.WriteLine("\n\nAverage Value: " + average);
                Console.WriteLine("Minimum Value: " + min);
                Console.WriteLine("Maximum Value: " + max);
            }
        


            public static void Marks()
            {
                int[] marks = new int[10];
                int sum = 0;

                // Input marks
                Console.WriteLine("Enter 10 marks:");
                for (int i = 0; i < 10; i++)
                {
                    marks[i] = Convert.ToInt32(Console.ReadLine());
                    sum += marks[i];
                }

                // Initialize ,find min and max
                int min = marks[0];
                int max = marks[0];

                for (int i = 1; i < 10; i++)
                {
                    if (marks[i] < min)
                        min = marks[i];

                    if (marks[i] > max)
                        max = marks[i];
                }

                // Calculate average
                double average = (double)sum / 10;

                // Sort ascending
                int[] asc = (int[])marks.Clone();
                Array.Sort(asc);

                // Sort descending
                int[] desc = (int[])marks.Clone();
                Array.Sort(desc);
                Array.Reverse(desc);

                // Output results
                Console.WriteLine("\nTotal: " + sum);
                Console.WriteLine("Average: " + average);
                Console.WriteLine("Minimum Marks: " + min);
                Console.WriteLine("Maximum Marks: " + max);

                Console.WriteLine("\nMarks in Ascending Order:");
                foreach (int m in asc)
                {
                    Console.Write(m + " ");
                }

                Console.WriteLine("\n\nMarks in Descending Order:");
                foreach (int m in desc)
                {
                    Console.Write(m + " ");
                }
            Console.WriteLine();
            }
        

        
            public static void copyarray()
            {
                int n;

                Console.Write("Enter number of elements: ");
                n = Convert.ToInt32(Console.ReadLine());

                int[] source = new int[n];
                int[] destination = new int[n];

                // Input elements into source array
                Console.WriteLine("Enter elements:");
                for (int i = 0; i < n; i++)
                {
                    source[i] = Convert.ToInt32(Console.ReadLine());
                }

                // Copy elements manually
                for (int i = 0; i < n; i++)
                {
                    destination[i] = source[i];
                }

                // Display source array
                Console.WriteLine("\nSource Array:");
                for (int i = 0; i < n; i++)
                {
                    Console.Write(source[i] + " ");
                }

                // Display destination array
                Console.WriteLine("\nDestination Array:");
                for (int i = 0; i < n; i++)
                {
                    Console.Write(destination[i] + " ");
                }
            Console.WriteLine();
            }
        

        //String

            public static void Length()
            {
                Console.Write("Enter a word: ");
                string word = Console.ReadLine();

                // Using string class property
                int length = word.Length;

                Console.WriteLine("Length of the word: " + length);
            }
       


            public static void reverse()
            {
                Console.Write("Enter a word: ");
                string word = Console.ReadLine();

                char[] chars = word.ToCharArray();

                // Reverse using Array method 
                Array.Reverse(chars);

                // Convert back to string
                string reversed = new string(chars);

                Console.WriteLine("Reversed word: " + reversed);
            }
        


     
            public static void SameString()
            {
                Console.Write("Enter first word: ");
                string word1 = Console.ReadLine();

                Console.Write("Enter second word: ");
                string word2 = Console.ReadLine();

                if (word1.Equals(word2))
                {
                    Console.WriteLine("Both words are the same.");
                }
                else
                {
                    Console.WriteLine("Both words are different.");
                }
            }
      



    }
}
