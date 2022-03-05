using System;
using System.Threading;

namespace Workspace
{
    class Program
    {
        static void Main(string[] args)
        {
            Thread current = Thread.CurrentThread;
            current.Name = "Name";
            Thread.Sleep(500);
            Console.WriteLine(current.Name);
            Thread.Sleep(500);
            Console.WriteLine(current.IsBackground);
            Thread.Sleep(500);
            Console.WriteLine(current.IsAlive);
            Thread.Sleep(500);
            Console.WriteLine(current.ManagedThreadId);
            Thread.Sleep(500);
            Console.WriteLine(current.Priority);
            Thread.Sleep(500);
            Console.WriteLine(current.ThreadState);
            Thread t1 = new Thread(() => Console.WriteLine(1));
            t1.Priority = ThreadPriority.Highest;
            Thread t2 = new Thread(() => Console.WriteLine(2));
            Thread t3 = new Thread(() => Console.WriteLine(3));
            t1.Start();
            t2.Start();
            t3.Start();
            Console.WriteLine("end");

            Thread t4 = new Thread((a) => Console.WriteLine(a));
            t4.Priority = ThreadPriority.Highest;
            Thread t5 = new Thread((a) => Console.WriteLine(a));
            Thread t6 = new Thread((a) => Console.WriteLine(a));
            t4.Start(4);
            t5.Start(5);
            t6.Start(6);
            Console.WriteLine("end");

            int x = 0;
            object locker = new object();
            for (int i = 0; i < 6; i++)
            {
                Thread thread = new Thread(Print);
                thread.Start();
            }

            void Print()
            {
                lock (locker)
                {
                    for (int i = 0; i < 6; i++)
                    {
                        x++;
                        Thread.Sleep(100);
                        Console.WriteLine($"{Thread.CurrentThread.ManagedThreadId} - {x}");
                    }
                }
            }
        }
    }
}