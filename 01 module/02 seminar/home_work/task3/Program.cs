using System;
using System.Diagnostics;

namespace task3
{
    class Program
    {
        static void Main(string[] args)
        {
            double a;
            double b;
            double c;
            bool f1 = double.TryParse(Console.ReadLine(), out a);
            bool f2 = double.TryParse(Console.ReadLine(), out b);
            bool f3 = double.TryParse(Console.ReadLine(), out c);
            if (f1 && f2 && f3)
            {
                double discr = b * b - 4 * a * c;
                switch(discr)
                {
                    case 0:
                        double x = (-b + Math.Sqrt(discr)) / (2 * a);
                        Console.WriteLine(x);
                        break;
                    case > 0:
                        double x1 = (-b + Math.Sqrt(discr)) / (2 * a);
                        double x2 = (-b - Math.Sqrt(discr)) / (2 * a);
                        Console.WriteLine(x1);
                        Console.WriteLine(x2);
                        break;
                    case <0:
                        Console.WriteLine("Корней нет");
                        break;

                }
            }
            else { Console.WriteLine("Ошибка ввода"); }
        }
    }
}gi