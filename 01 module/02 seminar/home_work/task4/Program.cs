using System;

namespace task4
{
    class Program
    {
        public static void Print(int n)
        {
            int length = (int) Math.Log10(n);
            int p = (int) Math.Pow(10, length);
            int k;
            while (n > 0)
            {
                k = n / p;
                n = n % p;
                p /= 10;
                Console.WriteLine(k);
            }
        }
        public static void Main(string[] args)
        {
            int a;
            bool f1 = int.TryParse(Console.ReadLine(), out a);
            if (f1 && (a < 10000) && (a > 999))
                Print(a);
        }
    }
}