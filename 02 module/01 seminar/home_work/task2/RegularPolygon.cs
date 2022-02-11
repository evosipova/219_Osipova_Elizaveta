using System;

namespace task2
{
    class RegularPolygon
    {
        public int n { get; set; }
        public double r { get; set; }
        public RegularPolygon(int N = 0, double R = 0)
        {
            n = N;
            r = R;
        }
        public double P
        {
            get
            {
                return (2 * r * Math.Tan(Math.PI / 2 / n));  
            }
                
        }
        public double S
        { 
            get 
            { 
                return (n *  r * r * Math.Tan(Math.PI / 2 / n)); 
            }
        }
            
        public string Data()
        {
            return "Кол-во сторон : " + n.ToString() +
                   "\nРадиус вписанной окр.-ти : " + r.ToString() +
                   "\nПериметр многоугольника : " + P.ToString() +
                   "\nПлощадь многоугольника : " + S.ToString();
        }
        
    }
}