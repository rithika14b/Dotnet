using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assessment4.question1
{
    class Distance
    {
        public int Kilometer;
        public Distance(int km)
        {
            Kilometer = km;
        }
        public static Distance Add(Distance d1, Distance d2)
        {
            return new Distance(d1.Kilometer + d2.Kilometer);
        }
        public void Display()
        {
            Console.WriteLine("Distance: " + Kilometer + " km");
        }
    }
}
