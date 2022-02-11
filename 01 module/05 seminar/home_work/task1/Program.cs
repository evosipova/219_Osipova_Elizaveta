using System;

namespace task1
{
    class Program
    {
        public static bool Shift(ref char ch)
        {
            if (ch >= 97 && ch <= 122)
            {
                ch = (char)((int)ch - 4);
                return true;
            }
            return false;
        }
        static void Main(string[] args)
        {
            char.TryParse(Console.ReadLine(), out char a);
            if (Shift(ref a))
            {
                Console.WriteLine(a);
            }
            else
            {
                Console.WriteLine("Incorrect input.");
            }
        }
    }
}