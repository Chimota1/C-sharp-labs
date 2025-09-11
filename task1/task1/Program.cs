// See https://aka.ms/new-console-template for more information

using System;


class Program
{
    static void Main(string[] args)
    {
        const int R = 15;
        Console.WriteLine("Enter the coordinates of the point x: ");
        int x = int.Parse(Console.ReadLine());
        Console.WriteLine("Enter the coordinates of the point y: ");
        int y = int.Parse(Console.ReadLine());
        Isinclude(x,y,R);
    }
    public static void Isinclude(int x, int y, int R)
    {
        if ((x > 0 && x < (2*R)) && (y > -R && y < 0))
        {
            Console.WriteLine("The point match in rectangle");
        }
    }
}