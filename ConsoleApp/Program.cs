using Dal;
using System;
using System.Linq;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            using (BlueContext context = new BlueContext())
            {
                context.Initialize(true);

                var customers = context.Customers.ToList();
            }

            Console.WriteLine("Oki");
        }
    }
}
