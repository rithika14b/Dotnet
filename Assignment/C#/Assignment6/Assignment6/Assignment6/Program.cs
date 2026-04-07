using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment6
{
    internal class Program
    {
        static void Main(string[] args)
        {


            // first code

            BookShelf shelf = new BookShelf();

            shelf[0] = new Books("The Alchemist", "Paulo Coelho");
            shelf[1] = new Books("Wings of Fire", "A.P.J Abdul Kalam");
            shelf[2] = new Books("Harry Potter", "J.K. Rowling");
            shelf[3] = new Books("Rich Dad Poor Dad", "Robert Kiyosaki");
            shelf[4] = new Books("Ikigai", "Hector Garcia");

            Console.WriteLine("Books in Shelf:\n");

            for (int i = 0; i < 5; i++)
            {
                shelf[i].Display();
            }



            // second code

            WriteStream();
            ReadStream();


            //third code

            WriteStreams();
            CountLines();


        }

        //first code

        public class Books
        {
            public string BookName;
            public string AuthorName;

            public Books(string bookName, string authorName)
            {
                BookName = bookName;
                AuthorName = authorName;
            }

            public void Display()
            {
                Console.WriteLine("Book Name: " + BookName + ", Author: " + AuthorName);
            }
        }

        public class BookShelf
        {
            private Books[] bookList = new Books[5];

            public Books this[int index]
            {
                get
                {
                    return bookList[index];
                }
                set
                {
                    bookList[index] = value;
                }
            }
        }



        //second code


        public static void WriteStream()

        {
            using (FileStream files = new FileStream("ArrayString.txt", FileMode.Create, FileAccess.Write))
            using (StreamWriter streamwrite = new StreamWriter(files))
            {
                Console.WriteLine("Enter Size Of Array: ");
                int size = Convert.ToInt32(Console.ReadLine());
                string[] Strarray = new string[size];
                Console.WriteLine("Enter Elements Of Array: ");
                for (int i = 0; i < size; i++)
                {
                    Strarray[i] = Console.ReadLine();
                    streamwrite.WriteLine(Strarray[i]);
                }
            }
        }
        public static void ReadStream()
        {
            using (FileStream files = new FileStream("ArrayString.txt", FileMode.Open, FileAccess.Read))
            using (StreamReader streamread = new StreamReader(files))
            {
                string line;
                Console.WriteLine("Array Elements: ");

                while ((line = streamread.ReadLine()) != null)
                {
                    Console.WriteLine(line);
                }
            }
        }




        // third code


        public static void WriteStreams()
        {
            using (FileStream files = new FileStream("StringLines.txt", FileMode.Create, FileAccess.Write))
            using (StreamWriter streamwrite = new StreamWriter(files))
            {
                Console.WriteLine(" Enter Lines: ");
                string str = Console.ReadLine();
                streamwrite.WriteLine(str);
            }

        }
        public static void CountLines()
        {
            int LineCount = 0;
            using (FileStream files = new FileStream("StringLines.txt", FileMode.Open, FileAccess.Read))
            using (StreamReader streamrread = new StreamReader(files))
            {
                string str;
                while ((str = streamrread.ReadLine()) != null)
                {
                    LineCount++;
                }


            }
            Console.WriteLine($" Total Lines Count: {LineCount}");

        }
    }
}
