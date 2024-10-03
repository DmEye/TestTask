using System.Numerics;
using System.Reflection.Metadata;

namespace TestLib
{
    public interface IShape
    {
        double Area { get; }
    }

    public class Circle : IShape
    {
        private readonly double radius;

        public Circle(double rad)
        {
            if (rad < 0)
                throw new ArgumentException("Радиус должен быть положительным");

            radius = rad;
        }

        public double Area => Math.PI * radius * radius;
    }

    public class Triangle : IShape
    {
        private readonly double sideA, sideB, sideC;

        public Triangle(double a, double b, double c)
        {
            if (a <= 0 || b <= 0 || c <= 0)
                throw new ArgumentException("Длина сторон должна быть положительной");
            if (a + b <= c || a + c <= b || b + c <= a)
                throw new ArgumentException("Невозможные стороны треугольника");

            sideA = a;
            sideB = b;
            sideC = c;
        }

        public double Area
        {
            get
            {
                double s = (sideA + sideB + sideC) / 2;
                return Math.Sqrt(s * (s - sideA) * (s - sideB) * (s - sideC));
            }
        }

        public bool IsRightTriangle()
        {
            double[] sides = new[] { sideA, sideB, sideC };
            Array.Sort(sides);
            return Math.Abs(Math.Pow(sides[0], 2) + Math.Pow(sides[1], 2) - Math.Pow(sides[2], 2)) < 1e-10;
        }
    }

    public class ShapeAreaCalculator
    {
        public static double CalculateArea(IShape shape)
        {
            return shape.Area;
        }
    }
}
