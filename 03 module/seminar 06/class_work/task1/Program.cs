using System;
using System.Collections.Generic;

namespace task1
{


// композиция
    class Animal
    {
        Brain brain;

        public Animal()
        {
            brain = new Brain();
        }
    }

    class Brain
    {
    }

// агрегация
    class Car
    {
        Wheel wheel;

        public Car(Wheel wheel)
        {
            this.wheel = wheel;
        }
    }

    class Wheel
    {
    }

    class Program
    {
        static void Main(string[] args)
        {

        }
    }
}