import { Shape } from "../contracts/Shape.js";

export class Rectangle extends Shape {
  constructor(width, height) {
    super();
    this.width = width;
    this.height = height;
  }
  area() { return this.width * this.height; }
  perimeter() { return 2 * this.width + 2 * this.height; }
}
