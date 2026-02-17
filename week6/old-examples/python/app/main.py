"""
Chapter 7 (Python): runnable entry point.

Run:
  python -m app.main
"""
from __future__ import annotations

from app.domain.geometry.shapes import Circle, Rectangle
from app.domain.geometry.reporting import ShapeReporter


def main() -> None:
    shapes = [
        Rectangle(width=10, height=20),
        Rectangle(width=30, height=50),
        Circle(radius=10),
    ]

    reporter = ShapeReporter()
    print(reporter.summary(shapes))


if __name__ == "__main__":
    main()
