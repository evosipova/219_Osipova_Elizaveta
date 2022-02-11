using System;

namespace task7
{
    class Program
    {
        static void Main(string[] args)
        {
            double a;
            bool f1 = double.TryParse(Console.ReadLine(), out a);
            if (f1)
            {
                Console.WriteLine(Math.Sqrt(a));
                Console.WriteLine(Math.Pow(a, 2));
                Console.WriteLine(Math.Truncate(a));
                Console.WriteLine(a - (int)a);
            }
            else { Console.WriteLine("Ошибка ввода"); }
        }
    }
}