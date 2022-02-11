using System;

namespace task2
{
    class Program
    {
        static void Main(string[] args)
        {
            double x, y;
            do
            {
                Console.Write("Enter first fractional number: ");
            } while (!double.TryParse(Console.ReadLine(), out x));
            do
            {
                Console.Write("Enter second fractional number: ");
            } while (!double.TryParse(Console.ReadLine(), out y));
            
            if ((x < y) && (x > 0))
            {
                Console.WriteLine(x + Math.Sin(y)); 
            } else if ((x > y) && (x < 0))
            {
                Console.WriteLine(y - Math.Cos(x));
            }
            else
            {
                Console.WriteLine(0.5 * x * y);
            } 
        }
    }
}