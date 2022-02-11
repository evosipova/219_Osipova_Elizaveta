using System;

namespace task5
{
    class Program
    {
        static void Main(string[] args)
        {
            double a;
            double b;
            bool f1 = double.TryParse(Console.ReadLine(), out a);
            bool f2 = double.TryParse(Console.ReadLine(), out b);
            if ((f1&&f2) && (a >= 0) && (b >= 0))
            {
                double c;
                c = Math.Sqrt(a * a + b * b); 
                Console.WriteLine(c);
            }
            else { Console.WriteLine("Incorrect input"); }
        }
    }
}