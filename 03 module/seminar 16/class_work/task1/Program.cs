using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Xml.Serialization;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Concurrent;
using System.Diagnostics;
 
namespace task1
{
    class Program
    {
        public static void Main(string[] args)
        {
            //Task task1 = new Task(() => Console.WriteLine("task 1"));
            //task1.Start();
 
            //Task task2 = Task.Factory.StartNew(() => Console.WriteLine("task 2"));
 
            //Task task3 = Task.Run(() => Console.WriteLine("task 3"));
            //task1.Wait();
            //task2.Wait();
            //task3.Wait();
 
            //var outer = Task.Factory.StartNew(() =>      // внешняя задача
            //{
            //    Console.WriteLine("Outer task starting...");
            //    var inner = Task.Factory.StartNew(() =>  // вложенная задача
            //    {
            //        Console.WriteLine("Inner task starting...");
            //        //Thread.Sleep(2000);
            //        Console.WriteLine("Inner task finished.");
            //    }, TaskCreationOptions.AttachedToParent);
            //});
            //outer.Wait(); // ожидаем выполнения внешней задачи
            //Console.WriteLine("End of Main");
 
            Task[] tasks = new Task[]
            {
                new Task(() => Console.WriteLine("task 1")),
                new Task(() => Console.WriteLine("task 2")),
                new Task(() => Console.WriteLine("task 3")),
            };
 
            foreach (var t in tasks)
                t.Start();
 

            //foreach (var t in tasks)
            //    t.Wait();
 
            Task.WaitAll(tasks);
        }
    }
}