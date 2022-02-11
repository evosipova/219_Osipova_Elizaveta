using System;

namespace task1
{
    class Program
    {
        public static void Print(int[] mas)
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
            int[] mas = new int[k];
            for (int i = 0; i < mas.Length; i++)
            {
                mas[i] = (int) random.Next(0, 1000);
            }
            Print(mas);
            Console.WriteLine();
            // по четности
            Array.Sort(mas, (int a, int b) =>
            {
                a = Math.Abs(a);
                b = Math.Abs(b);
                if (a % 2 == 1 && b % 2 == 0) return 1;
                if (a % 2 == 0 && b % 2 == 1) return -1;
                return 0;
            });
            Print(mas);
            Console.WriteLine();
            // по кол-ву цифр в числе
            Array.Sort(mas, (int a, int b) =>
            {
                int lena = 0;
                int lenb = 0;
                a = Math.Abs(a);
                b = Math.Abs(b);
                while (a != 0)
                {
                    lena = lena + 1;
                    a = a / 10;
                }
                while (b != 0)
                {
                    lenb = lenb + 1;
                    b = b / 10;
                }
                if (lena > lenb) return 1; //порядок нарушен
                if (lena < lenb) return -1; //порядок верный
                return 0;
            });
            Print(mas);
            Console.WriteLine();
            // по сумме цифр в числе
            Array.Sort(mas, (int a, int b) =>
            {
                int lena = 0;
                int lenb = 0;
                a = Math.Abs(a);
                b = Math.Abs(b);
                while (a != 0)
                {
                    lena = lena + a % 10;
                    a = a / 10;
                }
                while (b != 0)
                {
                    lenb = lenb + b % 10;
                    b = b / 10;
                }
                if (lena > lenb) return 1;
                if (lena < lenb) return -1;
                return 0;
            });
            Print(mas);
            Console.WriteLine();
        }
    }
}