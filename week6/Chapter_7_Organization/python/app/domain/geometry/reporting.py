from __future__ import annotations

from typing import Iterable
from app.domain.geometry.contracts import Shape, Measurement


class ShapeReporter:
    """A small service class that formats shape results."""

    def measure(self, shape: Shape) -> Measurement:
        return Measurement(area=shape.area(), perimeter=shape.perimeter())

    def summary(self, shapes: Iterable[Shape]) -> str:
        lines: list[str] = []
        total_area = 0.0
        total_perimeter = 0.0

        for i, shape in enumerate(shapes, start=1):
            m = self.measure(shape)
            total_area += m.area
            total_perimeter += m.perimeter
            lines.append(
                f"{i}. {shape.__class__.__name__}: area={m.area:.2f}, perimeter={m.perimeter:.2f}"
            )

        lines.append("-")
        lines.append(f"TOTAL area={total_area:.2f}, TOTAL perimeter={total_perimeter:.2f}")
        return "\n".join(lines)
