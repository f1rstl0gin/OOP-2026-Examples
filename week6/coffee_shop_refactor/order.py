from dataclasses import dataclass, field
from typing import List

from catalog import Beverage


@dataclass
class Order:
    items: List[Beverage] = field(default_factory=list)

    def add(self, item: Beverage) -> None:
        self.items.append(item)

    def total(self) -> float:
        return sum(item.price for item in self.items)

    def receipt(self) -> str:
        lines = [item.display() for item in self.items]
        lines.append(f"Total: ${self.total():.2f}")
        return "\n".join(lines)
