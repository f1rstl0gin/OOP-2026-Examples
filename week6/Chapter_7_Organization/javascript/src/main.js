// Chapter 7 (JavaScript): runnable entry point.
//
// Run:
//   npm run demo

import { Rectangle, Circle } from "./domain/geometry/shapes/index.js";
import { ShapeReporter } from "./domain/geometry/reporting/ShapeReporter.js";

const shapes = [
  new Rectangle(10, 20),
  new Rectangle(30, 50),
  new Circle(10),
];

const reporter = new ShapeReporter();
console.log(reporter.summary(shapes));
