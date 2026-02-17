using OopOrganization.Domain.Geometry.Contracts;

namespace OopOrganization.Domain.Geometry.Reporting;

public sealed class ShapeReporter
{
    public string Summary(IEnumerable<IShape> shapes)
    {
        var lines = new List<string>();
        double totalArea = 0;
        double totalPerimeter = 0;

        int i = 1;
        foreach (var shape in shapes)
        {
            var area = shape.Area();
            var perimeter = shape.Perimeter();
            totalArea += area;
            totalPerimeter += perimeter;

            lines.Add($"{i}. {shape.GetType().Name}: area={area:F2}, perimeter={perimeter:F2}");
            i++;
        }

        lines.Add("-");
        lines.Add($"TOTAL area={totalArea:F2}, TOTAL perimeter={totalPerimeter:F2}");
        return string.Join(Environment.NewLine, lines);
    }
}
