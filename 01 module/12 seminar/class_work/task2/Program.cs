using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

//    /* Ввести n, сгенировать массив чисел от 1 до 10000.
//    1) Запрос, который вернет двухначные числа кратные 3 
//    2) Запрос, который вернет в порядке возрастания
//    все палиндромы (читается одинако) 
//    3) Запрос, который отсортирует числа по сумме цифр, а затем по
//    значению числа
//    4) Запрос, который найдет сумму всех четырехзнчных чисел 
//    5) Запрос, который найдет минимальное значение среди всех двузначных
//    чисел /+
//    6) запрос, который формирует коллекцию
namespace task2
{
    class Program
    {
        static int summ(int n)
        {
            int sum = 0;
            int t = n;
            while (t > 0)
            {
                sum = sum + t % 10;
                t = t / 10;
            }
            return sum;
        }
        
        static bool P(int a)
        {
            var s = a.ToString();
            for (int i = 0; i < s.Length / 2; i++)
            {
                if (s[i] != s[s.Length - i - 1]) return false;
            }
            return true;
        }
        
        static void Main(string[] args)
        {
            
            int n = 10;
            var random = new Random();
            List<int> selected = new List<int>();
            for (int i = 0; i < n; i++)
            {
                selected.Add(random.Next(1, 10000));
            }
            
            foreach (var i in selected)
            {
                Console.Write(i + " ");
            }
            Console.WriteLine();
            
            //1 - запрос 
            foreach (var i in selected)
            {
                if (i > 9 && i < 100 && (i % 3 == 0)) 
                    Console.Write(i + " ");
            }
            Console.WriteLine();
            
            
            //2 - запрос 
            selected.Sort();
            foreach (var i in selected)
            {
                if (P(i))
                    Console.Write(i + " ");
            }
            Console.WriteLine();
            
            //3 - запрос 
            foreach (var i in selected)
            {
                Console.Write(summ(i ) + " ");
            }
            Console.WriteLine();
            
            
            //4 - запрос 
            int sum = 0;
            foreach (var i in selected)
            {
                if (i > 999 && i < 10000)
                    sum = sum + i;
            }
            Console.Write(sum);
            Console.WriteLine();
            
            
            
            //5 - запрос 
            int min = 101;
            foreach (var i in selected)
            {
                if (i > 9 && i < 100 && (i < min))
                    min =  i;
            }
            if (min < 101) Console.Write(min);
            Console.WriteLine();
            
        }
    }
}