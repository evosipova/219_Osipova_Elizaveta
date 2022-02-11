using System;

namespace task03
{
    class RegularPolygon 
    {
        public int n { get; set; }
        public int r { get; set; }
        public RegularPolygon(int N = 0, int R = 0)
        {
            n = N;
            r = R;
        }
        public double Perimetr
        {
            get
            {
              return (2 * r * Math.Tan(Math.PI / 2 / n));  
            }
            
        }
        public double Square
        { 
            get 
            { 
                return (n *  r * r * Math.Tan(Math.PI / 2 / n)); 
            }
        }
        
        public override string ToString()
        {
            return ("P = " + Perimetr + " S = " + Square);
        }
    }
    class Program   
    {
        static void Main(string[] args)
        {
            var c = int.Parse(Console.ReadLine());
            var rad = int.Parse(Console.ReadLine());
            var ans = new RegularPolygon(c, rad);
            Console.WriteLine(ans.ToString());
        }
    }
} 
