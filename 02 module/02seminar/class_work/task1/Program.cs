using System;
namespace task1
{
    class MyComplex   
    {
        public double re { get; set; }
        public double im { get; set; }
        public MyComplex(double xre, double xim)
        { re = xre; im = xim; }
             
        public static MyComplex operator --(MyComplex mc)
        {
            return new MyComplex(mc.re - 1, mc.im - 1);
        }
        public double Mod()
        {
            return Math.Abs(re * re + im * im);
        }
        public static bool operator true(MyComplex mc)
        {
            return mc.Mod() > 1.0;
        }
        public static bool operator false(MyComplex mc)
        {
            return mc.Mod() <= 1.0;
        }
        
        
        public static double operator +(MyComplex a, MyComplex b)
        {
            return (a.re + b.im) + (b.re + a.im);
        }
        public static double operator -(MyComplex a, MyComplex b)
        {
            return (a.re + b.im) - (b.re + a.im);
        }
        public static double operator *(MyComplex a, MyComplex b)
        {
            return (a.re + b.im) * (b.re + a.im);
        }
        public static double operator /(MyComplex a, MyComplex b)
        {
            return (a.re + b.im) / (b.re + a.im);
        }
    }
    class Program
     {
            static void Main(string[] args)
            {
                var a = new MyComplex(1, 35);
                var b = new MyComplex(10, 3);
                Console.WriteLine(a + b);
                Console.WriteLine(a - b);
                Console.WriteLine(a * b);
                Console.WriteLine(a / b);
            }
    }
}
   