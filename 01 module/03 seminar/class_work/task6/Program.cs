using System;

namespace task6
{
    class Program   
    {
        static void Main(string[] args)
        {
            double a = double.Parse(Console.ReadLine());
            double b = double.Parse(Console.ReadLine());
            double delta = double.Parse(Console.ReadLine());
            double integral = 0;
            while (a + delta <= b)
            {
                integral += delta * (a * a + (a + delta) * (a + delta)) / 2;
                a += delta;
            }
            integral += (b - a) * (a * a + b * b) / 2;
            Console.WriteLine(integral);
        }
    }
}