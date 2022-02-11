using System;

namespace task1
{
    class Program
    {
        static void Main(string[] args)
        {
            double n;
            bool f1 = double.TryParse(Console.ReadLine(), out n);
            if (f1) 
            {
                Console.WriteLine((n * (2 + n * (3 + n * (9 + n * 12))) - 4));
            }
            else { Console.WriteLine("Incorrect input"); }
        }

    }
}