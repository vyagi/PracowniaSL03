using System;

namespace Geometry
{
    public class Point
    {
        private readonly double _x;
        private readonly double _y;
        public enum ReflectionType
        {
            X,
            Y,
            Origin
        }

        public Point(double x, double y)
        {
            _x = x;
            _y = y;
        }

        public Point() : this(1,1) { }

        public double X => _x;
        public double Y => _y;

        public double Distance() => Math.Sqrt(X*X + Y*Y);

        public double Distance(Point another) => 
            Math.Sqrt(Math.Pow(X - another.X,2) + Math.Pow(Y - another.Y, 2));

        public static double Distance(Point first, Point second) => 
            first.Distance(second);

        public override string ToString() => $"({X},{Y})";

        public Point Reflect(ReflectionType reflectionType) =>
            reflectionType switch
            {
                ReflectionType.X => new Point(X, -Y),
                ReflectionType.Y => new Point(-X, Y),
                ReflectionType.Origin => new Point(-X, -Y),
                _ => throw new ArgumentOutOfRangeException(nameof(reflectionType), reflectionType, null)
            };
    }
}