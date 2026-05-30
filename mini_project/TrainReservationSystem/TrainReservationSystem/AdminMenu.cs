using System;

namespace TrainReservationSystem
{
    public class AdminMenu
    {
        public void ShowMenu()
        {
            while (true)
            {
                Console.Clear();

                Console.WriteLine("===== ADMIN MENU =====");
                Console.WriteLine("1. Add Train");
                Console.WriteLine("2. Update Train");
                Console.WriteLine("3. View Trains");
                Console.WriteLine("4. Delete Train");
                Console.WriteLine("5. Back");

                Console.Write("Enter Choice : ");

                int choice;

                if (!int.TryParse(Console.ReadLine(), out choice))
                {
                    Console.WriteLine("Invalid Input");
                    Console.ReadKey();
                    continue;
                }

                TrainOperations train = new TrainOperations();

                switch (choice)
                {
                    case 1:
                        train.AddTrain();
                        break;

                    case 2:
                        train.UpdateTrain();
                        break;

                    case 3:
                        train.ViewTrain();
                        break;

                    case 4:
                        train.DeleteTrain();
                        break;

                    case 5:
                        return;

                    default:
                        Console.WriteLine("Invalid Choice");
                        Console.ReadKey();
                        break;
                }
            }
        }
    }
}