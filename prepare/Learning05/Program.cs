using System;
using System.Globalization;
using System.Reflection.Metadata.Ecma335;
using System.Reflection.PortableExecutable;

class Program
{
    static void Main(string[] args)
    {
        List <Shape> shapes= new List<Shape>();
        shapes.Add(new Square("Blue",10));
        shapes.Add(new Rectangle("Green",10,2));
        shapes.Add(new Circle("Red",10));
        foreach (Shape shape in shapes)
        {
            Console.WriteLine($"Color: {shape.GetColor()}");
            Console.WriteLine($"Area: {shape.GetArea()}");
        }
    }
}