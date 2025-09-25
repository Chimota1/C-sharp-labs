using System;

class Program
{
    static void Main(string[] args)
    {
        Random random = new Random();
        int[,] arr = new int[6, 4];

        Console.Write("Enter max number: ");
        int maxNumber = int.Parse(Console.ReadLine());
        
        FillArray(arr, random);

        Console.WriteLine("Original array:");
        PrintArray(arr);
        
        int max = FindMax(arr);
        Console.WriteLine($"Max element in array = {max}");
        
        int count, average;
        ProcessArray(arr, maxNumber, max, out count, out average);

        Console.WriteLine("Modified array:");
        PrintArray(arr);
        
        Console.WriteLine($"Count of replaced elements = {count}");
        Console.WriteLine($"Average of replaced elements = {average}");
    }
    
    static void FillArray(int[,] arr, Random random)
    {
        for (int i = 0; i < arr.GetLength(0); i++)
        {
            for (int j = 0; j < arr.GetLength(1); j++)
            {
                arr[i, j] = random.Next(-50, 49);
            }
        }
    }

    static void PrintArray(int[,] arr)
    {
        for (int i = 0; i < arr.GetLength(0); i++)
        {
            for (int j = 0; j < arr.GetLength(1); j++)
            {
                Console.Write($"{arr[i, j],5}");
            }
            Console.WriteLine();
        }
    }

    static int FindMax(int[,] arr)
    {
        int max = arr[0, 0];
        for (int i = 0; i < arr.GetLength(0); i++)
        {
            for (int j = 0; j < arr.GetLength(1); j++)
            {
                if (arr[i, j] > max)
                {
                    max = arr[i, j];
                }
            }
        }
        return max;
    }

    static void ProcessArray(int[,] arr, int maxNumber, int max, out int count, out int average)
    {
        count = 0;
        int sum = 0;
        average = 0;
        
        for (int i = 0; i < arr.GetLength(0); i++)
        {
            for (int j = 0; j < arr.GetLength(1); j++)
            {
                if (arr[i, j] > maxNumber)
                {
                    sum += arr[i, j];
                    arr[i, j] = max;
                    count++;
                }
            }
        }

        if (count > 0)
        {
            average = sum / count;
        }
    }
}
