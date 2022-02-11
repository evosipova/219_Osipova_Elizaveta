using System;

namespace task5
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
                bool sign = a < b + c & b < a + c & c < a + b;
                string report = sign ? "Это длины сторон треугольника!" : "Треугольник построить нельзя!";
                Console.WriteLine(report);
            }
            else
            {
                Console.WriteLine("Ошибка ввода");
            }
        }
    }
}