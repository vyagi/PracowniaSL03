using System;
using System.Collections.Generic;
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

        [Fact]
        public void Can_create_new_point_without_parameters()
        {
            var point = new Point();

            point.X.Should().Be(1);
            point.Y.Should().Be(1);
        }

        [Theory]
        [MemberData(nameof(PointData))]
        public void Distance_is_calculated_correctly(double x, double y, double expectedDistance)
        {
            var point = new Point(x, y);

            var distance = point.Distance();

            distance.Should().Be(expectedDistance);
        }

        [Fact]
        public void Distance_from_another_point_is_calculated_properly()
        {
            var point1 = new Point(-3, 6);
            var point2 = new Point(3, 14);

            var distance = point1.Distance(point2);

            distance.Should().Be(10);
        }

        [Fact]
        public void Static_distance_between_two_points_is_calculated_properly()
        {
            var point1 = new Point(-3, 6);
            var point2 = new Point(3, 14);

            var distance = Point.Distance(point1, point2);

            distance.Should().Be(10);
        }

        [Fact]
        public void ToString_returns_valid_string_representation()
        {
            var point = new Point(-3, 6);

            var stringRepresentation = point.ToString();

            stringRepresentation.Should().Be("(-3,6)");
        }

        [Fact]
        public void Reflection_along_x_should_change_proper_coordinate()
        {
            var point = new Point(-3, 6);

            var reflection= point.Reflect(Point.ReflectionType.X);

            reflection.X.Should().Be(-3);
            reflection.Y.Should().Be(-6);
        }

        [Fact]
        public void Reflection_along_y_should_change_proper_coordinate()
        {
            var point = new Point(-3, 6);

            var reflection = point.Reflect(Point.ReflectionType.Y);

            reflection.X.Should().Be(3);
            reflection.Y.Should().Be(6);
        }

        [Fact]
        public void Reflection_with_origin_should_change_proper_coordinate()
        {
            var point = new Point(-3, 6);

            var reflection = point.Reflect(Point.ReflectionType.Origin);

            reflection.X.Should().Be(3);
            reflection.Y.Should().Be(-6);
        }

        public static IEnumerable<object[]> PointData = new List<object[]>
        {
            new object[] { 3, 4, 5 },
            new object[] { 1, 1, Math.Sqrt(2) },
            new object[] { 0, 0, 0 },
        };
    }
}
