import { Shape } from "../contracts/Shape.js";

export class Circle extends Shape {
  constructor(radius) {
    super();
    this.radius = radius;
  }
  area() { return Math.PI * (this.radius ** 2); }
  perimeter() { return 2 * Math.PI * this.radius; }
}
