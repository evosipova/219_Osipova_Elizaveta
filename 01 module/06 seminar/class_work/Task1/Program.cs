using System;
namespace Task1
{
    class Program
    {
        /// <summary>
        /// Метод для нахождения длины числа.
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        static int  Dlina(long x) // 
        {
            int count = 0;
            while (x > 0)
            {
                count++;
                x = x / 10;
            }
            return count;
        }
        static void Main(string[] args)
        {
            int a;
            int b = 9;
            int sum = 0;
            if (int.TryParse(System.Console.ReadLine(), out a))
            {
                for (int i = 0; i < Dlina(a); i++)
                {
                    int c = a;
                    while (c != 0 && (b >= 0))
                    {
                        if (c % 10 == b)
                        {
                            sum = sum * 10 + (c % 10);
                        } 
                        c = c / 10;
                    }
                    b = b - 1;
                }
            }
            Console.Write(sum);
        }
    }
}