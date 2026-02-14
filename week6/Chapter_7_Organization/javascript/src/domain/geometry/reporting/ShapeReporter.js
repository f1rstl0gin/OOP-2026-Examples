export class ShapeReporter {
  measure(shape) {
    return { area: shape.area(), perimeter: shape.perimeter() };
  }

  summary(shapes) {
    let totalArea = 0;
    let totalPerimeter = 0;

    const lines = [];
    let i = 1;

    for (const shape of shapes) {
      const m = this.measure(shape);
      totalArea += m.area;
      totalPerimeter += m.perimeter;
      lines.push(`${i}. ${shape.constructor.name}: area=${m.area.toFixed(2)}, perimeter=${m.perimeter.toFixed(2)}`);
      i += 1;
    }

    lines.push("-");
    lines.push(`TOTAL area=${totalArea.toFixed(2)}, TOTAL perimeter=${totalPerimeter.toFixed(2)}`);
    return lines.join("\n");
  }
}
