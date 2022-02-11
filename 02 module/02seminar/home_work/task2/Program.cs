using System;

namespace task2
{
    class Program
    {
            public class ConsolePlate
            {
                char _plateChar; //Символ.
                ConsoleColor _plateColor = ConsoleColor.White;//Цвет символа.
                ConsoleColor _backColor = ConsoleColor.Black;
                public ConsolePlate(char plateChar, ConsoleColor plateColor, ConsoleColor backColor)
                {
                    if (plateColor == backColor)
                    {
                        Console.WriteLine("!");
                        return;
                    }
                    PlateChar = plateChar;
                    PlateColor = plateColor;
                    BackColor = backColor;
                }
                public char PlateChar
                {
                    set
                    {
                        if (value >= 65 || value <= 90) _plateChar = value; //Отбрасываем командовые символы.
                        else _plateChar = 'A';
                    }
                    get { return _plateChar; }
                }
                public ConsoleColor PlateColor
                {
                    set { _plateColor = value; }
                    get { return _plateColor; }
                }
                public ConsoleColor BackColor
                {
                    get { return _backColor; }
                    set { _backColor = value; }
                }
        
            }
        static void Main( )
        {
            ConsolePlate s1 = new ConsolePlate('X', ConsoleColor.White, ConsoleColor.Red);
            ConsolePlate s2 = new ConsolePlate('O', ConsoleColor.White, ConsoleColor.Magenta);
            int n; string number;
            do
            {
                number = Console.ReadLine();
            } while (!int.TryParse(number, out n) || n < 2 || n > 35);
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (i % 2 != 0)
                    {
                        if (j % 2 != 0)
                        {
                            Console.ForegroundColor = s1.PlateColor;
                            Console.BackgroundColor = s1.BackColor;
                            Console.Write(s1.PlateChar);
                        }
                        else if (j % 2 == 0)
                        {
                            Console.ForegroundColor = s2.PlateColor;
                            Console.BackgroundColor = s2.BackColor;
                            Console.Write(s2.PlateChar);
                        }
                    }
                    else if (i % 2 == 0)
                    {
                        if (j % 2 == 0)
                        {
                            Console.ForegroundColor = s1.PlateColor;
                            Console.BackgroundColor = s1.BackColor;
                            Console.Write(s1.PlateChar);
                        }
                        else if (j % 2 != 0)
                        {
                            Console.ForegroundColor = s2.PlateColor;
                            Console.BackgroundColor = s2.BackColor;
                            Console.Write(s2.PlateChar);
                        }
                    }
                }
            }
        }
    }
}