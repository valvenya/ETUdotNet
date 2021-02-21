using System;

namespace task1
{
    public class List
    {
        private Node _head;
        public int Count { get; private set; }

        private class Node
        {
            public string Data { get; set; }
            public Node Next { get; set; }

            public Node(string data)
            {
                Data = data;
            }
        }

        public void Add(string data)
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

        public void Add(string data, int index)
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

        public string Get(int index)
        {
            var cur = _head;
            for (var i = 0; i < index; i++)
            {
                cur = cur.Next;
            }

            return cur.Data;
        }
        
        
        public void Print()
        {
            if (_head == null)
            {
                Console.WriteLine("List is empty\n");
                return;
            }
            
            var cur = _head;
            Console.WriteLine("List elements:\n");
            var i = 0;
            while (cur != null)
            {
                Console.WriteLine(i + ": " + cur.Data);
                cur = cur.Next;
                i++;
            }
        }
    }
    
}