using System;
using System.Text;
namespace task1
{
    class Program  
    {
        static void Main(string[] args)
        {
            String[] str = Console.ReadLine().Split(';');
            string vowels = "AEIOUY";
            for (int i = 0; i < str.Length; i++)
            {
                StringBuilder sb = new StringBuilder("", str[i].Length);
                String[] str2 = str[i].Split();
                for (int m = 0; m < str2.Length; m++)
                {
                    for (int j = 0; j < str2[m].Length; j++)
                    {
                        if (j==0)
                        {
                            sb.Append(str2[m][j].ToString().ToUpper());
                        }
                        else                      
                        {
                            sb.Append(str2[m][j].ToString().ToLower());
                        }
                        if (vowels.Contains(str2[m][j]) || vowels.ToLower().Contains(str2[m][j]))
                        {
                            break;
                        }
                    }
                }
                Console.WriteLine(sb);
            }
        }
    }
}