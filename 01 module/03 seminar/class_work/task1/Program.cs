using System;

namespace task1
{
    class Program
    {
        public static void MinMax(int a, out int minNumber, out int maxNumber)
        {
            int next;
            minNumber = 10;
            maxNumber = -1;
            while (a > 0)
            {
                next = a % 10;
                a /= 10;
                if (next < minNumber) minNumber = next;
                if (next > maxNumber) maxNumber = next;
            }
        }

        public static void Main()
        {
            int min, max;
            MinMax(7345679, out min, out max);
            Console.WriteLine(min);
            Console.WriteLine(max);
        }
    }
}