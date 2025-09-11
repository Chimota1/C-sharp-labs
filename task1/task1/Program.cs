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
        IsIncludeInRectangle(x,y,R);
        IsIncludeInCircle(x,y,R);
    }
    public static void IsIncludeInRectangle(int x, int y, int R)
    {
        if ((x > 0 && x < (2*R)) && (y > -R && y < 0))
        {
            Console.WriteLine("The point match in rectangle");
        }
        else if ((x == 0 || x == (2 * R)) || (y == -R || y == 0))
        {
            Console.WriteLine("on the verge in rectangle");
        }
        else
        {
            Console.WriteLine("not in rectangle");
        }
    }
    public static void IsIncludeInCircle(int x,int y, int R)
    {
        if ((x * x) + ((y - R) * (y - R)) < (R * R))
        {
            Console.WriteLine("The circle is inside");
        }
        else if ((x * x) + ((y - R) * (y - R)) == (R * R))
        {
            Console.WriteLine("The circle equation is on the verge");
        }
        else
        {
            Console.WriteLine("not in circle");
        }
    }
}