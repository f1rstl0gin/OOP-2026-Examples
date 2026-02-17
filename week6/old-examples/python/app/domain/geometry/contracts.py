from __future__ import annotations

from dataclasses import dataclass
from abc import ABC, abstractmethod


class Shape(ABC):
    """A small interface-style contract for shapes."""

    @abstractmethod
    def area(self) -> float:
        raise NotImplementedError

    @abstractmethod
    def perimeter(self) -> float:
        raise NotImplementedError


@dataclass(frozen=True)
class Measurement:
    """A value object to carry calculated measurements."""
    area: float
    perimeter: float
