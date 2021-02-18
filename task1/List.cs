using System;

namespace task1
{
    public class List
    {
        private class Node
        {
            public string Data { get; set; }
            public Node Next { get; set; }

            public Node(string data)
            {
                Data = data;
            }
        }

        private Node _head;

        public void Add(string data)
        {
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

        public void Remove(int index)
        {
            if (_head == null)
            {
                return;
            }

            var cur = _head;
            for (var i = 0; i < index; i++)
            {
                cur = cur.Next;
            }
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