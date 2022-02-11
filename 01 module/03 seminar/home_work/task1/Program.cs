using System;

namespace task1
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
            
            if (((y <= 0) && ((x-2)*(x-2) + (y-2)*(y-2) <= 4)) || ((x >= 0) && (y >= 0) && ((x-2)*(x-2) + (y-2)*(y-2) <= 4) && (y <= x)))
            {
                Console.WriteLine("True"); 
            }else 
                Console.WriteLine("False");
        }
    }
}