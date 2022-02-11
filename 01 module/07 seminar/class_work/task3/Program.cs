using System;

namespace task3
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
        static void Main(string[] args)
        {
            int[] data = new int[100]; 
            for (int i = 0; i < data.Length; i++)
            {
                data[i] = i+1;
            }
            Random rnd = new Random();
            int escape = rnd.Next(0, 101);
            data[escape] = data[rnd.Next(rnd.Next(0, escape), rnd.Next(escape, 101))];
            for (int i = 1; i < 101; i++)
            {
                if (Array.IndexOf(data, i) == -1) Console.WriteLine(i);
            }
        }
    }
}