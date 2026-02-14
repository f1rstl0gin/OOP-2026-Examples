// Minimal "interface" contract by convention:
// any Shape must implement area() and perimeter()
export class Shape {
  area() { throw new Error("Not implemented"); }
  perimeter() { throw new Error("Not implemented"); }
}
