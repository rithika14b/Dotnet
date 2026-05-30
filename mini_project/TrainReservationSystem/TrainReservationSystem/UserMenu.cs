using System;

namespace TrainReservationSystem
{
    public class UserMenu
    {
        public void ShowMenu()
        {
            while (true)
            {
                Console.Clear();

                Console.WriteLine("===== USER MENU =====");
                Console.WriteLine("1. Search Train");
                Console.WriteLine("2. Book Ticket");
                Console.WriteLine("3. View Ticket");
                Console.WriteLine("4. Cancel Ticket");
                Console.WriteLine("5. Back");

                Console.Write("Enter Choice : ");

                int choice = Convert.ToInt32(Console.ReadLine());

                UserOperations user = new UserOperations();

                switch (choice)
                {
                    case 1:
                        user.SearchTrain();
                        break;

                    case 2:
                        user.BookTicket();
                        break;

                    case 3:
                        user.ViewTicket();
                        break;

                    case 4:
                        user.CancelTicket();
                        break;

                    case 5:
                        return;
                }
            }
        }
    }
}
