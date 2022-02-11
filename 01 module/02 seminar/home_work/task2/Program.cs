using System;

namespace task2
{
    class Program
    {
        static void Main(string[] args)
        {
            int n;
            int a = 0;
            int b = 0;
            int c = 0;
            int k;
            bool f1 = int.TryParse(Console.ReadLine(), out n);
            if (f1 && (n < 1000) && (n > 99)) 
            {
                for (int i = 0; i < 3; i++)
                {
                    c = n % 10;
                    if (c > b) { k = b; b = c; c = k; }
                    if (b > a) { k = a; a = b; b = k; }
                    n = n / 10;
                }
                Console.WriteLine(100*a + 10*b + c);
            }
            else { Console.WriteLine("Incorrect input"); }
        }

    }
}