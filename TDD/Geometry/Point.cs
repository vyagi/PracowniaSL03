namespace Geometry
{
    public class Point
    {
        private readonly double _x;
        private readonly double _y;

        public Point(double x, double y)
        {
            _x = x;
            _y = y;
        }

        public double X => _x;
        public double Y => _y;
    }
}