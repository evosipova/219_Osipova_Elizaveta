using System;
using System.Collections;
using System.Collections.Generic;
namespace task3
{
    class Point
    {
        public double x { get; set; }
        public double y { get; set; }
        public Point(double _x = 0, double _y = 0)
        {
            x = _x;
            y = _y;
        }
        public static double Distance(Point p1, Point p2)
        {
            return p1.Distance(p2);
        }
        public double Distance(Point p)
        {
            return Math.Sqrt((x - p.x) * (x - p.x) + (y - p.y) * (y - p.y));
        }
    }
    class TriangleComp : IComparable<TriangleComp>
    {
        public Point A, B, C;
        public double AB, AC, BC;
        private double area = -1;
        public double Area
        {
            get
            {
                if (area == -1)
                {
                    double p = (AB + AC + BC) / 2;
                    return area = Math.Sqrt(p * (p - AB) * (p - AC) * (p - BC));
                }
                return area;
            }
        }
        public TriangleComp(Point _A, Point _B, Point _C)
        {
            A = _A;
            B = _B;
            C = _C;
            AB = A.Distance(B);
            AC = A.Distance(C);
            BC = B.Distance(C);
        }
        private double sign(Point p1, Point p2, Point p3)
        {
            return (p1.x - p3.x) * (p2.y - p3.y) - (p2.x - p3.x) * (p1.y - p3.y);
        }
        public bool PointInTriangle(Point pt)
        {
            double d1, d2, d3;
            bool has_neg, has_pos;
            d1 = sign(pt, A, B);
            d2 = sign(pt, B, C);
            d3 = sign(pt, C, A);
            has_neg = (d1 < 0) || (d2 < 0) || (d3 < 0);
            has_pos = (d1 > 0) || (d2 > 0) || (d3 > 0);
            return !(has_neg && has_pos);
        }
        public int CompareTo(TriangleComp obj)
        {
            return this.Area.CompareTo(obj.Area);
        }
    }
    class TriangleCompComparer : IComparer<TriangleComp>
    {
        public int Compare(TriangleComp x, TriangleComp y)
        {
            double xp = x.AB + x.AC + x.BC;
            double yp = y.AB + y.AC + y.BC;
            return yp.CompareTo(xp);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            TriangleComp tc = new(new Point(0, 0), new Point(0, 1), new Point(1, 0));
            Console.WriteLine(tc.Area + " " + tc.PointInTriangle(new Point(0.1, 0.1)));
            int n = 5;
            TriangleComp[] triangleComps = new TriangleComp[n];
            triangleComps[0] = new(new Point(0, 0), new Point(0, 1), new Point(1, 0));
            triangleComps[1] = new(new Point(1, 0), new Point(6, 1), new Point(1, 9));
            triangleComps[2] = new(new Point(1, 2), new Point(0, 1), new Point(5, 9));
            triangleComps[3] = new(new Point(-1, 3), new Point(0, 1), new Point(1, 10));
            triangleComps[4] = new(new Point(7, 6), new Point(7, 1), new Point(1, 0));
            Array.Sort(triangleComps);
            foreach (var a in triangleComps)
                Console.WriteLine(a.Area);
            Console.WriteLine("***");
            Array.Sort(triangleComps, new TriangleCompComparer());
            foreach (var a in triangleComps)
                Console.WriteLine(a.Area);
            Console.WriteLine("***");
        }
    }
}