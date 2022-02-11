using System;

namespace task3
{
    class Program
    {
        public static void NodNok(uint a, uint b, out uint nod, out uint nok)
        {
            uint n = a, m = b;
            uint c;
            while (b > 0)
            {
                c = b;
                b = a % b;
                a = c;
            }
            nod = a;
            nok = (n * n) / nod;
        }
        static void Main(string[] args)
        {
            uint a, b;
            uint.TryParse(Console.ReadLine(), out a); 
            uint.TryParse(Console.ReadLine(), out b);
            NodNok(a, b, out uint nod, out uint nok);
            Console.WriteLine(nod);
            Console.WriteLine(nok);
        }
    }
}