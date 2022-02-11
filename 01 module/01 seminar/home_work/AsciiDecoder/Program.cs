using System;

namespace AsciiDecoder
{
    class Program
    {
        static void Main(string[] args)
        {
            char a;
            if (char.TryParse(Console.ReadLine(), out a))
            {
                if (((int)a >= 32) && ((int)a <= 127))
                {Console.WriteLine((int)a);} 
                else { Console.WriteLine("Incorrect input"); }
            }
            else { Console.WriteLine("Incorrect input"); }
        }
    }
}