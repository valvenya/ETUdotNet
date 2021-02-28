using System;
using System.Collections;
using System.Collections.Generic;

namespace task1
{
    public class List<T> : IEnumerable<T>
    {
        private Node _head;
        public int Count { get; private set; }

        private class Node
        {
            public T Data { get; }
            public Node Next { get; set; }

            public Node(T data)
            {
                Data = data;
            }
        }
        

        public void Add(T data)
        {
            Count++;
            if (_head == null)
            {
                _head = new Node(data);
            }
            else
            {
                var cur = _head;
                while (cur.Next != null)
                {
                    cur = cur.Next;
                }

                var newNode = new Node(data);
                cur.Next = newNode;
            }
        }

        public void Add(T data, int index)
        {
            if (index < 0 || index > Count)
            {
                throw new ListIndexOutOfBoundsException();
            }

            var cur = _head;
            Node prev = null;
            for (var i = 0; i < index; i++)
            {
                prev = cur;
                cur = cur.Next;
            }

            Count++;
            if (prev == null)
            {
                _head = new Node(data) { Next = cur };
            }
            else
            {
                var newNode = new Node(data);
                prev.Next = newNode;
                newNode.Next = cur;
            }
            
        }

        public void Remove(int index)
        {
            if (index < 0 || index >= Count)
            {
                throw new ListIndexOutOfBoundsException();
            }

            if (index == 0)
            {
                _head = _head.Next;
                Count--;
            }
            else
            {
                var cur = _head;
                var prev = _head;
                for (var i = 0; i < index; i++)
                {
                    prev = cur;
                    cur = cur.Next;
                }

                prev.Next = cur.Next;
                Count--;
            }
            
        }

        public void Clear()
        {
            Count = 0;
            _head = null;
        }

        public void Reverse()
        {
            var cur = _head;
            Node prev = null;
            while (cur != null)
            {
                var next = cur.Next;
                cur.Next = prev; 
                prev = cur;
                cur = next;
            }

            _head = prev;
        }

        public T Get(int index)
        {
            var cur = _head;
            for (var i = 0; i < index; i++)
            {
                cur = cur.Next;
            }

            return cur.Data;
        }

        public bool IsEmpty()
        {
            return _head == null;
        }
        
        public void Print()
        {
            if (_head == null)
            {
                Console.WriteLine("List is empty");
                return;
            }
            
            var cur = _head;
            Console.WriteLine("List elements:");
            var i = 0;
            while (cur != null)
            {
                Console.WriteLine(i + ": " + cur.Data);
                cur = cur.Next;
                i++;
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (var cur = _head; cur != null; cur = cur.Next)
            {
                yield return cur.Data;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
}