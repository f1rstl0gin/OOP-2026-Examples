using OopOrganization.Domain.Geometry.Contracts;

namespace OopOrganization.Domain.Geometry.Shapes;

public sealed class Rectangle : IShape
{
    public double Width { get; }
    public double Height { get; }

    public Rectangle(double width, double height)
    {
        Width = width;
        Height = height;
    }

    public double Area() => Width * Height;

    public double Perimeter() => 2 * Width + 2 * Height;
}
