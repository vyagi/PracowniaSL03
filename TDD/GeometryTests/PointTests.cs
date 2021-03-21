using FluentAssertions;
using Geometry;
using Xunit;

namespace GeometryTests
{
    public class PointTests
    {
        [Fact]
        public void Can_create_new_point()
        {
            var point = new Point(10, 40);

            point.X.Should().Be(10);
            point.Y.Should().Be(40);
        }

        [Fact]
        public void Can_create_new_point_with_double_parameters()
        {
            var point = new Point(1.4, 4.5);

            point.X.Should().Be(1.4);
            point.Y.Should().Be(4.5);
        }
    }
}
