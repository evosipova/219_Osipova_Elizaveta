using System;

namespace task4
{
    class Program
    {
        static double Form(double k, double r,uint n)
        {
            if (n == 0)
            {
                return k;
            }
            return Form(k * (1 + r / 100), r, n - 1);
        }
        static void Main(string[] args)
        {
            double.TryParse(Console.ReadLine(), out double k);
            double.TryParse(Console.ReadLine(), out double r);
            uint.TryParse(Console.ReadLine(), out uint n);
            Console.WriteLine(Form(k, r, n));
        }
    }
}