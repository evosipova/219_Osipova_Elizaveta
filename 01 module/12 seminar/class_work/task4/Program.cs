using System;
using System.Text.RegularExpressions;
//Найти все слова, которые оканчиваются на символ a.
namespace task4
{
    class Program
    {
        static void Main(string[] args)
        {
            var s = "slova, doma, slon";
            string ss = (@"\b[a-zA-Z]*a\b");
            foreach (var i in Regex.Matches(s, ss))
            {
                Console.WriteLine(i + " ");
            }
        }
    }
}