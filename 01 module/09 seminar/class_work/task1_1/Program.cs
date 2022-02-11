using System;
namespace task1_1
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string[] arr = input.Split(';');
            string vowels = "aeiouy";
            foreach (string sent in arr)
            {
                string[] words = sent.Split();
                foreach (var word in words)
                {
                    for (int i = 0; i < word.Length; i++)
                    {
                        if (i == 0)
                        {
                            Console.Write(word[i].ToString().ToUpper());
                            if (vowels.Contains(word[i].ToString().ToLower()))
                                break;
                            continue;
                        }
                        Console.Write(word[i]);
                        if (vowels.Contains(word[i].ToString().ToLower())) break;
                    }
                    
                }
                Console.WriteLine();
            }
        }
    }
}