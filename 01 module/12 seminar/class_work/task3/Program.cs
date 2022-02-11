using System;
using System.Text.RegularExpressions;
//Найти все слова из 4 букв.
namespace task3
{
    class Program
    {
        static void Main(string[] args)
        {
            string s = "Слова, текст, игра, дом";
            string ss = @"\b\w{4}\b";
            //Regex regex2 = new Regex();
            foreach (var i in Regex.Matches(s,ss))
            {
                Console.Write(i + " ");
            }
            Console.WriteLine();
            // Console.WriteLine(regex2.IsMatch(s));
            // Console.WriteLine(regex2.Match(s)); 
        }
    }
}