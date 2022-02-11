using System;

namespace task3
{
    class Program
    {
        static void Main(string[] args)
        {
            double x;
            do
            {
                Console.Write("Enter number: ");
            } while (!double.TryParse(Console.ReadLine(), out x));
            if (x < 0.5)
            {
                Console.WriteLine(Math.Sin(Math.PI/2)); 
            } else if (x > 0.5)
            {
                Console.WriteLine(Math.Sin(Math.PI*(x-1)/2)); 
            }
        }
    }
}