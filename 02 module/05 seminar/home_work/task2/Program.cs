using System;

namespace task2
{
     public class Cinderella
    {
        public string all = String.Empty;
        public override string ToString() { return all; }
    }
    abstract class Something : Cinderella { }
    class Ashes : Something
    {
        private Random random = new();
        private double Volume()
        { return random.Next(0,2) + random.NextDouble(); }
        public override string ToString()
        { return ("Ashes" + $" Volume = {Volume()}"); }
    }
    class Lentil : Something
    {
        private Random random = new();
        private double Weight()
        { return random.Next(0,2) + random.NextDouble(); }
        public override string ToString()
        { return ("Lentil" + $" Weight = {Weight()}"); }
    }
    internal class Program
    {
        public static void Main(string[] args)
        {
            var rand = new Random();
            var n = int.Parse(Console.ReadLine());
            Cinderella el = new Cinderella();
            var arrayC = new Cinderella[n];
            for (int i = 0; i < n; i++)
            {
                if (rand.Next(0, 2) == 1)
                { el = new Lentil(); }
                else
                { el = new Ashes(); }
                arrayC[i] = el;
            }
            Array.Sort(arrayC, Check);
            foreach (var r in arrayC)
            { if (r is Ashes) { Console.WriteLine(r); } }
            foreach (var t in arrayC)
            { if (t is Lentil) { Console.WriteLine(t); } }

            static int Check(Cinderella d1, Cinderella d2)
            {
                if (d1 is Lentil && d2 is Ashes)
                { return 1; }
                if (d1 is Ashes && d2 is Lentil)
                { return 0; }
                return -1;
            }
        }
    }
}