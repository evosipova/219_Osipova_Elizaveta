using System;
namespace task2
{
    class AccountEventArgs
    {
        public string Str { get; }
        public AccountEventArgs(string s) => Str = s;
    }
    //public delegate void AccountHandler(string s);
    class Account
    {
        public event EventHandler<AccountEventArgs> Notify;
        public int Sum { get; set; }
        public Account(int sum) => Sum = sum;
        public void Put(int sum)
        {
            Sum += sum;
            Notify?.Invoke(this, new AccountEventArgs("Put" + sum));
        }
        public void Take(int sum)
        {
            Sum -= sum;
            Notify?.Invoke(this, new AccountEventArgs("Take" + sum));
        }
    }
    class Program
    {
        public void Print(object sender, AccountEventArgs s)
        {
            Console.WriteLine(s.Str);
        }
        public static void Print2(object sender, AccountEventArgs s)
        {
            Console.WriteLine(s.Str);
        }
        static void Main(string[] args)
        {
            Account account = new Account(1000);
            account.Notify += (new Program()).Print;
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