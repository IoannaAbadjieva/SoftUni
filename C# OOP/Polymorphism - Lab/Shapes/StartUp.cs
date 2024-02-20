namespace Shapes
{
    using System;

    public class StartUp
    {
        static void Main(string[] args)
        {
            Shape circle = new Circle(5);
            Shape rectangle = new Rectangle(5,2.5);

            Console.WriteLine(circle.CalculateArea());
            Console.WriteLine(circle.Draw());
            Console.WriteLine(rectangle.CalculatePerimeter());
            Console.WriteLine(rectangle.Draw());

        }
    }
}
