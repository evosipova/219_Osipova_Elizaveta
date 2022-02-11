using System;
namespace Task1
{
    //инвариант
    class Base { }
    class Derived : Base { }
    interface IInvariant<T>
    {
        T Print(T a);
    }
    class ClassInvarinatBase : IInvariant<Base>
    {
        public Base Print(Base a)
        {
            Console.WriteLine(a);
            return a;
        }
    }
    class ClassInvarinatDerived : IInvariant<Derived>
    {
        public Derived Print(Derived a)
        {
            Console.WriteLine(a);
            return a;
        }
    }
    interface ICovariant<out T>
    {
        T Print();
    }
    class ClassCovariantBase : ICovariant<Base>
    {
        public Base Print()
        {
            return new Derived();
        }
    }
    class ClassCovariantDerived : ICovariant<Derived>
    {
        public Derived Print()
        {
            return new Derived();
        }
    }
    interface IContrvariant<in T>
    {
        void Print(T t);
    }
    class ClassContrvariant<T> : IContrvariant<T>
    {
        public void Print(T t)
        {
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            IInvariant<Base> inv1 = new ClassInvarinatBase();
            //IInvariant<Base> inv2 = new ClassInvarinatDerived();
            IInvariant<Derived> inv3 = new ClassInvarinatDerived();
            //IInvariant<Derived> inv4 = new ClassInvarinatBase();
            ICovariant<Base> cov1 = new ClassCovariantBase();
            ICovariant<Base> cov2 = new ClassCovariantDerived();
            ICovariant<Derived> cov3 = new ClassCovariantDerived();
            //ICovariant<Derived> cov4 = new ClassCovariantBase();
            IContrvariant<Base> cont1 = new ClassContrvariant<Base>();
            //IContrvariant<Base> cont2 = new ClassContrvariant<Derived>();
            IContrvariant<Derived> cont3 = new ClassContrvariant<Derived>();
            IContrvariant<Derived> cont4 = new ClassContrvariant<Base>();
        }
    }
}