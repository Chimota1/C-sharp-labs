using System;

namespace PKPZ
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Write n");
            Random random = new Random();
            int n = int.Parse(Console.ReadLine());
            int[][] arr = new int[n][];
            int[] storage = new int[n];
            Fillarr(n,arr,random);
            PrintArr(arr);
            FindPaired(arr, storage);
            PrintStorage(storage);
        }

        public static void Fillarr(int n, int[][] arr,Random random)
        {
            for (int i = 0; i < n; i++)
            {
                int len = random.Next(1, n);
                arr[i] = new int[len];
                for (int j = 0; j < len; j++)
                {
                    arr[i][j] = random.Next(1, 10);
                }
            }
        }

        public static void PrintArr(int[][] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                for (int j = 0; j < arr[i].Length; j++)
                {
                    Console.Write($"{arr[i][j],5}");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        public static void FindPaired(int[][] arr, int[] storage)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                for (int j = 0; j < arr[i].Length; j++)
                {
                    if (arr[i][j] % 2 == 0)
                    {
                        storage[i] = arr[i][j];
                    }
                }
            }
        }

        public static void PrintStorage(int[] storage)
        {
            for (int i = 0; i < storage.Length; i++)
            {
                Console.Write($"{storage[i],3}");
            }
            Console.WriteLine();
        }
    }
}