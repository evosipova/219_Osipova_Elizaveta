using System;
namespace task1
{
    public delegate void AccountHandler(string s);
    class Account
    {
        public event AccountHandler Notify;
        public int Sum { get; set; }
        public Account(int sum) => Sum = sum;
        public void Put(int sum)
        {
            Sum += sum;
            Notify?.Invoke("Put" + sum);
        }
        public void Take(int sum)
        {
            Sum -= sum;
            Notify?.Invoke("Take" + sum);
        }
    }
    class Program
    {
        public static void Print(string s)
        {
            Console.WriteLine(s);
        }
        public static void Print2(string s)
        {
            Console.WriteLine(s);
        }
        static void Main(string[] args)
        {
            Account account = new Account(1000);
            account.Notify += Print;
            account.Notify += Print2;
            account.Take(100);
            Console.WriteLine(account.Sum);
            account.Take(100);
            Console.WriteLine(account.Sum);
            account.Put(100);
            Console.WriteLine(account.Sum);
        }
    }
}