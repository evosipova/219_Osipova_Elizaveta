using System;
using System.Collections.Generic;

namespace task2
{
    class Program
    {
        public delegate double DelegateConvertTemperature(double n);
        class TemperatureConverterlmp
        {
            public double FC(double temp)
            {
               return ((double) 5 / 9 * (temp - 32));
            }
            public double CF(double temp)
            {
                return ((double) 9 / 5 * temp + 32);
            }
        }

        class StaticTempConverters
        {
            public static double CK(double temp)
            { return temp + 273.15; }
            public static double KC(double temp)
            { return temp - 273.15; }
            public static double CR(double temp) => (temp + 273.15) * (double) 9 / 5;
            public static double RC(double temp) => (temp - 491.67) * (double) 5 / 9;
            public static double CRe(double temp) => temp * (double) 4 / 5;
            public static double ReC(double temp) => temp * (double) 5 / 4;
        
        }
        static void Main(string[] args)
        {
            DelegateConvertTemperature D1 = new TemperatureConverterlmp().CF;
            DelegateConvertTemperature D2 = new TemperatureConverterlmp().FC;
            Console.WriteLine(D1(145.63));
            Console.WriteLine(D2(24.45));
            TemperatureConverterlmp tempConverter = new TemperatureConverterlmp();
            DelegateConvertTemperature temp1 = new DelegateConvertTemperature(tempConverter.FC);
            DelegateConvertTemperature temp2 = new DelegateConvertTemperature(tempConverter.CF);
            DelegateConvertTemperature[] arrConverters = { temp1 };
            DelegateConvertTemperature temp3 = new DelegateConvertTemperature(StaticTempConverters.CK);
            DelegateConvertTemperature temp4 = new DelegateConvertTemperature(StaticTempConverters.CR);
            DelegateConvertTemperature temp5 = new DelegateConvertTemperature(StaticTempConverters.CRe);
            arrConverters = new DelegateConvertTemperature[] {temp2,temp3,temp4,temp5};
            Console.Write("Введите температуру в Цельсиях(С°): ");
            int temp;
            while (!int.TryParse(Console.ReadLine(), out temp)) Console.Write("Необходимо ввести целое число, температуру в Цельсиях(С°):");
            foreach(var del in arrConverters) 
                Console.WriteLine(del.Method.Name + " : " + del(temp)+ "°");
        }
    }
}