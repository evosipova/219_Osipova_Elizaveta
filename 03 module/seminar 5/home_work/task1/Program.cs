using System;

namespace task1
{
    public delegate double calculate(double x);

    interface IFunction
    { 
        double Function(double x);
    }
    
    class F : IFunction
    {
        calculate calc;
        
        public F(calculate c) => calc = c;

        public double Function(double x)
        {
            return calc(x);
        }
    }

    class G
    {
        F f1, f2;
        public G(F f1, F f2)
        {
            this.f1 = f1;
            this.f2 = f2;
        }
        public double GF(double x0)
        {
            return f1.Function(f2.Function(x0));
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            F f1 = new F(x => x * x + 4);
            F f2 = new F(x => Math.Sin(x));
            G g = new G(f1, f2);
            //G g = new G(new F(x => x * x + 4), new F(x => Math.Sin(x)));
            for (double i = 0; i < Math.PI; i += Math.PI / 16)
            {
                Console.WriteLine("{0:F4}", g.GF(i));
            }
        }
    }
}