using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace task1
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] names = {"Artr", "Asd", "asde", "Sdr", "hre"};
            List<string> selected = new List<string>();
            for (int i = 0; i < names.Length; i++)
            {
                if (names[i].ToUpper().StartsWith("A"))
                    selected.Add(names[i]);
            }

            foreach (var i in selected)
            {
                Console.Write(i + " ");
            }
            Console.WriteLine();

            var selected2 = (from t in names
                where t.ToUpper().StartsWith("A")
                orderby t descending
                select t).ToArray();
            
            
            foreach (var i in selected2)
            {
                Console.Write(i + " ");
            }
            Console.WriteLine();



            names[1] = "AAAAA";
            foreach (var i in selected2)
            {
                Console.Write(i + " ");
            }
            Console.WriteLine();



            var selected3 = names
                .Where(t => t.ToUpper().StartsWith("A"))
                .OrderByDescending(t => t)
                .ThenBy(t => t.Length);
            foreach (var i in selected3)
            {
                Console.Write(i + " ");
            }
            Console.WriteLine();




            string s = "Бык, бычок";
            Regex regex = new Regex(@"туп\w*");
            var matches = regex.Matches(s);
            foreach (Match m in matches)
            {
                Console.WriteLine(m);
            }

            s = regex.Replace(s, "1111");
            Console.WriteLine(s);


            string s2 = "1111-111-1111";
            Regex regex2 = new Regex(@"^[0-9]{3}-\d{3}-\d{3}");
            Console.WriteLine(regex2.IsMatch(s2));
            Console.WriteLine(regex2.Match(s2));
        }
    }
}