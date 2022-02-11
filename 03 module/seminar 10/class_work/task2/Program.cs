using System;

namespace task2
{
    class Program
    {
        static void Main(string[] args)
        {
            MyStack<int> stack = new MyStack<int>();
            stack.Push(2);
            stack.Push(6);
            stack.Push(10);
            Console.WriteLine($"Size: {stack.Size()}");
            Console.WriteLine($"Peek: {stack.Peek()}");
            Console.WriteLine($"Pop: {stack.Pop()}");
            Console.WriteLine($"Size: {stack.Size()}");
            Console.WriteLine($"Peek: {stack.Peek()}");
            Console.WriteLine($"IsEmpty: {stack.IsEmpty()}");
        }
    }

    public class MyStack<T>
    {
        private MyNode<T> lastNode;
        private int size;

        public MyStack()
        {
            lastNode = null;
            size = 0;
        }

        public void Push(T item)
        {
            MyNode<T> myNode = new MyNode<T>(item, lastNode);
            lastNode = myNode;
            size++;
        }

        public T Pop()
        {
            T item = lastNode.Item;
            lastNode = lastNode.PreviousNode;
            size--;
            return item;
        }

        public T Peek()
        {
            return lastNode.Item;
        }

        public int Size()
        {
            return size;
        }

        public bool IsEmpty()
        {
            return size == 0;
        }
    }

    public class MyNode<T>
    {
        public T Item { get; set; }
        public MyNode<T> PreviousNode { get; set; }

        public MyNode(T item, MyNode<T> previousNode)
        {
            Item = item;
            PreviousNode = previousNode;
        }
    }
}