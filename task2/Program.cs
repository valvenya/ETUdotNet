using System;

namespace task2
{
    class Program
    {
        static void Main(string[] args)
        {
            //testing
            var tree = new BinaryTree<string>();
            int[] arr = {10, 5, 9, 8, 14, 3, 6};

            foreach (var num in arr)
            {
                tree.Add(num, num.ToString());
            }

            foreach (var num in arr) 
            {
                Console.WriteLine(tree.Search(num));
            }
            
            tree.Print();

            foreach (var num in arr)
            {
                try
                {
                    tree.Remove(num);
                   // tree.Remove(num);
                }
                catch (KeyNotFoundException)
                {
                    Console.WriteLine("Key not found in remove");
                }
            }

            foreach (var num in arr)
            {
                try
                {
                    tree.Search(num);
                }
                catch (KeyNotFoundException)
                {
                    Console.WriteLine("Key not found");
                }
            }
            tree.Print();
        }
    }
}