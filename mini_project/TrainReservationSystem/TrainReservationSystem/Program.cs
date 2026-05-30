using System;

namespace TrainReservationSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.Clear();

                Console.WriteLine("=================================");
                Console.WriteLine(" TRAIN RESERVATION SYSTEM ");
                Console.WriteLine("=================================");
                Console.WriteLine("1. Admin");
                Console.WriteLine("2. User");
                Console.WriteLine("3. Exit");
                Console.WriteLine();

                Console.Write("Enter Choice : ");

                int choice;

                if (!int.TryParse(Console.ReadLine(), out choice))
                {
                    Console.WriteLine("Please enter a valid number.");
                    Console.ReadKey();
                    continue;
                }

                switch (choice)
                {
                    case 1:
                        AdminMenu admin = new AdminMenu();
                        admin.ShowMenu();
                        break;

                    case 2:
                        UserMenu user = new UserMenu();
                        user.ShowMenu();
                        break;

                    case 3:
                        Environment.Exit(0);
                        break;

                    default:
                        Console.WriteLine("Invalid Choice");
                        Console.ReadKey();
                        break;
                }
            }
        }
    }
}