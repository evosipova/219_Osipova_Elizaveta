using System;

namespace task2
{
    class Program
    {
        public static void Print(int[] mas)
        {
            foreach (var i in mas)
            {
                Console.Write(i + " ");
            }
            Console.WriteLine();
        }
        static int Sh(int a, int b)
        {
            Random random = new Random();
            return random.Next(-1, 2);
        }

        static void Main(string[] args)
        {
            Random random = new Random();
            int[] mas = new int[100];
            for (int i = 0; i < mas.Length; i++)
            {
                mas[i] = i + 1;
            }
            //Print(mas);
            Array.Sort(mas, Sh);
            Array.Resize(ref mas, 99);
            int s = 5050;
            for (int i = 0; i < mas.Length; i++)
            {
                s -= mas[i];
            }
            Console.WriteLine(s);
        }
    }
}