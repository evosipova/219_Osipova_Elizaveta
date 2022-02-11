using System;

namespace task4
{
    class Program
    {
        static void Main(string[] args)
        {
            double a, b, c;
            do
            {
                Console.Write("Первая аудитория: ");
            } while (!(double.TryParse(Console.ReadLine(), out a) && (a > 100) && (a < 999)));

            do
            {
                Console.Write("Вторая аудитория: ");
            } while (!(double.TryParse(Console.ReadLine(), out b) && (b > 100) && (b < 999)));

            do
            {
                Console.Write("Третья аудитория: ");
            } while (!(double.TryParse(Console.ReadLine(), out c) && (c > 100) && (c < 999)));

            double resa = a % 100;
            double resb = b % 100;
            double resc = c % 100;
            if ((resa < resb) && (resa < resc))
            {
                Console.Write(a);
            }
            else if ((resb < resa) && (resb < resc))
            {
                Console.Write(b);
            }
            else Console.Write(c);
        }
    }
}