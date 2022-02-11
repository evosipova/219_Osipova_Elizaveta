using System;

namespace task3
{
    class Stack<T>
    {
        class Node<T>
        {
            internal T value;
            internal Node<T> prev;

            internal Node(T value, Node<T> prev)
                => (this.value, this.prev) = (value, prev);
        }

        private Node<T> head = null;
        private Node<T> tail = null;

        public bool IsEmpty()
            => head == null;

        public void Push(T t)
        {
            if (IsEmpty())
            {
                head = new Node<T>(t, null);
                tail = head;
            }
            else
            {
                tail = new Node<T>(t, tail);
            }
        }

        public int Size()
        {
            var currentNode = tail;
            var k = 1;
            while (currentNode != head)
            {
                currentNode = currentNode.prev;
                k++;
            }

            return k;
        }

        public T Pop()
        {
            if (IsEmpty())
            {
                throw new Exception("Stack is empty.");
            }

            var val = tail.value;
            tail = tail.prev;
            if (tail == null)
                head = null;
            return val;
        }

        public T Peek()
        {
            if (IsEmpty())
            {
                throw new Exception("Stack is empty.");
            }

            return tail.value;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var myStack = new Stack<int>();

            myStack.Push(1);
            myStack.Push(2);
            myStack.Push(3);
            Console.WriteLine(myStack.Size());
            Console.WriteLine(myStack.Peek());
            Console.WriteLine(myStack.Pop());
            Console.WriteLine(myStack.Pop());
            Console.WriteLine(myStack.Pop());
            try
            {
                Console.WriteLine(myStack.Pop());
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}