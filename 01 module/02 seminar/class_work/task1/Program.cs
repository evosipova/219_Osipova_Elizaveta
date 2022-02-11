using System;

namespace task1
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = vvod();
            print(number);
        }

        public static void print(int num)
        {
            for (int i = (int)Math.Log10(num) + 1; i > 0; i--)
            {
                if (i == 0)
                {
                    Console.WriteLine(num % 10);
                }
                else
                {
                    Console.WriteLine((int)(num/(Math.Pow(10, i - 1))) % 10);
                }
            }
        }

        public static int vvod()
        {
            int number;
            Console.Write("Ввод: ");
            while (!int.TryParse(Console.ReadLine(), out number)) Console.Write("Ввод: ");
            return number;
        }

    }
}
