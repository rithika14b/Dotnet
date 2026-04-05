using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Assignment5.Scholarship;

namespace Assignment5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            
            //first code


            try
            {
                BankAccount account = new BankAccount(1000);

                account.Deposit(500);
                account.Withdraw(200);

                Console.WriteLine("Current Balance: " + account.GetBalance());

                account.Withdraw(2000);

                account.Deposit(-50);
            }
            catch (InsufficientBalanceException ex) 
            {
                Console.WriteLine("Custom Exception: " + ex.Message);
            }
            catch (ArgumentException ex) 
            {
                Console.WriteLine("Argument Exception: " + ex.Message);
            }
            catch (Exception ex) 
            {
                Console.WriteLine("General Exception: " + ex.Message);
            }
            finally
            {
                Console.WriteLine("Transaction process completed.");
            }



            //second code


            try
            {
                Scholarship s = new Scholarship();

                Console.Write("Enter Marks: ");
                int marks = int.Parse(Console.ReadLine());

                Console.Write("Enter Fees: ");
                double fees = double.Parse(Console.ReadLine());

                double result = s.Merit(marks, fees);

                Console.WriteLine("Scholarship: " + result);
            }
            catch (InvalidMarksException e)
            {
                Console.WriteLine("Custom Error: " + e.Message);
            }
            catch (DivideByZeroException)
            {
                Console.WriteLine("Error: Fees cannot be zero.");
            }
            catch (FormatException)
            {
                Console.WriteLine("Error: Invalid input format.");
            }
            catch (Exception e)
            {
                Console.WriteLine("General Error: " + e.Message);
            }
            finally
            {
                Console.WriteLine("End of Program");
            }


            //third code


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


        }
    }


        //first code
      

    public class InsufficientBalanceException : ApplicationException
    {
        public InsufficientBalanceException(string message) : base(message)
        {
        }
    }

    public class BankAccount
    {
        private double balance;

        public BankAccount(double initialBalance)
        {
            if (initialBalance < 0)
                throw new ArgumentException("Initial balance cannot be negative."); 

            balance = initialBalance;
        }

        
        public void Deposit(double amount)
        {
            if (amount <= 0)
                throw new ArgumentException("Deposit amount must be positive."); 

            balance += amount;
            Console.WriteLine("Deposited: " + amount);
        }

        
        public void Withdraw(double amount)
        {
            if (amount <= 0)
                throw new ArgumentException("Withdrawal amount must be positive."); 

            if (amount > balance)
                throw new InsufficientBalanceException("Insufficient balance for withdrawal."); 

            balance -= amount;
            Console.WriteLine("Withdrawn: " + amount);
        }

        
        public double GetBalance()
        {
            return balance;
        }
    }



    // second code


    public class InvalidMarksException : Exception
    {
        public InvalidMarksException(string message) : base(message) { }
    }

    class Scholarship
    {
        public double Merit(int marks, double fees)
        {
            double temp = 1000 / fees;

            if (marks >= 70 && marks <= 80)
            {
                return fees * 0.20;
            }
            else if (marks > 80 && marks <= 90)
            {
                return fees * 0.30;
            }
            else if (marks > 90)
            {
                return fees * 0.50;
            }
            else
            {
                throw new InvalidMarksException("Marks are too low for scholarship");
            }
        }



        // third code

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
    }
}

