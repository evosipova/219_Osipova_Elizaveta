using System;
using System.Collections;

namespace task4
{
    class Program
    {
        public static void Print(double[] mas)
        {
            foreach (var i in mas)
            {
                Console.Write(i + " ");
            }
        } 
        static void Main(string[] args)
        {
            int n = 5, m = 3;
            int[,] a = new int[n, m];
            
            Random random = new Random();
            int[][] b = new int[n][];
            Console.WriteLine();
            for (int i = 0; i < b.Length; i++)
                b[i] = new int[random.Next(5, 15 + i)];

            for (int i = 0; i < b.Length; i++, Console.WriteLine())
            for (int j = 0; j < b[i].Length; j++)
            {
                b[i][j] = random.Next(-10, 10);
                Console.Write(b[i][j] + " ");
            }
        }
    }
}