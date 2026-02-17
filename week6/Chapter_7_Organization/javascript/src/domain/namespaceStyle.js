// Chapter 7: "Organizing code with objects"
// Useful in browsers when you don't want bundling.

export const App = {
  Geometry: { Shapes: {}, Reporting: {} },
};

App.Geometry.Shapes.Rectangle = class Rectangle {
  constructor(width, height) { this.width = width; this.height = height; }
  area() { return this.width * this.height; }
  perimeter() { return 2 * this.width + 2 * this.height; }
};

App.Geometry.Reporting.ShapeReporter = class ShapeReporter {
  summary(shapes) {
    return shapes
      .map((s, idx) => `${idx + 1}. ${s.constructor.name}: area=${s.area().toFixed(2)}`)
      .join("\n");
  }
};
