from __future__ import annotations

from dataclasses import dataclass
from math import pi
from app.domain.geometry.contracts import Shape


@dataclass(frozen=True, slots=True)
class Rectangle(Shape):
    width: float
    height: float

    def area(self) -> float:
        return self.width * self.height

    def perimeter(self) -> float:
        return 2 * self.width + 2 * self.height


@dataclass(frozen=True, slots=True)
class Circle(Shape):
    radius: float

    def area(self) -> float:
        return pi * (self.radius ** 2)

    def perimeter(self) -> float:
        return 2 * pi * self.radius
