using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assessment2
{
    internal class Products
    {
            public int ProductId;
            public string ProductName;
            public double Price;
        }

        class Product
        {
            static void Main()
            {
                Products[] p = new Products[10];
                for (int i = 0; i < 10; i++)
                {
                    p[i] = new Products();

                    Console.WriteLine($"\nEnter details for Product {i + 1}:");

                    Console.Write("Product ID: ");
                    p[i].ProductId = Convert.ToInt32(Console.ReadLine());

                    Console.Write("Product Name: ");
                    p[i].ProductName = Console.ReadLine();

                    Console.Write("Price: ");
                    p[i].Price = Convert.ToDouble(Console.ReadLine());
                }
                for (int i = 0; i < 9; i++)
                {
                    for (int j = i + 1; j < 10; j++)
                    {
                        if (p[i].Price > p[j].Price)
                        {
                            Products temp = p[i];
                            p[i] = p[j];
                            p[j] = temp;
                        }
                    }
                }
                Console.WriteLine("\nProducts sorted by Price:");
                for (int i = 0; i < 10; i++)
                {
                    Console.WriteLine("ID: " + p[i].ProductId +
                                      ", Name: " + p[i].ProductName +
                                      ", Price: " + p[i].Price);
                }
            }
        }
    
}
