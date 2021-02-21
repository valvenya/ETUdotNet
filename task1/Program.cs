using System;

namespace task1
{
    class Program
    {
        static void Main(string[] args)
        {
            var list = new List();
            list.Add("hi");
            list.Add("i am list");
            list.Add("cool");
            list.Print();
            list.Add("0th element", 0);
            list.Add("another element", 2);
            list.Print();
            list.Reverse();
            list.Print();
            list.Remove(0);
            list.Remove(2);
            list.Print();
        }
    }
}