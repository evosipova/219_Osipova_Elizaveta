/*
 Класс Plant. Закрытые вещественные поля: рост (growth), светочувствительность(photosensitivity) и морозоустойчивость(frostresistance).
 */
using System;
namespace task1
{
    class Plant
    {
        private double growth; //рост
        private double photosensiuvity; //светочувствительность
        private double frostresistance; //морозоустойчивость

        public double Growth
        {
            get { return growth; }
            set { growth = value; }
        }

        public double Photosensiuvity
        {
            get { return photosensiuvity; }
            set
            {
                if (value >= 0 && value <= 100)
                    photosensiuvity = value;
                else photosensiuvity = 0;
            }
        }

        public double Frostresistance
        {
            get { return frostresistance; }
            set
            {
                if (value >= 0 && value <= 100)
                    frostresistance = value;
                else frostresistance = 0;
            }
        }

        public Plant(double growth, double photosensiuvity, double frostresistance)
        {
            Growth = growth;
            Photosensiuvity = photosensiuvity;
            Frostresistance = frostresistance;
        }

        public override string ToString()
        {
            return $"Growth: {Growth}, Photosensivity: {Photosensiuvity}, Frostresistance: {Frostresistance}.";
        }
    }

    
    class Program
    {
        public static int Swap(Plant x, Plant y)
        {
            return ((int) x.Photosensiuvity  == (int) y.Photosensiuvity) ? x.Photosensiuvity.CompareTo(y.Photosensiuvity) : (int) x.Photosensiuvity.CompareTo((int) y.Photosensiuvity);
        }
        
        static void Main(string[] args)
        {
            var random = new Random();
            Console.WriteLine("Введите ЦЕЛОЕ число n(количество растений):");
            int n; //Количесвто растений.
            while (!int.TryParse(Console.ReadLine(), out  n))
            {
                 Console.WriteLine("Введите ЦЕЛОЕ число:");
            }
            Plant[] arrayPlants = new Plant[n];
            for (int i = 0; i < n; i++)
            {
                arrayPlants[i] = new Plant((double) random.Next(25,101), (double) random.Next(0,101), (double) random.Next(0,81));
            }
            //Выведите на экран, используя метод Array.ForEach(), сведения о растениях из массива.
            Array.ForEach(arrayPlants, plant => Console.WriteLine(plant));
            Console.WriteLine();
            
            //Отсортируйте массив с использованием метода Array.Sort() по убыванию роста и снова выведите. Используйте анонимный метод. 
            Array.Sort(arrayPlants, delegate(Plant plant, Plant plant1) { return plant.Growth > plant1.Growth ? -1 : 1; });
            Array.ForEach(arrayPlants, plant => Console.WriteLine(plant));
            Console.WriteLine();
            
            //Затем отсортируйте массив с использованием метода Array.Sort() по возрастанию морозоустойчивости и выведите на экран.
            //Используйте лямбда-выражение.
            Array.Sort(arrayPlants, (plant, plant1) => plant.Growth < plant1.Growth ? -1 : 1);
            Array.ForEach(arrayPlants, plant => Console.WriteLine(plant));
            Console.WriteLine();
            
            //Затем отсортируйте массив с использованием метода Array.Sort() по четности светочувствительности и выведите на экран.
            //Используйте самостоятельно определенный метод.
            Array.Sort(arrayPlants, Swap);
            Array.ForEach(arrayPlants, plant => Console.WriteLine(plant));
            Console.WriteLine();
            
            //Измените параметр морозоустойчивость у всех растений массива, используя метод Array.ConvertAll().
            //Морозоустойчивость меняем по следующему правилу: четные значения уменьшаем в 3 раза, нечетные значения уменьшаем в 2 раза.
            Array.ConvertAll(arrayPlants, plant => plant.Frostresistance = (plant.Frostresistance % 2 == (0) )? plant.Frostresistance / 3 : plant.Frostresistance / 2);
            Array.ForEach(arrayPlants, plant => Console.WriteLine(plant));
            Console.WriteLine();
        }
    }
}