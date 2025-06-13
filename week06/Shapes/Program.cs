using System;
using System.Collections.Generic;

namespace Shapes
{
    class Program
    {
        static void Main(string[] args)
        {
            // Test individual Square class (before building the list)
            Square square1 = new Square("Blue", 5);
            Console.WriteLine($"Square Color: {square1.GetColor()}, Area: {square1.GetArea()}");

            // Test individual Rectangle class
            Rectangle rectangle1 = new Rectangle("Red", 4, 6);
            Console.WriteLine($"Rectangle Color: {rectangle1.GetColor()}, Area: {rectangle1.GetArea()}");

            // Test individual Circle class
            Circle circle1 = new Circle("Green", 3);
            Console.WriteLine($"Circle Color: {circle1.GetColor()}, Area: {circle1.GetArea()}");

            Console.WriteLine("\n--- Demonstrating Polymorphism with a List ---");

            // Create a list to hold different shapes
            List<Shape> shapes = new List<Shape>();

            // Add different kinds of shapes to the same list
            shapes.Add(new Square("Yellow", 7));
            shapes.Add(new Rectangle("Purple", 8, 2));
            shapes.Add(new Circle("Orange", 4.5f));
            shapes.Add(new Square("Black", 10)); // Add another square for variety

            // Iterate through the list and display their properties
            foreach (Shape shape in shapes)
            {
                Console.WriteLine($"Color: {shape.GetColor()}, Area: {shape.GetArea():F2}"); // :F2 for formatting float to 2 decimal places
            }
        }
    }
}`