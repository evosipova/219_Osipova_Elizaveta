using System;
using System.Collections;
namespace task1
{
    class TriangleNums : IEnumerable
    {
        int number = 1;
        public IEnumerator GetEnumerator()
        {
            for (int i = 0; i < 10; ++i)
            {
                yield return number;
                number = number + i + 2;
            }
        }
        public IEnumerable NameEnumerator(int number)
        {
            for (var i = 0; i < number; ++i)
            {
                yield return this.number;
                this.number = this.number + i + 2;
            }
        }
    }
    
    class Fibonacci : IEnumerable
    {
        private int x0 = 1;
        private int x1 = 1;
        public IEnumerator GetEnumerator()
        { 
            for (var i = 0; i < 10; ++i) 
            { 
                yield return x0;
                int c = x0; 
                x0 = x1; 
                x1 = x1 + c;
            }
        }
        public IEnumerable NameEnumerator(int n)
        {
            int y0 = 1;
            int y1 = 1;
            for (var i = 0; i < n; ++i)
            {
                yield return y0;
                int c = y0;
                y0 = y1;
                y1 = y1 + c;
            }
        }
    }


    internal class Program
    {
        private static void Main()
        {
            var fibonacci = new Fibonacci();
            var triangleNums = new TriangleNums();
            var array = new int[10];

            var index = 0;
            foreach (object? el in fibonacci.NameEnumerator(10))
            {
                Console.WriteLine(el);
                array[index++] = (int)el;
            }
            Console.WriteLine("----------");
            index = 0;
            foreach (object? el in triangleNums.NameEnumerator(10))
            {
                Console.WriteLine(el);
                array[index++] += (int)el;
            }
            Console.WriteLine("----------");
            foreach (int el in array)
            {
                Console.WriteLine(el);
            }
        }
    }
}