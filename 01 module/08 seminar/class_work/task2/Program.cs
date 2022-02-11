using System;

namespace task2
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
        public static void PrintM(int[] mask)
        {
            foreach (var i in mask)
            {
                Console.Write(i + " ");
            }
        }
        public static void PrintN(double[] masn)
        {
            foreach (var i in masn)
            {
                Console.Write(i + " ");
            }
        }
        static void Main(string[] args)
        {
            int k = 4;
            Random random = new Random();
            double[] mas = new Double[k];
            for (int i = 0; i < mas.Length; i++)
            {
                mas[i] = random.Next() + random.NextDouble();
            }
            Print(mas);
            Console.WriteLine();
            int[] mask = new int[k];
            double[] masn = new Double[k];
            for (int i = 0; i < mas.Length; i++)
            {
                mask[i] = (int) (mas[i]);
                masn[i] = (mas[i]) - mask[i];
            }
            PrintM(mask);
            Console.WriteLine();
            PrintN(masn);
        }
    }
}