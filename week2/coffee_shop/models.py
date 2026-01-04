from dataclasses import dataclass, field
from typing import List


@dataclass(frozen=True)
class MenuItem:
    name: str
    price: float

    def display(self) -> str:
        return f"{self.name} - ${self.price:.2f}"


@dataclass
class Order:
    items: List[MenuItem] = field(default_factory=list)

    def add_item(self, item: MenuItem) -> None:
        self.items.append(item)

    def total(self) -> float:
        return sum(item.price for item in self.items)

    def summary(self) -> str:
        lines = [item.display() for item in self.items]
        lines.append(f"Total: ${self.total():.2f}")
        return "\n".join(lines)


@dataclass
class CoffeeShop:
    name: str
    menu: List[MenuItem]

    def create_order(self) -> Order:
        return Order()

    def find_item(self, item_name: str) -> MenuItem | None:
        for item in self.menu:
            if item.name.lower() == item_name.lower():
                return item
        return None
