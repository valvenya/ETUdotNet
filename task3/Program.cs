using System;

namespace task3
{
    class Program
    {
        private static int[] InsertionSort(int[] arr)
        {
            for (var i = 1; i < arr.Length; i++)
            {
                var curElem = arr[i];
                var j = i - 1;
                while (j >= 0 && arr[j] > curElem)
                {
                    arr[j + 1] = arr[j];
                    j -= 1;
                }
                arr[j + 1] = curElem;
            }

            return arr;
        }
        
        static void Main(string[] args)
        {
            var rand = new Random();
            int n = rand.Next(15);
            int[] arr = new int[n];
            for (var i = 0; i < n; i++)
            {
                arr[i] = rand.Next(100);
            }
            foreach (var num in arr)
            {
                Console.Write(num + " ");
            }
            Console.Write("\n");
            foreach (var num in InsertionSort(arr))
            {
                Console.Write(num + " ");
            }
        }
    }
}