using System;

namespace task3
{

    class A
    {
        public event EventHandler OnSomething;

        public void Test()
        {
            for (int i = 0; i < 10; i++)
            {
                if (i == 1)
                {
                     OnSomething(); 
                }
                
            }
                       
        }
            
    }
    
    public delegate void EventHandler();

    class B
    {
        public void Event()
        {

            Console.WriteLine("1");
        }


    }

    class Program
    {
        static void Main(string[] args)
        {
            A a = new A();
            B b = new B();
            a.OnSomething += b.Event;
            a.Test();
        }
    }
}