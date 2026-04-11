using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelConcessionLibrary
{
    public class Concession
    {
        public string CalculateConcession(int age, double totalFare)
        {
            if (age <= 5)
            {
                return "Little Champs - Free Ticket";
            }
            else if (age > 60)
            {
                double concessionFare = totalFare - (totalFare * 0.30);
                return "Senior Citizen - Fare after concession: ₹" + concessionFare;
            }
            else
            {
                return "Ticket Booked - Fare: ₹" + totalFare;
            }
        }
    }
}
