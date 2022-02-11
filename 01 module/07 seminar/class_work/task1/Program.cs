using System;
using System.ComponentModel;

namespace task1
{
    class Program
    {
        public static void Print(char[] mas)
        {
            foreach (var i in mas)
            {
              Console.Write(i + " ");
            }
        }
        static void Main(string[] args)
        {
            int k = 10;
            Random random = new Random();
            char[] mas = new char[k];
            for (int i = 0; i < mas.Length; i++)
            {
                mas[i] = (char) random.Next('A', 'Z' + 1);
            }
            Print(mas);
            Console.WriteLine();
            Array.Sort(mas);
            Print(mas);
            Console.WriteLine();
            Array.Reverse(mas);
            Print(mas);
            Console.WriteLine();
            Array.Copy(mas, mas, k);
            Print(mas);
            Console.WriteLine();
        }
        

    }
}