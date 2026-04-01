using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //first code

            Accounts acc = new Accounts(1410, "Rithika", "Savings", 5000);
            acc.UpdateTransaction('D', 1500);
            acc.ShowData();
            acc.UpdateTransaction('W', 2000);
            acc.ShowData();



            //second code

            Result r = new Result(1, "RITHI", "BE", 3, "CSE");
            r.GetMarks();
            r.DisplayData();
            r.DisplayResult();



            // Third code

            DisplaySale sales = new DisplaySale(101, 5000, 350.5, 4, DateTime.Now);
            sales.Sales();
            sales.ShowData();

        }



        //first code

        class Accounts
        {
            public int AccountNo;
            public string CustomerName;
            public string AccountType;
            public char TransactionType;
            public double Amount;
            public double Balance;

            public Accounts(int accNo, string name, string type, double balance)
            {
                AccountNo = accNo;
                CustomerName = name;
                AccountType = type;
                Balance = balance;
            }

            public void UpdateTransaction(char tType, double amt)
            {
                TransactionType = tType;
                Amount = amt;

                if (TransactionType == 'D' || TransactionType == 'd')
                    Credit(Amount);
                else if (TransactionType == 'W' || TransactionType == 'w')
                    Debit(Amount);
            }

            public void Credit(double amount)
            {
                Balance += amount;
            }

            public void Debit(double amount)
            {
                if (amount <= Balance)
                    Balance -= amount;
                else
                    Console.WriteLine("Insufficient Balance");
            }

            public void ShowData()
            {
                Console.WriteLine("Account No: " + AccountNo);
                Console.WriteLine("Customer Name: " + CustomerName);
                Console.WriteLine("Account Type: " + AccountType);
                Console.WriteLine("Transaction Type: " + TransactionType);
                Console.WriteLine("Amount: " + Amount);
                Console.WriteLine("Balance: " + Balance);
            }
        }

    }


    // Second code

    class Student
    {
        public int RollNo;
        public string Name;
        public string ClassName;
        public int Semester;
        public string Branch;
        public int[] Marks = new int[5];

        public Student(int roll, string name, string cls, int sem, string branch)
        {
            RollNo = roll;
            Name = name;
            ClassName = cls;
            Semester = sem;
            Branch = branch;
        }

        public void GetMarks()
        {
            Console.WriteLine("Enter marks");
            for (int i = 0; i < 5; i++)
                Marks[i] = Convert.ToInt32(Console.ReadLine());
        }
    }

    class Result : Student
    {
        public Result(int roll, string name, string cls, int sem, string branch) : base(roll, name, cls, sem, branch) { }

        public void DisplayResult()
        {
            int total = 0;
            bool fail = false;

            for (int i = 0; i < 5; i++)
            {
                total += Marks[i];
                if (Marks[i] < 35)
                    fail = true;
            }

            double avg = total / 5.0;

            if (fail || avg < 50)
                Console.WriteLine("Result: Failed");
            else
                Console.WriteLine("Result: Passed");

            Console.WriteLine("Average: " + avg);
        }

        public void DisplayData()
        {
            Console.WriteLine("Roll No: " + RollNo);
            Console.WriteLine("Name: " + Name);
            Console.WriteLine("Class: " + ClassName);
            Console.WriteLine("Semester: " + Semester);
            Console.WriteLine("Branch: " + Branch);
            Console.WriteLine("Marks:");
            for (int i = 0; i < 5; i++)
                Console.WriteLine(Marks[i]);
        }
    }




    // Third code

    class Saledetails
    {
        public int SalesNo;
        public int ProductNo;
        public double Price;
        public DateTime DateOfSale;
        public int Qty;
        public double TotalAmount;

        public Saledetails(int salesNo, int productNo, double price, int qty, DateTime date)
        {
            SalesNo = salesNo;
            ProductNo = productNo;
            Price = price;
            Qty = qty;
            DateOfSale = date;
        }

        public void Sales()
        {
            TotalAmount = Qty * Price;
        }
    }

    class DisplaySale : Saledetails
    {
        public DisplaySale(int salesNo, int productNo, double price, int qty, DateTime date) : base(salesNo, productNo, price, qty, date) { }

        public void ShowData()
        {
            Console.WriteLine("Sales No: " + SalesNo);
            Console.WriteLine("Product No: " + ProductNo);
            Console.WriteLine("Price: " + Price);
            Console.WriteLine("Quantity: " + Qty);
            Console.WriteLine("Date of Sale: " + DateOfSale.ToShortDateString());
            Console.WriteLine("Total Amount: " + TotalAmount);
        }
    }

}
