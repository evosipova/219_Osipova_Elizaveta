using System;

namespace task8
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = 0;
            int.TryParse(Console.ReadLine(), out int k);
            for (int i = 100; i <= 999; i++)
            {
                if (i % k == 0)
                {
                    n++;
                }
            }
            Console.WriteLine(n);
        }
    }
}