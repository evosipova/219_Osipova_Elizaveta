using System;

namespace Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = 10;
            int[] mas = new int[n];
            for (int i = 0; i < mas.Length; i++)
            {
                mas[i] = 10;
                Console.Write(mas[i]);
            }
            Console.WriteLine();
            foreach (var el in mas)
            {
                Console.Write(el);
            }
        }
    }
}