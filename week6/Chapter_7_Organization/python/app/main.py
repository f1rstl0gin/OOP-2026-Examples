"""
Chapter 7 (Python): runnable entry point.

Preferred (recommended) run style from the *python* folder:
  python -m app.main

This file also supports direct execution:
  python app/main.py

Direct execution requires ensuring the project root is on sys.path; we add it automatically below.
"""
from __future__ import annotations

# Allow running as a script: `python app/main.py`
# When executed this way, Python sets sys.path to the *app/* folder, not the project root,
# so absolute imports like `from app.domain...` would fail without this.
if __name__ == "__main__" and __package__ is None:
    import os
    import sys
    sys.path.insert(0, os.path.dirname(os.path.dirname(__file__)))

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
