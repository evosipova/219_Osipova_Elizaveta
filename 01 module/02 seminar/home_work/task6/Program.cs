using System;

namespace task6
{
    class Program
    {
        static void F1(double b, int p)
        {
            double rub = b / 100 * p;
            double dol = (b * 0.0137) / 100 * p;
            double ev = (b * 0.0116) / 100 * p;
            Console.WriteLine(rub + "₽");
            Console.WriteLine(dol.ToString("C", new System.Globalization.CultureInfo("en-US")));
            Console.WriteLine(ev.ToString("C", new System.Globalization.CultureInfo("fr-FR")));
            
        }
        static void Main(string[] args)
        {
            double b;
            int p;
            bool f1 = double.TryParse(Console.ReadLine(), out b);
            bool f2 = int.TryParse(Console.ReadLine(), out p);
            if (f1 && f2)
            {
                F1(b, p);
            }
            else
            {
                Console.WriteLine("Ошибка ввода");
            }
        }
    }
}