using System;

namespace Task3
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = 7;
            int[] mas = new int[n];
            for (int i = 1; i < mas.Length; i++)
            {
                mas[i] = i;
                //Console.Write(mas[i]);
                //123456
                //2
            }
            for (int i = 0; i < mas.Length - 1; i++)
            {
                if ((mas[i] + mas[i + 1]) % 3 == 0)
                {
                    Console.Write(mas[i]* mas[i + 1]);
                }
                else Console.Write(mas[i+1]);
            }
        }
    }
}