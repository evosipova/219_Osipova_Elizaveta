using System;

namespace task3
{
    class Program
    {
        static void F1()
        {
            for (int i = 1; i < 10; i++)
            {
                Console.Write(i * i + " ");
            }
        }

        static void F2()
        {
            int k = 1;
            while (k < 10)
            {
                Console.Write(k * k + " ");
                k++;
            }
        }

        static void F3()
        {
            int k = 1;
            do
            {
                Console.Write(k * k + " ");
                k++;
            } while (k <= 10);
        }

        static void Main(string[] args)
        {
            F1();
            Console.WriteLine();
            F2();
            Console.WriteLine();
            F3();
        }
    }
}