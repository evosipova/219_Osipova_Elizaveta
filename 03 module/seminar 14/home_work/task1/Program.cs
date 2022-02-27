using System;
using System.Linq;

/*
В некоторой̆ коллекции хранятся целые числа.
1. Составить LINQ-выражение, формирующее коллекцию их квадратов.
2. Составить LINQ- выражение, выбирающее только положительные двузначные числа.
3. Составить LINQ- выражение, выбирающее только чётные числа и сортирующее их по убыванию.
4. Составить LINQ- выражение, группирующее числа по порядку (сотни, десятки, единицы).
Написать программу, применяющую выражения к коллекции из n (задать с клавиатуры) случайных чисел из отрезка [-1000, 1000]. 
(снабдить выводом исходных чисел и сформированных коллекций).
 */
namespace task1
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var array = new int[n];
            Random random = new Random();
            for (var i = 0; i < array.Length; i++)
            {
                array[i] =  random.Next(-1000,1001);
            }
            foreach (var el in array)
            {
                Console.WriteLine(el);
            }
            
            Console.WriteLine();
            
            //Составить LINQ-выражение, формирующее коллекцию их квадратов.
            var array1 = array.Select(x => x*x).ToArray();
            Array.ForEach(array1, Console.WriteLine);

            Console.WriteLine();
            
            //Составить LINQ- выражение, выбирающее только положительные двузначные числа.
            var array2 = array.Where(x => x > 0 && x < 100).ToArray();
            Array.ForEach(array2, Console.WriteLine);

            Console.WriteLine();
            //Составить LINQ- выражение, выбирающее только чётные числа и сортирующее их по убыванию.
            var array3 = array.Where(x => x % 2 == 0).OrderByDescending(x => x).ToArray();
            Array.ForEach(array3, Console.WriteLine);

            Console.WriteLine();
            
            //Составить LINQ- выражение, группирующее числа по порядку (сотни, десятки, единицы).
            var array4 = array.GroupBy(x => x.ToString().Length).ToArray();
            Array.ForEach(array4, x =>
            {
                Array.ForEach(x.ToArray(), Console.WriteLine);
            });
        }
    }
}