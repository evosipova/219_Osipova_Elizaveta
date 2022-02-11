using System;
class MainClass
{
    public delegate bool Comp(int x, int y);

    public static void BubbleSort(int[] a, Comp c)
    {
        for (int i = 0; i < a.Length - 1; i++)
        for (int j = i + 1; j < a.Length; j++) 
            if (c(a[i], a[j]))
            { 
                int temp = a[i];
                a[i] = a[j]; 
                a[j] = temp;
            }
    }
    
    static void Main(string[] args)
    {
        int[] a = { 1, 9, 0, -10, 3, 5 };
        BubbleSort(a, (x, y) => (x > y));
        Array.ForEach(a, el => Console.Write(el + " "));
        Console.WriteLine();
        BubbleSort(a, (x, y) => (x < y));
        Array.ForEach(a, el => Console.Write(el + " "));
        Console.WriteLine();
        BubbleSort(a, (x, y) => (x % 2 == 1) & (y % 2 == 0));
        Array.ForEach(a, el => Console.Write(el + " "));
        Console.WriteLine();
    }
}