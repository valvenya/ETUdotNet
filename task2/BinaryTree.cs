using System;

namespace task2
{
    public class BinaryTree<T>
    {
        private Node _root;
        public int Count { get; private set;  }
        private class Node
        {
            public T Data { get; }
            public int Key { get; }
            
            public Node Left { get; set; }
            public Node Right { get; set; }
            public Node Parent { get; set; }
            
            public Node(int key, T data)
            {
                Data = data;
                Key = key;
            }
        }

        public void Add(int key, T data)
        {
            if (_root == null)
            {
                _root = new Node(key, data);
                Count++;
            }
            else
            {
                var cur = _root;
                while (true)
                {
                    if (key == cur.Key)
                    {
                        throw new DuplicateKeyException();
                    }
                    
                    if (key < cur.Key)
                    {
                        if (cur.Left != null)
                        {
                            cur = cur.Left;
                        }
                        else
                        {
                            var newNode = new Node(key, data) { Parent = cur };
                            cur.Left = newNode;
                            Count++;
                            return;
                        }
                    }
                    else
                    {
                        if (cur.Right != null)
                        {
                            cur = cur.Right;
                        }
                        else
                        {
                            var newNode = new Node(key, data) { Parent = cur };
                            cur.Right = newNode;
                            Count++;
                            return;
                        }
                    }
                }
            }
        }

        public T Search(int key)
        {
            if (_root == null)
            {
                throw new KeyNotFoundException();
            }
            
            var cur = _root;
            while (true)
            {
                if (cur.Key == key)
                {
                    return cur.Data;
                }

                if (key < cur.Key)
                {
                    if (cur.Left != null)
                    {
                        cur = cur.Left;
                    }
                    else
                    {
                        throw new KeyNotFoundException();
                    }
                }
                else
                {
                    if (cur.Right != null)
                    {
                        cur = cur.Right;
                    }
                    else
                    {
                        throw new KeyNotFoundException();
                    }
                }
            }
        }

        public void Remove(int key)
        {
            if (_root == null)
            {
                throw new KeyNotFoundException();
            }
            var cur = _root;
            while (true)
            {
                if (cur.Key == key)
                {
                    break;
                }

                if (key < cur.Key)
                {
                    if (cur.Left != null)
                    {
                        cur = cur.Left;
                    }
                    else
                    {
                        throw new KeyNotFoundException();
                    }
                }
                else
                {
                    if (cur.Right != null)
                    {
                        cur = cur.Right;
                    }
                    else
                    {
                        throw new KeyNotFoundException();
                    }
                }
            }

            var parent = cur.Parent;
            if (parent == null)
            {
                if (Count == 1)
                {
                    _root = null;
                    Count = 0;
                }
                else
                {
                    Count--;
                    if (cur.Left == null)
                    {
                        _root = cur.Right;
                        _root.Parent = null;
                    }
                    else if (cur.Right == null)
                    {
                        _root = cur.Left;
                        _root.Parent = null;
                    }
                    else
                    {
                        var cur2 = cur.Left;
                        while (cur2.Right != null)
                        {
                            cur2 = cur2.Right;
                        }

                        _root = cur.Left;
                        _root.Parent = null;
                        cur2.Right = cur.Right;
                        cur.Right.Parent = cur2;
                    }
                }
            }
            else
            {
                Count--;
                var isRight = cur == parent.Right;
                if (cur.Left == null && cur.Right == null)
                {
                    if (isRight)
                    {
                        parent.Right = null;
                    }
                    else
                    {
                        parent.Left = null;
                    }
                }
                else if (cur.Left == null)
                {
                    cur.Right.Parent = parent;
                    if (isRight)
                    {
                        parent.Right = cur.Right;
                    }
                    else
                    {
                        parent.Left = cur.Right;
                    }
                }
                else if (cur.Right == null)
                {
                    cur.Left.Parent = parent;
                    if (isRight)
                    {
                        parent.Right = cur.Left;
                    }
                    else
                    {
                        parent.Left = cur.Left;
                    }
                }
                else
                {
                    var cur2 = cur.Left;
                    while (cur2.Right != null)
                    {
                        cur2 = cur2.Right;
                    }

                    if (isRight)
                    {
                        parent.Right = cur.Left;
                    }
                    else
                    {
                        parent.Left = cur.Left;
                    }

                    cur.Left.Parent = parent;
                    cur2.Right = cur.Right;
                    cur.Right.Parent = cur2;
                }
            }
        }
        
        //prints sorted array (depth traverse)
        private static void _print(Node cur)
        {
            if (cur.Left != null)
            {
                _print(cur.Left);
            }
            Console.WriteLine(cur.Data);
            if (cur.Right != null)
            {
                _print(cur.Right);
            }
        }
        public void Print()
        {
            if (_root == null)
            {
                Console.WriteLine("Tree is empty");
            }
            else
            {
                Console.WriteLine("Tree elements sorted:");
                _print(_root);
            }
        }
    }
}