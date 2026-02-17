using OopOrganization.Domain.Geometry.Contracts;
using OopOrganization.Domain.Geometry.Reporting;
using OopOrganization.Domain.Geometry.Shapes;

IShape[] shapes =
[
    new Rectangle(width: 10, height: 20),
    new Rectangle(width: 30, height: 50),
    new Circle(radius: 10),
];

var reporter = new ShapeReporter();
Console.WriteLine(reporter.Summary(shapes));
