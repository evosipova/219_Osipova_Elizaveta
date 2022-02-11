using System;

namespace task7
{
    class Program   
    {
        public static int Func(int m, int n)
        {
            if (m == 0)
            {
                return n + 1;
            }
            else if (m > 0 && n == 0)
            {
                return Func(m - 1, 1);
            }
            else if (m > 0 && n > 0)
            {
                return Func(m - 1, Func(m, n - 1));
            }

            return 0;
        }
        static void Main(string[] args)
        {
            int n = Convert.ToInt32(Console.ReadLine());
            int m = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine(Func(n, m));
        }
    }
}