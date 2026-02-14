using OopOrganization.Domain.Geometry.Contracts;

namespace OopOrganization.Domain.Geometry.Shapes;

public sealed class Circle : IShape
{
    public double Radius { get; }

    public Circle(double radius) => Radius = radius;

    public double Area() => Math.PI * Radius * Radius;

    public double Perimeter() => 2 * Math.PI * Radius;
}
