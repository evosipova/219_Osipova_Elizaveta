using System;
class House<T> {
    public static int myValue;
    public string Adress { get; set; }
    public int Capacity { get; set; }
    public T Id { get; set; }
    public House(string a, int c, T id)
    {
        Adress = a;
        Capacity = c;
        Id = id;
    }
}
class Program {
    static void Main(string[] args)  {
        House<string> house1 =
            new House<string>("132", 100, "dwgr452");
        House<int> house2 =
            new House<int>("132", 100, 452);
        Console.WriteLine(house1.Id);
        Console.WriteLine(house2.Id);
        Console.WriteLine(house1.GetType());
        Console.WriteLine(house2.GetType());
        House<string>.myValue = 100;
        House<int>.myValue = 500;
        Console.WriteLine(House<string>.myValue);
        Console.WriteLine(House<int>.myValue);
    }
}