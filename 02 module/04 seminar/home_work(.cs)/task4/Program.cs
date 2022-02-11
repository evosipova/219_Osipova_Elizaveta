using System;
using System.Collections.Generic;

namespace TaskSetSolution
{
    // Сиквел.
    // У Склад.LIFE большое количество различных складов с различными видами товаров.
    // Руководству важно знать, какие виды товаров находятся на различных складах. Помогите Склад.LIFE. 
    // P.S. В последнее время с заказами все плохо, поэтому на склад только завозят новые виды товаров.
    //
    // На вход программе поступают следующие запросы:
    // 1) add <storage_name> <product_name> - добавить вид товара на склад.
    // 2) get <storage_name> - получить список всех видов товаров на складе.
    // 3) exist <storage_name> <product_name> - узнать находится ли вид товара на складе.
    // 4) exit - завершить программу.

    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                RedisClient.Connect("redis-10799.c290.ap-northeast-1-2.ec2.cloud.redislabs.com");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return;
            }

            string com = "";

            string st;
            string pr;
            while (com != "exit")
            {
                Console.Write("input: ");
                com = Console.ReadLine();
                try
                {
                    string[] inputLines = com.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                    string command = inputLines[0];
                    switch (command)
                    {
                        case "add":
                            st = inputLines[1];
                            pr = inputLines[2];
                            RedisClient.Add(st, pr);
                            Console.WriteLine("New product set");
                            break;
                        case "get":
                            st = inputLines[1];
                            if (RedisClient.Exist(st))
                            {
                                List<string> products = RedisClient.GetPr(st);
                                foreach (string t in products)
                                    Console.WriteLine(t);
                            }
                            else { Console.WriteLine("Request failed"); }
                            break;
                        case "exist":
                            st = inputLines[1];
                            pr = inputLines[2];
                            if (RedisClient.ExistPr(st, pr)) Console.WriteLine($"Product {pr} found in {st}");
                            else Console.WriteLine($"Product {pr} found in {st}");
                            break;
                        case "exit": break;
                        default:
                            Console.WriteLine("Сommand not found"); break;
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("Incorrect input");
                }
            }
        }
    }
}