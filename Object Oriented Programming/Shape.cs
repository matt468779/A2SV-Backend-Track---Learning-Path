using System.ComponentModel.DataAnnotations;

namespace Task2
{
    class Shape
    {
        public string? name;

        public virtual double CalculateArea()
        {
            return 0;
        }

        public virtual void PrintShapeArea()
        {
            Console.WriteLine("Area of a Shape");
        }
    }

    class Circle : Shape
    {
        double radius;
        public Circle(double r)
        {
            name = "Circle";
            radius = r;
        }

        public override double CalculateArea()
        {
            return Math.PI * radius * radius;
        }

        public override void PrintShapeArea()
        {
            Console.WriteLine($"Area of the ${name} is " + CalculateArea());
        }

    }

    class Rectangle : Shape
    {

        double width;
        double height;

        public Rectangle(double w, double h)
        {
            name = "Rectangle";
            width = w;
            height = h;
        }

        public override double CalculateArea()
        {
            return width * height;
        }

        public override void PrintShapeArea()
        {
            Console.WriteLine($"Area of the ${name} is " + CalculateArea());
        }
    }

    class Triangle : Shape
    {
        double bas;
        double height;

        public Triangle(double b, double h)
        {
            name = "Triangle";
            bas = b;
            height = h;
        }

        public override double CalculateArea()
        {
            return bas * height / 2;
        }

        public override void PrintShapeArea()
        {
            Console.WriteLine($"Area of the {name} is " + CalculateArea());
        }
    }
}
