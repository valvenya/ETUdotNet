using System;

namespace task1
{
    class Program
    {
        static void Main(string[] args)
        {
            //testing
            var list = new List<string>();
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
            Console.WriteLine(list.Get(0));
            Console.WriteLine(list.Count);
            list.Clear();
            list.Print();
            list.Add("test");
            try
            {
                list.Add("exception", 123);
            }
            catch (ListIndexOutOfBoundsException)
            {
                Console.WriteLine("Exception at add worked");
            }
            try
            {
                list.Remove(123);
            }
            catch (ListIndexOutOfBoundsException)
            {
                Console.WriteLine("Exception at remove worked");
            }
            
            list.Remove(0);
            list.Print();
            if (list.IsEmpty())
            {
                Console.WriteLine("Function IsEmpty() working");
            }

            var list2 = new List<int>();
            list2.Add(1);
            list2.Add(4);
            list2.Add(5);
            list2.Print();
            foreach (var num in list2) 
            {
                Console.WriteLine(num*num);
            }
        }
    }
}